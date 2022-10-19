package com.dojo.productservice;

import com.dojo.productservice.controller.ProductsController;
import com.dojo.productservice.models.Product;
import com.fasterxml.jackson.databind.ObjectMapper;

import static org.hamcrest.Matchers.containsString;
import static org.junit.jupiter.api.Assertions.assertNotNull;
import static org.mockito.Mockito.when;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.result.MockMvcResultHandlers.print;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.content;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

import java.math.BigDecimal;

import org.junit.jupiter.api.Test;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.http.MediaType;
import org.springframework.test.web.servlet.MockMvc;
import org.springframework.test.web.servlet.MvcResult;
import org.springframework.test.web.servlet.request.MockMvcRequestBuilders;
import org.springframework.test.web.servlet.result.MockMvcResultMatchers;

@WebMvcTest(ProductsController.class)
public class WebLayerTest {

	@Autowired
	private MockMvc mockMvc;

	@Test
	public void getProducts() throws Exception {

        Product product = new Product(1L, "Chai Boot 1", new BigDecimal(18.0d), 100, false);

		this.mockMvc
            .perform(get("/api/products"))
            .andDo(print())
            .andExpect(status().isOk())
			.andExpect(content().string(containsString(product.getName())));
	}

    @Test
    public void getProductById() throws Exception {

        Product product = new Product(1L, "Chai Boot 1", new BigDecimal(18.0d), 100, false);
        
        this.mockMvc.perform(MockMvcRequestBuilders
            .get("/api/products/{id}", product.getId())
            .accept(MediaType.APPLICATION_JSON))
            .andDo(print())          
            .andExpect(status().isOk())
            .andExpect(MockMvcResultMatchers.jsonPath("$.name").exists())
            .andExpect(MockMvcResultMatchers.jsonPath("$.name").isNotEmpty());
    }    
     
    @Test
    public void createProduct() throws Exception 
    {
      this.mockMvc.perform( MockMvcRequestBuilders
          .post("/api/products")
          .content(asJsonString(new Product(99L, "Tea for Two", new BigDecimal(99.0d), 990, false)))
          .contentType(MediaType.APPLICATION_JSON)
          .accept(MediaType.APPLICATION_JSON))
          .andExpect(status().isCreated())
          .andExpect(MockMvcResultMatchers.jsonPath("$.id").exists());
    }
     
    @Test
    public void updateProduct() throws Exception 
    {
        this.mockMvc.perform( MockMvcRequestBuilders
          .put("/api/products/{id}", 2L)
          .content(asJsonString(new Product(2L, "Chai Latte", new BigDecimal(32.0d), 199, false)))
          .contentType(MediaType.APPLICATION_JSON)
          .accept(MediaType.APPLICATION_JSON))
          .andExpect(status().isOk())
          .andExpect(MockMvcResultMatchers.jsonPath("$.name").value("Chai Latte"));
    }

    @Test
    public void deleteProduct() throws Exception 
    {
        this.mockMvc.perform( MockMvcRequestBuilders.delete("/api/products/{id}", 2L) )
            .andExpect(status().isNoContent());
    }

    public static String asJsonString(final Object obj) {
        try {
            return new ObjectMapper().writeValueAsString(obj);
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }    
}


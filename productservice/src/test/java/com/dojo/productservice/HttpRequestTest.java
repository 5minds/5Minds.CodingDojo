package com.dojo.productservice;

import org.junit.jupiter.api.Test;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.boot.test.context.SpringBootTest.WebEnvironment;
import org.springframework.boot.test.web.client.TestRestTemplate;
import org.springframework.boot.web.server.LocalServerPort;
import org.springframework.http.ResponseEntity;

import static org.assertj.core.api.Assertions.assertThat;

import java.net.URI;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

import com.dojo.productservice.models.Product;

@SpringBootTest(webEnvironment = WebEnvironment.RANDOM_PORT)
public class HttpRequestTest {

	@LocalServerPort
	private int port;

	@Autowired
	private TestRestTemplate restTemplate;

    @Test
    public void getProduct() throws Exception
    {   
        // Arrange
        String url = "http://localhost:" + port + "/api/products/{id}";
        long id = 1L;

        // Act
        ResponseEntity<Product> result = restTemplate.getForEntity(url, Product.class, id);
                
        // Assert
        assertThat(result.getStatusCodeValue()).isEqualTo(200);
        assertThat(result.getBody().getId()).isEqualTo(id);
    }

	@Test
	public void getProducts() throws Exception {    
        // Arrange
        String url = "http://localhost:" + port + "/api/products";
    
        // Act
        Product[] result = restTemplate.getForObject(url, Product[].class);
        
        // Assert
        assertThat(result.length).isGreaterThan(0);
	}

}

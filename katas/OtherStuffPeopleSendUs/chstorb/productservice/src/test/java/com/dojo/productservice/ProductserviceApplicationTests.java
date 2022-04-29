package com.dojo.productservice;

import com.dojo.productservice.controller.ProductsController;

import static org.assertj.core.api.Assertions.assertThat;

import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;

@SpringBootTest
class ProductserviceApplicationTests {

	// Inject the controller.
	@Autowired
	private ProductsController controller;

	@Test
	public void contextLoads() throws Exception {
		assertThat(controller).isNotNull();
	}

}

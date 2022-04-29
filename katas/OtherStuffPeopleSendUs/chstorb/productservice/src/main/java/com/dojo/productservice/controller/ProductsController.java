package com.dojo.productservice.controller;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import com.dojo.productservice.models.Product;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.server.ResponseStatusException;

@RestController
@RequestMapping("/api")
public class ProductsController {

    private List<Product> db = new ArrayList<Product>();

    public ProductsController() {
        db.add(new Product(1L, "Chai Boot 1", new BigDecimal(18.0d), 100, false));
        db.add(new Product(2L, "Chai Boot 2", new BigDecimal(28.0d), 200, false));
        db.add(new Product(3L, "Chai Boot 3", new BigDecimal(38.0d), 300, false));
        db.add(new Product(4L, "Chai Boot 4", new BigDecimal(48.0d), 400, false));
    }

    @PostMapping("/products")
    public ResponseEntity<Product> createProduct(@RequestBody Product product) {
        try {
            Product existingProduct = findByName(product.getName());
            if (existingProduct != null) {
                return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
            }
            db.add(product);
            return new ResponseEntity<Product>(product, HttpStatus.CREATED);
        } catch (Exception e) {
        return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }
        
    @GetMapping("/products")
    public ResponseEntity<List<Product>> getProducts() {
        try {
            return new ResponseEntity<List<Product>>(db, HttpStatus.OK);
        } catch (Exception ex) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

	@GetMapping("/products/{id}")
	public ResponseEntity<Product> getProduct(@PathVariable Long id) {
        try {
            Product product = findById(id);
            if (product != null) {
                return new ResponseEntity<Product>(product, HttpStatus.OK);
            }            
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        } catch (Exception ex) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
	}    

    @PutMapping("/products/{id}")
    public ResponseEntity<Product> updateProduct(@PathVariable("id") long id, @RequestBody Product product) {
        try {
            Product existingProduct = findById(id);
            if (existingProduct != null) {
                existingProduct.setName(product.getName());
                existingProduct.setUnitPrice(product.getUnitPrice());
                existingProduct.setUnitsInStock(product.getUnitsInStock());
                return new ResponseEntity<Product>(existingProduct, HttpStatus.OK);
            } else {
                return new ResponseEntity<Product>(HttpStatus.NOT_FOUND);
            }
        } catch (Exception ex) {
            return new ResponseEntity<>(null, HttpStatus.INTERNAL_SERVER_ERROR);
        }
    }

    @DeleteMapping("/products/{id}")
    public ResponseEntity<HttpStatus> deleteProduct(@PathVariable("id") Long id) {
      try {       
        Product productToDelete = findById(id);
        if (productToDelete != null) {
            db.remove(productToDelete);
            return new ResponseEntity<>(HttpStatus.NO_CONTENT);
        } else {
            return new ResponseEntity<>(HttpStatus.NOT_FOUND);
        }
      } catch (Exception ex) {
            return new ResponseEntity<>(HttpStatus.INTERNAL_SERVER_ERROR);
      }
    }    

    private Product findById(Long id) {
        for(Product product : db) {
            if (product.getId() == id) {
                return product;
            }
        }
        return null;
    }

    private Product findByName(String name) {
        for(Product product : db) {
            if (product.getName().equals(name)) {
                return product;
            }
        }
        return null;
    }
}

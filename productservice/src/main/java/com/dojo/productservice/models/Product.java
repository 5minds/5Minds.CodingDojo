package com.dojo.productservice.models;

import java.math.BigDecimal;

import com.fasterxml.jackson.databind.deser.std.NumberDeserializers.BigDecimalDeserializer;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@JsonIgnoreProperties(ignoreUnknown = true)
public class Product {

	private long id;
	private String name;
    private BigDecimal unitPrice;
    private int unitsInStock;
    private boolean discontinued;

    public Product() 
    {
        
    }

	public Product(long id, String name, BigDecimal unitPrice, int unitsInStock, boolean discontinued) {
		this.id = id;
		this.name = name;
        this.unitPrice = unitPrice;
        this.unitsInStock = unitsInStock;
        this.discontinued = discontinued;
	}

	public long getId() {
		return id;
	}

    public void setId(long id) {
        this.id = id;
    }

	public String getName() {
		return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BigDecimal getUnitPrice() {
        return unitPrice;
    }

    public void setUnitPrice(BigDecimal unitPrice) {
        this.unitPrice = unitPrice;
    }

    public int getUnitsInStock() {
        return unitsInStock;
    }

    public void setUnitsInStock(int unitsInStock) {
        this.unitsInStock = unitsInStock;
    }

    public boolean getDiscontinued() {
        return discontinued;        
    }

    public void setDiscontinued(boolean discontinued) {
        this.discontinued = discontinued;
    }
}


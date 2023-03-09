﻿namespace VicTechTask.Products;

public class Crisps : IProduct
{
    public Crisps(string name, double price, int quantity, int code)
    {
        this.name = name;
        this.price = price;
        this.quantity = quantity;
        this.code = code;
    }

    public string name { get; set; }
    public double price { get; set; }
    public int quantity { get; set; }
    public int code { get; set; }
}
﻿namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Title { get; private set; }
    public Decimal Price { get; private set; }
    public bool Active { get; private set; }

    public Product(string title, decimal price, bool active)
    {
        Title = title;
        Price = price;
        Active = active;
    }
}
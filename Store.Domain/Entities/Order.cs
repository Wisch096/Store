﻿using Flunt.Validations;
using Store.Domain.Enums;

namespace Store.Domain.Entities;

public class Order : Entity
{
    public Order(Customer customer, decimal deliveryFee, Discount discount)
    {
        AddNotifications(
            new Contract<Order>()
                .Requires()
                .IsNotNull(customer, "Customer", "customer is required")
            );
        
        Customer = customer;
        Date = DateTime.Now;
        Number = Guid.NewGuid().ToString()[..8];
        Status = EOrderStatus.WaitingPayment;
        DeliveryFee = deliveryFee;
        Discount = discount;
        Items = new List<OrderItem>();
    }
    
    public Customer Customer { get; set; }
    public DateTime Date { get; set; }
    public string Number { get; set; }
    public IList<OrderItem> Items { get; set; }
    public decimal DeliveryFee { get; set; }
    public Discount Discount { get; set; }
    public EOrderStatus Status { get; set; }

    public void AddItem(Product product, int quantity)
    {
        var item = new OrderItem(product, quantity);
        
        if(item.IsValid)
            Items.Add(item);
    }

    public decimal Total()
    {
        decimal total = 0;
        foreach (var item in Items)
        {
            total += item.Total();
        }
        
        total += DeliveryFee;
        total -= Discount.Value();

        return total;
    }

    public void Pay(decimal amount)
    {
        if (amount == Total())
            this.Status = EOrderStatus.WaitingDelivery;
    }

    public void Cancel()
    {
        this.Status = EOrderStatus.Canceled;
    }
}
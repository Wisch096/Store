using Flunt.Validations;

namespace Store.Domain.Entities;

public class OrderItem : Entity
{
    public OrderItem(Product product, int quantity)
    {
        AddNotifications(
            new Contract<Order>()
                .Requires()
                .IsNotNull(product, "Product", "Product is required")
                .IsGreaterThan(quantity, 0, "Quantity", "Quantity must be greater than 0")
        );
        
        Product = product;
        Price = Product != null ? Product.Price : 0;
        Quantity = quantity;
    }
    
    public Product Product { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public decimal Total()
    {
        return Price * Quantity;
    }
}
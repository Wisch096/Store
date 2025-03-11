using Flunt.Notifications;
using Flunt.Validations;

namespace Store.Domain.Commands.Interfaces;

public class CreateOrderItemCommand : Notifiable<Notification>, ICommand
{
    public CreateOrderItemCommand(Guid product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public CreateOrderItemCommand() { }

    public Guid Product { get; set; }
    public int Quantity { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<CreateOrderItemCommand>()
            .Requires()
            .IsGreaterThan(Quantity, 0, "Quantity", "Quantity must be greater than 0")
            .AreEquals(Product.ToString(), 32, "Product", "Product must be 32 characters long")
        );
    }
}
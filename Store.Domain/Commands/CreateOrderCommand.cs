using Flunt.Notifications;
using Flunt.Validations;
using Store.Domain.Commands.Interfaces;

namespace Store.Domain.Commands;

public class CreateOrderCommand : Notifiable<Notification>, ICommand
{
    public CreateOrderCommand(string customer, string zipCode, string promoCode, IList<CreateOrderItemCommand> items)
    {
        Customer = customer;
        ZipCode = zipCode;
        PromoCode = promoCode;
        Items = items;
    }

    public CreateOrderCommand()
    {
        Items = new List<CreateOrderItemCommand>();
    }

    public string Customer { get; set; }

    public string ZipCode { get; set; }

    public string PromoCode { get; set; }
    public IList<CreateOrderItemCommand> Items { get; set; }
    
    public void Validate()
    {
        AddNotifications(new Contract<CreateOrderCommand>()
            .Requires()
            .IsGreaterThan(PromoCode.Length, 3, "PromoCode", "PromoCode must have length 3 or more")
        );
    }
}
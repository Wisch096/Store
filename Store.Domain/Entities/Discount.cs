namespace Store.Domain.Entities;

public class Discount : Entity
{
    public Discount(decimal amout, DateTime expireDate)
    {
        Amout = amout;
        ExpireDate = expireDate;
    }

    public decimal Amout { get; set; }
    public DateTime ExpireDate { get; set; }

    public bool IsValid()
    {
        return DateTime.Compare(DateTime.Now, ExpireDate) < 0;
    }

    public decimal Value()
    {
        return IsValid() ? Amout : 0;
    }
}
namespace Server.Entities.Pedido;

public class FinalOrder
{
    public Guid Id { get; set; }
    public required ApplicationUser Client { get; set; }
    public required string Address { get; set; }
    public required ICollection<Order> Orders { get; set; }
    public required float Price { get; set; }
}
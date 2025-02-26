namespace Server.Entities.Pedido;

public class FinalOrder
{
    public required ApplicationUser Client { get; set; }
    public required string Address { get; set; }
    public required ICollection<Order> Orders { get; set; }
    public required float Price { get; set; }
}
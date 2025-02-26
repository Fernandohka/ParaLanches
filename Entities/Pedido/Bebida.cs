namespace Server.Entities.Pedido;

public class Bebida
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required float Price { get; set; }
    public float Rating { get; set; } = 0;
}
namespace Server.Entities.Pedido;

public class Ingrediente
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required float Price { get; set; }
}
using Server.Entities.Pedido;

namespace Server.Entities.Pedido;

public class Lanche
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required float Price { get; set; }
    public required ICollection<Ingrediente> Ingredientes { get; set; }
    public ICollection<Ingrediente>? Adicionais { get; set; }
    public float Rating { get; set; }
}
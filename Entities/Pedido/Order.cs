using Server.Entities;
using Server.Entities.Pedido;

namespace Server.Entities.Pedido;

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Lanche? Lanches{ get; set; }
    public Bebida? Bebidas{ get; set; }
    public ICollection<Ingrediente>? Adicionais { get; set; }
    public ICollection<Ingrediente>? Removidos { get; set; }
    public required float Price { get; set; }
}
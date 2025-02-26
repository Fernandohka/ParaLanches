using Server.Entities;
using Server.Entities.Pedido;

namespace Server.Entities.Pedido;

public class Review
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required ApplicationUser Client { get; set; }
    public required int Rating { get; set; }
    public string? Description { get; set; }
    public string? Title { get; set; }
    public Bebida? Bebida { get; set; }
    public Lanche? Lanche { get; set; }

}
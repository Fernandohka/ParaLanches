using System.ComponentModel.DataAnnotations;
using Server.Entities.Pedido;

namespace Server.Models;

public record LancheData(
    [Required]
    string Name,
    [Required]
    string Description,
    [Required]
    float Price,
    [Required]
    ICollection<Guid> IngredientesId,
    ICollection<Guid> AdicionaisId,
    float Rating
) {}
using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public record IngredienteData(
    [Required]
    string Name,
    [Required]
    float Price
) {}
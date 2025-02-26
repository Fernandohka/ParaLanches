using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public record BebidaData(
    [Required]
    string Name,
    [Required]
    string Description,
    [Required]
    float Price
) {}
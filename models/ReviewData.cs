using System.ComponentModel.DataAnnotations;

namespace Server.Models;

public record ReviewData(
    [Required]
    Guid ClientId,
    [Required]
    int Rating,
    string Description,
    string Title,
    Guid BebidaId,
    Guid LancheId
) {}
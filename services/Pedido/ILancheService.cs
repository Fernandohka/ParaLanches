using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public interface ILancheService{
    Task<ICollection<Lanche>> GetLanches();
    Task<Lanche> GetLancheById(Guid Id);
    Task<Lanche> CreateLanche(LancheData data);
    Boolean DeleteLanche(Guid Id);
}
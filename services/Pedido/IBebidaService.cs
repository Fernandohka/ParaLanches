using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public interface IBebidaService{
    Task<ICollection<Bebida>> GetBebidas();
    Task<Bebida> GetBebidaById(Guid Id);
    Task<Bebida> CreateBebida(BebidaData data);
    Task<Boolean> DeleteBebida(Guid Id);
}
using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public interface IIngredienteService{
    Task<ICollection<Ingrediente>> GetIngredientes();
    Task<Ingrediente> GetIngredienteById(Guid Id);
    Task<Ingrediente> CreateIngrediente(IngredienteData data);
    Task<Boolean> DeleteIngrediente(Guid Id);
}
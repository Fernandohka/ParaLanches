using Server.Entities;
using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public class EFIngredienteService(ParaLanchesDbContext ctx) : IIngredienteService
{
    public async Task<Ingrediente> CreateIngrediente(IngredienteData data)
    {
        var ing = new Ingrediente{
            Name = data.Name,
            Price = data.Price
        };

        ctx.Add(ing);
        await ctx.SaveChangesAsync();

        return ing;
    }

    public bool DeleteIngrediente(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<Ingrediente> GetIngredienteById(Guid Id)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Ingrediente>> GetIngredientes()
    {
        throw new NotImplementedException();
    }
}
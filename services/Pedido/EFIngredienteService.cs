using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Boolean> DeleteIngrediente(Guid Id)
    {
        var ingredientes = 
            from ing in ctx.Ingredientes
            where ing.Id == Id
            select ing;
        
        var Ingrediente = ingredientes.FirstOrDefault();

        if (Ingrediente is null)
            return false;
        
        ctx.Remove(Ingrediente);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Ingrediente?> GetIngredienteById(Guid Id)
    {
        var ingredientes = 
            from ing in ctx.Ingredientes
            where ing.Id == Id
            select ing;
        
        return await ingredientes.FirstOrDefaultAsync() switch
        {
            Ingrediente ingrediente => ingrediente,
            _ => null
        };
    }

    public async Task<ICollection<Ingrediente>> GetIngredientes()
    {
        var ingredientes =
            from ing in ctx.Ingredientes
            select ing;
        
        return await ingredientes.ToListAsync();
    }
}
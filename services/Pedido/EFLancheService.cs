using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public class EFLancheService(ParaLanchesDbContext ctx) : ILancheService
{
    public async Task<Lanche> CreateLanche(LancheData data)
    {
        var lanche = new Lanche{
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            IngredientesId = data.IngredientesId,
            Rating = data.Rating
        };

        ctx.Add(lanche);
        await ctx.SaveChangesAsync();

        return lanche;
    }

    public async Task<Boolean> DeleteLanche(Guid Id)
    {
        var lanches = 
            from l in ctx.Lanches
            where l.Id == Id
            select l;
        
        var lanche = lanches.FirstOrDefaultAsync();

        if (lanche is null)
            return false;
        
        ctx.Remove(lanche);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Lanche?> GetLancheById(Guid Id)
    {
        var lanches = 
            from l in ctx.Lanches
            where l.Id == Id
            select l;

        return await lanches.FirstOrDefaultAsync() switch
        {
            Lanche lanche => lanche,
            _ => null
        };
    }

    public async Task<ICollection<Lanche>> GetLanches()
    {
        var lanches =
            from l in ctx.Lanches
            select l;
        
        return await lanches.ToListAsync();
    }
}
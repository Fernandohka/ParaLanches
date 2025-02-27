using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public class EFBebidaService(ParaLanchesDbContext ctx) : IBebidaService
{
    public async Task<Bebida> CreateBebida(BebidaData data)
    {
        var bebida = new Bebida{
            Name = data.Name,
            Description = data.Description,
            Price = data.Price,
            Rating = 0
        };

        ctx.Add(bebida);
        await ctx.SaveChangesAsync();

        return bebida;
    }

    public async Task<Boolean> DeleteBebida(Guid Id)
    {
        var bebidas = 
            from b in ctx.Bebidas
            where b.Id == Id
            select b;
        
        var bebida = bebidas.FirstOrDefault();
        
        if(bebida is null)
            return false;

        ctx.Remove(bebida);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<Bebida?> GetBebidaById(Guid Id)
    {
        var bebidas = 
            from b in ctx.Bebidas
            where b.Id == Id
            select b;

        return await bebidas.FirstOrDefaultAsync() switch
        {
            Bebida bebida => bebida,
            _ => null
        };
    }

    public async Task<ICollection<Bebida>> GetBebidas()
    {
        var bebidas = 
            from b in ctx.Bebidas
            select b;

        return await bebidas.ToListAsync();
    }
}
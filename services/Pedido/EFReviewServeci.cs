using Microsoft.EntityFrameworkCore;
using Server.Entities;
using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public class EFReviewService(ParaLanchesDbContext ctx) : IReviewService
{
    public async Task<Review> CreateReview(ReviewData data)
    {
        var clients = 
            from c in ctx.Users
            where c.Id == data.ClientId
            select c;
        
        var bebidas =
            from b in ctx.Bebidas
            where b.Id == data.BebidaId
            select b;
        
        var lanches =
            from l in ctx.Lanches
            where l.Id == data.LancheId
            select l;

        var client = await clients.FirstOrDefaultAsync();
        var bebida = await bebidas.FirstOrDefaultAsync();
        var lanche = await lanches.FirstOrDefaultAsync();
        if (client is null || bebida is null || lanche is null)
            return null;

        var review = new Review{
            Client = client,
            Rating = data.Rating,
            Description = data.Description,
            Title = data.Title,
            Bebida = bebida,
            Lanche = lanche
        };

        ctx.Add(review);
        await ctx.SaveChangesAsync();

        return review;
    }

    public async Task<Boolean> DeleteReview(Guid Id)
    {
        var reviews = 
            from r in ctx.Reviews
            where r.Id == Id
            select r;
        
        var review = reviews.FirstOrDefault();

        if (review is null)
            return false;

        ctx.Remove(review);
        await ctx.SaveChangesAsync();

        return true;
    }

    public async Task<ICollection<Review>?> GetReviewsByClientId(Guid ClientId)
    {
        var reviews =
            from r in ctx.Reviews
            where r.Client.Id == ClientId
            select r;

        return await reviews.FirstOrDefaultAsync() switch
        {
            ICollection<Review> review => review,
            _ => null
        };
    }

    public async Task<ICollection<Review>?> GetReviewsByProductId(Guid LancheId, Guid BebidaId)
    {
        

        var reviews =
            from r in ctx.Reviews
            where r.Lanche.Id == LancheId || r.Bebida.Id == BebidaId
            select r;

        return await reviews.FirstOrDefaultAsync() switch
        {
            ICollection<Review> review => review,
            _ => null
        };
    }
}
using Server.Entities.Pedido;
using Server.Models;

namespace Server.Services.Pedido;

public interface IReviewService{
    Task<ICollection<Review>> GetReviewsByClientId(Guid ClientId);
    Task<ICollection<Review>> GetReviewsByProductId(Guid LancheId, Guid BebidaId);
    Task<Review> CreateReview(ReviewData data);
    Task<Boolean> DeleteReview(Guid Id);
}
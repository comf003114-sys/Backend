using ChaChaClub.Domains.Models.Review;

namespace ChaChaClub.BusinessLogic.Interface
{
    public interface IReviews
    {
        Task<List<ReviewDto>> GetByDish(int dishId);
        Task Create(CreateReviewDto dto, int userId);
        Task Delete(int id);
    }
}
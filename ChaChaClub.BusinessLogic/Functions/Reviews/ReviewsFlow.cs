using AutoMapper;
using ChaChaClub.BusinessLogic.Core.Reviews;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;
using ChaChaClub.Domains.Entities.Review;
using ChaChaClub.Domains.Models.Review;

namespace ChaChaClub.BusinessLogic.Functions.Reviews
{
    public class ReviewsFlow : ReviewsActions, IReviews
    {
        public ReviewsFlow(DbSession session, IMapper mapper) : base(session, mapper)
        {
        }

        public async Task<List<ReviewDto>> GetByDish(int dishId)
        {
            var reviews = await GetReviewsByDish(dishId);
            return _mapper.Map<List<ReviewDto>>(reviews);
        }

        public async Task Create(CreateReviewDto dto, int userId)
        {
            var review = new ReviewData
            {
                Comment = dto.Comment,
                Rating = dto.Rating,
                DishId = dto.DishId,
                UserId = userId
            };
            await CreateReview(review);
        }

        public async Task Delete(int id)
        {
            var review = await GetReviewById(id);
            if (review == null)
                throw new Exception("Review not found");
            await DeleteReview(review);
        }
    }
}
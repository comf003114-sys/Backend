using AutoMapper;
using ChaChaClub.DataAccess;
using ChaChaClub.DataAccess.Context;
using ChaChaClub.Domains.Entities.Review;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.BusinessLogic.Core.Reviews
{
    public class ReviewsActions
    {
        private readonly DbSession _session;
        protected readonly IMapper _mapper;

        public ReviewsActions(DbSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        protected async Task<List<ReviewData>> GetReviewsByDish(int dishId)
        {
            using var context = new RestaurantContext(_session);
            return await context.Reviews
                .Include(r => r.User)
                .Include(r => r.Dish)
                .Where(r => r.DishId == dishId)
                .ToListAsync();
        }

        protected async Task CreateReview(ReviewData review)
        {
            using var context = new RestaurantContext(_session);
            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }

        protected async Task<ReviewData> GetReviewById(int id)
        {
            using var context = new RestaurantContext(_session);
            return await context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
        }

        protected async Task DeleteReview(ReviewData review)
        {
            using var context = new RestaurantContext(_session);
            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
        }
    }
}
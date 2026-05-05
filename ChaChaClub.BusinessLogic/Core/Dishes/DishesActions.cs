using AutoMapper;
using ChaChaClub.DataAccess;
using ChaChaClub.DataAccess.Context;
using ChaChaClub.Domains.Entities.Dish;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.BusinessLogic.Core.Dishes
{
    public class DishesActions
    {
        private readonly DbSession _session;
        protected readonly IMapper _mapper;

        public DishesActions(DbSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        protected async Task<List<DishData>> GetAllDishes()
        {
            using var context = new RestaurantContext(_session);
            return await context.Dishes.Include(d => d.Category).ToListAsync();
        }

        protected async Task<List<DishData>> GetDishesByCategory(int categoryId)
        {
            using var context = new RestaurantContext(_session);
            return await context.Dishes
                .Include(d => d.Category)
                .Where(d => d.CategoryId == categoryId)
                .ToListAsync();
        }

        protected async Task<DishData> GetDishById(int id)
        {
            using var context = new RestaurantContext(_session);
            return await context.Dishes
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        protected async Task<DishData> GetDailyDish()
        {
            using var context = new RestaurantContext(_session);
            return await context.Dishes
                .Include(d => d.Category)
                .FirstOrDefaultAsync(d => d.IsDailyDish == true);
        }

        protected async Task CreateDish(DishData dish)
        {
            using var context = new RestaurantContext(_session);
            await context.Dishes.AddAsync(dish);
            await context.SaveChangesAsync();
        }

        protected async Task UpdateDish(DishData dish)
        {
            using var context = new RestaurantContext(_session);
            context.Dishes.Update(dish);
            await context.SaveChangesAsync();
        }

        protected async Task DeleteDish(DishData dish)
        {
            using var context = new RestaurantContext(_session);
            context.Dishes.Remove(dish);
            await context.SaveChangesAsync();
        }
    }
}
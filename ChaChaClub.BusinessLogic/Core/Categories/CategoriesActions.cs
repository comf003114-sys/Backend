using AutoMapper;
using ChaChaClub.DataAccess;
using ChaChaClub.DataAccess.Context;
using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Models.Dish;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.BusinessLogic.Core.Categories
{
    public class CategoriesActions
    {
        private readonly DbSession _session;
        protected readonly IMapper _mapper;

        public CategoriesActions(DbSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        protected async Task<List<CategoryData>> GetAllCategories()
        {
            using var context = new RestaurantContext(_session);
            return await context.Categories.ToListAsync();
        }

        protected async Task<CategoryData> GetCategoryById(int id)
        {
            using var context = new RestaurantContext(_session);
            return await context.Categories.FirstOrDefaultAsync(c => c.Id == id);
        }

        protected async Task CreateCategory(CategoryData category)
        {
            using var context = new RestaurantContext(_session);
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        protected async Task UpdateCategory(CategoryData category)
        {
            using var context = new RestaurantContext(_session);
            context.Categories.Update(category);
            await context.SaveChangesAsync();
        }

        protected async Task DeleteCategory(CategoryData category)
        {
            using var context = new RestaurantContext(_session);
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
        }
    }
}
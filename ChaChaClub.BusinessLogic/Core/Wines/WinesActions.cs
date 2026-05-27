using AutoMapper;
using ChaChaClub.DataAccess;
using ChaChaClub.DataAccess.Context;
using ChaChaClub.Domains.Entities.Wine;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.BusinessLogic.Core.Wines
{
    public class WinesActions
    {
        private readonly DbSession _session;
        protected readonly IMapper _mapper;

        public WinesActions(DbSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        protected async Task<List<WineData>> GetAllWines()
        {
            using var context = new RestaurantContext(_session);
            return await context.Wines.ToListAsync();
        }

        protected async Task<List<WineData>> GetWinesByCategory(string category)
        {
            using var context = new RestaurantContext(_session);
            return await context.Wines
                .Where(w => w.Category == category)
                .ToListAsync();
        }

        protected async Task<WineData> GetWineById(int id)
        {
            using var context = new RestaurantContext(_session);
            return await context.Wines.FirstOrDefaultAsync(w => w.Id == id);
        }

        protected async Task CreateWine(WineData wine)
        {
            using var context = new RestaurantContext(_session);
            await context.Wines.AddAsync(wine);
            await context.SaveChangesAsync();
        }

        protected async Task UpdateWine(WineData wine)
        {
            using var context = new RestaurantContext(_session);
            context.Wines.Update(wine);
            await context.SaveChangesAsync();
        }

        protected async Task DeleteWine(WineData wine)
        {
            using var context = new RestaurantContext(_session);
            context.Wines.Remove(wine);
            await context.SaveChangesAsync();
        }
    }
}
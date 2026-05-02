using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Entities.Review;
using ChaChaClub.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.DataAccess.Context
{
    public class RestaurantContext : DbContext
    {
        private readonly DbSession _session;

        public RestaurantContext(DbSession session)
        {
            _session = session;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_session.ConnectionString);
        }

        public DbSet<UserData> Users { get; set; }
        public DbSet<CategoryData> Categories { get; set; }
        public DbSet<DishData> Dishes { get; set; }
        public DbSet<IngredientData> Ingredients { get; set; }
        public DbSet<ReviewData> Reviews { get; set; }
    }
}
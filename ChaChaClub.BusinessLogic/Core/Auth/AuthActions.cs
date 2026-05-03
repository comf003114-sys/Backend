using ChaChaClub.DataAccess.Context;
using ChaChaClub.DataAccess;
using ChaChaClub.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.BusinessLogic.Core.Auth
{
    public class AuthActions
    {
        private readonly DbSession _session;

        public AuthActions(DbSession session)
        {
            _session = session;
        }

        protected async Task<UserData> GetUserByEmail(string email)
        {
            using var context = new RestaurantContext(_session);
            return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        protected async Task CreateUser(UserData user)
        {
            using var context = new RestaurantContext(_session);
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}
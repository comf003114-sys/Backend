using AutoMapper;
using ChaChaClub.DataAccess;
using ChaChaClub.DataAccess.Context;
using ChaChaClub.Domains.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace ChaChaClub.BusinessLogic.Core.Users
{
    public class UsersActions
    {
        private readonly DbSession _session;
        protected readonly IMapper _mapper;

        public UsersActions(DbSession session, IMapper mapper)
        {
            _session = session;
            _mapper = mapper;
        }

        protected async Task<UserData> GetUserById(int id)
        {
            using var context = new RestaurantContext(_session);
            return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        protected async Task UpdateUser(UserData user)
        {
            using var context = new RestaurantContext(_session);
            context.Users.Update(user);
            await context.SaveChangesAsync();
        }
    }
}
using ChaChaClub.Domains.Models.User;

namespace ChaChaClub.BusinessLogic.Interface
{
    public interface IUsers
    {
        Task<UserDto> GetProfile(int userId);
        Task UpdateProfile(int userId, UpdateUserDto dto);
    }
}
namespace ChaChaClub.BusinessLogic.Interface
{
    public interface IAuth
    {
        Task<string> Login(string email, string password);
        Task Register(string username, string email, string password);
    }
}
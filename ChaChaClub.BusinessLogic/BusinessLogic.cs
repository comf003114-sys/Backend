using ChaChaClub.BusinessLogic.Functions.Auth;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;

namespace ChaChaClub.BusinessLogic
{
    public class BusinessLogic
    {
        private readonly DbSession _session;
        private readonly string _jwtSecret;

        public BusinessLogic(DbSession session, string jwtSecret)
        {
            _session = session;
            _jwtSecret = jwtSecret;
        }

        public IAuth Auth() => new AuthFlow(_session, _jwtSecret);
    }
}
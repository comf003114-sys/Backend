using AutoMapper;
using ChaChaClub.BusinessLogic.Functions.Auth;
using ChaChaClub.BusinessLogic.Functions.Categories;
using ChaChaClub.BusinessLogic.Functions.Dishes;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;

namespace ChaChaClub.BusinessLogic
{
    public class BusinessLogic
    {
        private readonly DbSession _session;
        private readonly string _jwtSecret;
        private readonly IMapper _mapper;

        public BusinessLogic(DbSession session, string jwtSecret, IMapper mapper)
        {
            _session = session;
            _jwtSecret = jwtSecret;
            _mapper = mapper;
        }

        public IAuth Auth() => new AuthFlow(_session, _jwtSecret);
        public ICategories Categories() => new CategoriesFlow(_session, _mapper);
        public IDishes Dishes() => new DishesFlow(_session, _mapper);
    }
}
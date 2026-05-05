using AutoMapper;
using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Entities.Review;
using ChaChaClub.Domains.Entities.User;
using ChaChaClub.Domains.Models.Review;

namespace ChaChaClub.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewData, CreateReviewDto>().ReverseMap();
        }
    }
}
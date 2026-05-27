using AutoMapper;
using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Entities.Review;
using ChaChaClub.Domains.Models.Dish;
using ChaChaClub.Domains.Models.Review;
using ChaChaClub.Domains.Entities.Wine;
using ChaChaClub.Domains.Models.Wine;

namespace ChaChaClub.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewData, CreateReviewDto>().ReverseMap();
            CreateMap<ReviewData, ReviewDto>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.User.Username))
                .ReverseMap();
            CreateMap<DishData, DishDto>().ReverseMap();
            CreateMap<DishData, CreateDishDto>().ReverseMap();
            CreateMap<CategoryData, CategoryDto>().ReverseMap();
            CreateMap<CategoryData, CreateCategoryDto>().ReverseMap();
            CreateMap<WineData, WineDto>().ReverseMap();
            CreateMap<WineData, CreateWineDto>().ReverseMap();
        }
    }
}
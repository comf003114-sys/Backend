using AutoMapper;
using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Entities.Review;
using ChaChaClub.Domains.Models.Dish;
using ChaChaClub.Domains.Models.Review;

namespace ChaChaClub.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ReviewData, CreateReviewDto>().ReverseMap();
            CreateMap<DishData, DishDto>().ReverseMap();
            CreateMap<DishData, CreateDishDto>().ReverseMap();
            CreateMap<CategoryData, CategoryDto>().ReverseMap();
            CreateMap<CategoryData, CreateCategoryDto>().ReverseMap();
        }
    }
}
using ChaChaClub.Domains.Models.Dish;

namespace ChaChaClub.BusinessLogic.Interface
{
    public interface ICategories
    {
        Task<List<CategoryDto>> GetAll();
        Task<CategoryDto> GetById(int id);
        Task Create(CreateCategoryDto dto);
        Task Update(int id, CreateCategoryDto dto);
        Task Delete(int id);
    }
}
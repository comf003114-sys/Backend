using ChaChaClub.Domains.Models.Dish;

namespace ChaChaClub.BusinessLogic.Interface
{
    public interface IDishes
    {
        Task<List<DishDto>> GetAll();
        Task<List<DishDto>> GetByCategory(int categoryId);
        Task<DishDto> GetById(int id);
        Task<DishDto> GetDailyDish();
        Task Create(CreateDishDto dto);
        Task Update(int id, CreateDishDto dto);
        Task Delete(int id);
    }
}
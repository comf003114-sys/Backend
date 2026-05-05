using AutoMapper;
using ChaChaClub.BusinessLogic.Core.Dishes;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;
using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Models.Dish;

namespace ChaChaClub.BusinessLogic.Functions.Dishes
{
    public class DishesFlow : DishesActions, IDishes
    {
        public DishesFlow(DbSession session, IMapper mapper) : base(session, mapper)
        {
        }

        public async Task<List<DishDto>> GetAll()
        {
            var dishes = await GetAllDishes();
            return _mapper.Map<List<DishDto>>(dishes);
        }

        public async Task<List<DishDto>> GetByCategory(int categoryId)
        {
            var dishes = await GetDishesByCategory(categoryId);
            return _mapper.Map<List<DishDto>>(dishes);
        }

        public async Task<DishDto> GetById(int id)
        {
            var dish = await GetDishById(id);
            if (dish == null)
                throw new Exception("Dish not found");
            return _mapper.Map<DishDto>(dish);
        }

        public async Task<DishDto> GetDailyDish()
        {
            var dish = await GetDailyDish();
            if (dish == null)
                throw new Exception("Daily dish not found");
            return _mapper.Map<DishDto>(dish);
        }

        public async Task Create(CreateDishDto dto)
        {
            var dish = _mapper.Map<DishData>(dto);
            await CreateDish(dish);
        }

        public async Task Update(int id, CreateDishDto dto)
        {
            var dish = await GetDishById(id);
            if (dish == null)
                throw new Exception("Dish not found");
            _mapper.Map(dto, dish);
            dish.UpdatedAt = DateTime.UtcNow;
            await UpdateDish(dish);
        }

        public async Task Delete(int id)
        {
            var dish = await GetDishById(id);
            if (dish == null)
                throw new Exception("Dish not found");
            await DeleteDish(dish);
        }
    }
}
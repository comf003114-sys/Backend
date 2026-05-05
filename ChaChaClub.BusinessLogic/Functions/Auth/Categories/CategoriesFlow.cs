using AutoMapper;
using ChaChaClub.BusinessLogic.Core.Categories;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;
using ChaChaClub.Domains.Entities.Dish;
using ChaChaClub.Domains.Models.Dish;

namespace ChaChaClub.BusinessLogic.Functions.Categories
{
    public class CategoriesFlow : CategoriesActions, ICategories
    {
        public CategoriesFlow(DbSession session, IMapper mapper) : base(session, mapper)
        {
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var categories = await GetAllCategories();
            return _mapper.Map<List<CategoryDto>>(categories);
        }

        public async Task<CategoryDto> GetById(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null)
                throw new Exception("Category not found");
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task Create(CreateCategoryDto dto)
        {
            var category = _mapper.Map<CategoryData>(dto);
            await CreateCategory(category);
        }

        public async Task Update(int id, CreateCategoryDto dto)
        {
            var category = await GetCategoryById(id);
            if (category == null)
                throw new Exception("Category not found");
            _mapper.Map(dto, category);
            category.UpdatedAt = DateTime.UtcNow;
            await UpdateCategory(category);
        }

        public async Task Delete(int id)
        {
            var category = await GetCategoryById(id);
            if (category == null)
                throw new Exception("Category not found");
            await DeleteCategory(category);
        }
    }
}
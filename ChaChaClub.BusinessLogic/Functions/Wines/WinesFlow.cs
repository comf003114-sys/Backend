using AutoMapper;
using ChaChaClub.BusinessLogic.Core.Wines;
using ChaChaClub.BusinessLogic.Interface;
using ChaChaClub.DataAccess;
using ChaChaClub.Domains.Entities.Wine;
using ChaChaClub.Domains.Models.Wine;

namespace ChaChaClub.BusinessLogic.Functions.Wines
{
    public class WinesFlow : WinesActions, IWines
    {
        public WinesFlow(DbSession session, IMapper mapper) : base(session, mapper) { }

        public async Task<List<WineDto>> GetAll()
        {
            var wines = await GetAllWines();
            return _mapper.Map<List<WineDto>>(wines);
        }

        public async Task<List<WineDto>> GetByCategory(string category)
        {
            var wines = await GetWinesByCategory(category);
            return _mapper.Map<List<WineDto>>(wines);
        }

        public async Task<WineDto> GetById(int id)
        {
            var wine = await GetWineById(id);
            if (wine == null) throw new Exception("Wine not found");
            return _mapper.Map<WineDto>(wine);
        }

        public async Task Create(CreateWineDto dto)
        {
            var wine = _mapper.Map<WineData>(dto);
            await CreateWine(wine);
        }

        public async Task Update(int id, CreateWineDto dto)
        {
            var wine = await GetWineById(id);
            if (wine == null) throw new Exception("Wine not found");
            _mapper.Map(dto, wine);
            wine.UpdatedAt = DateTime.UtcNow;
            await UpdateWine(wine);
        }

        public async Task Delete(int id)
        {
            var wine = await GetWineById(id);
            if (wine == null) throw new Exception("Wine not found");
            await DeleteWine(wine);
        }
    }
}
using ChaChaClub.Domains.Models.Wine;

namespace ChaChaClub.BusinessLogic.Interface
{
    public interface IWines
    {
        Task<List<WineDto>> GetAll();
        Task<List<WineDto>> GetByCategory(string category);
        Task<WineDto> GetById(int id);
        Task Create(CreateWineDto dto);
        Task Update(int id, CreateWineDto dto);
        Task Delete(int id);
    }
}
namespace Library.Repositories.Interfaces;

public interface ILibraryRepository
{
    Task<List<Library.Models.Entities.Library>> GetAllAsync();
    Task<Library.Models.Entities.Library?> GetByIdAsync(int id);
    Task<Library.Models.Entities.Library> AddAsync(Library.Models.Entities.Library library);
    Task UpdateAsync(Library.Models.Entities.Library library);
    Task DeleteAsync(Library.Models.Entities.Library library);
}
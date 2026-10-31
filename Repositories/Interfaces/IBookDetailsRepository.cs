using Library.Models.Entities;

namespace Library.Repositories.Interfaces;

public interface IBookDetailsRepository
{
    Task<List<BookDetails>> GetAllAsync();
    Task<BookDetails?> GetByIdAsync(int id);
    Task<BookDetails> AddAsync(BookDetails bookDetails);
    Task UpdateAsync(BookDetails bookDetails);
    Task DeleteAsync(BookDetails bookDetails);
}
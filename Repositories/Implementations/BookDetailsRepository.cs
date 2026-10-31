using Library.Data;
using Library.Models.Entities;
using Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Library.Repositories.Implementations;

public class BookDetailsRepository : IBookDetailsRepository
{
    private readonly LibraryDBContext _context;

    public BookDetailsRepository(LibraryDBContext context)
    {
        _context = context;
    }

    public async Task<List<BookDetails>> GetAllAsync()
    {
        return await _context.BookDetails.Include(d => d.Book).ToListAsync();
    }

    public async Task<BookDetails?> GetByIdAsync(int id)
    {
        return await _context.BookDetails.Include(d => d.Book).FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<BookDetails> AddAsync(BookDetails bookDetails)
    {
        _context.BookDetails.Add(bookDetails);
        await _context.SaveChangesAsync();
        return bookDetails;
    }

    public async Task UpdateAsync(BookDetails bookDetails)
    {
        _context.BookDetails.Update(bookDetails);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(BookDetails bookDetails)
    {
        _context.BookDetails.Remove(bookDetails);
        await _context.SaveChangesAsync();
    }
}
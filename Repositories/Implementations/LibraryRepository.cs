using Library.Data;
using Library.Models.Entities;
using Library.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using LibraryEntity = Library.Models.Entities.Library;

namespace Library.Repositories.Implementations;

public class LibraryRepository : ILibraryRepository
{
    private readonly LibraryDBContext _context;

    public LibraryRepository(LibraryDBContext context)
    {
        _context = context;
    }

    public async Task<List<LibraryEntity>> GetAllAsync()
    {
        return await _context.Libraries.Include(l => l.Books).ToListAsync();
    }

    public async Task<LibraryEntity?> GetByIdAsync(int id)
    {
        return await _context.Libraries.Include(l => l.Books).FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<LibraryEntity> AddAsync(LibraryEntity library)
    {
        _context.Libraries.Add(library);
        await _context.SaveChangesAsync();
        return library;
    }

    public async Task UpdateAsync(LibraryEntity library)
    {
        _context.Libraries.Update(library);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(LibraryEntity library)
    {
        _context.Libraries.Remove(library);
        await _context.SaveChangesAsync();
    }
}
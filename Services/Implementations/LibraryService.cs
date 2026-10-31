
using Library.Models.DTOs.LibraryDTOs;
using Library.Models.Entities;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services.Implementations;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository _repository;

    public LibraryService(ILibraryRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<LibraryResponseDto>> GetAllAsync()
    {
        var libraries = await _repository.GetAllAsync();

        return libraries.Select(l => new LibraryResponseDto
        {
            Id = l.Id,
            Name = l.Name,
            Address = l.Address,
            BookCount = l.Books.Count
        }).ToList();
    }

    public async Task<LibraryResponseDto?> GetByIdAsync(int id)
    {
        var library = await _repository.GetByIdAsync(id);

        if (library == null)
        {
            return null;
        }

        return new LibraryResponseDto
        {
            Id = library.Id,
            Name = library.Name,
            Address = library.Address,
            BookCount = library.Books.Count
        };
    }

    public async Task<LibraryResponseDto> AddAsync(CreateLibraryDto dto)
    {
        var library = new Models.Entities.Library
        {
            Name = dto.Name,
            Address = dto.Address,
            Books = new List<Book>()
        };

        var createdLibrary = await _repository.AddAsync(library);

        return new LibraryResponseDto
        {
            Id = createdLibrary.Id,
            Name = createdLibrary.Name,
            Address = createdLibrary.Address,
            BookCount = 0
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateLibraryDto dto)
    {
        var library = await _repository.GetByIdAsync(id);

        if (library == null)
        {
            return false;
        }

        library.Name = dto.Name;
        library.Address = dto.Address;

        await _repository.UpdateAsync(library);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var library = await _repository.GetByIdAsync(id);

        if (library == null)
        {
            return false;
        }

        if (library.Books.Count > 0)
        {
            throw new InvalidOperationException("Cannot delete a library that contains books.");
        }

        await _repository.DeleteAsync(library);

        return true;
    }
}

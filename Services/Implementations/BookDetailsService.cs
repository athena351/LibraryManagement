
using Library.Models.DTOs.BookDetailsDTOs;
using Library.Models.Entities;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services.Implementations;

public class BookDetailsService : IBookDetailsService
{
    private readonly IBookDetailsRepository _repository;
    private readonly IBookRepository _bookRepository;

    public BookDetailsService( IBookDetailsRepository repository, IBookRepository bookRepository)
    {
        _repository = repository;
        _bookRepository = bookRepository;
    }

    public async Task<List<BookDetailsResponseDto>> GetAllAsync()
    {
        var details = await _repository.GetAllAsync();

        return details.Select(d => new BookDetailsResponseDto
        {
            Id = d.Id,
            ISBN = d.ISBN,
            PageCount = d.PageCount,
            PublishedYear = d.PublishedYear,
            BookId = d.BookId
        }).ToList();
    }

    public async Task<BookDetailsResponseDto?> GetByIdAsync(int id)
    {
        var details = await _repository.GetByIdAsync(id);

        if (details == null)
        {
            return null;
        }

        return new BookDetailsResponseDto
        {
            Id = details.Id,
            ISBN = details.ISBN,
            PageCount = details.PageCount,
            PublishedYear = details.PublishedYear,
            BookId = details.BookId
        };
    }

    public async Task<BookDetailsResponseDto> AddAsync(CreateBookDetailsDto dto)
    {
        var book = await _bookRepository.GetByIdAsync(dto.BookId);

        if (book == null)
        {
            throw new ArgumentException("Book does not exist.");
        }

        if (book.BookDetails != null)
        {
            throw new InvalidOperationException("This book already has details.");
        }

        var details = new BookDetails
        {
            ISBN = dto.ISBN,
            PageCount = dto.PageCount,
            PublishedYear = dto.PublishedYear,
            BookId = dto.BookId
        };

        var createdDetails = await _repository.AddAsync(details);

        return new BookDetailsResponseDto
        {
            Id = createdDetails.Id,
            ISBN = createdDetails.ISBN,
            PageCount = createdDetails.PageCount,
            PublishedYear = createdDetails.PublishedYear,
            BookId = createdDetails.BookId
        };
    }

    public async Task<bool> UpdateAsync(
        int id, UpdateBookDetailsDto dto)
    {
        var details = await _repository.GetByIdAsync(id);

        if (details == null)
        {
            return false;
        }

        details.ISBN = dto.ISBN;
        details.PageCount = dto.PageCount;
        details.PublishedYear = dto.PublishedYear;

        await _repository.UpdateAsync(details);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var details = await _repository.GetByIdAsync(id);

        if (details == null)
        {
            return false;
        }

        await _repository.DeleteAsync(details);

        return true;
    }
}

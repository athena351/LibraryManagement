
using Library.Models.DTOs.BookDTOs;
using Library.Models.DTOs.BookDetailsDTOs;
using Library.Models.Entities;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services.Implementations;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly ILibraryRepository _libraryRepository;
    private readonly IGenreRepository _genreRepository;

    public BookService(IBookRepository bookRepository, ILibraryRepository libraryRepository, IGenreRepository genreRepository)
    {
        _bookRepository = bookRepository;
        _libraryRepository = libraryRepository;
        _genreRepository = genreRepository;
    }

    public async Task<List<BookResponseDto>> GetAllAsync()
    {
        var books = await _bookRepository.GetAllAsync();

        return books.Select(b => new BookResponseDto
        {
            Id = b.Id,
            Title = b.Title,
            Author = b.Author,
            Price = b.Price,
            LibraryId = b.LibraryId,
            LibraryName = b.Library.Name,
            Genres = b.Genres.Select(g => g.Name).ToList(),
            BookDetails = b.BookDetails == null ? null : new BookDetailsResponseDto
            {
                Id = b.BookDetails.Id,
                ISBN = b.BookDetails.ISBN,
                PageCount = b.BookDetails.PageCount,
                PublishedYear = b.BookDetails.PublishedYear,
                BookId = b.BookDetails.BookId
            }
        }).ToList();
    }

    public async Task<BookResponseDto?> GetByIdAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
        {
            return null;
        }

        return new BookResponseDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
            LibraryId = book.LibraryId,
            LibraryName = book.Library.Name,
            Genres = book.Genres.Select(g => g.Name).ToList(),
            BookDetails = book.BookDetails == null ? null : new BookDetailsResponseDto
            {
                Id = book.BookDetails.Id,
                ISBN = book.BookDetails.ISBN,
                PageCount = book.BookDetails.PageCount,
                PublishedYear = book.BookDetails.PublishedYear,
                BookId = book.BookDetails.BookId
            }
        };
    }

    public async Task<BookResponseDto> AddAsync(CreateBookDto dto)
    {
        var library = await _libraryRepository.GetByIdAsync(dto.LibraryId);

        if (library == null)
        {
            throw new ArgumentException("Library does not exist.");
        }

        var genreIds = dto.GenreIds.Distinct().ToList();
        var genres = new List<Genre>();

        foreach (var genreId in genreIds)
        {
            var genre = await _genreRepository.GetByIdAsync(genreId);

            if (genre == null)
            {
                throw new ArgumentException($"Genre with ID {genreId} does not exist.");
            }

            genres.Add(genre);
        }

        var book = new Book
        {
            Title = dto.Title,
            Author = dto.Author,
            Price = dto.Price,
            LibraryId = dto.LibraryId,
            Genres = genres
        };

        var createdBook = await _bookRepository.AddAsync(book);

        return new BookResponseDto
        {
            Id = createdBook.Id,
            Title = createdBook.Title,
            Author = createdBook.Author,
            Price = createdBook.Price,
            LibraryId = createdBook.LibraryId,
            LibraryName = library.Name,
            Genres = genres.Select(g => g.Name).ToList()
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateBookDto dto)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
        {
            return false;
        }

        var library = await _libraryRepository.GetByIdAsync(dto.LibraryId);

        if (library == null)
        {
            throw new ArgumentException("Library does not exist.");
        }

        var genreIds = dto.GenreIds.Distinct().ToList();
        var genres = new List<Genre>();

        foreach (var genreId in genreIds)
        {
            var genre = await _genreRepository.GetByIdAsync(genreId);

            if (genre == null)
            {
                throw new ArgumentException($"Genre with ID {genreId} does not exist.");
            }

            genres.Add(genre);
        }

        book.Title = dto.Title;
        book.Author = dto.Author;
        book.Price = dto.Price;
        book.LibraryId = dto.LibraryId;
        book.Genres = genres;

        await _bookRepository.UpdateAsync(book);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book == null)
        {
            return false;
        }

        await _bookRepository.DeleteAsync(book);

        return true;
    }
}

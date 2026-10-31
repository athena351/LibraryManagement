using Library.Data;
using Library.Models.DTOs.LibraryDTOs;
using Library.Models.DTOs.BookDTOs;
using Library.Models.DTOs.GenreDTOs;
using Library.Repositories.Interfaces;
using Library.Repositories.Implementations;
using Library.Services.Interfaces;
using Library.Services.Implementations;

using var context = new LibraryDBContext();

ILibraryRepository libraryRepository = new LibraryRepository(context);
IBookRepository bookRepository = new BookRepository(context);
IBookDetailsRepository bookDetailsRepository = new BookDetailsRepository(context);
IGenreRepository genreRepository = new GenreRepository(context);

ILibraryService libraryService = new LibraryService(libraryRepository);
IBookService bookService = new BookService(bookRepository, libraryRepository, genreRepository);
IBookDetailsService bookDetailsService = new BookDetailsService(bookDetailsRepository, bookRepository);
IGenreService genreService = new GenreService(genreRepository);


var library = await libraryService.AddAsync(new CreateLibraryDto
{
    Name = "Central Library",
    Address = "Tbilisi"
});

Console.WriteLine($"Library added: {library.Name}");

var fantasy = await genreService.AddAsync(new CreateGenreDto
{
    Name = "Fantasy"
});

var adventure = await genreService.AddAsync(new CreateGenreDto
{
    Name = "Adventure"
});

var book = await bookService.AddAsync(new CreateBookDto
{
    Title = "The Hobbit",
    Author = "J.R.R. Tolkien",
    Price = 25,
    LibraryId = library.Id,
    GenreIds = new List<int> { fantasy.Id, adventure.Id }
});

Console.WriteLine($"Book added: {book.Title}");

var details = await bookDetailsService.AddAsync(new Library.Models.DTOs.BookDetailsDTOs.CreateBookDetailsDto
{
    ISBN = "9780547928227",
    PageCount = 310,
    PublishedYear = 1937,
    BookId = book.Id
});

Console.WriteLine($"Book details added. ISBN: {details.ISBN}");

var books = await bookService.GetAllAsync();

Console.WriteLine("\nAll books:");

foreach (var item in books)
{
    Console.WriteLine($"Title: {item.Title}");
    Console.WriteLine($"Author: {item.Author}");
    Console.WriteLine($"Library: {item.LibraryName}");
    Console.WriteLine($"Genres: {string.Join(", ", item.Genres)}");
    Console.WriteLine();
}

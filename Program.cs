using Library.Data;
using Library.Models.Entities;
using Microsoft.EntityFrameworkCore;

using var context = new LibraryDBContext();

var library = new Library.Models.Entities.Library
{
    Name = "Central Library",
    Address = "Tbilisi",

    Books = new List<Book>
    {
        new Book
        {
            Title = "The Hobbit",
            Author = "J.R.R. Tolkien",
            Price = 25.50m,
            BookDetails = new BookDetails
            {
                ISBN = "9780007525492",
                PageCount = 310,
                PublishedYear = 1937
            }
        },

        new Book
        {
            Title = "1984",
            Author = "George Orwell",
            Price = 20m,
            BookDetails = new BookDetails
            {
                ISBN = "9780451524935",
                PageCount = 328,
                PublishedYear = 1949
            }
        },

        new Book
        {
            Title = "The Little Prince",
            Author = "Antoine de Saint-Exupery",
            Price = 15m,
            BookDetails = new BookDetails
            {
                ISBN = "9780156012195",
                PageCount = 96,
                PublishedYear = 1943
            }
        }
    }
};

context.Libraries.Add(library);
await context.SaveChangesAsync();

Console.WriteLine("Library and books added successfully!");

var result = await context.Libraries
    .Include(l => l.Books)
    .FirstOrDefaultAsync(l => l.Id == library.Id);

if (result != null)
{
    Console.WriteLine($"\nLibrary: {result.Name}");

    foreach (var book in result.Books)
    {
        Console.WriteLine(book.Title);
    }
}
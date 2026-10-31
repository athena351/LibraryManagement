using Library.Models.DTOs.BookDetailsDTOs;

namespace Library.Models.DTOs.BookDTOs;

public class BookResponseDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int LibraryId { get; set; }
    public string LibraryName { get; set; } = string.Empty;
    public List<string> Genres { get; set; } = new List<string>();
    public BookDetailsResponseDto? BookDetails { get; set; }
}
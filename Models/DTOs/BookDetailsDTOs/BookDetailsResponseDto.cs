namespace Library.Models.DTOs.BookDetailsDTOs;

public class BookDetailsResponseDto
{
    public int Id { get; set; }
    public string ISBN { get; set; } = string.Empty;
    public int PageCount { get; set; }
    public int PublishedYear { get; set; }
    public int BookId { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTOs.BookDetailsDTOs;

public class CreateBookDetailsDto
{
    [MaxLength(20)]
    public string ISBN { get; set; } = string.Empty;
    [Range(0, int.MaxValue)]
    public int PageCount { get; set; }
    [Range(0, int.MaxValue)]
    public int PublishedYear { get; set; }
    [Range(1, int.MaxValue)]
    public int BookId { get; set; }
}
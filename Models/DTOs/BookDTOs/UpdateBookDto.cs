using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTOs.BookDTOs;

public class UpdateBookDto
{
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(40)]
    public string Author { get; set; }
    [Range(0, double.MaxValue)]
    public decimal Price { get; set; }
    [Range(1, int.MaxValue)]
    public int LibraryId { get; set; }
    public List<int> GenreIds { get; set; } = new List<int>();
}
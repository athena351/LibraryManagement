using System.ComponentModel.DataAnnotations;

namespace Library.Models.Entities;

public class Book
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MaxLength(40)]
    public string Author { get; set; }
    [Range(0, int.MaxValue)]
    public decimal Price { get; set; }
    public int LibraryId { get; set; }
    public Library Library { get; set; }
    public BookDetails BookDetails { get; set; }
    public ICollection<Genre> Genres { get; set; } = new List<Genre>();
}
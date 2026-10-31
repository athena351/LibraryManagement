using System.ComponentModel.DataAnnotations;

namespace Library.Models.Entities;

public class Genre
{
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>();
}
using System.ComponentModel.DataAnnotations;

namespace Library.Models.Entities;

public class Library
{
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
    public ICollection<Book> Books { get; set; }
}
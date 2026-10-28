using System.ComponentModel.DataAnnotations;

namespace Library.Models.Entities;

public class BookDetails
{
    public int Id { get; set; }
    [MaxLength(20)]
    public string ISBN { get; set; }
    [Range(0, int.MaxValue)]
    public int PageCount { get; set; }
    [Range(0, int.MaxValue)]
    public int PublishedYear { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
}
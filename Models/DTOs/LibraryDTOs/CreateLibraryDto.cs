using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTOs.LibraryDTOs;

public class CreateLibraryDto
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required]
    [MaxLength(200)]
    public string Address { get; set; }
}
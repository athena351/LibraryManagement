using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTOs.GenreDTOs;

public class UpdateGenreDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
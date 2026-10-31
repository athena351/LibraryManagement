using System.ComponentModel.DataAnnotations;

namespace Library.Models.DTOs.GenreDTOs;

public class CreateGenreDto
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
}
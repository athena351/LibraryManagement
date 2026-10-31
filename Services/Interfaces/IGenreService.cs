using Library.Models.DTOs.GenreDTOs;

namespace Library.Services.Interfaces;

public interface IGenreService
{
    Task<List<GenreResponseDto>> GetAllAsync();
    Task<GenreResponseDto?> GetByIdAsync(int id);
    Task<GenreResponseDto> AddAsync(CreateGenreDto dto);
    Task<bool> UpdateAsync(int id, UpdateGenreDto dto);
    Task<bool> DeleteAsync(int id);
}
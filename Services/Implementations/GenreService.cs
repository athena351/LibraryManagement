
using Library.Models.DTOs.GenreDTOs;
using Library.Models.Entities;
using Library.Repositories.Interfaces;
using Library.Services.Interfaces;

namespace Library.Services.Implementations;

public class GenreService : IGenreService
{
    private readonly IGenreRepository _repository;

    public GenreService(IGenreRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<GenreResponseDto>> GetAllAsync()
    {
        var genres = await _repository.GetAllAsync();

        return genres.Select(g => new GenreResponseDto
        {
            Id = g.Id,
            Name = g.Name
        }).ToList();
    }

    public async Task<GenreResponseDto?> GetByIdAsync(int id)
    {
        var genre = await _repository.GetByIdAsync(id);

        if (genre == null)
        {
            return null;
        }

        return new GenreResponseDto
        {
            Id = genre.Id,
            Name = genre.Name
        };
    }

    public async Task<GenreResponseDto> AddAsync(CreateGenreDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Genre name cannot be empty.");
        }

        var genre = new Genre
        {
            Name = dto.Name.Trim()
        };

        var createdGenre = await _repository.AddAsync(genre);

        return new GenreResponseDto
        {
            Id = createdGenre.Id,
            Name = createdGenre.Name
        };
    }

    public async Task<bool> UpdateAsync(int id, UpdateGenreDto dto)
    {
        var genre = await _repository.GetByIdAsync(id);

        if (genre == null)
        {
            return false;
        }

        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new ArgumentException("Genre name cannot be empty.");
        }

        genre.Name = dto.Name.Trim();

        await _repository.UpdateAsync(genre);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var genre = await _repository.GetByIdAsync(id);

        if (genre == null)
        {
            return false;
        }

        if (genre.Books.Count > 0)
        {
            throw new InvalidOperationException("Cannot delete a genre that is assigned to books.");
        }

        await _repository.DeleteAsync(genre);

        return true;
    }
}

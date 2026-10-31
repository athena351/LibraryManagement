using Library.Models.DTOs.BookDetailsDTOs;

namespace Library.Services.Interfaces;

public interface IBookDetailsService
{
    Task<List<BookDetailsResponseDto>> GetAllAsync();
    Task<BookDetailsResponseDto?> GetByIdAsync(int id);
    Task<BookDetailsResponseDto> AddAsync(CreateBookDetailsDto dto);
    Task<bool> UpdateAsync(int id, UpdateBookDetailsDto dto);
    Task<bool> DeleteAsync(int id);
}
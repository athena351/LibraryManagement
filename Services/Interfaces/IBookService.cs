using Library.Models.DTOs.BookDTOs;

namespace Library.Services.Interfaces;

public interface IBookService
{
    Task<List<BookResponseDto>> GetAllAsync();
    Task<BookResponseDto?> GetByIdAsync(int id);
    Task<BookResponseDto> AddAsync(CreateBookDto dto);
    Task<bool> UpdateAsync(int id, UpdateBookDto dto);
    Task<bool> DeleteAsync(int id);
}
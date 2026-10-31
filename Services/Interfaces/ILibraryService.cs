using Library.Models.DTOs.LibraryDTOs;

namespace Library.Services.Interfaces;

public interface ILibraryService
{
    Task<List<LibraryResponseDto>> GetAllAsync();
    Task<LibraryResponseDto?> GetByIdAsync(int id);
    Task<LibraryResponseDto> AddAsync(CreateLibraryDto dto);
    Task<bool> UpdateAsync(int id, UpdateLibraryDto dto);
    Task<bool> DeleteAsync(int id);
}
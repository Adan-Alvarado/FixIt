using fixIt.Api.Dtos;
using fixIt.Api.Dtos.Categoria;

namespace FixIt.Api.Services.Categoria
{
    public interface ICategoriaService
    {
        // Listar todas las categorias
        Task<List<CategoriaItemDto>> GetAllAsync();

        // Obtener una categoria por ID
        Task<CategoriaDto> GetByIdAsync(Guid id);

        // Crear una nueva categoria
        Task<CategoriaActionResponseDto> CreateAsync(CategoriaCreateDto dto);

        // Editar una categoria existente
        Task<CategoriaActionResponseDto> UpdateAsync(Guid id, CategoriaCreateDto dto);

        // Eliminar una categoria
        Task<CategoriaActionResponseDto> DeleteAsync(Guid id);
    }
}

using fixIt.Api.Dtos.Common;
using fixIt.Api.Dtos.Categoria;
using fixIt.Api.Dtos;

namespace FixIt.Api.Services.Categoria
{
    public interface ICategoriaService
    {
        // Listar todas las categorías
        Task<ResponseDto<List<CategoriaItemDto>>> GetAllAsync();

        // Obtener categoría por ID
        Task<ResponseDto<CategoriaDto>> GetByIdAsync(Guid id);

        // Crear nueva categoría
        Task<ResponseDto<CategoriaActionResponseDto>> CreateAsync(CategoriaCreateDto dto);

        // Editar categoría existente
        Task<ResponseDto<CategoriaActionResponseDto>> UpdateAsync(Guid id, CategoriaCreateDto dto);

        // Eliminar categoría
        Task<ResponseDto<CategoriaActionResponseDto>> DeleteAsync(Guid id);
    }
}

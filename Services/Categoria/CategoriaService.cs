using fixIt.Api.Dtos;
using fixIt.Api.Dtos.Categoria;
using fixIt.Api.Dtos.Common;
using FixIt.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixIt.Api.Services.Categoria
{
    public class CategoriaService : ICategoriaService
    {
        private readonly FixItDbContext _context;

        public CategoriaService(FixItDbContext context)
        {
            _context = context;
        }

        // Listar todas las categorias
        public async Task<ResponseDto<List<CategoriaItemDto>>> GetAllAsync()
        {
            var categorias = await _context.Categorias
                .Select(c => new CategoriaItemDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre,
                    Urgencia = c.Urgencia
                })
                .ToListAsync();

            return new ResponseDto<List<CategoriaItemDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Categorías obtenidas correctamente",
                Data = categorias
            };
        }

        // Obtener una categoria por ID
        public async Task<ResponseDto<CategoriaDto>> GetByIdAsync(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return new ResponseDto<CategoriaDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Categoría no encontrada",
                    Data = null
                };
            }

            return new ResponseDto<CategoriaDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Categoría encontrada",
                Data = new CategoriaDto
                {
                    Id = categoria.Id,
                    Nombre = categoria.Nombre,
                    Urgencia = categoria.Urgencia,
                    Descripcion = categoria.Descripcion,
                }
            };
        }

        // Crear una nueva categoria
        public async Task<ResponseDto<CategoriaActionResponseDto>> CreateAsync(CategoriaCreateDto dto)
        {
            var categoria = new CategoriaEntity
            {
                Id = Guid.NewGuid(),
                Nombre = dto.Nombre,
                Urgencia = dto.Urgencia,
                Descripcion = dto.Descripcion,
                Activa = true,
                CreationDate = DateTime.UtcNow,
                UpdatedDate = DateTime.UtcNow
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return new ResponseDto<CategoriaActionResponseDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Categoría creada correctamente",
                Data = new CategoriaActionResponseDto { Id = categoria.Id }
            };
        }

        // Editar una categoria existente
        public async Task<ResponseDto<CategoriaActionResponseDto>> UpdateAsync(Guid id, CategoriaCreateDto dto)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return new ResponseDto<CategoriaActionResponseDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Categoría no encontrada",
                    Data = null
                };
            }

            categoria.Nombre = dto.Nombre;
            categoria.Urgencia = dto.Urgencia;
            categoria.Descripcion = dto.Descripcion;
            categoria.UpdatedDate = DateTime.UtcNow;

            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();

            return new ResponseDto<CategoriaActionResponseDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Categoría actualizada correctamente",
                Data = new CategoriaActionResponseDto { Id = categoria.Id }
            };
        }

        // Eliminar una categoria
        public async Task<ResponseDto<CategoriaActionResponseDto>> DeleteAsync(Guid id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return new ResponseDto<CategoriaActionResponseDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Categoría no encontrada",
                    Data = null
                };
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return new ResponseDto<CategoriaActionResponseDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Categoría eliminada correctamente",
                Data = new CategoriaActionResponseDto { Id = categoria.Id }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fixIt.Api.Dtos.Common;
using FixIt.Api.Constants;
using FixIt.Dtos.BarrioColonia;
using FixIt.Dtos.Common;
using FixIt.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace FixIt.Services.BarrioColonia
{
    public class BarrioColoniaService : IBarrioColoniaService
    {
        private readonly FixItDbContext _context;
        private readonly IMapper _mapper;
        private readonly int PAGE_SIZE;
        private readonly int PAGE_SIZE_LIMIT;

        public BarrioColoniaService(FixItDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            // Tamaños de paginación
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
            PAGE_SIZE_LIMIT = configuration.GetValue<int>("PageSizeLimit");
        }
        
        public async Task<ResponseDto<BarrioColoniaActionResponseDto>> CreateAsync(BarrioColoniaCreateDto dto)
        {
             // Mapeo de DTO → Entidad
            var barrioColoniaEntity = _mapper.Map<BarrioColoniaEntity>(dto);

            // Guardar en la base de datos
            _context.BarriosColonias.Add(barrioColoniaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<BarrioColoniaActionResponseDto>
            {
                StatusCode = HttpStatusCodes.CREATED,
                Status = true,
                Message = "Registro creado correctamente",
                Data = _mapper.Map<BarrioColoniaActionResponseDto>(barrioColoniaEntity)
            };
        }

        public async Task<ResponseDto<BarrioColoniaActionResponseDto>> DeleteAsync(Guid id)
        {
            // Buscar el registro a eliminar
            var barrioColoniaEntity = await _context.BarriosColonias.FirstOrDefaultAsync(x => x.Id == id);

            if (barrioColoniaEntity is null)
            {
                return new ResponseDto<BarrioColoniaActionResponseDto>
                {
                    StatusCode = HttpStatusCodes.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            // Eliminar registro
            _context.BarriosColonias.Remove(barrioColoniaEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<BarrioColoniaActionResponseDto>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registro eliminado correctamente",
                Data = _mapper.Map<BarrioColoniaActionResponseDto>(barrioColoniaEntity)
            };
        }

        public async Task<ResponseDto<BarrioColoniaActionResponseDto>> EditAsync(Guid id, BarrioColoniaEditDto dto)
        {
            var barrioColoniaEntity = await _context.BarriosColonias.FirstOrDefaultAsync(x => x.Id == id);

            if (barrioColoniaEntity is null)
            {
                return new ResponseDto<BarrioColoniaActionResponseDto>
                {
                    StatusCode = HttpStatusCodes.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            // Mapea los cambios del DTO a la entidad encontrada
            _mapper.Map(dto, barrioColoniaEntity);

            // Marca la entidad como modificada
            _context.BarriosColonias.Update(barrioColoniaEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<BarrioColoniaActionResponseDto>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registro editado correctamente",
                Data = _mapper.Map<BarrioColoniaActionResponseDto>(barrioColoniaEntity)
            };
        }

        public async Task<ResponseDto<PaginationDto<List<BarrioColoniaItemDto>>>> GetListAsync(string searchTerm, int page = 1, int pageSize = 0)
        {
            // Usa el tamaño por defecto si no viene uno
            pageSize = pageSize == 0 ? PAGE_SIZE : pageSize;

            // Limita el tamaño si excede el máximo permitido
            pageSize = pageSize > PAGE_SIZE_LIMIT ? PAGE_SIZE_LIMIT : pageSize;

            int startIndex = (page - 1) * pageSize;

            IQueryable<BarrioColoniaEntity> barrioColoniaQuery = _context.BarriosColonias;

            // Filtro: buscar por descripción si viene SearchTerm
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                barrioColoniaQuery = barrioColoniaQuery.Where(x =>
                    x.Nombre.ToLower().Contains(searchTerm.ToLower())
                );
            }

            int totalRows = await barrioColoniaQuery.CountAsync();

            // Obtener registros paginados
            var barriocolonia =  await barrioColoniaQuery
                .OrderByDescending(x => x.CreationDate)   // orden descendente
                .Skip(startIndex)
                .Take(pageSize)
                .ProjectToType<BarrioColoniaItemDto>()          // Mapea a DTO
                .ToListAsync();

            // Respuesta final
            return new ResponseDto<PaginationDto<List<BarrioColoniaItemDto>>>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registros obtenidos correctamente",
                Data = new PaginationDto<List<BarrioColoniaItemDto>>
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = totalRows,
                    HasNextPage = startIndex + pageSize < PAGE_SIZE_LIMIT && page < (int)Math.Ceiling((double)totalRows / pageSize),
                    HasPreviousPage = page > 1,
                    TotalPages = (int)Math.Ceiling((double)totalRows / pageSize),
                    Items = barriocolonia
                }
            };
        }

        public async Task<ResponseDto<BarrioColoniaDto>> GetOneByIdAsync(Guid id)
        {
            var barrioColoniaEntity = await _context.BarriosColonias.FirstOrDefaultAsync(x => x.Id == id);

            if (barrioColoniaEntity is null)
            {
                return new ResponseDto<BarrioColoniaDto>
                {
                    StatusCode = HttpStatusCodes.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            return new ResponseDto<BarrioColoniaDto>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registro encontrado",
                Data = _mapper.Map<BarrioColoniaDto>(barrioColoniaEntity)
            };
        }
    }
}
using fixIt.Api.Dtos.Common;
using FixIt.Api.Constants;
using FixIt.Dtos.Common;
using FixIt.Dtos.Reportes;
using FixIt.Entities;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;

namespace FixIt.Services.Reportes
{

    public class ReporteService : IReporteService
    {
        private readonly FixItDbContext _context;
        private readonly IMapper _mapper;
        private readonly int PAGE_SIZE;
        private readonly int PAGE_SIZE_LIMIT;

        // Constructor: recibe contexto, configuración y mapper
        public ReporteService(FixItDbContext context, IConfiguration configuration, IMapper mapper)
        {
            _context = context;

            // Tamaños de paginación
            PAGE_SIZE = configuration.GetValue<int>("PageSize");
            PAGE_SIZE_LIMIT = configuration.GetValue<int>("PageSizeLimit");
        }

        // GET LIST — Obtener listado con paginación y filtros

        public async Task<ResponseDto<PaginationDto<List<ReporteItemDto>>>> GetListAsync(string searchTerm, int page = 1, int pageSize = 0)
        {
            // Usa el tamaño por defecto si no viene uno
            pageSize = pageSize == 0 ? PAGE_SIZE : pageSize;

            // Limita el tamaño si excede el máximo permitido
            pageSize = pageSize > PAGE_SIZE_LIMIT ? PAGE_SIZE_LIMIT : pageSize;

            int startIndex = (page - 1) * pageSize;

            IQueryable<ReporteEntity> reporteQuery = _context.Reportes;

            // Filtro: buscar por descripción si viene SearchTerm
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                reporteQuery = reporteQuery.Where(x =>
                    x.Descripcion.ToLower().Contains(searchTerm.ToLower())
                );
            }

            // Contar total de registros filtrados
            int totalRows = await reporteQuery.CountAsync();

            // Obtener registros paginados
            var reportes = await reporteQuery
                .OrderByDescending(x => x.CreationDate)   // orden descendente
                .Skip(startIndex)
                .Take(pageSize)
                .ProjectToType<ReporteItemDto>()           // Mapea a DTO
                .ToListAsync();

            // Respuesta final
            return new ResponseDto<PaginationDto<List<ReporteItemDto>>>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registros obtenidos correctamente",
                Data = new PaginationDto<List<ReporteItemDto>>
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItems = totalRows,
                    HasNextPage = startIndex + pageSize < PAGE_SIZE_LIMIT && page < (int)Math.Ceiling((double)totalRows / pageSize),
                    HasPreviousPage = page > 1,
                    TotalPages = (int)Math.Ceiling((double)totalRows / pageSize),
                    Items = reportes
                }
            };
        }

        // GET ONE — Obtener un reporte por ID

        public async Task<ResponseDto<ReporteDto>> GetOneByIdAsync(Guid id)
        {
            // Buscar por ID
            var reporteEntity = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);

            if (reporteEntity is null)
            {
                return new ResponseDto<ReporteDto>
                {
                    StatusCode = HttpStatusCodes.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            return new ResponseDto<ReporteDto>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registro encontrado",
                Data = _mapper.Map<ReporteDto>(reporteEntity)
            };
        }

        // CREATE — Crear un nuevo reporte

        public async Task<ResponseDto<ReporteActionResponseDto>> CreateAsync(ReporteCreateDto dto)
        {
            // Mapeo de DTO → Entidad
            var reporteEntity = _mapper.Map<ReporteEntity>(dto);

            // Guardar en la base de datos
            _context.Reportes.Add(reporteEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<ReporteActionResponseDto>
            {
                StatusCode = HttpStatusCodes.CREATED,
                Status = true,
                Message = "Registro creado correctamente",
                Data = _mapper.Map<ReporteActionResponseDto>(reporteEntity)
            };
        }

        // EDIT — Editar un reporte existente
        public async Task<ResponseDto<ReporteActionResponseDto>> EditAsync(Guid id, ReporteEditDto dto)
        {
            // Buscar el registro a editar
            var reporteEntity = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);

            if (reporteEntity is null)
            {
                return new ResponseDto<ReporteActionResponseDto>
                {
                    StatusCode = HttpStatusCodes.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado"
                };
            }

            // Mapea los cambios del DTO a la entidad encontrada
            _mapper.Map(dto, reporteEntity);

            // Marca la entidad como modificada
            _context.Reportes.Update(reporteEntity);

            await _context.SaveChangesAsync();

            return new ResponseDto<ReporteActionResponseDto>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registro editado correctamente",
                Data = _mapper.Map<ReporteActionResponseDto>(reporteEntity)
            };
        }

        // DELETE — Eliminar un reporte por ID

        public async Task<ResponseDto<ReporteActionResponseDto>> DeleteAsync(Guid id)
        {
            // Buscar el registro a eliminar
            var reporteEntity = await _context.Reportes.FirstOrDefaultAsync(x => x.Id == id);

            if (reporteEntity is null)
            {
                return new ResponseDto<ReporteActionResponseDto>
                {
                    StatusCode = HttpStatusCodes.NOT_FOUND,
                    Status = false,
                    Message = "Registro no encontrado",
                };
            }

            // Eliminar registro
            _context.Reportes.Remove(reporteEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<ReporteActionResponseDto>
            {
                StatusCode = HttpStatusCodes.OK,
                Status = true,
                Message = "Registro eliminado correctamente",
                Data = _mapper.Map<ReporteActionResponseDto>(reporteEntity)
            };
        }

    }

}
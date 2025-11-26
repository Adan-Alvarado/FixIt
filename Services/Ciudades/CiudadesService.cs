using fixIt.Api.Dtos;
using fixIt.Api.Dtos.Common;
using fixIt.Api.Services.Ciudades;
using FixIt.Entities;
using Microsoft.EntityFrameworkCore;

namespace FixIt.Api.Services.Ciudades
{
    public class CiudadesService : ICiudadesService
    {
        private readonly FixItDbContext _context;

        public CiudadesService(FixItDbContext context)
        {
            _context = context;
        }

        // Obtener todas las ciudades
        public async Task<ResponseDto<List<CiudadesDto>>> GetAllAsync()
        {
            var ciudades = await _context.Ciudades
                .Select(c => new CiudadesDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                }).ToListAsync();

            return new ResponseDto<List<CiudadesDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Ciudades obtenidas correctamente",
                Data = ciudades
            };
        }

        // Obtener ciudad por ID
        public async Task<ResponseDto<CiudadesDto>> GetByIdAsync(Guid id)
        {
            var ciudad = await _context.Ciudades
                .Where(c => c.Id == id)
                .Select(c => new CiudadesDto
                {
                    Id = c.Id,
                    Nombre = c.Nombre
                })
                .FirstOrDefaultAsync();

            if (ciudad == null)
            {
                return new ResponseDto<CiudadesDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Ciudad no encontrada",
                    Data = null
                };
            }

            return new ResponseDto<CiudadesDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Ciudad obtenida correctamente",
                Data = ciudad
            };
        }
    }
}

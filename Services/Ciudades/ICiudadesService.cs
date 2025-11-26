using fixIt.Api.Dtos;
using fixIt.Api.Dtos.Categoria;
using fixIt.Api.Dtos.Common;

namespace fixIt.Api.Services.Ciudades
{
    public interface ICiudadesService
    {
    // Obtener ciudad por ID
        Task<ResponseDto<CiudadesDto>> GetByIdAsync(Guid id);
        Task<ResponseDto<List<CiudadesDto>>> GetAllAsync();
    }    
}



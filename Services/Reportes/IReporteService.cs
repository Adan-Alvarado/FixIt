using fixIt.Api.Dtos.Common;
using FixIt.Dtos.Common;
using FixIt.Dtos.Reportes;

namespace FixIt.Services.Reportes
{
    public interface IReporteService
    {
        Task<ResponseDto<ReporteDto>> GetOneByIdAsync(Guid id);
        // una interfaz es un contrato que todas la clases que hereden de esta la clase tiene que crear todo lo que se indique aqui.
        Task<ResponseDto<ReporteActionResponseDto>> CreateAsync(ReporteCreateDto dto);
        Task<ResponseDto<ReporteActionResponseDto>> EditAsync(Guid id, ReporteEditDto dto);
        Task<ResponseDto<ReporteActionResponseDto>> DeleteAsync(Guid id);
        Task<ResponseDto<PaginationDto<List<ReporteItemDto>>>> GetListAsync(string searchTerm, int page = 1, int pageSize = 0);
    }

    
}
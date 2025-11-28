using fixIt.Api.Dtos.Common;
using FixIt.Dtos.BarrioColonia;
using FixIt.Dtos.Common;

namespace FixIt.Services.BarrioColonia
{
    public interface IBarrioColoniaService
    {
        Task<ResponseDto<BarrioColoniaDto>> GetOneByIdAsync(Guid id);
        // una interfaz es un contrato que todas la clases que hereden de esta la clase tiene que crear todo lo que se indique aqui.
        Task<ResponseDto<BarrioColoniaActionResponseDto>> CreateAsync(BarrioColoniaCreateDto dto);
        Task<ResponseDto<BarrioColoniaActionResponseDto>> EditAsync(Guid id, BarrioColoniaEditDto dto);
        Task<ResponseDto<BarrioColoniaActionResponseDto>> DeleteAsync(Guid id);
        Task<ResponseDto<PaginationDto<List<BarrioColoniaItemDto>>>> GetListAsync(string searchTerm, int page = 1, int pageSize = 0);
    }
}
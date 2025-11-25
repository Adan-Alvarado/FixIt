using fixIt.Api.Dtos.Common;
using FixIt.Dtos.Reportes;
using FixIt.Services.Reportes;
using Microsoft.AspNetCore.Mvc;

namespace FixIt.Controllers
{
    [ApiController]
    [Route("api/reportes")]
    public class ReporteController : ControllerBase
    {
        private readonly IReporteService _reporteService; //El _ eS PARA DECIR QUE ES UNA BARIABEL GLOBAL
        public ReporteController(IReporteService reporteService)
        {
            _reporteService = reporteService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<ReporteItemDto>>>> GetPaginationList(string searchTerm, int page = 1, int pageSize = 0)
        {
            var response = await _reporteService.GetListAsync(searchTerm, page, pageSize);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto<ReporteActionResponseDto>>> Post(ReporteCreateDto dto)
        {
            var response = await _reporteService.CreateAsync(dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<ReporteDto>>> GetOne(Guid id)
        {
            var response = await _reporteService.GetOneByIdAsync(id);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<ReporteActionResponseDto>>> Edit(Guid id, ReporteEditDto dto)
        {
            var response = await _reporteService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }
            
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<ReporteActionResponseDto>>> Delete(Guid id)
        {
            var response = await _reporteService.DeleteAsync(id);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });

        }
    }
}
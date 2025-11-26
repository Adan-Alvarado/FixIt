using fixIt.Api.Dtos;
using fixIt.Api.Dtos.Common;
using fixIt.Api.Services.Ciudades;
using Microsoft.AspNetCore.Mvc;

namespace fixIt.Api.Controllers
{
    [ApiController]
    [Route("api/ciudades")]
    public class CiudadesController : ControllerBase
    {
        private readonly ICiudadesService _ciudadesService;
        public CiudadesController(ICiudadesService ciudadesService)
        {
            _ciudadesService = ciudadesService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CiudadesDto>>>> GetAll()
        {
            var response = await _ciudadesService.GetAllAsync();
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<CiudadesDto>>> GetById(Guid id)
        {
            var response = await _ciudadesService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }
    }
}

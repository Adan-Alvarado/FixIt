using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using fixIt.Api.Dtos.Common;
using FixIt.Dtos.BarrioColonia;
using FixIt.Services.BarrioColonia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FixIt.Controllers
{
    [ApiController]
    [Route("api/barrio-colonia")]
    public class BarrioColoniaController : ControllerBase
    {
        private readonly IBarrioColoniaService _barrioColoniaService; //El _ eS PARA DECIR QUE ES UNA BARIABEL GLOBAL
        

        public BarrioColoniaController(IBarrioColoniaService barrioColoniaService)
        {
            _barrioColoniaService = barrioColoniaService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<BarrioColoniaItemDto>>>> GetPaginationList(string searchTerm, int page = 1, int pageSize = 0)
        {
            var response = await _barrioColoniaService.GetListAsync(searchTerm, page, pageSize);

            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data
            });
        }
        [HttpPost]
        public async Task<ActionResult<ResponseDto<BarrioColoniaActionResponseDto>>> Post(BarrioColoniaCreateDto dto)
        {
            var response = await _barrioColoniaService.CreateAsync(dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<BarrioColoniaDto>>> GetOne(Guid id)
        {
            var response = await _barrioColoniaService.GetOneByIdAsync(id);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });

        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<BarrioColoniaActionResponseDto>>> Edit(Guid id, BarrioColoniaEditDto dto)
        {
            var response = await _barrioColoniaService.EditAsync(id, dto);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });
        }
            
        
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<BarrioColoniaActionResponseDto>>> Delete(Guid id)
        {
            var response = await _barrioColoniaService.DeleteAsync(id);
            return StatusCode(response.StatusCode, new
            {
                response.Status,
                response.Message,
                response.Data,
            });

        }
    }
}
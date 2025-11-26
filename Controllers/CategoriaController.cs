using Microsoft.AspNetCore.Mvc;
using FixIt.Api.Services.Categoria;
using fixIt.Api.Dtos.Common;
using fixIt.Api.Dtos.Categoria;
using fixIt.Api.Dtos;

namespace FixIt.Api.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET api/categorias
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CategoriaItemDto>>>> GetAll()
        {
            var response = await _categoriaService.GetAllAsync();
            return StatusCode(response.StatusCode, response);
        }

        // GET api/categorias/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<CategoriaDto>>> GetById(Guid id)
        {
            var response = await _categoriaService.GetByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // POST api/categorias
        [HttpPost]
        public async Task<ActionResult<ResponseDto<CategoriaActionResponseDto>>> Create(CategoriaCreateDto dto)
        {
            var response = await _categoriaService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // PUT api/categorias/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<CategoriaActionResponseDto>>> Update(Guid id, CategoriaCreateDto dto)
        {
            var response = await _categoriaService.UpdateAsync(id, dto);
            return StatusCode(response.StatusCode, response);
        }

        // DELETE api/categorias/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<CategoriaActionResponseDto>>> Delete(Guid id)
        {
            var response = await _categoriaService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}

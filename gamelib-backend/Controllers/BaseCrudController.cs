using gamelib_backend.Business.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace gamelib_backend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class BaseCrudController<TEntity, TId, TRequestDto, TOutDto, TCreateDto, TUpdateDto>
        : ControllerBase {


        private readonly IBaseCrudService<TEntity, TId, TRequestDto, TOutDto, TCreateDto, TUpdateDto> service;

        public BaseCrudController(
            IBaseCrudService<TEntity, TId, TRequestDto, TOutDto, TCreateDto, TUpdateDto> service
        ) {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IList<TOutDto>>> GetAllByAsync([FromQuery] TRequestDto requestDto) {
            try {
                var outDtos = await service.GetAllByAsync(requestDto);
                return Ok(outDtos);
            } catch (Exception e) {
                return BadRequest(e);
            }
        }

        [HttpPost("create")]
        public async Task<ActionResult<TOutDto>> CreateAsync(TCreateDto createDto) {
            try {
                var outDto = await service.CreateAsync(createDto);
                return Ok(outDto);
            } catch (Exception e) {
                return BadRequest(e);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<TOutDto>> UpdateAsync(TUpdateDto updateDto) {
            try {
                var outDto = await service.UpdateAsync(updateDto);
                return Ok(outDto);
            } catch (Exception e) {
                return BadRequest(e);
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] TId id) {
            try {
                await service.DeleteAsync(id);
                return Ok();
            } catch (Exception e) {
                return BadRequest(e);
            }
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestEx.Models;
using TestEx.Repository;

namespace TestEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepository _todoService;
        public TodosController(ITodoRepository todoService) 
        {
            _todoService = todoService;
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> Post([FromBody]TodoDTOCreate dto)
        {
            var entity = new Todo();
            entity.IsActive = true;
            entity.Name = dto.Name;

            return Ok(await _todoService.AddOrUpdateAsync(entity));
        }

        [HttpGet]
        public ActionResult<IEnumerable<Todo>> GetAll()
        {
            return Ok(_todoService.GetAll());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var todo = await _todoService.FindByIdAsync(id);
            if (todo != null)
            {
                _todoService.Delete(todo);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Todo>> Put(int id, [FromBody] TodoDTOEdit dto)
        {
            if (!_todoService.ExistAnyById(id)) return NotFound();
            
            if(id != dto.Id) return BadRequest();

            var entity = await _todoService.FindByIdAsync(id);

            entity.Name = dto.Name;
            return Ok(await _todoService.AddOrUpdateAsync(entity));
        }

        [HttpPut]
        [Route("status/{id:int}")]
        public async Task<ActionResult> Put(int id)
        {
            if (!_todoService.ExistAnyById(id)) return NotFound();

            var entity = await _todoService.FindByIdAsync(id);

            await _todoService.ChangeStatusAsync(entity);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using ToDoApp.Shared.DTOs;
using ToDoApp.Shared.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDosController : ControllerBase, IToDoExchange
    {
        private IToDoExchange toDoRepository;
        public ToDosController(IToDoExchange toDoRepository)
        {
            this.toDoRepository = toDoRepository;
        }

        // GET: api/<ToDoesController>
        [HttpGet]
        public Task<IEnumerable<ToDoDTO>> GetAll()
        {
            return toDoRepository.GetAll();
        }

        // GET api/<ToDoesController>/5
        [HttpGet("{id}")]
        public Task<ToDoDTO> GetById(int id)
        {
            return toDoRepository.GetById(id);
        }

        // POST api/<ToDoesController>
        [HttpPost]
        public Task Add([FromBody] ToDoDTO value)
        {
            return toDoRepository.Add(value);
        }

        // PUT api/<ToDoesController>/5
        [HttpPut("{id}")]
        public Task Update(int id, [FromBody] ToDoDTO value)
        {
            return toDoRepository.Update(id, value);
        }

        // DELETE api/<ToDoesController>/5
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return toDoRepository.Delete(id);
        }
    }
}

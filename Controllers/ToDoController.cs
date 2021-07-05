using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using todo_list.DTO;

namespace todo_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoRepository _database = new();

        [HttpGet]
        public IEnumerable<ToDoDto> Get()
        {
            return _database.GetAll();
        }

        [HttpPost]
        public int Post([FromBody] ToDoDto value)
        {
            return _database.Add(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDoDto value)
        {
            _database.Update(id, value);
        }
    }
}
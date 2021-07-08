using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using todo_list.DbInfrastructure;
using todo_list.DTO;
using todo_list.Entities;

namespace todo_list.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ToDoController(IToDoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<ToDoDto> Get()
        {
            return _repository.GetAll().Select(x => new ToDoDto
            {
                Id = x.Id, Name = x.Name, Done = x.Done
            });
        }

        [HttpPost]
        public int Post([FromBody] ToDoDto value)
        {
            var newEntity = new ToDoEntity
            {
                Name = value.Name,
                Done = value.Done
            };
            _repository.Add(newEntity);
            _unitOfWork.Commit();
            return newEntity.Id;
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ToDoDto value)
        {
            var entity = _repository.GetById(id);
            entity.Done = value.Done;
            entity.Name = value.Name;
            _unitOfWork.Commit();
        }
    }
}
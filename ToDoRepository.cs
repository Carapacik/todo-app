using System.Collections.Generic;
using System.Linq;
using todo_list.DbInfrastructure;
using todo_list.Entities;

namespace todo_list
{
    public class ToDoRepository : IToDoRepository
    {
        private readonly ToDoDbContext _context;

        public ToDoRepository(ToDoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ToDoEntity> GetAll()
        {
            return _context.Set<ToDoEntity>();
        }

        public void Add(ToDoEntity newEntity)
        {
            _context.Set<ToDoEntity>()
                .Add(newEntity);
        }

        public ToDoEntity GetById(int id)
        {
            return _context.Set<ToDoEntity>().FirstOrDefault(item => item.Id == id);
        }
    }
}
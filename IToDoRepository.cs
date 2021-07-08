using System.Collections.Generic;
using todo_list.Entities;

namespace todo_list
{
    public interface IToDoRepository
    {
        IEnumerable<ToDoEntity> GetAll();
        void Add(ToDoEntity toDoDto);
        ToDoEntity GetById(int id);
    }
}
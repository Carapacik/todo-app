using System;
using System.Collections.Generic;
using System.Linq;
using todo_list.DTO;

namespace todo_list
{
    public class ToDoRepository
    {
        // эмуляция БД
        private static readonly List<ToDo> Database = new();

        // публичные функции репозитория
        public ToDoDto[] GetAll()
        {
            return Database
                .ConvertAll(x => new ToDoDto {Id = x.Id, Name = x.Name, Done = x.Done})
                .ToArray();
        }

        public int Add(ToDoDto toDoDto)
        {
            var id = GetId();
            Database.Add(new ToDo(id, toDoDto.Name, toDoDto.Done));
            return id;
        }

        public void Update(int id, ToDoDto toDoDto)
        {
            var todo = Database.Find(x => x.Id == id);
            if (todo == null) return;
            todo.Name = toDoDto.Name;
            todo.Done = toDoDto.Done;
        }

        // эмуляция генерации следующего Id БД
        private int GetId()
        {
            var nextId = 1;
            if (Database.Count > 0) nextId = Database.Max(x => x.Id) + 1;
            return nextId;
        }


        // скрытая реализация внутренних сущностей БД
        // сущность БД
        private class ToDo
        {
            public ToDo(int id, string name, bool done)
            {
                Id = id;
                Name = name;
                Done = done;
                CreationDate = DateTime.Now;
            }

            public int Id { get; }
            public string Name { get; set; }
            public bool Done { get; set; }
            public DateTime CreationDate { get; }
        }
    }
}
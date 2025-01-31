using ToDoApp.Shared.DTOs;
using ToDoApp.Shared.Interfaces;

namespace ToDoApp.API.Services
{
    public class ToDoRepository : IToDoExchange
    {
        private List<ToDoDTO> data;
        public ToDoRepository()
        {
            data = Enumerable.Range(1, 10).Select(index => new ToDoDTO
            {
                ID = index,
                DueDate = DateTime.Now.AddDays(index),
                Title = "ToDo" + index,
                Description = "Beschreibung " + index
            }).ToList();
        }

        public Task<IEnumerable<ToDoDTO>> GetAll()
        {
            return Task.FromResult<IEnumerable<ToDoDTO>>(data);
        }

        public Task<ToDoDTO> GetById(int id)
        {
            return Task.FromResult<ToDoDTO>(data.FirstOrDefault(x => x.ID == id));
        }

        public Task Add(ToDoDTO toDo)
        {
            toDo.ID = 1;
            if (data.Count > 0)
                toDo.ID = data.Max(x => x.ID) + 1;

            data.Add(toDo);
            return Task.CompletedTask;
        }

        public Task Update(int id, ToDoDTO toDo)
        {
            data.Remove(data.First(x => x.ID == id));
            data.Add(toDo);

            return Task.CompletedTask;
        }

        public Task Delete(int id)
        {
            data.Remove(data.First(x => x.ID == id));
            return Task.CompletedTask;
        }
    }
}

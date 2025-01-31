using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Shared.DTOs;
using ToDoApp.Shared.Interfaces;

namespace ToDoApp.Tests.Mocks
{
    public class MockToDoRepository : IToDoExchange
    {
        private List<ToDoDTO> data = new List<ToDoDTO>();
        public MockToDoRepository()
        {
            data.Add(new ToDoDTO()
            {
                ID = 1,
                Title = "Item1",
                DueDate =
            DateTime.Now,
                Description = "Description Item1"
            });
        }
        public Task<IEnumerable<ToDoDTO>> GetAll()
        {
            return Task.FromResult<IEnumerable<ToDoDTO>>(data);
        }
        public Task<ToDoDTO> GetById(int id)
        {
            return Task.FromResult(data.First());
        }
        public Task Add(ToDoDTO toDo)
        {
            return Task.CompletedTask;
        }
        public Task Update(int id, ToDoDTO toDo)
        {
            return Task.CompletedTask;
        }
        public Task Delete(int id)
        {
            return Task.CompletedTask;
        }
    }
}

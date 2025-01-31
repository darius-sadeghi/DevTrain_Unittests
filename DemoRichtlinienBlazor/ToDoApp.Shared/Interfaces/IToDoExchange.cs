using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Shared.DTOs;

namespace ToDoApp.Shared.Interfaces
{
    public interface IToDoExchange
    {
        Task<IEnumerable<ToDoDTO>> GetAll();
        Task<ToDoDTO> GetById(int id);
        Task Add(ToDoDTO toDo);
        Task Update(int id, ToDoDTO toDo);
        Task Delete(int id);
    }
}

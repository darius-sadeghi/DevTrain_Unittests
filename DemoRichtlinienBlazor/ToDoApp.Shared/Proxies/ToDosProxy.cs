using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Shared.DTOs;
using ToDoApp.Shared.Interfaces;

namespace ToDoApp.Shared.Proxies
{
    public class ToDosProxy : IToDoExchange
    {
        private HttpClient httpClient { get; set; }
        public ToDosProxy(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<ToDoDTO>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<List<ToDoDTO>>("/api/ToDos");
        }

        public async Task<ToDoDTO> GetById(int id)
        {
            try
            {
                return await httpClient.GetFromJsonAsync<ToDoDTO>($"/api/ToDos/{id}");
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        public async Task Add(ToDoDTO toDo)
        {
            await httpClient.PostAsJsonAsync("/api/ToDos", toDo);
        }

        public async Task Update(int id, ToDoDTO toDo)
        {
            await httpClient.PutAsJsonAsync($"/api/ToDos/{id}", toDo);
        }

        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync($"/api/ToDos/{id}");
        }

    }
}

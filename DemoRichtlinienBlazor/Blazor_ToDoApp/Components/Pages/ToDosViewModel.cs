using Microsoft.AspNetCore.Components;
using ToDoApp.Shared.DTOs;
using ToDoApp.Shared.Interfaces;

namespace Blazor_ToDoApp.Components.Pages
{
    public class ToDosViewModel : ComponentBase
    {
        public ToDoDTO[] Todos { get; set; }

        [Inject]
        protected IToDoExchange repositoryProxy { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Todos = (await repositoryProxy.GetAll()).ToArray();
        }
    }
}

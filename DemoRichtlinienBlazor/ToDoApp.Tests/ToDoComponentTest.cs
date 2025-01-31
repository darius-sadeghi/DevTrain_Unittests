using Blazor_ToDoApp.Components.Pages;
using Bunit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Shared.Interfaces;
using ToDoApp.Tests.Mocks;

namespace ToDoApp.Tests
{
    [TestClass]
    public class ToDoComponentTest
    {
        [TestMethod]
        public void ToDoComponent_Render_Testcase1()
        {
            using var ctx = new Bunit.TestContext();
            ctx.Services.AddSingleton<IToDoExchange>(new MockToDoRepository());

            var cut = ctx.RenderComponent<ToDos>();

            Assert.AreEqual(2, cut.FindAll(".row").Count);
            Assert.AreEqual(1, cut.FindComponents<ToDoItem>().Count);
        }
    }
}

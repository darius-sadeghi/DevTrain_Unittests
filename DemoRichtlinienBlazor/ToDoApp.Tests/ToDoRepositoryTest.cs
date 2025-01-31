using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.API.Services;

namespace ToDoApp.Tests
{
    [TestClass]
    public class ToDoRepositoryTest
    {
        [TestMethod]
        public async Task GetAll_Testcase1()
        {
            ToDoRepository testObj = new ToDoRepository();

            var result = await testObj.GetAll();

            Assert.AreEqual(10, result.Count());
        }
    }
}

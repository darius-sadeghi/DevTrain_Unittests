using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToDoApp.Business;
using ToDoApp.Business.Models;

namespace ToDoApp.Unittests
{
  
    [TestClass]
    public class ToDoTest
    {
      
        [TestMethod]
        public void ToDo_ID_Testcase1()
        {
            ToDo myToDo = new ToDo();

            myToDo.Id = 1;

            Assert.AreEqual(1, myToDo.Id);
        }

        [TestMethod]
        public void ToDo_Title_Testcase1()
        {
            ToDo myToDo = new ToDo();

            myToDo.Title = "Test";

            Assert.AreEqual("Test", myToDo.Title);
        }

        [TestMethod]
        public void ToDo_Date_Testcase1()
        {
            ToDo myToDo = new ToDo();

            myToDo.Date = new DateTime(2017,1,1);

            Assert.AreEqual(new DateTime(2017, 1, 1), myToDo.Date);
        }

        [TestMethod]
        public void ToDo_Categories_Testcase1()
        {
            ToDo myToDo = new ToDo();

            myToDo.Categories.Add(new ToDoCategory());

            Assert.AreEqual(1, myToDo.Categories.Count);
        }

        [TestMethod]
        public void ToDo_Body_Testcase1()
        {
            ToDo myToDo = new ToDo();

            myToDo.Body = "Test";

            Assert.AreEqual("Test", myToDo.Body);
        }
    }
}

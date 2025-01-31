using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business;
using ToDoApp.Business.Models;

namespace ToDoApp.Unittests
{
    [TestClass]
    public class ToDoRepositoryTests
    {
        [TestMethod]
        public void ToDoRepository_GetAll_Testcase1()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();
            {
                ToDo toDo = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
                toDoRepository.Create(toDo);
            }

            // Test durchführen            
            var result = toDoRepository.GetAll();

            // Behauptung aufstellen
            Assert.AreEqual(1, result.Count);
        }

        [TestMethod]
        public void ToDoRepository_Create_Testcase1()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();

            // Test durchführen
            ToDo toDo = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
            toDoRepository.Create(toDo);

            // Behauptung aufstellen
            Assert.AreEqual(1, toDo.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDoRepository_Create_Testcase2()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();

            // Test durchführen            
            toDoRepository.Create(null);                       
        }

        [TestMethod]
        public void ToDoRepository_Create_Testcase3()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();

            // Test durchführen
            ToDo toDo1 = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
            toDoRepository.Create(toDo1);
            ToDo toDo2 = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
            toDoRepository.Create(toDo2);

            // Behauptung aufstellen
            Assert.AreEqual(1, toDo1.Id);
            Assert.AreEqual(2, toDo2.Id);
        }

        [TestMethod]
        public void ToDoRepository_Update_Testcase1()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();
            {                
                ToDo toDo = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
                toDoRepository.Create(toDo);
            }

            // Test durchführen
            {
                ToDo toDo = toDoRepository.GetAll().First();
                toDo.Title = "Änderung";
                toDoRepository.Update(toDo);
            }

            // Behauptung aufstellen
            {
                ToDo toDo = toDoRepository.GetAll().First();
                Assert.AreEqual("Änderung", toDo.Title);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDoRepository_Update_Testcase2()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();

            // Test durchführen            
            toDoRepository.Update(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDoRepository_Update_Testcase3()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();
            {
                ToDo toDo = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
                toDoRepository.Create(toDo);
            }

            // Test durchführen            
            ToDo toDoFalsch = new ToDo() { Id = 99, Title = "Item99", Date = new DateTime(2023, 1, 1), Body = "Beschreibung99" };
            toDoRepository.Update(toDoFalsch);
        }

        [TestMethod]
        public void ToDoRepository_Delete_Testcase1()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();
            {
                ToDo toDo = new ToDo() { Id = 0, Title = "Item1", Date = new DateTime(2023, 1, 1), Body = "Beschreibung1" };
                toDoRepository.Create(toDo);
            }

            // Test durchführen
            {
                ToDo toDo = toDoRepository.GetAll().First();
                toDo.Title = "Änderung";
                toDoRepository.Delete(toDo);
            }

            // Behauptung aufstellen
            {
                var result = toDoRepository.GetAll();
                Assert.AreEqual(0, result.Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ToDoRepository_Delete_Testcase2()
        {
            // Testobjekt erstellen
            ToDoRepository toDoRepository = new ToDoRepository();

            // Test durchführen            
            toDoRepository.Delete(null);
        }
    }
}

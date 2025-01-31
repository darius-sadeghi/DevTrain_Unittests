using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Models;

namespace ToDoApp.Business
{
    public class ToDoRepositoryEDM
    {
        private ToDoAppEntities context;

        public ToDoRepositoryEDM()
        {
            context = new ToDoAppEntities();
        }


        public List<ToDo> GetAll()
        {
            return context.ToDos.ToList();
        }

        public void Create(ToDo myToDo)
        {
            if( myToDo==null)
            {
                throw new ArgumentException("ToDo Parameter ist null!");
            }

            context.ToDos.Add(myToDo);
            context.SaveChanges();            
        }

        public void Update(ToDo myToDo)
        {
            if (myToDo == null)
            {
                throw new ArgumentException("ToDo Parameter ist null!");
            }

            context.Entry<ToDo>(myToDo).State = EntityState.Modified;
            if (context.SaveChanges() != 0)
                return;

            throw new ArgumentException($"ToDo mit Id {myToDo.Id} nicht gefunden!");
        }

        public void Delete(ToDo myToDo)
        {
            if (myToDo == null)
            {
                throw new ArgumentException("ToDo Parameter ist null!");
            }

            context.Remove(myToDo);
            context.SaveChanges();
        }

    }
}

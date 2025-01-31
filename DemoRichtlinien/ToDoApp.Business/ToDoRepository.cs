using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Models;

namespace ToDoApp.Business
{
    public class ToDoRepository
    {
        private List<ToDo> _Data;

        public ToDoRepository()
        {
            _Data = new List<ToDo>();
        }


        public List<ToDo> GetAll()
        {
            return _Data.ToList();
        }

        public void Create(ToDo myToDo)
        {
            if( myToDo==null)
            {
                throw new ArgumentException("ToDo Parameter ist null!");
            }


            myToDo.Id = 1;
            if (_Data.Count > 0)
                myToDo.Id = _Data.Max(x => x.Id) + 1;
            _Data.Add(myToDo);            
        }

        public void Update(ToDo myToDo)
        {
            if (myToDo == null)
            {
                throw new ArgumentException("ToDo Parameter ist null!");
            }

            for (int i = 0; i < _Data.Count; i++)
            {
                if (_Data[i].Id == myToDo.Id)
                {
                    _Data[i] = myToDo;
                    return;
                }
            }

            throw new ArgumentException($"ToDo mit Id {myToDo.Id} nicht gefunden!");
        }

        public void Delete(ToDo myToDo)
        {
            if (myToDo == null)
            {
                throw new ArgumentException("ToDo Parameter ist null!");
            }


            _Data.Remove(myToDo);
        }

    }
}

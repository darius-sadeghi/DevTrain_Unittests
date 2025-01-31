using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Business.Models;

namespace ToDoApp.Business
{
    public class CategoryRepository
    {
        private List<ToDoCategory> _Data;

        public CategoryRepository()
        {
            _Data = new List<ToDoCategory>();
        }


        public List<ToDoCategory> GetAll()
        {
            return _Data.ToList();
        }

        public void Create(ToDoCategory myToDoCategory)
        {
            myToDoCategory.Id = 1;
            if (_Data.Count > 0)
                myToDoCategory.Id = _Data.Max(x => x.Id) + 1;
            _Data.Add(myToDoCategory);           
        }

        public void Update(ToDoCategory myToDoCategory)
        {
            for (int i = 0; i < _Data.Count; i++)
            {
                if (_Data[i].Id == myToDoCategory.Id)
                {
                    _Data[i] = myToDoCategory;
                    return;
                }
            }

        }

        public void Delete(ToDoCategory myToDoCategory)
        {
            _Data.Remove(myToDoCategory);
        }

    }
}

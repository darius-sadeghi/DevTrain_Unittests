using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ToDoApp.Business.Models
{
    public class ToDoCategory : ModelBase
    {
        private int _Id;
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; RaisePropertyChange("Id"); }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; RaisePropertyChange("Title"); }
        }

        public ToDoCategory()
        {
            Title = "Neue Kategorie";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace ToDoApp.Business.Models
{
    public class ToDo : ModelBase
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

        private DateTime? _Date;
        public DateTime? Date
        {
            get { return _Date; }
            set { _Date = value; RaisePropertyChange("Date"); }
        }


        private ObservableCollection<ToDoCategory> _Categories;
        public ObservableCollection<ToDoCategory> Categories
        {
            get { return _Categories; }
            set { _Categories = value; RaisePropertyChange("Categories"); }
        }


        private string _Body;
        public string Body
        {
            get { return _Body; }
            set { _Body = value; RaisePropertyChange("Body"); }
        }

        public ToDo() : this("Neue Aufgabe")
        {
        }

        public ToDo(string myTitle)
        {
            Title = myTitle;
            Date = DateTime.Now.Date;
            Categories = new ObservableCollection<ToDoCategory>();
            Body = "";
        }
    }
}
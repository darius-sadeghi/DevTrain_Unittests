using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using ToDoApp.Business;
using ToDoApp.Business.Models;
using ToDoApp.Business.Utility;
using ToDoApp.Client.Utility;

namespace ToDoApp.Client
{
    public class MainViewModel:ModelBase
    {
        private List<ToDo> _DataList;
        public List<ToDo> DataList
        {
            get { return _DataList; }
            set { _DataList = value; RaisePropertyChange("DataList"); }
        }

        private ToDo _SelectedToDo;
        public ToDo SelectedToDo
        {
            get { return _SelectedToDo; }
            set { _SelectedToDo = value; RaisePropertyChange("SelectedToDo"); }
        }

        private string _Suchwort;
        public string Suchwort
        {
            get { return _Suchwort; }
            set { _Suchwort = value; RaisePropertyChange("Suchwort"); }
        }


        public ICommand AddCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private ToDoRepositoryEDM _ToDoRepository;

        public MainViewModel()
        {
            DataList = new List<ToDo>();
            SelectedToDo = null;
            AddCommand = new StandardCommand(Add);
            DeleteCommand = new StandardCommand(Delete);
            UpdateCommand = new StandardCommand(Update);
            _ToDoRepository = new ToDoRepositoryEDM();

            SearchCommand = new StandardCommand(Search);
            Suchwort = "";
        }

        private void Search(object parameter)
        {
            try
            {
                var myQuery = from myToDo in _ToDoRepository.GetAll()
                              where myToDo.Title.Contains(this.Suchwort)
                              select myToDo;

                this.DataList = myQuery.ToList();
            }
            catch (Exception ex)
            {
                Logging.WriteLog("Fehler: " + ex.ToString());
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        private void Update(object parameter)
        {
            try
            {
                _ToDoRepository.Update(this.SelectedToDo);

                this.DataList = _ToDoRepository.GetAll().ToList(); 
            }
            catch (Exception ex)
            {
                Logging.WriteLog("Fehler: " + ex.ToString());
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        private void Delete(object parameter)
        {
            try
            {
                 _ToDoRepository.Delete(SelectedToDo);

                this.DataList = _ToDoRepository.GetAll().ToList();
                this.SelectedToDo = null;
            }
            catch (Exception ex)
            {
                Logging.WriteLog("Fehler: " + ex.ToString());
                MessageBox.Show("Fehler: " + ex.Message);
            }
        }

        private void Add(object parameter)
        {
            try
            {
                var toDo = new ToDo();
                _ToDoRepository.Create(toDo);

                this.DataList = _ToDoRepository.GetAll().ToList();
                this.SelectedToDo = toDo;
            }
            catch( Exception ex )
            {
                Logging.WriteLog("Fehler: " + ex.ToString());
                MessageBox.Show("Fehler: " + ex.Message);
            }
            
        }
    }

}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfApp4.Commands;
using System.Collections.ObjectModel;
using WpfApp4.Models;
using WpfApp4.Repositories;

namespace WpfApp4.ViewModels
{
    public class MainWindowViewModels : BaseViewModel
    {
        ObservableCollection<Author> aauthors;
        public Repository Authorss { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand ShowAllCommand { get; set; }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private string firstname;

        public string FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }

        private string lastname;

        public string LastName
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged(); }
        }

        private DataGrid authors;

        public DataGrid Authors
        {
            get { return authors; }
            set { authors = value; OnPropertyChanged(); }
        }

        public MainWindowViewModels()
        {
            Authorss = new Repository();
            aauthors = new ObservableCollection<Author>(Authorss.GetAll());
            Authors = new DataGrid();
            Authors.ItemsSource = aauthors;
            Authors.DisplayMemberPath = nameof(Author.FirstName);

            InsertCommand = new RelayCommand(obj =>
            {
                LastName = FirstName;
            });

            DeleteCommand = new RelayCommand(obj =>
            {

            });

            ShowAllCommand = new RelayCommand(obj =>
            {

            });

        }
    }
}

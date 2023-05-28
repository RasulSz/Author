using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp4.Commands;

namespace WpfApp4.ViewModels
{
    public class MainWindowViewModels : BaseViewModel
    {
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

        private GroupBox authors;

        public GroupBox Authors
        {
            get { return authors; }
            set { authors = value; OnPropertyChanged(); }
        }

        public MainWindowViewModels()
        {
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

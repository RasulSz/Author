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
        RelayCommand InsertCommand { get; set; }
        RelayCommand DeleteCommand { get; set; }
        RelayCommand ShowAllCommand { get; set; }
        private TextBox id;

        public TextBox Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged(); }
        }

        private TextBox firstname;

        public TextBox FirstName
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }

        private TextBox lastname;

        public TextBox LastName
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

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
                string cs = "";
                DataTable table;
                SqlDataReader reader;
                using (var conn = new SqlConnection())
                {
                    conn.ConnectionString = cs;
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "SELECT * FROM Authors";
                    command.Connection = conn;
                    table = new DataTable();
                    bool hasColumnAdded = false;
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!hasColumnAdded)
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    table.Columns.Add(reader.GetName(i));
                                }
                                hasColumnAdded = true;
                            }
                            DataRow row = table.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = reader[i];
                            }
                            table.Rows.Add(row);
                        }
                        author.ItemsSource = table.DefaultView;
                    }
                }
            });
        }
    }
}

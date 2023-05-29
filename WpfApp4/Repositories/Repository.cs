using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp4.Models;

namespace WpfApp4.Repositories
{
    public class Repository
    {
       
        ObservableCollection<Author> authors = new ObservableCollection<Author>();
        SqlConnection conn;
       

        public Repository()
        {
            using (var conn = new SqlConnection())
            {
                var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn.ConnectionString = cs;
                conn.Open();
                SqlDataReader reader = null;
                string query = "SELECT * FROM Authors";
                using (var command = new SqlCommand(query, conn))
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                       Author author = new Author();
                        author.Id = (int)reader[0];
                        author.FirstName = reader[1].ToString();
                        author.LastName = reader[2].ToString();
                        authors.Add(author);
                    }
                }
            }
        }
        public ObservableCollection<Author> GetAll()
        {
            return authors;
        }
        
        public void Insert(int id,string firstname,string lastname)
        {
            using (var conn = new SqlConnection())
            {
                var cs = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn.ConnectionString = cs;
                conn.Open();
                string query = $@"INSERT INTO Authors(Id,FirstName,LastName)
                               VALUES(@id,@firstname,@lastname)";

                var paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.SqlDbType = SqlDbType.Int;
                paramId.Value = id;

                var paramName = new SqlParameter();
                paramName.ParameterName = "@firstname";
                paramName.SqlDbType = SqlDbType.NVarChar;
                paramName.Value = firstname;

                var paramSurname = new SqlParameter();
                paramSurname.ParameterName = "@lastname";
                paramSurname.SqlDbType = SqlDbType.NVarChar;
                paramSurname.Value = lastname;

                using (var command = new SqlCommand(query,conn))
                {
                    command.Parameters.Add(paramId);
                    command.Parameters.Add(paramName);
                    command.Parameters.Add(paramSurname);

                    var result = command.ExecuteNonQuery();
                }

                Author author = new Author
                {
                    Id = id,
                    FirstName = firstname,
                    LastName = lastname
                };
                authors.Add(author);
                
            }
        }

        //public void Delete()
    }
}

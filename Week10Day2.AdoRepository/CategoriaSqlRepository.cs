using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.AdoRepository
{
    public class CategoriaSqlRepository : ICategoriaRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                                  "Initial Catalog = EroiVsMostri;" +
                                                  "Integrated Security = true";
        public List<Categoria> Fetch(string discriminator)
        {
            List<Categoria> categorie = new List<Categoria>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Categoria where Discriminator = @disc";
                command.Parameters.AddWithValue("@disc", discriminator);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Categoria c = new Categoria();
                    c.Id = (int)reader["Id"];
                    c.Nome = (string)reader["Nome"];
                    c.Discriminatore = (string)reader["Discriminator"];

                    categorie.Add(c);
                }
            }
            return categorie;
        }
    
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.AdoRepository
{
    public class ArmaSqlRepository : IArmaRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                                "Initial Catalog = EroiVsMostri;" +
                                                "Integrated Security = true";
        public List<Arma> Fetch(Categoria categoria)
        {
            List<Arma> armi = new List<Arma>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Arma where IdCategoria = @categoria";
                command.Parameters.AddWithValue("@categoria", categoria.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Arma a = new Arma();
                    a.Id = (int)reader["Id"];
                    a.Nome = (string)reader["Nome"];
                    a.PuntiDanno = (int)reader["PuntiDanno"];
                    a.IdCategoria = (int)reader["IdCategoria"];

                    armi.Add(a);
                }
            }
            return armi;
        }
    }
}

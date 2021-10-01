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
    public class MostriSqlRepository : IMostroRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                                   "Initial Catalog = EroiVsMostri;" +
                                                   "Integrated Security = true";
        public List<Mostro> FetchByLivello(int livello)
        {
            List<Mostro> mostri = new List<Mostro>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Personaggio.*, Arma.Nome as NomeArma, Arma.PuntiDanno, Categoria.Nome as NomeCategoria, Categoria.Discriminator " +
                                      "from Personaggio join Categoria on Categoria.Id = Personaggio.IdCategoria " +
                                      "join Arma on Arma.Id = Personaggio.IdArma " +
                                      "where Personaggio.Livello <= @lvl and Categoria.Discriminator ='Mostro'";
                command.Parameters.AddWithValue("@lvl", livello);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Mostro m = new Mostro();
                    m.Id = (int)reader["Id"];
                    m.Nome = (string)reader["Nome"];
                    m.Livello = (int)reader["Livello"];
                    m.PuntiVita = (int)reader["PuntiVita"];

                    Categoria c = new Categoria();
                    c.Id = (int)reader["IdCategoria"];
                    c.Nome = (string)reader["NomeCategoria"];
                    c.Discriminatore = (string)reader["Discriminator"];
                    m._Categoria = c;

                    Arma a = new Arma();
                    a.Id = (int)reader["IdArma"];
                    a.Nome = (string)reader["NomeArma"];
                    a.PuntiDanno = (int)reader["PuntiDanno"];
                    a.IdCategoria = (int)reader["IdCategoria"];
                    m._Arma = a;

                    mostri.Add(m);
                }
            }
            return mostri;
        }

        public Mostro Insert(Mostro m)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;

                command.CommandText = "insert into Personaggio values (@nome, @livello, @pv, @idcategoria, @idarma, @punti, @idgiocatore)";
                command.Parameters.AddWithValue("@nome", m.Nome);
                command.Parameters.AddWithValue("@livello", m.Livello);
                command.Parameters.AddWithValue("@pv", m.PuntiVita);
                command.Parameters.AddWithValue("@idcategoria", m._Categoria.Id);
                command.Parameters.AddWithValue("@idarma", m._Arma.Id);
                command.Parameters.AddWithValue("@punti", DBNull.Value);
                command.Parameters.AddWithValue("@idgiocatore", DBNull.Value);

                command.ExecuteNonQuery();
                return m;
            }
        }
    }
}

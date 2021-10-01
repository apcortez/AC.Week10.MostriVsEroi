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
    public class EroiSqlRepository : IEroeRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                                     "Initial Catalog = EroiVsMostri;" +
                                                     "Integrated Security = true";
        public string Delete(Eroe eroe)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Personaggio where Id = @id";
                command.Parameters.AddWithValue("@id", eroe.Id);

                command.ExecuteNonQuery();

            }
            return "Eroe eliminato con successo.";
        }

        public List<Eroe> FetchByUtente(Utente u)
        {
            List<Eroe> eroi = new List<Eroe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Personaggio.*, Arma.Nome as NomeArma, Arma.PuntiDanno, Categoria.Nome as NomeCategoria, Categoria.Discriminator " +
                                      "from Personaggio join Utente on Personaggio.IdGiocatore = Utente.Id " +
                                      "join Categoria on Categoria.Id = Personaggio.IdCategoria " +
                                      "join Arma on Arma.Id = Personaggio.IdArma "+
                                      "where Utente.Id = @user";
                command.Parameters.AddWithValue("@user", u.Id);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Eroe e = new Eroe();
                    e.Id = (int)reader["Id"];
                    e.Nome = (string)reader["Nome"];
                    e.Livello = (int)reader["Livello"];
                    e.PuntiVita = (int)reader["PuntiVita"];

                    Categoria c = new Categoria();
                    c.Id = (int)reader["IdCategoria"];
                    c.Nome = (string)reader["NomeCategoria"];
                    c.Discriminatore = (string)reader["Discriminator"];
                    e._Categoria = c;
                    
                    Arma a = new Arma();
                    a.Id = (int)reader["IdArma"];
                    a.Nome = (string)reader["NomeArma"];
                    a.PuntiDanno=(int)reader["PuntiDanno"];
                    a.IdCategoria = (int)reader["IdCategoria"];
                    e._Arma = a;

                    e.PuntiAccumulati = (int)reader["PuntiAccumulati"];
                    e.IdGiocatore = (int)reader["IdGiocatore"];

                    eroi.Add(e);
                }
            }
            return eroi;
        }

        public List<Eroe> FetchTop10()
        {
            List<Eroe> eroi = new List<Eroe>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT TOP(10) Personaggio.*, Arma.Nome as NomeArma, Arma.PuntiDanno, Categoria.Nome as NomeCategoria, Categoria.Discriminator " +
                                      "FROM Personaggio join Categoria on Personaggio.IdCategoria = Categoria.Id " +
                                      "join Arma on Arma.Id = Personaggio.IdArma " +
                                      "WHERE Categoria.Discriminator = 'Eroe' " +
                                      "Order by  Livello desc, PuntiAccumulati desc ";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Eroe e = new Eroe();
                    e.Id = (int)reader["Id"];
                    e.Nome = (string)reader["Nome"];
                    e.Livello = (int)reader["Livello"];
                    e.PuntiVita = (int)reader["PuntiVita"];

                    Categoria c = new Categoria();
                    c.Id = (int)reader["IdCategoria"];
                    c.Nome = (string)reader["NomeCategoria"];
                    c.Discriminatore = (string)reader["Discriminator"];
                    e._Categoria = c;

                    Arma a = new Arma();
                    a.Id = (int)reader["IdArma"];
                    a.Nome = (string)reader["NomeArma"];
                    a.PuntiDanno = (int)reader["PuntiDanno"];
                    a.IdCategoria = (int)reader["IdCategoria"];
                    e._Arma = a;

                    e.PuntiAccumulati = (int)reader["PuntiAccumulati"];
                    e.IdGiocatore = (int)reader["IdGiocatore"];
                    eroi.Add(e);
                }
            }
            return eroi;
        }

        public Eroe Insert(Eroe e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "insert into Personaggio values (@nome, @livello, @pv, @idcategoria, @idarma, @punti, @idgiocatore)";
                command.Parameters.AddWithValue("@nome", e.Nome);
                command.Parameters.AddWithValue("@livello", e.Livello);
                command.Parameters.AddWithValue("@pv", e.PuntiVita);
                command.Parameters.AddWithValue("@idcategoria", e._Categoria.Id);
                command.Parameters.AddWithValue("@idarma", e._Arma.Id);
                command.Parameters.AddWithValue("@punti", e.PuntiAccumulati);
                command.Parameters.AddWithValue("@idgiocatore", e.IdGiocatore);

                command.ExecuteNonQuery();
                return e;
            }
        }

        public void Update(Eroe e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;


                command.CommandText = "update Personaggio " +
                                      "set Nome = @nome, Livello = @livello, PuntiVita = @pv, IdCategoria = @idcategoria, IdArma = @idarma, " +
                                      "PuntiAccumulati = @punti, IdGiocatore = @idgiocatore " +
                                      "where Id = @id";
                command.Parameters.AddWithValue("@id", e.Id);
                command.Parameters.AddWithValue("@nome", e.Nome);
                command.Parameters.AddWithValue("@livello", e.Livello);
                command.Parameters.AddWithValue("@pv", e.PuntiVita);
                command.Parameters.AddWithValue("@idcategoria", e._Categoria.Id);
                command.Parameters.AddWithValue("@idarma", e._Arma.Id);
                command.Parameters.AddWithValue("@punti", e.PuntiAccumulati);
                command.Parameters.AddWithValue("@idgiocatore", e.IdGiocatore);
                

                command.ExecuteNonQuery();
            }
        }
    }
}

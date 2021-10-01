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
    public class UtentiSqlRepository : IUtenteRepository
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;" +
                                              "Initial Catalog = EroiVsMostri;" +
                                              "Integrated Security = true";
        public List<Utente> FetchByEroi(List<Eroe> eroi)
        {

            List<Utente> utentiEroi = new List<Utente>();
            foreach (var e in eroi) 
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select Utente.* from Utente join Personaggio on Utente.Id = Personaggio.Id where Utente.Id = @utenteEroe";
                    command.Parameters.AddWithValue("@utenteEroe", e.IdGiocatore);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Utente utente = new Utente();
                        utente.Id = (int)reader["Id"];
                        utente.Username = (string)reader["Username"];
                        utente.Password = (string)reader["Password"];
                        utente.isAdmin = (bool)reader["IsAdmin"];
                        
                        utentiEroi.Add(utente);
                    }

                } 
            }
            
            return utentiEroi;
        }

        public Utente GetByUsername(string username)
        {
            Utente utente = new Utente();
            try { using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        SqlCommand command = new SqlCommand();
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "select * from Utente where Username = @user";
                        command.Parameters.AddWithValue("@user", username);

                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            utente.Id = (int)reader["Id"];
                            utente.Username = (string)reader["Username"];
                            utente.Password = (string)reader["Password"];
                            utente.isAdmin = (bool)reader["IsAdmin"];

                        }
                    }
                    return utente;
                }catch(Exception ex)
                    {
                        throw ex;
                    }
            }

        public Utente GetByUserPass(string username, string password)
        {
            Utente utente = new Utente();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "select * from Utente where Username = @user, Password = @pass";
                    command.Parameters.AddWithValue("@user", username);
                    command.Parameters.AddWithValue("@pass", password);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        utente.Id = (int)reader["Id"];
                        utente.Username = (string)reader["Username"];
                        utente.Password = (string)reader["Password"];
                        utente.isAdmin = (bool)reader["IsAdmin"];

                    }
                }
                return utente;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Utente Insert(Utente u)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;


                    command.CommandText = "insert into Utente values (@username, @password, @admin)";
                    command.Parameters.AddWithValue("@username", u.Username);
                    command.Parameters.AddWithValue("@password", u.Password);
                    command.Parameters.AddWithValue("@admin", u.isAdmin);

                    command.ExecuteNonQuery();
                }

                return u;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.MockRepository
{
    public class UtentiRepository : IUtenteRepository
    {
        public static List<Utente> utenti = new List<Utente>()
        {
            new Utente{ Id = 1, Username = "pippo", Password = "pw1", isAdmin = true},
            new Utente{ Id = 2, Username = "pluto", Password = "pw2", isAdmin = false},
            new Utente{ Id = 3, Username = "paperino", Password = "pw3", isAdmin = true},
        };

        public List<Utente> FetchByEroi(List<Eroe> eroi)
        {
            
            List<Utente> utentiEroi = new List<Utente>();
            foreach(var e in eroi)
            {
                Utente utente = utenti.Where(u => u.Id == e.IdGiocatore).FirstOrDefault();
                utentiEroi.Add(utente);
            }
            return utentiEroi;
        }

        public Utente GetByUsername(string username)
        {
            return utenti.Where(u => u.Username == username).FirstOrDefault();
        }

        public Utente GetByUserPass(string username, string password)
        {
            return utenti.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

        public Utente Insert(Utente utente)
        {
            if(utenti.Count() == 0)
            {
                utente.Id = 1;
            }
            else
            {
                utente.Id = utenti.Max(u => u.Id) + 1;
            }
            utenti.Add(utente);
            return utente;
            
        }
    }
}

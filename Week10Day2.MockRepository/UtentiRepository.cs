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
        public static List<Utente> utenti = new List<Utente>();
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day2.Core.Entities
{
    public class Utente
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public bool isAdmin { get; set; }

        public Utente(string Username, string Password)
        {
            this.Username = Username;
            this.Password = Password;
        }

        public Utente()
        {

        }
    }
}

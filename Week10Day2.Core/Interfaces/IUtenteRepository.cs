using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;

namespace Week10Day2.Core.Interfaces
{
    public interface IUtenteRepository : IRepository<Utente>
    {
        Utente GetByUsername(string username);
        Utente GetByUserPass(string username, string password);
    }
}

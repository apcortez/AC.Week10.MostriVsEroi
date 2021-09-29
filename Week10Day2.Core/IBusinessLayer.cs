using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;

namespace Week10Day2.Core
{
    public interface IBusinessLayer
    {
        Utente GetUtente(string username);
        Utente AccediUtente(string username, string password);
        Utente InsertUser(Utente user);
        List<Eroe> FetchEroi(Utente u);
    }
}

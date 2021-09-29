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
        #region IUtente
        Utente GetUtente(string username);
        Utente AccediUtente(string username, string password);
        Utente InsertUser(Utente user);
        #endregion

        #region IEroi
        List<Eroe> FetchEroi(Utente u);
        Eroe InsertEroe(Eroe nuovoEroe);
        List<Categoria> FetchCategoria(string discriminator);
        List<Arma> FetchArma(Categoria categoria);
        string EliminaEroe(Eroe eroe);
        void UpdateEroe(Eroe eroe);
        #endregion
        #region IMostri
        Mostro GetRandomMostro(int livello);
        

        #endregion







    }
}

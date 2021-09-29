using System;
using System.Collections.Generic;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.Core
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IUtenteRepository utenteRepo;
        private readonly IEroeRepository eroeRepo;
        private readonly IMostroRepository mostroRepo;

        public BusinessLayer(IUtenteRepository utenti, IEroeRepository eroi, IMostroRepository mostri)
        {
            utenteRepo = utenti;
            eroeRepo = eroi;
            mostroRepo = mostri;
        }


        public List<Eroe> FetchEroi(Utente u)
        {
            return eroeRepo.FetchByUtente(u);
        }

        #region Utente
        public Utente AccediUtente(string username, string password)
        {
            return utenteRepo.GetByUserPass(username, password);
        }
        public Utente GetUtente(string username)
        {
            return utenteRepo.GetByUsername(username);
        }

        public Utente InsertUser(Utente user)
        {
            user.isAdmin = false;
            return utenteRepo.Insert(user);
            
        }

        #endregion
    }
}

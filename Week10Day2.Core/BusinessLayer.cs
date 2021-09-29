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
        private readonly ICategoriaRepository categoriaRepo;
        private readonly IMostroRepository mostroRepo;
        private readonly IArmaRepository armiRepo;

        public BusinessLayer(IUtenteRepository utenti, IEroeRepository eroi, IMostroRepository mostri, ICategoriaRepository categoria, IArmaRepository armi)
        {
            utenteRepo = utenti;
            eroeRepo = eroi;
            categoriaRepo = categoria;
            mostroRepo = mostri;
            armiRepo = armi;

        }


        public List<Arma> FetchArma(Categoria categoria)
        {
            return armiRepo.Fetch(categoria);
        }
        public List<Categoria> FetchCategoria(string discriminator)
        {
            return categoriaRepo.Fetch(discriminator);
        }

        public Eroe InsertEroe(Eroe nuovoEroe)
        {
            nuovoEroe.Livello = 1;
            nuovoEroe.PuntiAccumulati = 0;
            nuovoEroe.PuntiVita = 20;
            return eroeRepo.Insert(nuovoEroe);
        }

        public string EliminaEroe(Eroe eroe)
        {
            return eroeRepo.Delete(eroe);
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

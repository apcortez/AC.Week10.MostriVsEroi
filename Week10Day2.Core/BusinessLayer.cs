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

        #region Eroe

        public List<Arma> FetchArma(Categoria categoria)
        {
            return armiRepo.Fetch(categoria);
        }
        public List<Categoria> FetchCategoria(string discriminator)
        {
            return categoriaRepo.Fetch(discriminator);
        }
        public void UpdateEroe(Eroe eroe)
        {
            eroeRepo.Update(eroe);
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
        public List<Eroe> FetchClassica()
        {
            return eroeRepo.FetchTop10();
        }


        #endregion
        #region Utente

        public List<Utente> FetchUtenti(List<Eroe> eroi)
        {
            return utenteRepo.FetchByEroi(eroi);
        }

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
        #region Mostro
        public Mostro GetRandomMostro(int livello)
        {
            List<Mostro> mostri = mostroRepo.FetchByLivello(livello);
            Random random = new Random();
            int index = random.Next(mostri.Count);
            Mostro mostro = mostri[index];
            return mostro;

        }

        public Mostro InsertMostro(Mostro nuovoMostro)
        {
            switch (nuovoMostro.Livello)
            {
                case 1: nuovoMostro.PuntiVita = 20; break;
                case 2: nuovoMostro.PuntiVita = 40; break;
                case 3: nuovoMostro.PuntiVita = 60; break;
                case 4: nuovoMostro.PuntiVita = 80; break;
                case 5: nuovoMostro.PuntiVita = 100; break;
            }
            return mostroRepo.Insert(nuovoMostro);
        }



        #endregion
    }
}

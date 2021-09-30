using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.MockRepository
{
    public class EroiRepository : IEroeRepository
    {
        public static List<Eroe> eroi = new List<Eroe>() 
        {
            new Eroe{ Id = 1, Nome = "Pippo1", Livello = 2, PuntiAccumulati = 10, PuntiVita = 40, _Arma = new Arma{Id = 8, Nome = "Bastone magico", PuntiDanno = 10, IdCategoria = 2}, IdGiocatore = 1, _Categoria = new Categoria{Id = 2, Nome = "Mago", Discriminatore = "Eroe"}},
            new Eroe{ Id = 2, Nome = "Pippo2", Livello = 2, PuntiAccumulati = 50, PuntiVita = 100, _Arma = new Arma{Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1}, IdGiocatore = 1, _Categoria = new Categoria{Id = 1, Nome = "Guerriero", Discriminatore = "Eroe"}},
           
            new Eroe{ Id = 3, Nome = "Pluto1", Livello = 3, PuntiAccumulati = 30, PuntiVita = 60, _Arma = new Arma{Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1}, IdGiocatore = 2, _Categoria = new Categoria{Id = 1, Nome = "Guerriero", Discriminatore = "Eroe"}},
            new Eroe{ Id = 4, Nome = "Pluto2", Livello = 4, PuntiAccumulati = 60, PuntiVita = 80, _Arma = new Arma{Id = 9, Nome = "Onda d'urto", PuntiDanno = 15, IdCategoria = 2}, IdGiocatore = 2, _Categoria = new Categoria{Id = 2, Nome = "Mago", Discriminatore = "Eroe"}},
            
            new Eroe{ Id = 5, Nome = "Paperino1", Livello = 5, PuntiAccumulati = 225, PuntiVita = 100, _Arma = new Arma{Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1}, IdGiocatore = 3, _Categoria = new Categoria{Id = 1, Nome = "Guerriero", Discriminatore = "Eroe"}},
            new Eroe{ Id = 6, Nome = "Paperino2", Livello = 5, PuntiAccumulati = 400, PuntiVita = 100, _Arma = new Arma{Id = 8, Nome = "Bastone magico", PuntiDanno = 10, IdCategoria = 3}, IdGiocatore = 3, _Categoria = new Categoria{Id = 2, Nome = "Mago", Discriminatore = "Eroe"}},
            new Eroe{ Id = 7, Nome = "Pippo3", Livello = 5, PuntiAccumulati = 120, PuntiVita = 100, _Arma = new Arma{Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1}, IdGiocatore = 1, _Categoria = new Categoria{Id = 1, Nome = "Guerriero", Discriminatore = "Eroe"}},

            new Eroe{ Id = 8, Nome = "Pluto3", Livello = 1, PuntiAccumulati = 20, PuntiVita = 20, _Arma = new Arma{Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1}, IdGiocatore = 2, _Categoria = new Categoria{Id = 1, Nome = "Guerriero", Discriminatore = "Eroe"}},
            new Eroe{ Id = 9, Nome = "Pluto4", Livello = 4, PuntiAccumulati = 93, PuntiVita = 80, _Arma = new Arma{Id = 9, Nome = "Onda d'urto", PuntiDanno = 15, IdCategoria = 2}, IdGiocatore = 2, _Categoria = new Categoria{Id = 2, Nome = "Mago", Discriminatore = "Eroe"}},

            new Eroe{ Id = 10, Nome = "Paperino3", Livello = 1, PuntiAccumulati = 10, PuntiVita = 20, _Arma = new Arma{Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1}, IdGiocatore = 3, _Categoria = new Categoria{Id = 1, Nome = "Guerriero", Discriminatore = "Eroe"}},


        };

        public string Delete(Eroe eroe)
        {
            eroi.Remove(eroe);
            return "Eroe eliminato con successo.";
        }

        public List<Eroe> FetchByUtente(Utente u)
        {
            return eroi.Where(e => e.IdGiocatore == u.Id).ToList();
        }

        public List<Eroe> FetchTop10()
        {
            return eroi.OrderByDescending(e => e.Livello).ThenByDescending(e => e.PuntiAccumulati).Take(10).ToList();
        }

        public Eroe Insert(Eroe eroe)
        {
            if (eroi.Count() == 0)
            {
                eroe.Id = 1;
            }
            else
            {
                eroe.Id = eroi.Max(i => i.Id) + 1;
            }
            eroi.Add(eroe);
            return eroe;

        }

        public void Update(Eroe eroe)
        {
            Eroe eroeDaCancellare = eroi.Where(e => e.Id == eroe.Id).FirstOrDefault();
            if(eroeDaCancellare != null)
            {
                eroi.Remove(eroeDaCancellare);
                eroi.Add(eroe);
            } 
        }
    }
}

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
        public static List<Eroe> eroi = new List<Eroe>();

        public string Delete(Eroe eroe)
        {
            eroi.Remove(eroe);
            return "Eroe eliminato con successo.";
        }

        public List<Eroe> FetchByUtente(Utente u)
        {
            return eroi.Where(e => e.IdGiocatore == u.Id).ToList();
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

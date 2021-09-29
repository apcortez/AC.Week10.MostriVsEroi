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
        public List<Eroe> FetchByUtente(Utente u)
        {
            return eroi.Where(e => e.IdGiocatore == u.Id).ToList();
        }

        public Eroe Insert(Eroe item)
        {
            throw new NotImplementedException();
        }
    }
}

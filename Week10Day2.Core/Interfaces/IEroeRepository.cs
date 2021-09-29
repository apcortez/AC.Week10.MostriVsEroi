using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;

namespace Week10Day2.Core.Interfaces
{
    public interface IEroeRepository : IRepository<Eroe>
    {
        List<Eroe> FetchByUtente(Utente u);
        string Delete(Eroe eroe);
        void Update(Eroe eroe);
    }
}

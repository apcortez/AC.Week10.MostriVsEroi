using System;
using System.Collections.Generic;
using System.Linq;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.MockRepository
{
    public class MostriRepository : IMostroRepository
    {
        public static List<Mostro> mostri = new List<Mostro>() 
        { 
            new Mostro{Id = 1, Nome = "Shrek", Livello = 1, PuntiVita = 20, _Arma = new Arma{Id = 17, Nome = "Spada rotta", puntiDanno = 3, IdCategoria = 4}, _Categoria = new Categoria{Id = 4, Nome ="Orco", Discriminatore = "Mostro"} },
            new Mostro{Id = 2, Nome = "Cult", Livello = 1, PuntiVita = 20, _Arma = new Arma{Id = 12, Nome = "Farneticazione", puntiDanno = 7, IdCategoria = 3}, _Categoria = new Categoria{Id = 3, Nome ="Cultista", Discriminatore = "Mostro"}},
            new Mostro{Id = 3, Nome = "Shrek2", Livello = 3, PuntiVita = 60, _Arma = new Arma{Id = 18, Nome = "Mazza chiodata", puntiDanno = 10, IdCategoria = 4}, _Categoria = new Categoria{Id = 4, Nome ="Orco", Discriminatore = "Mostro"}},
            new Mostro{Id = 4, Nome = "Cult2", Livello = 3, PuntiVita = 60, _Arma = new Arma{Id = 14, Nome = "Magia nera", puntiDanno = 3, IdCategoria = 3}, _Categoria = new Categoria{Id = 3, Nome ="Cultista", Discriminatore = "Mostro"}},
            new Mostro{Id = 5, Nome = "Boss", Livello = 5, PuntiVita = 100, _Arma = new Arma{Id = 19, Nome = "Alabarda del drago", puntiDanno = 30, IdCategoria = 5}, _Categoria = new Categoria{Id = 5, Nome ="Signore del Male", Discriminatore = "Mostro"}}

        };

        public List<Mostro> FetchByLivello(int livello)
        {
            return mostri.Where(m => m.Livello <= livello).ToList();
        }

        public Mostro Insert(Mostro item)
        {
            throw new NotImplementedException();
        }
    }
}

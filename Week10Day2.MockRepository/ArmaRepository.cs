using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.MockRepository
{
    public class ArmaRepository : IArmaRepository
    {
        public static List<Arma> armi = new List<Arma>()
        {
            //guerriero
            new Arma{ Id = 1, Nome = "Alabarda", PuntiDanno = 15, IdCategoria = 1},
            new Arma{ Id = 2, Nome = "Ascia", PuntiDanno = 8, IdCategoria = 1},
            new Arma{ Id = 3, Nome = "Mazza", PuntiDanno = 5, IdCategoria = 1},
            new Arma{ Id = 4, Nome = "Spada", PuntiDanno = 10, IdCategoria = 1},
            new Arma{ Id = 5, Nome = "Spadone", PuntiDanno = 15, IdCategoria = 1},
            //mago
            new Arma{ Id = 6, Nome = "Arco e Frecce", PuntiDanno = 8, IdCategoria = 2},
            new Arma{ Id = 7, Nome = "Bacchetta", PuntiDanno = 5, IdCategoria = 2},
            new Arma{ Id = 8, Nome = "Bastone magico", PuntiDanno = 10, IdCategoria = 2},
            new Arma{ Id = 9, Nome = "Onda d'urto", PuntiDanno = 15, IdCategoria = 2},
            new Arma{ Id = 10, Nome = "Pugnale", PuntiDanno = 5, IdCategoria = 2},
            //cultista
            new Arma{ Id = 11, Nome = "Discorso noioso", PuntiDanno = 4, IdCategoria = 3},
            new Arma{ Id = 12, Nome = "Farneticazione", PuntiDanno = 7, IdCategoria = 3},
            new Arma{ Id = 13, Nome = "Imprecazione", PuntiDanno = 5, IdCategoria = 3},
            new Arma{ Id = 14, Nome = "Magia nera", PuntiDanno = 3, IdCategoria = 3},
            //orco
            new Arma{ Id = 15, Nome = "Arco", PuntiDanno = 7, IdCategoria = 4},
            new Arma{ Id = 16, Nome = "Clava", PuntiDanno = 5, IdCategoria = 4},
            new Arma{ Id = 17, Nome = "Spada rotta", PuntiDanno = 3, IdCategoria = 4},
            new Arma{ Id = 18, Nome = "Mazza chiodata", PuntiDanno = 10, IdCategoria = 4},
            //
            new Arma{ Id = 19, Nome = "Alabarda del drago", PuntiDanno = 30, IdCategoria = 5},
            new Arma{ Id = 20, Nome = "Divinazione", PuntiDanno = 15, IdCategoria = 5},
            new Arma{ Id = 21, Nome = "Fulmine", PuntiDanno = 10, IdCategoria = 5},
            new Arma{ Id = 22, Nome = "Fulmine celeste", PuntiDanno = 15, IdCategoria = 5},
            new Arma{ Id = 23, Nome = "Tempesta", PuntiDanno = 8, IdCategoria = 5},
            new Arma{ Id = 24, Nome = "Tempesta oscura", PuntiDanno = 15, IdCategoria = 5},
        };

        public List<Arma> Fetch(Categoria categoria)
        {
            return armi.Where(a => a.IdCategoria == categoria.Id).ToList();
        }
    }
}

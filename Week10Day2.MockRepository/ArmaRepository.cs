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
            new Arma{ Id = 1, Nome = "Alabarda", puntiDanno = 15, IdCategoria = 1},
            new Arma{ Id = 2, Nome = "Ascia", puntiDanno = 8, IdCategoria = 1},
            new Arma{ Id = 3, Nome = "Mazza", puntiDanno = 5, IdCategoria = 1},
            new Arma{ Id = 4, Nome = "Spada", puntiDanno = 10, IdCategoria = 1},
            new Arma{ Id = 5, Nome = "Spadone", puntiDanno = 15, IdCategoria = 1},

            new Arma{ Id = 6, Nome = "Arco e Frecce", puntiDanno = 8, IdCategoria = 2},
            new Arma{ Id = 7, Nome = "Bacchetta", puntiDanno = 5, IdCategoria = 2},
            new Arma{ Id = 8, Nome = "Bastone magico", puntiDanno = 10, IdCategoria = 2},
            new Arma{ Id = 9, Nome = "Onda d'urto", puntiDanno = 15, IdCategoria = 2},
            new Arma{ Id = 10, Nome = "Pugnale", puntiDanno = 5, IdCategoria = 2},

            new Arma{ Id = 11, Nome = "Discorso noioso", puntiDanno = 4, IdCategoria = 3},
            new Arma{ Id = 12, Nome = "Farneticazione", puntiDanno = 7, IdCategoria = 3},
            new Arma{ Id = 13, Nome = "Imprecazione", puntiDanno = 5, IdCategoria = 3},
            new Arma{ Id = 14, Nome = "Magia nera", puntiDanno = 3, IdCategoria = 3},

            new Arma{ Id = 15, Nome = "Arco", puntiDanno = 7, IdCategoria = 4},
            new Arma{ Id = 16, Nome = "Clava", puntiDanno = 5, IdCategoria = 4},
            new Arma{ Id = 17, Nome = "Spada rotta", puntiDanno = 3, IdCategoria = 4},
            new Arma{ Id = 18, Nome = "Mazza chiodata", puntiDanno = 10, IdCategoria = 4},

            new Arma{ Id = 19, Nome = "Alabarda del drago", puntiDanno = 30, IdCategoria = 5},
            new Arma{ Id = 20, Nome = "Divinazione", puntiDanno = 15, IdCategoria = 5},
            new Arma{ Id = 21, Nome = "Fulmine", puntiDanno = 10, IdCategoria = 5},
            new Arma{ Id = 22, Nome = "Fulmine celeste", puntiDanno = 15, IdCategoria = 5},
            new Arma{ Id = 23, Nome = "Tempesta", puntiDanno = 8, IdCategoria = 5},
            new Arma{ Id = 24, Nome = "Tempesta oscura", puntiDanno = 15, IdCategoria = 5},
        };

        public List<Arma> Fetch(Categoria categoria)
        {
            return armi.Where(a => a.IdCategoria == categoria.Id).ToList();
        }
    }
}

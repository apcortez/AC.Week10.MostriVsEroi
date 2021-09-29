using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week10Day2.Core.Entities;
using Week10Day2.Core.Interfaces;

namespace Week10Day2.MockRepository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public static List<Categoria> categorie = new List<Categoria>()
        {
            new Categoria{Id = 1, Nome = "Guerriero", Discriminatore="Eroe"},
            new Categoria{Id = 2, Nome = "Mago", Discriminatore="Eroe"},
            new Categoria{Id = 3, Nome = "Cultista", Discriminatore="Mostro"},
            new Categoria{Id = 4, Nome = "Orco", Discriminatore="Mostro"},
            new Categoria{Id = 5, Nome = "Signore del Male", Discriminatore="Mostro"},
        };

        public List<Categoria> Fetch(string discriminator)
        {
            return categorie.Where(c => c.Discriminatore == discriminator).ToList();
        }
    }
}

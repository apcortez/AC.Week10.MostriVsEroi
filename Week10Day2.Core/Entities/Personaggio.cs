using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day2.Core.Entities
{
    public abstract class Personaggio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Livello { get; set; }
        public int PuntiVita { get; set; }
        public Categoria _Categoria { get; set; }
        public Arma _Arma { get; set; }
    }
    
    public struct Categoria
    {
        public int Id;
        public string Nome;
        public string Discriminatore;
    }
    
}

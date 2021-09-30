using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day2.Core.Entities
{
    public class Arma
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public int PuntiDanno { get; set; }

        public int IdCategoria { get; set; }
        
        public string Print()
        {
            return $"{Nome} - Danno: {PuntiDanno}";
        }
    }
}

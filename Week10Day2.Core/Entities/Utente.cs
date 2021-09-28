using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10Day2.Core.Entities
{
    class Utente
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public List<Eroe> eroi { get; set; }
    }
}

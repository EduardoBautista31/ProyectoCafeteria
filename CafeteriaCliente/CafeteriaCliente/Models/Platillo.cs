using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaServidor.Models
{
    public class Platillo
    {
        public int NumeroMesa { get; set; }
        public string NombrePlatillo { get; set; } = "";
        public decimal CantidadPlatillos { get; set; }
    }
}

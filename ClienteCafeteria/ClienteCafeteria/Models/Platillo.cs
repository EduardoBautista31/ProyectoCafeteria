using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClienteCafeteria.Droid.Models
{
    public class Platillo
    {
        public int NumeroMesa { get; set; }
        public string NombrePlatillo { get; set; } = "";
        public decimal CantidadPlatillos { get; set; }
    }
}
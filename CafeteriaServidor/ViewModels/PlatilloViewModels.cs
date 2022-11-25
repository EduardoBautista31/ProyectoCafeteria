using CafeteriaServidor.Models;
using CafeteriaServidor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaServidor.ViewModels
{
    public class PlatilloViewModels : INotifyPropertyChanged
    {
        CafeteriaServices servicio = new CafeteriaServices();
        public ObservableCollection<Platillo> platillos = new ObservableCollection<Platillo>();
        public PlatilloViewModels()
        {
            Iniciar();
            servicio.ordenrecibida += Servicio_ordenrecibida;
        }

        private void Servicio_ordenrecibida(Models.Platillo obj)
        {            
            platillos.Add(obj);
            Actualizar();
        }

        private void Iniciar()
        {
           
            servicio.Iniciar();
            Actualizar();
        }
        void Actualizar(string? name=null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

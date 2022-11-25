using ClienteCafe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CafeteriaCliente
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        async void Ir(object sender, EventArgs a)
        {
            await Navigation.PushAsync(new HacerPedido());
        }
    }
}

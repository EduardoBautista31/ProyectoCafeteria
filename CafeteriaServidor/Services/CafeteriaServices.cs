using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaServidor.Services
{
    public class CafeteriaServices
    {
        //ESTE ES EL SERVIDOR
        HttpListener listener = new HttpListener();
        public CafeteriaServices()
        {
            listener.Prefixes.Add("http://*:12056/pedidos");

        }
        public void Iniciar()
        {
            if (!listener.IsListening)
            {
                listener.Start();
                listener.BeginGetContext(ContextoRecibido, null);
            }

        }

        private void ContextoRecibido(IAsyncResult ar)
        {
            var context = listener.EndGetContext(ar);

        }

    }
}

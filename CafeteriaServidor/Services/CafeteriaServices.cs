using CafeteriaServidor.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CafeteriaServidor.Services
{
    public class CafeteriaServices
    {
        //ESTE ES EL SERVIDOR
        HttpListener listener = new HttpListener();
        public event Action<Platillo>? ordenrecibida;
        public CafeteriaServices()
        {
            listener.Prefixes.Add("http://*:9000/pedidos/");

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
            listener.BeginGetContext(ContextoRecibido, null);
            if (context.Request.Url!=null)
            {
                if(context.Request.HttpMethod=="POST" && context.Request.Url.LocalPath== "/pedidos/respuesta")
                {
                    var stream = new StreamReader(context.Request.InputStream);
                    var json = stream.ReadToEnd();
                    Platillo? platillo = JsonConvert.DeserializeObject<Platillo>(json);
                    context.Response.StatusCode = 200;
                    context.Response.Close();
                    if (platillo!=null)
                    {
                        ordenrecibida?.Invoke(platillo);
                    }
                    context.Response.Close();

                }
                else
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.Close();
                }
            }


        }

    }
}

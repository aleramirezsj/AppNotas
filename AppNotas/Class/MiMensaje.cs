using AppNotas.Models;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNotas.Class
{
    public class MiMensaje : ValueChangedMessage<string>
    {
        public Nota NotaAEditar { get; set; }
        public MiMensaje(string value) : base(value)
        {

        }
    }
}

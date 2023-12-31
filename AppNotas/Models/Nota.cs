﻿using AppNotas.Utils;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppNotas.Models
{
    public class Nota
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Contenido { get; set; } = string.Empty;
        public byte[]? Imagen { get; set; }



        public override string ToString()
        {
            return Titulo +" "+ Contenido;
        }
    }
}

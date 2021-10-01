using Questionados.Net.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionados.Net.Models.Request
{
    public class InfoPreguntaNueva
    {

        public string Enunciado;

        public List<Respuesta> Opciones;

        public int CategoriaId;
    }
}

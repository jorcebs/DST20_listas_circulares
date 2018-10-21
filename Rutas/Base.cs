using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rutas
{
    class Base
    {
        public string nombre { private set; get; }
        public int minutos { private set; get; }
        public Base siguiente;

        public Base(string nombre, int minutos)
        {
            this.nombre = nombre;
            this.minutos = minutos;
            siguiente = null;
        }

        public override string ToString()
        {
            return nombre + "\t" + minutos.ToString() + Environment.NewLine;
        }
    }
}
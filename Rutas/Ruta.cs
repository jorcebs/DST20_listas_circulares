using System;

namespace Rutas
{
    class Ruta
    {
        Base inicio = null;

        public void agregarAlFinal(Base nueva)
        {
            if (inicio == null)
                inicio = nueva;
            else
            {
                Base temp = inicio;
                while (temp.siguiente != null && temp.siguiente != inicio)
                    temp = temp.siguiente;
                temp.siguiente = nueva;
            }
            nueva.siguiente = inicio;
        }

        public void agregarAlInicio(Base nueva)
        {
            if (inicio == null)
                inicio = nueva;
            else
            {
                Base temp = inicio;
                while (temp.siguiente != null && temp.siguiente != inicio)
                    temp = temp.siguiente;
                temp.siguiente = nueva;
            }
            nueva.siguiente = inicio;
            inicio = nueva;
        }

        public Base buscar(string nombre)
        {
            if (inicio == null)
                return null;
            else
            {
                Base temp = inicio;
                do
                {
                    if (temp.nombre == nombre)
                        return temp;
                    temp = temp.siguiente;
                }
                while (temp != inicio);
                return null;
            }
        }

        public bool eliminar(string nombre)
        {
            if (buscar(nombre) == null)
                return false;
            else
            {
                if (inicio.nombre == nombre)
                    eliminarInicio();
                else
                {
                    Base temp = inicio;
                    while (temp.siguiente.nombre != nombre)
                        temp = temp.siguiente;
                    temp.siguiente = temp.siguiente.siguiente;
                }
                return true;
            }
        }

        public bool eliminarInicio()
        {
            if (inicio == null)
                return false;
            else
            {
                if (inicio.siguiente == inicio)
                {
                    inicio.siguiente = null;
                    inicio = null;
                }
                else
                {
                    Base temp = inicio;
                    while (temp.siguiente != inicio)
                        temp = temp.siguiente;
                    temp.siguiente = inicio.siguiente;
                    inicio = inicio.siguiente;
                }
                return true;
            }
        }

        public bool eliminarÚltimo()
        {
            if (inicio == null)
                return false;
            else
            {
                if (inicio.siguiente == inicio)
                {
                    inicio.siguiente = null;
                    inicio = null;
                }
                else
                {
                    Base temp = inicio;
                    while (temp.siguiente.siguiente != inicio)
                        temp = temp.siguiente;
                    temp.siguiente = inicio;
                }
                return true;
            }
        }

        public bool insertarDespuésDe(string nombre, Base nueva)
        {
            if (buscar(nombre) == null)
                return false;
            else
            {
                Base temp = inicio;
                while (temp.nombre != nombre)
                    temp = temp.siguiente;
                nueva.siguiente = temp.siguiente;
                temp.siguiente = nueva;
                return true;
            }
        }

        public string recorrido(string nombre, DateTime hora, DateTime horaFin) // preguntar com interproceso
        {
            String recorrido = "";
            Base inicioRecorrido = buscar(nombre);
            if (inicioRecorrido != null)
            {
                recorrido = encabezado(inicioRecorrido);
                while (hora.CompareTo(horaFin) < 0)
                {
                    Base temp = inicioRecorrido;
                    do
                    {
                        recorrido += hora.ToShortTimeString() + "\t";
                        if (hora.CompareTo(horaFin) >= 0)   // sepa
                            break;
                        hora = hora.AddMinutes(temp.minutos);
                        temp = temp.siguiente;
                    }
                    while (temp != inicioRecorrido);
                    recorrido += Environment.NewLine;
                }
            }
            return recorrido;
        }

        private string encabezado(Base inicioRecorrido)
        {
            String txt = "";
            Base temp = inicioRecorrido;
            do
            {
                txt += temp.nombre + "\t";
                temp = temp.siguiente;
            }
            while (temp != inicioRecorrido);
            return txt += Environment.NewLine;
        }

        public override string ToString()
        {
            if (inicio == null)
                return "";
            else
            {
                String cadena = "Nombre\tMinutos\r\n";
                Base temp = inicio;
                do
                {
                    cadena += temp.ToString();
                    temp = temp.siguiente;
                }
                while (temp != inicio);
                return cadena;
            }
        }
    }
}

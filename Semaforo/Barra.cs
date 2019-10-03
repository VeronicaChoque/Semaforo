using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    public class Barra
    {
        public Queue<Cliente> capacidad { get; set; }
        public List<Bebida> bebidas { get; set; }
        public Barra() { capacidad = new Queue<Cliente>(); }

        public void atencionX()
        {
            foreach(var cliente in capacidad)
            {
                if(cliente.SeguirTomando && cliente.MeAlcanzaPara())
                {
                    cliente.BebidaDeseada.Decrementar();
                }
                capacidad.Dequeue();
            }

        }
    }
}

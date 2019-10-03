using System;

namespace Semaforo
{
    public class Bebida
    {
        public string nombre { get; set; }
        public int precio { get; set; }
        public int stock { get; set; }

        public Bebida() { }
        public void Decrementar()
        {
            stock--;
        }
    }
}

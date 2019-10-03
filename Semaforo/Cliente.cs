using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    public class Cliente
    {
        public string nombre { get; set; }
        public Queue<Bebida> bebidas { get; set; }
        public int tiempoConsumo { get; set; }
        public int plata { get; set; }
        public Bebida BebidaDeseada => bebidas.Peek();
        public Cliente()
        {
            bebidas = new Queue<Bebida>();
        }
        public void pedirBebida()
        {
            while (true)
            {
                foreach (var bebida in bebidas)
                {
                    if (alcanzaPara(bebida))
                    {
                        plata = plata - bebida.precio;
                        bebidas.Dequeue();
                    }
                    break;
                }
            }
        }

        private bool alcanzaPara(Bebida bebida)
        {
            return plata >= bebida.precio;
        }

        public bool MeAlcanzaPara() => alcanzaPara(BebidaDeseada);

        public bool SeguirTomando => bebidas.Count != 0;
    }
}

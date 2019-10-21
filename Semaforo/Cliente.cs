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

        private bool alcanzaPara(Bebida bebida) => plata >= bebida.precio;

        public bool AlcanzaDeseada() => alcanzaPara(BebidaDeseada);

        public bool SeguirTomando => bebidas.Count != 0;

        public void TomarBebida() => bebidas.Dequeue();

        public void Comprar()
        {
            decrmentarPlataPorBebida();
            TomarBebida();
        }

        private void decrmentarPlataPorBebida() => plata -= BebidaDeseada.precio;
    }
}
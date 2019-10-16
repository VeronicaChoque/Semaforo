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
                if(cliente.SeguirTomando && cliente.AlcanzaDeseada())
                {
                    cliente.BebidaDeseada.Decrementar();
                }
                capacidad.Dequeue();
            }
        }

        public void clienteEntraAlBar(Cliente cliente)
        {
            do
            {
                if (!hayStockDe(cliente.BebidaDeseada))
                {
                    Console.WriteLine("Cliente se va por insuficiencia de stock.");
                    break;
                }
                if (!cliente.AlcanzaDeseada())
                {
                    Console.WriteLine("Cliente se va porque no tiene mas plata.");
                    break;
                }
                Console.WriteLine("El cliente tomara {0}",cliente.BebidaDeseada.nombre);
                cliente.Comprar();

            } while (true);
        }

        public bool hayStockDe(Bebida bebida) => bebida.stock > 0;
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaforo
{
    public class Barra
    {
        const int personaEnSimultanio = 2;
        //const int cantidadHilos = 5;
        //Crea un hilos sin ningun recurso libre
        private static Semaphore semaforo = new Semaphore(0, personaEnSimultanio);
        //private static int contador = 0;
        //public List<Task> tareas { get; set; }
        public Queue<Cliente> capacidad { get; set; }
        public List<Bebida> bebidas { get; set; }
        public Barra() { capacidad = new Queue<Cliente>(); }

        
        public void clienteEntraAlBar(Cliente cliente)
        {
            semaforo.WaitOne();
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

            } while (cliente.SeguirTomando);
            Console.WriteLine("El cliente se va del bar.");
            semaforo.Release();
        }

        public bool hayStockDe(Bebida bebida) => bebida.stock > 0;

        public void abrirBar()
        {

        }

        public void clientesAHilo()
        {
            var tareas = new List<Task>();
            while (capacidad.Count!=0)
            {
                var cliente = capacidad.Dequeue();
                tareas.Add(new Task(()=>clienteEntraAlBar(cliente)));
            }
            tareas.ForEach(t=>t.Start());
            semaforo.Release(personaEnSimultanio);
        }
    }
}

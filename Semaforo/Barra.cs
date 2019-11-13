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
        public Barra() { capacidad = new Queue<Cliente>();
                         bebidas = new List<Bebida>(); }

        
        public void clienteEntraAlBar(Cliente cliente)
        {
            semaforo.WaitOne();
            Console.WriteLine("{0} entro al bar",cliente.nombre);
            do
            {
                if (!hayStockDe(cliente.BebidaDeseada))
                {
                    Console.WriteLine($"{cliente.nombre} se va por insuficiencia de stock.");
                    break;
                }
                if (!cliente.AlcanzaDeseada())
                {
                    Console.WriteLine("{0} se va porque no tiene mas plata.",cliente.nombre);
                    break;
                }
                Console.WriteLine("{0} tomara {1}",cliente.nombre,cliente.BebidaDeseada.nombre);
                cliente.Comprar();

            } while (cliente.SeguirTomando);
            Console.WriteLine("{0} se va del bar.",cliente.nombre);
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
            Task.WaitAll(tareas.ToArray());

        }

        public void agregarCliente(Cliente cliente)
        {
            capacidad.Enqueue(cliente);
        }

        public void agregarBebida(Bebida bebida)
        {
            bebidas.Add(bebida);
        }
    }
}

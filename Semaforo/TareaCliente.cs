using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Semaforo
{
    public class TareaCliente
    {
        const int cantidadMaximaTareas = 2;
        const int cantidadHilos = 5;
        //Crea un hilos sin ningun recurso libre
        private static Semaphore semaforo = new Semaphore(0, cantidadMaximaTareas);
        private static int contador = 0;

    }
}

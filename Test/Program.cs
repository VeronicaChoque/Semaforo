﻿using Semaforo;
using System;
using System.Collections.Generic;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
          

            var fernet = new Bebida { nombre ="Fernet",precio=110, stock=100 };
            var ronConCola = new Bebida { nombre ="Ron con Cola ", precio =100, stock =100};
            var Pinta = new Bebida { nombre ="Pinta de cerveza artesanal", precio =120, stock =100};
            var Daikiri = new Bebida { nombre ="Daikiri", precio =120, stock =100};

            var Beto = new Cliente { nombre = "Beto", plata = 500, tiempoConsumo = 1500 };
            Beto.agregarBebida(Pinta);
            Beto.agregarBebida(Pinta);
            Beto.agregarBebida(Pinta);
            Beto.agregarBebida(Pinta);
            Beto.agregarBebida(Pinta);

            var Guido = new Cliente { nombre = "Guido", plata = 800, tiempoConsumo = 5000 };
            Guido.agregarBebida(Daikiri);
            Guido.agregarBebida(Daikiri);

            var Adolfo = new Cliente { nombre = "Adolfo", plata = 200, tiempoConsumo = 3500 };
            Adolfo.agregarBebida(fernet);
            Adolfo.agregarBebida(ronConCola);
            Adolfo.agregarBebida(Pinta);

            var Ivan = new Cliente { nombre = "Ivan", plata = 500, tiempoConsumo = 2000 };
            Ivan.agregarBebida(Pinta);
            Ivan.agregarBebida(Pinta);
            Ivan.agregarBebida(Pinta);

            var Jessica = new Cliente { nombre = "Jessica", plata = 300, tiempoConsumo = 4500 };
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);
            Jessica.agregarBebida(Pinta);

            var barra1 = new Barra();
            barra1.agregarBebida(fernet);
            barra1.agregarBebida(ronConCola);
            barra1.agregarBebida(Pinta);
            barra1.agregarBebida(Daikiri);


            barra1.agregarCliente(Beto);
            barra1.agregarCliente(Guido);
            barra1.agregarCliente(Adolfo);
            barra1.agregarCliente(Ivan);
            barra1.agregarCliente(Jessica);
            

            barra1.clientesAHilo();
            Console.ReadKey();
        }
    }
}

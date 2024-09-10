using System;
using SCadeteria;

namespace Cadeteria;

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            InterfazCadeteria interfazCadeteria = new InterfazCadeteria();
            interfazCadeteria.IniciarPrograma("Pedidos.csv");
        }
    }

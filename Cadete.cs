using System;

namespace Cadeteria;

    public class Cadete
    {
        private static int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listadoPedidos;


    public string Telefono { get => telefono; set => telefono = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public Cadete()
    { id ++;
    }
    public Cadete( string nombre, string direccion, string telefono ) :this()
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listadoPedidos = new List<Pedidos>();
    }
}
using System;

namespace Cadeteria;

    public class Cadete
    {
        private static int id;
        private string nombre;
        private string direccion;
        private string telefono;
        private List<Pedidos> listadoPedidos;
        private  Pedidos? pedidoAux;

    public int Id {get => id;}
    public string Nombre { get => nombre; set => nombre = value; }
    public string Direccion { get => direccion; set => direccion = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Pedidos> ListadoPedidos {get => listadoPedidos; set => listadoPedidos = value;}
    public Cadete()
    { id ++;
    listadoPedidos = new List<Pedidos>();
    }
    public Cadete( string nombre, string direccion, string telefono ) :this()
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        listadoPedidos = new List<Pedidos>();
    }
    public Pedidos AltaPedido(string pObs, string cNombre, string cDireccion, string cTel, string cDatRef ){
        pedidoAux = new Pedidos( pObs,  cNombre,  cDireccion,  cTel,  cDatRef);
        this.listadoPedidos.Add(pedidoAux);
        return pedidoAux;
    }
    public Pedidos AltaPedido(Estado estado,string pObs, string cNombre, string cDireccion, string cTel, string cDatRef ){
        pedidoAux = new Pedidos( estado, pObs,  cNombre,  cDireccion,  cTel,  cDatRef);
        this.listadoPedidos.Add(pedidoAux);
        return pedidoAux;
    }


    public   Pedidos ObtenerPedidoPorId(int id){
        pedidoAux = this.listadoPedidos.FirstOrDefault(p => p.Nro == id); 

        return pedidoAux;
    }
   public Pedidos RemoverPedido ( int id){
    pedidoAux = this.listadoPedidos.FirstOrDefault(p => p.Nro == id);
    if(pedidoAux != null){
        this.listadoPedidos.Remove(pedidoAux);
    }

    return pedidoAux;
   }
   public void AsignarPedido(Pedidos pedidoAsignar){
     this.listadoPedidos.Add(pedidoAsignar);
     
   }

}
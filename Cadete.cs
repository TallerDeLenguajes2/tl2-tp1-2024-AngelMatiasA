using System;

namespace SCadeteria;

    public class Cadete
    {
        private static int nro= 0;
        private int id ;
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
    { this.id  = nro;
    listadoPedidos = new List<Pedidos>();
        nro++;
    }
    public Cadete( string nombre, string direccion, string telefono ) :this()
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        // listadoPedidos = new List<Pedidos>();
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
        if (pedidoAux != null)
        {
            return pedidoAux;
        } 
        return null;
    }
   public Pedidos RemoverPedido ( Pedidos pedidoRemover){
    if(pedidoRemover != null){
        this.listadoPedidos.Remove(pedidoRemover);
    }

    return pedidoRemover;
   }
   public Pedidos AsignarPedido(Pedidos pedidoAsignar){

    if(pedidoAsignar != null){
     this.listadoPedidos.Add(pedidoAsignar);
    }
    return pedidoAsignar;
     
   }

}
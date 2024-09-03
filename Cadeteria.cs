using System;

namespace SCadeteria;

    public class Cadeteria
    {
        public int ID { get; }
        public  string Nombre { get; set;}
        public string Direccion{get; set;}
        public List<Cadete> listadoCadetes {get;set;}

    public Cadeteria (){
        ID++;
        listadoCadetes = new List<Cadete>();
    }
    public Cadeteria ( string nombre, string Direccion):this()
    {
        this.Nombre = nombre;
        this.Direccion = Direccion;
    }
    public Cadeteria (List<Cadete> listaCadetesCsv, string nombre, string Direccion){
        ID++;
        this.Nombre = nombre;
        this.Direccion = Direccion;
        listadoCadetes =listaCadetesCsv;
    }
        public Cadete AltaCadete ( string nombre, string direccion, string telefono ){
            Cadete nuevoCadete = new Cadete( nombre,  direccion,  telefono );
            if (nuevoCadete !=null)
            {
                this.listadoCadetes.Add(nuevoCadete);
            }
            return  nuevoCadete;
        }
        public Cadete AltaPedido ( int idCadete, string pObs, string cNombre, string cDireccion, string cTel, string cDatRef){
            Cadete cadeteAsignar = this.listadoCadetes.FirstOrDefault(p => p.Id == idCadete);
            if (cadeteAsignar !=null)
            {
                cadeteAsignar.AltaPedido(  pObs,  cNombre,  cDireccion,  cTel,  cDatRef);
            }
            return  cadeteAsignar;
        }
        //primero uso este para chequear si el cadete a asignar existe 
        // y lo guardo en alguna variable cadete en la clase superior a esta
        public Cadete buscarCadetePorId(int id){
            Cadete cadeteBuscado = this.listadoCadetes.FirstOrDefault(c => c.Id == id);
            if(cadeteBuscado != null){
                return cadeteBuscado;
            }
            return null;
        }
        // aqui busco el cadete que tenga el pedido. Si no existe el pedido, 
        // no lo encuentra al cadete y en la clase superior recibo null y hago el control
        public Cadete BuscarCadeteConElPedido(int nroPedido){
            Cadete cadeteBuscado = null;
            Pedidos pedidoBuscado;
            foreach (var cadete in this.listadoCadetes)
            {
                pedidoBuscado = cadete.ObtenerPedidoPorId(nroPedido);
                if (pedidoBuscado != null)
                {
                    cadeteBuscado = cadete;
                    return cadeteBuscado;
                }
            }
            return cadeteBuscado;
        }
        // public Pedidos BuscarPedido(int nroPedido, Cadete CadeteAsignar){
        //     Pedidos pedidoBuscado;
        //     foreach (var cadete in this.listadoCadetes)
        //     {
        //         pedidoBuscado = cadete.ObtenerPedidoPorId(nroPedido);
        //         if (pedidoBuscado != null)
        //         {
        //             return pedidoBuscado;
        //         }
        //     }
        //     return null;
        // }
        //por ultimo utiliso este con el los cadetes obtenidos de los dos metodos anteriores
        public void ReasignarPedido(Cadete cadeteConPedido, int nroPedido, Cadete cadeteAsignar){
            Pedidos pedidoCurrent = cadeteConPedido.ObtenerPedidoPorId(nroPedido);
            cadeteConPedido.RemoverPedido(pedidoCurrent);
            cadeteAsignar.AsignarPedido(pedidoCurrent);
            
        }

    }
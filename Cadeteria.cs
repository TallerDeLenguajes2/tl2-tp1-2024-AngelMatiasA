using System;

namespace Cadeteria;

    public class Cadeteria
    {
        public int ID { get; set;}
        public  string Nombre { get; set;}
        public string Direccion{get; set;}
        public List<Cadete> listadoCadetes {get;set;}

    public Cadeteria (){
        listadoCadetes = new List<Cadete>();
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
        public Cadete buscarCadetePorId(int id){
            Cadete cadeteBuscado = this.listadoCadetes.FirstOrDefault(c => c.Id == id);
            if(cadeteBuscado != null){
                return cadeteBuscado;
            }
            return null;
        }
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
        public void ReasignarPedido(Cadete cadeteConPedido, int nroPedido, Cadete cadeteAsignar){
            Pedidos pedidoCurrent = cadeteConPedido.ObtenerPedidoPorId(nroPedido);
            cadeteConPedido.RemoverPedido(pedidoCurrent);
            cadeteAsignar.AsignarPedido(pedidoCurrent);
            
        }

    }
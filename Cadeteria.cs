using System;

namespace SCadeteria;

    public class Cadeteria
    {
        public int ID { get; }
        public  string Nombre { get; set;}
        public string Direccion{get; set;}
        public List<Cadete> ListadoCadetes {get;set;}

    public Cadeteria (){
        ID++;
        ListadoCadetes = new List<Cadete>();
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
        ListadoCadetes =listaCadetesCsv;
    }
        public Cadete AltaCadete ( string nombre, string direccion, string telefono ){
            Cadete nuevoCadete = new Cadete( nombre,  direccion,  telefono );
            if (nuevoCadete !=null)
            {
                this.ListadoCadetes.Add(nuevoCadete);
            }
            return  nuevoCadete;
        }
        public Cadete AltaPedido ( string pObs, string cNombre, string cDireccion, string cTel, string cDatRef, int idCadete){
            Cadete cadeteAsignar = this.ListadoCadetes.FirstOrDefault(p => p.Id == idCadete);
            if (cadeteAsignar !=null)
            {
                cadeteAsignar.AltaPedido(  pObs,  cNombre,  cDireccion,  cTel,  cDatRef);
            }
            return  cadeteAsignar;
        }
        //primero uso este para chequear si el cadete a asignar existe 
        // y lo guardo en alguna variable cadete en la clase superior a esta
        public Cadete buscarCadetePorId(int id){
            Cadete cadeteBuscado = this.ListadoCadetes.FirstOrDefault(c => c.Id == id);
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
            foreach (var cadete in this.ListadoCadetes)
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
        //     foreach (var cadete in this.ListadoCadetes)
        //     {
        //         pedidoBuscado = cadete.ObtenerPedidoPorId(nroPedido);
        //         if (pedidoBuscado != null)
        //         {
        //             return pedidoBuscado;
        //         }
        //     }
        //     return null;
        // }
        //por ultimo utilizo este con el los cadetes obtenidos de los dos metodos anteriores
        public void ReasignarPedido(Cadete cadeteConPedido, int nroPedido, Cadete cadeteAsignar){
            Pedidos pedidoCurrent = cadeteConPedido.ObtenerPedidoPorId(nroPedido);
            cadeteConPedido.RemoverPedido(pedidoCurrent);
            cadeteAsignar.AsignarPedido(pedidoCurrent);
            
        }
        public void CambiarEstado(Pedidos currentPedi, Estado estado){
           
                currentPedi.Estado = estado;
                
        }
          public Pedidos BuscarPedido(int nroPedido){
            Pedidos pedidoBuscado = null;
            foreach (var cadete in this.ListadoCadetes)
            {
                 if (cadete.ListadoPedidos.Count > 0){
                    pedidoBuscado = cadete.ObtenerPedidoPorId(nroPedido);
                    if (pedidoBuscado != null)
                    {
                        
                        return pedidoBuscado;
                    }
                 }
            }
            return pedidoBuscado;
        }
        public void MostrarCadetes(){
            foreach (Cadete cadete in this.ListadoCadetes)
            {
                Console.WriteLine($"Cadete nro: {cadete.Id}");
                Console.WriteLine($"Nombre: {cadete.Nombre}");
                Console.WriteLine($"Celular: {cadete.Telefono}");
                Console.WriteLine($"Direccion: {cadete.Direccion}");
                
            }
        }
        public void MostrarPedidos(){
            foreach (Cadete cadete in this.ListadoCadetes)
            {
                if (cadete.ListadoPedidos.Count > 0)
                {
                    Console.WriteLine($"Estos son los pedidos del Cadete");
                    Console.WriteLine($"Numero: {cadete.Id}");
                    Console.WriteLine($"Nombre: {cadete.Nombre}");
                    foreach (Pedidos pedido in cadete.ListadoPedidos){
                        Console.WriteLine($"Pedido nro: {pedido.Nro}");
                        Console.WriteLine($"Estado: {pedido.Estado}");
                        Console.WriteLine($"Observacion: {pedido.Observacion}");
                        Console.WriteLine($"Celular del cliente: {pedido.Cliente.Telefono}");
                        Console.WriteLine($"Nombre de cliente: {pedido.Cliente.Nombre}");
                        Console.WriteLine($"Direccion: {pedido.Cliente.Direccion}");
                        Console.WriteLine($"Datos de referencia de direccion: {pedido.Cliente.DatosReferenciaDireccion}");

                    }
                    
                }
                
            }
        }
        public int CantidadDeCadetes (){
            return this.ListadoCadetes.Count;
        }

    }
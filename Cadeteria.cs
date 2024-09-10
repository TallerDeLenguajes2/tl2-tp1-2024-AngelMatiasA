using System;

namespace SCadeteria;

    public class Cadeteria
    {
        private const double PrecioPorViaje = 500;

        public int ID { get; }
        public  string Nombre { get; set;}
        public string Direccion{get; set;}
         public string Telefono{get; set;}
        public List<Cadete> ListadoCadetes {get;set;}
        public List<Pedidos> ListadoPedidos {get;set;}

    public Cadeteria (){
        ID++;
        ListadoCadetes = new List<Cadete>();
        ListadoPedidos = new List<Pedidos>();
    }
    public Cadeteria ( string nombre, string telefono):this()
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
    }
   
        public Cadete AltaCadete ( string nombre, string direccion, string telefono ){
            Cadete nuevoCadete = new Cadete( nombre,  direccion,  telefono );
            if (nuevoCadete !=null)
            {
                this.ListadoCadetes.Add(nuevoCadete);
            }
            return  nuevoCadete;
        }
        public void AltaPedido ( string pObs, string cNombre, string cDireccion, string cTel, string cDatRef, int idCadete){
            Pedidos nuevoPedido = new Pedidos(pObs,  cNombre,  cDireccion,  cTel,  cDatRef, idCadete);
            if (nuevoPedido != null)
            {
                
                this.ListadoPedidos.Add(nuevoPedido);
            }
            else{
                Console.WriteLine("no se pudo crear el pedido");
            }
          
           
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
        public Pedidos ObtenerPedidoPorId(int id){
        Pedidos pedidoAux = this.ListadoPedidos.FirstOrDefault(p => p.Nro == id);
        if (pedidoAux != null)
        {
            return pedidoAux;
        } 
        return null;
    }
        // aqui busco el cadete que tenga el pedido. Si no existe el pedido, 
        // no lo encuentra al cadete y en la clase superior recibo null y hago el control
        // public Cadete BuscarCadeteConElPedido(int nroPedido){
        //     Cadete cadeteBuscado = null;
        //     Pedidos pedidoBuscado;
        //     foreach (var cadete in this.ListadoCadetes)
        //     {
        //         pedidoBuscado = cadete.ObtenerPedidoPorId(nroPedido);
        //         if (pedidoBuscado != null)
        //         {
        //             cadeteBuscado = cadete;
        //             return cadeteBuscado;
        //         }
        //     }
        //     return cadeteBuscado;
        // }
     
        //por ultimo utilizo este con el los cadetes obtenidos de los dos metodos anteriores
        public void AsignarCadeteAPedido(int idCadete, int nroPedido){
            Pedidos pedBuscado = ObtenerPedidoPorId(nroPedido);
            pedBuscado.IdCadete = idCadete;
           
        }
        //no recibe datos primitivos por eso lo cambio para el tp3
        // public void CambiarEstado(Pedidos currentPedi, Estado estado){
           
        //         currentPedi.Estado = estado;
                
        // }
         public void CambiarEstado(int idPedido, int estado){
            Pedidos pedidoCambiar = ObtenerPedidoPorId(idPedido);
            pedidoCambiar.Estado = (Estado)estado;
                
        }
         
        public List<Cadete> MostrarCadetes(){
            return this.ListadoCadetes;
          
        }
        public List<Pedidos> MostrarPedidos(){
            return this.ListadoPedidos;

        }
      
        public int CantidadDeCadetes (){
            return this.ListadoCadetes.Count;
        }
        public int CantidadDePedidos (){
            return this.ListadoPedidos.Count;
        }
        public int PedidosRealizados(int idCadete){
              int realizados =  ListadoPedidos.Where
           (p => p.IdCadete == idCadete && p.Estado == Estado.Entregado).Count();
           return realizados;
        }
        public double JornalACobrar(int idCadete){
            int realizados = PedidosRealizados(idCadete);
         

            return realizados * PrecioPorViaje ;
        }

    }
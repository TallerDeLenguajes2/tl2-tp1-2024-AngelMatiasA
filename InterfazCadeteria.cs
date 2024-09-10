using System;
using System.Collections.Generic;
using System.IO;
using SCadeteria;

namespace SCadeteria;
public class InterfazCadeteria {
    const string CadeteriaJson = "Cadeteria.json";
    const string CadetesJson = "Cadetes.json";
    const string CadetesCSV = "CadeteriaDatos.csv";
    const string CadeteriaCSV = "Cadetes.csv";
    int nroPedido = 0;
    bool fin = false;
    static bool  continuar = true;
    InformeFinal informe;
    Cadeteria cadeteria;
    AccesoCSV accesoCsv;   
    AccesoJSON accesoJson;   
    int opcion = 0;
    public void IniciarPrograma( string nomArchPedidos ){
        CargarDatos();
        CargarPedidos(cadeteria, nomArchPedidos);
        do
        {
             Console.WriteLine("ingrese: \n  1) dar de alta pedidos \n " +
            " 2)Asignar pedido a cadetes \n 3) Cambiar Estado \n  4) Mostrar Cadetes \n  5) Mostrar Pedidos \n 0)Salir");
            opcion =  Convert.ToInt32(Console.ReadLine());
            LeerOpciones(opcion);
            
        } while (!fin);

    }

    private void LeerOpciones(int opc) {
        switch (opc)
        {
            case 0:
                fin = true;
                informe = new InformeFinal(cadeteria);
                informe.MostrarInforme();
                break;
            case 1:
                string [] datosPedidos = ObtenerDatosPedido();
                int idCadete = Convert.ToInt32(datosPedidos[5]);
                cadeteria.AltaPedido(datosPedidos[0], datosPedidos[1], datosPedidos[2], datosPedidos[3], datosPedidos[4], idCadete);
                Console.WriteLine($"Se guardo el pedido  ");
            
                break;
            case 2:
                Cadete cadeteAsignar = null;
                Pedidos cadeteConPedido = null;
               
                Pedidos pedido = null;
                do
                {
                    Console.WriteLine("Ingrese el Id del cadete al cual desea asignarle el pedido");
                    int idAsignar;
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out idAsignar))
                    {
                        Console.WriteLine("No se pudo leer el numero ingresado, por favor intente nuevamente  ");
                    }
                    else
                    {
                         cadeteAsignar = cadeteria.buscarCadetePorId(idAsignar);
                        if(cadeteAsignar != null){
                            continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el cadete, intente nuevamente");
                        }
                    }
                    
                } while (continuar);
                continuar = true;
                do
                {
                    int op ;
                    Console.WriteLine("Ingrese el numero del pedido ");
                    
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out nroPedido))
                    {
                        Console.WriteLine("No se pudo leer el numero ingresado, por favor intente nuevamente  ");
                    }
                    else
                    {
                         pedido = cadeteria.ObtenerPedidoPorId(nroPedido);
                        if(pedido != null){
                            continuar = false;
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el pedido \n Para intentar nuevamente"+
                            ". presione 1 \n Para volver al menu principal precione 0");
                            while (!int.TryParse(Console.ReadLine(), out op) || op <0 || op>1){                            
                                Console.WriteLine("El número ingresado no es correcto, por favor intente nuevamente"+ 
                                  " \n Para intentar nuevamente"+
                            ". presione 1 \n Para volver al menu principal precione 0");
                            }
                            if(op == 0){continuar =false;}
                        }
                    }
                    
                } while (continuar);
                if(pedido != null && cadeteAsignar!= null){
                    cadeteria.AsignarCadeteAPedido(cadeteAsignar.Id, nroPedido );
                    Console.WriteLine($"Se asigno el pedido numero {nroPedido} con exito al cadete {cadeteAsignar.Nombre}");
                }
                
                break;
            case 3:
              do {
                    Console.WriteLine("Ingrese el numero del pedido ");
                    
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out nroPedido))
                    {
                        Console.WriteLine("No se pudo leer el numero ingresado, por favor intente nuevamente  ");
                    }
                    else
                    {
                        Pedidos buscado = cadeteria.ObtenerPedidoPorId( nroPedido);
                        if(buscado != null){
                            Console.WriteLine("Ingrese el estado del pedido:");
                            Console.WriteLine("1 - EnProceso");
                            Console.WriteLine("2 - Entregado");
                            Console.WriteLine("3 - Cancelado");
                            int opcEstado;
                            while(!int.TryParse(Console.ReadLine(), out opcEstado ) || opcEstado < 1 || opcEstado > 3){
                                Console.WriteLine("No se encontro el valor de estado ingresado, intente nuevamente");
                                Console.WriteLine("1 - EnProceso");
                                Console.WriteLine("2 - Entregado");
                                Console.WriteLine("3 - Cancelado");
                            }
                            opcEstado--;
                            Estado nuevoEstado = (Estado)opcEstado;
                            // cadeteria.CambiarEstado(buscado, nuevoEstado );
                            cadeteria.CambiarEstado(nroPedido, opcEstado );
                             Console.WriteLine($"Se cambio de estado con exito a : {nuevoEstado.ToString()}");
                            
                            continuar = false;
                        }
                        else
                        {
                            int op = -1;
                            Console.WriteLine("No se encontro el pedido \n Para intentar nuevamente"+
                            ". presione 1 \n Para volver al menu principal precione 0");
                            while (!int.TryParse(Console.ReadLine(), out op) || op <0 || op>1){                            
                                Console.WriteLine("El número ingresado no es correcto, por favor intente nuevamente  ");
                            }
                            if(op == 0){continuar =false;}
                        }
                    }
                    
                } while (continuar);
                break;
            case 4:
                MostrarCadetes();
                break;
            case 5:
                MostrarPedidos();
                break;

                

            
            default:
                Console.WriteLine("opcion incorrecta, intente de nuevo.");
                break;
        }
    }

    private static string[] ObtenerDatosPedido(){
        string [] datosCliente = new string[6];
        Console.WriteLine("Ingrese la observación del pedido:");
        datosCliente[0] = Console.ReadLine();

         Console.WriteLine("Ingrese el nombre del cliente:");
        datosCliente[1] = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección del cliente:");
        datosCliente[2] = Console.ReadLine();

        Console.WriteLine("Ingrese el teléfono del cliente:");
        datosCliente[3] = Console.ReadLine();

        Console.WriteLine("Ingrese datos de referencia del cliente:");
        datosCliente[4] = Console.ReadLine();
          
          Console.WriteLine("Si posee el numero de cadete para asignarle ingreselo ahora, de lo contrario ingrese 0:");
        datosCliente[5] = Console.ReadLine();

    return (datosCliente);
    }

    public void CargarDatosConCSV( ){
        accesoCsv = new AccesoCSV();
        cadeteria = accesoCsv.cargarCadeteria(CadeteriaCSV);
        if(accesoCsv.cargarCadetes( CadeteriaCSV) != null){
        cadeteria.ListadoCadetes = accesoCsv.cargarCadetes(CadeteriaCSV);
        }else
        {
            Console.WriteLine("no se pudo cargar cadetes, intente de nuevo");
        }
    }
   
   public void CargarDatos(){
    int op ; 
    Console.WriteLine("Ingrese 1 si quiere cargar los datos desde csv o 2 desde el json  ");
     while (!int.TryParse(Console.ReadLine(), out op) || op <1 || op>2){                            
        Console.WriteLine("El número ingresado no es correcto, por favor intente nuevamente  ");
    }
    if(op == 1){
       
    
        CargarDatosConCSV();
    }
    else {
        CargarDatosConJSON();
    }
    
   }

    public void CargarDatosConJSON( ){
        accesoJson = new AccesoJSON();
        cadeteria = accesoJson.cargarCadeteria(CadeteriaJson);
        if(cadeteria == null){
            Console.WriteLine("no se pudo cargar los datos de la cadeteria.");
            
        }
        if(accesoJson.cargarCadetes( CadetesJson) != null){
        cadeteria.ListadoCadetes = accesoJson.cargarCadetes(CadetesJson);
        }else
        {
            Console.WriteLine("no se pudo cargar cadetes, intente de nuevo");
        }
    }
    public void CargarPedidos(Cadeteria cadeteria, string nomArchPedidos ){
        accesoCsv = new AccesoCSV();
        accesoCsv.cargarPedidos(cadeteria, nomArchPedidos);
       
            Console.WriteLine("Se cargaron los Pedidos");

        
    }

       public void MostrarCadetes(){
            foreach (Cadete cadete in cadeteria.MostrarCadetes())
            {
                Console.WriteLine($"\n************************* \n");
                Console.WriteLine($"Cadete nro: {cadete.Id}");
                Console.WriteLine($"Nombre: {cadete.Nombre}");
                Console.WriteLine($"Celular: {cadete.Telefono}");
                Console.WriteLine($"Direccion: {cadete.Direccion}");
                
            }
        }
          public void MostrarPedidos(){
            List<Pedidos> listadoPedidos = cadeteria.MostrarPedidos();
         
            if (listadoPedidos.Count > 0)
            {
                
                foreach (Pedidos pedido in listadoPedidos){
                    Console.WriteLine($" \n ************** Pedido nro: {pedido.Nro} *************** ");
                    Console.WriteLine($"Estado: {pedido.Estado}");
                    Console.WriteLine($"Observacion: {pedido.Observacion}");
                    Console.WriteLine($"Celular del cliente: {pedido.Cliente.Telefono}");
                    Console.WriteLine($"Nombre de cliente: {pedido.Cliente.Nombre}");
                    Console.WriteLine($"Direccion: {pedido.Cliente.Direccion}");
                    Console.WriteLine($"Datos de referencia de direccion: {pedido.Cliente.DatosReferenciaDireccion}");
                    if(pedido.IdCadete >0){
                        Console.WriteLine($"Este Pedido le pertenece al cadete de id: {pedido.IdCadete}");

                    }else{
                        Console.WriteLine($"Pedido sin asignar");

                    }

                }
                
            }
            
            
        }

}
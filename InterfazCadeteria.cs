using System;
using System.Collections.Generic;
using System.IO;
using SCadeteria;

namespace SCadeteria;
public class InterfazCadeteria {
    int nroPedido = 0;
    bool fin = false;
    static bool  continuar = true;
    InformeFinal informe;
    Cadeteria cadeteria;
    AccesoDatos accesoCsv;   
    int opcion = 0;
    public void IniciarPrograma(string nomArchCadeteria, string nomArchCadetes, string nomArchPedidos ){
        CargarDatos( nomArchCadeteria,  nomArchCadetes );
        CargarPedidos(cadeteria, nomArchPedidos);
        do
        {
             Console.WriteLine("ingrese: \n  1) dar de alta pedidos \n " +
            " 2) reasignarlos a cadetes \n 3) Cambiar Estado \n  4) Mostrar Cadetes \n  5) Mostrar Pedidos \n 0)Salir");
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
                Cadete cadeteConPedido = cadeteria.AltaPedido(datosPedidos[0], datosPedidos[1], datosPedidos[2], datosPedidos[3], datosPedidos[4], idCadete);
                if (cadeteConPedido !=null){
                    Console.WriteLine($"Se guardo el pedido con el cadete : {cadeteConPedido.Nombre} de id numero: {cadeteConPedido.Id}  ");
                    break;
                }
                Console.WriteLine("No se pudo cargar el pedido.");
                break;
            case 2:
                Cadete cadeteAsignar = null; cadeteConPedido = null;
               
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
                         cadeteConPedido = cadeteria.BuscarCadeteConElPedido(nroPedido);
                        if(cadeteConPedido != null){
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
                if(cadeteConPedido != null && cadeteAsignar!= null){
                    cadeteria.ReasignarPedido(cadeteConPedido, nroPedido, cadeteAsignar);
                    Console.WriteLine($"Se reasigno el pedido con exito desde el cadete {cadeteConPedido.Nombre} "+
                    $", para el cadete {cadeteAsignar.Nombre}");
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
                        Pedidos buscado = cadeteria.BuscarPedido( nroPedido);
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
                            cadeteria.CambiarEstado(buscado, nuevoEstado );
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
                cadeteria.MostrarCadetes();
                break;
            case 5:
                cadeteria.MostrarPedidos();
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
          
          Console.WriteLine("Si posee el numero de cadete ingreselo ahora, de lo contrario ingrese 1:");
        datosCliente[5] = Console.ReadLine();

    return (datosCliente);
    }

    public void CargarDatos(string nomArchCadeteria, string nomArchCadetes ){
        accesoCsv = new AccesoDatos();
        cadeteria = accesoCsv.cargarCadeteria(nomArchCadeteria);
        if(accesoCsv.cargarCadetes( cadeteria, nomArchCadetes) == null){
            Console.WriteLine("no se pudo cargar cadetes, intente de nuevo");

        }
    }
    public void CargarPedidos(Cadeteria cadeteria, string nomArchPedidos ){
        accesoCsv = new AccesoDatos();
        accesoCsv.cargarPedidos(cadeteria, nomArchPedidos);
       
            Console.WriteLine("Se cargaron los Pedidos");

        
    }

}
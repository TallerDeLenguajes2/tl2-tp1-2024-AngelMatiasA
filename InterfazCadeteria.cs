using System;
using System.Collections.Generic;
using System.IO;
using SCadeteria;

namespace SCadeteria;
public class InterfazCadeteria {
    bool fin = false;
    Cadeteria cadeteria;
    AccesoDatos accesoCsv;   
    int opcion = 0;
    public void IniciarPrograma(string nomArchCadeteria, string nomArchCadetes ){
        CargarDatos( nomArchCadeteria,  nomArchCadetes );
        do
        {
             Console.WriteLine("ingrese: \n  1) dar de alta pedidos \n " +
            " 2) reasignarlos a cadetes \n 3) Mostrar Cadetes \n 0)Salir");
            opcion =  Convert.ToInt32(Console.ReadLine());
            LeerOpciones(opcion);
            
        } while (!fin);

    }

    private void LeerOpciones(int opc) {
        switch (opc)
        {
            case 0:
                fin = true;
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
                bool continuar = true;
                Cadete cadeteAsignar = null; cadeteConPedido = null;
                int nroPedido;
                Pedidos pedido = null;
                do
                {
                    Console.WriteLine("Ingrese el Id del cadete al cual desea asignarle el pedido");
                    int idAsignar;
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out idAsignar))
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
                    Console.WriteLine("Ingrese el numero del pedido ");
                    
                    string input = Console.ReadLine();
                    if (!Int32.TryParse(input, out nroPedido))
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
                            Console.WriteLine("No se encontro el cadete, intente nuevamente");
                        }
                    }
                    
                } while (continuar);
                cadeteria.ReasignarPedido(cadeteConPedido, nroPedido, cadeteAsignar);
                
                break;
            case 3:
                cadeteria.MostrarCadetes();
                break;
            case 4:
                cadeteria.MostrarPedidos();
                break;

                

            
            default:
                Console.WriteLine("opcion incorrecta, intente de nuevo.");
                break;
        }
    }

    private static string[] ObtenerDatosPedido(){
        string [] datosCliente = new string[6];
         Console.WriteLine("Ingrese el nombre del cliente:");
        datosCliente[0] = Console.ReadLine();

        Console.WriteLine("Ingrese la dirección del cliente:");
        datosCliente[1] = Console.ReadLine();

        Console.WriteLine("Ingrese la observación del pedido:");
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

}
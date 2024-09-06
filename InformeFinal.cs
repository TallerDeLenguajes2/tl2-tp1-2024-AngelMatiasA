using System; 
using SCadeteria; 
namespace SCadeteria;

public class InformeFinal {
    private const double PrecioPorViaje = 500;
    private Cadeteria cadeteriaInforme;
    private InformeGrupal infGrup;
 
 public InformeFinal( Cadeteria cadetInforme){
    this.cadeteriaInforme = cadetInforme;
    infGrup = new InformeGrupal();
    cargarInforme();
 }

 public void AgregarInfPerALista( InformePersonal nuevoInf){
    this.infGrup.ListInfCadetes.Add(nuevoInf);
 }
 

 public void cargarInforme(){
    List<InformeGrupal> nuevoInf = null;
    infGrup.TotalDeEnvios = 0;
    infGrup.MontoGanadoTotal = 0;
    InformePersonal nuevoInfo ;
    foreach (Cadete cadete in cadeteriaInforme.ListadoCadetes)
    {
        nuevoInfo = new InformePersonal(); 
        nuevoInfo.IdCadete = cadete.Id;
        nuevoInfo.NombreCadete = cadete.Nombre;
        nuevoInfo.PedidosRealizados= 0;
        if (cadete.CantidadDePedidosAsignasdos()>0)
        {
            foreach (Pedidos pedidoAsign in cadete.ListadoPedidos)
            {
                if( pedidoAsign.Estado == Estado.Entregado){
                    nuevoInfo.PedidosRealizados++;
                    infGrup.TotalDeEnvios++;
                }
            }
        }
        nuevoInfo.MontoGanado = nuevoInfo.PedidosRealizados * PrecioPorViaje;
        infGrup.MontoGanadoTotal += nuevoInfo.MontoGanado ;
           
            AgregarInfPerALista(nuevoInfo);
        
    }
    infGrup.EnvioPromedio = infGrup.TotalDeEnvios / cadeteriaInforme.CantidadDeCadetes();
 }

    
}
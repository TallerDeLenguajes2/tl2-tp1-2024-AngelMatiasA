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
 public void MostrarInforme (){
    Console.WriteLine($"Informe numero: {Convert.ToString(infGrup.NroDeInforme)}");
    Console.WriteLine($"Cadeteria Nombre: {cadeteriaInforme.Nombre}");
    Console.WriteLine($"Envios Realizados: {Convert.ToString(infGrup.TotalDeEnvios)}");
    Console.WriteLine($"Envios Promedio por Cadete: {Convert.ToString(infGrup.EnvioPromedio)}");
    Console.WriteLine($"Monto Ganado : ${Convert.ToString(infGrup.MontoGanadoTotal)}");
    Console.WriteLine($"Informe Personal Por cada Cadete : ");
    foreach(InformePersonal persInf in infGrup.ListInfCadetes){

    Console.WriteLine($"*********** *************** \n ************************** \n");
    Console.WriteLine($"Cadete Id: {persInf.IdCadete}");
    Console.WriteLine($"Cadete Nombre: {persInf.NombreCadete}");
    Console.WriteLine($"Envios Realizados: {Convert.ToString(persInf.PedidosRealizados)}");
    Console.WriteLine($"Total Cobrado: ${Convert.ToString(persInf.MontoGanado)}");

    }



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
        nuevoInfo.PedidosRealizados= cadeteriaInforme.PedidosRealizados(cadete.Id);
        infGrup.TotalDeEnvios += nuevoInfo.PedidosRealizados;
        nuevoInfo.MontoGanado = cadeteriaInforme.JornalACobrar(cadete.Id);
        infGrup.MontoGanadoTotal += nuevoInfo.MontoGanado ;
           
            AgregarInfPerALista(nuevoInfo);
        
    }
    infGrup.EnvioPromedio = infGrup.TotalDeEnvios / cadeteriaInforme.CantidadDeCadetes();
 }

    
}
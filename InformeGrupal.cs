using System; 
using SCadeteria; 
namespace SCadeteria;

public class InformeGrupal {

    private static int nro = 0;
    public int NroDeInforme{get; }
    public double EnvioPromedio {get; set;}
    public double MontoGanadoTotal {get;set;}
    public double TotalDeEnvios {get;set;}
    public List<InformePersonal> ListInfCadetes {get;set;}

 
public InformeGrupal (){
    nro++;
    this.NroDeInforme = nro;
    ListInfCadetes = new List<InformePersonal>();

}
    
}
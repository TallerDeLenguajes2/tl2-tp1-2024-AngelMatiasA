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
        public Cadete AltaPedido ( string pObs, string cNombre, string cDireccion, string cTel, string cDatRef){
            Cadete cadeteProvisorio = this.listadoCadetes.FirstOrDefault(p => p.Id == 1);

            Cadete cadeteAux = new Cadete();
            cadeteAux.AltaPedido(  pObs,  cNombre,  cDireccion,  cTel,  cDatRef);
            return  cadeteProvisorio;

            
        }

    }
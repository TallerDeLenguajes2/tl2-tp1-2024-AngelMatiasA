using System;
using System.Collections.Generic;
using System.IO;
using SCadeteria;

namespace SCadeteria;
public class AccesoCSV:AccesoADatos{
    
    public AccesoCSV(){

    }
    public static StreamReader ExisteCsv(string nombreArchivo){
        StreamReader archivoCsv = new StreamReader(File.OpenRead(@nombreArchivo));

        return  archivoCsv;

    }
    public override List<Cadete> cargarCadetes( string nombreArchivo){
        List<Cadete> cadetes = null;
        if(!ArchivoCargado(nombreArchivo)){
            return cadetes;
        }
        cadetes = new List<Cadete>();
        using( StreamReader lector = new StreamReader (nombreArchivo)){
            var primeraLinea = lector.ReadLine();
            while( !lector.EndOfStream){
                string linea = lector.ReadLine();
                string []? valores = linea.Split(';');
                Cadete nuevoCadete = new Cadete (valores[0], valores[1], valores[2]);
                cadetes.Add(nuevoCadete);
            }
        }
        return cadetes;
    } 
    public override Cadeteria cargarCadeteria( string nombreArchivo){
        Cadeteria cadeteria = null;
        if(!ArchivoCargado(nombreArchivo)) return cadeteria;
        using(StreamReader lector = new StreamReader(nombreArchivo)){
            string TiTuloFilasCsv = lector.ReadLine();
            
            string linea = lector.ReadLine();
            string []? valores = linea.Split(';');
            cadeteria = new Cadeteria(valores[0], valores[1]);

        }
            return cadeteria;


    }
    public void cargarPedidos(Cadeteria cadeteria, string nombreArchivo){
        StreamReader lectorArchivo = ExisteCsv( nombreArchivo);
        if(lectorArchivo != null){
          int id = 0;
            while(!lectorArchivo.EndOfStream){
                string linea = lectorArchivo.ReadLine();
                string []? valores = linea.Split(';');
                
                cadeteria.AltaPedido(valores[0], valores[1], valores[2], valores[3], valores[4], id);
            }

        }
       
    }

  
}

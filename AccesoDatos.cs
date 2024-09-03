using System;
using System.Collections.Generic;
using System.IO;
using SCadeteria;

namespace SCadeteria;
public class AccesoDatos{
    
    public AccesoDatos(){

    }
    public static StreamReader ExisteCsv(string nombreArchivo){
        StreamReader archivoCsv = new StreamReader(File.OpenRead(@nombreArchivo));

        return  archivoCsv;

    }
    public List<Cadete> cargarCadetes(Cadeteria cadeteria, string nombreArchivo){
        List<Cadete> cadetes = null;
        StreamReader lectorArchivo = ExisteCsv( nombreArchivo);
        if(lectorArchivo != null){
            string TiTuloFilasCsv = lectorArchivo.ReadLine();
            while(!lectorArchivo.EndOfStream){
                string linea = lectorArchivo.ReadLine();
                string []? valores = linea.Split(';');
                cadeteria.AltaCadete(valores[0], valores[1], valores[2]);
            }
            cadetes = cadeteria.listadoCadetes;

        }
        

        return cadetes;


    } public Cadeteria cargarCadeteria( string nombreArchivo){
        Cadeteria cadeteria = null;
        StreamReader lectorArchivo = ExisteCsv( nombreArchivo);
        if(lectorArchivo != null){
            string TiTuloFilasCsv = lectorArchivo.ReadLine();
            
            string linea = lectorArchivo.ReadLine();
            string []? valores = linea.Split(';');
            cadeteria = new Cadeteria(valores[0], valores[1]);
          

        }
        

        return cadeteria;


    }

}

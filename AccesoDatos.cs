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
            cadetes = cadeteria.ListadoCadetes;

        }
        return cadetes;
    } 
    public Cadeteria cargarCadeteria( string nombreArchivo){
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

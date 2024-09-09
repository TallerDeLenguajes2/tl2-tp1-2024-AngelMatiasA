using System;
using System.Collections.Generic;
using System.IO;
using SCadeteria;

namespace SCadeteria;
public abstract class AccesoADatos{
    
    public AccesoADatos(){

    }
    protected bool ArchivoCargado(string nombreArchivo){
        if(File.Exists(nombreArchivo)){
            using(var archivo = File.OpenRead(nombreArchivo)){
                if(archivo.Length > 0){
                    return true;
                }
                return false;

            }
        }
        return false;

    }
    
    public abstract Cadeteria cargarCadeteria( string nombreArchivo);
    public abstract List<Cadete> cargarCadetes( string nombreArchivo);
   

}

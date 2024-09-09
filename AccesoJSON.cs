using System;
using System.Text.Json;

namespace SCadeteria;
public class AccesoJSON : AccesoADatos
{
    public override Cadeteria cargarCadeteria(string nombreArchivo)
    {
        Cadeteria cadeteria = null; 
        if(!ArchivoCargado(nombreArchivo)) return cadeteria;
        using(var lector = new StreamReader(nombreArchivo))
            {
                var json = lector.ReadToEnd(); 
                cadeteria = JsonSerializer.Deserialize<Cadeteria>(json);
            }
    
        return cadeteria;
    }

    public override List<Cadete> cargarCadetes(string nombreArchivo)
    {
        List<Cadete> cadetes = null; 
        if(!ArchivoCargado(nombreArchivo)) return cadetes;
        using( StreamReader lector = new StreamReader(nombreArchivo)){
            var json = lector.ReadToEnd();
            cadetes = JsonSerializer.Deserialize<List<Cadete>>(json);
        }

        return cadetes;
        
    }
}
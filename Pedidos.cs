using System;

namespace Cadeteria;
public enum Estado{
    EnProceso,
    Entregado,
    Cancelado
}

    public class Pedidos
    {
       private static int nro; 
       private string observacion;
       private Cliente cliente;
       private Estado estado;


    public static int Nro { get => Nro; set => Nro = value; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Pedidos(){
        nro++;
    }
    public Pedidos(Estado estado, string pObs, string cNombre, string cDireccion, string cTel, string cDatRef ):this()
    {
        this.estado = estado;
        this.Observacion = pObs;
        this.cliente = new Cliente(cNombre, cDireccion, cTel, cDatRef);
    }
}
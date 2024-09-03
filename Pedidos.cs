using System;

namespace SCadeteria;
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


    public  int Nro { get => Nro; }
    public string Observacion { get => observacion; set => observacion = value; }
    public Cliente Cliente { get => cliente; set => cliente = value; }
    public Estado Estado { get => estado; set => estado = value; }
    public Pedidos(){
        nro++;
    }
      public Pedidos(string pObs, string cNombre, string cDireccion, string cTel, string cDatRef ):this()
    {
        this.estado = Estado.EnProceso;
        this.Observacion = pObs;
        this.cliente = new Cliente(cNombre, cDireccion, cTel, cDatRef);
    }
    public Pedidos(Estado estado, string pObs, string cNombre, string cDireccion, string cTel, string cDatRef ):this()
    {
        this.estado = estado;
        this.Observacion = pObs;
        this.cliente = new Cliente(cNombre, cDireccion, cTel, cDatRef);
    }
    public void VerDireccionCliente(){
        Console.WriteLine(cliente.Direccion);
    }
    public void VerDatosCliente(){
        Console.WriteLine(cliente.DatosReferenciaDireccion);
    }
    public void ModificarEstado (Estado estado){
        this.estado = estado;
    }
}
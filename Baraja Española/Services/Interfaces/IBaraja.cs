namespace Baraja_Española.Services.Interfaces
{
    public interface IBaraja
    {
        public void InicializarNaipes();
        public void Ordenar();
        public void Barajar();
        public void Imprimir();
        public void GuardarEnArchivo(string rutaArchivo);
        public void LeerDesdeArchivo(string rutaArchivo);
    }
}

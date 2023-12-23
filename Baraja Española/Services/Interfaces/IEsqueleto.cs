namespace Baraja_Española.Services.Interfaces
{
    public interface IEsqueleto
    {
        public void CargarInformacion(int indice, string nombre, double peso, double densidad, double longitud, double diametro);
        public void OrdenarEImprimir(string criterio);
        public void GuardarEnArchivo(Esqueleto esqueleto);
        public void CargarDesdeArchivo(string filePath);
    }
}

namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IIdioma
    {
        string MensajeListaVacia();
        string Encabezado();
        string TraducirForma(string forma, int cantidad);
        string Linea(string nombre, int cantidad, double area, double perimetro);
        string Pie(int totalFormas, double totalArea, double totalPerimetro);
    }
}

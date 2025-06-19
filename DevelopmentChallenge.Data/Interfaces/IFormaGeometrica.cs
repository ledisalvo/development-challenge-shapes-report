namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        double CalcularArea();
        double CalcularPerimetro();
        string ObtenerNombre(IIdioma idioma, int cantidad);
    }
}

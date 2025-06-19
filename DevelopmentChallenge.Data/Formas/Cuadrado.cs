using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Formas
{
    public class Cuadrado : IFormaGeometrica
    {
        public double Lado { get; set; }
        public Cuadrado(double lado) { Lado = lado; }
        public double CalcularArea() { return Lado * Lado; }
        public double CalcularPerimetro() { return 4 * Lado; }
        public string ObtenerNombre(IIdioma idioma, int cantidad) => idioma.TraducirForma("Cuadrado", cantidad);
    }
}

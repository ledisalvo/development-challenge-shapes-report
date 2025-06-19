using System;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Formas
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        public double Lado { get; set; }
        public TrianguloEquilatero(double lado) 
        {
            if (lado <= 0)
            {
                throw new ArgumentException("La longitud del lado debe ser un valor positivo.");
            }
            Lado = lado; 
        }
        public double CalcularArea() { return (Math.Sqrt(3) / 4) * Math.Pow(Lado, 2); }
        public double CalcularPerimetro() { return 3 * Lado; }

        public string ObtenerNombre(IIdioma idioma, int cantidad) => idioma.TraducirForma("Triángulo", cantidad);
    }
}

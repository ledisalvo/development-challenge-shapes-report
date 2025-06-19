using System;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Formas
{
    public class Circulo : IFormaGeometrica
    {
        public double Lado { get; set; }
        public Circulo(double lado) { Lado = lado; }
        public double CalcularArea() { return Math.PI * (Lado/2) * (Lado/2); }
        public double CalcularPerimetro() { return 2 * Math.PI * (Lado/2); }
        public string ObtenerNombre(IIdioma idioma, int cantidad) => idioma.TraducirForma("Círculo", cantidad);
    }

}

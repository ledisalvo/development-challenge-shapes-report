using System;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Formas
{
    public class TrapecioBase : IFormaGeometrica
    {
        //Propiedades comunes a todos los trapecios
        public double Base1 { get; }
        public double Base2 { get; }
        public double Altura { get; }

        //Lados no paralelos
        public double Lado3 { get; set; }
        public double Lado4 { get; set; } // Asumiendo que el lado 4 es igual al lado 3 para un trapecio isósceles

        public TrapecioBase(double base1, double base2, double lado3, double lado4, double altura)
        {
            // Validaciones básicas para asegurar que las medidas son positivas
            if (base1 <= 0 || base2 <= 0 || altura <= 0 || lado3 < 0 || lado4 < 0)
            {
                throw new ArgumentException("Todas las medidas deben ser valores positivos.");
            }

            Base1 = base1;
            Base2 = base2;
            Lado3 = lado3;
            Lado4 = lado4;
            Altura = altura;
        }

        /// <summary>
        /// Calcula el área de cualquier trapecio.
        /// Esta implementación es común para todas las clases derivadas.
        /// </summary>
        public double CalcularArea() => 0.5 * (Base1 + Base2) * Altura;

        /// <summary>
        /// Calcula el perímetro de un trapecio general (escaleno).
        /// Este método es 'virtual' para que las clases derivadas puedan sobrescribirlo.
        /// </summary>
        public virtual double CalcularPerimetro() => Base1 + Base2 + Lado3 + Lado4;

        public virtual string ObtenerNombre(IIdioma idioma, int cantidad) => idioma.TraducirForma("Trapecio", cantidad);
    }
}

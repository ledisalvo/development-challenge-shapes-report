using System;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Formas
{
    public class TrapecioIsosceles : TrapecioBase
    {
        /// <summary>
        /// Constructor para un Trapecio Isósceles.
        /// Los dos lados no paralelos son iguales.
        /// </summary>
        /// <param name="base1">Longitud de la primera base.</param>
        /// <param name="base2">Longitud de la segunda base.</param>
        /// <param name="ladoNoParalelo">Longitud de uno de los lados no paralelos (ambos son iguales).</param> 
        /// <param name="altura">Altura del trapecio.</param>
        public TrapecioIsosceles(double base1, double base2, double ladoNoParalelo, double altura)
            : base(base1, base2, ladoNoParalelo, ladoNoParalelo, altura)
        { }

        /// <summary>
        /// Constructor para un Trapecio Isósceles cuando no se conoce el lado no paralelo,
        /// pero se puede calcular a partir de las bases y la altura.
        /// </summary>
        public TrapecioIsosceles(double base1, double base2, double altura)
        : base(base1, base2, 0, 0, altura) // Inicializamos lados en 0, se recalcularán
        {

            // Calcula el lado no paralelo usando el Teorema de Pitágoras
            double diferenciaBases = Math.Abs(base1 - base2);
            double proyeccion = diferenciaBases / 2.0;

            // a^2 + b^2 = c^2, donde c es el ladoNoParalelo
            Lado3 = Math.Sqrt(Math.Pow(altura, 2) + Math.Pow(proyeccion, 2));
            Lado4 = Lado3; // Ambos lados no paralelos son iguales
        }

        /// <summary>
        /// Sobrescribe el método CalcularPerimetro de la clase base para la lógica de un trapecio isósceles.
        /// </summary>
        public override double CalcularPerimetro()
        {
            // En un isósceles, Lado3 y Lado4 ya son iguales
            return Base1 + Base2 + (2 * Lado3);
        }
        
        public override string ObtenerNombre(IIdioma idioma, int cantidad) => idioma.TraducirForma("Trapecio", cantidad);
    }
}

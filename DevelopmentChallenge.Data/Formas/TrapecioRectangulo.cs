using System;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Formas
{
    public class TrapecioRectangulo : TrapecioBase
    {
        /// <summary>
        /// Constructor para un Trapecio Rectángulo.
        /// Uno de los lados no paralelos es la altura.
        /// </summary>
        /// <param name="base1">Longitud de la primera base.</param>
        /// <param name="base2">Longitud de la segunda base.</param>
        /// <param name="ladoOblicuo">Longitud del lado no paralelo que no es la altura.</param>
        /// <param name="altura">Altura del trapecio (también uno de los lados no paralelos).</param>
        public TrapecioRectangulo(double base1, double base2, double ladoOblicuo, double altura) 
            : base(base1, base2, ladoOblicuo, altura, altura) // Un lado no paralelo es la altura
        { }

        /// <summary>
        /// Constructor para un Trapecio Rectángulo cuando no se conoce el lado oblicuo,
        /// pero se puede calcular a partir de las bases y la altura.
        /// </summary>
        public TrapecioRectangulo(double base1, double base2, double altura)
            : base(base1, base2, 0, 0, altura) // Inicializamos lados en 0, se recalcularán
        {
            // Calcula el lado oblicuo usando el Teorema de Pitágoras
            // La base del triángulo rectángulo es la diferencia absoluta de las bases
            double diferenciaBases = Math.Abs(base1 - base2);

            // a^2 + b^2 = c^2, donde c es el ladoOblicuo
            Lado4 = Math.Sqrt(Math.Pow(altura, 2) + Math.Pow(diferenciaBases, 2));
            Lado3 = altura; // El otro lado no paralelo es la altura
        }

        /// <summary>
        /// Sobrescribe el método CalcularPerimetro de la clase base para la lógica de un trapecio rectángulo.
        /// </summary>
        public override double CalcularPerimetro()
        {
            // En un trapecio rectángulo, un lado no paralelo es la altura (Lado3) y el otro es el lado oblicuo (Lado4).
            return Base1 + Base2 + Lado3 + Lado4;
        }
        
        public override string ObtenerNombre(IIdioma idioma, int cantidad) => idioma.TraducirForma("Trapecio", cantidad);
    }
}

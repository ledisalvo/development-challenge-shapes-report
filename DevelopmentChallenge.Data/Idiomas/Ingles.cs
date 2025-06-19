using System.Collections.Generic;
using DevelopmentChallenge.Data.Interfaces;
using System.Globalization;

namespace DevelopmentChallenge.Data
{
    public class Ingles : IIdioma
    {
        private static readonly Dictionary<string, (string singular, string plural)> _traducciones = new Dictionary<string, (string singular, string plural)>()
        {
            { "Cuadrado", ("Square", "Squares") },
            { "Círculo", ("Circle", "Circles") },
            { "Triángulo", ("Triangle", "Triangles") },
            { "Trapecio", ("Trapezoid", "Trapezoids") },
        };

        public string MensajeListaVacia() => "Empty list of shapes!";

        public string TraducirForma(string forma, int cantidad)
        {
            if (_traducciones.TryGetValue(forma, out var traduccion))
                return cantidad == 1 ? traduccion.singular : traduccion.plural;

            // fallback si no está en el diccionario
            return cantidad == 1 ? forma : forma + "s";
        }
        public string Encabezado() => "Shapes report";

        public string Linea(string nombre, int cantidad, double area, double perimetro)
        {
            return $"{cantidad} {nombre} | Area {area.ToString("0.##", CultureInfo.InvariantCulture)} | Perimeter {perimetro.ToString("0.##", CultureInfo.InvariantCulture)} <br/>\n";
        }

        public string Pie(int totalFormas, double totalArea, double totalPerimetro)
        {
            return $"TOTAL:<br/>{totalFormas} shapes | Area {totalArea.ToString("0.##", CultureInfo.InvariantCulture)} | Perimeter {totalPerimetro.ToString("0.##", CultureInfo.InvariantCulture)}";
        }
    }
}

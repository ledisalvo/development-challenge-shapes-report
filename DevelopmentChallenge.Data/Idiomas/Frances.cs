using System.Collections.Generic;
using DevelopmentChallenge.Data.Interfaces;
using System.Globalization;

namespace DevelopmentChallenge.Data
{
    public class Frances : IIdioma
    {
        private static readonly Dictionary<string, (string singular, string plural)> _traducciones = new Dictionary<string, (string singular, string plural)>()
        {
            { "Cuadrado", ("Carré", "Carrés") },
            { "Círculo", ("Cercle", "Cercles") },
            { "Triángulo", ("Triangle", "Triangles") },
            { "Trapecio", ("Trapèze", "Trapèzes") },
        };

        public string MensajeListaVacia() => "Liste vide de formes!";

        public string TraducirForma(string forma, int cantidad)
        {
            if (_traducciones.TryGetValue(forma, out var traduccion))
                return cantidad == 1 ? traduccion.singular : traduccion.plural;

            // fallback si no está en el diccionario
            return cantidad == 1 ? forma : forma + "s";
        }
        public string Encabezado() => "Rapport de formes";

        public string Linea(string nombre, int cantidad, double area, double perimetro)
        {
            return $"{cantidad} {nombre} | Aire {area.ToString("0.##", CultureInfo.InvariantCulture)} | Périmètre {perimetro.ToString("0.##", CultureInfo.InvariantCulture)} <br/>\n";
        }

        public string Pie(int totalFormas, double totalArea, double totalPerimetro)
        {
            return $"TOTAL:<br/>{totalFormas} formes | Aire {totalArea.ToString("0.##", CultureInfo.InvariantCulture)} | Périmètre {totalPerimetro.ToString("0.##", CultureInfo.InvariantCulture)}";
        }
    }
}

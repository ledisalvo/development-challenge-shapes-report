using System.Collections.Generic;
using DevelopmentChallenge.Data.Interfaces;
using System.Globalization;

namespace DevelopmentChallenge.Data
{
    public class Italiano : IIdioma
    {
        private static readonly Dictionary<string, (string singular, string plural)> _traducciones = new Dictionary<string, (string singular, string plural)>()
        {
            { "Cuadrado", ("Quadrato", "Quadrati") },
            { "Círculo", ("Cerchio", "Cerchi") },
            { "Triángulo", ("Triangolo", "Triangoli") },
            //{ "Trapecio", ("Trapezio", "Trapezi") }, A efectos de armar un test que haga fallback si no aparece traducida esa forma, se comenta esta línea
        };

        public string MensajeListaVacia() => "Lista vuota di forme!";

        public string TraducirForma(string forma, int cantidad)
        {
            if (_traducciones.TryGetValue(forma, out var traduccion))
                return cantidad == 1 ? traduccion.singular : traduccion.plural;

            // fallback si no está en el diccionario
            return cantidad == 1 ? forma : forma + "s";
        }
        public string Encabezado() => "Report delle forme";

        public string Linea(string nombre, int cantidad, double area, double perimetro)
        {
            return $"{cantidad} {nombre} | Area {area.ToString("0.##", CultureInfo.InvariantCulture)} | Perimetro {perimetro.ToString("0.##", CultureInfo.InvariantCulture)} <br/>\n";
        }

        public string Pie(int totalFormas, double totalArea, double totalPerimetro)
        {
            return $"TOTALE:<br/>{totalFormas} formes | Area {totalArea.ToString("0.##", CultureInfo.InvariantCulture)} | Perimetro {totalPerimetro.ToString("0.##", CultureInfo.InvariantCulture)}";
        }
    }
}

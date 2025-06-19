using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data.Reportes
{
    public static class ReporteFormas
    {
        public static string Imprimir(List<IFormaGeometrica> formas, IIdioma idioma)
        {
            if (formas == null || !formas.Any())
                return $"<h1>{idioma.MensajeListaVacia()}</h1>";

            var sb = new StringBuilder();
            sb.Append($"<h1>{idioma.Encabezado()}</h1>\n");

            var resumen = formas
                .GroupBy(f => f.ObtenerNombre(idioma, formas.Count()))
                .Select(g => new
                {
                    Nombre = g.Key,
                    Cantidad = g.Count(),
                    Area = g.Sum(f => f.CalcularArea()),
                    Perimetro = g.Sum(f => f.CalcularPerimetro())
                });

            int totalFormas = 0;
            double totalArea = 0, totalPerimetro = 0;

            foreach (var r in resumen)
            {
                sb.Append(idioma.Linea(r.Nombre, r.Cantidad, r.Area, r.Perimetro));
                totalFormas += r.Cantidad;
                totalArea += r.Area;
                totalPerimetro += r.Perimetro;
            }

            sb.Append(idioma.Pie(totalFormas, totalArea, totalPerimetro));
            return sb.ToString().Trim();
        }
    }
}

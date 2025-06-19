using DevelopmentChallenge.Data.Interfaces;

namespace DevelopmentChallenge.Data
{
    public class Castellano : IIdioma
    {
        public string MensajeListaVacia() => "Lista vacía de formas!";
        public string Encabezado() => "Reporte de Formas";

        public string TraducirForma(string forma, int cantidad)
        {
            return cantidad == 1 ? forma : forma + "s";
        }

        public string Linea(string nombre, int cantidad, double area, double perimetro)
        {
            return $"{cantidad} {nombre} | Area {area:#.##} | Perímetro {perimetro:#.##} <br/>\n";
        }

        public string Pie(int totalFormas, double totalArea, double totalPerimetro)
        {
            return $"TOTAL:<br/>{totalFormas} formas | Area {totalArea:#.##} | Perímetro {totalPerimetro:#.##}";
        }
    }
}

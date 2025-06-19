using System.Collections.Generic;
using DevelopmentChallenge.Data.Formas;
using DevelopmentChallenge.Data.Interfaces;
using DevelopmentChallenge.Data.Reportes;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase]
        public void TestResumenListaVacia()
        {
            var idioma = new Castellano();
            var formas = new List<IFormaGeometrica>();
            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", resultado);
        }

        [TestCase]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            var idioma = new Ingles();
            var formas = new List<IFormaGeometrica>();
            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.AreEqual("<h1>Empty list of shapes!</h1>", resultado);
        }

        [TestCase]
        public void TestResumenListaConUnCuadrado()
        {
            var idioma = new Castellano();
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5)
            };
            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>\n1 Cuadrado | Area 25 | Perímetro 20 <br/>\nTOTAL:<br/>1 formas | Area 25 | Perímetro 20",
                resultado);
        }

        [TestCase]
        public void TestResumenListaConMasCuadrados()
        {
            var idioma = new Ingles();
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3)
            };
            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.AreEqual(
                "<h1>Shapes report</h1>\n3 Squares | Area 35 | Perimeter 36 <br/>\nTOTAL:<br/>3 shapes | Area 35 | Perimeter 36",
                resultado);
        }

        [TestCase]
        public void TestResumenListaConMasTipos()
        {
            var idioma = new Ingles();
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2)
            };
            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.AreEqual(
                "<h1>Shapes report</h1>\n2 Squares | Area 29 | Perimeter 28 <br/>\n2 Circles | Area 13.01 | Perimeter 18.06 <br/>\n3 Triangles | Area 49.64 | Perimeter 51.6 <br/>\nTOTAL:<br/>7 shapes | Area 91.65 | Perimeter 97.66",
                resultado);
        }

        [TestCase]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            var idioma = new Castellano();
            var formas = new List<IFormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75),
                new TrianguloEquilatero(4.2)
            };
            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.AreEqual(
                "<h1>Reporte de Formas</h1>\n2 Cuadrados | Area 29 | Perímetro 28 <br/>\n2 Círculos | Area 13,01 | Perímetro 18,06 <br/>\n3 Triángulos | Area 49,64 | Perímetro 51,6 <br/>\nTOTAL:<br/>7 formas | Area 91,65 | Perímetro 97,66",
                resultado);
        }

        /// <summary>
        ///  Test con múltiples formas en diferentes cantidades
        ///  Para verificar pluralización y suma correcta
        /// </summary>
        [Test]
        public void TestTresCirculosDosCuadradosUnTrianguloEnFrances()
        {
            var idioma = new Frances();
            var formas = new List<IFormaGeometrica>
            {
                new Circulo(1),
                new Circulo(2),
                new Circulo(3),
                new Cuadrado(2),
                new Cuadrado(4),
                new TrianguloEquilatero(5)
            };

            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.IsTrue(resultado.Contains("3 Cercles"));
            Assert.IsTrue(resultado.Contains("2 Carrés"));
            Assert.IsTrue(resultado.Contains("1 Triangle"));
        }

        /// <summary>
        /// Test con un idioma nuevo que aún no tiene todas las traducciones
        /// Para verificar fallback (forma + "s" o forma sin traducir):
        /// </summary>
        [Test]
        public void TestIdiomaIncompletoHaceFallback()
        {
            var idioma = new Italiano(); // Asumimos que "Trapecio" no está traducido aún
            var formas = new List<IFormaGeometrica> { new TrapecioRectangulo(4, 2, 3) };

            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.IsTrue(resultado.Contains("1 Trapecio")); // fallback, ya que "Trapecio" no está en el diccionario de traducciones
        }

        /// <summary>
        /// Test de precisión decimal
        /// Asegurar que el redondeo sea correcto en cada idioma
        /// </summary>
        [Test]
        public void TestPrecisionDecimalEnIngles()
        {
            var idioma = new Ingles();
            var formas = new List<IFormaGeometrica>
            {
                new Circulo(1.1234) // Asegura decimales largos
            };

            var resultado = ReporteFormas.Imprimir(formas, idioma);

            Assert.IsTrue(resultado.Contains("Area"));
            Assert.IsFalse(resultado.Contains(",")); // Asegura que no haya coma
        }

        /// <summary>
        /// Test de lista vacía en todos los idiomas
        /// Para validar que el mensaje cambia por idioma:
        /// </summary>
        /// <param name="idioma"></param>
        /// <param name="esperado"></param>
        [TestCaseSource(nameof(Idiomas))]
        public void TestListaVaciaConTodosLosIdiomas(IIdioma idioma, string esperado)
        {
            var resultado = ReporteFormas.Imprimir(new List<IFormaGeometrica>(), idioma);
            Assert.AreEqual($"<h1>{esperado}</h1>", resultado);
        }

        private static IEnumerable<TestCaseData> Idiomas()
        {
            yield return new TestCaseData(new Castellano(), "Lista vacía de formas!");
            yield return new TestCaseData(new Ingles(), "Empty list of shapes!");
            yield return new TestCaseData(new Frances(), "Liste vide de formes!"); 
            yield return new TestCaseData(new Italiano(), "Lista vuota di forme!");
        }
    }
}

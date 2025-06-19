# Challenge Técnico – Reporte de Formas Geométricas

Este repositorio contiene la solución al desafío técnico que consiste en refactorizar un sistema que genera un reporte multilingüe a partir de una lista de formas geométricas. El objetivo fue mejorar la extensibilidad, mantenibilidad y calidad del código, aplicando principios de programación orientada a objetos y buenas prácticas de testing.

---

## 🧠 Objetivos del desafío

- Refactorizar la clase `FormaGeometrica` para respetar principios SOLID.
- Soportar fácilmente la incorporación de nuevos idiomas y nuevas formas geométricas.
- Implementar la figura *Trapecio*.
- Agregar al menos un idioma adicional (se implementaron **Francés** e **Italiano**).
- Asegurar cobertura con **tests unitarios automáticos**.

---

## 🧱 Arquitectura propuesta

Se aplicaron los siguientes principios y patrones:

- **Responsabilidad Única (SRP):** Cada clase tiene una única función (forma, idioma, o reporte).
- **Open/Closed (OCP):** El sistema permite agregar nuevos idiomas y formas sin modificar código existente.
- **Polimorfismo:** Cada figura implementa la interfaz `IFormaGeometrica` y conoce su lógica de cálculo.
- **Inyección de Comportamiento por Idioma:** Cada idioma implementa `IIdioma`, con su propia lógica de traducción y formato.

---

## 📦 Estructura del proyecto

- `DevelopmentChallenge.Data`: contiene las clases de formas (`Cuadrado`, `Círculo`, etc.), interfaces (`IFormaGeometrica`, `IIdioma`) y la lógica de generación de reportes.
- `DevelopmentChallenge.Data.Tests`: contiene los **tests unitarios con NUnit**, cubriendo distintos idiomas, figuras y escenarios.
- `ReporteFormas.cs`: clase encargada de procesar las formas y generar el reporte final.
- Idiomas implementados: Español (default), Inglés, Francés, Italiano.

---

## ✅ Funcionalidades implementadas

- ✔️ Refactor de clase `FormaGeometrica` a clases polimórficas
- ✔️ Cálculo de área y perímetro para Cuadrado, Círculo, Triángulo Equilátero y Trapecio Rectángulo
- ✔️ Internacionalización del reporte en 4 idiomas
- ✔️ Traducción singular/plural de cada figura
- ✔️ Separación clara de responsabilidades
- ✔️ Formato numérico correcto por idioma (`18.06` en inglés, `18,06` en español)
- ✔️ Cobertura completa con **tests automatizados**

---

## 🧪 Tests avanzados incluidos

- 🧠 Pluralización y traducción en múltiples idiomas
- 🧪 Precisión decimal con validación de formatos
- 💬 Traducción con tildes y caracteres especiales
- 🕵️‍♂️ Escenarios con formas sin traducción como fallback
- 📝 Test parametrizados con múltiples idiomas

---

## 💡 Ideas futuras de mejora

- 🔄 Cargar traducciones desde archivo JSON o base de datos (estilo i18n real)
- 🧠 Integrar alguna API de IA para que traduzca automaticamente sin necesidad de depender de una actualización constante de la base de datos o de un archivo
- 🖼️ Exportar el reporte en HTML o PDF
- 🌐 Incluir una interfaz web con Blazor o React para cargar formas y ver resultados mejorando la experiencia del usuario
- 🔍 Agregar métricas de performance (ej: procesar 10.000 figuras)
---

## 🧰 Requisitos técnicos

- Visual Studio 2019 o superior
- .NET Framework 4.6.2
- NUnit 3.12.0
- Microsoft.NET.Test.Sdk 16.5.0
- NUnit3TestAdapter 3.16.1

---

## 🚀 ¿Cómo ejecutar?

1. Clonar el repositorio:
   ```bash
   git clone https://github.com/tuusuario/development-challenge-shapes-report.git

2. Abrir DevelopmentChallenge.sln en Visual Studio.

3. Restaurar paquetes NuGet.

4. Ejecutar los tests desde el Test Explorer.

## ✉️ Contacto

Podés escribirme por [LinkedIn](https://www.linkedin.com/in/leonardo-di-salvo/) o enviarme un [mail](mailto:ledisalvo@gmail.com) si querés conocer más sobre cómo fue el proceso o discutir mejoras.
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readifly.Domain.Entities;

namespace Readifly.UnitTests.Domain.Entities
{
    [TestClass]
    public class LibroTests
    {
        [TestMethod]
        public void CrearLibro_ConDatosValidos_DebeCrearLibroCorrectamente()
        {
            // Arrange
            var isbn = "978-0-123456-78-9";
            var nombre = "El Quijote";
            var autor = "Miguel de Cervantes";
            var numeroPaginas = 863;
            var editorial = "Editorial Castalia";
            var anioPublicacion = 1605;

            // Act
            var libro = new Libro(isbn, nombre, autor, numeroPaginas, editorial, anioPublicacion);

            // Assert
            libro.ISBN.Should().Be(isbn);
            libro.Nombre.Should().Be(nombre);
            libro.Autor.Should().Be(autor);
            libro.NumeroPaginas.Should().Be(numeroPaginas);
            libro.Editorial.Should().Be(editorial);
            libro.AnioPublicacion.Should().Be(anioPublicacion);
            libro.EstaPrestado.Should().BeFalse();
        }

        [TestMethod]
        public void CrearLibro_ConAutorVacio_DebeLanzarExcepcion()
        {
            // Arrange
            var isbn = "978-0-123456-78-9";
            var nombre = "El Quijote";
            var autor = "";
            var numeroPaginas = 863;
            var editorial = "Editorial Castalia";
            var anioPublicacion = 1605;

            // Act & Assert
            var action = () => new Libro(isbn, nombre, autor, numeroPaginas, editorial, anioPublicacion);
            action.Should().Throw<ArgumentException>()
                .WithMessage("El autor no puede estar vacío*");
        }

        [TestMethod]
        public void CalcularDiasPrestamo_ConSumaDígitosMayorA30_DebeRetornar15Dias()
        {
            // Arrange
            var isbn = "978-0-123456-78-9"; // Suma: 9+7+8+0+1+2+3+4+5+6+7+8+9 = 69 > 30
            var libro = new Libro(isbn, "Test Book", "Test Author", 100, "Test Editorial", 2023);

            // Act
            var diasPrestamo = libro.CalcularDiasPrestamo();

            // Assert
            diasPrestamo.Should().Be(15);
        }

        [TestMethod]
        public void CalcularDiasPrestamo_ConSumaDígitosMenorOIgualA30_DebeRetornar10Dias()
        {
            // Arrange
            var isbn = "978-0-123456-78-1"; // Suma: 9+7+8+0+1+2+3+4+5+6+7+8+1 = 61 > 30, pero usemos uno menor
            var libro = new Libro("111-1-111111-11-1", "Test Book", "Test Author", 100, "Test Editorial", 2023); // Suma: 1+1+1+1+1+1+1+1+1+1+1+1+1 = 13 < 30

            // Act
            var diasPrestamo = libro.CalcularDiasPrestamo();

            // Assert
            diasPrestamo.Should().Be(10);
        }
    }
}

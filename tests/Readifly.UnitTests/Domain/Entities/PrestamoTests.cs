using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readifly.Domain.Entities;
using Readifly.Domain.Extensions;

namespace Readifly.UnitTests.Domain.Entities
{
    [TestClass]
    public class PrestamoTests
    {
        [TestMethod]
        public void CrearPrestamo_ConMaterialValido_DebeCrearPrestamoCorrectamente()
        {
            // Arrange
            var libro = new Libro("978-0-123456-78-9", "Test Book", "Test Author", 100, "Test Editorial", 2023);
            var usuarioId = "user123";

            // Act
            var prestamo = Prestamo.CrearPrestamo(libro, usuarioId);

            // Assert
            prestamo.ISBN.Should().Be(libro.ISBN);
            prestamo.UsuarioId.Should().Be(usuarioId);
            prestamo.FechaPrestamo.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
            prestamo.FechaDevolucionProgramada.Should().BeAfter(prestamo.FechaPrestamo);
            prestamo.FechaDevolucionReal.Should().BeNull();
            libro.EstaPrestado.Should().BeTrue();
        }

        [TestMethod]
        public void CrearPrestamo_ConMaterialYaPrestado_DebeLanzarExcepcion()
        {
            // Arrange
            var libro = new Libro("978-0-123456-78-9", "Test Book", "Test Author", 100, "Test Editorial", 2023);
            libro.MarcarComoPrestado(); // Marcar como prestado
            var usuarioId = "user123";

            // Act & Assert
            var action = () => Prestamo.CrearPrestamo(libro, usuarioId);
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("El material ya está prestado");
        }

        [TestMethod]
        public void CrearPrestamo_ConIsbnPalindromo_DebeLanzarExcepcion()
        {
            // Arrange
            var isbnPalindromo = "123-4-567-8-765-4-321";
            var libro = new Libro(isbnPalindromo, "Test Book", "Test Author", 100, "Test Editorial", 2023);
            var usuarioId = "user123";

            // Act & Assert
            var action = () => Prestamo.CrearPrestamo(libro, usuarioId);
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("No se puede prestar material con ISBN palíndromo");
        }

        [TestMethod]
        public void CrearPrestamo_ConRevista_DebeCalcularFechaDevolucionCorrecta()
        {
            // Arrange
            var revista = new Revista("977-1234567890-12", "Test Revista", "Test Editorial", 1, 2024, DateTime.Now.AddDays(-30));
            var usuarioId = "user123";

            // Act
            var prestamo = Prestamo.CrearPrestamo(revista, usuarioId);

            // Assert
            var fechaEsperada = DateTime.Now.AddDays(Revista.DiasPrestamo);
            prestamo.FechaDevolucionProgramada.Should().BeCloseTo(fechaEsperada, TimeSpan.FromMinutes(1));
        }

        [TestMethod]
        public void RegistrarDevolucion_ConPrestamoValido_DebeRegistrarDevolucion()
        {
            // Arrange
            var libro = new Libro("978-0-123456-78-9", "Test Book", "Test Author", 100, "Test Editorial", 2023);
            var prestamo = Prestamo.CrearPrestamo(libro, "user123");

            // Act
            prestamo.RegistrarDevolucion();

            // Assert
            prestamo.FechaDevolucionReal.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMinutes(1));
        }

        [TestMethod]
        public void RegistrarDevolucion_ConPrestamoYaDevuelto_DebeLanzarExcepcion()
        {
            // Arrange
            var libro = new Libro("978-0-123456-78-9", "Test Book", "Test Author", 100, "Test Editorial", 2023);
            var prestamo = Prestamo.CrearPrestamo(libro, "user123");
            prestamo.RegistrarDevolucion(); // Primera devolución

            // Act & Assert
            var action = () => prestamo.RegistrarDevolucion();
            action.Should().Throw<InvalidOperationException>()
                .WithMessage("El préstamo ya fue devuelto");
        }
    }
}

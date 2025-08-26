using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Readifly.Domain.Extensions;

namespace Readifly.UnitTests.Domain.Extensions
{
    [TestClass]
    public class IsbnExtensionsTests
    {
        [TestMethod]
        public void EsPalindromo_ConIsbnPalindromo_DebeRetornarTrue()
        {
            // Arrange
            var isbnPalindromo = "123-4-567-8-765-4-321";

            // Act
            var resultado = isbnPalindromo.EsPalindromo();

            // Assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void EsPalindromo_ConIsbnNoPalindromo_DebeRetornarFalse()
        {
            // Arrange
            var isbnNoPalindromo = "978-0-123456-78-9";

            // Act
            var resultado = isbnNoPalindromo.EsPalindromo();

            // Assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void EsPalindromo_ConStringVacio_DebeRetornarFalse()
        {
            // Arrange
            var isbnVacio = "";

            // Act
            var resultado = isbnVacio.EsPalindromo();

            // Assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void EsPalindromo_ConStringNull_DebeRetornarFalse()
        {
            // Arrange
            string? isbnNull = null;

            // Act
            var resultado = isbnNull.EsPalindromo();

            // Assert
            resultado.Should().BeFalse();
        }

        [TestMethod]
        public void EsPalindromo_ConSoloUnDigito_DebeRetornarTrue()
        {
            // Arrange
            var isbnUnDigito = "1";

            // Act
            var resultado = isbnUnDigito.EsPalindromo();

            // Assert
            resultado.Should().BeTrue();
        }

        [TestMethod]
        public void EsPalindromo_ConIsbnConGuiones_DebeIgnorarGuiones()
        {
            // Arrange
            var isbnConGuiones = "1-2-3-2-1";

            // Act
            var resultado = isbnConGuiones.EsPalindromo();

            // Assert
            resultado.Should().BeTrue();
        }
    }
}

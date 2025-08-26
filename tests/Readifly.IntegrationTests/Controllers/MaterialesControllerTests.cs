using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Readifly.IntegrationTests.Controllers
{
    [TestClass]
    public class MaterialesControllerTests
    {
        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;

        [TestInitialize]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [TestMethod]
        public async Task GetMateriales_DebeRetornarListaVacia()
        {
            // Act
            var response = await _client.GetAsync("/api/materiales");

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            var content = await response.Content.ReadAsStringAsync();
            content.Should().Be("[]");
        }

        [TestMethod]
        public async Task CrearLibro_ConDatosValidos_DebeCrearLibro()
        {
            // Arrange
            var libro = new
            {
                ISBN = "978-0-123456-78-9",
                Nombre = "El Quijote",
                Autor = "Miguel de Cervantes",
                NumeroPaginas = 863,
                Editorial = "Editorial Castalia",
                AnioPublicacion = 1605
            };

            var json = JsonSerializer.Serialize(libro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/materiales/libros", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var responseContent = await response.Content.ReadAsStringAsync();
            responseContent.Should().Contain(libro.ISBN);
            responseContent.Should().Contain(libro.Nombre);
        }

        [TestMethod]
        public async Task CrearLibro_ConDatosInvalidos_DebeRetornarBadRequest()
        {
            // Arrange
            var libro = new
            {
                ISBN = "", // ISBN vacío
                Nombre = "Test Book",
                Autor = "Test Author",
                NumeroPaginas = 100,
                Editorial = "Test Editorial",
                AnioPublicacion = 2023
            };

            var json = JsonSerializer.Serialize(libro);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/materiales/libros", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public async Task CrearRevista_ConDatosValidos_DebeCrearRevista()
        {
            // Arrange
            var revista = new
            {
                ISBN = "977-1234567890-12",
                Nombre = "National Geographic",
                Editorial = "National Geographic Society",
                Numero = 1,
                Volumen = 2024,
                FechaPublicacion = DateTime.Now.AddDays(-30)
            };

            var json = JsonSerializer.Serialize(revista);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Act
            var response = await _client.PostAsync("/api/materiales/revistas", content);

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            var responseContent = await response.Content.ReadAsStringAsync();
            responseContent.Should().Contain(revista.ISBN);
            responseContent.Should().Contain(revista.Nombre);
        }
    }
}

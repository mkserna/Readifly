using Readifly.Application.Common.Interfaces;
using Readifly.Domain.Entities;
using Readifly.Domain.Interfaces;
using Readifly.Domain.Services;

namespace Readifly.Infrastructure.Services
{
    public class PrestamoService : IServicioPrestamo
    {
        private readonly IRepositorioMaterialBibliografico _materialRepository;
        private readonly IRepositorioPrestamo _prestamoRepository;

        public PrestamoService(
            IRepositorioMaterialBibliografico materialRepository,
            IRepositorioPrestamo prestamoRepository)
        {
            _materialRepository = materialRepository;
            _prestamoRepository = prestamoRepository;
        }

        public async Task<Prestamo> RealizarPrestamoAsync(string isbn, string usuarioId)
        {
            var material = await _materialRepository.ObtenerPorIsbnAsync(isbn);
            if (material == null)
            {
                throw new ArgumentException("Material no encontrado");
            }

            var prestamo = Prestamo.CrearPrestamo(material, usuarioId);

            await _prestamoRepository.AgregarAsync(prestamo);
            await _materialRepository.ActualizarAsync(material);

            return prestamo;
        }

        public async Task RegistrarDevolucionAsync(int prestamoId)
        {
            var prestamo = await _prestamoRepository.ObtenerPorIdAsync(prestamoId);
            if (prestamo == null)
            {
                throw new ArgumentException("Préstamo no encontrado");
            }

            prestamo.RegistrarDevolucion();

            var material = await _materialRepository.ObtenerPorIsbnAsync(prestamo.ISBN);
            if (material != null)
            {
                material.MarcarComoDevuelto();
                await _materialRepository.ActualizarAsync(material);
            }

            await _prestamoRepository.ActualizarAsync(prestamo);
        }
    }
}

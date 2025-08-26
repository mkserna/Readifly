using System.Threading.Tasks;
using Readifly.Domain.Entities;

namespace Readifly.Domain.Services
{
    public interface IServicioPrestamo
    {
        Task<Prestamo> RealizarPrestamoAsync(string isbn, string usuarioId);
        Task RegistrarDevolucionAsync(int prestamoId);
    }
}

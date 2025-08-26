using System.Collections.Generic;
using System.Threading.Tasks;
using Readifly.Domain.Entities;

namespace Readifly.Domain.Interfaces
{
    public interface IRepositorioPrestamo
    {
        Task<Prestamo> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Prestamo>> ObtenerPorUsuarioAsync(string usuarioId);
        Task<IEnumerable<Prestamo>> ObtenerActivosAsync();
        Task<Prestamo> AgregarAsync(Prestamo prestamo);
        Task ActualizarAsync(Prestamo prestamo);
    }
}

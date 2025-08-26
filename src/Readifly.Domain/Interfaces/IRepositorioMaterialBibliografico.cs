using System.Collections.Generic;
using System.Threading.Tasks;
using Readifly.Domain.Entities;

namespace Readifly.Domain.Interfaces
{
    public interface IRepositorioMaterialBibliografico
    {
        Task<MaterialBibliografico> ObtenerPorIsbnAsync(string isbn);
        Task<IEnumerable<MaterialBibliografico>> ObtenerTodosAsync();
        Task<IEnumerable<MaterialBibliografico>> ObtenerDisponiblesAsync();
        Task<MaterialBibliografico> AgregarAsync(MaterialBibliografico material);
        Task ActualizarAsync(MaterialBibliografico material);
    }
}

using AutoMapper;
using Readifly.Application.DTOs;
using Readifly.Application.Features.Materiales.Commands.CrearLibro;
using Readifly.Application.Features.Materiales.Commands.CrearRevista;
using Readifly.Domain.Entities;

namespace Readifly.Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Libro, LibroDto>();
            CreateMap<Revista, RevistaDto>();
            CreateMap<MaterialBibliografico, MaterialBibliograficoDto>()
                .Include<Libro, LibroDto>()
                .Include<Revista, RevistaDto>();
            CreateMap<Prestamo, PrestamoDto>();
            
            CreateMap<CrearLibroCommand, Libro>();
            CreateMap<CrearRevistaCommand, Revista>();
        }
    }
}

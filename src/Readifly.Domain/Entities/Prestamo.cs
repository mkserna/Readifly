using System;
using Readifly.Domain.Extensions;

namespace Readifly.Domain.Entities
{
    public class Prestamo
    {
        public int Id { get; private set; }
        public string ISBN { get; private set; }
        public string UsuarioId { get; private set; }
        public DateTime FechaPrestamo { get; private set; }
        public DateTime FechaDevolucionProgramada { get; private set; }
        public DateTime? FechaDevolucionReal { get; private set; }

        private Prestamo() { } // Para EF Core

        public static Prestamo CrearPrestamo(MaterialBibliografico material, string usuarioId)
        {
            if (material == null)
                throw new ArgumentNullException(nameof(material));

            if (string.IsNullOrWhiteSpace(usuarioId))
                throw new ArgumentException("El ID de usuario no puede estar vacío", nameof(usuarioId));

            if (material.EstaPrestado)
                throw new InvalidOperationException("El material ya está prestado");

            if (material.ISBN.EsPalindromo())
                throw new InvalidOperationException("No se puede prestar material con ISBN palíndromo");

            var prestamo = new Prestamo
            {
                ISBN = material.ISBN,
                UsuarioId = usuarioId,
                FechaPrestamo = DateTime.Now,
                FechaDevolucionProgramada = CalcularFechaDevolucion(material)
            };

            material.MarcarComoPrestado();
            return prestamo;
        }

        private static DateTime CalcularFechaDevolucion(MaterialBibliografico material)
        {
            DateTime fechaDevolucion;

            if (material is Revista)
            {
                fechaDevolucion = DateTime.Now.AddDays(Revista.DiasPrestamo);
            }
            else if (material is Libro libro)
            {
                fechaDevolucion = DateTime.Now.AddDays(libro.CalcularDiasPrestamo());
            }
            else
            {
                throw new ArgumentException("Tipo de material no soportado");
            }

            // Ajustar si cae en domingo
            while (fechaDevolucion.DayOfWeek == DayOfWeek.Sunday)
            {
                fechaDevolucion = fechaDevolucion.AddDays(1);
            }

            return fechaDevolucion;
        }

        public void RegistrarDevolucion()
        {
            if (FechaDevolucionReal.HasValue)
                throw new InvalidOperationException("El préstamo ya fue devuelto");

            FechaDevolucionReal = DateTime.Now;
        }
    }
}

using System;

namespace Readifly.Domain.Entities
{
    public class Revista : MaterialBibliografico
    {
        public string Editorial { get; private set; } = string.Empty;
        public int Numero { get; private set; }
        public int Volumen { get; private set; }
        public DateTime FechaPublicacion { get; private set; }

        // Constructor sin parámetros para EF Core
        private Revista() { }

        public Revista(
            string isbn,
            string nombre,
            string editorial,
            int numero,
            int volumen,
            DateTime fechaPublicacion) : base(isbn, nombre)
        {
            if (string.IsNullOrWhiteSpace(editorial))
                throw new ArgumentException("La editorial no puede estar vacía", nameof(editorial));
            
            if (numero <= 0)
                throw new ArgumentException("El número debe ser mayor a 0", nameof(numero));
            
            if (volumen <= 0)
                throw new ArgumentException("El volumen debe ser mayor a 0", nameof(volumen));
            
            if (fechaPublicacion > DateTime.Now)
                throw new ArgumentException("La fecha de publicación no puede ser futura", nameof(fechaPublicacion));

            Editorial = editorial;
            Numero = numero;
            Volumen = volumen;
            FechaPublicacion = fechaPublicacion;
        }

        public const int DiasPrestamo = 2;

        public override void MarcarComoPrestado()
        {
            var fechaActual = DateTime.Now;
            if (fechaActual.DayOfWeek == DayOfWeek.Saturday || 
                fechaActual.DayOfWeek == DayOfWeek.Sunday)
            {
                throw new InvalidOperationException("Las revistas no se pueden prestar para el fin de semana");
            }

            base.MarcarComoPrestado();
        }
    }
}

using System;

namespace Readifly.Domain.Entities
{
    public class Libro : MaterialBibliografico
    {
        public string Autor { get; private set; }
        public int NumeroPaginas { get; private set; }
        public string Editorial { get; private set; }
        public int AnioPublicacion { get; private set; }

        public Libro(
            string isbn,
            string nombre,
            string autor,
            int numeroPaginas,
            string editorial,
            int anioPublicacion) : base(isbn, nombre)
        {
            if (string.IsNullOrWhiteSpace(autor))
                throw new ArgumentException("El autor no puede estar vacío", nameof(autor));
            
            if (numeroPaginas <= 0)
                throw new ArgumentException("El número de páginas debe ser mayor a 0", nameof(numeroPaginas));
            
            if (string.IsNullOrWhiteSpace(editorial))
                throw new ArgumentException("La editorial no puede estar vacía", nameof(editorial));
            
            if (anioPublicacion <= 0)
                throw new ArgumentException("El año de publicación debe ser válido", nameof(anioPublicacion));

            Autor = autor;
            NumeroPaginas = numeroPaginas;
            Editorial = editorial;
            AnioPublicacion = anioPublicacion;
        }

        public int CalcularDiasPrestamo()
        {
            int sumaDígitos = 0;
            foreach (char digito in ISBN.Replace("-", ""))
            {
                if (char.IsDigit(digito))
                {
                    sumaDígitos += int.Parse(digito.ToString());
                }
            }

            return sumaDígitos > 30 ? 15 : 10;
        }
    }
}

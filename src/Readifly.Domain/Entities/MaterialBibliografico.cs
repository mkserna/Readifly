using System;

namespace Readifly.Domain.Entities
{
    public abstract class MaterialBibliografico
    {
        public int Id { get; protected set; }
        public string ISBN { get; protected set; } = string.Empty;
        public string Nombre { get; protected set; } = string.Empty;
        public bool EstaPrestado { get; protected set; }

        // Constructor sin parámetros para EF Core
        protected MaterialBibliografico() { }

        protected MaterialBibliografico(string isbn, string nombre)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                throw new ArgumentException("El ISBN no puede estar vacío", nameof(isbn));
            
            if (string.IsNullOrWhiteSpace(nombre))
                throw new ArgumentException("El nombre no puede estar vacío", nameof(nombre));

            ISBN = isbn;
            Nombre = nombre;
            EstaPrestado = false;
        }

        public virtual void MarcarComoPrestado()
        {
            if (EstaPrestado)
                throw new InvalidOperationException("El material ya está prestado");
            
            EstaPrestado = true;
        }

        public virtual void MarcarComoDevuelto()
        {
            if (!EstaPrestado)
                throw new InvalidOperationException("El material no está prestado");
            
            EstaPrestado = false;
        }
    }
}

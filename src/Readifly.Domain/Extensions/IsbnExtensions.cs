using System.Linq;

namespace Readifly.Domain.Extensions
{
    public static class IsbnExtensions
    {
        public static bool EsPalindromo(this string isbn)
        {
            if (string.IsNullOrWhiteSpace(isbn))
                return false;

            // Removemos los guiones del ISBN para validar solo los números
            string soloNumeros = new string(isbn.Replace("-", "").Where(char.IsDigit).ToArray());
            
            if (string.IsNullOrEmpty(soloNumeros))
                return false;

            int inicio = 0;
            int fin = soloNumeros.Length - 1;

            while (inicio < fin)
            {
                if (soloNumeros[inicio] != soloNumeros[fin])
                    return false;
                
                inicio++;
                fin--;
            }

            return true;
        }
    }
}

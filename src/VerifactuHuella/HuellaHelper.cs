using System.Security.Cryptography;
using System.Text;

namespace VerifactuHuella
{
    internal static class HuellaHelper
    {
        public static string CalcularHashSHA256(string valor)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(valor);
                byte[] hashBytes = sha256.ComputeHash(bytes);

                // Convertir el hash a una cadena hexadecimal
                StringBuilder hash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hash.Append(b.ToString("x2"));
                }

                return hash.ToString().ToUpper();
            }
        }
    }
}

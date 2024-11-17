using System;
using VerifactuHuella.Extensions;

namespace VerifactuHuella
{
    public class Huella : IHuella
    {
        public string CalcularHuella<T>(T data) where T : class
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            return HuellaHelper.CalcularHashSHA256(data.ConcatenaCampos());
        }
    }
}

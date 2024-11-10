using System.Reflection;
using VerifactuHuella.Models;

namespace VerifactuHuella.Extensions
{
    internal class EnlacePropiedadAtributo
    {
        public PropertyInfo Propiedad { get; set; }
        public CampoAttribute Atributo { get; set; }
    }
}

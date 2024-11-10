using System;
using System.Linq;
using System.Reflection;
using VerifactuHuella.Models;

namespace VerifactuHuella.Extensions
{
    public static class Extensiones
    {
        public static string ConcatenaCampos<T>(this T registro) where T : class
        {
            IOrderedEnumerable<EnlacePropiedadAtributo> propiedades = typeof(T)
                .GetProperties()
                .Where(prop => Attribute.IsDefined(prop, typeof(CampoAttribute)))
                .Select(prop => new EnlacePropiedadAtributo()
                {
                    Propiedad = prop,
                    Atributo = (CampoAttribute)prop.GetCustomAttribute(typeof(CampoAttribute))
                })
                .OrderBy(x => x.Atributo.Orden);

            return new Concatenacion().Ejecutar(propiedades, registro);
        }
    }
}

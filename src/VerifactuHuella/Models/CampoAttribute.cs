using System;

namespace VerifactuHuella.Models
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CampoAttribute : Attribute
    {
        public string Nombre { get; }
        public int Orden { get; }
        public string Formato { get; }

        public CampoAttribute(string nombre, int orden, string formato = null)
        {
            Nombre = nombre;
            Orden = orden;
            Formato = formato;
        }

    }
}

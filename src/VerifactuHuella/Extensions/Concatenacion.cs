using System.Globalization;
using System.Linq;
using System.Text;

namespace VerifactuHuella.Extensions
{
    internal static class Concatenacion
    {
        internal static string Ejecutar(IOrderedEnumerable<EnlacePropiedadAtributo> enlaces, object data)
        {
            StringBuilder resultado = new StringBuilder();

            foreach (var item in enlaces)
            {
                string nombreCampo = item.Atributo.Nombre;
                object valorCampo = item.Propiedad.GetValue(data);

                // Verificar si hay un formato en el atributo y aplicarlo si es necesario
                string valorFormateado;
                if (valorCampo != null && item.Atributo.Formato != null)
                {
                    valorFormateado = string.Format(CultureInfo.InvariantCulture, "{0:" + item.Atributo.Formato + "}", valorCampo);
                }
                else
                {
                    valorFormateado = valorCampo?.ToString() ?? string.Empty;
                }

                resultado.Append($"{nombreCampo}={valorFormateado}&");
            }

            //Quitar el último & de la concatenación de campos
            string cadenaFinal = resultado.ToString();

            return cadenaFinal.Remove(cadenaFinal.LastIndexOf("&"), 1);
        }
    }
}

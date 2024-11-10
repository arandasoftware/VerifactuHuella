using VerifactuHuella;
using VerifactuHuella.Models;

namespace VerifactuHuellaTest
{
    
    public class VerifactuHuellaTest
    {
        private IHuella _huella;

        [SetUp]
        public void Setup()
        {
            _huella = new Huella();
        }

        [Test]
        public void CalcularHuella_RegistroAlta_ArgumentNullException()
        {
            Assert.Catch<ArgumentNullException>(() =>_huella.CalcularHuella<RegistroAlta>(null));
        }

        [Test]
        public void CalcularHuella_Primer_RegistroAlta()
        {
            string resultado = _huella.CalcularHuella(new RegistroAlta()
            {
                IDEmisorFactura = "89890001K",
                NumSerieFactura = "12345678/G33",
                FechaExpedicionFactura = new DateTime(2024, 1, 1, 5, 0, 30, DateTimeKind.Local),
                TipoFactura = "F1",
                CuotaTotal = 12.35m,
                ImporteTotal = 123.45m,
                Huella = "",
                FechaHoraHusoGenRegistro = new DateTime(2024, 1, 1, 19, 20, 30, DateTimeKind.Local),
            });

            Assert.AreEqual(resultado, "3C464DAF61ACB827C65FDA19F352A4E3BDC2C640E9E9FC4CC058073F38F12F60");
        }
    }
}
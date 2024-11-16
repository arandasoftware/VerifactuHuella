using System;

namespace VerifactuHuella.Models
{
    public class RegistroAlta
    {
        [Campo("IDEmisorFactura", 1)]
        public string IDEmisorFactura { get; set; }

        [Campo("NumSerieFactura", 2)]
        public string NumSerieFactura { get; set; }

        [Campo("FechaExpedicionFactura", 3, "dd-MM-yyyy")]
        public DateTime FechaExpedicionFactura { get; set; }

        [Campo("TipoFactura", 4)]
        public string TipoFactura { get; set; }

        [Campo("CuotaTotal", 5, "N2")]
        public decimal CuotaTotal { get; set; }

        [Campo("ImporteTotal", 6, "N2")]
        public decimal ImporteTotal { get; set; }

        [Campo("Huella", 7)]
        public string Huella { get; set; }

        [Campo("FechaHoraHusoGenRegistro", 8, "yyyy-MM-ddTHH:mm:ssK")]
        public DateTime FechaHoraHusoGenRegistro { get; set; }
    }
}

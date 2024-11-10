using System;

namespace VerifactuHuella.Models
{
    public class RegistroAnulacion
    {
        [Campo("IDEmisorFacturaAnulada", 1)]
        public string IDEmisorFacturaAnulada { get; set; }

        [Campo("NumSerieFacturaAnulada", 2)]
        public string NumSerieFacturaAnulada { get; set; }

        [Campo("FechaExpedicionFacturaAnulada", 3, "dd-MM-yyyy")]
        public DateTime FechaExpedicionFacturaAnulada { get; set; }

        [Campo("Huella", 4)]
        public string Huella { get; set; }

        [Campo("FechaHoraHusoGenRegistro", 5, "yyyy-MM-ddTHH:mm:ssK")]
        public DateTime FechaHoraHusoGenRegistro { get; set; }
    }
}

using System;

namespace VerifactuHuella.Models
{

    public class RegistroEvento
    {
        [Campo("NIF", 1)]
        public string NIF { get; set; }

        [Campo("ID", 2)]
        public string ID { get; set; }

        [Campo("IdSistemaInformatico", 3)]
        public string IdSistemaInformatico { get; set; }

        [Campo("Version", 4)]
        public string Version { get; set; }

        [Campo("Version", 5)]
        public string NumeroInstalacion { get; set; }

        [Campo("NIF", 6)]
        public string NIFEmisior { get; set; }

        [Campo("TipoEvento", 7)]
        public string TipoEvento { get; set; }

        [Campo("HuellaEvento", 8)]
        public string HuellaEvento { get; set; }

        [Campo("FechaHoraHusoGenEvento", 9, "yyyy-MM-ddTHH:mm:ssK")]
        public DateTime FechaHoraHusoGenEvento { get; set; }
    }
}

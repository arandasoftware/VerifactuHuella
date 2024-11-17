using VerifactuHuella;
using VerifactuHuella.Extensions;
using VerifactuHuella.Models;

namespace VerifactuHuellaTest;

public class PruebasUnitarias
{
    [Fact]
    public void CalcularHuella_RegistroAlta_ArgumentNullException()
    {
        Huella _huella = new();
        Assert.Throws<ArgumentNullException>(() => _huella.CalcularHuella<RegistroAlta>(null));
    }

    /// <summary>
    /// Caso 1: primer registro de facturaciÃ³n â€“en este caso, de altaâ€“ en un Sistema InformÃ¡tico de FacturaciÃ³n(SIF)
    /// </summary>
    [Fact]
    public void CalcularHuella_Primer_RegistroAlta_Prueba()
    {
        string resultado2 = new RegistroAlta()
        {
            IDEmisorFactura = "89890001K",
            NumSerieFactura = "12345678/G33",
            FechaExpedicionFactura = new DateTime(2024, 1, 1, 5, 0, 30, DateTimeKind.Local),
            TipoFactura = "F1",
            CuotaTotal = 12.35m,
            ImporteTotal = 123.45m,
            Huella = "",
            FechaHoraHusoGenRegistro = new DateTimeOffset(2024, 1, 1, 19, 20, 30, TimeSpan.FromHours(1)),
        }.ConcatenaCampos();

        Assert.Equal("IDEmisorFactura=89890001K&NumSerieFactura=12345678/G33&FechaExpedicionFactura=01-01-2024&TipoFactura=F1&CuotaTotal=12.35&ImporteTotal=123.45&Huella=&FechaHoraHusoGenRegistro=2024-01-01T19:20:30+01:00", resultado2);
    }

    /// <summary>
    /// Caso 1: primer registro de facturaciÃ³n â€“en este caso, de altaâ€“ en un Sistema InformÃ¡tico de FacturaciÃ³n(SIF)
    /// </summary>
    [Fact]
    public void CalcularHuella_Primer_RegistroAlta()
    {
        Huella _huella = new();
        string resultado = _huella.CalcularHuella(new RegistroAlta()
        {
            IDEmisorFactura = "89890001K",
            NumSerieFactura = "12345678/G33",
            FechaExpedicionFactura = new DateTime(2024, 1, 1, 5, 0, 30, DateTimeKind.Local),
            TipoFactura = "F1",
            CuotaTotal = 12.35m,
            ImporteTotal = 123.45m,
            Huella = "",
            FechaHoraHusoGenRegistro = new DateTimeOffset(2024, 1, 1, 19, 20, 30, TimeSpan.FromHours(1)),
        });

        Assert.Equal("3C464DAF61ACB827C65FDA19F352A4E3BDC2C640E9E9FC4CC058073F38F12F60", resultado);
    }

    /// <summary>
    /// Caso 2: registro de facturaciÃ³n -en este caso de alta- con registro de facturaciÃ³n anterior existente en el SIF (siendo, por tanto, el segundo registro o sucesivo)
    /// </summary>
    [Fact]
    public void CalcularHuella_Sucesivos_RegistrosAlta()
    {
        Huella _huella = new();
        string resultado = _huella.CalcularHuella(new RegistroAlta()
        {
            IDEmisorFactura = "89890001K",
            NumSerieFactura = "12345679/G34",
            FechaExpedicionFactura = new DateTime(2024, 1, 1, 5, 0, 30, DateTimeKind.Local),
            TipoFactura = "F1",
            CuotaTotal = 12.35m,
            ImporteTotal = 123.45m,
            Huella = "3C464DAF61ACB827C65FDA19F352A4E3BDC2C640E9E9FC4CC058073F38F12F60",
            FechaHoraHusoGenRegistro = new DateTimeOffset(2024, 1, 1, 19, 20, 30, TimeSpan.FromHours(1)),
        });

        Assert.Equal("0C03B2B67A998263BBB8B96212EB2C5554FF64236269B37BAB195AD58C28E511", resultado);
    }


    /// <summary>
    /// Caso 3: registro de facturaciÃ³n â€“en este caso, de anulaciÃ³nâ€“ con registro de facturaciÃ³n anterior existente en el SIF(siendo, por tanto, el segundo registro o sucesivo)
    /// </summary>
    [Fact]
    public void CalcularHuella_Sucesivos_RegistrosAnulacion()
    {
        Huella _huella = new();
        string resultado = _huella.CalcularHuella(new RegistroAnulacion()
        {
            IDEmisorFacturaAnulada = "89890001K",
            NumSerieFacturaAnulada = "12345679/G34",
            FechaExpedicionFacturaAnulada = new DateTime(2024, 1, 1, 5, 0, 30, DateTimeKind.Local),
            Huella = "F7B94CFD8924EDFF273501B01EE5153E4CE8F259766F88CF6ACB8935802A2B97",
            FechaHoraHusoGenRegistro = new DateTimeOffset(2024, 1, 1, 19, 20, 30, TimeSpan.FromHours(1)),
        });

        Assert.Equal("F2EB78E6796D47CFACF00DEEC42DBA7681A39284B6BA9D2F0910F7F4CD734409", resultado);
    }

    /// <summary>
    /// Caso 4: primer registro de evento
    /// </summary>
    [Fact]
    public void CalcularHuella_Primer_RegistrosEvento()
    {
        Huella _huella = new();
        string resultado = _huella.CalcularHuella(new RegistroEvento()
        {
            NIF = "89890001K",
            ID = "",
            IdSistemaInformatico = "123456",
            Version = "1.1",
            NumeroInstalacion = "1",
            NIFEmisior = "89890001K",
            TipoEvento = "A",
            HuellaEvento = "",
            FechaHoraHusoGenEvento = new DateTimeOffset(2024, 1, 1, 19, 20, 30, TimeSpan.FromHours(1)),
        });

        Assert.Equal("97A8116D24A6235C98147B887031DDCE371F4E4CBF5BD2EBC4B80100F8F8BEBC", resultado);
    }

    /// <summary>
    /// Caso 5: registro de evento con registro de evento anterior existente en el SIF(siendo, por tanto, el segundo registro o sucesivo)
    /// </summary>
    [Fact]
    public void CalcularHuella_Sucesivo_RegistrosEvento()
    {
        Huella _huella = new();
        string resultado = _huella.CalcularHuella(new RegistroEvento()
        {
            NIF = "89890001K",
            ID = "",
            IdSistemaInformatico = "123456",
            Version = "1.1",
            NumeroInstalacion = "1",
            NIFEmisior = "89890001K",
            TipoEvento = "A",
            HuellaEvento = "97A8116D24A6235C98147B887031DDCE371F4E4CBF5BD2EBC4B80100F8F8BEBC",
            FechaHoraHusoGenEvento = new DateTimeOffset(2024, 1, 1, 19, 20, 30, TimeSpan.FromHours(1)),
        });

        Assert.Equal("481DE60FE058F5B518172C87724D1AA048BA5EED2DD94A2D5687636061C70FA6", resultado);
    }
}

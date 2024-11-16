using System.Globalization;
using VerifactuHuella;
using VerifactuHuella.Models;

namespace VerifactuHuellaTest;

public class PruebasUnitariasBase : IDisposable
{
    private readonly CultureInfo _originalCulture;

    public PruebasUnitariasBase()
    {
        // Guarda la cultura actual para restaurarla despuÃ©s
        _originalCulture = CultureInfo.CurrentCulture;

        // Establece la nueva cultura
        var cultureInfo = new CultureInfo("es-ES");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }

    public void Dispose()
    {
        // Restaura la cultura original despuÃ©s de cada prueba
        CultureInfo.DefaultThreadCurrentCulture = _originalCulture;
        CultureInfo.DefaultThreadCurrentUICulture = _originalCulture;
    }
}

public class PruebasUnitarias : PruebasUnitariasBase
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
        string resultado = HuellaHelper.CalcularHashSHA256("IDEmisorFactura=89890001K&NumSerieFactura=12345678/G33&FechaExpedicionFactura=01-01-2024&TipoFactura=F1&CuotaTotal=12.35&ImporteTotal=123.45&Huella=&FechaHoraHusoGenRegistro=2024-01-01T19:20:30+01:00");

        Assert.Equal("3C464DAF61ACB827C65FDA19F352A4E3BDC2C640E9E9FC4CC058073F38F12F60", resultado);
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
            FechaHoraHusoGenRegistro = new DateTime(2024, 1, 1, 19, 20, 30, DateTimeKind.Local),
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
            FechaHoraHusoGenRegistro = new DateTime(2024, 1, 1, 19, 20, 35, DateTimeKind.Local),
        });

        Assert.Equal("F7B94CFD8924EDFF273501B01EE5153E4CE8F259766F88CF6ACB8935802A2B97", resultado);
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
            FechaHoraHusoGenRegistro = new DateTime(2024, 1, 1, 19, 20, 40, DateTimeKind.Local),
        });

        Assert.Equal("177547C0D57AC74748561D054A9CEC14B4C4EA23D1BEFD6F2E69E3A388F90C68", resultado);
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
            FechaHoraHusoGenEvento = new DateTime(2024, 1, 1, 19, 20, 40, DateTimeKind.Local),
        });

        Assert.Equal("A632D1BB507D1013F76FC81AF984C3510B9D33F00ECE4826C96F5BB22524780E", resultado);
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
            HuellaEvento = "A632D1BB507D1013F76FC81AF984C3510B9D33F00ECE4826C96F5BB22524780E",
            FechaHoraHusoGenEvento = new DateTime(2024, 1, 1, 19, 20, 50, DateTimeKind.Local),
        });

        Assert.Equal("0F91A8BD213777015492BFD57577CFE8F557701DA1F948A8B93924FF063D948A", resultado);
    }
}

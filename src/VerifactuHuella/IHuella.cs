namespace VerifactuHuella
{
    public interface IHuella
    {
        string CalcularHuella<T>(T data) where T : class;
    }
}

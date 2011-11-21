namespace DustyTome.PFC.Core
{
    public interface IError
    {
        int LineNumber { get; }

        string Message { get; }
    }
}

namespace DustyTome.PFC.Core
{
    public class Error : IError
    {
        public int LineNumber { get; set; }

        public string Message { get; set; }
    }
}

namespace ParcelService.CutomErrorHandler
{
    public class BadRequestException : Exception

    {
        public BadRequestException(string message) : base(message) { }

    }
}

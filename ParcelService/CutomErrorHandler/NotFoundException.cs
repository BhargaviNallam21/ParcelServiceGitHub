namespace ParcelService.CutomErrorHandler
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }

    }
}

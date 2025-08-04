namespace licencjatApi.Services.Validators
{
    public class NotValidObjectDataException : Exception
    {
        public NotValidObjectDataException(string message) : base(message) { }
    }
}

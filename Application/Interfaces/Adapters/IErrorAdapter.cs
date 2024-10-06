namespace Application.Interfaces.Adapters
{
    public interface IErrorAdapter
    {
        Error Validation<T>(string errorMessage, string errorName);
        Error NotFound<T>(string errorMessage, string errorName);
        Error Unauthorized<T>(string errorMessage, string errorName);
        Error Forbidden<T>(string errorMessage, string errorName);

    }
}

namespace Domain.Abstractions
{
    public abstract class ErrorsAbstraction<T>
    {
        public static string GetCodeError(string errorName)
        {
            return $"{typeof(T).Name}.{errorName}";
        }
    }
}

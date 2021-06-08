namespace Core.Utilities.Results.Concrete.Errors
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        public ErrorDataResult(T data) : base(data, false, "İşlem sırasında hata oluştu")
        {

        }
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }
        public ErrorDataResult() : base(default, false, "İşlem sırasında hata oluştu")
        {

        }
    }
}

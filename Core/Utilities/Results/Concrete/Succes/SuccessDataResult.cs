namespace Core.Utilities.Results.Concrete.Succes
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, true, "İşlem Başarılı")
        {

        }
        public SuccessDataResult(string message) : base(default, true, message)
        {

        }
        public SuccessDataResult() : base(default, true, "İşlem Başarılı")
        {

        }
    }
}

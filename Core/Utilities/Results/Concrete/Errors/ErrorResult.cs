using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrete.Errors
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        public ErrorResult() : base(false, "İşlem sırasında hata oluştu")
        {

        }
    }
}

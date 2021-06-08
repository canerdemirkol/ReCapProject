using Core.Entities.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Core.Extensions.Concrete
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public List<ValidationErrorDto> ValidationError { get; set; }
    }
}

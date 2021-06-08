namespace Core.Entities.Concrete
{
    public class ValidationErrorDto : IDto
	{
		public string PropertyName { get; set; }
		public string ErrorMessage { get; set; }
		public string ErrorCode { get; set; }
		public object AttemptedValue { get; set; }
	}
}

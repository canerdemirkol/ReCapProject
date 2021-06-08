namespace Core.Entities.Concrete
{
    public partial class BaseAuthUser : EntityBase<int>, IDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

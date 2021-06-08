namespace Core.Entities.Concrete
{
    public partial class UsersAllowedToUseAPI : EntityBase<int>, IEntity
    {
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}

namespace Core.Entities.Concrete
{
    public partial class UserAllowedToUseAPI : EntityBase<int>, IEntity
    {
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}

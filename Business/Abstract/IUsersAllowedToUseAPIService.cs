using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IUsersAllowedToUseAPIService
    {
        IResult UserAllowedToUseEmailExists(string email);
    }
}

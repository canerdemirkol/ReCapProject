using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface UsersAllowedToUseAPIService
    {
        IResult UserAllowedToUseEmailExists(string email);
    }
}

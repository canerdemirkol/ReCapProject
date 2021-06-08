using Core.Utilities.Results.Abstract;
using System.Threading.Tasks;

namespace Business.Adapters.SmsService
{
    public interface ISmsService
    {
        Task<string> Send_NN(string username, string password, string company, string header, string[] mesaj, string[] cellPhone, string bayikodu, string startDate = "", string stopDate = "", string encoding = "UTF-8");
        Task<string> Send_1N(string username, string password, string company, string header, string mesaj, string[] cellPhone, string bayikodu, string startDate = "", string stopDate = "", string encoding = "UTF-8");
        Task<string> SendStartDateAndStopDate(string username, string password, string company, string header, string[] mesaj, string[] cellPhone, string bayikodu, string startDate, string stopDate, string encoding = "UTF-8");

    }
}

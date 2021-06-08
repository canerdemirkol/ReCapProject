using Business.Abstract;
using Entities.Concrete;
using NETGSMServiceReference;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Adapters.SmsService.NetGSM
{
    public class NetGsmSmsAdapterService : INetGsmSmsService
    {
        private smsnn _netGsmSmsnnClient;
        public NetGsmSmsAdapterService(smsnn netGsmSmsnnClient)
        {
            _netGsmSmsnnClient = netGsmSmsnnClient;
        }

        public async Task<string> SendStartDateAndStopDate(string username, string password, string company, string header, string[] mesaj, string[] cellPhone, string bayikodu, string startDate, string stopDate, string encoding = "UTF-8")
        {
          var result= await  _netGsmSmsnnClient.sms_gonder_nnAsync(new sms_gonder_nnRequest
            {
                username = username,
                password = password,
                company = company,
                header = header,
                msg = mesaj,
                gsm = cellPhone,
                encoding = encoding,
                startdate = startDate,
                stopdate = stopDate,
                bayikodu = bayikodu
            });
            return result.@return;
        }

    
        public async Task<string> Send_1N(string username, string password, string company, string header, string mesaj, string[] cellPhone, string bayikodu, string startDate = "", string stopDate = "", string encoding = "UTF-8")
        {
            var result = await _netGsmSmsnnClient.sms_gonder_1nAsync(new sms_gonder_1nRequest
            {
                username = username,
                password = password,
                company = company,
                header = header,
                msg = mesaj,
                gsm = cellPhone,
                encoding = encoding,
                startdate = startDate,
                stopdate = stopDate,
                bayikodu = bayikodu
            });
            return result.@return;
        }

        public async Task<string> Send_NN(string username, string password, string company, string header, string[] mesaj, string[] cellPhone,  string bayikodu, string startDate = "", string stopDate = "", string encoding = "UTF-8")
        {
            var result = await _netGsmSmsnnClient.sms_gonder_nnAsync(new sms_gonder_nnRequest
            {
                username = username,
                password = password,
                company = company,
                header = header,
                msg = mesaj,
                gsm = cellPhone,
                encoding = encoding,
                startdate = startDate,
                stopdate = stopDate,
                bayikodu = bayikodu
            });
            return result.@return;
        }

    }
}

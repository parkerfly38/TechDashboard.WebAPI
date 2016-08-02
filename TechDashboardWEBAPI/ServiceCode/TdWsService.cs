using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rkl.Erp.Sage.Sage100.TableObjects;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TechDashboardWEBAPI.ServiceCode
{
    
    public partial class TdWsService
    {
        protected bool _isUsingHttps = false;
        protected string _sDataUrl = @"jobops2016adev.rkldev.local/sdata/MasApp/MasContract/JOB/";
        protected string _userId = @"sdata";
        protected string _password = @"RKLsupp@rt";

        public TdWsService()
        {
            try
            {
                _isUsingHttps = Convert.ToBoolean(Properties.Settings.Default.isUsingHttps);
            }
            catch(Exception ex)
            {
                // empty
            }
            try
            {
                _sDataUrl = Properties.Settings.Default.sDataUrl;
            }
            catch (Exception ex)
            {
                // empty
            }
            try
            {
                _userId = Properties.Settings.Default.userId;
            }
            catch (Exception ex)
            {
                // empty
            }
            try
            {
                _password = Properties.Settings.Default.password;
            }
            catch (Exception ex)
            {
                // empty
            }
        }

        public bool ValidateAuthentication(HttpRequestMessage request)
        {
            bool accepted = true;
            HttpRequestHeaders headers = request.Headers;

            if (!headers.Contains("x-tdws-authid"))
            {
                return false;
            }
            SimpleAES decryptText = new SimpleAES("Sm9iT3BzRXhhbXBsZVdlYlNlcnZpY2U=", "Sm9iT3BzRXhhbXBsZVZlY3Rvcg==");
            string strDecrypt = decryptText.DecryptString(headers.GetValues("x-tdws-authid").First());

            accepted = ValidateAuthenticationBase(request);

            return accepted;
        }

        public bool ValidateAuthenticationBase(HttpRequestMessage request)
        {
            HttpRequestHeaders headers = request.Headers;
            if (!headers.Contains("x-tdws-auth"))
            {
                return false;
            }
            SimpleAES decryptText = new SimpleAES("Sm9iT3BzRXhhbXBsZVdlYlNlcnZpY2U=", "Sm9iT3BzRXhhbXBsZVZlY3Rvcg==");
            string strDecrypt = decryptText.DecryptString(headers.GetValues("x-tdws-auth").First());

            DateTime dtRequestTime = DateTime.ParseExact(strDecrypt, "yyyy-MM-ddTHH:mm:sszzz", null);

            if ((dtRequestTime > DateTime.Now.AddMinutes(-15) && dtRequestTime < DateTime.Now.AddMinutes(15)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<bool> TestConnection()
        {
            List<bool> returnData = new List<bool>();
            returnData.Add(true);

            return returnData;
        }

        protected List<T> GetData<T>(string filterType, string filterText)
        {
            TdWs.SDataClient.SDataClient myClient =
                new TdWs.SDataClient.SDataClient(
                    _isUsingHttps,
                    _sDataUrl,
                    _userId,
                    _password
                );

            if ((filterType == null) || (filterType.ToLower().Trim() == "all"))
            {
                filterType = string.Empty;
                filterText = string.Empty;
            }

            return myClient.GetData<T>(filterType, filterText);
        }

        protected bool UpdateTechnicianRecord(JT_Technician technician)
        {
            TdWs.SDataClient.SDataClient myClient =
                new TdWs.SDataClient.SDataClient(
                    _isUsingHttps,
                    _sDataUrl,
                    _userId,
                    _password
                );

            return myClient.UpdateTechnicianRecord(technician);
        }

        protected bool InsertRecord<T>(T dataItem)
        {
            TdWs.SDataClient.SDataClient myClient =
                new TdWs.SDataClient.SDataClient(
                    _isUsingHttps,
                    _sDataUrl,
                    _userId,
                    _password
                );

            return myClient.InsertRecord(dataItem);
        }
    }
}

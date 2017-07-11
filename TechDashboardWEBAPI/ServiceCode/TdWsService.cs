using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using TechDashboardWEBAPI.DataAccess;
using Rkl.Erp.Sage.Sage100.TableObjects;
using Sage.SData.Client;

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

        /// <summary>
        /// Validates Authentication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool ValidateAuthentication(HttpRequestMessage request)
        {
            bool accepted = true;
            HttpRequestHeaders headers = request.Headers;

            if (!headers.Contains("x-tdws-authid"))
            {
                return false;
            }
            SimpleAES decryptText = new SimpleAES("V&WWJ3d39brdR5yUh5(JQGHbi:FB@$^@", "W4aRWS!D$kgD8Xz@");
            string strDecrypt = decryptText.DecryptString(headers.GetValues("x-tdws-authid").First());

            DBMapper dbMapper = new DBMapper();
            if (!dbMapper.ValidateDevice(Guid.Parse(strDecrypt)))
                return false;

            accepted = ValidateAuthenticationBase(request);

            return accepted;
        }

        /// <summary>
        /// base authentication
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public bool ValidateAuthenticationBase(HttpRequestMessage request)
        {
            HttpRequestHeaders headers = request.Headers;
            if (!headers.Contains("x-tdws-auth"))
            {
                return false;
            }
            SimpleAES decryptText = new SimpleAES("V&WWJ3d39brdR5yUh5(JQGHbi:FB@$^@", "W4aRWS!D$kgD8Xz@");
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
            // dch rkl 01/30/2017 Decode filter text
            if (filterText.Trim().Length > 0)
            {
                filterText = System.Web.HttpUtility.UrlDecode(filterText);
            }

            SDataClient myClient =
                new SDataClient(
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
            SDataClient myClient =
                new SDataClient(
                    _isUsingHttps,
                    _sDataUrl,
                    _userId,
                    _password
                );

            return myClient.UpdateTechnicianRecord(technician);
        }

        // dch rkl 12/09/2016 return API_Results, which includes success flag & error message(s)
        //protected bool InsertRecord<T>(T dataItem)
        protected API_Results InsertRecord<T>(T dataItem)
        {
            SDataClient myClient =
                new SDataClient(
                    _isUsingHttps,
                    _sDataUrl,
                    _userId,
                    _password
                );

            return myClient.InsertRecord(dataItem);
        }

        // dch rkl 12/09/2016 return API_Results, which includes success flag & error message(s)
    }
}

using Rkl.Erp.Sage.Sage100.TableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechDashboardWEBAPI.ServiceCode;
using System.Web.Http.Description;
using TechDashboardWEBAPI.DataAccess;
using TechDashboardWEBAPI.Models;

namespace TechDashboardWEBAPI.Controllers
{
    /// <summary>
    /// Version 1.6 REST api for Job Ops Tech Dashboard
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = false)]
    [RoutePrefix("v1-6")]
    public class v16Controller : ApiController
    {
        TdWsService tdws = new TdWsService();

        /// <summary>
        /// Test connection service
        /// </summary>
        /// <returns></returns>
        [Route("test")]
        [HttpGet]
        public List<bool> TestConnection()
        {
            List<bool> returnData = new List<bool>();
            returnData.Add(true);

            return returnData;
        }

        /// <summary>
        /// Get Device ID (or insert new)
        /// </summary>
        /// <param name="deviceName"></param>
        /// <returns></returns>
        [Route("GetDeviceID/{deviceName}")]
        [HttpGet]
        public string GetDeviceID(string deviceName)
        {
            if (deviceName.Length == 0)
                return "";
            DBMapper dataMapper = new DBMapper();
            return dataMapper.GetDeviceIdByName(deviceName);
        }

        /// <summary>
        /// Get filtered CI_Options
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        [Route("q/CI_Options/{filterType}")]
        [HttpGet]
        public List<CI_Options> GetCI_Options(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_OptionsFiltered(filterType, v);
        }

        /// <summary>
        /// Get all CI_Options
        /// </summary>
        /// <returns></returns>
        [Route("all/CI_Options")]
        [HttpGet]
        public List<CI_Options> Get_SOOptionsAll()
        {

            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_OptionsAll();
        }

        /// <summary>
        /// Gets SO_SalesOrderDetail records by filter
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        [Route("q/SO_SalesOrderDetail/{filterType}")]
        [HttpGet]
        public List<SO_SalesOrderDetail> GetSO_SalesOrderDetail(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_SalesOrderDetailFiltered(filterType, v);
        }

        /// <summary>
        /// Gets SO_SalesOrderDetailRecords by posted filter
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        [Route("q/SO_SalesOrderDetail/{filterType}")]
        [HttpPost]
        public List<SO_SalesOrderDetail> PostSO_SalesOrderDetail(string filterType, [FromBody] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            // dch rkl 01/31/2017 Decode filter
            if (v.Trim().Length > 0)
            {
                v = System.Web.HttpUtility.UrlDecode(v);
            }

            List<SO_SalesOrderDetail> salesOrders = new List<SO_SalesOrderDetail>();
            //return tdws.GetSDataForSO_SalesOrderDetailFiltered(filterType, v);
            if (filterType == "where")
            {
                v = v.Replace("eq", "==");
                v = v.Replace("ne", "!=");
                v = v.Replace("'", "\"");
                salesOrders = tdws.GetSDataForSO_SalesOrderDetailAll().AsQueryable().Where(v).ToList();
            } else
            {
                salesOrders = tdws.GetSDataForSO_SalesOrderDetailFiltered(filterType, v);
            }
            return salesOrders;
        }

        /// <summary>
        /// Gets all SO_SalesOrderDetail records
        /// </summary>
        /// <returns></returns>
        [Route("all/SO_SalesOrderDetail")]
        [HttpGet, HttpPost]
        public List<SO_SalesOrderDetail> GetAllSO_SalesOrderDetail()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_SalesOrderDetailAll();
        }
      
        /// <summary>
        /// Get AR_Customer by varying criteria.
        /// </summary>
        /// <param name="filterType">clause for query</param>
        /// <param name="v">body of filter clause</param>
        /// <returns>AR_Customer</returns>
        [Route("q/AR_Customer/{filterType}")]
        [HttpGet]
        public List<AR_Customer> GetAR_Customer(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForAR_CustomerFiltered(filterType, v);
        }

        /// <summary>
        /// Get AR_Customer by varying criteria.
        /// </summary>
        /// <param name="filterType">clause for query</param>
        /// <param name="v">body of filter clause</param>
        /// <returns>AR_Customer</returns>
        [Route("q/AR_Customer/{filterType}")]
        [HttpPost]
        public List<AR_Customer> GetAR_CustomerPost(string filterType, [FromBody] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            // dch rkl 01/31/2017 Decode filter
            if (v.Trim().Length > 0)
            {
                v = System.Web.HttpUtility.UrlDecode(v);
            }

            List<AR_Customer> customers = new List<AR_Customer>();
            if (filterType == "where")
            {
                v = v.Replace("eq", "==");
                v = v.Replace("ne", "!=");
                v = v.Replace("'", "\"");
                customers = tdws.GetSDataForAR_CustomerAll().AsQueryable().Where(v).ToList();
            }
            else {
                customers = tdws.GetSDataForAR_CustomerFiltered(filterType, v);
            }
            return customers;
        }
        /// <summary>
        /// Get all AR_Customer records
        /// </summary>
        /// <returns>AR_Customer</returns>
        [Route("all/AR_Customer")]
        [HttpGet, HttpPost]
        public List<AR_Customer> GetAllAR_Customer()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForAR_CustomerAll();
        }

        /// <summary>
        /// Get AR_CustomerContact records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns>AR_CustomerContact</returns>
        [Route("q/AR_CustomerContact/{filterType}")]
        [HttpGet]
        public List<AR_CustomerContact> GetAR_CustomerContact(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForAR_CustomerContactFiltered(filterType, v);
        }

        /// <summary>
        /// Get AR_CustomerContact records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns>AR_CustomerContact</returns>
        [Route("q/AR_CustomerContact/{filterType}")]
        [HttpPost]
        public List<AR_CustomerContact> GetAR_CustomerContactPost(string filterType, [FromBody] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            // dch rkl 01/31/2017 Decode filter
            if (v.Trim().Length > 0)
            {
                v = System.Web.HttpUtility.UrlDecode(v);
            }

            List<AR_CustomerContact> customerContacts = new List<AR_CustomerContact>();
            if (filterType == "where")
            {
                v = v.Replace("eq", "==")
                    .Replace("ne", "!=")
                    .Replace("'", "\"");
                customerContacts = tdws.GetSDataForAR_CustomerContactAll().Where(v).ToList();
            }
            else
            {
                customerContacts = tdws.GetSDataForAR_CustomerContactFiltered(filterType, v);
            }
            return customerContacts;
        }

        /// <summary>
        /// All AR_CustomerContact records
        /// </summary>
        /// <returns></returns>
        [Route("all/AR_CustomerContact")]
        [HttpGet, HttpPost]
        public List<AR_CustomerContact> GetAllAR_CustomerContact()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForAR_CustomerContactAll();
        }

        /// <summary>
        /// Gets CI_Items with filter clause
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/CI_Item/{filterType}")]
        [HttpGet]
        public List<CI_Item> GetCI_Item(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_ItemFiltered(filterType, v);
        }

        /// <summary>
        /// Returns all CI_Item records
        /// </summary>
        /// <returns></returns>
        [Route("all/CI_Item")]
        [HttpGet]
        public List<CI_Item> GetAllCI_Item()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_ItemAll();
        }

        /// <summary>
        /// Gets IM_ItemWarehouse records with filter clause
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/IM_ItemWarehouse/{filterType}")]
        [HttpGet]
        public List<IM_ItemWarehouse> GetIM_ItemWarehouse(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForIM_ItemWarehouseFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all IM_ItemWarehouse records
        /// </summary>
        /// <returns></returns>
        [Route("all/IM_ItemWarehouse")]
        [HttpGet]
        public List<IM_ItemWarehouse> GetAllIM_ItemWarehouse()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForIM_ItemWarehouseAll();
        }

        [Route("q/IM_ItemCost")]
        [HttpGet, HttpPost]
        public List<IM_ItemCost> GetIM_ItemCost(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForIM_ItemCost(filterType, v);
        }

        [Route("all/IM_ItemCost")]
        [HttpGet, HttpPost]
        public List<IM_ItemCost> GetAllIM_ItemCost()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForIM_ItemCost();
        }

        /// <summary>
        /// Gets JT_ActivityCode records with filter clause
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ActivityCode/{filterType}")]
        [HttpGet]
        public List<JT_ActivityCode> GetJT_ActivityCode(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ActivityCodeFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_ActivityCode records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ActivityCode")]
        [HttpGet]
        public List<JT_ActivityCode> GetAllJT_ActivityCode()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ActivityCodeAll();
        }

        /// <summary>
        /// Gets JT_ClassificationCode records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ClassificationCode/{filterType}")]
        [HttpGet]
        public List<JT_ClassificationCode> GetJT_ClassificationCode(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ClassificationCodeFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_ClassificationCode records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ClassificationCode")]
        [HttpGet]
        public List<JT_ClassificationCode> GetAllJT_ClassificationCode()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ClassificationCodeAll();
        }

        /// <summary>
        /// Gets JT_CustomerBillingRates records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_CustomerBillingRates/{filterType}")]
        [HttpGet]
        public List<JT_CustomerBillingRates> GetJT_CustomerBillingRates(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_CustomerBillingRatesFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_CustomerBillingRates records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_CustomerBillingRates")]
        [HttpGet]
        public List<JT_CustomerBillingRates> GetAllJT_CustomerBillingRates()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_CustomerBillingRatesAll();
        }

        /// <summary>
        /// Gets JT_DailyTimeEntry records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_DailyTimeEntry/{filterType}")]
        [HttpGet]
        public List<JT_DailyTimeEntry> GetJT_DailyTimeEntry(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_DailyTimeEntryFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_DailyTimeEntry records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_DailyTimeEntry")]
        [HttpGet]
        public List<JT_DailyTimeEntry> GetAllJT_DailyTimeEntry()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_DailyTimeEntryAll();
        }

        /// <summary>
        /// Gets JT_EarningsCode records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_EarningsCode/{filterType}")]
        [HttpGet]
        public List<JT_EarningsCode> GetJT_EarningsCode(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_EarningsCodeFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_EarningsCode records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_EarningsCode")]
        [HttpGet]
        public List<JT_EarningsCode> GetAllJT_EarningsCode()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_EarningsCodeAll();
        }

        /// <summary>
        /// Gets JT_Employee records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_Employee/{filterType}")]
        [HttpGet]
        public List<JT_Employee> GetJT_Employee(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_EmployeeFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_Employee records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_Employee")]
        [HttpGet]
        public List<JT_Employee> GetAllJT_Employee()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_EmployeeAll();
        }

        /// <summary>
        /// Gets JT_EquipmentAsset records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_EquipmentAsset/{filterType}")]
        [HttpGet]
        public List<JT_EquipmentAsset> GetJT_EquipmentAsset(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_EquipmentAssetFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_EquipmentAsset records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_EquipmentAsset")]
        [HttpGet]
        public List<JT_EquipmentAsset> GetAllJT_EquipmentAsset()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_EquipmentAssetAll();
        }

        /// <summary>
        /// Gets JT_FieldServiceOptions records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_FieldServiceOptions/{filterType}")]
        [HttpGet]
        public List<JT_FieldServiceOptions> GetJT_FieldServiceOptions(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_FieldServiceOptionsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_FieldServiceOptions records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_FieldServiceOptions")]
        [HttpGet]
        public List<JT_FieldServiceOptions> GetAllJT_FieldServiceOptions()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_FieldServiceOptionsAll();
        }

        /// <summary>
        /// Gets JT_FSDCommunication records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_FSDCommunication/{filterType}")]
        [HttpGet]
        public List<JT_FSDCommunication> GetJT_FSDCommunication(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_FSDCommunicationFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_FSDCommunication records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_FSDCommunication")]
        [HttpGet]
        public List<JT_FSDCommunication> GetAllJT_FSDCommunication()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_FSDCommunicationAll();
        }

        /// <summary>
        /// Gets JT_LaborText records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_LaborText/{filterType}")]
        [HttpGet]
        public List<JT_LaborText> GetJT_LaborText(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_LaborTextFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_LaborText records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_LaborText")]
        [HttpGet]
        public List<JT_LaborText> GetAllJT_LaborText()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_LaborTextAll();
        }

        /// <summary>
        /// Gets JT_MiscellaneousCodes by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_MiscellaneousCodes/{filterType}")]
        [HttpGet]
        public List<JT_MiscellaneousCodes> GetJT_MiscellaneousCodes(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_MiscellaneousCodesFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_MiscellaneousCodes records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_MiscellaneousCodes")]
        [HttpGet]
        public List<JT_MiscellaneousCodes> GetAllJT_MiscellaneousCodes()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_MiscellaneousCodesAll();
        }

        /// <summary>
        /// Gets JT_Options records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_Options/{filterType}")]
        [HttpGet]
        public List<JT_Options> GetJT_Options(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_OptionsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_Options records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_Options")]
        [HttpGet]
        public List<JT_Options> GetAllJT_Options()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_OptionsAll();
        }

        // dch rkl 11/16/2016 add SO_Options
        /// <summary>
        /// Gets SO_Options records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/SO_Options/{filterType}")]
        [HttpGet]
        public List<SO_Options> GetSO_Options(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_OptionsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all SO_Options records
        /// </summary>
        /// <returns></returns>
        [Route("all/SO_Options")]
        [HttpGet]
        public List<SO_Options> GetAllSO_Options()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_OptionsAll();
        }

        /// <summary>
        /// Gets JT_ServiceAgreementDetail records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ServiceAgreementDetail/{filterType}")]
        [HttpGet]
        public List<JT_ServiceAgreementDetail> GetJT_ServiceAgreementDetail(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceAgreementDetailFiltered(filterType, v);
        }

        /// <summary>
        /// Gets JT_ServiceAgreementDetail records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ServiceAgreementDetail/{filterType}")]
        [HttpPost]
        public List<JT_ServiceAgreementDetail> GetJT_ServiceAgreementDetailPost(string filterType, [FromBody] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            // dch rkl 01/31/2017 Decode filter
            if (v.Trim().Length > 0)
            {
                v = System.Web.HttpUtility.UrlDecode(v);
            }

            List<JT_ServiceAgreementDetail> serviceAgreements = new List<JT_ServiceAgreementDetail>();
            if (filterType == "where")
            {
                v = v.Replace("eq", "==");
                v = v.Replace("ne", "!=");
                v = v.Replace("'", "\"");
                serviceAgreements = tdws.GetSDataForJT_ServiceAgreementDetailAll().AsQueryable().Where(v).ToList();
            }
            else {
                serviceAgreements = tdws.GetSDataForJT_ServiceAgreementDetailFiltered(filterType, v);
            }
            return serviceAgreements;
        }

        /// <summary>
        /// Gets all JT_ServiceAgreementDetail records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ServiceAgreementDetail")]
        [HttpGet]
        public List<JT_ServiceAgreementDetail> GetAllJT_ServiceAgreementDetail()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceAgreementDetailAll();
        }

        /// <summary>
        /// Gets JT_ServiceAgreementHeader records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ServiceAgreementHeader/{filterType}")]
        [HttpGet]
        public List<JT_ServiceAgreementHeader> GetJT_ServiceAgreementHeader(string filterType, [FromUri]string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            return tdws.GetSDataForJT_ServiceAgreementHeaderFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_ServiceAgreementHeader records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ServiceAgreementHeader")]
        [HttpGet]
        public List<JT_ServiceAgreementHeader> GetAllJT_ServiceAgreementHeader()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceAgreementHeaderAll();
        }

        /// <summary>
        /// Gets JT_ServiceAgreementPMDetail records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ServiceAgreementPMDetail/{filterType}")]
        [HttpGet]
        public List<JT_ServiceAgreementPMDetail> GetJT_ServiceAgreementPMDetail(string filterType, [FromUri]string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceAgreementPMDetailFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_ServiceAgreementPMDetail records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ServiceAgreementPMDetail")]
        [HttpGet]
        public List<JT_ServiceAgreementPMDetail> GetAllJT_ServiceAgreementPMDetail()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceAgreementPMDetailAll();
        }

        /// <summary>
        /// Gets JT_ServiceEquipmentParts by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ServiceEquipmentParts/{filterType}")]
        [HttpGet]
        public List<JT_ServiceEquipmentParts> GetJT_ServiceEquipmentParts(string filterType, [FromUri]string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceEquipmentPartsFiltered(filterType, v);
        }
        /// <summary>
        /// Gets JT_ServiceEquipmentParts by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_ServiceEquipmentParts/{filterType}")]
        [HttpPost]
        public List<JT_ServiceEquipmentParts> GetJT_ServiceEquipmentPartsPost(string filterType, [FromBody ]string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            // dch rkl 01/31/2017 Decode filter
            if (v.Trim().Length > 0)
            {
                v = System.Web.HttpUtility.UrlDecode(v);
            }

            List<JT_ServiceEquipmentParts> serviceEquipmentParts = new List<JT_ServiceEquipmentParts>();
            if (filterType == "where")
            {
                v = v.Replace("eq", "==");
                v = v.Replace("ne", "!=");
                v = v.Replace("'", "\"");
                serviceEquipmentParts = tdws.GetSDataForJT_ServiceEquipmentPartsAll().Where(v).ToList();
            } else
            {
                serviceEquipmentParts = tdws.GetSDataForJT_ServiceEquipmentPartsFiltered(filterType, v);
            }
            return serviceEquipmentParts;
        }

        /// <summary>
        /// Gets all JT_ServiceEquipmentParts records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ServiceEquipmentParts")]
        [HttpGet, HttpPost]
        public List<JT_ServiceEquipmentParts> GetAllJT_ServiceEquipmentPartsl()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_ServiceEquipmentPartsAll();
        }

        /// <summary>
        /// Gets JT_Technician records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_Technician/{filterType}")]
        [HttpGet]
        public List<JT_Technician> GetJT_Technician(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TechnicianFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_Technician records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_Technician")]
        [HttpGet]
        public List<JT_Technician> GetAllJT_Technician()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TechnicianAll();
        }

        /// <summary>
        /// Update JT_Technician
        /// </summary>
        /// <param name="technician"></param>
        /// <returns></returns>
        [Route("u/JT_Technician")]
        [HttpPut]
        public bool UpdateJT_Technician([FromBody] JT_Technician technician)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.UpdateJT_Technician(technician);
        }

        /// <summary>
        /// Gets JT_TechnicianScheduleDetail records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_TechnicianScheduleDetail/{filterType}")]
        [HttpGet]
        public List<JT_TechnicianScheduleDetail> GetJT_TechnicianScheduleDetail(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TechnicianScheduleDetailFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_TechnicianScheduleDetail records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_TechnicianScheduleDetail")]
        [HttpGet]
        public List<JT_TechnicianScheduleDetail> GetAllJT_TechnicianScheduleDetail()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TechnicianScheduleDetailAll();
        }

        /// <summary>
        /// Gets JT_TechnicianStatus records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_TechnicianStatus/{filterType}")]
        [HttpGet]
        public List<JT_TechnicianStatus> GetJT_TechnicianStatus(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TechnicianStatusFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_TechnicianStatus records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_TechnicianStatus")]
        [HttpGet]
        public List<JT_TechnicianStatus> GetAllJT_TechnicianStatus()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TechnicianStatusAll();
        }

        /// <summary>
        /// Gets JT_TemplateParts records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_TemplateParts/{filterType}")]
        [HttpGet]
        public List<JT_TemplateParts> GetJT_TemplateParts(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TemplatePartsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_TemplateParts records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_TemplateParts")]
        [HttpGet]
        public List<JT_TemplateParts> GetAllJT_TemplateParts()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TemplatePartsAll();
        }

        /// <summary>
        /// Gets JT_Transaction records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_Transaction/{filterType}")]
        [HttpGet]
        public List<JT_Transaction> GetJT_Transaction(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TransactionFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_Transaction records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_Transaction")]
        [HttpGet]
        public List<JT_Transaction> GetAllJT_Transaction()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TransactionAll();
        }

        /// <summary>
        /// Gets JT_TransactionHistory records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_TransactionHistory/{filterType}")]
        [HttpGet]
        public List<JT_TransactionHistory> GetJT_TransactionHistory(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TransactionHistoryFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_TransactionHistory records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_TransactionHistory")]
        [HttpGet]
        public List<JT_TransactionHistory> GetAllJT_TransactionHistory()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TransactionHistoryAll();
        }

        /// <summary>
        /// Gets JT_TransactionImportDetail records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_TransactionImportDetail/{filterType}")]
        [HttpGet]
        public List<JT_TransactionImportDetail> GetJT_TransactionImportDetail(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TransactionImportDetailFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_TransactionImportDetail records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_TransactionImportDetail")]
        [HttpGet]
        public List<JT_TransactionImportDetail> GetAllJT_TransactionImportDetail()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TransactionImportDetailAll();
        }

        /// <summary>
        /// Inserts a new JT_TransactionImportDetail record
        /// dch rkl 12/09/2016 return API_Results, which includes success flag & error message(s)
        /// </summary>
        /// <param name="importDetail"></param>
        /// <returns></returns>
        [Route("i/JT_TransactionImportDetail")]
        [HttpPost]
        public API_Results InsertJT_TransactionImportDetail([FromBody]JT_TransactionImportDetail importDetail)
        //public bool InsertJT_TransactionImportDetail([FromBody]JT_TransactionImportDetail importDetail)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.InsertJT_TransactionImportDetail(importDetail);
        }

        /// <summary>
        /// Gets JT_WorkTicket records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_WorkTicket/{filterType}")]
        [HttpGet]
        public List<JT_WorkTicket> GetJT_WorkTicket(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_WorkTicket records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_WorkTicket")]
        [HttpGet]
        public List<JT_WorkTicket> GetAllJT_WorkTicket()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketAll();
        }

        /// <summary>
        /// Gets JT_WorkTicketAttachment records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_WorkTicketAttachment/{filterType}")]
        [HttpGet]
        public List<JT_WorkTicketAttachment> GetJT_WorkTicketAttachment(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketAttachmentFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_WorkTicketAttachment records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_WorkTicketAttachment")]
        [HttpGet]
        public List<JT_WorkTicketAttachment> GetAllJT_WorkTicketAttachment()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketAttachmentAll();
        }

        /// <summary>
        /// Gets JT_WorkTicketClass records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_WorkTicketClass/{filterType}")]
        [HttpGet]
        public List<JT_WorkTicketClass> GetJT_WorkTicketClass(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketClassFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_WorkTicketClass records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_WorkTicketClass")]
        [HttpGet]
        public List<JT_WorkTicketClass> GetAllJT_WorkTicketClass()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketClassAll();
        }

        /// <summary>
        /// Gets JT_WorkTicketHistory records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_WorkTicketHistory/{filterType}")]
        [HttpGet]
        public List<JT_WorkTicketHistory> GetJT_WorkTicketHistory(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketHistoryFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_WorkTicketHistory records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_WorkTicketHistory")]
        [HttpGet]
        public List<JT_WorkTicketHistory> GetAllJT_WorkTicketHistory()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketHistoryAll();
        }

        /// <summary>
        /// Gets JT_WorkTicketText records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_WorkTicketText/{filterType}")]
        [HttpGet]
        public List<JT_WorkTicketText> GetJT_WorkTicketText(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketTextFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_WorkTicketText records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_WorkTicketText")]
        [HttpGet]
        public List<JT_WorkTicketText> GetAllJT_WorkTicketText()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_WorkTicketTextAll();
        }

        /// <summary>
        /// Gets SO_SalesOrderHeader records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/SO_SalesOrderHeader/{filterType}")]
        [HttpGet]
        public List<SO_SalesOrderHeader> GetSO_SalesOrderHeader(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_SalesOrderHeaderFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all SO_SalesOrderHeader records
        /// </summary>
        /// <returns></returns>
        [Route("all/SO_SalesOrderHeader")]
        [HttpGet, HttpPost]
        public List<SO_SalesOrderHeader> GetAllSO_SalesOrderHeader()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_SalesOrderHeaderAll();
        }

        /// <summary>
        /// Gets SO_ShipToAddress records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/SO_ShipToAddress/{filterType}")]
        [HttpGet]
        public List<SO_ShipToAddress> GetSO_ShipToAddress(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_ShipToAddressFiltered(filterType, v);
        }

        /// <summary>
        /// Gets SO_ShipToAddress records by filter with post
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="filterTextEncoded"></param>
        /// <returns></returns>
        [Route("q/SO_ShipToAddress/{filterType}")]
        [HttpPost]
        public List<SO_ShipToAddress> GetSO_ShipToAddressPost(string filterType, [FromBody] string filterTextEncoded)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }

            // dch rkl 01/31/2017 Decode filter text
            if (filterTextEncoded.Trim().Length > 0)
            {
                filterTextEncoded = System.Web.HttpUtility.UrlDecode(filterTextEncoded);
            }

            List<SO_ShipToAddress> shipToAddresses = new List<SO_ShipToAddress>();
            if (filterType == "where")
            {
                filterTextEncoded = filterTextEncoded.Replace("eq", "==");
                filterTextEncoded = filterTextEncoded.Replace("ne", "!=");
                filterTextEncoded = filterTextEncoded.Replace("'", "\"");
                shipToAddresses = tdws.GetSDataForSO_ShipToAddressAll().Where(filterTextEncoded).ToList();
            }
            else
            {
                shipToAddresses = tdws.GetSDataForSO_ShipToAddressFilteredRest(filterType, filterTextEncoded);
            }
            return shipToAddresses;
        }

        /// <summary>
        /// Gets all SO_ShipToAddress records
        /// </summary>
        /// <returns></returns>
        [Route("all/SO_ShipToAddress")]
        [HttpGet, HttpPost]
        public List<SO_ShipToAddress> GetAllSO_ShipToAddress()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForSO_ShipToAddressAll();
        }

        // dch rkl 11/03/2016 Add JT_TimeTrackerOptions BEGIN
        /// <summary>
        /// Gets JT_TimeTrackerOptions records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/JT_TimeTrackerOptions/{filterType}")]
        [HttpGet]
        public List<JT_TimeTrackerOptions> GetJT_TimeTrackerOptions(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TimeTrackerOptionsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_TimeTrackerOptions records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_TimeTrackerOptions")]
        [HttpGet]
        public List<JT_TimeTrackerOptions> GetAllJT_TimeTrackerOptions()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForJT_TimeTrackerOptionsAll();
        }
        // dch rkl 11/03/2016 Add JT_TimeTrackerOptions END

        // dch rkl 12/01/2016 Add IM_Warehouse BEGIN
        /// <summary>
        /// Gets IM_Warehouse records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/IM_Warehouse/{filterType}")]
        [HttpGet]
        public List<IM_Warehouse> GetIM_Warehouse(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForIM_WarehouseFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all IM_Warehouse records
        /// </summary>
        /// <returns></returns>
        [Route("all/IM_Warehouse")]
        [HttpGet]
        public List<IM_Warehouse> GetAllIM_Warehouse()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForIM_WarehouseAll();
        }
        // dch rkl 12/01/2016 Add IM_Warehouse END

        // dch rkl 12/07/2016 Add ApplicationLog POST
        /// <summary>
        /// Inserts a new ApplicationLog record
        /// </summary>
        /// <param name="appLog"></param>
        /// <returns></returns>
        [Route("i/ApplicationLog")]
        [HttpPost]
        public bool InsertApplicationLog([FromBody]ApplicationLog appLog)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            DBMapper oDBMap = new DataAccess.DBMapper();
            return oDBMap.InsertError(appLog);
        }

        // dch rkl 01/13/2017 Add CI_ExtendedDescription BEGIN
        /// <summary>
        /// Gets CI_ExtendedDescription records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/CI_ExtendedDescription/{filterType}")]
        [HttpGet]
        public List<CI_ExtendedDescription> GetCI_ExtendedDescription(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_ExtendedDescriptionFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all CI_ExtendedDescription records
        /// </summary>
        /// <returns></returns>
        [Route("all/CI_ExtendedDescription")]
        [HttpGet]
        public List<CI_ExtendedDescription> GetAllCI_ExtendedDescription()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_ExtendedDescriptionAll();
        }
        // dch rkl 01/13/2017 Add CI_ExtendedDescription END

        // dch rkl 01/20/2017 Added CI_UnitOfMeasure table BEGIN
        /// <summary>
        /// Gets CI_UnitOfMeasure records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/CI_UnitOfMeasure/{filterType}")]
        [HttpGet]
        public List<CI_UnitOfMeasure> GetCI_UnitOfMeasure(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_UnitOfMeasureFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all CI_UnitOfMeasure records
        /// </summary>
        /// <returns></returns>
        [Route("all/CI_UnitOfMeasure")]
        [HttpGet]
        public List<CI_UnitOfMeasure> GetAllCI_UnitOfMeasure()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForCI_UnitOfMeasureAll();
        }
        // dch rkl 01/20/2017 Added CI_UnitOfMeasure table END

        // dch rkl 01/23/2017 Added AR_Options table BEGIN
        /// <summary>
        /// Gets AR_Options records by filter
        /// </summary>
        /// <param name="filterType">filter type</param>
        /// <param name="v">filter body</param>
        /// <returns></returns>
        [Route("q/AR_Options/{filterType}")]
        [HttpGet]
        public List<AR_Options> GetAR_Options(string filterType, [FromUri] string v)
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForAR_OptionsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all AR_Options records
        /// </summary>
        /// <returns></returns>
        [Route("all/AR_Options")]
        [HttpGet]
        public List<AR_Options> GetAllAR_Options()
        {
            if (Properties.Settings.Default.isUsingDeviceAuthentication)
            {
                if (!tdws.ValidateAuthentication(this.Request))
                    throw new Exception("Invalid authorization on call");
            }
            return tdws.GetSDataForAR_OptionsAll();
        }
        // dch rkl 01/20/2017 Added CI_UnitOfMeasure table END
    }
}
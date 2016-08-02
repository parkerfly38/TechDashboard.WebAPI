﻿using Rkl.Erp.Sage.Sage100.TableObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TechDashboardWEBAPI.ServiceCode;
using System.Web.Http.Description;

namespace TechDashboardWEBAPI.Controllers
{
    /// <summary>
    /// Version 1 REST api for Job Ops Tech Dashboard
    /// </summary>
    [RoutePrefix("v1")]
    public class v1Controller : ApiController
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
        /// Get AR_Customer by varying criteria.
        /// </summary>
        /// <param name="filterType">clause for query</param>
        /// <param name="v">body of filter clause</param>
        /// <returns>AR_Customer</returns>
        [Route("q/AR_Customer/{filterType}")]
        [HttpGet]
        public List<AR_Customer> GetAR_Customer(string filterType, [FromUri] string v)
        {
            return tdws.GetSDataForAR_CustomerFiltered(filterType, v);
        }

        /// <summary>
        /// Get all AR_Customer records
        /// </summary>
        /// <returns>AR_Customer</returns>
        [Route("all/AR_Customer")]
        public List<AR_Customer> GetAllAR_Customer()
        {
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
            return tdws.GetSDataForAR_CustomerContactFiltered(filterType, v);
        }

        /// <summary>
        /// All AR_CustomerContact records
        /// </summary>
        /// <returns></returns>
        [Route("all/AR_CustomerContact")]
        public List<AR_CustomerContact> GetAllAR_CustomerContact()
        {
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
            return tdws.GetSDataForIM_ItemWarehouseAll();
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
            return tdws.GetSDataForJT_OptionsAll();
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
            return tdws.GetSDataForJT_ServiceAgreementDetailFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_ServiceAgreementDetail records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ServiceAgreementDetail")]
        [HttpGet]
        public List<JT_ServiceAgreementDetail> GetAllJT_ServiceAgreementDetail()
        {
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
            return tdws.GetSDataForJT_ServiceEquipmentPartsFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all JT_ServiceEquipmentParts records
        /// </summary>
        /// <returns></returns>
        [Route("all/JT_ServiceEquipmentParts")]
        [HttpGet]
        public List<JT_ServiceEquipmentParts> GetAllJT_ServiceEquipmentPartsl()
        {
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
            return tdws.GetSDataForJT_TransactionImportDetailAll();
        }

        /// <summary>
        /// Inserts a new JT_TransactionImportDetail record
        /// </summary>
        /// <param name="importDetail"></param>
        /// <returns></returns>
        [Route("i/JT_TransactionImportDetail")]
        [HttpPost]
        public bool InsertJT_TransactionImportDetail([FromBody]JT_TransactionImportDetail importDetail)
        {
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
            return tdws.GetSDataForSO_SalesOrderHeaderFiltered(filterType, v);
        }

        /// <summary>
        /// Gets all SO_SalesOrderHeader records
        /// </summary>
        /// <returns></returns>
        [Route("all/SO_SalesOrderHeader")]
        [HttpGet]
        public List<SO_SalesOrderHeader> GetAllSO_SalesOrderHeader()
        {
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
            return tdws.GetSDataForSO_ShipToAddressFilteredRest(filterType, filterTextEncoded);
        }

        /// <summary>
        /// Gets all SO_ShipToAddress records
        /// </summary>
        /// <returns></returns>
        [Route("all/SO_ShipToAddress")]
        public List<SO_ShipToAddress> GetAllSO_ShipToAddress()
        {
            return tdws.GetSDataForSO_ShipToAddressAll();
        }
    }
}
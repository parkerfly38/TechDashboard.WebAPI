using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Common;
using TechDashboardWEBAPI.Models;
using Dapper;

namespace TechDashboardWEBAPI.DataAccess
{
    public class DBMapper
    {
        public string GetDeviceIdByName(string device)
        {
            string sql = @"SELECT id FROM ApplicationDevices WHERE DeviceData = @deviceData";
            var parameters = new { deviceData = device };

            Guid deviceId;

            try
            {
                using (DbConnection connection = ConnectionFactory.GetOpenConnection())
                {
                    deviceId = connection.Query<Guid>(sql, parameters).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                throw;
            }

            if (deviceId == Guid.Empty)
                deviceId = Guid.Parse(InsertDevice(device));

            return deviceId.ToString();

        }
        public bool ValidateDevice(Guid deviceId)
        {
            string sql = "SELECT Verified FROM ApplicationDevices WHERE id = @id";
            var parameters = new { id = deviceId };

            bool validated = false;
            try
            {
                using (DbConnection connection = ConnectionFactory.GetOpenConnection())
                {
                    validated = connection.Query<bool>(sql, parameters).DefaultIfEmpty(false).First();
                }
            }
            catch (Exception exception)
            {
                //
            }

            return validated;
        }

        public string InsertDevice(string device)
        {
            string sql = @"INSERT INTO ApplicationDevices(DeviceData, Verified) OUTPUT INSERTED.id VALUES (@deviceData, 0)";
            var parameters = new { deviceData = device };

            Guid deviceId;

            try
            {
                using (DbConnection connection = ConnectionFactory.GetOpenConnection())
                {
                    deviceId = connection.Query<Guid>(sql, parameters).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                throw;
            }
            return deviceId.ToString();
        }

        public string returnValidatedDeviceId(string device)
        {
            string sql = @"SELECT id FROM ApplicationDevices WHERE DeviceData = @deviceData and Verified = 1";
            var parameters = new { deviceData = device };

            Guid deviceId;

            try
            {
                using (DbConnection connection = ConnectionFactory.GetOpenConnection())
                {
                    deviceId = connection.Query<Guid>(sql, parameters).FirstOrDefault();
                }
            }
            catch (Exception exception)
            {
                throw;
            }

            return deviceId.ToString();
        }

        // dch rkl 12/07/2016 return true/false
        public bool InsertError(ApplicationLog appLog)
        //public void InsertError(ApplicationLog appLog)
        {
            bool bSuccess = false;

            try
            {
                string sql = @"insert into ApplicationLog(log_date,log_level,log_logger,log_message,log_machine_name, log_user_name, log_call_site, log_thread, log_exception, log_stacktrace) 
                            values(@time_stamp, @level, @logger, @message,@machinename, @user_name, @call_site, @threadid, @log_exception, @stacktrace)";

                var parameters = new
                {
                    time_stamp = appLog.log_date,
                    level = appLog.log_level,
                    logger = appLog.log_logger,
                    message = appLog.log_message,
                    machinename = appLog.log_machine_name,
                    user_name = appLog.log_user_name,
                    call_site = appLog.log_call_site,
                    threadid = appLog.log_thread,
                    log_exception = appLog.log_exception,
                    stacktrace = appLog.log_stacktrace
                };

                try
                {
                    using (DbConnection connection = ConnectionFactory.GetOpenConnection())
                    {
                        connection.Execute(sql, parameters);
                        bSuccess = true;
                    }
                }
                catch (Exception exception)
                {
                    Console.Write(exception.Message);
                }
            }
            catch (Exception ex)
            {

            }

            return bSuccess;
        }
    }
}
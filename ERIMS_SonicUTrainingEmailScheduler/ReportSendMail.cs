using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Data.Common;

namespace ERIMS_SonicUTraining_EmailScheduler
{
    class ReportSendMail
    {
        #region Public Variables

        public static String strConn = String.Empty;

        #endregion

        #region Report Methods

        /// <summary>
        /// get data for E-mail to employee and Administrator for the remaining Training
        /// </summary>
        /// <returns></returns>
        public static DataSet GetEmployeeTrainingData()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("SendMailforTrainingData");
          
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get data for E-mail to Early Alert Location Manager for the remaining Training
        /// </summary>
        /// <returns></returns>
        public static DataSet GetEmployeeTrainingDataForReport()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptSonicUTrainingShedulerData");

            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get data for E-mail to Early Alert Location Manager for the remaining Training
        /// </summary>
        /// <returns></returns>
        public static DataSet GetEmployeeTrainingDataForPayRollTrainingReport()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptPayrollTrainingReportData");

            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get List of RLCM users
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRLCMUsers()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("GetAllRlcmWithLocation");

            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get the System Administrator List
        /// </summary>
        /// <returns></returns>
        public static DataSet GetAdminList()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("GetSystemAdministratorList");

            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the LU_Location table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("LU_LocationSelectByPK");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select RLCM Users
        /// </summary>
        /// <param name="fK_Employee_Id"></param>
        /// <returns></returns>
        public static DataSet SelectLocation_By_RLCM(decimal? fK_Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Select_Location_By_RLCM");

            db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, fK_Employee_Id);
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select RLCM Users
        /// </summary>
        /// <param name="fK_Employee_Id"></param>
        /// <returns></returns>
        public static DataSet SelectRegion_By_RLCM(decimal? fK_Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();

            DbCommand dbCommand = db.GetStoredProcCommand("Region_By_RLCM");
            db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, fK_Employee_Id);
            dbCommand.CommandTimeout = 1000;

            return db.ExecuteDataSet(dbCommand);
        }


        /// <summary>
        /// Select RLCM Users
        /// </summary>
        /// <param name="fK_Employee_Id"></param>
        /// <returns></returns>
        public static DataSet SelectAllDepartment()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesSelectDepartments");            
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get data for Percentage Recap
        /// </summary>
        /// <returns></returns>
        public static DataSet GetEmployeeTrainingDataForPercentageRecap()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("rptPercentageRecapData");

            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Certificate Data
        /// </summary>
        /// <returns></returns>
        public static DataSet GetRLCMCertificateData(decimal? fk_Employee_Id, string region, decimal? fk_LU_Market, decimal? pk_LU_Location, decimal? pk_Employee_ID, int? year, int? quarter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("GetCertificateData");

            db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, fk_Employee_Id);
            db.AddInParameter(dbCommand, "Region", DbType.String, region);
            db.AddInParameter(dbCommand, "FK_LU_Market", DbType.Decimal, fk_LU_Market);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pk_LU_Location);
            db.AddInParameter(dbCommand, "PK_Employee_ID", DbType.Decimal, pk_Employee_ID);
            db.AddInParameter(dbCommand, "Year", DbType.Int16, year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Int16, quarter);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// get data for Percentage Recap
        /// </summary>
        /// <returns></returns>
        public static int InsertRCRACertificateSent(DateTime RCRACertificateSentDate)
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("RCRACertificateSentInsert");

            db.AddInParameter(dbCommand, "RCRACertificateSentDate", DbType.Date, RCRACertificateSentDate);

            dbCommand.CommandTimeout = 1000;

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));
            return returnValue;
        }

        /// <summary>
        /// GetLastRCRACertificateSentDate
        /// </summary>
        /// <returns></returns>
        public static DataSet GetLastRCRACertificateSentDate()
        {
            SqlDatabase db = new SqlDatabase(strConn);
            DbCommand dbCommand = db.GetStoredProcCommand("GetLastRCRACertificateSentDate");
            dbCommand.CommandTimeout = 1000;
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects Security Data
        /// </summary>
        /// <returns></returns>
        public static DataSet SelectEmployeeData()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SelectFROIList");

            return db.ExecuteDataSet(dbCommand);
        }
        
        
        #endregion
    }
}

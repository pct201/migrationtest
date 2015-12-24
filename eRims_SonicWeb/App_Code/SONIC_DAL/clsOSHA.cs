using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for clsOSHA
    /// </summary>
    public sealed class clsOSHA
    {
        public clsOSHA()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        ///<summary>
        ///OSHA 300 Form Data 
        ///</summary>
        ///
        public static DataSet GetReportOSHA300(int year, int page_size, decimal fK_Employee_ID, decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand;
            dbCommand = db.GetStoredProcCommand("rptOSHA300_and_300A");
            db.AddInParameter(dbCommand, "ReportYear", DbType.Int32, year);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, page_size);
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, fK_Employee_ID);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        ///<summary>
        ///OSHA 300 Form Data 
        ///</summary>
        ///
        public static DataSet GetReportOSHA301(DateTime dtIncident_Begin_Date, DateTime dtIncident_End_Date, decimal fK_Employee_ID, decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand;
            dbCommand = db.GetStoredProcCommand("rptOSHA301");
            db.AddInParameter(dbCommand, "Incident_Begin_Date", DbType.DateTime, dtIncident_Begin_Date);
            db.AddInParameter(dbCommand, "Incident_End_Date", DbType.DateTime, dtIncident_End_Date);
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, fK_Employee_ID);
            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        ///<summary>
        ///Select data by Location
        ///</summary>
        ///
        public static DataSet SelectByPKLocation(decimal pK_LU_Location_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("OSHASelect");

            db.AddInParameter(dbCommand, "PK_LU_Location_ID", DbType.Decimal, pK_LU_Location_ID);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
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
        public static DataSet GetReportOSHA300(int Year, int page_size, decimal FK_Employee_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand;
            dbCommand = db.GetStoredProcCommand("rptOSHA300_and_300A");
            db.AddInParameter(dbCommand, "ReportYear", DbType.Int32, Year);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, page_size);
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, FK_Employee_ID);
            return db.ExecuteDataSet(dbCommand);
        }

        ///<summary>
        ///OSHA 300 Form Data 
        ///</summary>
        ///
        public static DataSet GetReportOSHA301(DateTime dtIncident_Begin_Date, DateTime dtIncident_End_Date, decimal FK_Employee_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand;
            dbCommand = db.GetStoredProcCommand("rptOSHA301");
            db.AddInParameter(dbCommand, "Incident_Begin_Date", DbType.DateTime, dtIncident_Begin_Date);
            db.AddInParameter(dbCommand, "Incident_End_Date", DbType.DateTime, dtIncident_End_Date);
            db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, FK_Employee_ID);
            return db.ExecuteDataSet(dbCommand);
        }
    }
}
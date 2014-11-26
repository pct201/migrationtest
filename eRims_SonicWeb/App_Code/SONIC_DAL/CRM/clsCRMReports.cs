using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
/// <summary>
/// Summary description for clsCRMReports
/// </summary>
public class clsCRMReports
{
	public clsCRMReports()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static DataSet GetCustomerIncidentSummary(int intYear, string strFK_LU_Location)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptCustomerIncidentSummary");
        db.AddInParameter(dbCommand, "Year", DbType.String, intYear.ToString());
        db.AddInParameter(dbCommand, "strFK_LU_Location", DbType.String, strFK_LU_Location);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetNonCustomerInquiryData(int intYear, string strFK_LU_Location)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptNonCustomerInquiry");
        db.AddInParameter(dbCommand, "Year", DbType.String, intYear.ToString());
        db.AddInParameter(dbCommand, "strFK_LU_Location", DbType.String, strFK_LU_Location);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetIncidentTotalsByDealership(DateTime? dtBegin, DateTime? dtEnd, string strFK_LU_Location)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptIncidentTotalsByDealership");
        db.AddInParameter(dbCommand, "Begin_Date", DbType.DateTime, dtBegin);
        db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, dtEnd);
        db.AddInParameter(dbCommand, "strFK_LU_Location", DbType.String, strFK_LU_Location);

        return db.ExecuteDataSet(dbCommand);
    }
}
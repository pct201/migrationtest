using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


/// <summary>
/// Summary description for clsNewUserApprovedDeniedReport
/// </summary>
public class clsNewUserApprovedDeniedReport
{
	public clsNewUserApprovedDeniedReport()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    #region Report

    public static DataSet GetNewUserApprovedDeniedReport(DateTime DateApproved, DateTime DateDenied)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestApprovedDeniedReport");
        db.AddInParameter(dbCommand, "DateApproved", DbType.DateTime, DateApproved);
        db.AddInParameter(dbCommand, "DateDenied", DbType.DateTime, DateDenied);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetTerminatedInactiveUsersReport(DateTime DateApproved, DateTime DateDenied)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("U_A_RequestTerminatedInactiveReport");
        db.AddInParameter(dbCommand, "DateApproved", DbType.DateTime, DateApproved);
        db.AddInParameter(dbCommand, "DateDenied", DbType.DateTime, DateDenied);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetVOCReport(int StartYear,int EndYear,int StartMonth,int EndMonth,decimal Location)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("VOCReport");
        db.AddInParameter(dbCommand, "StartYear", DbType.Int16, StartYear);
        db.AddInParameter(dbCommand, "EndYear", DbType.Int16, EndYear);
        db.AddInParameter(dbCommand, "StartMonth", DbType.Int16, StartMonth);
        db.AddInParameter(dbCommand, "EndMonth", DbType.Int16, EndMonth);
        db.AddInParameter(dbCommand, "Location", DbType.Int32, Location);
        return db.ExecuteDataSet(dbCommand);
    }


    #endregion
}
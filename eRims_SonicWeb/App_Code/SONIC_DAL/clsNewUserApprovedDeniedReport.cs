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


    #endregion
}
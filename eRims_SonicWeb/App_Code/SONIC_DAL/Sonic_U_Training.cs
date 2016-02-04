using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

/// <summary>
/// Summary description for Sonic_U_Training
/// </summary>
public class Sonic_U_Training
{
	public Sonic_U_Training()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// select by search criteria
    /// </summary>
    /// <returns></returns>
    public static DataSet Associate_Training_Search(decimal Associate, int year, int quarter)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Sonic_University_Training_Data");
        db.AddInParameter(dbCommand, "FK_Employee_ID", DbType.Decimal, Associate);
        db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
        db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);

        return db.ExecuteDataSet(dbCommand);
    }

    public static  void Manage_Training_Data_InsertUpdate(string Employee_Id,string Code, int year, int quarter, decimal FK_Employee, string Class_Name, bool Completed)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Manage_Training_Data_InsertUpdate");
        db.AddInParameter(dbCommand, "Employee_Id", DbType.String, Employee_Id);
        db.AddInParameter(dbCommand, "Code", DbType.String, Code);
        db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
        db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
        db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, FK_Employee);
        db.AddInParameter(dbCommand, "Class_Name", DbType.String, Class_Name);
        db.AddInParameter(dbCommand, "Completed", DbType.Boolean, Completed);

        db.ExecuteNonQuery(dbCommand);
    }

    public static void Complete_Sonic_U_Training(int year, int quarter, decimal fK_Employee,string code,  bool completed)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Complete_Sonic_U_Training");
        db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
        db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
        db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, fK_Employee);
        db.AddInParameter(dbCommand, "Code", DbType.String, code);
        db.AddInParameter(dbCommand, "Completed", DbType.Boolean, completed);

        db.ExecuteNonQuery(dbCommand);
    }

    public static DataSet Associate_Training_Data(int quarter, string dba,int year)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Associate_Training_Data");
        db.AddInParameter(dbCommand, "Quarter", DbType.Int32, quarter);
        db.AddInParameter(dbCommand, "dba", DbType.String, dba);
        db.AddInParameter(dbCommand, "year", DbType.Int32, year);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet Learning_Program()
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Learning_Program_Curr_Quarter");

        return db.ExecuteDataSet(dbCommand);
    }
}
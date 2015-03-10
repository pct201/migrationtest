using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERIMS.DAL;

/// <summary>
/// Summary description for Audit_Trail
/// </summary>
public class Audit_Trail
{
    /// <summary>
    /// Default Constructor
    /// </summary>
    public Audit_Trail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetWorkers_Comp_RMW_Audit(decimal PK_Workers_Comp_RMW)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Workers_Comp_RMW_AuditView");

        db.AddInParameter(dbCommand, "PK_Workers_Comp_RMW", DbType.Decimal, PK_Workers_Comp_RMW);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAuto_Loss_RMW_Audit(decimal PK_Auto_Loss_RMW)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Auto_Loss_RMW_AuditView");

        db.AddInParameter(dbCommand, "PK_Auto_Loss_RMW", DbType.Decimal, PK_Auto_Loss_RMW);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPremises_Loss_RMW_Audit(decimal PK_Premises_Loss_RMW)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Premises_Loss_RMW_AuditView");

        db.AddInParameter(dbCommand, "PK_Premises_Loss_RMW", DbType.Decimal, PK_Premises_Loss_RMW);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    ///  get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Notes"></param>
    /// <returns></returns>
    public static DataSet GetSonicNotes_Audit(decimal PK_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SonicNote_AuditView");

        db.AddInParameter(dbCommand, "PK_Notes", DbType.Decimal, PK_Notes);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAP_AL_FROIs_Audit(decimal PK_AP_AL_FROIs)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_AL_FROIs_Audit_View");

        db.AddInParameter(dbCommand, "PK_AP_AL_FROIs", DbType.Decimal, PK_AP_AL_FROIs);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAP_Property_Security_Audit(decimal PK_AP_Property_Security)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_View");

        db.AddInParameter(dbCommand, "PK_AP_Property_Security", DbType.Decimal, PK_AP_Property_Security);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAP_Cal_Atlantic_Audit(decimal PK_AP_Cal_Atlantic)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_Cal_Atlantic_View");
        db.AddInParameter(dbCommand, "PK_AP_Cal_Atlantic", DbType.Decimal, PK_AP_Cal_Atlantic);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_AP_Fraud_Events"></param>
    /// <returns></returns>
    public static DataSet GetAP_Fraud_Events_Audit(decimal PK_AP_Fraud_Events)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_Fraud_Events_View");
        db.AddInParameter(dbCommand, "PK_AP_Fraud_Events", DbType.Decimal, PK_AP_Fraud_Events);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAP_FE_Notes_Audit(decimal pK_AP_FE_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_Notes_Audit_View");
        db.AddInParameter(dbCommand, "PK_AP_FE_Notes", DbType.Decimal, pK_AP_FE_Notes);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAP_FE_PA_Notes_Audit(decimal pK_AP_FE_PA_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_PA_Notes_Audit_View");
        db.AddInParameter(dbCommand, "PK_AP_FE_PA_Notes", DbType.Decimal, pK_AP_FE_PA_Notes);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAP_FE_Transactions_Audit(decimal pK_AP_FE_Transactions)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_FE_Transaction_Audit_View");
        db.AddInParameter(dbCommand, "PK_AP_FE_Transactions", DbType.Decimal, pK_AP_FE_Transactions);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// ACI Event Audit pop up data bind
    /// </summary>
    /// <param name="PK_Event"></param>
    /// <returns></returns>
    public static DataSet GetEvent_AuditTrail(decimal PK_Event)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Event_Audit_View");
        db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, PK_Event);
        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetEvent_AuditTrail_New(decimal PK_Event)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Event_Audit_View_New");
        db.AddInParameter(dbCommand, "PK_Event", DbType.Decimal, PK_Event);
        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetManagement_AuditTrail(decimal PK_Management)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Management_Audit_View");
        db.AddInParameter(dbCommand, "PK_Management", DbType.Decimal, PK_Management);
        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetAP_Notes_AuditTrail(decimal PK_Management)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_Notes_AuditView");
        db.AddInParameter(dbCommand, "PK_Notes", DbType.Decimal, PK_Management);
        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetCOI_Notes_AuditTrail(decimal PK_Management)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("COI_Notes_AuditView");
        db.AddInParameter(dbCommand, "PK_COI_Notes", DbType.Decimal, PK_Management);
        dbCommand.CommandTimeout = 10000;
        return db.ExecuteDataSet(dbCommand);
    }
}

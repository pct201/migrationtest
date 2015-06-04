using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using ERIMS.DAL;

/// <summary>
/// Summary description for AuditTrail
/// </summary>
public class AuditTrail
{
    public AuditTrail()
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
    public static DataSet GetExecutive_Risk_AuditTrial(decimal PK_Executive_Risk)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_AuditView");

        db.AddInParameter(dbCommand, "PK_Executive_Risk", DbType.Decimal, PK_Executive_Risk);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetExecutive_Risk_Carrier_AuditTrial(decimal PK_Executive_Risk_Carrier)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_Carrier_AuditView");

        db.AddInParameter(dbCommand, "PK_Executive_Risk_Carrier", DbType.Decimal, PK_Executive_Risk_Carrier);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetDefense_Attorney_AuditTrial(decimal PK_Defense_Attorney)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Defense_Attorney_AuditView");

        db.AddInParameter(dbCommand, "PK_Defense_Attorney", DbType.Decimal, PK_Defense_Attorney);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPlaintiff_Attorney_AuditTrial(decimal PK_Plaintiff_Attorney)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Plaintiff_Attorney_AuditView");

        db.AddInParameter(dbCommand, "PK_Plaintiff_Attorney", DbType.Decimal, PK_Plaintiff_Attorney);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetExecutive_Risk_Expenses_AuditTrial(decimal PK_Executive_Risk_Expenses)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_Expenses_AuditView");

        db.AddInParameter(dbCommand, "PK_Executive_Risk_Expenses", DbType.Decimal, PK_Executive_Risk_Expenses);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetExecutive_Risk_Contacts_AuditTrial(decimal PK_Executive_Risk_Contacts)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Executive_Risk_Contacts_AuditView");

        db.AddInParameter(dbCommand, "PK_Executive_Risk_Contacts", DbType.Decimal, PK_Executive_Risk_Contacts);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetInvestigator_Notes_AuditTrial(decimal PK_Investigator_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Investigator_Notes_AuditView");

        db.AddInParameter(dbCommand, "PK_Investigator_Notes", DbType.Decimal, PK_Investigator_Notes);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetDiary_AuditTrial(decimal PK_Diary_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Diary_AuditView");

        db.AddInParameter(dbCommand, "PK_Diary_ID", DbType.Decimal, PK_Diary_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAdjustor_Notes_AuditTrial(decimal PK_Adjustor_Notes_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Adjustor_Notes_AuditView");

        db.AddInParameter(dbCommand, "PK_Adjustor_Notes_ID", DbType.Decimal, PK_Adjustor_Notes_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetWC_FR_AuditTrial(decimal PK_WC_FR_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("WC_FR_AuditView");

        db.AddInParameter(dbCommand, "PK_WC_FR_ID", DbType.Decimal, PK_WC_FR_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetAL_FR_AuditTrial(decimal PK_AL_FR_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AL_FR_AuditView");

        db.AddInParameter(dbCommand, "PK_AL_FR_ID", DbType.Decimal, PK_AL_FR_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetDPD_FR_AuditTrial(decimal PK_DPD_FR_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_AuditView");

        db.AddInParameter(dbCommand, "PK_DPD_FR_ID", DbType.Decimal, PK_DPD_FR_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetDPD_Witness_AuditTrial(decimal PK_DPD_Witness_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DPD_Witness_AuditView");

        db.AddInParameter(dbCommand, "PK_DPD_Witness_ID", DbType.Decimal, PK_DPD_Witness_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// 
    /// <returns></returns>
    public static DataSet GetDPD_FR_Passenger_AuditTrial(decimal PK_DPD_FR_Injured_Passenger_id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Injured_Passenger_AuditView");

        db.AddInParameter(dbCommand, "PK_DPD_FR_Injured_Passenger_id", DbType.Decimal, PK_DPD_FR_Injured_Passenger_id);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPL_FR_AuditTrial(decimal PK_PL_FR_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("PL_FR_AuditView");

        db.AddInParameter(dbCommand, "PK_PL_FR_ID", DbType.Decimal, PK_PL_FR_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_FR_AuditTrial(decimal PK_Property_FR_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_AuditView");

        db.AddInParameter(dbCommand, "PK_Property_FR_ID", DbType.Decimal, PK_Property_FR_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_FR_BuildingAuditTrial(decimal PK_Property_FR_Building_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_Building_AuditView");

        db.AddInParameter(dbCommand, "PK_Property_FR_Building_ID", DbType.Decimal, PK_Property_FR_Building_ID);

        return db.ExecuteDataSet(dbCommand);
    }
    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_FR_Witness_AuditTrial(decimal PK_Property_FR_Witness_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_FR_Witness_AuditView");

        db.AddInParameter(dbCommand, "PK_Property_FR_Witness_ID", DbType.Decimal, PK_Property_FR_Witness_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetDPD_FR_Vehicle_AuditTrial(decimal PK_DPD_FR_Vehicle_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("DPD_FR_Vehicle_AuditView");

        db.AddInParameter(dbCommand, "PK_DPD_FR_Vehicle_ID", DbType.Decimal, PK_DPD_FR_Vehicle_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetInvestigation_AuditTrial(decimal PK_Investigation_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Investigation_AuditView");

        db.AddInParameter(dbCommand, "PK_Investigation_ID", DbType.Decimal, PK_Investigation_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetWC_Allocation_Charges_AuditTrial(decimal PK_WC_Allocation_Charges)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_AuditView");

        db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges", DbType.Decimal, PK_WC_Allocation_Charges);

        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetWC_Allocation_Charges_ByMarket_AuditTrial(decimal PK_WC_Allocation_Charges)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("WC_Allocation_Charges_ByMarket_AuditView");

        db.AddInParameter(dbCommand, "PK_WC_Allocation_Charges_ByMarket", DbType.Decimal, PK_WC_Allocation_Charges);

        return db.ExecuteDataSet(dbCommand);
    }

    #region "Exposure"

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_Equipment_AuditTrial(decimal PK_Enviro_Equipment_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Equipment_AuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_Equipment_ID", DbType.Decimal, PK_Enviro_Equipment_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_Recommendations_AuditTrail(int PK_Enviro_Equipment_Recommendations_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Recommendations_AuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_Equipment_Recommendations_ID", DbType.Int32, PK_Enviro_Equipment_Recommendations_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_PermitAuditTrail(int PK_Enviro_Permit_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Enviro_PermitAuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, PK_Enviro_Permit_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_InspectionAuditTrail(int PK_Enviro_Inspection_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Inspection_AuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_Inspection_ID", DbType.Int32, PK_Enviro_Inspection_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_SPCCAuditTrail(int PK_Enviro_Inspection_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Enviro_SPCC_AuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_SPCC_ID", DbType.Int32, PK_Enviro_Inspection_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_Phase1AuditTrail(int PK_Enviro_Inspection_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Enviro_Phase1_AuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_Phase1_ID", DbType.Int32, PK_Enviro_Inspection_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetEnviro_EPAAuditTrail(int PK_Enviro_Permit_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("EPA_IDs_AuditView");

        db.AddInParameter(dbCommand, "PK_Enviro_Permit_ID", DbType.Int32, PK_Enviro_Permit_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_COPE_AuditTrail(decimal PK_Property_Cope_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_AuditView");

        db.AddInParameter(dbCommand, "PK_Property_Cope_ID", DbType.Decimal, PK_Property_Cope_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetBuilding_AuditTrail(decimal PK_Building_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_AuditView");

        db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Decimal, PK_Building_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// Get all record from building insurance cope
    /// </summary>
    /// <param name="PK_Building_ID"></param>
    /// <returns></returns>
    public static DataSet GetBuildingInsuranceCOPE_AuditTrail(decimal PK_Building_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("BuildingInsuranceCOPE_AuditView");

        db.AddInParameter(dbCommand, "PK_Building_ID", DbType.Decimal, PK_Building_ID);

        return db.ExecuteDataSet(dbCommand);
    }


    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetBuilding_Ownership_AuditTrail(decimal PK_Building_Ownership_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_AuditView");

        db.AddInParameter(dbCommand, "PK_Building_Ownership_ID", DbType.Decimal, PK_Building_Ownership_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetBuilding_Additional_Insureds_Payees_AuditTrail(decimal PK_Building_Additional_Insureds_Payees_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_Additional_Insureds_Payees_AuditView");

        db.AddInParameter(dbCommand, "PK_Building_Additional_Insureds_Payees_ID", DbType.Decimal, PK_Building_Additional_Insureds_Payees_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetBuilding_Ownership_Sublease_AuditTrail(decimal PK_Building_Ownership_Sublease_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_Ownership_Sublease_AuditView");

        db.AddInParameter(dbCommand, "PK_Building_Ownership_Sublease", DbType.Decimal, PK_Building_Ownership_Sublease_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_Assessment_AuditTrail(decimal PK_Property_Assessment_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_AuditView");

        db.AddInParameter(dbCommand, "PK_Property_Assessment_ID", DbType.Decimal, PK_Property_Assessment_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_Assessment_Concern_AuditTrail(decimal PK_Property_Assessment_Concern_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_Assessment_Concern_AuditView");

        db.AddInParameter(dbCommand, "PK_Property_Assessment_Concern_ID", DbType.Decimal, PK_Property_Assessment_Concern_ID);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetProperty_Contact_AuditTrail(decimal FK_Building_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_Contact_AuditView");

        db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Decimal, FK_Building_ID);

        return db.ExecuteDataSet(dbCommand);
    }


    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetInspection_AuditTrail(decimal PK_Inspection_ID, string Item_Number_Focus_Area)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Inspection_AuditView");

        db.AddInParameter(dbCommand, "PK_Inspection_ID", DbType.Decimal, PK_Inspection_ID);
        db.AddInParameter(dbCommand, "Item_Number_Focus_Area", DbType.String, Item_Number_Focus_Area);

        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetBuilding_Improvements_AuditTrail(decimal PK_Building_Improvements)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_Improvements_AuditView");
        db.AddInParameter(dbCommand, "PK_Building_Improvements", DbType.Decimal, PK_Building_Improvements);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetBuilding_FinancialLimits_AuditTrail(decimal PK_Building_Financial_Limits)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_Financial_Limits_Audit_View");
        db.AddInParameter(dbCommand, "PK_Building_Financial_Limits", DbType.Decimal, PK_Building_Financial_Limits);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetBuilding_GGKL_AuditTrail(decimal PK_Building_GGKL)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Building_GGKL_Audit_View");
        db.AddInParameter(dbCommand, "PK_Building_GGKL", DbType.Decimal, PK_Building_GGKL);
        return db.ExecuteDataSet(dbCommand);
    }


    #endregion

    #region Purchasing
    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPurchasing_Asset_AuditTrial(decimal PK_Purchasing_Asset)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_AuditView");

        db.AddInParameter(dbCommand, "PK_Purchasing_Asset", DbType.Decimal, PK_Purchasing_Asset);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPurchasing_Asset_Notes_AuditTrial(decimal PK_Purchasing_Asset_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Asset_Notes_AuditView");

        db.AddInParameter(dbCommand, "PK_Purchasing_Asset_Notes", DbType.Decimal, PK_Purchasing_Asset_Notes);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPurchasing_LR_Agreement_AuditTrial(decimal PK_Purchasing_LR_Agreement)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Agreement_AuditView");

        db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, PK_Purchasing_LR_Agreement);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPurchasing_Service_Contract_AuditTrial(decimal PK_Purchasing_Service_Contract)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Service_Contract_AuditView");

        db.AddInParameter(dbCommand, "PK_Purchasing_Service_Contract", DbType.Decimal, PK_Purchasing_Service_Contract);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPurchasing_SC_Notes_AuditTrial(decimal PK_Purchasing_SC_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_SC_Notes_AuditView");

        db.AddInParameter(dbCommand, "PK_Purchasing_SC_Notes", DbType.Decimal, PK_Purchasing_SC_Notes);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPurchasing_LR_Notes_AuditTrial(decimal PK_Purchasing_LR_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Notes_AuditView");

        db.AddInParameter(dbCommand, "PK_Purchasing_LR_Notes", DbType.Decimal, PK_Purchasing_LR_Notes);

        return db.ExecuteDataSet(dbCommand);
    }
    #endregion

    #region Policy
    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPolicy_AuditView(decimal PK_Policy_Id)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Policy_AuditView");

        db.AddInParameter(dbCommand, "PK_Policy_Id", DbType.Decimal, PK_Policy_Id);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetPolicyFeature_AuditView(decimal PK_Policy_Features)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Policy_Features_AuditView");

        db.AddInParameter(dbCommand, "PK_Policy_Features", DbType.Decimal, PK_Policy_Features);

        return db.ExecuteDataSet(dbCommand);
    }
    #endregion

    #region " LEASE "

    public static DataSet GetRE_Subtenant_TRS_AuditTrail(decimal pk_RE_Subtenant_TRS)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_TRS_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Subtenant_TRS", DbType.Decimal, pk_RE_Subtenant_TRS);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_SubTenant_ORS_AuditTrail(decimal pk_RE_SubTenant_ORS)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_SubTenant_ORS_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_SubTenant_ORS", DbType.Decimal, pk_RE_SubTenant_ORS);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Rent_Projctions_TRS_AuditTrail(decimal pk_RE_Rent_Projctions_TRS)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_Projctions_TRS_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Rent_Projctions_TRS", DbType.Decimal, pk_RE_Rent_Projctions_TRS);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Rent_Projctions_ORS_AuditTrail(decimal pk_RE_Rent_Projections_ORS)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_Projections_ORS_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Rent_Projections_ORS", DbType.Decimal, pk_RE_Rent_Projections_ORS);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Repair_Maintenance_AuditTrail(decimal pk_RE_Repair_Maintenance)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Repair_Maintenance_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Repair_Maintenance", DbType.Decimal, pk_RE_Repair_Maintenance);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Notes_AuditTrail(decimal pk_RE_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Notes_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Notes", DbType.Decimal, pk_RE_Notes);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Information_AuditTrail(decimal pk_RE_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Information_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Information", DbType.Decimal, pk_RE_Notes);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Subtenant_AuditTrail(decimal pK_RE_Subtenant)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Subtenant_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Subtenant", DbType.Decimal, pK_RE_Subtenant);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Rent_Projections_AuditTrail(decimal pK_RE_Rent_Projections)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_Projections_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Rent_Projections", DbType.Decimal, pK_RE_Rent_Projections);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Security_Deposit_AuditTrail(decimal pK_RE_Security_Deposit)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Security_Deposit_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Security_Deposit", DbType.Decimal, pK_RE_Security_Deposit);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Surrender_Obligations_AuditTrail(decimal pK_RE_Surrender_Obligations)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Surrender_Obligations_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Surrender_Obligations", DbType.Decimal, pK_RE_Surrender_Obligations);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Notices_AuditTrail(decimal pK_RE_Notices)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Notices_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Notices", DbType.Decimal, pK_RE_Notices);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Rent_AuditTrail(decimal pK_RE_Rent)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Rent", DbType.Decimal, pK_RE_Rent);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Rent_TRS_AuditTrail(decimal pK_RE_Rent_TRS)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_TRS_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Rent_TRS", DbType.Decimal, pK_RE_Rent_TRS);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetRE_Rent_RRS_AuditTrail(decimal pK_RE_Rent_RRS)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("RE_Rent_RRS_AuditView");
        db.AddInParameter(dbCommand, "PK_RE_Rent_RRS", DbType.Decimal, pK_RE_Rent_RRS);
        return db.ExecuteDataSet(dbCommand);
    }
    #endregion

    public static DataSet GetSabaTrainingAuditTrail(decimal PK_Property_COPE_Saba_Training)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Property_COPE_Saba_Training_Audit_View");

        db.AddInParameter(dbCommand, "PK_Property_COPE_Saba_Training", DbType.Int32, PK_Property_COPE_Saba_Training);

        return db.ExecuteDataSet(dbCommand);

    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetFranchise_AuditTrial(decimal PK_Franchise)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Franchise_AuditView");
        db.AddInParameter(dbCommand, "PK_Franchise", DbType.Decimal, PK_Franchise);
        return db.ExecuteDataSet(dbCommand);
    }
    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetFranchise_Improvements_AuditTrial(decimal PK_Franchise_Improvements)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Franchise_Improvements_AuditView");
        db.AddInParameter(dbCommand, "PK_Franchise_Improvements", DbType.Decimal, PK_Franchise_Improvements);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetCRM_Non_Customer_AuditTrial(decimal PK_CRM_Non_Customer)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_Customer_AuditView");
        db.AddInParameter(dbCommand, "PK_CRM_Non_Customer", DbType.Decimal, PK_CRM_Non_Customer);
        return db.ExecuteDataSet(dbCommand);
    }
    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetCRM_Non_Customer_Notes_AuditTrial(decimal PK_CRM_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("CRM_Non_Customer_Notes_AuditView");
        db.AddInParameter(dbCommand, "PK_CRM_Notes", DbType.Decimal, PK_CRM_Notes);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all record from audit table for a passed key
    /// </summary>
    /// <param name="PK_Case"></param>
    /// <returns></returns>
    public static DataSet GetCRM_Customer_AuditTrial(decimal PK_CRM_Customer)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("CRM_Customer_AuditView");
        db.AddInParameter(dbCommand, "PK_CRM_Customer", DbType.Decimal, PK_CRM_Customer);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetIncidentInvolvement_AuditTrial(decimal PK_FR_PL_Involvement)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("FR_PL_Involvement_AuditView");
        db.AddInParameter(dbCommand, "PK_FR_PL_Involvement", DbType.Decimal, PK_FR_PL_Involvement);
        return db.ExecuteDataSet(dbCommand);
    }

    #region " SLT "

    public static DataSet GetSLT_Meeting_AuditTrial(decimal PK_SLT_Meeting)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Meeting", DbType.Decimal, PK_SLT_Meeting);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSLT_Incident_Review_AuditTrial(decimal PK_SLT_Incident_Review)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Incident_Review_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Incident_Review", DbType.Decimal, PK_SLT_Incident_Review);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSLT_Members_AuditTrial(decimal PK_SLT_Members)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Members_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Members", DbType.Decimal, PK_SLT_Members);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSLT_Meeting_Schedule_AuditTrial(decimal PK_SLT_Meeting_Schedule)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Meeting_Schedule_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Meeting_Schedule", DbType.Decimal, PK_SLT_Meeting_Schedule);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSLT_Quarterly_Inspections_AuditTrial(decimal PK_SLT_Quarterly_Inspections)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Quarterly_Inspections_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Quarterly_Inspections", DbType.Decimal, PK_SLT_Quarterly_Inspections);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSLT_Training_AuditTrial(decimal PK_SLT_Training)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Training_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Training", DbType.Decimal, PK_SLT_Training);
        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetSLT_New_Procedure_AuditTrial(decimal PK_SLT_New_Procedure)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_New_Procedure_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_New_Procedure", DbType.Decimal, PK_SLT_New_Procedure);
        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetSLT_Suggestion_AuditTrial(decimal PK_SLT_Suggestion)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Suggestion_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Suggestion", DbType.Decimal, PK_SLT_Suggestion);
        return db.ExecuteDataSet(dbCommand);
    }

    public static DataSet GetSLT_Safety_Walk_AuditTrial(decimal PK_SLT_Safety_Walk)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk", DbType.Decimal, PK_SLT_Safety_Walk);
        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetSLT_Safety_Walk_Responses_AuditTrial(decimal PK_SLT_Safety_Walk_Responses)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("SLT_Safety_Walk_Responses_AuditView");
        db.AddInParameter(dbCommand, "PK_SLT_Safety_Walk_Responses", DbType.Decimal, PK_SLT_Safety_Walk_Responses);
        return db.ExecuteDataSet(dbCommand);
    }
    public static DataSet GetSedgwick_Claim_Review_AuditTrial(decimal PK_SLT_Safety_Walk_Responses)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Sedgwick_Claim_Review_AuditView");
        db.AddInParameter(dbCommand, "PK_Sedgwick_Claim_Review", DbType.Decimal, PK_SLT_Safety_Walk_Responses);
        return db.ExecuteDataSet(dbCommand);
    }
    #endregion


    #region " Project Management "
    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetProjectManagement_AuditTrial(decimal PK_EPM_Identification)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("ProjectManagement_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetProjectCost_AuditTrial(decimal PK_EPM_Project_Cost)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("ProjectCost_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Project_Cost", DbType.Decimal, PK_EPM_Project_Cost);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetProjectMilestone_AuditTrial(decimal PK_EPM_Milestone)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("ProjectMilestone_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Milestone", DbType.Decimal, PK_EPM_Milestone);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetActionAndNotes_AuditTrial(decimal PK_EPM_Action_Notes)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("EPM_ActionAndNotes_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Action_Notes", DbType.Decimal, PK_EPM_Action_Notes);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetConsultant_AuditTrial(decimal PK_EPM_Identification)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("EPM_Consultant_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Identification", DbType.Decimal, PK_EPM_Identification);
        return db.ExecuteDataSet(dbCommand);
    }
    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetSchedule_AuditTrial(decimal PK_EPM_Schedule)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("EPM_Schedule_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Schedule", DbType.Decimal, PK_EPM_Schedule);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetAP_DPD_FROIsAuditTrail(decimal PK_AP_DPD_FROIs)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_DPD_FROIs_AuditView");
        db.AddInParameter(dbCommand, "PK_AP_DPD_FROIs", DbType.Decimal, PK_AP_DPD_FROIs);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetAP_Property_Security_FinancialsAuditTrail(decimal PK_AP_Property_Security_Financials)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("AP_Property_Security_Financials_AuditView");
        db.AddInParameter(dbCommand, "FK_AP_Property_Security", DbType.Decimal, PK_AP_Property_Security_Financials);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetProjectCostInvoice_AuditTrial(decimal PK_EPM_Project_Cost)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("ProjectCostInvoice_AuditView");
        db.AddInParameter(dbCommand, "PK_EPM_Project_Cost_Invoice", DbType.Decimal, PK_EPM_Project_Cost);
        return db.ExecuteDataSet(dbCommand);
    }


    /// <summary>
    /// Selects a single record from the PM_SI_Utility_Provider table by a primary key.
    /// </summary>
    /// <returns>DataSet</returns>
    public static DataSet GetAuditOSHALogView(decimal pK_PM_Compliance_Reporting_OSHA)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("PM_Complaince_Reporting_OSHA_AuditView");

        db.AddInParameter(dbCommand, "PK_PM_Compliance_Reporting_OSHA", DbType.Decimal, pK_PM_Compliance_Reporting_OSHA);

        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetACI_Management_ProjectCost_AuditTrial(decimal PK_ACIManagement_ProjectCost)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("ACI_Management_ProjectCost_AuditView");
        db.AddInParameter(dbCommand, "PK_ACIManagement_ProjectCost", DbType.Decimal, PK_ACIManagement_ProjectCost);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet Get_ACI_Management_ProjectCostInvoice_AuditTrial(decimal PK_ACIManagement_ProjectCost_Invoice)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("ACI_MKanagement_ProjectCostInvoice_AuditView");
        db.AddInParameter(dbCommand, "PK_ACIManagement_ProjectCost_Invoice", DbType.Decimal, PK_ACIManagement_ProjectCost_Invoice);
        return db.ExecuteDataSet(dbCommand);
    }

    /// <summary>
    /// get all audit records
    /// </summary>
    /// <param name="PK_CRM_Customer"></param>
    /// <returns></returns>
    public static DataSet GetPA_Values_ImportedAuditTrail(decimal PK_PA_Values_Imported)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("PA_Values_ImportedAuditView");
        db.AddInParameter(dbCommand, "PK_PA_Values_Imported", DbType.Decimal, PK_PA_Values_Imported);
        return db.ExecuteDataSet(dbCommand);
    }

    #endregion
}

#region Includes
	using System;
	using System.Data;
	using System.Collections.Generic;
	using Microsoft.Practices.EnterpriseLibrary.Data;
	using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
	using Microsoft.Practices.EnterpriseLibrary.Common;
	using System.Configuration;
	using System.Globalization;
	using System.Data.Common;
#endregion

namespace RIMS_Base.Dal
{
[Serializable]


public class CLiabilityClaimSettlement : RIMS_Base.CLiabilityClaimSettlement
{

	public override int InsertUpdateility_Claim_Settlement(RIMS_Base.CLiabilityClaimSettlement Objility_Claim_Settlement)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_InsertUpdate_Settlement");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,Objility_Claim_Settlement.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Settlement_Date_Offered",DbType.DateTime,Objility_Claim_Settlement.Settlement_Date_Offered);
			dbHelper.AddInParameter(cmd,"@Amnt_Of_Settlement",DbType.Decimal,Objility_Claim_Settlement.Amnt_Of_Settlement);
			dbHelper.AddInParameter(cmd,"@Release_Date",DbType.DateTime,Objility_Claim_Settlement.Release_Date);
			dbHelper.AddInParameter(cmd,"@Settlement_ChkMail_Date",DbType.DateTime,Objility_Claim_Settlement.Settlement_ChkMail_Date);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_Settlement.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_Settlement.Updated_Date);
			dbHelper.ExecuteNonQuery(cmd);
            nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@FK_Liability_Claim").ToString());
			//dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
		finally
		{ dbHelper = null; cmd.Dispose(); cmd = null; }
	}
	public override int Deleteility_Claim_Settlement(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_Settlement");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,lFK_Liability_Claim);
			nRetVal = dbHelper.ExecuteNonQuery(cmd);
			dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
    }
	public override string ActivateInactivateility_Claim_Settlement(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_Settlements");
			dbHelper.AddParameter(cmd,"@FK_Liability_Claims",DbType.String, ParameterDirection.InputOutput,"FK_Liability_Claims",DataRowVersion.Current, strIDs);
			dbHelper.AddInParameter(cmd, "@ModifiedBy", DbType.Int32, intModifiedBy);
			dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, bIsActive);
			nRetVal = dbHelper.ExecuteNonQuery(cmd);
			dbHelper = null; cmd.Dispose(); cmd = null;
			return "";
		}
        catch (Exception)
        {
            throw ;
        }
    }
	public override List<RIMS_Base.CLiabilityClaimSettlement> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Claim_Settlement");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimSettlement> results = new List<RIMS_Base.CLiabilityClaimSettlement>();
			while (reader.Read())
			{
				CLiabilityClaimSettlement objility_Claim_Settlement = new CLiabilityClaimSettlement();
				objility_Claim_Settlement = MapFrom(reader);
				results.Add(objility_Claim_Settlement);
			}
			reader.Close();
			cmd = null;
			dbHelper = null;
			return results;
		}
        catch (Exception)
        {
            throw ;
        }
    }


	public override List<RIMS_Base.CLiabilityClaimSettlement> GetGL_Claim_SettlementByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_Select_Settlement");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);

            List<RIMS_Base.CLiabilityClaimSettlement> results = new List<RIMS_Base.CLiabilityClaimSettlement>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimSettlement objility_Claim_Settlement = new CLiabilityClaimSettlement();
			if (reader.Read())
			{
				objility_Claim_Settlement =  MapFrom(reader);
                results.Add(objility_Claim_Settlement);
			}
			reader.Close();
			cmd = null;
			dbHelper = null;

            return results;
        }
        catch (Exception)
        {
            throw ;
        }
    }


	protected RIMS_Base.Dal.CLiabilityClaimSettlement MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimSettlement objility_Claim_Settlement = new RIMS_Base.Dal.CLiabilityClaimSettlement();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_Settlement.FK_Liability_Claim=Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Settlement_Date_Offered"]))  {objility_Claim_Settlement.Settlement_Date_Offered=Convert.ToDateTime(reader["Settlement_Date_Offered"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Amnt_Of_Settlement"]))  {objility_Claim_Settlement.Amnt_Of_Settlement=Convert.ToDecimal(reader["Amnt_Of_Settlement"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Release_Date"]))  {objility_Claim_Settlement.Release_Date=Convert.ToDateTime(reader["Release_Date"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Settlement_ChkMail_Date"]))  {objility_Claim_Settlement.Settlement_ChkMail_Date=Convert.ToDateTime(reader["Settlement_ChkMail_Date"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_Settlement.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_Settlement.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objility_Claim_Settlement;
	}




}


}


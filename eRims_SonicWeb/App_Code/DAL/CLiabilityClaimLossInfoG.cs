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


public class CLiabilityClaimLossInfoG : RIMS_Base.CLiabilityClaimLossInfoG
{

	public override int InsertUpdateility_Claim_LossInfo_G(RIMS_Base.CLiabilityClaimLossInfoG Objility_Claim_LossInfo_G)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_InsertUpdate_LossInfo_G");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,Objility_Claim_LossInfo_G.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Desc_Loss",DbType.String,Objility_Claim_LossInfo_G.Desc_Loss);
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
	public override int Deleteility_Claim_LossInfo_G(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_LossInfo_G");
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
	public override string ActivateInactivateility_Claim_LossInfo_G(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_LossInfo_Gs");
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
	public override List<RIMS_Base.CLiabilityClaimLossInfoG> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Claim_LossInfo_G");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimLossInfoG> results = new List<RIMS_Base.CLiabilityClaimLossInfoG>();
			while (reader.Read())
			{
				CLiabilityClaimLossInfoG objility_Claim_LossInfo_G = new CLiabilityClaimLossInfoG();
				objility_Claim_LossInfo_G = MapFrom(reader);
				results.Add(objility_Claim_LossInfo_G);
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


	public override List<RIMS_Base.CLiabilityClaimLossInfoG> GetGL_Claim_LossInfo_GByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_Select_LossInfo_G");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);

            List<RIMS_Base.CLiabilityClaimLossInfoG> results = new List<RIMS_Base.CLiabilityClaimLossInfoG>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimLossInfoG objility_Claim_LossInfo_G = new CLiabilityClaimLossInfoG();
			if (reader.Read())
			{
				objility_Claim_LossInfo_G =  MapFrom(reader);
                results.Add(objility_Claim_LossInfo_G);
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


	protected RIMS_Base.Dal.CLiabilityClaimLossInfoG  MapFrom(IDataReader reader)
	{
        RIMS_Base.Dal.CLiabilityClaimLossInfoG objility_Claim_LossInfo_G = new RIMS_Base.Dal.CLiabilityClaimLossInfoG();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_LossInfo_G.FK_Liability_Claim=Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Desc_Loss"]))  {objility_Claim_LossInfo_G.Desc_Loss=Convert.ToString(reader["Desc_Loss"], CultureInfo.InvariantCulture);}
		return objility_Claim_LossInfo_G;
	}




}


}


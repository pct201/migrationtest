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


public class CLiabilityClaimOtherPropertyDamage : RIMS_Base.CLiabilityClaimOtherPropertyDamage
{

	public override int InsertUpdateility_Claim_OtherPropertyDamage(RIMS_Base.CLiabilityClaimOtherPropertyDamage Objility_Claim_OtherPropertyDamage)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_OtherPropertyDamage");
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_OtherPropertyDamage.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Damage_To_Property",DbType.String,Objility_Claim_OtherPropertyDamage.Damage_To_Property);
			dbHelper.AddInParameter(cmd,"@Damage_Desc",DbType.String,Objility_Claim_OtherPropertyDamage.Damage_Desc);
			dbHelper.AddInParameter(cmd,"@Cost_To_Repair",DbType.Decimal,Objility_Claim_OtherPropertyDamage.Cost_To_Repair);
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
	public override int Deleteility_Claim_OtherPropertyDamage(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_OtherPropertyDamage");
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
	public override string ActivateInactivateility_Claim_OtherPropertyDamage(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_OtherPropertyDamages");
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
	public override List<RIMS_Base.CLiabilityClaimOtherPropertyDamage> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherPropertyDamage");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimOtherPropertyDamage> results = new List<RIMS_Base.CLiabilityClaimOtherPropertyDamage>();
			while (reader.Read())
			{
				CLiabilityClaimOtherPropertyDamage objility_Claim_OtherPropertyDamage = new CLiabilityClaimOtherPropertyDamage();
				objility_Claim_OtherPropertyDamage = MapFrom(reader);
				results.Add(objility_Claim_OtherPropertyDamage);
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


    public override List<RIMS_Base.CLiabilityClaimOtherPropertyDamage> GetAL_Claim_OtherPropertyDamageByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherPropertyDamage");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimOtherPropertyDamage> results = new List<RIMS_Base.CLiabilityClaimOtherPropertyDamage>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimOtherPropertyDamage objility_Claim_OtherPropertyDamage = new CLiabilityClaimOtherPropertyDamage();
			if (reader.Read())
			{
				objility_Claim_OtherPropertyDamage =  MapFrom(reader);
                results.Add(objility_Claim_OtherPropertyDamage);
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


	protected RIMS_Base.Dal.CLiabilityClaimOtherPropertyDamage MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimOtherPropertyDamage objility_Claim_OtherPropertyDamage = new RIMS_Base.Dal.CLiabilityClaimOtherPropertyDamage();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_OtherPropertyDamage.FK_Liability_Claim=Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Damage_To_Property"]))  {objility_Claim_OtherPropertyDamage.Damage_To_Property=Convert.ToString(reader["Damage_To_Property"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Damage_Desc"]))  {objility_Claim_OtherPropertyDamage.Damage_Desc=Convert.ToString(reader["Damage_Desc"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Cost_To_Repair"]))  {objility_Claim_OtherPropertyDamage.Cost_To_Repair=Convert.ToDecimal(reader["Cost_To_Repair"], CultureInfo.InvariantCulture);}
		return objility_Claim_OtherPropertyDamage;
	}




}


}


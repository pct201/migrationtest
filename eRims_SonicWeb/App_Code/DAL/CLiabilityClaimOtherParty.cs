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


public class CLiabilityClaimOtherParty : RIMS_Base.CLiabilityClaimOtherParty
{

	public override int InsertUpdateility_Claim_OtherParty(RIMS_Base.CLiabilityClaimOtherParty Objility_Claim_OtherParty)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_OtherParty");
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_OtherParty.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Name",DbType.String,Objility_Claim_OtherParty.Name);
			dbHelper.AddInParameter(cmd,"@Email",DbType.String,Objility_Claim_OtherParty.Email);
			dbHelper.AddInParameter(cmd,"@TelePhone",DbType.String,Objility_Claim_OtherParty.TelePhone);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_OtherParty.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_OtherParty.Updated_Date);
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
	public override int Deleteility_Claim_OtherParty(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_OtherParty");
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
	public override string ActivateInactivateility_Claim_OtherParty(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_OtherPartys");
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
	public override List<RIMS_Base.CLiabilityClaimOtherParty> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherParty");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimOtherParty> results = new List<RIMS_Base.CLiabilityClaimOtherParty>();
			while (reader.Read())
			{
				CLiabilityClaimOtherParty objility_Claim_OtherParty = new CLiabilityClaimOtherParty();
				objility_Claim_OtherParty = MapFrom(reader);
				results.Add(objility_Claim_OtherParty);
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


    public override List<RIMS_Base.CLiabilityClaimOtherParty> GetAL_Claim_OtherPartyByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherParty");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimOtherParty> results = new List<RIMS_Base.CLiabilityClaimOtherParty>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimOtherParty objility_Claim_OtherParty = new CLiabilityClaimOtherParty();
			if (reader.Read())
			{
				objility_Claim_OtherParty =  MapFrom(reader);
                results.Add(objility_Claim_OtherParty);
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


	protected RIMS_Base.Dal.CLiabilityClaimOtherParty MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimOtherParty objility_Claim_OtherParty = new RIMS_Base.Dal.CLiabilityClaimOtherParty();
        if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherParty.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
		if (!Convert.IsDBNull(reader["Name"]))  {objility_Claim_OtherParty.Name=Convert.ToString(reader["Name"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Email"]))  {objility_Claim_OtherParty.Email=Convert.ToString(reader["Email"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["TelePhone"]))  {objility_Claim_OtherParty.TelePhone=Convert.ToString(reader["TelePhone"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_OtherParty.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_OtherParty.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objility_Claim_OtherParty;
	}




}


}


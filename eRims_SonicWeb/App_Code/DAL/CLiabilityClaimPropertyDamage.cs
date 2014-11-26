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


public class CLiabilityClaimPropertyDamage : RIMS_Base.CLiabilityClaimPropertyDamage
{

	public override int InsertUpdateility_Claim_PropertyDamage(RIMS_Base.CLiabilityClaimPropertyDamage Objility_Claim_PropertyDamage)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_InsertUpdate_PropertyDamage");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,Objility_Claim_PropertyDamage.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Property_Owner",DbType.String,Objility_Claim_PropertyDamage.Property_Owner);
			dbHelper.AddInParameter(cmd,"@Name",DbType.String,Objility_Claim_PropertyDamage.Name);
			dbHelper.AddInParameter(cmd,"@Address1",DbType.String,Objility_Claim_PropertyDamage.Address1);
			dbHelper.AddInParameter(cmd,"@Address2",DbType.String,Objility_Claim_PropertyDamage.Address2);
			dbHelper.AddInParameter(cmd,"@City",DbType.String,Objility_Claim_PropertyDamage.City);
			dbHelper.AddInParameter(cmd,"@FK_State",DbType.Decimal,Objility_Claim_PropertyDamage.FK_State);
            dbHelper.AddInParameter(cmd, "@Zipcode", DbType.String, Objility_Claim_PropertyDamage.Zipcode);
			dbHelper.AddInParameter(cmd,"@Home_TeleNo",DbType.String,Objility_Claim_PropertyDamage.Home_TeleNo);
			dbHelper.AddInParameter(cmd,"@Work_TeleNo",DbType.String,Objility_Claim_PropertyDamage.Work_TeleNo);
			dbHelper.AddInParameter(cmd,"@Cell_TeleNo",DbType.String,Objility_Claim_PropertyDamage.Cell_TeleNo);
			dbHelper.AddInParameter(cmd,"@Email",DbType.String,Objility_Claim_PropertyDamage.Email);
			dbHelper.AddInParameter(cmd,"@Desc_Of_Damage",DbType.String,Objility_Claim_PropertyDamage.Desc_Of_Damage);
			dbHelper.AddInParameter(cmd,"@Cost_Of_Damage",DbType.Decimal,Objility_Claim_PropertyDamage.Cost_Of_Damage);
			dbHelper.AddInParameter(cmd,"@Copy_Estimated_Received",DbType.String,Objility_Claim_PropertyDamage.Copy_Estimated_Received);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_PropertyDamage.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_PropertyDamage.Updated_Date);
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
	public override int Deleteility_Claim_PropertyDamage(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_PropertyDamage");
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
	public override string ActivateInactivateility_Claim_PropertyDamage(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_PropertyDamages");
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
	public override List<RIMS_Base.CLiabilityClaimPropertyDamage> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Claim_PropertyDamage");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimPropertyDamage> results = new List<RIMS_Base.CLiabilityClaimPropertyDamage>();
			while (reader.Read())
			{
				CLiabilityClaimPropertyDamage objility_Claim_PropertyDamage = new CLiabilityClaimPropertyDamage();
				objility_Claim_PropertyDamage = MapFrom(reader);
				results.Add(objility_Claim_PropertyDamage);
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


	public override List<RIMS_Base.CLiabilityClaimPropertyDamage> GetGL_Claim_PropertyDamageByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_Select_PropertyDamage");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);

            List<RIMS_Base.CLiabilityClaimPropertyDamage> results= new List<RIMS_Base.CLiabilityClaimPropertyDamage>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimPropertyDamage objility_Claim_PropertyDamage = new CLiabilityClaimPropertyDamage();
			if (reader.Read())
			{
				objility_Claim_PropertyDamage =  MapFrom(reader);
                results.Add(objility_Claim_PropertyDamage);
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


	protected RIMS_Base.Dal.CLiabilityClaimPropertyDamage MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimPropertyDamage objility_Claim_PropertyDamage = new RIMS_Base.Dal.CLiabilityClaimPropertyDamage();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_PropertyDamage.FK_Liability_Claim=Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Property_Owner"]))  {objility_Claim_PropertyDamage.Property_Owner=Convert.ToString(reader["Property_Owner"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Name"]))  {objility_Claim_PropertyDamage.Name=Convert.ToString(reader["Name"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Address1"]))  {objility_Claim_PropertyDamage.Address1=Convert.ToString(reader["Address1"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Address2"]))  {objility_Claim_PropertyDamage.Address2=Convert.ToString(reader["Address2"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["City"]))  {objility_Claim_PropertyDamage.City=Convert.ToString(reader["City"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_State"]))  {objility_Claim_PropertyDamage.FK_State=Convert.ToDecimal(reader["FK_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Home_TeleNo"]))  {objility_Claim_PropertyDamage.Home_TeleNo=Convert.ToString(reader["Home_TeleNo"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Work_TeleNo"]))  {objility_Claim_PropertyDamage.Work_TeleNo=Convert.ToString(reader["Work_TeleNo"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Cell_TeleNo"]))  {objility_Claim_PropertyDamage.Cell_TeleNo=Convert.ToString(reader["Cell_TeleNo"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Email"]))  {objility_Claim_PropertyDamage.Email=Convert.ToString(reader["Email"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Desc_Of_Damage"]))  {objility_Claim_PropertyDamage.Desc_Of_Damage=Convert.ToString(reader["Desc_Of_Damage"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Cost_Of_Damage"]))  {objility_Claim_PropertyDamage.Cost_Of_Damage=Convert.ToDecimal(reader["Cost_Of_Damage"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Copy_Estimated_Received"]))  {objility_Claim_PropertyDamage.Copy_Estimated_Received=Convert.ToString(reader["Copy_Estimated_Received"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_PropertyDamage.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_PropertyDamage.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objility_Claim_PropertyDamage;
	}




}


}


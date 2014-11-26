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


    public class CLiabilityClaimBodilyInjury : RIMS_Base.CLiabilityClaimBodilyInjury
{

	public override int InsertUpdateility_Claim_BodilyInjury(RIMS_Base.CLiabilityClaimBodilyInjury Objility_Claim_BodilyInjury)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_InsertUpdate_BodilyInjury");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,Objility_Claim_BodilyInjury.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Desc_Injury",DbType.String,Objility_Claim_BodilyInjury.Desc_Injury);
			dbHelper.AddInParameter(cmd,"@Name_Of_Facility",DbType.String,Objility_Claim_BodilyInjury.Name_Of_Facility);
			dbHelper.AddInParameter(cmd,"@Address_1",DbType.String,Objility_Claim_BodilyInjury.Address_1);
			dbHelper.AddInParameter(cmd,"@Address_2",DbType.String,Objility_Claim_BodilyInjury.Address_2);
			dbHelper.AddInParameter(cmd,"@City",DbType.String,Objility_Claim_BodilyInjury.City);
			dbHelper.AddInParameter(cmd,"@FK_State",DbType.Decimal,Objility_Claim_BodilyInjury.FK_State);
			dbHelper.AddInParameter(cmd,"@ZipCode",DbType.String,Objility_Claim_BodilyInjury.ZipCode);
			dbHelper.AddInParameter(cmd,"@TelePhone",DbType.String,Objility_Claim_BodilyInjury.TelePhone);
			dbHelper.AddInParameter(cmd,"@Facsimile",DbType.String,Objility_Claim_BodilyInjury.Facsimile);
			dbHelper.AddInParameter(cmd,"@Cost_Of_Treatment",DbType.Decimal,Objility_Claim_BodilyInjury.Cost_Of_Treatment);
			dbHelper.AddInParameter(cmd,"@Medical_Bill_Received",DbType.String,Objility_Claim_BodilyInjury.Medical_Bill_Received);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_BodilyInjury.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_BodilyInjury.Updated_Date);
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
	public override int Deleteility_Claim_BodilyInjury(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_BodilyInjury");
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
	public override string ActivateInactivateility_Claim_BodilyInjury(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_BodilyInjurys");
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
	public override List<RIMS_Base.CLiabilityClaimBodilyInjury> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Claim_BodilyInjury");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimBodilyInjury> results = new List<RIMS_Base.CLiabilityClaimBodilyInjury>();
			while (reader.Read())
			{
				CLiabilityClaimBodilyInjury objility_Claim_BodilyInjury = new CLiabilityClaimBodilyInjury();
				objility_Claim_BodilyInjury = MapFrom(reader);
				results.Add(objility_Claim_BodilyInjury);
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


	public override List<RIMS_Base.CLiabilityClaimBodilyInjury> GetGL_Claim_BodilyInjuryByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("GeneralLiability_Select_BodilyInjury");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);

            List<RIMS_Base.CLiabilityClaimBodilyInjury> results = new List<RIMS_Base.CLiabilityClaimBodilyInjury>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimBodilyInjury objility_Claim_BodilyInjury = new CLiabilityClaimBodilyInjury();
			if (reader.Read())
			{
				objility_Claim_BodilyInjury =  MapFrom(reader);
                results.Add(objility_Claim_BodilyInjury);
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


	protected RIMS_Base.Dal.CLiabilityClaimBodilyInjury MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimBodilyInjury objility_Claim_BodilyInjury = new RIMS_Base.Dal.CLiabilityClaimBodilyInjury();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_BodilyInjury.FK_Liability_Claim=Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Desc_Injury"]))  {objility_Claim_BodilyInjury.Desc_Injury=Convert.ToString(reader["Desc_Injury"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Name_Of_Facility"]))  {objility_Claim_BodilyInjury.Name_Of_Facility=Convert.ToString(reader["Name_Of_Facility"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Address_1"]))  {objility_Claim_BodilyInjury.Address_1=Convert.ToString(reader["Address_1"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Address_2"]))  {objility_Claim_BodilyInjury.Address_2=Convert.ToString(reader["Address_2"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["City"]))  {objility_Claim_BodilyInjury.City=Convert.ToString(reader["City"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_State"]))  {objility_Claim_BodilyInjury.FK_State=Convert.ToDecimal(reader["FK_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["ZipCode"]))  {objility_Claim_BodilyInjury.ZipCode=Convert.ToString(reader["ZipCode"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["TelePhone"]))  {objility_Claim_BodilyInjury.TelePhone=Convert.ToString(reader["TelePhone"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Facsimile"]))  {objility_Claim_BodilyInjury.Facsimile=Convert.ToString(reader["Facsimile"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Cost_Of_Treatment"]))  {objility_Claim_BodilyInjury.Cost_Of_Treatment=Convert.ToDecimal(reader["Cost_Of_Treatment"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Medical_Bill_Received"]))  {objility_Claim_BodilyInjury.Medical_Bill_Received=Convert.ToString(reader["Medical_Bill_Received"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_BodilyInjury.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_BodilyInjury.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objility_Claim_BodilyInjury;
	}




}


}


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


public class CLiabilityClaimLossLocation : RIMS_Base.CLiabilityClaimLossLocation
{

	public override int InsertUpdateility_Claim_LossLocation(RIMS_Base.CLiabilityClaimLossLocation Objility_Claim_LossLocation)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_LossLocation");
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_LossLocation.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Address1",DbType.String,Objility_Claim_LossLocation.Address1);
			dbHelper.AddInParameter(cmd,"@Address2",DbType.String,Objility_Claim_LossLocation.Address2);
			dbHelper.AddInParameter(cmd,"@City",DbType.String,Objility_Claim_LossLocation.City);
			dbHelper.AddInParameter(cmd,"@FK_State",DbType.Decimal,Objility_Claim_LossLocation.FK_State);
			dbHelper.AddInParameter(cmd,"@Zip",DbType.String,Objility_Claim_LossLocation.Zip);
			dbHelper.AddInParameter(cmd,"@County",DbType.String,Objility_Claim_LossLocation.County);
			dbHelper.AddInParameter(cmd,"@Accident_In_Company",DbType.String,Objility_Claim_LossLocation.Accident_In_Company);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_LossLocation.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_LossLocation.Updated_Date);
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
	public override int Deleteility_Claim_LossLocation(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_LossLocation");
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
	public override string ActivateInactivateility_Claim_LossLocation(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_LossLocations");
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
	public override List<RIMS_Base.CLiabilityClaimLossLocation> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_LossLocation");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimLossLocation> results = new List<RIMS_Base.CLiabilityClaimLossLocation>();
			while (reader.Read())
			{
				CLiabilityClaimLossLocation objility_Claim_LossLocation = new CLiabilityClaimLossLocation();
				objility_Claim_LossLocation = MapFrom(reader);
				results.Add(objility_Claim_LossLocation);
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


    public override List<RIMS_Base.CLiabilityClaimLossLocation> GetAL_Claim_LossLocationByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_LossLocation");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimLossLocation> results = new List<RIMS_Base.CLiabilityClaimLossLocation>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimLossLocation objility_Claim_LossLocation = new CLiabilityClaimLossLocation();
			if (reader.Read())
			{
				objility_Claim_LossLocation =  MapFrom(reader);
                results.Add(objility_Claim_LossLocation);
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


	protected RIMS_Base.Dal.CLiabilityClaimLossLocation MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimLossLocation objility_Claim_LossLocation = new RIMS_Base.Dal.CLiabilityClaimLossLocation();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_LossLocation.FK_Liability_Claim=Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Address1"]))  {objility_Claim_LossLocation.Address1=Convert.ToString(reader["Address1"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Address2"]))  {objility_Claim_LossLocation.Address2=Convert.ToString(reader["Address2"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["City"]))  {objility_Claim_LossLocation.City=Convert.ToString(reader["City"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_State"]))  {objility_Claim_LossLocation.FK_State=Convert.ToDecimal(reader["FK_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Zip"]))  {objility_Claim_LossLocation.Zip=Convert.ToString(reader["Zip"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["County"]))  {objility_Claim_LossLocation.County=Convert.ToString(reader["County"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Accident_In_Company"]))  {objility_Claim_LossLocation.Accident_In_Company=Convert.ToString(reader["Accident_In_Company"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_LossLocation.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_LossLocation.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objility_Claim_LossLocation;
	}




}


}


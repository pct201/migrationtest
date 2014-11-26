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


public class CLiabilityClaimCmpVehicleInfo : RIMS_Base.CLiabilityClaimCmpVehicleInfo
{

	public override int InsertUpdateility_Claim_CmpVehicleInfo(RIMS_Base.CLiabilityClaimCmpVehicleInfo Objility_Claim_CmpVehicleInfo)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_CmpVehicleInfo");
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_CmpVehicleInfo.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Year",DbType.String,Objility_Claim_CmpVehicleInfo.Year);
			dbHelper.AddInParameter(cmd,"@Model",DbType.String,Objility_Claim_CmpVehicleInfo.Model);
			dbHelper.AddInParameter(cmd,"@License_Plate_Number",DbType.String,Objility_Claim_CmpVehicleInfo.License_Plate_Number);
			dbHelper.AddInParameter(cmd,"@Vehicle_Color",DbType.String,Objility_Claim_CmpVehicleInfo.Vehicle_Color);
			dbHelper.AddInParameter(cmd,"@Make",DbType.String,Objility_Claim_CmpVehicleInfo.Make);
			dbHelper.AddInParameter(cmd,"@VIN",DbType.String,Objility_Claim_CmpVehicleInfo.VIN);
			dbHelper.AddInParameter(cmd,"@FK_License_Plate_State",DbType.Decimal,Objility_Claim_CmpVehicleInfo.FK_License_Plate_State);
			dbHelper.AddInParameter(cmd,"@CmpVeh_Only_Veh",DbType.String,Objility_Claim_CmpVehicleInfo.CmpVeh_Only_Veh);
			dbHelper.AddInParameter(cmd,"@Damage_To_CmpVeh",DbType.String,Objility_Claim_CmpVehicleInfo.Damage_To_CmpVeh);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_CmpVehicleInfo.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_CmpVehicleInfo.Updated_Date);
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
	public override int Deleteility_Claim_CmpVehicleInfo(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_CmpVehicleInfo");
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
	public override string ActivateInactivateility_Claim_CmpVehicleInfo(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_CmpVehicleInfos");
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
	public override List<RIMS_Base.CLiabilityClaimCmpVehicleInfo> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_CmpVehicleInfo");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimCmpVehicleInfo> results = new List<RIMS_Base.CLiabilityClaimCmpVehicleInfo>();
			while (reader.Read())
			{
				CLiabilityClaimCmpVehicleInfo objility_Claim_CmpVehicleInfo = new CLiabilityClaimCmpVehicleInfo();
				objility_Claim_CmpVehicleInfo = MapFrom(reader);
				results.Add(objility_Claim_CmpVehicleInfo);
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


    public override List<RIMS_Base.CLiabilityClaimCmpVehicleInfo> GetAL_Claim_CmpVehicleInfoByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_CmpVehicleInfo");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimCmpVehicleInfo> results = new List<RIMS_Base.CLiabilityClaimCmpVehicleInfo>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimCmpVehicleInfo objility_Claim_CmpVehicleInfo = new CLiabilityClaimCmpVehicleInfo();
			if (reader.Read())
			{
				objility_Claim_CmpVehicleInfo =  MapFrom(reader);
                results.Add(objility_Claim_CmpVehicleInfo);
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


	protected RIMS_Base.Dal.CLiabilityClaimCmpVehicleInfo MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimCmpVehicleInfo objility_Claim_CmpVehicleInfo = new RIMS_Base.Dal.CLiabilityClaimCmpVehicleInfo();
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_CmpVehicleInfo.FK_Liability_Claim=Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Year"]))  {objility_Claim_CmpVehicleInfo.Year=Convert.ToString(reader["Year"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Model"]))  {objility_Claim_CmpVehicleInfo.Model=Convert.ToString(reader["Model"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["License_Plate_Number"]))  {objility_Claim_CmpVehicleInfo.License_Plate_Number=Convert.ToString(reader["License_Plate_Number"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_Color"]))  {objility_Claim_CmpVehicleInfo.Vehicle_Color=Convert.ToString(reader["Vehicle_Color"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Make"]))  {objility_Claim_CmpVehicleInfo.Make=Convert.ToString(reader["Make"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["VIN"]))  {objility_Claim_CmpVehicleInfo.VIN=Convert.ToString(reader["VIN"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_License_Plate_State"]))  {objility_Claim_CmpVehicleInfo.FK_License_Plate_State=Convert.ToDecimal(reader["FK_License_Plate_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["CmpVeh_Only_Veh"]))  {objility_Claim_CmpVehicleInfo.CmpVeh_Only_Veh=Convert.ToString(reader["CmpVeh_Only_Veh"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Damage_To_CmpVeh"]))  {objility_Claim_CmpVehicleInfo.Damage_To_CmpVeh=Convert.ToString(reader["Damage_To_CmpVeh"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_CmpVehicleInfo.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_CmpVehicleInfo.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objility_Claim_CmpVehicleInfo;
	}




}


}


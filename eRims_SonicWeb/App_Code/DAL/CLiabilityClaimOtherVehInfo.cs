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


public class CLiabilityClaimOtherVehInfo : RIMS_Base.CLiabilityClaimOtherVehInfo
{

	public override int InsertUpdateility_Claim_OtherVehInfo(RIMS_Base.CLiabilityClaimOtherVehInfo Objility_Claim_OtherVehInfo)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_OtherVehInfo");
            dbHelper.AddParameter(cmd, "@Pk_OtherVehicle", DbType.Int32, ParameterDirection.InputOutput, "Pk_OtherVehicle", DataRowVersion.Current, Objility_Claim_OtherVehInfo.Pk_OtherVehicle);
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_OtherVehInfo.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Owner_Name",DbType.String,Objility_Claim_OtherVehInfo.Owner_Name);
			dbHelper.AddInParameter(cmd,"@Owner_Address1",DbType.String,Objility_Claim_OtherVehInfo.Owner_Address1);
			dbHelper.AddInParameter(cmd,"@Owner_Address2",DbType.String,Objility_Claim_OtherVehInfo.Owner_Address2);
			dbHelper.AddInParameter(cmd,"@Owner_City",DbType.String,Objility_Claim_OtherVehInfo.Owner_City);
			dbHelper.AddInParameter(cmd,"@FK_Owner_State",DbType.Decimal,Objility_Claim_OtherVehInfo.FK_Owner_State);
			dbHelper.AddInParameter(cmd,"@Owner_Zipcode",DbType.String,Objility_Claim_OtherVehInfo.Owner_Zipcode);
			dbHelper.AddInParameter(cmd,"@Owner_Telephone",DbType.String,Objility_Claim_OtherVehInfo.Owner_Telephone);
			dbHelper.AddInParameter(cmd,"@Insurance_Carrier",DbType.String,Objility_Claim_OtherVehInfo.Insurance_Carrier);
			dbHelper.AddInParameter(cmd,"@Insurance_Telephone",DbType.String,Objility_Claim_OtherVehInfo.Insurance_Telephone);
			dbHelper.AddInParameter(cmd,"@Insurance_Agent_Name",DbType.String,Objility_Claim_OtherVehInfo.Insurance_Agent_Name);
			dbHelper.AddInParameter(cmd,"@Insurance_Agent_Telephone",DbType.String,Objility_Claim_OtherVehInfo.Insurance_Agent_Telephone);
			dbHelper.AddInParameter(cmd,"@Policy_Number",DbType.String,Objility_Claim_OtherVehInfo.Policy_Number);
			dbHelper.AddInParameter(cmd,"@Vehicle_Year",DbType.String,Objility_Claim_OtherVehInfo.Vehicle_Year);
			dbHelper.AddInParameter(cmd,"@Vehicle_Make",DbType.String,Objility_Claim_OtherVehInfo.Vehicle_Make);
			dbHelper.AddInParameter(cmd,"@Vehicle_Model",DbType.String,Objility_Claim_OtherVehInfo.Vehicle_Model);
			dbHelper.AddInParameter(cmd,"@Vehicle_VIN",DbType.String,Objility_Claim_OtherVehInfo.Vehicle_VIN);
			dbHelper.AddInParameter(cmd,"@Vehicle_Plate_Number",DbType.String,Objility_Claim_OtherVehInfo.Vehicle_Plate_Number);
			dbHelper.AddInParameter(cmd,"@FK_Vehicle_State",DbType.Decimal,Objility_Claim_OtherVehInfo.FK_Vehicle_State);
			dbHelper.AddInParameter(cmd,"@Vehicle_Color",DbType.String,Objility_Claim_OtherVehInfo.Vehicle_Color);
			dbHelper.AddInParameter(cmd,"@Desc_Damage",DbType.String,Objility_Claim_OtherVehInfo.Desc_Damage);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_OtherVehInfo.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_OtherVehInfo.Updated_Date);
			dbHelper.ExecuteNonQuery(cmd);
            nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Pk_OtherVehicle").ToString());
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
    public override int Delete_Claim_OtherVehInfo(System.Int32 pk_OtherVehicle)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("AutoLiability_Delete_Claim_OtherVehInfo");
            dbHelper.AddInParameter(cmd, "@Pk_OtherVehicle", DbType.Int32, pk_OtherVehicle);
			nRetVal = dbHelper.ExecuteNonQuery(cmd);
			dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
    }
	public override string ActivateInactivateility_Claim_OtherVehInfo(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_OtherVehInfos");
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
	public override List<RIMS_Base.CLiabilityClaimOtherVehInfo> GetAll()
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherVehInfo");
			//dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimOtherVehInfo> results = new List<RIMS_Base.CLiabilityClaimOtherVehInfo>();
			while (reader.Read())
			{
				CLiabilityClaimOtherVehInfo objility_Claim_OtherVehInfo = new CLiabilityClaimOtherVehInfo();
				objility_Claim_OtherVehInfo = MapFrom(reader);
				results.Add(objility_Claim_OtherVehInfo);
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


    public override List<RIMS_Base.CLiabilityClaimOtherVehInfo> GetAL_Claim_OtherVehInfoByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherVehInfo");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimOtherVehInfo> results = new List<RIMS_Base.CLiabilityClaimOtherVehInfo>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			
			while (reader.Read())
			{
                CLiabilityClaimOtherVehInfo objility_Claim_OtherVehInfo = new CLiabilityClaimOtherVehInfo();
				objility_Claim_OtherVehInfo =  MapFrom(reader);
                results.Add(objility_Claim_OtherVehInfo);
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


	protected RIMS_Base.Dal.CLiabilityClaimOtherVehInfo MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimOtherVehInfo objility_Claim_OtherVehInfo = new RIMS_Base.Dal.CLiabilityClaimOtherVehInfo();

        if (!Convert.IsDBNull(reader["Pk_OtherVehicle"])) { objility_Claim_OtherVehInfo.Pk_OtherVehicle = Convert.ToInt32(reader["Pk_OtherVehicle"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherVehInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
		if (!Convert.IsDBNull(reader["Owner_Name"]))  {objility_Claim_OtherVehInfo.Owner_Name=Convert.ToString(reader["Owner_Name"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Owner_Address1"]))  {objility_Claim_OtherVehInfo.Owner_Address1=Convert.ToString(reader["Owner_Address1"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Owner_Address2"]))  {objility_Claim_OtherVehInfo.Owner_Address2=Convert.ToString(reader["Owner_Address2"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Owner_City"]))  {objility_Claim_OtherVehInfo.Owner_City=Convert.ToString(reader["Owner_City"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_Owner_State"]))  {objility_Claim_OtherVehInfo.FK_Owner_State=Convert.ToDecimal(reader["FK_Owner_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Owner_Zipcode"]))  {objility_Claim_OtherVehInfo.Owner_Zipcode=Convert.ToString(reader["Owner_Zipcode"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Owner_Telephone"]))  {objility_Claim_OtherVehInfo.Owner_Telephone=Convert.ToString(reader["Owner_Telephone"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Insurance_Carrier"]))  {objility_Claim_OtherVehInfo.Insurance_Carrier=Convert.ToString(reader["Insurance_Carrier"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Insurance_Telephone"]))  {objility_Claim_OtherVehInfo.Insurance_Telephone=Convert.ToString(reader["Insurance_Telephone"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Insurance_Agent_Name"]))  {objility_Claim_OtherVehInfo.Insurance_Agent_Name=Convert.ToString(reader["Insurance_Agent_Name"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Insurance_Agent_Telephone"]))  {objility_Claim_OtherVehInfo.Insurance_Agent_Telephone=Convert.ToString(reader["Insurance_Agent_Telephone"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Policy_Number"]))  {objility_Claim_OtherVehInfo.Policy_Number=Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_Year"]))  {objility_Claim_OtherVehInfo.Vehicle_Year=Convert.ToString(reader["Vehicle_Year"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_Make"]))  {objility_Claim_OtherVehInfo.Vehicle_Make=Convert.ToString(reader["Vehicle_Make"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_Model"]))  {objility_Claim_OtherVehInfo.Vehicle_Model=Convert.ToString(reader["Vehicle_Model"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_VIN"]))  {objility_Claim_OtherVehInfo.Vehicle_VIN=Convert.ToString(reader["Vehicle_VIN"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_Plate_Number"]))  {objility_Claim_OtherVehInfo.Vehicle_Plate_Number=Convert.ToString(reader["Vehicle_Plate_Number"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_Vehicle_State"]))  {objility_Claim_OtherVehInfo.FK_Vehicle_State=Convert.ToDecimal(reader["FK_Vehicle_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Vehicle_Color"]))  {objility_Claim_OtherVehInfo.Vehicle_Color=Convert.ToString(reader["Vehicle_Color"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Desc_Damage"]))  {objility_Claim_OtherVehInfo.Desc_Damage=Convert.ToString(reader["Desc_Damage"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_OtherVehInfo.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_OtherVehInfo.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}

        if (!Convert.IsDBNull(reader["FLD_state"])) { objility_Claim_OtherVehInfo.FLD_State = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
		return objility_Claim_OtherVehInfo;
	}




    public override List<RIMS_Base.CLiabilityClaimOtherVehInfo> Get_Claim_OtherVehInfoByID(System.Int32 pk_OtherVehicle)
    {
        Database dbHelper = null;
        DbCommand cmd = null;
        try
        {
            dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherVehicleByID");
            dbHelper.AddInParameter(cmd, "@Pk_OtherVehicle", DbType.Decimal, pk_OtherVehicle);
            List<RIMS_Base.CLiabilityClaimOtherVehInfo> results = new List<RIMS_Base.CLiabilityClaimOtherVehInfo>();
            IDataReader reader = dbHelper.ExecuteReader(cmd);
            CLiabilityClaimOtherVehInfo objility_Claim_OtherVehInfo = new CLiabilityClaimOtherVehInfo();
            if (reader.Read())
            {
                objility_Claim_OtherVehInfo = MapFromveh(reader);
                results.Add(objility_Claim_OtherVehInfo);
            }
            reader.Close();
            cmd = null;
            dbHelper = null;

            return results;
        }
        catch (Exception)
        {
            throw;
        }
    }


    protected RIMS_Base.Dal.CLiabilityClaimOtherVehInfo MapFromveh(IDataReader reader)
    {
        RIMS_Base.Dal.CLiabilityClaimOtherVehInfo objility_Claim_OtherVehInfo = new RIMS_Base.Dal.CLiabilityClaimOtherVehInfo();
        if (!Convert.IsDBNull(reader["Pk_OtherVehicle"])) { objility_Claim_OtherVehInfo.Pk_OtherVehicle = Convert.ToInt32(reader["Pk_OtherVehicle"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherVehInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Owner_Name"])) { objility_Claim_OtherVehInfo.Owner_Name = Convert.ToString(reader["Owner_Name"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Owner_Address1"])) { objility_Claim_OtherVehInfo.Owner_Address1 = Convert.ToString(reader["Owner_Address1"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Owner_Address2"])) { objility_Claim_OtherVehInfo.Owner_Address2 = Convert.ToString(reader["Owner_Address2"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Owner_City"])) { objility_Claim_OtherVehInfo.Owner_City = Convert.ToString(reader["Owner_City"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["FK_Owner_State"])) { objility_Claim_OtherVehInfo.FK_Owner_State = Convert.ToDecimal(reader["FK_Owner_State"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Owner_Zipcode"])) { objility_Claim_OtherVehInfo.Owner_Zipcode = Convert.ToString(reader["Owner_Zipcode"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Owner_Telephone"])) { objility_Claim_OtherVehInfo.Owner_Telephone = Convert.ToString(reader["Owner_Telephone"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Insurance_Carrier"])) { objility_Claim_OtherVehInfo.Insurance_Carrier = Convert.ToString(reader["Insurance_Carrier"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Insurance_Telephone"])) { objility_Claim_OtherVehInfo.Insurance_Telephone = Convert.ToString(reader["Insurance_Telephone"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Insurance_Agent_Name"])) { objility_Claim_OtherVehInfo.Insurance_Agent_Name = Convert.ToString(reader["Insurance_Agent_Name"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Insurance_Agent_Telephone"])) { objility_Claim_OtherVehInfo.Insurance_Agent_Telephone = Convert.ToString(reader["Insurance_Agent_Telephone"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Policy_Number"])) { objility_Claim_OtherVehInfo.Policy_Number = Convert.ToString(reader["Policy_Number"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Vehicle_Year"])) { objility_Claim_OtherVehInfo.Vehicle_Year = Convert.ToString(reader["Vehicle_Year"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Vehicle_Make"])) { objility_Claim_OtherVehInfo.Vehicle_Make = Convert.ToString(reader["Vehicle_Make"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Vehicle_Model"])) { objility_Claim_OtherVehInfo.Vehicle_Model = Convert.ToString(reader["Vehicle_Model"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Vehicle_VIN"])) { objility_Claim_OtherVehInfo.Vehicle_VIN = Convert.ToString(reader["Vehicle_VIN"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Vehicle_Plate_Number"])) { objility_Claim_OtherVehInfo.Vehicle_Plate_Number = Convert.ToString(reader["Vehicle_Plate_Number"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["FK_Vehicle_State"])) { objility_Claim_OtherVehInfo.FK_Vehicle_State = Convert.ToDecimal(reader["FK_Vehicle_State"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Vehicle_Color"])) { objility_Claim_OtherVehInfo.Vehicle_Color = Convert.ToString(reader["Vehicle_Color"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Desc_Damage"])) { objility_Claim_OtherVehInfo.Desc_Damage = Convert.ToString(reader["Desc_Damage"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherVehInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherVehInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
        return objility_Claim_OtherVehInfo;
    }

}


}


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


public class CLiabilityClaimCmpDriverInfo : RIMS_Base.CLiabilityClaimCmpDriverInfo
{

	public override int InsertUpdatelility_Claim_CmpDriverInfo(RIMS_Base.CLiabilityClaimCmpDriverInfo Objlility_Claim_CmpDriverInfo)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_CmpDriverInfo");
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objlility_Claim_CmpDriverInfo.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Name",DbType.String,Objlility_Claim_CmpDriverInfo.Name);
			dbHelper.AddInParameter(cmd,"@Supervisor",DbType.String,Objlility_Claim_CmpDriverInfo.Supervisor);
			dbHelper.AddInParameter(cmd,"@Telephone_No",DbType.String,Objlility_Claim_CmpDriverInfo.Telephone_No);
			dbHelper.AddInParameter(cmd,"@Supervisor_TeleNo",DbType.String,Objlility_Claim_CmpDriverInfo.Supervisor_TeleNo);
			dbHelper.AddInParameter(cmd,"@List_Company_Passengers",DbType.String,Objlility_Claim_CmpDriverInfo.List_Company_Passengers);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objlility_Claim_CmpDriverInfo.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objlility_Claim_CmpDriverInfo.Updated_Date);
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
	public override int Deletelility_Claim_CmpDriverInfo(System.Decimal lFK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deletelility_Claim_CmpDriverInfo");
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
	public override string ActivateInactivatelility_Claim_CmpDriverInfo(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivatelility_Claim_CmpDriverInfos");
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
	public override List<RIMS_Base.CLiabilityClaimCmpDriverInfo> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_CmpDriverInfo");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimCmpDriverInfo> results = new List<RIMS_Base.CLiabilityClaimCmpDriverInfo>();
			while (reader.Read())
			{
				CLiabilityClaimCmpDriverInfo objlility_Claim_CmpDriverInfo = new CLiabilityClaimCmpDriverInfo();
				objlility_Claim_CmpDriverInfo = MapFrom(reader);
				results.Add(objlility_Claim_CmpDriverInfo);
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


    public override List<RIMS_Base.CLiabilityClaimCmpDriverInfo> GetAL_Claim_CmpDriverInfoByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_CmpDriverInfo");
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimCmpDriverInfo> results = new List<RIMS_Base.CLiabilityClaimCmpDriverInfo>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityClaimCmpDriverInfo objlility_Claim_CmpDriverInfo = new CLiabilityClaimCmpDriverInfo();
			if (reader.Read())
			{
				objlility_Claim_CmpDriverInfo =  MapFrom(reader);
                results.Add(objlility_Claim_CmpDriverInfo);
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


	protected RIMS_Base.Dal.CLiabilityClaimCmpDriverInfo MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimCmpDriverInfo objlility_Claim_CmpDriverInfo = new RIMS_Base.Dal.CLiabilityClaimCmpDriverInfo();
        if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objlility_Claim_CmpDriverInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
		if (!Convert.IsDBNull(reader["Name"]))  {objlility_Claim_CmpDriverInfo.Name=Convert.ToString(reader["Name"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Supervisor"]))  {objlility_Claim_CmpDriverInfo.Supervisor=Convert.ToString(reader["Supervisor"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Telephone_No"]))  {objlility_Claim_CmpDriverInfo.Telephone_No=Convert.ToString(reader["Telephone_No"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Supervisor_TeleNo"]))  {objlility_Claim_CmpDriverInfo.Supervisor_TeleNo=Convert.ToString(reader["Supervisor_TeleNo"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["List_Company_Passengers"]))  {objlility_Claim_CmpDriverInfo.List_Company_Passengers=Convert.ToString(reader["List_Company_Passengers"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objlility_Claim_CmpDriverInfo.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objlility_Claim_CmpDriverInfo.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
		return objlility_Claim_CmpDriverInfo;
	}




}


}


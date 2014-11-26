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


public class CLiabilityCoverageMaster : RIMS_Base.CLiabilityCoverageMaster
{

	public override int InsertUpdateility_Coverage_Master(RIMS_Base.CLiabilityCoverageMaster Objility_Coverage_Master)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_InsertUpdateility_Coverage_Master");
			dbHelper.AddInParameter(cmd,"@PK_ID",DbType.Decimal,Objility_Coverage_Master.PK_ID);
			dbHelper.AddInParameter(cmd,"@Liability_Coverage_text",DbType.String,Objility_Coverage_Master.Liability_Coverage_text);
			dbHelper.ExecuteNonQuery(cmd);
			nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@").ToString());
			dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
		finally
		{ dbHelper = null; cmd.Dispose(); cmd = null; }
	}
	public override int Deleteility_Coverage_Master(System.Decimal lPK_ID)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Coverage_Master");
			dbHelper.AddInParameter(cmd,"@PK_ID",DbType.Decimal,lPK_ID);
			nRetVal = dbHelper.ExecuteNonQuery(cmd);
			dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
    }
	public override string ActivateInactivateility_Coverage_Master(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Coverage_Masters");
			dbHelper.AddParameter(cmd,"@PK_IDs",DbType.String, ParameterDirection.InputOutput,"PK_IDs",DataRowVersion.Current, strIDs);
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
	public override List<RIMS_Base.CLiabilityCoverageMaster> GetAll(Boolean  blnIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Coverage_Master");
			dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityCoverageMaster> results = new List<RIMS_Base.CLiabilityCoverageMaster>();
			while (reader.Read())
			{
				CLiabilityCoverageMaster objility_Coverage_Master = new CLiabilityCoverageMaster();
				objility_Coverage_Master = MapFrom(reader);
				results.Add(objility_Coverage_Master);
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


	public override RIMS_Base.CLiabilityCoverageMaster Getility_Coverage_MasterByID(System.Decimal pK_ID)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_Selectility_Coverage_Master");
			dbHelper.AddInParameter(cmd,"@PK_ID",DbType.Decimal,pK_ID);

			IDataReader reader = dbHelper.ExecuteReader(cmd);
			CLiabilityCoverageMaster objility_Coverage_Master = new CLiabilityCoverageMaster();
			if (reader.Read())
			{
				objility_Coverage_Master =  MapFrom(reader);
			}
			reader.Close();
			cmd = null;
			dbHelper = null;

			return objility_Coverage_Master;
        }
        catch (Exception)
        {
            throw ;
        }
    }


	protected RIMS_Base.Dal.CLiabilityCoverageMaster MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityCoverageMaster objility_Coverage_Master = new RIMS_Base.Dal.CLiabilityCoverageMaster();
		if (!Convert.IsDBNull(reader["PK_ID"]))  {objility_Coverage_Master.PK_ID=Convert.ToDecimal(reader["PK_ID"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Liability_Coverage_text"]))  {objility_Coverage_Master.Liability_Coverage_text=Convert.ToString(reader["Liability_Coverage_text"], CultureInfo.InvariantCulture);}
		return objility_Coverage_Master;
	}




}


}


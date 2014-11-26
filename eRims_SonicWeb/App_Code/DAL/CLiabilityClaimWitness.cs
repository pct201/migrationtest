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


public class CLiabilityClaimWitness : RIMS_Base.CLiabilityClaimWitness
{

	public override int InsertUpdateility_Claim_Witness(RIMS_Base.CLiabilityClaimWitness Objility_Claim_Witness)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_Witness");
            dbHelper.AddParameter(cmd, "@PK_Witness", DbType.Int32, ParameterDirection.InputOutput, "PK_Witness", DataRowVersion.Current, Objility_Claim_Witness.PK_Witness);
			dbHelper.AddInParameter(cmd,"@FK_Liability_Claim",DbType.Decimal,Objility_Claim_Witness.FK_Liability_Claim);
			dbHelper.AddInParameter(cmd,"@Witeness_Name",DbType.String,Objility_Claim_Witness.Witeness_Name);
			dbHelper.AddInParameter(cmd,"@Witness_Address1",DbType.String,Objility_Claim_Witness.Witness_Address1);
			dbHelper.AddInParameter(cmd,"@Witness_Address2",DbType.String,Objility_Claim_Witness.Witness_Address2);
			dbHelper.AddInParameter(cmd,"@Witness_City",DbType.String,Objility_Claim_Witness.Witness_City);
			dbHelper.AddInParameter(cmd,"@FK_Witness_State",DbType.Decimal,Objility_Claim_Witness.FK_Witness_State);
			dbHelper.AddInParameter(cmd,"@Witness_Zipcode",DbType.String,Objility_Claim_Witness.Witness_Zipcode);
			dbHelper.AddInParameter(cmd,"@Witness_Telephone",DbType.String,Objility_Claim_Witness.Witness_Telephone);
			dbHelper.AddInParameter(cmd,"@Witness_Statement",DbType.String,Objility_Claim_Witness.Witness_Statement);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.String,Objility_Claim_Witness.Updated_By);
			dbHelper.AddInParameter(cmd,"@Updated_Date",DbType.DateTime,Objility_Claim_Witness.Updated_Date);
			dbHelper.ExecuteNonQuery(cmd);
            nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Witness").ToString());
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
    public override int Delete_Claim_Witness(System.Int32 pk_Witness)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Delete_Claim_Witness");
            dbHelper.AddInParameter(cmd, "@PK_Witness", DbType.Int32, pk_Witness);
			nRetVal = dbHelper.ExecuteNonQuery(cmd);
			dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
    }
	public override string ActivateInactivateility_Claim_Witness(string strIDs,int intModifiedBy,bool bIsActive)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_Witnesss");
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
	public override List<RIMS_Base.CLiabilityClaimWitness> GetAll()
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Witness");
			//dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			List<RIMS_Base.CLiabilityClaimWitness> results = new List<RIMS_Base.CLiabilityClaimWitness>();
			while (reader.Read())
			{
				CLiabilityClaimWitness objility_Claim_Witness = new CLiabilityClaimWitness();
				objility_Claim_Witness = MapFrom(reader);
				results.Add(objility_Claim_Witness);
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
    public override List<RIMS_Base.CLiabilityClaimWitness> GetAL_Claim_WitnessByID(System.Decimal fK_Liability_Claim)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Witness");
            dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, fK_Liability_Claim);
            List<RIMS_Base.CLiabilityClaimWitness> results = new List<RIMS_Base.CLiabilityClaimWitness>();
			IDataReader reader = dbHelper.ExecuteReader(cmd);
			
            while (reader.Read())
			{
                CLiabilityClaimWitness objility_Claim_Witness = new CLiabilityClaimWitness();
				objility_Claim_Witness =  MapFrom(reader);
                results.Add(objility_Claim_Witness);
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
    protected RIMS_Base.Dal.CLiabilityClaimWitness MapFrom(IDataReader reader)
	{
		RIMS_Base.Dal.CLiabilityClaimWitness objility_Claim_Witness = new RIMS_Base.Dal.CLiabilityClaimWitness();
        if (!Convert.IsDBNull(reader["PK_Witness"])) { objility_Claim_Witness.PK_Witness = Convert.ToInt32(reader["PK_Witness"], CultureInfo.InvariantCulture); }
		if (!Convert.IsDBNull(reader["FK_Liability_Claim"]))  {objility_Claim_Witness.FK_Liability_Claim=Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witeness_Name"]))  {objility_Claim_Witness.Witeness_Name=Convert.ToString(reader["Witeness_Name"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witness_Address1"]))  {objility_Claim_Witness.Witness_Address1=Convert.ToString(reader["Witness_Address1"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witness_Address2"]))  {objility_Claim_Witness.Witness_Address2=Convert.ToString(reader["Witness_Address2"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witness_City"]))  {objility_Claim_Witness.Witness_City=Convert.ToString(reader["Witness_City"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["FK_Witness_State"]))  {objility_Claim_Witness.FK_Witness_State=Convert.ToDecimal(reader["FK_Witness_State"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witness_Zipcode"]))  {objility_Claim_Witness.Witness_Zipcode=Convert.ToString(reader["Witness_Zipcode"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witness_Telephone"]))  {objility_Claim_Witness.Witness_Telephone=Convert.ToString(reader["Witness_Telephone"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Witness_Statement"]))  {objility_Claim_Witness.Witness_Statement=Convert.ToString(reader["Witness_Statement"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_By"]))  {objility_Claim_Witness.Updated_By=Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture);}
		if (!Convert.IsDBNull(reader["Updated_Date"]))  {objility_Claim_Witness.Updated_Date=Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture);}
        if (!Convert.IsDBNull(reader["FLD_state"])) { objility_Claim_Witness.FLD_State = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
		return objility_Claim_Witness;
	}





    public override List<RIMS_Base.CLiabilityClaimWitness> Get_Witness_ByID(System.Int32 pk_Witness)
    {
        Database dbHelper = null;
        DbCommand cmd = null;
        try
        {
            dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_WitnessByID");
            dbHelper.AddInParameter(cmd, "@PK_Witness", DbType.Int32, pk_Witness);
            List<RIMS_Base.CLiabilityClaimWitness> results = new List<RIMS_Base.CLiabilityClaimWitness>();
            IDataReader reader = dbHelper.ExecuteReader(cmd);
            CLiabilityClaimWitness objility_Claim_Witness = new CLiabilityClaimWitness();
            while (reader.Read())
            {
                objility_Claim_Witness = MapFromWit(reader);
                results.Add(objility_Claim_Witness);
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
    protected RIMS_Base.Dal.CLiabilityClaimWitness MapFromWit(IDataReader reader)
    {
        RIMS_Base.Dal.CLiabilityClaimWitness objility_Claim_Witness = new RIMS_Base.Dal.CLiabilityClaimWitness();
        if (!Convert.IsDBNull(reader["PK_Witness"])) { objility_Claim_Witness.PK_Witness = Convert.ToInt32(reader["PK_Witness"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_Witness.FK_Liability_Claim = Convert.ToDecimal(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witeness_Name"])) { objility_Claim_Witness.Witeness_Name = Convert.ToString(reader["Witeness_Name"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witness_Address1"])) { objility_Claim_Witness.Witness_Address1 = Convert.ToString(reader["Witness_Address1"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witness_Address2"])) { objility_Claim_Witness.Witness_Address2 = Convert.ToString(reader["Witness_Address2"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witness_City"])) { objility_Claim_Witness.Witness_City = Convert.ToString(reader["Witness_City"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["FK_Witness_State"])) { objility_Claim_Witness.FK_Witness_State = Convert.ToDecimal(reader["FK_Witness_State"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witness_Zipcode"])) { objility_Claim_Witness.Witness_Zipcode = Convert.ToString(reader["Witness_Zipcode"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witness_Telephone"])) { objility_Claim_Witness.Witness_Telephone = Convert.ToString(reader["Witness_Telephone"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Witness_Statement"])) { objility_Claim_Witness.Witness_Statement = Convert.ToString(reader["Witness_Statement"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_Witness.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
        if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_Witness.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
        return objility_Claim_Witness;
    }


}


}


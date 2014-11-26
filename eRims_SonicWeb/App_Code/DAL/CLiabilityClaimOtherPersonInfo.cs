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


    public class CLiabilityClaimOtherPersonInfo : RIMS_Base.CLiabilityClaimOtherPersonInfo
    {

        public override int InsertUpdateility_Claim_OtherPersonInfo(RIMS_Base.CLiabilityClaimOtherPersonInfo Objility_Claim_OtherPersonInfo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_OtherPersonInfo");
                dbHelper.AddParameter(cmd, "@PK_Injured_Person", DbType.Int32, ParameterDirection.InputOutput, "PK_Injured_Person", DataRowVersion.Current, Objility_Claim_OtherPersonInfo.PK_Injured_Person);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_OtherPersonInfo.FK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Injured_Person_name", DbType.String, Objility_Claim_OtherPersonInfo.Injured_Person_name);
                dbHelper.AddInParameter(cmd, "@Injured_Person_Address1", DbType.String, Objility_Claim_OtherPersonInfo.Injured_Person_Address1);
                dbHelper.AddInParameter(cmd, "@Injured_Person_Address2", DbType.String, Objility_Claim_OtherPersonInfo.Injured_Person_Address2);
                dbHelper.AddInParameter(cmd, "@Injured_Person_City", DbType.String, Objility_Claim_OtherPersonInfo.Injured_Person_City);
                dbHelper.AddInParameter(cmd, "@FK_Person_State", DbType.Decimal, Objility_Claim_OtherPersonInfo.FK_Person_State);
                dbHelper.AddInParameter(cmd, "@Injured_Person_Zipcode", DbType.String, Objility_Claim_OtherPersonInfo.Injured_Person_Zipcode);
                dbHelper.AddInParameter(cmd, "@Injured_Person_Telephone", DbType.String, Objility_Claim_OtherPersonInfo.Injured_Person_Telephone);
                dbHelper.AddInParameter(cmd, "@FK_InjuredType_Was", DbType.Decimal, Objility_Claim_OtherPersonInfo.FK_InjuredType_Was);
                dbHelper.AddInParameter(cmd, "@Desc_Injuries", DbType.String, Objility_Claim_OtherPersonInfo.Desc_Injuries);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objility_Claim_OtherPersonInfo.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objility_Claim_OtherPersonInfo.Updated_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Injured_Person").ToString());
                //dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Delete_Claim_OtherPersonInfo(System.Int32 pk_Injured_Person)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AttoLiability_Delete_Claim_OtherPersonInfo");
                dbHelper.AddInParameter(cmd, "@PK_Injured_Person", DbType.Int32, pk_Injured_Person);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateility_Claim_OtherPersonInfo(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_OtherPersonInfos");
                dbHelper.AddParameter(cmd, "@FK_Liability_Claims", DbType.String, ParameterDirection.InputOutput, "FK_Liability_Claims", DataRowVersion.Current, strIDs);
                dbHelper.AddInParameter(cmd, "@ModifiedBy", DbType.Int32, intModifiedBy);
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, bIsActive);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override List<RIMS_Base.CLiabilityClaimOtherPersonInfo> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherPersonInfo");
             //   dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CLiabilityClaimOtherPersonInfo> results = new List<RIMS_Base.CLiabilityClaimOtherPersonInfo>();
                while (reader.Read())
                {
                    CLiabilityClaimOtherPersonInfo objility_Claim_OtherPersonInfo = new CLiabilityClaimOtherPersonInfo();
                    objility_Claim_OtherPersonInfo = MapFrom(reader);
                    results.Add(objility_Claim_OtherPersonInfo);
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


        public override List<RIMS_Base.CLiabilityClaimOtherPersonInfo> GetAL_Claim_OtherPersonInfoByID(System.Decimal fK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherPersonInfo");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, fK_Liability_Claim);
                List<RIMS_Base.CLiabilityClaimOtherPersonInfo> results = new List<RIMS_Base.CLiabilityClaimOtherPersonInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
               
                while (reader.Read())
                {
                    CLiabilityClaimOtherPersonInfo objility_Claim_OtherPersonInfo = new CLiabilityClaimOtherPersonInfo();
                    objility_Claim_OtherPersonInfo = MapFrom(reader);
                    results.Add(objility_Claim_OtherPersonInfo);
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


        protected RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo objility_Claim_OtherPersonInfo = new RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo();
            if (!Convert.IsDBNull(reader["PK_Injured_Person"])) { objility_Claim_OtherPersonInfo.PK_Injured_Person = Convert.ToInt32(reader["PK_Injured_Person"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherPersonInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_name"])) { objility_Claim_OtherPersonInfo.Injured_Person_name = Convert.ToString(reader["Injured_Person_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Address1"])) { objility_Claim_OtherPersonInfo.Injured_Person_Address1 = Convert.ToString(reader["Injured_Person_Address1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Address2"])) { objility_Claim_OtherPersonInfo.Injured_Person_Address2 = Convert.ToString(reader["Injured_Person_Address2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_City"])) { objility_Claim_OtherPersonInfo.Injured_Person_City = Convert.ToString(reader["Injured_Person_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Person_State"])) { objility_Claim_OtherPersonInfo.FK_Person_State = Convert.ToDecimal(reader["FK_Person_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Zipcode"])) { objility_Claim_OtherPersonInfo.Injured_Person_Zipcode = Convert.ToString(reader["Injured_Person_Zipcode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Telephone"])) { objility_Claim_OtherPersonInfo.Injured_Person_Telephone = Convert.ToString(reader["Injured_Person_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_InjuredType_Was"])) { objility_Claim_OtherPersonInfo.FK_InjuredType_Was = Convert.ToDecimal(reader["FK_InjuredType_Was"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Desc_Injuries"])) { objility_Claim_OtherPersonInfo.Desc_Injuries = Convert.ToString(reader["Desc_Injuries"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherPersonInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherPersonInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FLD_state"])) { objility_Claim_OtherPersonInfo.FLD_State = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
            return objility_Claim_OtherPersonInfo;
        }


        public override List<RIMS_Base.CLiabilityClaimOtherPersonInfo> Get_Claim_OtherPersonInfoByID(System.Int32 pk_Injured_Person)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_InjuredPersonByID");
                dbHelper.AddInParameter(cmd, "@PK_Injured_Person", DbType.Int32, pk_Injured_Person);
                List<RIMS_Base.CLiabilityClaimOtherPersonInfo> results = new List<RIMS_Base.CLiabilityClaimOtherPersonInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaimOtherPersonInfo objility_Claim_OtherPersonInfo = new CLiabilityClaimOtherPersonInfo();
                while (reader.Read())
                {
                    
                    objility_Claim_OtherPersonInfo = MapFromper(reader);
                    results.Add(objility_Claim_OtherPersonInfo);
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


        protected RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo MapFromper(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo objility_Claim_OtherPersonInfo = new RIMS_Base.Dal.CLiabilityClaimOtherPersonInfo();
            if (!Convert.IsDBNull(reader["PK_Injured_Person"])) { objility_Claim_OtherPersonInfo.PK_Injured_Person = Convert.ToInt32(reader["PK_Injured_Person"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherPersonInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_name"])) { objility_Claim_OtherPersonInfo.Injured_Person_name = Convert.ToString(reader["Injured_Person_name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Address1"])) { objility_Claim_OtherPersonInfo.Injured_Person_Address1 = Convert.ToString(reader["Injured_Person_Address1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Address2"])) { objility_Claim_OtherPersonInfo.Injured_Person_Address2 = Convert.ToString(reader["Injured_Person_Address2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_City"])) { objility_Claim_OtherPersonInfo.Injured_Person_City = Convert.ToString(reader["Injured_Person_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Person_State"])) { objility_Claim_OtherPersonInfo.FK_Person_State = Convert.ToDecimal(reader["FK_Person_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Zipcode"])) { objility_Claim_OtherPersonInfo.Injured_Person_Zipcode = Convert.ToString(reader["Injured_Person_Zipcode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Injured_Person_Telephone"])) { objility_Claim_OtherPersonInfo.Injured_Person_Telephone = Convert.ToString(reader["Injured_Person_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_InjuredType_Was"])) { objility_Claim_OtherPersonInfo.FK_InjuredType_Was = Convert.ToDecimal(reader["FK_InjuredType_Was"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Desc_Injuries"])) { objility_Claim_OtherPersonInfo.Desc_Injuries = Convert.ToString(reader["Desc_Injuries"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherPersonInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherPersonInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            return objility_Claim_OtherPersonInfo;
        }




    }


}


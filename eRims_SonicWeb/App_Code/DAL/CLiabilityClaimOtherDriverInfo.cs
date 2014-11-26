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


    public class CLiabilityClaimOtherDriverInfo : RIMS_Base.CLiabilityClaimOtherDriverInfo
    {

        public override int InsertUpdateility_Claim_OtherDriverInfo(RIMS_Base.CLiabilityClaimOtherDriverInfo Objility_Claim_OtherDriverInfo)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_OtherDriverInfo");
                dbHelper.AddParameter(cmd, "@PK_Otherdriver", DbType.Int32, ParameterDirection.InputOutput, "PK_Otherdriver", DataRowVersion.Current, Objility_Claim_OtherDriverInfo.PK_Otherdriver);
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_OtherDriverInfo.FK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@Driver_Name", DbType.String, Objility_Claim_OtherDriverInfo.Driver_Name);
                dbHelper.AddInParameter(cmd, "@Driver_Address1", DbType.String, Objility_Claim_OtherDriverInfo.Driver_Address1);
                dbHelper.AddInParameter(cmd, "@Driver_Address2", DbType.String, Objility_Claim_OtherDriverInfo.Driver_Address2);
                dbHelper.AddInParameter(cmd, "@Driver_City", DbType.String, Objility_Claim_OtherDriverInfo.Driver_City);
                dbHelper.AddInParameter(cmd, "@FK_Driver_State", DbType.Decimal, Objility_Claim_OtherDriverInfo.FK_Driver_State);
                dbHelper.AddInParameter(cmd, "@Driver_Zipcode", DbType.String, Objility_Claim_OtherDriverInfo.Driver_Zipcode);
                dbHelper.AddInParameter(cmd, "@Driver_Telephone", DbType.String, Objility_Claim_OtherDriverInfo.Driver_Telephone);
                dbHelper.AddInParameter(cmd, "@Driver_License_Number", DbType.String, Objility_Claim_OtherDriverInfo.Driver_License_Number);
                dbHelper.AddInParameter(cmd, "@FK_Driver_License_State", DbType.Decimal, Objility_Claim_OtherDriverInfo.FK_Driver_License_State);
                dbHelper.AddInParameter(cmd, "@Insurance_Carrier", DbType.String, Objility_Claim_OtherDriverInfo.Insurance_Carrier);
                dbHelper.AddInParameter(cmd, "@Insurance_Telephone", DbType.String, Objility_Claim_OtherDriverInfo.Insurance_Telephone);
                dbHelper.AddInParameter(cmd, "@Insurance_Agent_Name", DbType.String, Objility_Claim_OtherDriverInfo.Insurance_Agent_Name);
                dbHelper.AddInParameter(cmd, "@Insurance_Agent_Telephone", DbType.String, Objility_Claim_OtherDriverInfo.Insurance_Agent_Telephone);
                dbHelper.AddInParameter(cmd, "@Policy_number", DbType.String, Objility_Claim_OtherDriverInfo.Policy_number);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objility_Claim_OtherDriverInfo.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objility_Claim_OtherDriverInfo.Updated_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Otherdriver").ToString());
               // dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Deleteility_Claim_OtherDriverInfo(System.Int32 pk_Otherdriver)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Delete_Claim_OtherDriver");
                dbHelper.AddInParameter(cmd, "@PK_Otherdriver", DbType.Int32, pk_Otherdriver);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateility_Claim_OtherDriverInfo(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_OtherDriverInfos");
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
        public override List<RIMS_Base.CLiabilityClaimOtherDriverInfo> GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherDriverInfo");
               // dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CLiabilityClaimOtherDriverInfo> results = new List<RIMS_Base.CLiabilityClaimOtherDriverInfo>();
                while (reader.Read())
                {
                    CLiabilityClaimOtherDriverInfo objility_Claim_OtherDriverInfo = new CLiabilityClaimOtherDriverInfo();
                    objility_Claim_OtherDriverInfo = MapFrom(reader);
                    results.Add(objility_Claim_OtherDriverInfo);
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


        public override List<RIMS_Base.CLiabilityClaimOtherDriverInfo> GetAL_Claim_OtherDriverInfoByID(System.Decimal fK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherDriverInfo");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, fK_Liability_Claim);
                List<RIMS_Base.CLiabilityClaimOtherDriverInfo> results = new List<RIMS_Base.CLiabilityClaimOtherDriverInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
               
                while  (reader.Read())
                {
                    CLiabilityClaimOtherDriverInfo objility_Claim_OtherDriverInfo = new CLiabilityClaimOtherDriverInfo();
                    objility_Claim_OtherDriverInfo = MapFrom(reader);
                    results.Add(objility_Claim_OtherDriverInfo);
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


        protected RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo objility_Claim_OtherDriverInfo = new RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo();
            if (!Convert.IsDBNull(reader["PK_Otherdriver"])) { objility_Claim_OtherDriverInfo.PK_Otherdriver = Convert.ToInt32(reader["PK_Otherdriver"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherDriverInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Name"])) { objility_Claim_OtherDriverInfo.Driver_Name = Convert.ToString(reader["Driver_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Address1"])) { objility_Claim_OtherDriverInfo.Driver_Address1 = Convert.ToString(reader["Driver_Address1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Address2"])) { objility_Claim_OtherDriverInfo.Driver_Address2 = Convert.ToString(reader["Driver_Address2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_City"])) { objility_Claim_OtherDriverInfo.Driver_City = Convert.ToString(reader["Driver_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Driver_State"])) { objility_Claim_OtherDriverInfo.FK_Driver_State = Convert.ToDecimal(reader["FK_Driver_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Zipcode"])) { objility_Claim_OtherDriverInfo.Driver_Zipcode = Convert.ToString(reader["Driver_Zipcode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Telephone"])) { objility_Claim_OtherDriverInfo.Driver_Telephone = Convert.ToString(reader["Driver_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_License_Number"])) { objility_Claim_OtherDriverInfo.Driver_License_Number = Convert.ToString(reader["Driver_License_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Driver_License_State"])) { objility_Claim_OtherDriverInfo.FK_Driver_License_State = Convert.ToDecimal(reader["FK_Driver_License_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Carrier"])) { objility_Claim_OtherDriverInfo.Insurance_Carrier = Convert.ToString(reader["Insurance_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Telephone"])) { objility_Claim_OtherDriverInfo.Insurance_Telephone = Convert.ToString(reader["Insurance_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Agent_Name"])) { objility_Claim_OtherDriverInfo.Insurance_Agent_Name = Convert.ToString(reader["Insurance_Agent_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Agent_Telephone"])) { objility_Claim_OtherDriverInfo.Insurance_Agent_Telephone = Convert.ToString(reader["Insurance_Agent_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_number"])) { objility_Claim_OtherDriverInfo.Policy_number = Convert.ToString(reader["Policy_number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherDriverInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherDriverInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Address1"])) { objility_Claim_OtherDriverInfo.Driver_Address1 = Convert.ToString(reader["Driver_Address1"], CultureInfo.InvariantCulture); }

            if (!Convert.IsDBNull(reader["FLD_state"])) { objility_Claim_OtherDriverInfo.FLD_State = Convert.ToString(reader["FLD_state"], CultureInfo.InvariantCulture); }
            return objility_Claim_OtherDriverInfo;
        }




        public override List<RIMS_Base.CLiabilityClaimOtherDriverInfo> Get_Claim_OtherDriverInfoByID(System.Int32 pk_Otherdriver)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_OtherDriverByID");
                dbHelper.AddInParameter(cmd, "@PK_Otherdriver", DbType.Int32, pk_Otherdriver);
                List<RIMS_Base.CLiabilityClaimOtherDriverInfo> results = new List<RIMS_Base.CLiabilityClaimOtherDriverInfo>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaimOtherDriverInfo objility_Claim_OtherDriverInfo = new CLiabilityClaimOtherDriverInfo();
                if (reader.Read())
                {
                   
                    objility_Claim_OtherDriverInfo = MapFromDriver(reader);
                    results.Add(objility_Claim_OtherDriverInfo);
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


        protected RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo MapFromDriver(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo objility_Claim_OtherDriverInfo = new RIMS_Base.Dal.CLiabilityClaimOtherDriverInfo();
            if (!Convert.IsDBNull(reader["PK_Otherdriver"])) { objility_Claim_OtherDriverInfo.PK_Otherdriver = Convert.ToInt32(reader["PK_Otherdriver"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_OtherDriverInfo.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Name"])) { objility_Claim_OtherDriverInfo.Driver_Name = Convert.ToString(reader["Driver_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Address1"])) { objility_Claim_OtherDriverInfo.Driver_Address1 = Convert.ToString(reader["Driver_Address1"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Address2"])) { objility_Claim_OtherDriverInfo.Driver_Address2 = Convert.ToString(reader["Driver_Address2"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_City"])) { objility_Claim_OtherDriverInfo.Driver_City = Convert.ToString(reader["Driver_City"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Driver_State"])) { objility_Claim_OtherDriverInfo.FK_Driver_State = Convert.ToDecimal(reader["FK_Driver_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Zipcode"])) { objility_Claim_OtherDriverInfo.Driver_Zipcode = Convert.ToString(reader["Driver_Zipcode"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_Telephone"])) { objility_Claim_OtherDriverInfo.Driver_Telephone = Convert.ToString(reader["Driver_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Driver_License_Number"])) { objility_Claim_OtherDriverInfo.Driver_License_Number = Convert.ToString(reader["Driver_License_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Driver_License_State"])) { objility_Claim_OtherDriverInfo.FK_Driver_License_State = Convert.ToDecimal(reader["FK_Driver_License_State"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Carrier"])) { objility_Claim_OtherDriverInfo.Insurance_Carrier = Convert.ToString(reader["Insurance_Carrier"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Telephone"])) { objility_Claim_OtherDriverInfo.Insurance_Telephone = Convert.ToString(reader["Insurance_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Agent_Name"])) { objility_Claim_OtherDriverInfo.Insurance_Agent_Name = Convert.ToString(reader["Insurance_Agent_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Insurance_Agent_Telephone"])) { objility_Claim_OtherDriverInfo.Insurance_Agent_Telephone = Convert.ToString(reader["Insurance_Agent_Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Policy_number"])) { objility_Claim_OtherDriverInfo.Policy_number = Convert.ToString(reader["Policy_number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_OtherDriverInfo.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_OtherDriverInfo.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            return objility_Claim_OtherDriverInfo;
        }



    }


}


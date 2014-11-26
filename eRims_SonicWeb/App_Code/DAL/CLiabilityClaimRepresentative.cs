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


    public class CLiabilityClaimRepresentative : RIMS_Base.CLiabilityClaimRepresentative
    {

        public override int InsertUpdateility_Claim_Representative(RIMS_Base.CLiabilityClaimRepresentative Objility_Claim_Representative)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_InsertUpdate_Representative");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Int32, Objility_Claim_Representative.FK_Liability_Claim);
                dbHelper.AddInParameter(cmd, "@FairPoint_Name", DbType.String, Objility_Claim_Representative.FairPoint_Name);
                dbHelper.AddInParameter(cmd, "@Email", DbType.String, Objility_Claim_Representative.Email);
                dbHelper.AddInParameter(cmd, "@Telephone", DbType.String, Objility_Claim_Representative.Telephone);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.String, Objility_Claim_Representative.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objility_Claim_Representative.Updated_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@FK_Liability_Claim").ToString());
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
        public override int Deleteility_Claim_Representative(System.Decimal lFK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_Deleteility_Claim_Representative");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, lFK_Liability_Claim);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override string ActivateInactivateility_Claim_Representative(string strIDs, int intModifiedBy, bool bIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Lia_ActivateInactivateility_Claim_Representatives");
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
        public override List<RIMS_Base.CLiabilityClaimRepresentative> GetAll(Boolean blnIsActive)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Representative");
                dbHelper.AddInParameter(cmd, "@IsActive", DbType.Boolean, blnIsActive);
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CLiabilityClaimRepresentative> results = new List<RIMS_Base.CLiabilityClaimRepresentative>();
                while (reader.Read())
                {
                    CLiabilityClaimRepresentative objility_Claim_Representative = new CLiabilityClaimRepresentative();
                    objility_Claim_Representative = MapFrom(reader);
                    results.Add(objility_Claim_Representative);
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


        public override List<RIMS_Base.CLiabilityClaimRepresentative> GetAL_Claim_RepresentativeByID(System.Decimal fK_Liability_Claim)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("AutoLiability_Select_Representative");
                dbHelper.AddInParameter(cmd, "@FK_Liability_Claim", DbType.Decimal, fK_Liability_Claim);
                List<RIMS_Base.CLiabilityClaimRepresentative> results = new List<RIMS_Base.CLiabilityClaimRepresentative>();
                IDataReader reader = dbHelper.ExecuteReader(cmd);
                CLiabilityClaimRepresentative objility_Claim_Representative = new CLiabilityClaimRepresentative();
                if (reader.Read())
                {
                    
                    objility_Claim_Representative = MapFrom(reader);
                    results.Add(objility_Claim_Representative);
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


        protected RIMS_Base.Dal.CLiabilityClaimRepresentative MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CLiabilityClaimRepresentative objility_Claim_Representative = new RIMS_Base.Dal.CLiabilityClaimRepresentative();
            if (!Convert.IsDBNull(reader["FK_Liability_Claim"])) { objility_Claim_Representative.FK_Liability_Claim = Convert.ToInt32(reader["FK_Liability_Claim"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FairPoint_Name"])) { objility_Claim_Representative.FairPoint_Name = Convert.ToString(reader["FairPoint_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Email"])) { objility_Claim_Representative.Email = Convert.ToString(reader["Email"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Telephone"])) { objility_Claim_Representative.Telephone = Convert.ToString(reader["Telephone"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_By"])) { objility_Claim_Representative.Updated_By = Convert.ToString(reader["Updated_By"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Updated_Date"])) { objility_Claim_Representative.Updated_Date = Convert.ToDateTime(reader["Updated_Date"], CultureInfo.InvariantCulture); }
            return objility_Claim_Representative;
        }




    }


}


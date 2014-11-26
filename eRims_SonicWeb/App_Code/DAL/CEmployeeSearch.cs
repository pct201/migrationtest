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

    public class CEmployeeSearch : RIMS_Base.CEmployeeSearch
    {
        public override List<RIMS_Base.CEmployeeSearch> GetAll(RIMS_Base.CEmployeeSearch Objoyee, decimal pK_Security_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                //cmd = dbHelper.GetStoredProcCommand("GetClaimSearch");
                //cmd = dbHelper.GetStoredProcCommand("GetClaimSearchNew");
                cmd = dbHelper.GetStoredProcCommand("ExecutiveRiskSearch");
                dbHelper.AddInParameter(cmd, "@TableName", DbType.String, Objoyee.TableName);
                dbHelper.AddInParameter(cmd, "@PK_Employee_ID", DbType.Decimal, Objoyee.PK_Employee_ID);
                dbHelper.AddInParameter(cmd, "@Social_Security_Number", DbType.String, Objoyee.Social_Security_Number);

                dbHelper.AddInParameter(cmd, "@WorkerComp", DbType.String, Objoyee.WorkerComp);
                dbHelper.AddInParameter(cmd, "@AutoLib", DbType.String, Objoyee.AutoLib);
                dbHelper.AddInParameter(cmd, "@GeneralLib", DbType.String, Objoyee.GeneralLib);
                dbHelper.AddInParameter(cmd, "@FinPro", DbType.String, Objoyee.FinPro);
                dbHelper.AddInParameter(cmd, "@PropertyLoss", DbType.String, Objoyee.PropertyLoss);
                dbHelper.AddInParameter(cmd, "@ExecutiveRisk", DbType.String, Objoyee.ExecutiveRisk);
                dbHelper.AddInParameter(cmd, "@Claim_Number", DbType.String, Objoyee.Claim_Number);
                dbHelper.AddInParameter(cmd, "@DateOfLossFrom", DbType.String, Objoyee.DateOfLossFrom);
                dbHelper.AddInParameter(cmd, "@DateOfLossTo", DbType.String, Objoyee.DateOfLossTo);
                dbHelper.AddInParameter(cmd, "@ClaimStatus", DbType.Int32, Objoyee.ClaimStatus);
                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Int32, Objoyee.FK_Entity);
                dbHelper.AddInParameter(cmd, "@FK_Risk_Type", DbType.Int32, Objoyee.FK_Risk_Type);
                dbHelper.AddInParameter(cmd, "@PK_Security_Id", DbType.Decimal, pK_Security_Id);

                IDataReader reader = dbHelper.ExecuteReader(cmd);
                List<RIMS_Base.CEmployeeSearch> results = new List<RIMS_Base.CEmployeeSearch>();
                while (reader.Read())
                {
                    CEmployeeSearch objEmp = new CEmployeeSearch();
                    objEmp = MapFrom(reader);
                    results.Add(objEmp);
                }
                reader.Close();
                return results;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int DeleteClaim(string ClaimType, decimal PK_ClaimID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Claim_Delete");
                dbHelper.AddInParameter(cmd, "@ClaimType", DbType.String, ClaimType);
                dbHelper.AddInParameter(cmd, "@PK_ClaimID", DbType.Decimal, PK_ClaimID);
                dbHelper.ExecuteNonQuery(cmd);
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        protected RIMS_Base.Dal.CEmployeeSearch MapFrom(IDataReader reader)
        {
            RIMS_Base.Dal.CEmployeeSearch objoyee = new RIMS_Base.Dal.CEmployeeSearch();

            if (!Convert.IsDBNull(reader["Last_Name"])) { objoyee.Last_Name = Convert.ToString(reader["Last_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["First_Name"])) { objoyee.First_Name = Convert.ToString(reader["First_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Complainant_Plaintiff"])) { objoyee.Complainant_Plaintiff = Convert.ToString(reader["Complainant_Plaintiff"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Middle_Name"])) { objoyee.Middle_Name = Convert.ToString(reader["Middle_Name"], CultureInfo.InvariantCulture).Replace("''", "'"); }
            if (!Convert.IsDBNull(reader["Social_Security_Number"])) { objoyee.Social_Security_Number = Convert.ToString(reader["Social_Security_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Number"])) { objoyee.Claim_Number = Convert.ToString(reader["Claim_Number"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Date_Of_Loss"])) { objoyee.DateOfLoss = Convert.ToDateTime(reader["Date_Of_Loss"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Claim_Close_Date"])) { objoyee.Claim_Close_Date = Convert.ToDateTime(reader["Claim_Close_Date"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["PrimaryID"])) { objoyee.PK_Employee_ID = Convert.ToDecimal(reader["PrimaryID"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["TableName"])) { objoyee.TableName = Convert.ToString(reader["TableName"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Description"])) { objoyee.Entity_Description = Convert.ToString(reader["Description"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Sonic_Location_Code"])) { objoyee.Location_Code = Convert.ToInt32(reader["Sonic_Location_Code"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["dba"])) { objoyee.Location_Dba = Convert.ToString(reader["dba"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Major_Claim_Type"])) { objoyee.FK_Major_Claim_Type = Convert.ToInt32(reader["Major_Claim_Type"], CultureInfo.InvariantCulture); }
            return objoyee;
        }

    }
}

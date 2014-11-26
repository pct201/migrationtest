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


    public class CFCIPolicy : RIMS_Base.CFCIPolicy
    {

        public override int Policy_InsertUpdate(RIMS_Base.CFCIPolicy Objcy)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Policy_Id", DbType.Int32, ParameterDirection.InputOutput, "PK_Policy_Id", DataRowVersion.Current, Objcy.PK_Policy_Id);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Type", DbType.Decimal, Objcy.FK_Policy_Type);
                dbHelper.AddInParameter(cmd, "@Policy_Number", DbType.String, Objcy.Policy_Number);
                dbHelper.AddInParameter(cmd, "@Carrier", DbType.String, Objcy.Carrier);
                dbHelper.AddInParameter(cmd, "@Underwriter", DbType.String, Objcy.Underwriter);
                dbHelper.AddInParameter(cmd, "@Policy_Begin_Date", DbType.DateTime, Objcy.Policy_Begin_Date);
                dbHelper.AddInParameter(cmd, "@Policy_Expiration_Date", DbType.DateTime, Objcy.Policy_Expiration_Date);
                dbHelper.AddInParameter(cmd, "@Policy_Year", DbType.Int32, Objcy.Policy_Year);
                dbHelper.AddInParameter(cmd, "@FK_Entity", DbType.Decimal, Objcy.FK_Entity);
                dbHelper.AddInParameter(cmd, "@Annual_Premium", DbType.Decimal, Objcy.Annual_Premium);
                dbHelper.AddInParameter(cmd, "@Surplus_Lines_Fees", DbType.Decimal, Objcy.Surplus_Lines_Fees);
                dbHelper.AddInParameter(cmd, "@Deductible", DbType.String, Objcy.Deductible);
                dbHelper.AddInParameter(cmd, "@Deductible_Amount", DbType.Decimal, Objcy.Deductible_Amount);
                dbHelper.AddInParameter(cmd, "@Coverage_Form", DbType.String, Objcy.Coverage_Form);
                dbHelper.AddInParameter(cmd, "@Per_Occurrence_Limit", DbType.Decimal, Objcy.Per_Occurrence_Limit);
                dbHelper.AddInParameter(cmd, "@Aggregate_Limit", DbType.Decimal, Objcy.Aggregate_Limit);
                dbHelper.AddInParameter(cmd, "@Layered_Program", DbType.String, Objcy.Layered_Program);
                dbHelper.AddInParameter(cmd, "@FK_Layer", DbType.Decimal, Objcy.FK_Layer);
                dbHelper.AddInParameter(cmd, "@Underlying_Limit", DbType.Decimal, Objcy.Underlying_Limit);
                dbHelper.AddInParameter(cmd, "@Quota_Share", DbType.String, Objcy.Quota_Share);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objcy.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objcy.Update_Date);
                dbHelper.AddInParameter(cmd, "@Share_Precentage", DbType.Decimal, Objcy.Share_Precentage);
                dbHelper.AddInParameter(cmd, "@Share_Limit", DbType.Decimal, Objcy.Share_Limit);
                dbHelper.AddInParameter(cmd, "@Retroactive", DbType.String, Objcy.Retroactive);
                dbHelper.AddInParameter(cmd, "@ProgramID", DbType.Decimal, Objcy.ProgramID);
                dbHelper.AddInParameter(cmd, "@TPA", DbType.String, Objcy.TPA);
                dbHelper.AddInParameter(cmd, "@Store_Deductible", DbType.Decimal, Objcy.Store_Deductible);
                dbHelper.AddInParameter(cmd, "@Financial_Security_Required", DbType.String, Objcy.Financial_Security_Required);
                dbHelper.AddInParameter(cmd, "@FK_Financial_Security_Type", DbType.Decimal, Objcy.FK_Financial_Security_Type);
                dbHelper.AddInParameter(cmd, "@Policy_Notes", DbType.String, Objcy.Policy_Notes);
                dbHelper.AddInParameter(cmd, "@Original_Amount", DbType.Decimal, Objcy.Original_Amount);
                dbHelper.AddInParameter(cmd, "@Original_Amount_Date", DbType.DateTime, Objcy.Original_Amount_Date);
                dbHelper.AddInParameter(cmd, "@Change_Amount_1", DbType.Decimal, Objcy.Change_Amount_1);
                dbHelper.AddInParameter(cmd, "@Change_Amount_1_Date", DbType.DateTime, Objcy.Change_Amount_1_Date);
                dbHelper.AddInParameter(cmd, "@Change_Amount_2", DbType.Decimal, Objcy.Change_Amount_2);
                dbHelper.AddInParameter(cmd, "@Change_Amount_2_Date", DbType.DateTime, Objcy.Change_Amount_2_Date);
                dbHelper.AddInParameter(cmd, "@Change_Amount_3", DbType.Decimal, Objcy.Change_Amount_3);
                dbHelper.AddInParameter(cmd, "@Change_Amount_3_Date", DbType.DateTime, Objcy.Change_Amount_3_Date);
                dbHelper.AddInParameter(cmd, "@Change_Amount_4", DbType.Decimal, Objcy.Change_Amount_4);
                dbHelper.AddInParameter(cmd, "@Change_Amount_4_Date", DbType.DateTime, Objcy.Change_Amount_4_Date);

                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Policy_Id").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int Policy_Delete(System.Decimal lPK_Policy_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Decimal, lPK_Policy_Id);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_GetAll");
                dsCommon = dbHelper.ExecuteDataSet(cmd);

                cmd = null;
                dbHelper = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet Policy_GetByID(System.Decimal pK_Policy_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Decimal, pK_Policy_Id);
                dsCommon = dbHelper.ExecuteDataSet(cmd);

                cmd = null;
                dbHelper = null;

                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetPolicySearch(decimal FK_Policy_Type, string Carrier, int Policy_Year, Decimal pK_Security_Id,Decimal ProgramID,Decimal LocationID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetPolicySearch");
                dbHelper.AddInParameter(cmd, "@FK_Policy_Type", DbType.Decimal, FK_Policy_Type);
                dbHelper.AddInParameter(cmd, "@Carrier", DbType.String, Carrier.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Policy_Year", DbType.Int32, Policy_Year);
                dbHelper.AddInParameter(cmd, "@PK_Security_Id", DbType.Decimal, pK_Security_Id);
                dbHelper.AddInParameter(cmd, "@Program", DbType.Decimal, ProgramID);
                dbHelper.AddInParameter(cmd, "@Location", DbType.Decimal, LocationID);
                dsCommon = dbHelper.ExecuteDataSet(cmd);

                cmd = null;
                dbHelper = null;

                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public override DataSet GetPolicy_Popup_Search(System.String m_strColumn, System.String m_strCriteria)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyPopup_Search_Data");
                dbHelper.AddInParameter(cmd, "@ColumnName", DbType.String, m_strColumn.Replace("'", "''"));
                dbHelper.AddInParameter(cmd, "@Criteria", DbType.String, m_strCriteria.Replace("'", "''"));
                dsCommon = dbHelper.ExecuteDataSet(cmd);

                cmd = null;
                dbHelper = null;

                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public override int DeletePolicy(decimal PK_Policy_ID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int ret_Val = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Decimal, PK_Policy_ID);
                ret_Val = dbHelper.ExecuteNonQuery(cmd);

                cmd = null;
                dbHelper = null;

                return ret_Val;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetPolicyLayer()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Policy_GetLayers");
                dsCommon = dbHelper.ExecuteDataSet(cmd);

                cmd = null;
                dbHelper = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override int PolicyDuplicateCheck(RIMS_Base.CFCIPolicy Objcy)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckDuplicatePolicy");
                dbHelper.AddParameter(cmd, "@Total_Count", DbType.Int32, ParameterDirection.InputOutput, "Total_Count", DataRowVersion.Current,0);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Type", DbType.Decimal, Objcy.FK_Policy_Type);
                dbHelper.AddInParameter(cmd, "@Policy_Year", DbType.Int32, Objcy.Policy_Year);
                dbHelper.AddInParameter(cmd, "@FK_Layer", DbType.Decimal, Objcy.FK_Layer);
                dbHelper.AddInParameter(cmd, "@ProgramID", DbType.Decimal, Objcy.ProgramID);
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Decimal, Objcy.PK_Policy_Id);

                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Total_Count").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }

        public override int CheckSharedPercentagePolicy(RIMS_Base.CFCIPolicy Objcy)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("CheckSharedPercentagePolicy");
                dbHelper.AddParameter(cmd, "@Total_Count", DbType.Int32, ParameterDirection.InputOutput, "Total_Count", DataRowVersion.Current, 0);
                dbHelper.AddInParameter(cmd, "@FK_Policy_Type", DbType.Decimal, Objcy.FK_Policy_Type);
                dbHelper.AddInParameter(cmd, "@Policy_Year", DbType.Int32, Objcy.Policy_Year);
                dbHelper.AddInParameter(cmd, "@FK_Layer", DbType.Decimal, Objcy.FK_Layer);
                dbHelper.AddInParameter(cmd, "@ProgramID", DbType.Decimal, Objcy.ProgramID);
                dbHelper.AddInParameter(cmd, "@Share_Precentage", DbType.Decimal, Objcy.Share_Precentage != null ? Objcy.Share_Precentage : 0);
                dbHelper.AddInParameter(cmd, "@PK_Policy_Id", DbType.Decimal, Objcy.PK_Policy_Id);

                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Total_Count").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
    }


}


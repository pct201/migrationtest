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


    public class CPolicy_Features : RIMS_Base.CPolicy_Features
    {

        public override int PolicyFeatures_InsertUpdate(RIMS_Base.CPolicy_Features Objcy_Features)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyFeatures_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Policy_Features", DbType.Int32, ParameterDirection.InputOutput, "PK_Policy_Features", DataRowVersion.Current, Objcy_Features.PK_Policy_Features);
                dbHelper.AddInParameter(cmd, "@FK_Policy", DbType.Decimal, Objcy_Features.FK_Policy);
                dbHelper.AddInParameter(cmd, "@Feature", DbType.String, Objcy_Features.Feature);
                dbHelper.AddInParameter(cmd, "@Limit", DbType.Decimal, Objcy_Features.Limit);
                dbHelper.AddInParameter(cmd, "@Deductible", DbType.Decimal, Objcy_Features.Deductible);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objcy_Features.Notes);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objcy_Features.Updated_By);
                dbHelper.AddInParameter(cmd, "@Updated_Date", DbType.DateTime, Objcy_Features.Updated_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Policy_Features").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PolicyFeatures_Delete(System.Decimal lPK_Policy_Features)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyFeatures_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Features", DbType.Decimal, lPK_Policy_Features);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
       
        public override DataSet GetAll( )
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyFeatures_GetAll");
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


        public override DataSet PolicyFeatures_GetByID(System.Decimal pK_Policy_Features, System.Decimal m_dPolicyID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyFeatures_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Policy_Features", DbType.Decimal, pK_Policy_Features);
                dbHelper.AddInParameter(cmd, "@PK_Policy", DbType.Decimal, m_dPolicyID);
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
        public override DataSet PolicyFeatures_ByPolicyID(System.Decimal m_dPolicyID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PolicyFeatures_GetByPolicy");
                dbHelper.AddInParameter(cmd, "@PK_Policy", DbType.Decimal, m_dPolicyID);
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

    }


}


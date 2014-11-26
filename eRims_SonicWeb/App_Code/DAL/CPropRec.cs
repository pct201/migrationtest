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


    public class CPropRec : RIMS_Base.CPropRec
    {

        public override int PropRecommend_InsertUpdate(RIMS_Base.CPropRec Objerty_Recommendations)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRec_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Property_Recommendations", DbType.Decimal, ParameterDirection.InputOutput, "PK_Property_Recommendations", DataRowVersion.Current, Objerty_Recommendations.PK_Property_Recommendations);
                dbHelper.AddInParameter(cmd, "@FK_Property_COPE", DbType.Decimal, Objerty_Recommendations.FK_Property_COPE);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objerty_Recommendations.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objerty_Recommendations.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Recommendations").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
       
        public override DataSet GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRec_GetAll");
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


        public override DataSet PropRecommend_ById(System.Decimal Pk_Prop_Cope)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRec_GetAll");
//                dbHelper.AddInParameter(cmd, "@PK_Property_Recommendations", DbType.Decimal, pK_Property_Recommendations);
                dbHelper.AddInParameter(cmd, "@PK_Property_Cope", DbType.Decimal, Pk_Prop_Cope);
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


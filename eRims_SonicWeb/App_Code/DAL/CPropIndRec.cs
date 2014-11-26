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


    public class CPropIndRec : RIMS_Base.CPropIndRec
    {

        public override int PropIndRec_InsertUpdate(RIMS_Base.CPropIndRec Objvidual_Recommendations)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Individual_Recommendations", DbType.Decimal, ParameterDirection.InputOutput, "PK_Individual_Recommendations", DataRowVersion.Current, Objvidual_Recommendations.PK_Individual_Recommendations);
                dbHelper.AddInParameter(cmd, "@FK_Property_Recommendations", DbType.Decimal, Objvidual_Recommendations.FK_Property_Recommendations);
                dbHelper.AddInParameter(cmd, "@Visit", DbType.DateTime, Objvidual_Recommendations.Visit);
                dbHelper.AddInParameter(cmd, "@Recommendation_Number", DbType.String, Objvidual_Recommendations.Recommendation_Number);
                dbHelper.AddInParameter(cmd, "@FK_Recommendation_Type", DbType.Decimal, Objvidual_Recommendations.FK_Recommendation_Type);
                dbHelper.AddInParameter(cmd, "@FK_Recommended_By", DbType.Decimal, Objvidual_Recommendations.FK_Recommended_By);
                dbHelper.AddInParameter(cmd, "@FK_Recommendation_Status", DbType.Decimal, Objvidual_Recommendations.FK_Recommendation_Status);
                dbHelper.AddInParameter(cmd, "@Title", DbType.String, Objvidual_Recommendations.Title);
                dbHelper.AddInParameter(cmd, "@Recommendation_Description", DbType.String, Objvidual_Recommendations.Recommendation_Description);
                dbHelper.AddInParameter(cmd, "@Assigned_To", DbType.String, Objvidual_Recommendations.Assigned_To);
                dbHelper.AddInParameter(cmd, "@Due", DbType.DateTime, Objvidual_Recommendations.Due);
                dbHelper.AddInParameter(cmd, "@Assigned_To_Telephone_Number", DbType.String, Objvidual_Recommendations.Assigned_To_Telephone_Number);
                dbHelper.AddInParameter(cmd, "@Assigned_To_E_Mail", DbType.String, Objvidual_Recommendations.Assigned_To_E_Mail);
                dbHelper.AddInParameter(cmd, "@Resolution", DbType.String, Objvidual_Recommendations.Resolution);
                dbHelper.AddInParameter(cmd, "@Closed", DbType.DateTime, Objvidual_Recommendations.Closed);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objvidual_Recommendations.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objvidual_Recommendations.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Individual_Recommendations").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropIndRec_Delete(System.String lPK_Individual_Recommendations)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Individual_Recommendations", DbType.String, lPK_Individual_Recommendations);
                nRetVal = dbHelper.ExecuteNonQuery(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet PropIndRec_GetByRecID(decimal RecID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetByRecID");
                dbHelper.AddInParameter(cmd, "@RecID", DbType.Decimal, RecID);
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

        public override DataSet GetAll()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetAll");
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


        public override DataSet PropIndRec_GetByID(System.Decimal pK_Individual_Recommendations)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Individual_Recommendations", DbType.Decimal, pK_Individual_Recommendations);
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

        public override DataSet GetRecBy()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetRecBy");
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetRecStatus()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetRecStatus");
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetAssignedTo()
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetRecAssignedTo");
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public override DataSet GetRecType()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetRecType");
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DataSet GetDataAssignTo(decimal UserID)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropIndRec_GetDataAssignTo");
                dbHelper.AddInParameter(cmd, "@UserID", DbType.Int32, UserID);
                dsCommon = dbHelper.ExecuteDataSet(cmd);
                dbHelper = null; cmd.Dispose(); cmd = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }


}


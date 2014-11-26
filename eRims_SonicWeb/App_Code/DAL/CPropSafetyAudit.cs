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


    public class CPropSafetyAudit : RIMS_Base.CPropSafetyAudit
    {

        public override int PropSafetyAudit_InsertUpdate(RIMS_Base.CPropSafetyAudit Objty_Audit)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropSafetyAudit_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Safety_Audit", DbType.Int32, ParameterDirection.InputOutput, "PK_Safety_Audit", DataRowVersion.Current, Objty_Audit.PK_Safety_Audit);
                dbHelper.AddInParameter(cmd, "@FK_Property_COPE", DbType.Decimal, Objty_Audit.FK_Property_COPE);
                dbHelper.AddInParameter(cmd, "@Date_Of_Audit", DbType.DateTime, Objty_Audit.Date_Of_Audit);
                dbHelper.AddInParameter(cmd, "@Leader_Name", DbType.String, Objty_Audit.Leader_Name);
                dbHelper.AddInParameter(cmd, "@General_Safety_Actual", DbType.Decimal, Objty_Audit.General_Safety_Actual);
                dbHelper.AddInParameter(cmd, "@General_Safety_Maximum", DbType.Decimal, Objty_Audit.General_Safety_Maximum);
                dbHelper.AddInParameter(cmd, "@General_Safety_Percent", DbType.Decimal, Objty_Audit.General_Safety_Percent);
                dbHelper.AddInParameter(cmd, "@Housekeeping_Actual", DbType.Decimal, Objty_Audit.Housekeeping_Actual);
                dbHelper.AddInParameter(cmd, "@Housekeeping_Maximum", DbType.Decimal, Objty_Audit.Housekeeping_Maximum);
                dbHelper.AddInParameter(cmd, "@Housekeeping_Percent", DbType.Decimal, Objty_Audit.Housekeeping_Percent);
                dbHelper.AddInParameter(cmd, "@Ergonomics_Actual", DbType.Decimal, Objty_Audit.Ergonomics_Actual);
                dbHelper.AddInParameter(cmd, "@Ergonomics_Maximum", DbType.Decimal, Objty_Audit.Ergonomics_Maximum);
                dbHelper.AddInParameter(cmd, "@Ergonomics_Percent", DbType.Decimal, Objty_Audit.Ergonomics_Percent);
                dbHelper.AddInParameter(cmd, "@EAP_Actual", DbType.Decimal, Objty_Audit.EAP_Actual);
                dbHelper.AddInParameter(cmd, "@EAP_Maximum", DbType.Decimal, Objty_Audit.EAP_Maximum);
                dbHelper.AddInParameter(cmd, "@EAP_Percent", DbType.Decimal, Objty_Audit.EAP_Percent);
                dbHelper.AddInParameter(cmd, "@Hazardous_Materials_Actual", DbType.Decimal, Objty_Audit.Hazardous_Materials_Actual);
                dbHelper.AddInParameter(cmd, "@Hazardous_Materials_Maximum", DbType.Decimal, Objty_Audit.Hazardous_Materials_Maximum);
                dbHelper.AddInParameter(cmd, "@Hazardous_Materials_Percent", DbType.Decimal, Objty_Audit.Hazardous_Materials_Percent);
                dbHelper.AddInParameter(cmd, "@Fire_Electrical_Actual", DbType.Decimal, Objty_Audit.Fire_Electrical_Actual);
                dbHelper.AddInParameter(cmd, "@Fire_Electrical_Maximum", DbType.Decimal, Objty_Audit.Fire_Electrical_Maximum);
                dbHelper.AddInParameter(cmd, "@Fire_Electrical_Percent", DbType.Decimal, Objty_Audit.Fire_Electrical_Percent);
                dbHelper.AddInParameter(cmd, "@Vehicle_Safety_Actual", DbType.Decimal, Objty_Audit.Vehicle_Safety_Actual);
                dbHelper.AddInParameter(cmd, "@Vehicle_Safety_Maximum", DbType.Decimal, Objty_Audit.Vehicle_Safety_Maximum);
                dbHelper.AddInParameter(cmd, "@Vehicle_Safety_Percent", DbType.Decimal, Objty_Audit.Vehicle_Safety_Percent);
                dbHelper.AddInParameter(cmd, "@Safety_Culture_Actual", DbType.Decimal, Objty_Audit.Safety_Culture_Actual);
                dbHelper.AddInParameter(cmd, "@Safety_Culture_Maximum", DbType.Decimal, Objty_Audit.Safety_Culture_Maximum);
                dbHelper.AddInParameter(cmd, "@Safety_Culture_Percent", DbType.Decimal, Objty_Audit.Safety_Culture_Percent);
                dbHelper.AddInParameter(cmd, "@Physical_Security_Actual", DbType.Decimal, Objty_Audit.Physical_Security_Actual);
                dbHelper.AddInParameter(cmd, "@Physical_Security_Maximum", DbType.Decimal, Objty_Audit.Physical_Security_Maximum);
                dbHelper.AddInParameter(cmd, "@Physical_Security_Percent", DbType.Decimal, Objty_Audit.Physical_Security_Percent);
                dbHelper.AddInParameter(cmd, "@Network_Operations_Actual", DbType.Decimal, Objty_Audit.Network_Operations_Actual);
                dbHelper.AddInParameter(cmd, "@Network_Operations_Maximum", DbType.Decimal, Objty_Audit.Network_Operations_Maximum);
                dbHelper.AddInParameter(cmd, "@Network_Operations_Percent", DbType.Decimal, Objty_Audit.Network_Operations_Percent);
                dbHelper.AddInParameter(cmd, "@PPE_Actual", DbType.Decimal, Objty_Audit.PPE_Actual);
                dbHelper.AddInParameter(cmd, "@PPE_Maximum", DbType.Decimal, Objty_Audit.PPE_Maximum);
                dbHelper.AddInParameter(cmd, "@PPE_Percent", DbType.Decimal, Objty_Audit.PPE_Percent);
                dbHelper.AddInParameter(cmd, "@Hand_Tool_Eqiupment_Actual", DbType.Decimal, Objty_Audit.Hand_Tool_Eqiupment_Actual);
                dbHelper.AddInParameter(cmd, "@Hand_Tool_Eqiupment_Maximum", DbType.Decimal, Objty_Audit.Hand_Tool_Eqiupment_Maximum);
                dbHelper.AddInParameter(cmd, "@Hand_Tool_Eqiupment_Percent", DbType.Decimal, Objty_Audit.Hand_Tool_Eqiupment_Percent);
                dbHelper.AddInParameter(cmd, "@Battery_Room_Actual", DbType.Decimal, Objty_Audit.Battery_Room_Actual);
                dbHelper.AddInParameter(cmd, "@Battery_Room_Maximum", DbType.Decimal, Objty_Audit.Battery_Room_Maximum);
                dbHelper.AddInParameter(cmd, "@Battery_Room_Percent", DbType.Decimal, Objty_Audit.Battery_Room_Percent);
                dbHelper.AddInParameter(cmd, "@Special_HLE_Actual", DbType.Decimal, Objty_Audit.Special_HLE_Actual);
                dbHelper.AddInParameter(cmd, "@Special_HLE_Maximum", DbType.Decimal, Objty_Audit.Special_HLE_Maximum);
                dbHelper.AddInParameter(cmd, "@Special_HLE_Percent", DbType.Decimal, Objty_Audit.Special_HLE_Percent);
                dbHelper.AddInParameter(cmd, "@Excavations_Actual", DbType.Decimal, Objty_Audit.Excavations_Actual);
                dbHelper.AddInParameter(cmd, "@Excavations_Maximum", DbType.Decimal, Objty_Audit.Excavations_Maximum);
                dbHelper.AddInParameter(cmd, "@Excavations_Percent", DbType.Decimal, Objty_Audit.Excavations_Percent);
                dbHelper.AddInParameter(cmd, "@Fall_Protection_Actual", DbType.Decimal, Objty_Audit.Fall_Protection_Actual);
                dbHelper.AddInParameter(cmd, "@Fall_Protection_Maximum", DbType.Decimal, Objty_Audit.Fall_Protection_Maximum);
                dbHelper.AddInParameter(cmd, "@Fall_Protection_Percent", DbType.Decimal, Objty_Audit.Fall_Protection_Percent);
                dbHelper.AddInParameter(cmd, "@Confined_Space_Actual", DbType.Decimal, Objty_Audit.Confined_Space_Actual);
                dbHelper.AddInParameter(cmd, "@Confined_Space_Maximum", DbType.Decimal, Objty_Audit.Confined_Space_Maximum);
                dbHelper.AddInParameter(cmd, "@Confined_Space_Percent", DbType.Decimal, Objty_Audit.Confined_Space_Percent);
                dbHelper.AddInParameter(cmd, "@Total_Actual", DbType.Decimal, Objty_Audit.Total_Actual);
                dbHelper.AddInParameter(cmd, "@Total_Maximum", DbType.Decimal, Objty_Audit.Total_Maximum);
                dbHelper.AddInParameter(cmd, "@Total_Percent", DbType.Decimal, Objty_Audit.Total_Percent);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objty_Audit.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objty_Audit.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Safety_Audit").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropSafetyAudit__Delete(System.String lPK_Safety_Audit)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropSafetyAudit__Delete");
                dbHelper.AddInParameter(cmd, "@PK_Safety_Audit", DbType.Decimal, lPK_Safety_Audit);
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
                cmd = dbHelper.GetStoredProcCommand("PropSafetyAudit_GetAll");
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


        public override DataSet PropSafetyAudit_GetByID(System.Decimal pK_Safety_Audit)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropSafetyAudit_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Safety_Audit", DbType.Decimal, pK_Safety_Audit);

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

        public override DataSet PropSafetyAudit_BYCOPEId(System.Decimal PK_COPE_Id)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropSafetyAudit_ByCOPE");
                dbHelper.AddInParameter(cmd, "@PK_COPE_Id", DbType.Decimal, PK_COPE_Id);

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


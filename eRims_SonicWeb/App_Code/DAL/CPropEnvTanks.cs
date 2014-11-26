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


    public class CPropEnvTanks : RIMS_Base.CPropEnvTanks
    {
        public override int PropEnvTanks_InsertUpdate(RIMS_Base.CPropEnvTanks Objronmental_Tanks)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvTanks_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Environmental_Tanks", DbType.Decimal, ParameterDirection.InputOutput, "PK_Environmental_Tanks", DataRowVersion.Current, Objronmental_Tanks.PK_Environmental_Tanks);
                dbHelper.AddInParameter(cmd, "@FK_Property_Environmental", DbType.Decimal, Objronmental_Tanks.FK_Property_Environmental);
                dbHelper.AddInParameter(cmd, "@Identification", DbType.String, Objronmental_Tanks.Identification);
                dbHelper.AddInParameter(cmd, "@FK_Tank_Type", DbType.Decimal, Objronmental_Tanks.FK_Tank_Type);
                dbHelper.AddInParameter(cmd, "@FK_Tank_Contents", DbType.Decimal, Objronmental_Tanks.FK_Tank_Contents);
                dbHelper.AddInParameter(cmd, "@Contents_Other", DbType.String, Objronmental_Tanks.Contents_Other);
                dbHelper.AddInParameter(cmd, "@Capacity", DbType.Decimal, Objronmental_Tanks.Capacity);
                dbHelper.AddInParameter(cmd, "@FK_Tank_Status", DbType.Decimal, Objronmental_Tanks.FK_Tank_Status);
                dbHelper.AddInParameter(cmd, "@FK_Tank_Material", DbType.Decimal, Objronmental_Tanks.FK_Tank_Material);
                dbHelper.AddInParameter(cmd, "@Material_Other", DbType.String, Objronmental_Tanks.Material_Other);
                dbHelper.AddInParameter(cmd, "@FK_Tank_Construction", DbType.Decimal, Objronmental_Tanks.FK_Tank_Construction);
                dbHelper.AddInParameter(cmd, "@Construction_Other", DbType.String, Objronmental_Tanks.Construction_Other);
                dbHelper.AddInParameter(cmd, "@Release_Equipment_Present", DbType.String, Objronmental_Tanks.Release_Equipment_Present);
                dbHelper.AddInParameter(cmd, "@Release_Eqiupment_Description", DbType.String, Objronmental_Tanks.Release_Eqiupment_Description);
                dbHelper.AddInParameter(cmd, "@Installation", DbType.DateTime, Objronmental_Tanks.Installation);
                dbHelper.AddInParameter(cmd, "@Removal", DbType.DateTime, Objronmental_Tanks.Removal);
                dbHelper.AddInParameter(cmd, "@Closure", DbType.DateTime, Objronmental_Tanks.Closure);
                dbHelper.AddInParameter(cmd, "@Last_Inspection", DbType.DateTime, Objronmental_Tanks.Last_Inspection);
                dbHelper.AddInParameter(cmd, "@Next_Inspection", DbType.DateTime, Objronmental_Tanks.Next_Inspection);
                dbHelper.AddInParameter(cmd, "@Inspection_Company", DbType.String, Objronmental_Tanks.Inspection_Company);
                dbHelper.AddInParameter(cmd, "@Inspection_Company_Contact_Name", DbType.String, Objronmental_Tanks.Inspection_Company_Contact_Name);
                dbHelper.AddInParameter(cmd, "@Inspection_Company_Telephone_Number", DbType.String, Objronmental_Tanks.Inspection_Company_Telephone_Number);
                dbHelper.AddInParameter(cmd, "@Permit_Required", DbType.String, Objronmental_Tanks.Permit_Required);
                dbHelper.AddInParameter(cmd, "@Registration_Number", DbType.String, Objronmental_Tanks.Registration_Number);
                dbHelper.AddInParameter(cmd, "@Certificate_Number", DbType.String, Objronmental_Tanks.Certificate_Number);
                dbHelper.AddInParameter(cmd, "@Permit_Begin", DbType.DateTime, Objronmental_Tanks.Permit_Begin);
                dbHelper.AddInParameter(cmd, "@Permit_End", DbType.DateTime, Objronmental_Tanks.Permit_End);
                dbHelper.AddInParameter(cmd, "@Other_Reporting_Requirements", DbType.String, Objronmental_Tanks.Other_Reporting_Requirements);
                dbHelper.AddInParameter(cmd, "@Reporting_Requirements_Description", DbType.String, Objronmental_Tanks.Reporting_Requirements_Description);
                dbHelper.AddInParameter(cmd, "@Next_Report", DbType.DateTime, Objronmental_Tanks.Next_Report);
                dbHelper.AddInParameter(cmd, "@Notes", DbType.String, Objronmental_Tanks.Notes);
                dbHelper.AddInParameter(cmd, "@SPCCP_Identification", DbType.String, Objronmental_Tanks.SPCCP_Identification);
                dbHelper.AddInParameter(cmd, "@SPCCP_Effective", DbType.DateTime, Objronmental_Tanks.SPCCP_Effective);
                dbHelper.AddInParameter(cmd, "@SPCCP_Expiration", DbType.DateTime, Objronmental_Tanks.SPCCP_Expiration);
                dbHelper.AddInParameter(cmd, "@SPCCP_Last_Revision", DbType.DateTime, Objronmental_Tanks.SPCCP_Last_Revision);
                dbHelper.AddInParameter(cmd, "@SPCCP_Vendor", DbType.String, Objronmental_Tanks.SPCCP_Vendor);
                dbHelper.AddInParameter(cmd, "@SPCCP_Vendor_Contact", DbType.String, Objronmental_Tanks.SPCCP_Vendor_Contact);
                dbHelper.AddInParameter(cmd, "@SPCCP_Vendor_Telephone_Number", DbType.String, Objronmental_Tanks.SPCCP_Vendor_Telephone_Number);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objronmental_Tanks.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objronmental_Tanks.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Environmental_Tanks").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropEnvTanks_Delete(System.String lPK_Environmental_Tanks)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvTanks_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Environmental_Tanks", DbType.Decimal, lPK_Environmental_Tanks);
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
                cmd = dbHelper.GetStoredProcCommand("PropEnvTanks_GetAll");
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
        public override DataSet PropEnvTanks_GetByID(System.Decimal pK_Environmental_Tanks)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEnvTanks_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Environmental_Tanks", DbType.Decimal, pK_Environmental_Tanks);
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
        public override DataSet GetAllCombo()
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("GetAll_PropEnvTanksCombo");
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
        public override DataSet GetOtherReportingReq(decimal Pk_Environmental_Tanks)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropRptRqmts_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Tanks_Other_Reporting_Rqmts", DbType.Decimal, Pk_Environmental_Tanks);
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


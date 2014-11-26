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


    public class CPropOtherContacts : RIMS_Base.CPropOtherContacts
    {

        public override int PropOtherContacts_InsertUpdate(RIMS_Base.CPropOtherContacts Objr_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropOtherContacts_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Other_Contacts", DbType.Decimal, ParameterDirection.InputOutput, "PK_Other_Contacts", DataRowVersion.Current, Objr_Contacts.PK_Other_Contacts);
                dbHelper.AddInParameter(cmd, "@FK_Property_Contacts", DbType.Decimal, Objr_Contacts.FK_Property_Contacts);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objr_Contacts.Type);
                dbHelper.AddInParameter(cmd, "@Company_Name", DbType.String, Objr_Contacts.Company_Name);
                dbHelper.AddInParameter(cmd, "@Contact_Name", DbType.String, Objr_Contacts.Contact_Name);
                dbHelper.AddInParameter(cmd, "@Telephone_Number", DbType.String, Objr_Contacts.Telephone_Number);
                dbHelper.AddInParameter(cmd, "@E_Mail", DbType.String, Objr_Contacts.E_Mail);
                dbHelper.AddInParameter(cmd, "@Alternate_Telephone", DbType.String, Objr_Contacts.Alternate_Telephone);
                dbHelper.AddInParameter(cmd, "@Description", DbType.String, Objr_Contacts.Description);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objr_Contacts.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objr_Contacts.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Other_Contacts").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropOtherContacts_Delete(System.String lPK_Other_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropOtherContacts_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Other_Contacts", DbType.Decimal, lPK_Other_Contacts);
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
                cmd = dbHelper.GetStoredProcCommand("PropOtherContacts_GetAll");
                
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


        public override DataSet PropOtherContacts_GetByID(System.Decimal pK_Other_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropOtherContacts_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Other_Contacts", DbType.Decimal, pK_Other_Contacts);
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
        public override DataSet OtherContacts_ByContactID(System.Decimal PK_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_Other_Contact_ByContact");
                dbHelper.AddInParameter(cmd, "@PK_Contacts", DbType.Decimal, PK_Contacts);
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


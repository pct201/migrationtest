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


    public class CPropUtilContacts : RIMS_Base.CPropUtilContacts
    {

        public override int PropUtilContacts_InsertUpdate(RIMS_Base.CPropUtilContacts Objity_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropUtilContacts_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Utility_Contacts", DbType.Decimal, ParameterDirection.InputOutput, "PK_Utility_Contacts", DataRowVersion.Current, Objity_Contacts.PK_Utility_Contacts);
                dbHelper.AddInParameter(cmd, "@FK_Property_Contacts", DbType.Decimal, Objity_Contacts.FK_Property_Contacts);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objity_Contacts.Type);
                dbHelper.AddInParameter(cmd, "@Company_Name", DbType.String, Objity_Contacts.Company_Name);
                dbHelper.AddInParameter(cmd, "@Contact_Name", DbType.String, Objity_Contacts.Contact_Name);
                dbHelper.AddInParameter(cmd, "@Telephone_Number", DbType.String, Objity_Contacts.Telephone_Number);
                dbHelper.AddInParameter(cmd, "@E_Mail", DbType.String, Objity_Contacts.E_Mail);
                dbHelper.AddInParameter(cmd, "@Alternate_Telephone", DbType.String, Objity_Contacts.Alternate_Telephone);
                dbHelper.AddInParameter(cmd, "@Description", DbType.String, Objity_Contacts.Description);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objity_Contacts.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objity_Contacts.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Utility_Contacts").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int PropUtilContacts_Delete(System.String lPK_Utility_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropUtilContacts_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Utility_Contacts", DbType.Decimal, lPK_Utility_Contacts);
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
                cmd = dbHelper.GetStoredProcCommand("PropUtilContacts_GetAll");
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


        public override DataSet PropUtilContacts_GetByID(System.Decimal pK_Utility_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropUtilContacts_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Utility_Contacts", DbType.Decimal, pK_Utility_Contacts);
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
        public override DataSet UtilContacts_ByContactID(System.Decimal PK_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_Util_Contact_ByContact");
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


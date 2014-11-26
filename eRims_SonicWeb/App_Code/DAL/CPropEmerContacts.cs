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


    public class CPropEmerContacts : RIMS_Base.CPropEmerContacts
    {

        public override int PropEmerContacts_InsertUpdate(RIMS_Base.CPropEmerContacts Objgency_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEmerContacts_InsertUpdate");
                dbHelper.AddParameter(cmd, "@PK_Emergency_Contacts", DbType.Decimal, ParameterDirection.InputOutput, "PK_Emergency_Contacts", DataRowVersion.Current, Objgency_Contacts.PK_Emergency_Contacts);
                dbHelper.AddInParameter(cmd, "@FK_Property_Contacts", DbType.Decimal, Objgency_Contacts.FK_Property_Contacts);
                dbHelper.AddInParameter(cmd, "@Type", DbType.String, Objgency_Contacts.Type);
                dbHelper.AddInParameter(cmd, "@Company_Name", DbType.String, Objgency_Contacts.Company_Name);
                dbHelper.AddInParameter(cmd, "@Contact_Name", DbType.String, Objgency_Contacts.Contact_Name);
                dbHelper.AddInParameter(cmd, "@Telephone_Number", DbType.String, Objgency_Contacts.Telephone_Number);
                dbHelper.AddInParameter(cmd, "@E_Mail", DbType.String, Objgency_Contacts.E_Mail);
                dbHelper.AddInParameter(cmd, "@Alternate_Telephone", DbType.String, Objgency_Contacts.Alternate_Telephone);
                dbHelper.AddInParameter(cmd, "@Description", DbType.String, Objgency_Contacts.Description);
                dbHelper.AddInParameter(cmd, "@Updated_By", DbType.Decimal, Objgency_Contacts.Updated_By);
                dbHelper.AddInParameter(cmd, "@Update_Date", DbType.DateTime, Objgency_Contacts.Update_Date);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Emergency_Contacts").ToString());
                
                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        public override int EContacts_Master_InsertUpdate(RIMS_Base.CPropEmerContacts Objgency_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = 0;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_DeafultEntry");
                dbHelper.AddParameter(cmd, "@Pk_Contact_Id", DbType.Int32, ParameterDirection.InputOutput, "@Pk_Contact_Id", DataRowVersion.Current, Objgency_Contacts.FK_Property_Contacts);
                dbHelper.AddInParameter(cmd, "@FK_Property_COPE", DbType.Decimal, Objgency_Contacts.PK_COPE_Id);
                dbHelper.AddInParameter(cmd, "@UserID", DbType.Decimal, Objgency_Contacts.Updated_By);
                dbHelper.ExecuteNonQuery(cmd);
                nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@Pk_Contact_Id").ToString());

                return nRetVal;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            { dbHelper = null; cmd.Dispose(); cmd = null; }
        }
        
        public override int PropEmerContacts_Delete(System.String lPK_Emergency_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            int nRetVal = -1;
            
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEmerContacts_Delete");
                dbHelper.AddInParameter(cmd, "@PK_Emergency_Contacts", DbType.Decimal, lPK_Emergency_Contacts);
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
                cmd = dbHelper.GetStoredProcCommand("PropEmerContacts_GetAll");
                dsCommon=dbHelper.ExecuteDataSet(cmd);
                cmd = null;
                dbHelper = null;
                return dsCommon;
            }
            catch (Exception)
            {
                throw;
            }
        }


        public override DataSet PropEmerContacts_GetByID(System.Decimal pK_Emergency_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("PropEmerContacts_GetAll");
                dbHelper.AddInParameter(cmd, "@PK_Emergency_Contacts", DbType.Decimal, pK_Emergency_Contacts);

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
        public override DataSet ContactId_ByCOPE(System.Decimal m_dCOPEId)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("ContactId_ByCOPE");
                dbHelper.AddInParameter(cmd, "@COPEId", DbType.Decimal, m_dCOPEId);

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
        public override DataSet EmerContacts_ByContactID(System.Decimal PK_Contacts)
        {
            Database dbHelper = null;
            DbCommand cmd = null;
            DataSet dsCommon = new DataSet();
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Property_EmergencyContact_ByContact");
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


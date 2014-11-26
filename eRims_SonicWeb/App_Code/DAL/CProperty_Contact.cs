using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Common;
using System.Configuration;
using System.Globalization;
using System.Data.Common;

namespace RIMS_Base.Dal
{
    
    public class CProperty_Contact : RIMS_Base.CProperty_Contact
    {

        public override int InsertUpdateP_Contacts(RIMS_Base.CProperty_Contact Objerty_Contacts)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
            cmd = dbHelper.GetStoredProcCommand("Property_Contacts_InsertUpdate");
			dbHelper.AddParameter(cmd,"@PK_Property_Contacts",DbType.Int32, ParameterDirection.InputOutput, "PK_Property_Contacts", DataRowVersion.Current,Objerty_Contacts.PK_Property_Contacts);
			dbHelper.AddInParameter(cmd,"@FK_Property_COPE",DbType.Decimal,Objerty_Contacts.FK_Property_COPE);
			dbHelper.AddInParameter(cmd,"@Facility_Name",DbType.String,Objerty_Contacts.Facility_Name);
			dbHelper.AddInParameter(cmd,"@Facility_Telephone_Number",DbType.String,Objerty_Contacts.Facility_Telephone_Number);
			dbHelper.AddInParameter(cmd,"@Facility_Facsimile_Number",DbType.String,Objerty_Contacts.Facility_Facsimile_Number);
			dbHelper.AddInParameter(cmd,"@Facility_Call_Phone_Number",DbType.String,Objerty_Contacts.Facility_Call_Phone_Number);
			dbHelper.AddInParameter(cmd,"@AH_Name",DbType.String,Objerty_Contacts.AH_Name);
			dbHelper.AddInParameter(cmd,"@AH_Telephone_Number",DbType.String,Objerty_Contacts.AH_Telephone_Number);
			dbHelper.AddInParameter(cmd,"@AH_Facsimile_Number",DbType.String,Objerty_Contacts.AH_Facsimile_Number);
			dbHelper.AddInParameter(cmd,"@AH_Call_Phone_Number",DbType.String,Objerty_Contacts.AH_Call_Phone_Number);
			dbHelper.AddInParameter(cmd,"@Updated_By",DbType.Decimal,Objerty_Contacts.Updated_By);
			dbHelper.AddInParameter(cmd,"@Update_Date",DbType.DateTime,Objerty_Contacts.Update_Date);
			dbHelper.ExecuteNonQuery(cmd);
			nRetVal = int.Parse(dbHelper.GetParameterValue(cmd, "@PK_Property_Contacts").ToString());
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
		finally
		{ dbHelper = null; cmd.Dispose(); cmd = null; }
	}
        public override int DeleteP_Contacts(System.Decimal lPK_Property_Contacts)
	{
		Database dbHelper = null;
		DbCommand cmd = null;
		int nRetVal = -1;
		try
		{
			dbHelper = DatabaseFactory.CreateDatabase();
			cmd = dbHelper.GetStoredProcCommand("Pro_Deleteerty_Contacts");
			dbHelper.AddInParameter(cmd,"@PK_Property_Contacts",DbType.Decimal,lPK_Property_Contacts);
			nRetVal = dbHelper.ExecuteNonQuery(cmd);
			dbHelper = null; cmd.Dispose(); cmd = null;
			return nRetVal;
		}
        catch (Exception)
        {
            throw ;
        }
    }
        public override DataSet GetAll()
	{
        //Database dbHelper = null;
        //DbCommand cmd = null;
        //try
        //{
        //    dbHelper = DatabaseFactory.CreateDatabase();
        //    cmd = dbHelper.GetStoredProcCommand("Pro_Selecterty_Contacts");
        //    dbHelper.AddInParameter(cmd,"@IsActive",DbType.Boolean,blnIsActive);
        //    IDataReader reader = dbHelper.ExecuteReader(cmd);
        //    List<RIMS_Base.erty_Contacts> results = new List<RIMS_Base.erty_Contacts>();
        //    while (reader.Read())
        //    {
        //        erty_Contacts objerty_Contacts = new erty_Contacts();
        //        objerty_Contacts = MapFrom(reader);
        //        results.Add(objerty_Contacts);
        //    }
        //    reader.Close();
        //    cmd = null;
        //    dbHelper = null;
        //    return results;
        //}
        //catch (Exception)
        //{
        //    throw ;
        //}
            DataSet m_dsCommon=new DataSet();
            return m_dsCommon;
    }
        public override DataSet GetP_ContactsByID(System.Decimal pK_Property_Contacts)
	{
        //Database dbHelper = null;
        //DbCommand cmd = null;
        //try
        //{
        //    dbHelper = DatabaseFactory.CreateDatabase();
        //    cmd = dbHelper.GetStoredProcCommand("Pro_Selecterty_Contacts");
        //    dbHelper.AddInParameter(cmd,"@PK_Property_Contacts",DbType.Decimal,pK_Property_Contacts);

        //    IDataReader reader = dbHelper.ExecuteReader(cmd);
        //    erty_Contacts objerty_Contacts = new erty_Contacts();
        //    if (reader.Read())
        //    {
        //        objerty_Contacts =  MapFrom(reader);
        //    }
        //    reader.Close();
        //    cmd = null;
        //    dbHelper = null;

        //    return objerty_Contacts;
        //}
        //catch (Exception)
        //{
        //    throw ;
        //}
        DataSet m_dsCommon = new DataSet();
        return m_dsCommon;
    }
}

}

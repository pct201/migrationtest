using System;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;


/// <summary>
/// Summary description for clsGetInsuredName_SONIC
/// </summary>
/// 
namespace ERIMS.DAL
{
    
    public class clsGetInsuredName_SONIC
    {
        public clsGetInsuredName_SONIC()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        
        public static DataSet GetRegionList()
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString(); 

            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("GetLu_Location_RegionList");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetLu_Location_DBA_List()
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString(); 

            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("GetLu_Location_DBA_List");

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet GetState()
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString();
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("StateSelectAll");     
       
            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SearchByPaging(decimal? fK_LU_State, string strRegion, decimal? PK_LU_Location_DBA_ID, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString();
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("InsuredName_Search");
         
            db.AddInParameter(dbCommand, "FK_LU_State", DbType.Decimal, fK_LU_State);
            db.AddInParameter(dbCommand, "FK_Region", DbType.String, strRegion);
            db.AddInParameter(dbCommand, "FK_DBA", DbType.Decimal, PK_LU_Location_DBA_ID);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_Region_DBA_State_DropDownSelectedValue(string strSelectDropDown, string strSelectDropDownValue,string stRegion)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString();
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Get_Region_DBA_State_SelectBy_DropDown");

            db.AddInParameter(dbCommand, "strSelectDrpoDown", DbType.String, strSelectDropDown);
            db.AddInParameter(dbCommand, "ddlselectvalue", DbType.String, strSelectDropDownValue);
            db.AddInParameter(dbCommand, "strregion", DbType.String, stRegion);

            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_RegionWise_State_Location(string stRegion)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString();
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Get_RegionWise_State_Location");      
           
            db.AddInParameter(dbCommand, "strregion", DbType.String, stRegion);

            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_DBA_Wise_State_Region(string strDBA, string strregion)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString();
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Get_DBA_Wise_State_Region");

            db.AddInParameter(dbCommand, "strDBA", DbType.String, strDBA);
            db.AddInParameter(dbCommand, "strregion", DbType.String, strregion);

            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet Get_State_Wise_DBA_Region(string strState, string strregion)
        {
            string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SONICConn"].ToString();
            DbProviderFactory factory = System.Data.Common.DbProviderFactories.GetFactory("System.Data.SqlClient");
            Database db = new GenericDatabase(strConnection, factory);
            DbCommand dbCommand = db.GetStoredProcCommand("Get_State_Wise_DBA_Region");

            db.AddInParameter(dbCommand, "strState", DbType.String, strState);
            db.AddInParameter(dbCommand, "strregion", DbType.String, strregion);

            dbCommand.CommandTimeout = 10000;

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for ExposureCommon
    /// </summary>
    public class ExposureCommon
    {
        public ExposureCommon()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region "Methods"

        public static DataSet GetExposuresSearchResult(string strPKLocationIDs, string strFromDate,string strToDate, string strOrderBy, string strOrder, int intPageNo, int intPageSize,
                        string Regional, Nullable<decimal> CurrentEmployee, string strMainAddress, string strMainCity, string strMainState, string strMainZip, string strBuildingAddress,
                        string strBuildingCity, string strBuildingState, string strBuildingZip,string strConstructionProjectNumber
            )
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ExposuresSearch");

            db.AddInParameter(dbCommand, "PK_Location_IDs", DbType.String, strPKLocationIDs);
            db.AddInParameter(dbCommand, "From_Date", DbType.String, strFromDate);
            db.AddInParameter(dbCommand, "To_Date", DbType.String, strToDate);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "@Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "@CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "@MainAddress", DbType.String, strMainAddress);
            db.AddInParameter(dbCommand, "@MainCity", DbType.String, strMainCity);
            db.AddInParameter(dbCommand, "@MainState", DbType.String, strMainState);
            db.AddInParameter(dbCommand, "@MainZip", DbType.String, strMainZip);
            db.AddInParameter(dbCommand, "@BuildingAddress", DbType.String, strBuildingAddress);
            db.AddInParameter(dbCommand, "@BuildingCity", DbType.String, strBuildingCity);
            db.AddInParameter(dbCommand, "@BuildingState", DbType.String, strBuildingState);
            db.AddInParameter(dbCommand, "@BuildingZip", DbType.String, strBuildingZip);
           db.AddInParameter(dbCommand, "@ConstructionProjectNumber", DbType.String, strConstructionProjectNumber);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Outlook AddIn Exposure Search Result
        /// </summary>
        /// <param name="strPKLocationIDs"></param>
        /// <param name="strFromDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="strOrderBy"></param>
        /// <param name="strOrder"></param>
        /// <param name="intPageNo"></param>
        /// <param name="intPageSize"></param>
        /// <param name="Regional"></param>
        /// <param name="CurrentEmployee"></param>
        /// <param name="strMainAddress"></param>
        /// <param name="strMainCity"></param>
        /// <param name="strMainState"></param>
        /// <param name="strMainZip"></param>
        /// <param name="strBuildingAddress"></param>
        /// <param name="strBuildingCity"></param>
        /// <param name="strBuildingState"></param>
        /// <param name="strBuildingZip"></param>
        /// <returns></returns>
        public static DataSet GetOutlookExposureResult(string strPKLocationIDs, string strFromDate, string strToDate, string strOrderBy, string strOrder, int intPageNo, int intPageSize,
                        string Regional, Nullable<decimal> CurrentEmployee, string strMainAddress, string strMainCity, string strMainState, string strMainZip, string strBuildingAddress,
                        string strBuildingCity, string strBuildingState, string strBuildingZip)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Outlook_Exposure_Search");

            db.AddInParameter(dbCommand, "PK_Location_IDs", DbType.String, strPKLocationIDs);
            db.AddInParameter(dbCommand, "From_Date", DbType.String, strFromDate);
            db.AddInParameter(dbCommand, "To_Date", DbType.String, strToDate);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "@Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "@CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "@MainAddress", DbType.String, strMainAddress);
            db.AddInParameter(dbCommand, "@MainCity", DbType.String, strMainCity);
            db.AddInParameter(dbCommand, "@MainState", DbType.String, strMainState);
            db.AddInParameter(dbCommand, "@MainZip", DbType.String, strMainZip);
            db.AddInParameter(dbCommand, "@BuildingAddress", DbType.String, strBuildingAddress);
            db.AddInParameter(dbCommand, "@BuildingCity", DbType.String, strBuildingCity);
            db.AddInParameter(dbCommand, "@BuildingState", DbType.String, strBuildingState);
            db.AddInParameter(dbCommand, "@BuildingZip", DbType.String, strBuildingZip);
            return db.ExecuteDataSet(dbCommand);
        }

        #endregion
    }
}
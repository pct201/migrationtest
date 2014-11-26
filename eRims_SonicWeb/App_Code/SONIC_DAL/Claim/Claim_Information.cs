using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for Claim_Information
    /// </summary>
    public class Claim_Information
    {
        public Claim_Information()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// GEt Search Result
        /// </summary>
        /// <returns>DataSet</returns>
        /// Last Two Parameter is Added by Ravi Gupta 19/12/2008 (string Regional, Nullable<decimal> CurrentEmployee)
        public static DataSet GetSearchResults(decimal LocationNumber, Nullable<DateTime> DateOfAccident, Int32 Associated_First_Report, String EmployeeName, String TPA_Claim_Number, String Claim_Type, string strOrderBy, string strOrder, int intPageNo, int intPageSize, string Regional, Nullable<decimal> CurrentEmployee, string ClaimStatus, string ClaimantName)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("SearchClaimInformations");

            db.AddInParameter(dbCommand, "@LocationNumber", DbType.Decimal, LocationNumber);
            db.AddInParameter(dbCommand, "@Date_of_Accident", DbType.DateTime, DateOfAccident);
            db.AddInParameter(dbCommand, "@Associated_First_Report", DbType.Int32, Associated_First_Report);
            db.AddInParameter(dbCommand, "@EmployeeName", DbType.String, EmployeeName);
            db.AddInParameter(dbCommand, "@Origin_Claim_Number", DbType.String, TPA_Claim_Number);
            db.AddInParameter(dbCommand, "@Claim_Type", DbType.String, Claim_Type);
            db.AddInParameter(dbCommand, "@strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "@strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "@intPageNo", DbType.Decimal, intPageNo);
            db.AddInParameter(dbCommand, "@intPageSize", DbType.Decimal, intPageSize);
            db.AddInParameter(dbCommand, "@Regional", DbType.String, Regional);
            db.AddInParameter(dbCommand, "@CurrentEmployee", DbType.Decimal, CurrentEmployee);
            db.AddInParameter(dbCommand, "@ClaimStatus", DbType.String, ClaimStatus);
            db.AddInParameter(dbCommand, "@ClaimantName", DbType.String, ClaimantName);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}

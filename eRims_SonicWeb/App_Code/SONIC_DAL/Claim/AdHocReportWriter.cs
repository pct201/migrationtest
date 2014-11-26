using System;
using System.Data;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for AdHocReportWriter
    /// </summary>
    public class AdHocReportWriter
    {
        public AdHocReportWriter()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet SelectOutputFieldsByClaimType(String strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportFieldsSelectByClaimType");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SelectSortFieldsByClaimType(String strClaimType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("AdhocReportFieldsSelectSortFieldsByClaimType");

            db.AddInParameter(dbCommand, "Claim_Type", DbType.String, strClaimType);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
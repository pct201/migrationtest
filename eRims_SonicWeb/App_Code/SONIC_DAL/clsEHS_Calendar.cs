using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Web;

namespace ERIMS.DAL
{
    /// <summary>
    /// Summary description for EHS_Calendar
    /// </summary>
    public sealed class clsEHS_Calendar
    {
        public clsEHS_Calendar()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Selects records EHS calendar.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet EHS_Show_Calendar(int? year, int? month, decimal? FK_Employee_Id)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("EHS_Calendar");

            db.AddInParameter(dbCommand, "Year", DbType.Int32, year);
            db.AddInParameter(dbCommand, "Month", DbType.Int32, month);
            db.AddInParameter(dbCommand, "FK_Employee_Id", DbType.Decimal, FK_Employee_Id);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}
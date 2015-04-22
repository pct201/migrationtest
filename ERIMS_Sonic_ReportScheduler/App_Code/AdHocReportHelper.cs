using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS_DAL
{
    /// <summary>
    /// Summary description for AdHocReport
    /// </summary>
    public class AdHocReportHelper
    {
        public enum RaltiveDates : int
        {
            NotSet = -1,
            FirstDayPrevMonth = 0,
            LastDayPrevMonth = 1,
            FirstDayCurrMonth = 2,
            LastDayCurrMonth = 3,
            FirstDayPrevYear = 4,
            LastDayPrevYear = 5,
            FirstDayCurrYear = 6,
            LastDayCurrYear = 7,
            CurrentDate = 8,
            PreviousDate = 9,
        }

        public enum DateCriteria : int
        {
            On = 0,
            Before = 1,
            After = 2,
            Between = 3,
            WithinBefore = 4,
            WithinAfter = 5,
        }

        public enum AmountCriteria : int
        {
            Equal = 0,
            GreaterThan = 1,
            Between = 2,
            LessThan = 3,
        }

        public enum AdHocControlType : int
        {
            TextBox = 1,
            MultiSelectList = 2,
            DateControl = 3,
            AmountControl = 4,
        }

        /// <summary>
        /// function which return Relative date for Current date based on RaltiveDates Criteria
        /// </summary>
        /// <param name="RelDateType"></param>
        /// <returns></returns>
        public static DateTime GetRelativeDate(AdHocReportHelper.RaltiveDates RelDateType)
        {
            DateTime dtReturn = DateTime.Now;

            // Check Relative Date Criteria
            if (RelDateType == RaltiveDates.CurrentDate)
                return dtReturn;
            else if (RelDateType == RaltiveDates.FirstDayCurrMonth)
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            else if (RelDateType == RaltiveDates.FirstDayCurrYear)
                dtReturn = new DateTime(DateTime.Today.Year, 1, 1);
            else if (RelDateType == RaltiveDates.FirstDayPrevMonth)
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
            else if (RelDateType == RaltiveDates.FirstDayPrevYear)
                dtReturn = new DateTime(DateTime.Today.AddYears(-1).Year, 1, 1);
            else if (RelDateType == RaltiveDates.LastDayCurrMonth)
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month));
            else if (RelDateType == RaltiveDates.LastDayCurrYear)
                dtReturn = new DateTime(DateTime.Today.AddYears(1).Year, 1, 1).AddDays(-1);
            else if (RelDateType == RaltiveDates.LastDayPrevMonth)
                dtReturn = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddDays(-1);
            else if (RelDateType == RaltiveDates.LastDayPrevYear)
                dtReturn = new DateTime(DateTime.Today.Year, 1, 1).AddDays(-1);
            else if (RelDateType == RaltiveDates.PreviousDate)
                dtReturn = DateTime.Now.AddDays(-1);

            return dtReturn;
        }

        /// <summary>
        /// function return where query for passed Field name for relative date from and To criteria
        /// </summary>
        /// <param name="DateFieldName"></param>
        /// <param name="FromRelDate"></param>
        /// <param name="ToRelDate"></param>
        /// <param name="DateCriteria"></param>
        /// <returns></returns>
        public static string GetDateWhereAbsolute(string DateFieldName, DateTime? FromDate, DateTime? ToDate, DateCriteria DateCriteria, bool IsNotSelected)
        {
            string strWhere = string.Empty;
            // Cast Date time field for remove time from date
            DateFieldName = "CAST(CONVERT(VARCHAR," + DateFieldName + " ,102) as DATETIME)";
            if (IsNotSelected == true)
            {
                if (DateCriteria == DateCriteria.On && FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " != CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                else if (DateCriteria == DateCriteria.Before && FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " > CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                else if (DateCriteria == DateCriteria.After && FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " < CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                else if (DateCriteria == DateCriteria.Between)
                {
                    if (FromDate.HasValue)
                        strWhere = " AND ( " + DateFieldName + " < CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                    // if to date is passed and then add and condition for between
                    if (ToDate.HasValue)
                        strWhere += " OR " + DateFieldName + " > CAST('" + ToDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                    strWhere += " ) ";
                }
                else if (DateCriteria == DateCriteria.WithinBefore || DateCriteria == DateCriteria.WithinAfter)
                {
                    if (FromDate.HasValue)
                        strWhere = " AND " + DateFieldName + " <> CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                }
            }
            else
            {
                if (DateCriteria == DateCriteria.On && FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " = CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                else if (DateCriteria == DateCriteria.Before && FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " <= CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                else if (DateCriteria == DateCriteria.After && FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                else if (DateCriteria == DateCriteria.Between)
                {
                    if (FromDate.HasValue)
                        strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                    // if to date is passed and then add and condition for between
                    if (ToDate.HasValue)
                        strWhere += " AND " + DateFieldName + " <= CAST('" + ToDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                }
                else if (DateCriteria == DateCriteria.WithinBefore || DateCriteria == DateCriteria.WithinAfter)
                {
                    if (FromDate.HasValue)
                        strWhere = " AND " + DateFieldName + " = CAST('" + FromDate.Value.ToString("MM/dd/yyyy") + "' as DATETIME)";
                }
            }
            return strWhere;
        }

        /// <summary>
        /// function return where query for passed Field name for relative date from and To criteria
        /// </summary>
        /// <param name="DateFieldName"></param>
        /// <param name="FromRelDate"></param>
        /// <param name="ToRelDate"></param>
        /// <param name="DateCriteria"></param>
        /// <returns></returns>
        public static string GetDateWhere(string DateFieldName, AdHocReportHelper.RaltiveDates FromRelDate, AdHocReportHelper.RaltiveDates? ToRelDate, DateCriteria DateCriteria, bool IsNotSelected)
        {
            DateTime dtFromDate = GetRelativeDate(FromRelDate);
            DateTime? dtToDate = null;

            if (ToRelDate.HasValue)
                dtToDate = GetRelativeDate(ToRelDate.Value);

            return GetDateWhereAbsolute(DateFieldName, dtFromDate, dtToDate, DateCriteria, IsNotSelected);
        }

        /// <summary>
        /// used for getting Where condition for Amount fields based on amount criteria
        /// </summary>
        /// <param name="AmountFieldName"></param>
        /// <param name="FromAmount"></param>
        /// <param name="ToAmount"></param>
        /// <param name="AmountType"></param>
        /// <returns></returns>
        public static string GetAmountWhere(string AmountFieldName, decimal? FromAmount, decimal? ToAmount, AmountCriteria AmountType, bool IsNotSelected)
        {
            string strWhere = string.Empty;

            if (IsNotSelected == true)
            {
                if (AmountType == AmountCriteria.Between)
                {
                    if (FromAmount.HasValue)
                        strWhere = " AND (" + AmountFieldName + " < " + Convert.ToString(FromAmount).Trim().Replace(",", "") + " ";
                    if (ToAmount.HasValue)
                        strWhere += " OR " + AmountFieldName + " > " + Convert.ToString(ToAmount).Trim().Replace(",", "") + " ";
                    strWhere += " ) ";
                }
                else
                {
                    strWhere = " AND " + AmountFieldName + " ";
                    if (AmountType == AmountCriteria.GreaterThan)
                        strWhere += " < ";
                    else if (AmountType == AmountCriteria.LessThan)
                        strWhere += " > ";
                    else
                        strWhere += " != ";
                    strWhere += Convert.ToString(FromAmount).Trim().Replace(",", "");
                }
            }
            else
            {
                if (AmountType == AmountCriteria.Between)
                {
                    if (FromAmount.HasValue)
                        strWhere = " AND " + AmountFieldName + " >= " + Convert.ToString(FromAmount).Trim().Replace(",", "") + " ";
                    if (ToAmount.HasValue)
                        strWhere += " AND " + AmountFieldName + " <= " + Convert.ToString(ToAmount).Trim().Replace(",", "") + " ";
                }
                else
                {
                    strWhere = " AND " + AmountFieldName + " ";
                    if (AmountType == AmountCriteria.GreaterThan)
                        strWhere += " > ";
                    else if (AmountType == AmountCriteria.LessThan)
                        strWhere += " < ";
                    else
                        strWhere += " = ";
                    strWhere += Convert.ToString(FromAmount).Trim().Replace(",", "");
                }
            }

            return strWhere;
        }

        /// <summary>
        /// Get Comma Seperated Value from passed table and Column
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="ColumnName"></param>
        /// <returns></returns>
        private static string GetCommaValueFromTable(DataTable dt, string ColumnName)
        {
            string _strValue = string.Empty;

            for (int i = 0; i < dt.Rows.Count; i++)
                _strValue += (_strValue == "") ? dt.Rows[i][ColumnName].ToString().Trim() : "<b>,</b> " + dt.Rows[i][ColumnName].ToString().Trim();

            return _strValue;
        }

        public static IDataReader GetAdHocReport(string SelectedField, string GroupBy, DateTime? PVDWhere,
               string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID, bool isEvent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptAdHocReport");
            dbCommand.CommandTimeout = 100000;

            db.AddInParameter(dbCommand, "SelectedField", DbType.String, SelectedField);
            db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
            db.AddInParameter(dbCommand, "PVDWhere", DbType.DateTime, PVDWhere);
            db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
            db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
            db.AddInParameter(dbCommand, "SqlWhereIds", DbType.String, strFilterIds);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            db.AddInParameter(dbCommand, "isEvent", DbType.Boolean, isEvent);
            return db.ExecuteReader(dbCommand);
        }

        public static DataSet GetRecipientList()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Tatva_ScheduleGetRecipientList");
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// ACI ad-hoc report
        /// </summary>
        /// <param name="SelectedField"></param>
        /// <param name="GroupBy"></param>
        /// <param name="PVDWhere"></param>
        /// <param name="SqlWhere1"></param>
        /// <param name="SqlSortBy"></param>
        /// <param name="strFilterIds"></param>
        /// <param name="isEvent"></param>
        /// <returns></returns>
        public static IDataReader GetAdHocReportACI(string SelectedField, string GroupBy, DateTime? PVDWhere, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID, bool isEvent)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_rptAdHocReport");
            dbCommand.CommandTimeout = 100000;

            db.AddInParameter(dbCommand, "SelectedField", DbType.String, SelectedField);
            db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
            db.AddInParameter(dbCommand, "PVDWhere", DbType.DateTime, PVDWhere);
            db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
            db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
            db.AddInParameter(dbCommand, "SqlWhereIds", DbType.String, strFilterIds);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, PK_Security_ID);
            db.AddInParameter(dbCommand, "isEvent", DbType.Boolean, isEvent);
            return db.ExecuteReader(dbCommand);
        }

    }

}

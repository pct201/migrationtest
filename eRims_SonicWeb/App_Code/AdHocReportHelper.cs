using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.UI.WebControls;

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
        Is_Null = 4
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
        MultiSelectTextList = 5,
    }

    public enum AssetprotectionReportType : int
    {
        AP_Property_Security = 1,
        AP_DPD_FROIs = 2,
        AP_AL_FROIs = 3,
        AP_Cal_Atlantic = 4,
        AP_Fraud_Events = 5
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
    public static string GetDateWhereAbsolute(string DateFieldName, DateTime? FromDate, DateTime? ToDate, DateCriteria DateCriteria)
    {
        string strWhere = string.Empty;

        // Cast Date time field for remove time from date
        DateFieldName = "CAST(CONVERT(VARCHAR," + DateFieldName + " ,102) as DATETIME)";

        if (DateCriteria == DateCriteria.On && FromDate.HasValue)
            strWhere = " AND " + DateFieldName + " = CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
        else if (DateCriteria == DateCriteria.Before && FromDate.HasValue)
            strWhere = " AND " + DateFieldName + " < CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
        else if (DateCriteria == DateCriteria.After && FromDate.HasValue)
            strWhere = " AND " + DateFieldName + " > CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
        else if (DateCriteria == DateCriteria.Between)
        {
            if (FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";

            // if to date is passed and then add and condition for between
            if (ToDate.HasValue)
                strWhere += " AND " + DateFieldName + " <= CAST('" + ToDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
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
    public static string GetDateWhereAbsolute(string DateFieldName, DateTime? FromDate, DateTime? ToDate, DateCriteria DateCriteria, bool IsNotSelected)
    {
        string strWhere = string.Empty;
        // Cast Date time field for remove time from date
        DateFieldName = "CAST(CONVERT(VARCHAR," + DateFieldName + " ,102) as DATETIME)";
        if (IsNotSelected == true)
        {
            if (DateCriteria == DateCriteria.On && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " != CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
            else if (DateCriteria == DateCriteria.Before && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " > CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
            else if (DateCriteria == DateCriteria.After && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " < CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
            else if (DateCriteria == DateCriteria.Between)
            {
                if (FromDate.HasValue)
                    strWhere = " AND ( " + DateFieldName + " < CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
                // if to date is passed and then add and condition for between
                if (ToDate.HasValue)
                    strWhere += " OR " + DateFieldName + " > CAST('" + ToDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
                strWhere += " ) ";
            }
        }
        else
        {
            if (DateCriteria == DateCriteria.On && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " = CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
            else if (DateCriteria == DateCriteria.Before && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " <= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
            else if (DateCriteria == DateCriteria.After && FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
            else if (DateCriteria == DateCriteria.Between)
            {
                if (FromDate.HasValue)
                    strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
                // if to date is passed and then add and condition for between
                if (ToDate.HasValue)
                    strWhere += " AND " + DateFieldName + " <= CAST('" + ToDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
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
    public static string GetDateWhereAbsolute_EPMAdhoc(string DateFieldName, DateTime? FromDate, DateTime? ToDate, DateCriteria DateCriteria)
    {
        string strWhere = string.Empty;

        // Cast Date time field for remove time from date
        DateFieldName = "CAST(CONVERT(VARCHAR," + DateFieldName + " ,102) as DATETIME)";

        if (DateCriteria == DateCriteria.On && FromDate.HasValue)
            strWhere = " AND " + DateFieldName + " = CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
        else if (DateCriteria == DateCriteria.Before && FromDate.HasValue)
            strWhere = " AND " + DateFieldName + " <= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
        else if (DateCriteria == DateCriteria.After && FromDate.HasValue)
            strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
        else if (DateCriteria == DateCriteria.Between)
        {
            if (FromDate.HasValue)
                strWhere = " AND " + DateFieldName + " >= CAST('" + FromDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";

            // if to date is passed and then add and condition for between
            if (ToDate.HasValue)
                strWhere += " AND " + DateFieldName + " <= CAST('" + ToDate.Value.ToString(AppConfig.DisplayDateFormat) + "' as DATETIME)";
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
    public static string GetDateWhere(string DateFieldName, AdHocReportHelper.RaltiveDates FromRelDate, AdHocReportHelper.RaltiveDates? ToRelDate, DateCriteria DateCriteria)
    {
        DateTime dtFromDate = GetRelativeDate(FromRelDate);
        DateTime? dtToDate = null;

        if (ToRelDate.HasValue)
            dtToDate = GetRelativeDate(ToRelDate.Value);

        return GetDateWhereAbsolute(DateFieldName, dtFromDate, dtToDate, DateCriteria);
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
    /// used for getting Where condition for Amount fields based on amount criteria
    /// </summary>
    /// <param name="AmountFieldName"></param>
    /// <param name="FromAmount"></param>
    /// <param name="ToAmount"></param>
    /// <param name="AmountType"></param>
    /// <returns></returns>
    public static string GetAmountWhere(string AmountFieldName, decimal? FromAmount, decimal? ToAmount, AmountCriteria AmountType)
    {
        string strWhere = string.Empty;

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

        return strWhere;
    }

    /// <summary>
    /// Fill Dynamic Drop Down
    /// </summary>
    /// <param name="strField_Name"></param>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    /// <param name="IsTableHasCode"></param>
    public static void FillFilterDropDown(string strField_Name, ListBox[] dropDowns, bool booladdSelectAsFirstElement, string strModuleName)
    {
        /*
         * This function used for Fill drop down For Adhoc Report.
         * As Filter come from database directly, We maintain one XML file for Field name and Table Name.
         * Some of the drop down are static in system. Like Yes, No ,N/A  values drop down
         * In XML file there are one field "Title" which map with "Header" of Adhoc Report Field.
         * Same way another property "TableName" which is Actual table name in database.
         * "Type" property is used for define static drop down type.
         * "HasCode" property define if table has both Description and Code fields
         * 
         * First of all Find "Title" in XML File. based on that Fill Drop Down 
         * If It is static values meand "Type" is not "DropDown" then Add Static Fields to Dropdown
         * 
         * */

        DataSet dsXML = new System.Data.DataSet();
        // Read XML Files
        if (strModuleName.ToUpper() == "FRANCHISE")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\FranchiseAdHocReportFields.xml");
        else if (strModuleName.ToUpper() == "CRM")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\CRMAdHocReportFields.xml");
        else if (strModuleName.ToUpper() == "POLLUTION")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\PollutonAdHocReportFields.xml");
        else if (strModuleName.ToUpper() == "INSPECTION")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\InspectionAdHocReportFields.xml");
        else if (strModuleName.ToUpper() == "INVESTIGATION")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\InvestigationAdHocReportFields.xml");
        else if (strModuleName.ToUpper() == "SLT")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\SLTAdHocReportFields.xml");
        else if (strModuleName.ToUpper() == "EPM")
            dsXML.ReadXml(AppConfig.SitePath + @"App_Data\EPMAdHocReportFields.xml");

        string strTable = string.Empty, strType = string.Empty;
        bool IsTableHasCode = true;

        if (dsXML.Tables.Count > 0)
        {
            DataRow[] drFilter = dsXML.Tables[0].Select("Title = '" + strField_Name + "'");

            if (drFilter.Length > 0)
            {
                strTable = Convert.ToString(drFilter[0]["TableName"]);
                strType = Convert.ToString(drFilter[0]["Type"]);
                IsTableHasCode = (Convert.ToString(drFilter[0]["HasCode"]) == "Y");
            }
        }
        clsGeneral.DisposeOf(dsXML);

        if (string.Compare(strType, "DropDown", true) == 0)
        {
            DataSet dsData = clsGeneral.SelectByTableName(strTable);

            try
            {
                if (strTable == "LU_Importance" || strTable == "LU_Item_Status" || strTable == "LU_Procedure_Source" || strTable == "LU_SLT_Role" || strTable == "LU_Suggetion_Source" || strTable == "LU_Work_Status")
                    dsData.Tables[0].DefaultView.RowFilter = " Active = 1 ";
                else
                    dsData.Tables[0].DefaultView.RowFilter = " Active = 'Y' ";
            }
            catch { }

            foreach (ListBox ddlToFill in dropDowns)
            {
                DataColumn dc = new DataColumn("Code_Desc");
                dc.DataType = System.Type.GetType("System.String");
                if (strTable.ToUpper() == "LU_SIC".ToUpper())
                    dc.Expression = "Fld_Code";
                else
                    dc.Expression = "Fld_Desc";
                dsData.Tables[0].Columns.Add(dc);

                dsData.Tables[0].DefaultView.Sort = "Code_Desc";
                ddlToFill.Items.Clear();

                ddlToFill.DataTextField = "Code_Desc";

                if (strTable.ToUpper() == "County".ToUpper())
                    ddlToFill.DataValueField = "PK_ID";
                else
                    ddlToFill.DataValueField = "PK_" + strTable;

                ddlToFill.DataSource = dsData.Tables[0].DefaultView;
                ddlToFill.DataBind();


                if (booladdSelectAsFirstElement)
                {
                    ddlToFill.Items.Insert(0, new ListItem("---Select---", "0"));
                }

            }
            clsGeneral.DisposeOf(dsData);
        }
        else if ((string.Compare(strType, "drpYesNoInt", true) == 0))
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if ((string.Compare(strType, "drpYesNoNone", true) == 0))
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            liItem.Add(new ListItem("None", "2"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else
        {
            List<ListItem> liItem = new List<ListItem>();
            if (strModuleName.ToUpper() == "FRANCHISE")
            {
                liItem.Add(new ListItem("Yes", "1"));
                liItem.Add(new ListItem("No", "2"));
            }
            else if (strModuleName.ToUpper() == "DPD")
            {
                liItem.Add(new ListItem("Yes", "1"));
                liItem.Add(new ListItem("No", "0"));
            }
            else if (strModuleName.ToUpper() == "PROPERTY")
            {
                if (strField_Name == "Building Improvement-New Build" || strField_Name == "Building Improvement-Open")
                {
                    liItem.Add(new ListItem("Yes", "Y"));
                    liItem.Add(new ListItem("No", "N"));
                }
                else
                {
                    liItem.Add(new ListItem("Yes", "1"));
                    liItem.Add(new ListItem("No", "0"));
                }
            }
            else
            {
                liItem.Add(new ListItem("Yes", "Y"));
                liItem.Add(new ListItem("No", "N"));
            }

            // Fill static Drop Down Values
            if (string.Compare(strTable, "drpYesNoNA", true) != 0 && string.Compare(strTable, "drpYesNo", true) != 0)
            {
                if (string.Compare(strTable, "drpTest", true) == 0)
                    liItem.Insert(2, new ListItem("Time Expired-no test", "3"));
                else if (string.Compare(strTable, "drpYesNo9999", true) == 0)
                    liItem.Insert(2, new ListItem("9999", "3"));
                else if (string.Compare(strTable, "drpTest", true) == 0)
                    liItem.Insert(2, new ListItem("Time Expired-no test", "3"));
            }



            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
    }

    /// <summary>
    /// Get Franchise Ad-Hoc Report
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportFranchise(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptFranchiseAdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    /// <summary>
    /// Get CRM Customer Ad-hoc Report
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportCRMCustomer(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptCRM_Customer_AdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    /// <summary>
    /// Get CRM Non Customer Ad-hoc Report
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportCRMNonCustomer(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptCRM_Non_Customer_AdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    /// <summary>
    /// Get CRM Non Customer Ad-hoc Report
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportInspection(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptInspection_AdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    /// <summary>
    /// Get CRM Non Customer Ad-hoc Report
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportPollution(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID, out bool IsSuccess)
    {
        try
        {
            IsSuccess = true;
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("rptPollution_AdHocReport");
            dbCommand.CommandTimeout = 100000;

            db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
            db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
            db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
            db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
            db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
            db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
            return db.ExecuteReader(dbCommand);
        }
        catch (Exception ex)
        {
            IsSuccess = false;
            return null;

        }
    }

    /// <summary>
    /// Get Franchise Ad-Hoc Report
    /// 
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportDPD(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptDPD_FROI_AdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    /// <summary>
    /// Get Investigation Ad-Hoc Report
    /// </summary>
    /// <param name="SelectedField"></param>
    /// <param name="GroupBy"></param>
    /// <param name="SqlWhere1"></param>
    /// <param name="SqlSortBy"></param>
    /// <param name="strFilterIds"></param>
    /// <param name="PK_Security_ID"></param>
    /// <returns></returns>
    public static IDataReader GetAdHocReportInvestigation(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptInvestigation_AdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    public static IDataReader GetAdHocReportAssetProtection(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID, int ReportType)
    {
        try
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = null;
                        
            switch (ReportType)
            {
                case 1:
                    dbCommand = db.GetStoredProcCommand("rptAP_AdHocReport");
                    break;
                case 2:
                    dbCommand = db.GetStoredProcCommand("rptAP_AdHocReport_Type2");
                    break;
                case 3:
                    dbCommand = db.GetStoredProcCommand("rptAP_AdHocReport_Type3");
                    break;
                case 4:
                    dbCommand = db.GetStoredProcCommand("rptAP_AdHocReport_Type4");
                    break;
                case 5:
                    dbCommand = db.GetStoredProcCommand("rptAP_AdHocReport_Type5");
                    break;
                default:
                    dbCommand = db.GetStoredProcCommand("rptAP_AdHocReport");
                    break;
            }
            
            if (dbCommand != null)
            {
                dbCommand.CommandTimeout = 100000;
                db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
                db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
                db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
                db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
                db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
                db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
                return db.ExecuteReader(dbCommand);
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    public static IDataReader GetAdHocReportSLT(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptSLTAdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }

    public static IDataReader GetAdHocReportEPM(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptEPMAdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }
    
    public static IDataReader GetAdHocReportACI(string SelectedField, string GroupBy, DateTime? PVDWhere,string SqlWhere1, string SqlSortBy, string strFilterIds, bool isEvent)
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
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
        db.AddInParameter(dbCommand, "isEvent", DbType.Boolean, isEvent);
        return db.ExecuteReader(dbCommand);
    }

    public static IDataReader GetAdHocReportForManagement(string SelectedField, string GroupBy, DateTime? PVDWhere, string SqlWhere1, string SqlSortBy, string strFilterIds)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("Management_rptAdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "PVDWhere", DbType.DateTime, PVDWhere);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, Convert.ToDecimal(clsSession.UserID));
        return db.ExecuteReader(dbCommand);
    }

    
    public static IDataReader GetAdHocReportProperty(string SelectedField, string GroupBy, string SqlWhere1, string SqlSortBy, string strFilterIds, decimal PK_Security_ID)
    {
        Database db = DatabaseFactory.CreateDatabase();
        DbCommand dbCommand = db.GetStoredProcCommand("rptProperty_AdHocReport");
        dbCommand.CommandTimeout = 100000;

        db.AddInParameter(dbCommand, "@SelectedField", DbType.String, SelectedField);
        db.AddInParameter(dbCommand, "GroupBy", DbType.String, GroupBy);
        db.AddInParameter(dbCommand, "SqlWhere1", DbType.String, SqlWhere1);
        db.AddInParameter(dbCommand, "SqlSortBy", DbType.String, SqlSortBy);
        db.AddInParameter(dbCommand, "@SqlWhereIds", DbType.String, strFilterIds);
        db.AddInParameter(dbCommand, "Pk_Security_ID", DbType.Decimal, PK_Security_ID);
        return db.ExecuteReader(dbCommand);
    }
}

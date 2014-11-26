using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

/// <summary>
/// Summary description for Business_RuleHelper
/// </summary>
public class Business_RuleHelper
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
    }

    public enum DateCriteria : int
    {
        On = 0,
        Before = 1,
        After = 2,
        Between = 3,
    }

    public enum AmountCriteria : int
    {
        Equal = 0,
        GreaterThan = 1,
        Between = 2,
        LessThan = 3,
        GreaterThanEqual = 4,
        LessThanEqual = 5,
    }

    public enum NumberCriteria : int
    {
        Equal = 0,
        GreaterThan = 1,
        Between = 2,
        LessThan = 3,
        GreaterThanEqual = 4,
        LessThanEqual = 5,
    }

    public enum ControlType : int
    {
        TextBox = 1,
        MultiSelectList = 2,
        DateControl = 3,
        AmountControl = 4,
        IntNumberControl = 5,
    }

    public Business_RuleHelper()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    /// <summary>
    /// Fill Dynamic Drop Down
    /// </summary>
    /// <param name="strField_Name"></param>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    /// <param name="IsTableHasCode"></param>
    public static string GetDropdwonFormail(string strTable_Name, string strField_Name, string strClaimMajor_Coverage)
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
        Database db = DatabaseFactory.CreateDatabase();
        DataSet dsXML = new System.Data.DataSet();
        // Read XML Files
        dsXML.ReadXml(AppConfig.SitePath + @"App_Data\Business_Rule_Management.xml");
        string strTable = string.Empty, strType = string.Empty, strTextField = string.Empty, strValueField = string.Empty, strOrderBy = string.Empty, strActive = string.Empty;
        //bool IsTableHasCode = true;

        if (dsXML.Tables.Count > 0)
        {
            DataRow[] drFilter = dsXML.Tables[0].Select("Name = '" + strField_Name + "'");

            if (drFilter.Length > 0)
            {
                strTable = Convert.ToString(drFilter[0]["Table_Name"]);
                strType = Convert.ToString(drFilter[0]["ControlType"]);
                strTextField = Convert.ToString(drFilter[0]["TextField"]);
                strValueField = Convert.ToString(drFilter[0]["ValueField"]);
                strOrderBy = Convert.ToString(drFilter[0]["OrderBy"]);
                strActive = Convert.ToString(drFilter[0]["Active"]);
            }
        }
        clsGeneral.DisposeOf(dsXML);
        string strSQL = string.Empty;
        if (string.Compare(strType, "DropDown", true) == 0)
        {
            // DataSet dsData = clsGeneral.SelectByTableName(strTable);
            strSQL = string.Empty;
            strSQL = "SELECT Top 1 ISNULL(" + strTextField + ",'') FROM " + strTable + " WHERE 1=1 AND " + strTable + "." + strValueField + "=" + strTable_Name + "." + strField_Name;
            if ((!string.IsNullOrEmpty(strClaimMajor_Coverage)) && ((strTable == "LU_Cause") || (strTable == "LU_Coverage") || (strTable == "Claim") || (strTable == "LU_Payment_Id")))
            {
                if (strTable == "LU_Cause" || strTable == "LU_Payment_Id")
                {
                    strSQL = strSQL + " AND " + strClaimMajor_Coverage.Replace("Maj_Cov", "Major_Coverage");
                }
                else
                    strSQL = strSQL + " AND " + strClaimMajor_Coverage;
            }            
        }
        else if (string.Compare(strType, "YesNo", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name+"."+strField_Name + " WHEN 1 THEN 'Yes' ELSE 'No' END";
        }
        else if (string.Compare(strType, "YesNoChar", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'Y' THEN 'Yes' ELSE 'No' END";
        }
        else if (string.Compare(strType, "YesNoBit", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Yes' ELSE 'No' END";

        }
        else if (string.Compare(strType, "drpYesNoNA", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Yes' WHEN 2 THEN 'No' ELSE 'NA' END";

        }
        else if (string.Compare(strType, "drpYesNo9999", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Yes' WHEN 2 THEN 'No' WHEN 3 THEN '9999' ELSE 'NA' END";

        }
        else if (string.Compare(strType, "YesNoNA", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Yes' WHEN 0 THEN 'No' ELSE 'NA' END";

        }
        else if (string.Compare(strType, "Entry_Adjuster", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "SELECT (isnull([FIRST_NAME] + ' ','') + isnull([LAST_NAME],'')) AS Name FROM [Security] WHERE PK_Security_ID = " + strTable_Name + "." + strField_Name;

        }
        else if (string.Compare(strType, "Claim_Adjuster", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "SELECT (isnull([FIRST_NAME] + ' ','') + isnull([LAST_NAME],'')) AS Name FROM [Security] WHERE PK_Security_ID = " + strTable_Name + "." + strField_Name;

        }
        else if (string.Compare(strType, "Drug_Test", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Yes' WHEN 3 THEN 'Time Expired-no test' ELSE 'No' END";

        }
        else if (string.Compare(strType, "LeftRight", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Left' ELSE 'Right' END";

        }
        else if (string.Compare(strType, "Policy_Type", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'O' THEN 'Occurrence' ELSE 'Claims Made' END";

        }
        else if (string.Compare(strType, "Layer_Number", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 1 THEN 'Primary' WHEN 2 THEN '2' WHEN 3 THEN '3' WHEN 4 THEN '4' WHEN 5 THEN '5' WHEN 6 THEN '6' WHEN 7 THEN '7' WHEN 8 THEN '8' WHEN 9 THEN '9' ELSE '10' END";

        }
        else if (string.Compare(strType, "Payee", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'C' THEN 'Claimant' WHEN 'L' THEN 'Landstar' ELSE 'Vendor' END";

        }
        else if (string.Compare(strType, "Ownership", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'Internal' THEN 'Sonic Owned with Internal Lease'"+
                                                                    " WHEN 'ThirdParty' THEN 'Sonic Owned with Third Party Lease'"+
                                                                    " WHEN 'Owned' THEN 'Sonic Owned'" +
                                                                    " WHEN 'ThirdPartyLease' THEN 'Third Party Owned and Sonic Leased'" +
                                                                    " WHEN 'ThirdPartySublease' THEN 'Third Party Owned and Sonic Leased and Subleased to Third Party'" +
                                                                    " END";
        }
        else if (string.Compare(strType, "GALimitAppliesTo", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Policy' WHEN '2' THEN 'Project' WHEN '3' THEN 'Location' ELSE 'N/A' END";
        }
        else if (string.Compare(strType, "FK_LU_Meeting_Quality", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Spectator' WHEN '2' THEN 'Water boy' WHEN '3' THEN 'Second String' WHEN '4' THEN 'Starter' WHEN '5' THEN 'All Pro' END";
        }
        else if (string.Compare(strType, "Coverage_Form", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'O' THEN 'Occurrence' WHEN 'C' THEN 'Claims Made' END";
        }
        else if (string.Compare(strType, "Gender", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'M' THEN 'Male' WHEN 'F' THEN 'Female' END";
        }
        else if (string.Compare(strType, "Initial_Claim_Classification", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Potential Lost-time from Work'" +
                                                                   " WHEN '2' THEN 'Medical care and treatment only from a “Health Provider”'" +
                                                                   " WHEN '3' THEN 'Report Only – No medical care or treatment provided by a Health Provider'" +
                                                                   " WHEN '4' THEN 'Unknown at this time'" +
                                                                   " END";
        }
        else if (string.Compare(strType, "Offsiteonsite", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '0' THEN 'Onsite' WHEN '1' THEN 'Offsite' END";
        }
        else if (string.Compare(strType, "YesNoNone", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' ELSE 'None' END";
        }
        else if (string.Compare(strType, "ApprovedNotApproved", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Approved' WHEN '0' THEN 'Not Approved' END";
        }
        else if (string.Compare(strType, "YesNoUnknown", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Yes' WHEN '0' THEN 'No' ELSE 'Unknown' END";
        }
        else if (string.Compare(strType, "yesNoNotRequired", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'Y' THEN 'Yes' WHEN 'N' THEN 'No' WHEN 'R' THEN 'Not Required' END";
        }
        else if (string.Compare(strType, "DirectIndirect", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN 'D' THEN 'Direct' WHEN 'I' THEN 'Indirect' END";
        }
        else if (string.Compare(strType, "ActiveInactiveDisposed", true) == 0 || string.Compare(strType, "BusinessPersonal", true) == 0 || string.Compare(strType, "Contact_Type", true) == 0
                || string.Compare(strType, "Distance_from_body_of_water", true) == 0 || string.Compare(strType, "Fire_Department_Type", true) == 0 || string.Compare(strType, "Ground_Location", true) == 0
                || string.Compare(strType, "Intru_Contact_Alarm_Type", true) == 0 || string.Compare(strType, "investigation_status", true) == 0 || string.Compare(strType, "Investigative_Quality", true) == 0
                || string.Compare(strType, "Liability", true) == 0 || string.Compare(strType, "property_contact_type", true) == 0 || string.Compare(strType, "Sonic_Cause_Code", true) == 0
                || string.Compare(strType, "TypeOfVehicle", true) == 0 || string.Compare(strType, "MortgageeLandlord", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = strTable_Name + "." + strField_Name;
        }
        else if (string.Compare(strType, "HH_Or_Other", true) == 0)
        {
            strSQL = string.Empty;
            strSQL = "CASE " + strTable_Name + "." + strField_Name + " WHEN '1' THEN 'Hart & Hickman' WHEN '0' THEN 'Other Consultant' END";
        }
        else
            return strSQL = string.Empty;
        return "ISNULL((" + strSQL + "),'')";
    }

    /// <summary>
    /// Fill Dynamic Drop Down
    /// </summary>
    /// <param name="strField_Name"></param>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    /// <param name="IsTableHasCode"></param>
    public static void FillFilterDropDown(string strField_Name, ListBox[] dropDowns, bool booladdSelectAsFirstElement, string strClaimMajor_Coverage)
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
        Database db = DatabaseFactory.CreateDatabase();
        DataSet dsXML = new System.Data.DataSet();
        // Read XML Files
        dsXML.ReadXml(AppConfig.SitePath + @"App_Data\Business_Rule_Management.xml");
        string strTable = string.Empty, strType = string.Empty, strTextField = string.Empty, strValueField = string.Empty, strOrderBy = string.Empty, strActive = string.Empty;
        //bool IsTableHasCode = true;

        if (dsXML.Tables.Count > 0)
        {
            DataRow[] drFilter = dsXML.Tables[0].Select("Name = '" + strField_Name + "'");

            if (drFilter.Length > 0)
            {
                strTable = Convert.ToString(drFilter[0]["Table_Name"]);
                strType = Convert.ToString(drFilter[0]["ControlType"]);
                strTextField = Convert.ToString(drFilter[0]["TextField"]);
                strValueField = Convert.ToString(drFilter[0]["ValueField"]);
                strOrderBy = Convert.ToString(drFilter[0]["OrderBy"]);
                strActive = Convert.ToString(drFilter[0]["Active"]);
            }
        }
        clsGeneral.DisposeOf(dsXML);

        if (string.Compare(strType, "DropDown", true) == 0)
        {
            // DataSet dsData = clsGeneral.SelectByTableName(strTable);

            foreach (ListBox ddlToFill in dropDowns)
            {

                string strSQL = string.Empty;
                strSQL = "SELECT " + strTextField + " AS strTextField," + strValueField + " AS strValueField FROM " + strTable + " WHERE 1=1 ";//|| (strTable == "LU_Coverage") 
                if ((!string.IsNullOrEmpty(strClaimMajor_Coverage)) && ((strTable == "LU_Cause") || (strTable == "Claim") || (strTable == "LU_Payment_Id")))
                {
                    if (strTable == "LU_Cause" || strTable == "LU_Payment_Id")
                    {
                        strSQL = strSQL + " AND " + strClaimMajor_Coverage.Replace("Maj_Cov", "Major_Coverage");
                    }
                    else
                        strSQL = strSQL + " AND " + strClaimMajor_Coverage;
                }
                if (!string.IsNullOrEmpty(strActive) && (strActive == "Y"))
                    strSQL = strSQL + " AND Active = '" + strActive + "'";
                else if (!string.IsNullOrEmpty(strActive) && (strActive == "N"))
                    strSQL = strSQL + " AND ISNULL(Inactive,'N') <> 'Y'";
                strSQL = strSQL + " ORDER BY " + strOrderBy; ;

                DataSet ds = db.ExecuteDataSet(CommandType.Text, strSQL);

                if ((ds != null) && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (ListBox lstBox in dropDowns)
                    {
                        lstBox.Items.Clear();

                        lstBox.DataTextField = "strTextField";
                        lstBox.DataValueField = "strValueField";
                        lstBox.DataSource = ds.Tables[0];
                        lstBox.DataBind();
                    }
                }
            }

            //clsGeneral.DisposeOf(dsData);

        }
        else if (string.Compare(strType, "YesNo", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));

            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoChar", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "Y"));
            liItem.Add(new ListItem("No", "N"));

            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoBit", true) == 0)
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
        else if (string.Compare(strType, "drpYesNoNA", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            liItem.Add(new ListItem("NA", "0"));

            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "drpYesNo9999", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            liItem.Add(new ListItem("NA", "0"));
            liItem.Add(new ListItem("9999", "3"));

            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoNA", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            liItem.Add(new ListItem("NA", "2"));

            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        
        //else if (string.Compare(strType, "Claim_Adjuster", true) == 0)
        //{
        //    DataTable dtAdjuster = ERIMS_DAL.Employee.SelectByClaimAdjuster_Type().Tables[0];
        //    foreach (ListBox ddlToFill in dropDowns)
        //    {
        //        ddlToFill.Items.Clear();
        //        ddlToFill.DataSource = dtAdjuster;
        //        ddlToFill.DataTextField = "Name";
        //        ddlToFill.DataValueField = "PK_Security_ID";
        //        ddlToFill.DataBind();
        //    }
        //}
        else if (string.Compare(strType, "Drug_Test", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            liItem.Add(new ListItem("Time Expired-no test", "3"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "LeftRight", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Left", "1"));
            liItem.Add(new ListItem("Right", "2"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Policy_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Occurrence", "O"));
            liItem.Add(new ListItem("Claims Made", "C"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Layer_Number", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Primary", "1"));
            liItem.Add(new ListItem("2", "2"));
            liItem.Add(new ListItem("3", "3"));
            liItem.Add(new ListItem("4", "4"));
            liItem.Add(new ListItem("5", "5"));
            liItem.Add(new ListItem("6", "6"));
            liItem.Add(new ListItem("7", "7"));
            liItem.Add(new ListItem("8", "8"));
            liItem.Add(new ListItem("9", "9"));
            liItem.Add(new ListItem("10", "10"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Payee", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Claimant", "C"));
            liItem.Add(new ListItem("Landstar", "L"));
            liItem.Add(new ListItem("Vendor", "V"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "dropGen", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("True", "--NA--"));
            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Distance_from_body_of_water", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("<1 MIles", "<1 MIles"));
            liItem.Add(new ListItem("1-5 Miles", "1-5 Miles"));
            liItem.Add(new ListItem("5-10 Miles", "5-10 Miles"));
            liItem.Add(new ListItem(">10 Miles", ">10 Miles"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Fire_Department_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Paid", "Paid"));
            liItem.Add(new ListItem("Part Paid", "Part Paid"));
            liItem.Add(new ListItem("Volunteer", "Volunteer"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Intru_Contact_Alarm_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Beam", "Beam"));
            liItem.Add(new ListItem("Motion", "Motion"));
            liItem.Add(new ListItem("Ultrasound", "Ultrasound"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Liability", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Assigned with Liability", "Assigned with Liability"));
            liItem.Add(new ListItem("Assigned without Liability", "Assigned without Liability"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "ActiveInactiveDisposed", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Active", "Active"));
            liItem.Add(new ListItem("InActive", "InActive"));
            liItem.Add(new ListItem("Disposed", "Disposed"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Ownership", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Sonic Owned with Internal Lease", "Internal"));
            liItem.Add(new ListItem("Sonic Owned with Third Party Lease", "ThirdParty"));
            liItem.Add(new ListItem("Sonic Owned", "Owned"));
            liItem.Add(new ListItem("Third Party Owned and Sonic Leased", "ThirdPartyLease"));
            liItem.Add(new ListItem("Third Party Owned and Sonic Leased and Subleased to Third Party", "ThirdPartySublease"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "MortgageeLandlord", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Mortgagee", "Mortgagee"));
            liItem.Add(new ListItem("Landlord", "Landlord"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "GALimitAppliesTo", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Policy", "1"));
            liItem.Add(new ListItem("Project", "2"));
            liItem.Add(new ListItem("Location", "3"));
            liItem.Add(new ListItem("N/A", "0"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "TypeOfVehicle", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("New Inventory", "New Inventory"));
            liItem.Add(new ListItem("Used Inventory", "Used Inventory"));
            liItem.Add(new ListItem("Demo", "Demo"));
            liItem.Add(new ListItem("Shop Loaner", "Shop Loaner"));
            liItem.Add(new ListItem("Daily Rental", "Daily Rental"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Ground_Location", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("On Surface", "On Surface"));
            liItem.Add(new ListItem("Underground", "Underground"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Contact_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("HR", "HR"));
            liItem.Add(new ListItem("Legal", "Legal"));
            liItem.Add(new ListItem("Risk Management", "Risk Management"));
            liItem.Add(new ListItem("Other", "Other"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Sonic_Cause_Code", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("S0-1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY", "S0-1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"));
            liItem.Add(new ListItem("S0-2-FALL SAME LEVEL OR ELEVATED SURFACE", "S0-2-FALL SAME LEVEL OR ELEVATED SURFACE"));
            liItem.Add(new ListItem("S0-3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART", "S0-3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"));
            liItem.Add(new ListItem("S0-4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT", "S0-4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"));
            liItem.Add(new ListItem("S0-5-OTHER - NOT CLASSIFIED", "S0-5-OTHER - NOT CLASSIFIED"));
            liItem.Add(new ListItem("S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY", "S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"));
            liItem.Add(new ListItem("S2-FALL SAME LEVEL OR ELEVATED SURFACE", "S2-FALL SAME LEVEL OR ELEVATED SURFACE"));
            liItem.Add(new ListItem("S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART", "S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"));
            liItem.Add(new ListItem("S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT", "S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"));
            liItem.Add(new ListItem("S5-OTHER - NOT CLASSIFIED IN ABOVE CODES", "S5-OTHER - NOT CLASSIFIED IN ABOVE CODES"));
            liItem.Add(new ListItem("S-1 Denied", "S-1 Denied"));
            liItem.Add(new ListItem("S-2 Denied", "S-2 Denied"));
            liItem.Add(new ListItem("S-3 Denied", "S-3 Denied"));
            liItem.Add(new ListItem("S-4 Denied", "S-4 Denied"));
            liItem.Add(new ListItem("S-5 Denied", "S-5 Denied"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Investigative_Quality", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("All Pro", "All Pro"));
            liItem.Add(new ListItem("Starter", "Starter"));
            liItem.Add(new ListItem("Second String", "Second String"));
            liItem.Add(new ListItem("Water boy", "Water boy"));
            liItem.Add(new ListItem("Spectator", "Spectator"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "investigation_status", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Pending", "Pending"));
            liItem.Add(new ListItem("Completed", "Completed"));
            liItem.Add(new ListItem("Pending Capital Approval", "Pending Capital Approval"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "FK_LU_Meeting_Quality", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Spectator", "1"));
            liItem.Add(new ListItem("Water boy", "2"));
            liItem.Add(new ListItem("Second String", "3"));
            liItem.Add(new ListItem("Starter", "4"));
            liItem.Add(new ListItem("All Pro", "5")); 
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Marital_Status", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Divorced", "Divorced"));
            liItem.Add(new ListItem("Married", "Married"));
            liItem.Add(new ListItem("Single", "Single"));
            liItem.Add(new ListItem("Widowed", "Widowed"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Coverage_Form", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Occurrence", "O"));
            liItem.Add(new ListItem("Claims Made", "C"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "property_contact_type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Local Police", "Local Police"));
            liItem.Add(new ListItem("Fire Department", "Fire Department"));
            liItem.Add(new ListItem("County Sherriff", "County Sherriff"));
            liItem.Add(new ListItem("State Police", "State Police"));
            liItem.Add(new ListItem("Local Hospital", "Local Hospital"));
            liItem.Add(new ListItem("Ambulance", "Ambulance"));
            liItem.Add(new ListItem("HazMat", "HazMat"));
            liItem.Add(new ListItem("Other", "Other"));
            liItem.Add(new ListItem("Power", "Power"));
            liItem.Add(new ListItem("Water", "Water"));
            liItem.Add(new ListItem("Gas", "Gas"));
            liItem.Add(new ListItem("Cleaning", "Cleaning"));
            liItem.Add(new ListItem("Connectivity/Internet", "Connectivity/Internet"));
            liItem.Add(new ListItem("Other Contact", "Other Contact"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Gender", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Male", "M"));
            liItem.Add(new ListItem("Female", "F"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Initial_Claim_Classification", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Potential Lost-time from Work", "1"));
            liItem.Add(new ListItem("Medical care and treatment only from a “Health Provider”", "2"));
            liItem.Add(new ListItem("Report Only – No medical care or treatment provided by a Health Provider", "3"));
            liItem.Add(new ListItem("Unknown at this time", "4"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Offsiteonsite", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Onsite", "0"));
            liItem.Add(new ListItem("Offsite", "1"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "BusinessPersonal", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Business", "Business"));
            liItem.Add(new ListItem("Personal", "Personal"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoNone", true) == 0)
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
        else if (string.Compare(strType, "ApprovedNotApproved", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Approved", "1"));
            liItem.Add(new ListItem("Not Approved", "0"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoUnknown", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            liItem.Add(new ListItem("Unknown", "-1"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "yesNoNotRequired", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Yes", "Y"));
            liItem.Add(new ListItem("No", "N"));
            liItem.Add(new ListItem("Not Required", "R"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "DirectIndirect", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Direct", "D"));
            liItem.Add(new ListItem("Indirect", "I"));
            foreach (ListBox ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "HH_Or_Other", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Hart & Hickman", "1"));
            liItem.Add(new ListItem("Other Consultant", "0"));
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
    /// Fill Dynamic Drop Down
    /// </summary>
    /// <param name="strField_Name"></param>
    /// <param name="dropDowns"></param>
    /// <param name="booladdSelectAsFirstElement"></param>
    /// <param name="IsTableHasCode"></param>
    public static void FillFilterDropDownAction(string strField_Name, DropDownList[] dropDowns, bool booladdSelectAsFirstElement, string strClaimMajor_Coverage)
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
        Database db = DatabaseFactory.CreateDatabase();
        DataSet dsXML = new System.Data.DataSet();
        // Read XML Files
        dsXML.ReadXml(AppConfig.SitePath + @"App_Data\Business_Rule_Management.xml");
        string strTable = string.Empty, strType = string.Empty, strTextField = string.Empty, strValueField = string.Empty, strOrderBy = string.Empty, strActive = string.Empty;
        //bool IsTableHasCode = true;

        if (dsXML.Tables.Count > 0)
        {
            DataRow[] drFilter = dsXML.Tables[0].Select("Name = '" + strField_Name + "'");

            if (drFilter.Length > 0)
            {
                strTable = Convert.ToString(drFilter[0]["Table_Name"]);
                strType = Convert.ToString(drFilter[0]["ControlType"]);
                strTextField = Convert.ToString(drFilter[0]["TextField"]);
                strValueField = Convert.ToString(drFilter[0]["ValueField"]);
                strOrderBy = Convert.ToString(drFilter[0]["OrderBy"]);
                strActive = Convert.ToString(drFilter[0]["Active"]);
            }
        }
        clsGeneral.DisposeOf(dsXML);

        if (string.Compare(strType, "DropDown", true) == 0)
        {
            // DataSet dsData = clsGeneral.SelectByTableName(strTable);

            foreach (DropDownList ddlToFill in dropDowns)
            {

                string strSQL = string.Empty;
                strSQL = "SELECT " + strTextField + " AS strTextField," + strValueField + " AS strValueField FROM " + strTable + " WHERE 1=1 ";
                if ((!string.IsNullOrEmpty(strClaimMajor_Coverage)) && ((strTable == "LU_Cause") || (strTable == "LU_Coverage") || (strTable == "Claim") || (strTable == "LU_Payment_Id")))
                {
                    if (strTable == "LU_Cause" || strTable == "LU_Payment_Id")
                    {
                        strSQL = strSQL + " AND " + strClaimMajor_Coverage.Replace("Maj_Cov", "Major_Coverage");
                    }
                    else
                        strSQL = strSQL + " AND " + strClaimMajor_Coverage;
                }
                if (!string.IsNullOrEmpty(strActive))
                    strSQL = strSQL + " AND Active = '" + strActive + "'";
                strSQL = strSQL + " ORDER BY " + strOrderBy; ;
                DataSet ds = db.ExecuteDataSet(CommandType.Text, strSQL);

                if ((ds != null) && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DropDownList lstBox in dropDowns)
                    {
                        lstBox.Items.Clear();

                        lstBox.DataTextField = "strTextField";
                        lstBox.DataValueField = "strValueField";
                        lstBox.DataSource = ds.Tables[0];
                        lstBox.DataBind();
                    }
                }
            }

            //clsGeneral.DisposeOf(dsData);

        }

        else if (string.Compare(strType, "YesNo", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoChar", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "Y"));
            liItem.Add(new ListItem("No", "N"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoBit", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "drpYesNoNA", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            liItem.Add(new ListItem("NA", "0"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoNA", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            liItem.Add(new ListItem("NA", "2"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "drpYesNo9999", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            liItem.Add(new ListItem("NA", "0"));
            liItem.Add(new ListItem("9999", "3"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        //else if (string.Compare(strType, "Entry_Adjuster", true) == 0)
        //{
        //    DataTable dtAdjuster = ERIMS_DAL.Employee.SelectByAdjuster_Type_2().Tables[0];
        //    foreach (DropDownList ddlToFill in dropDowns)
        //    {
        //        ddlToFill.Items.Clear();
        //        ddlToFill.DataSource = dtAdjuster;
        //        ddlToFill.DataTextField = "Name";
        //        ddlToFill.DataValueField = "PK_Security_ID";
        //        ddlToFill.DataBind();

        //    }
        //}
        //else if (string.Compare(strType, "Claim_Adjuster", true) == 0)
        //{
        //    DataTable dtAdjuster = ERIMS_DAL.Employee.SelectByClaimAdjuster_Type().Tables[0];
        //    foreach (DropDownList ddlToFill in dropDowns)
        //    {
        //        ddlToFill.Items.Clear();
        //        ddlToFill.DataSource = dtAdjuster;
        //        ddlToFill.DataTextField = "Name";
        //        ddlToFill.DataValueField = "PK_Security_ID";
        //        ddlToFill.DataBind();
        //    }
        //}
        else if (string.Compare(strType, "Drug_Test", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            liItem.Add(new ListItem("Time Expired-no test", "3"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "LeftRight", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Left", "1"));
            liItem.Add(new ListItem("Right", "2"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Policy_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Occurrence", "O"));
            liItem.Add(new ListItem("Claims Made", "C"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Layer_Number", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Primary", "1"));
            liItem.Add(new ListItem("2", "2"));
            liItem.Add(new ListItem("3", "3"));
            liItem.Add(new ListItem("4", "4"));
            liItem.Add(new ListItem("5", "5"));
            liItem.Add(new ListItem("6", "6"));
            liItem.Add(new ListItem("7", "7"));
            liItem.Add(new ListItem("8", "8"));
            liItem.Add(new ListItem("9", "9"));
            liItem.Add(new ListItem("10", "10"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Payee", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Claimant", "C"));
            liItem.Add(new ListItem("Landstar", "L"));
            liItem.Add(new ListItem("Vendor", "V"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "dropGen", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("True", "--NA--"));
            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "2"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Distance_from_body_of_water", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("<1 MIles", "<1 MIles"));
            liItem.Add(new ListItem("1-5 Miles", "1-5 Miles"));
            liItem.Add(new ListItem("5-10 Miles", "5-10 Miles"));
            liItem.Add(new ListItem(">10 Miles", ">10 Miles"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Fire_Department_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Paid", "Paid"));
            liItem.Add(new ListItem("Part Paid", "Part Paid"));
            liItem.Add(new ListItem("Volunteer", "Volunteer"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Intru_Contact_Alarm_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Beam", "Beam"));
            liItem.Add(new ListItem("Motion", "Motion"));
            liItem.Add(new ListItem("Ultrasound", "Ultrasound"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Liability", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Assigned with Liability", "Assigned with Liability"));
            liItem.Add(new ListItem("Assigned without Liability", "Assigned without Liability"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "ActiveInactiveDisposed", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Active", "Active"));
            liItem.Add(new ListItem("InActive", "InActive"));
            liItem.Add(new ListItem("Disposed", "Disposed"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Ownership", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Sonic Owned with Internal Lease", "Internal"));
            liItem.Add(new ListItem("Sonic Owned with Third Party Lease", "ThirdParty"));
            liItem.Add(new ListItem("Sonic Owned", "Owned"));
            liItem.Add(new ListItem("Third Party Owned and Sonic Leased", "ThirdPartyLease"));
            liItem.Add(new ListItem("Third Party Owned and Sonic Leased and Subleased to Third Party", "ThirdPartySublease"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "MortgageeLandlord", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Mortgagee", "Mortgagee"));
            liItem.Add(new ListItem("Landlord", "Landlord"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "GALimitAppliesTo", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Policy", "1"));
            liItem.Add(new ListItem("Project", "2"));
            liItem.Add(new ListItem("Location", "3"));
            liItem.Add(new ListItem("N/A", "0"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "TypeOfVehicle", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("New Inventory", "New Inventory"));
            liItem.Add(new ListItem("Used Inventory", "Used Inventory"));
            liItem.Add(new ListItem("Demo", "Demo"));
            liItem.Add(new ListItem("Shop Loaner", "Shop Loaner"));
            liItem.Add(new ListItem("Daily Rental", "Daily Rental"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Ground_Location", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("On Surface", "On Surface"));
            liItem.Add(new ListItem("Underground", "Underground"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Contact_Type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("HR", "HR"));
            liItem.Add(new ListItem("Legal", "Legal"));
            liItem.Add(new ListItem("Risk Management", "Risk Management"));
            liItem.Add(new ListItem("Other", "Other"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Sonic_Cause_Code", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("S0-1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY", "S0-1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"));
            liItem.Add(new ListItem("S0-2-FALL SAME LEVEL OR ELEVATED SURFACE", "S0-2-FALL SAME LEVEL OR ELEVATED SURFACE"));
            liItem.Add(new ListItem("S0-3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART", "S0-3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"));
            liItem.Add(new ListItem("S0-4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT", "S0-4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"));
            liItem.Add(new ListItem("S0-5-OTHER - NOT CLASSIFIED", "S0-5-OTHER - NOT CLASSIFIED"));
            liItem.Add(new ListItem("S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY", "S1-OVEREXERTION-LIFTLOWER, PUSH/PULL, CARRY"));
            liItem.Add(new ListItem("S2-FALL SAME LEVEL OR ELEVATED SURFACE", "S2-FALL SAME LEVEL OR ELEVATED SURFACE"));
            liItem.Add(new ListItem("S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART", "S3-VEHICLE RELATED - HIGHWAY, PREMISES, GOLF CART"));
            liItem.Add(new ListItem("S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT", "S4-STRUCK BY/AGAINST - STATIONARY OBJECT/FALLING MOVING OBJECT"));
            liItem.Add(new ListItem("S5-OTHER - NOT CLASSIFIED IN ABOVE CODES", "S5-OTHER - NOT CLASSIFIED IN ABOVE CODES"));
            liItem.Add(new ListItem("S-1 Denied", "S-1 Denied"));
            liItem.Add(new ListItem("S-2 Denied", "S-2 Denied"));
            liItem.Add(new ListItem("S-3 Denied", "S-3 Denied"));
            liItem.Add(new ListItem("S-4 Denied", "S-4 Denied"));
            liItem.Add(new ListItem("S-5 Denied", "S-5 Denied"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Investigative_Quality", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("All Pro", "All Pro"));
            liItem.Add(new ListItem("Starter", "Starter"));
            liItem.Add(new ListItem("Second String", "Second String"));
            liItem.Add(new ListItem("Water boy", "Water boy"));
            liItem.Add(new ListItem("Spectator", "Spectator"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "investigation_status", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Pending", "Pending"));
            liItem.Add(new ListItem("Completed", "Completed"));
            liItem.Add(new ListItem("Pending Capital Approval", "Pending Capital Approval"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "FK_LU_Meeting_Quality", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Spectator", "1"));
            liItem.Add(new ListItem("Water boy", "2"));
            liItem.Add(new ListItem("Second String", "3"));
            liItem.Add(new ListItem("Starter", "4"));
            liItem.Add(new ListItem("All Pro", "5"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Marital_Status", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Divorced", "Divorced"));
            liItem.Add(new ListItem("Married", "Married"));
            liItem.Add(new ListItem("Single", "Single"));
            liItem.Add(new ListItem("Widowed", "Widowed"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Coverage_Form", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Occurrence", "O"));
            liItem.Add(new ListItem("Claims Made", "C"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "property_contact_type", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Local Police", "Local Police"));
            liItem.Add(new ListItem("Fire Department", "Fire Department"));
            liItem.Add(new ListItem("County Sherriff", "County Sherriff"));
            liItem.Add(new ListItem("State Police", "State Police"));
            liItem.Add(new ListItem("Local Hospital", "Local Hospital"));
            liItem.Add(new ListItem("Ambulance", "Ambulance"));
            liItem.Add(new ListItem("HazMat", "HazMat"));
            liItem.Add(new ListItem("Other", "Other"));
            liItem.Add(new ListItem("Power", "Power"));
            liItem.Add(new ListItem("Water", "Water"));
            liItem.Add(new ListItem("Gas", "Gas"));
            liItem.Add(new ListItem("Cleaning", "Cleaning"));
            liItem.Add(new ListItem("Connectivity/Internet", "Connectivity/Internet"));
            liItem.Add(new ListItem("Other Contact", "Other Contact"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Gender", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Male", "M"));
            liItem.Add(new ListItem("Female", "F"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Initial_Claim_Classification", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Potential Lost-time from Work", "1"));
            liItem.Add(new ListItem("Medical care and treatment only from a “Health Provider”", "2"));
            liItem.Add(new ListItem("Report Only – No medical care or treatment provided by a Health Provider", "3"));
            liItem.Add(new ListItem("Unknown at this time", "4"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "Offsiteonsite", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Onsite", "0"));
            liItem.Add(new ListItem("Offsite", "1"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "BusinessPersonal", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Business", "Business"));
            liItem.Add(new ListItem("Personal", "Personal"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoNone", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();

            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            liItem.Add(new ListItem("None", "2"));

            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "ApprovedNotApproved", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Approved", "1"));
            liItem.Add(new ListItem("Not Approved", "0"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "YesNoUnknown", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Yes", "1"));
            liItem.Add(new ListItem("No", "0"));
            liItem.Add(new ListItem("Unknown", "-1"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "yesNoNotRequired", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Yes", "Y"));
            liItem.Add(new ListItem("No", "N"));
            liItem.Add(new ListItem("Not Required", "R"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "DirectIndirect", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Direct", "D"));
            liItem.Add(new ListItem("Indirect", "I"));
            foreach (DropDownList ddlToFill in dropDowns)
            {
                ddlToFill.Items.Clear();
                for (int i = 0; i < liItem.Count; i++)
                {
                    ddlToFill.Items.Add((ListItem)liItem[i]);
                }
            }
        }
        else if (string.Compare(strType, "HH_Or_Other", true) == 0)
        {
            List<ListItem> liItem = new List<ListItem>();
            liItem.Add(new ListItem("Hart & Hickman", "1"));
            liItem.Add(new ListItem("Other Consultant", "0"));
            foreach (DropDownList ddlToFill in dropDowns)
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
                else if (AmountType == AmountCriteria.GreaterThanEqual)
                    strWhere += " <= ";
                else if (AmountType == AmountCriteria.LessThan)
                    strWhere += " > ";
                else if (AmountType == AmountCriteria.LessThanEqual)
                    strWhere += " >= ";
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
                else if (AmountType == AmountCriteria.GreaterThanEqual)
                    strWhere += " >= ";
                else if (AmountType == AmountCriteria.LessThan)
                    strWhere += " < ";
                else if (AmountType == AmountCriteria.LessThanEqual)
                    strWhere += " <= ";
                else
                    strWhere += " = ";
                strWhere += Convert.ToString(FromAmount).Trim().Replace(",", "");
            }
        }

        return strWhere;
    }

    /// <summary>
    /// used for getting Where condition for Number fields based on Number criteria
    /// </summary>
    /// <param name="NumberFieldName"></param>
    /// <param name="FromNumber"></param>
    /// <param name="ToNumber"></param>
    /// <param name="NumberType"></param>
    /// <returns></returns>
    public static string GetNumberWhere(string NumberFieldName, decimal? FromNumber, decimal? ToNumber, NumberCriteria NumberType, bool IsNotSelected)
    {
        string strWhere = string.Empty;

        if (NumberFieldName == "[AL_FR].Driver_Age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[AL_FR].Driver_Date_of_Birth,GETDATE())";
        }
        else if (NumberFieldName == "[AssocEmployee].Age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[AssocEmployee].Date_Of_Birth,GETDATE())";
        }
        else if (NumberFieldName == "[AL_FR].Passenger_Age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[AL_FR].Passenger_Date_of_Birth,GETDATE())";
        }
        else if (NumberFieldName == "[AL_FR].Other_Driver_Age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[AL_FR].Other_Driver_Date_of_Birth,GETDATE())";
        }
        else if (NumberFieldName == "[AL_FR].Oth_Veh_Pass_age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[AL_FR].Oth_Veh_Pass_Date_of_Birth,GETDATE())";
        }
        else if (NumberFieldName == "[AL_FR].Pedestrian_Age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[AL_FR].Pedestrian_Date_of_Birth,GETDATE())";
        }
        else if (NumberFieldName == "[Auto_Loss_Claims].Driver_age")
        {
            NumberFieldName = "DATEDIFF(YEAR,[Auto_Loss_Claims].Driver_Date_of_Birth,GETDATE())";
        }
        
        if (IsNotSelected == true)
        {
            if (NumberType == NumberCriteria.Between)
            {
                if (FromNumber.HasValue)
                    strWhere = " AND (" + NumberFieldName + " < " + Convert.ToString(FromNumber).Trim().Replace(",", "") + " ";
                if (ToNumber.HasValue)
                    strWhere += " OR " + NumberFieldName + " > " + Convert.ToString(ToNumber).Trim().Replace(",", "") + " ";
                strWhere += " ) ";
            }
            else
            {
                strWhere = " AND " + NumberFieldName + " ";
                if (NumberType == NumberCriteria.GreaterThan)
                    strWhere += " < ";
                else if (NumberType == NumberCriteria.GreaterThanEqual)
                    strWhere += " <= ";
                else if (NumberType == NumberCriteria.LessThan)
                    strWhere += " > ";
                else if (NumberType == NumberCriteria.LessThanEqual)
                    strWhere += " >= ";
                else
                    strWhere += " != ";
                strWhere += Convert.ToString(FromNumber).Trim().Replace(",", "");
            }
        }
        else
        {
            if (NumberType == NumberCriteria.Between)
            {
                if (FromNumber.HasValue)
                    strWhere = " AND " + NumberFieldName + " >= " + Convert.ToString(FromNumber).Trim().Replace(",", "") + " ";
                if (ToNumber.HasValue)
                    strWhere += " AND " + NumberFieldName + " <= " + Convert.ToString(ToNumber).Trim().Replace(",", "") + " ";
            }
            else
            {
                strWhere = " AND " + NumberFieldName + " ";
                if (NumberType == NumberCriteria.GreaterThan)
                    strWhere += " > ";
                else if (NumberType == NumberCriteria.GreaterThanEqual)
                    strWhere += " >= ";
                else if (NumberType == NumberCriteria.LessThan)
                    strWhere += " < ";
                else if (NumberType == NumberCriteria.LessThanEqual)
                    strWhere += " <= ";
                else
                    strWhere += " = ";
                strWhere += Convert.ToString(FromNumber).Trim().Replace(",", "");
            }
        }

        return strWhere;
    }

    /// <summary>
    /// function which return Relative date for Current date based on RaltiveDates Criteria
    /// </summary>
    /// <param name="RelDateType"></param>
    /// <returns></returns>
    public static DateTime GetRelativeDate(Business_RuleHelper.RaltiveDates RelDateType)
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

        return dtReturn;
    }

}
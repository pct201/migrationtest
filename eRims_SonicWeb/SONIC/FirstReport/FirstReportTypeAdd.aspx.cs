using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
/// <summary>
/// Date           : 18-07-08
/// 
/// Developer Name : Ravi Gupta
/// 
/// Description    : Used to add new First Report Type to Current First Report Wizard.
/// 
/// </summary>
public partial class SONIC_FirstReportTypeAdd : clsBasePage
{
    /// <summary>
    /// Denotes the First Report ID
    /// </summary>
    public int First_Report_Wizard_ID
    {
        get
        {
            return clsGeneral.GetInt(clsSession.First_Report_Wizard_ID);
        }
        set { clsSession.First_Report_Wizard_ID = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// Handle Continue Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        string strURL = "";
        
        if (ddlFirstReportType.SelectedValue.ToString() != "0")
        {
            //Create Object
            First_Report_Wizard objFRW = new First_Report_Wizard();
            objFRW.PK_First_Report_Wizard_ID = First_Report_Wizard_ID;
            //check First Report type and According to the Name of Report set value in object
            if (ddlFirstReportType.SelectedValue.ToUpper() == "WC")
            {
                objFRW.Injured_Employee = true;
                strURL = "WCFirstReport.aspx";
                SetTabValtoSession("1");
            }
            else
            {
                objFRW.Injured_Employee = false;
            }
            //check First Report type and According to the Name of Report set value in object
            if (ddlFirstReportType.SelectedValue.ToUpper() == "DPD")
            {
                objFRW.Inventoried_Vehicle = true;
                strURL = "DPDFirstReport.aspx";
                SetTabValtoSession("3");
            }
            else
            {
                objFRW.Inventoried_Vehicle = false;
            }
            //check First Report type and According to the Name of Report set value in object
            if (ddlFirstReportType.SelectedValue.ToUpper() == "AL")
            {
                objFRW.Customer_Vehicle = true;
                strURL = "ALFirstReport.aspx";
                SetTabValtoSession("2");
            }
            else
            {
                objFRW.Customer_Vehicle = false;
            }
            //check First Report type and According to the Name of Report set value in object
            if (ddlFirstReportType.SelectedValue.ToUpper() == "PL")
            {
                objFRW.General_Claim = true;
                strURL = "PLFirstReport.aspx";
                SetTabValtoSession("5");
            }
            else
            {
                objFRW.General_Claim = false;
            }
            //check First Report type and According to the Name of Report set value in object
            if (ddlFirstReportType.SelectedValue.ToUpper() == "PROPERTY")
            {
                objFRW.Property_Claim = true;
                strURL = "PropertyFirstReport.aspx";
                SetTabValtoSession("4");
            }
            else
            {
                objFRW.Property_Claim = false;
            }

            int rtnval = objFRW.AddNewReport();

            Response.Redirect(strURL + "?id=" + Encryption.Encrypt(rtnval.ToString()));
        }
    }

    /// <summary>
    /// Used to set Allowed Tab session. while adding new First Report
    /// </summary>
    /// <param name="AllowTabId"></param>
    public void SetTabValtoSession(string AllowTabId)
    {
        if (!string.IsNullOrEmpty(AllowTabId))
        {
            string AllowTab = clsSession.AllowedTab.ToString();
            string[] AllTab = AllowTab.Split(Convert.ToChar(","));
            int intCC = AllTab.Length;
            bool checkDup = false;
            for (int inti = 0; inti < intCC; inti++)
            {
                //check Pased value is already in session. if yes than update CheckDup boolean value to true else remain false
                if (AllTab[inti].ToString().ToUpper() == AllowTabId.ToString().ToUpper())
                {
                    checkDup = true;
                }
                //check value of checkDup variable. if it is false than add Allowedid to Session Variable
                if (checkDup == false)
                {
                    if (AllowTab != string.Empty)
                        AllowTab += "," + AllowTabId;
                    else
                        AllowTab += AllowTabId;
                }
            }
            clsSession.AllowedTab = AllowTab;
        }
    }
}

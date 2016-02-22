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
public partial class Controls_SONICInfo_SonicInfo : System.Web.UI.UserControl
{
    public ReportType CurrentReportType;
    /// <summary>
    /// Denotes First Report Type
    /// </summary>
    public enum ReportType
    {
        WC = 1,
        AL = 2,
        DPD = 3,
        Property = 4,
        PL = 5
    }
    public Boolean Access_Type;
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

    public string ClaimInfo
    {
        get
        {
            return clsSession.ClaimID_Diary;
        }
        set { clsSession.ClaimID_Diary = value; }
    }

    /// <summary>
    /// Denotes the First Report Number
    /// </summary>
    public string FirstReportNumber
    {
        set
        {
            //if value is null than denote "" to lblFirstReportNumber else denote value
            if (string.IsNullOrEmpty(value))
            {
                lblFirstReportNumber.Text = "";
            }
            else
            {
                lblFirstReportNumber.Text = value;
            }
        }
    }

    public string ClaimNumber
    {
        set
        {
            //if value is null than denote "" to lblFirstReportNumber else denote value
            if (string.IsNullOrEmpty(value))
            {
                lnkClaimNumber.Text = "";
            }
            else
            {
                lnkClaimNumber.Text = value;
            }
        }
    }

    /// <summary>
    /// Denotes the Location dba
    /// </summary>
    public string SONICLocationdba
    {
        set
        {
            //if value is null than denote "" to lblLocationdba else denote value
            if (string.IsNullOrEmpty(value))
            {
                lblLocationdba.Text = "";
            }
            else
            {
                lblLocationdba.Text = value;
            }
        }
    }
    /// <summary>
    /// Denotes the Name
    /// </summary>
    public string Name
    {
        set
        {
            //if value is null than denote "" to lblName and hide the name columan else denote value
            if (string.IsNullOrEmpty(value))
            {
                lblName.Text = "";
                if (CurrentReportType != ReportType.WC)
                {
                    tdHeaderName.Style.Add("display", "none");
                    tdName.Style.Add("display", "none");
                }
                else
                {
                    tdHeaderName.Style.Add("display", "block");
                    tdName.Style.Add("display", "block");
                }
            }
            else
            {
                lblName.Text = value;
                tdHeaderName.Style.Add("display", "block");
                tdName.Style.Add("display", "block");
            }
        }
    }
    /// <summary>
    /// Denotes the Date of Incident
    /// </summary>
    public string DateOfIncident
    {
        set
        {
            //if value is null than denote "" to lbldateIncident else denote value
            if (string.IsNullOrEmpty(value))
            {
                lblDateIncident.Text = "";
            }
            else
            {
                lblDateIncident.Text = value;
            }
        }
    }
    /// <summary>
    /// Display Add new Link
    /// </summary>
    public Boolean AddNewLink
    {
        set
        {
            //if value is null than denote "" to lbldateIncident else denote value
            if (value == false)
            {
                lnkAddNew.Visible = false;
            }
            else
            {
                lnkAddNew.Visible = true;
            }
        }
    }

    public Boolean ClaimLinkVisibility
    {
        set
        {
            lnkClaimNumber.Visible = value ? true : false;
            lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/PropertyClaimInfo.aspx?id=" + Encryption.Encrypt(ClaimInfo);
        }
    }

    public void SetClaimPostBackUrlAndVisibility(decimal fK_Property_Claims_ID, decimal fk_First_Report_Wizard_ID)
    {
        if (fK_Property_Claims_ID > 0)
        {
            lnkClaimNumber.Visible = true;
            lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/PropertyClaimInfo.aspx?id=" + Encryption.Encrypt(fK_Property_Claims_ID.ToString()) + "&mode=view&wz_id=" + Encryption.Encrypt(fk_First_Report_Wizard_ID.ToString());
        }
        else {
            lnkClaimNumber.Enabled = false;
        }
        
    }

    /// <summary>
    /// Shows Investigation block for WC module, otherwise hides.
    /// </summary>
    public bool ShowInvestigation
    {
        set
        {
            tdHeaderInvestigation.Style["display"] = "none";
            tdDataInvestigation.Style["display"] = "none";
            if (value == true)
            {
                tdHeaderInvestigation.Style["display"] = "block";
                tdDataInvestigation.Style["display"] = "block";
                int intInvID = Investigation.SelectPKByWc_FR_ID(WC_FR_ID_For_Investigation);
                if (intInvID > 0)
                {
                    lnkInvestigation.Text = intInvID.ToString();
                    lnkInvestigation.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(intInvID.ToString()) + "&wc=" + Encryption.Encrypt(WC_FR_ID_For_Investigation.ToString());
                    lnkAddInvestigation.Visible = false;
                }
                else
                {
                    //check acces type if it is true than display LInk else hide.
                    if (Access_Type == true)
                    {
                        lnkAddInvestigation.Visible = true;
                    }
                    else
                    {
                        lnkAddInvestigation.Visible = false;
                    }
                }
            }
            else
            {
                tdHeaderInvestigation.Style["display"] = "none";
                tdDataInvestigation.Style["display"] = "none";
            }
        }
    }
    /// <summary>
    /// get and set WC_FR_ID for Investigation
    /// </summary>
    public int WC_FR_ID_For_Investigation
    {
        get { return Convert.ToInt32(ViewState["WC_FR_ID_For_Investigation"]); }
        set { ViewState["WC_FR_ID_For_Investigation"] = value; }
    }
    #region Page Load Events
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Page POst Back
        if (!IsPostBack)
        {
            //Fill Report List to dropdownlist
            ComboHelper.FillReportType_ByWizardID(new DropDownList[] { ddlCompanionFirstReport }, false, First_Report_Wizard_ID);
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                ListItem lstPF_FR_ID = new ListItem();
                lstPF_FR_ID = ddlCompanionFirstReport.Items.FindByValue(Encryption.Decrypt(Request.QueryString["id"].ToString()));

                if (CurrentReportType == ReportType.WC)
                    lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/WCClaimInfo.aspx?id=" + Encryption.Encrypt(ClaimInfo);
                else if (CurrentReportType == ReportType.AL)
                    lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/ALClaimInfo.aspx?id=" + Encryption.Encrypt(ClaimInfo);
                else if (CurrentReportType == ReportType.DPD)
                    lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/DPDClaimInfo.aspx?id=" + Encryption.Encrypt(ClaimInfo);
                else if (CurrentReportType == ReportType.PL)
                    lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/PLClaimInfo.aspx?id=" + Encryption.Encrypt(ClaimInfo);
                else if (CurrentReportType == ReportType.Property)
                    //lnkClaimNumber.PostBackUrl = AppConfig.SiteURL + "SONIC/ClaimInfo/PropertyClaimInfo.aspx?id=" + Encryption.Encrypt(ClaimInfo);

                if (lstPF_FR_ID != null)
                {
                    ddlCompanionFirstReport.Items.Remove(lstPF_FR_ID);
                }
                if (ddlCompanionFirstReport.Items.Count > 0)
                {
                    ddlCompanionFirstReport.Items.Insert(0, new ListItem("--First Report List--", "0"));
                }
                else
                {
                    ddlCompanionFirstReport.Items.Insert(0, new ListItem("--None--", "0"));
                }
            }
            else
            {
                ddlCompanionFirstReport.Items.Insert(0, new ListItem("--None--", "0"));
            }
            //check User Access Type. if is View only than Hide Add new Link Button
        }
    }
    #endregion

    #region Add New Link
    /// <summary>
    /// Add new link click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("FirstReportTypeAdd.aspx");
    }

    protected void lnkAddInvestigation_Click(object sender, EventArgs e)
    {
        Investigation objInv = new Investigation();

        DataTable dt = Investigation.SelectByWc_FR_ID(WC_FR_ID_For_Investigation).Tables[0];
        DateTime? dtLastUpdate = null;

        int intInvID;

        // Check if Investigation is Exists or not.
        if (dt.Rows.Count > 0)
        {
            intInvID = Convert.ToInt32(dt.Rows[0]["PK_Investigation_ID"]);

            // Check if last updated date is not null
            if (dt.Rows[0]["Updated_Date"] != DBNull.Value)
            {
                dtLastUpdate = Convert.ToDateTime(dt.Rows[0]["Updated_Date"]);
                // get difference Between Current Date and Last Update date
                TimeSpan tp = DateTime.Now - dtLastUpdate.Value;

                // If record has been saved less than 20 minutes 
                if (tp.TotalMinutes < 20)
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "ShowError", "alert('An Investigation record is currently being added, please retry in 20 minutes.')", true);
                    ScriptManager.RegisterStartupScript(this.Parent.Parent, GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                    return;
                }
                else
                {
                    // Show Message For View Investigation Record.
                    ScriptManager.RegisterStartupScript(Page, GetType(), DateTime.Now.ToString(), "javascript:ShowMessage(" + intInvID.ToString() + "," + WC_FR_ID_For_Investigation.ToString() + ");", true);
                    return;
                }
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(Convert.ToString(WC_FR_ID_For_Investigation)))
            {
                WC_FR objWC_FR = new WC_FR(WC_FR_ID_For_Investigation);

                objInv.Physician_Other_Professional = objWC_FR.Treating_Physician_Name;
                objInv.Facility = objWC_FR.Medical_Facility_Name;
                objInv.Facility_Address = objWC_FR.Medical_Facility_Address1;
                objInv.Facility_City = objWC_FR.Medical_Facility_City;

                if (!string.IsNullOrEmpty(objWC_FR.Medical_Facility_State))
                {
                    objInv.FK_State_Facility = clsGeneral.GetDecimal(objWC_FR.Medical_Facility_State);
                }

                objInv.Facility_Zip_Code = objWC_FR.Medical_Facility_Zip;
                objInv.Emergency_Room = objWC_FR.Emergency_Room;
                objInv.Time_Began_Work = objWC_FR.Time_Began_Work;
                objInv.Activity_Before_Incident = objWC_FR.Activity_Before_Incident;
                objInv.Object_Substance_Involved = objWC_FR.Object_Substance_Involved;
                objInv.Admitted_to_Hospital = objWC_FR.Admitted_to_Hospital;
            }

            objInv.FK_WC_FR_ID = Convert.ToInt32(WC_FR_ID_For_Investigation);
            objInv.FK_LU_Location_ID = Convert.ToInt32(new WC_FR(WC_FR_ID_For_Investigation).FK_LU_Location);
            objInv.Updated_Date = System.DateTime.Now;
            intInvID = objInv.Insert();
        }

        Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(intInvID.ToString()) + "&wc=" + Encryption.Encrypt(WC_FR_ID_For_Investigation.ToString()) + "&op=edit");
        //Response.Redirect(AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?wc=" + WC_FR_ID_For_Investigation);
    }
    #endregion

    /// <summary>
    /// as per selected value from dropdown page redirection is done.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ddlCompanionFirstReport_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strURL = "";
        string rtnval = "";
        if (ddlCompanionFirstReport.SelectedValue.ToString() != "0")
        {
            rtnval = ddlCompanionFirstReport.SelectedValue.ToString();
            string[] strVal = ddlCompanionFirstReport.SelectedItem.Text.ToString().Split(Convert.ToChar("-"));
            if (strVal.Length == 2)
            {
                strURL = strVal[0];
            }
        }
        switch (strURL.ToUpper())
        {
            case "WC":
                strURL = "WCFirstReport.aspx";
                break;
            case "NS":
                strURL = "WCFirstReport.aspx";
                break;
            case "DPD":
                strURL = "DPDFirstReport.aspx";
                break;
            case "AL":
                strURL = "ALFirstReport.aspx";
                break;
            case "PL":
                strURL = "PLFirstReport.aspx";
                break;
            case "PROP":
                strURL = "PropertyFirstReport.aspx";
                break;
            default:
                break;
        }
        Response.Redirect(strURL + "?id=" + Encryption.Encrypt(rtnval.ToString()));
    }
}

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
public partial class Admin_LetterHistory : clsBasePage
{
    // PK for Letter History
    private int PK_COI_Letter_History
    {
        get
        {
            return clsGeneral.GetInt(ViewState["LetterHistoryID"]);
        }
        set { ViewState["LetterHistoryID"] = value; }
    }

    private decimal PK_COIs
    {
        get
        {
            return Convert.ToDecimal(ViewState["PK_COIs"]);
        }
        set { ViewState["PK_COIs"] = value; }
    }

    #region "Page Events"
    /// <summary>
    /// Handle Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time.
        Page.ClientScript.RegisterStartupScript(Page.GetType(), "ShowPanel", "javascript:ShowPanel(1);", true);

        if (!IsPostBack)
        {
            if (App_Access == AccessType.NotAssigned)
                Response.Redirect(AppConfig.SiteURL + "Message.aspx?msg=You are not authorized to access this page");
            else
            {
                // if id is passed set primary key.
                if (!clsGeneral.IsNull(Request.QueryString["id"]))
                {
                    //   PK_COI_Letter_History = Convert.ToInt32(Request.QueryString["id"]);
                    PK_COI_Letter_History = (int)clsGeneral.GetQueryStringID(Request.QueryString["id"]);
                    BindDetailsForView();
                    if (App_Access == AccessType.Administrative_Access)
                    {
                        // set Attachment details control in read/write mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Letter_History, PK_COI_Letter_History, true, 0);
                        BindAttachmentDetails();
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }

    #endregion

    /// <summary>
    /// Displays the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // create object for curernt Letter History
        COI_Letter_History objLetterHistory = new COI_Letter_History(PK_COI_Letter_History);

        PK_COIs = objLetterHistory.FK_COIs;
        // set values
        COIs objCOI = new COIs(objLetterHistory.FK_COIs);
        COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds);
        lblInsured.Text = clsGeneral.FormatName(objInsured.Contact_First_Name, objInsured.Contact_Last_Name);

        if (objCOI.Issue_Date.HasValue)
            lblIssueDate.Text = objCOI.Issue_Date.Value.ToString(AppConfig.DisplayDateFormat);

        lblDateLetterSent.Text = objLetterHistory.Date_Letter_Sent.ToString(AppConfig.DisplayDateFormat);
        lblNoncomplianceLevel.Text = new COI_Noncompliance_Level(objLetterHistory.FK_COI_Noncompliance_Level).Fld_Desc;
        lblGeneral.Text = new COI_Coverage_Status(objLetterHistory.FK_COI_Coverage_Status_General).Fld_Desc;
        lblWCLiability.Text = new COI_Coverage_Status(objLetterHistory.FK_COI_Coverage_Status_WC).Fld_Desc;
        lblAutomobile.Text = new COI_Coverage_Status(objLetterHistory.FK_COI_Coverage_Status_Automobile).Fld_Desc;
        lblProperty.Text = new COI_Coverage_Status(objLetterHistory.FK_COI_Coverage_Status_Property).Fld_Desc;
        lblExcess.Text = new COI_Coverage_Status(objLetterHistory.FK_COI_Coverage_Status_Excess).Fld_Desc;
        lblProfessional.Text = new COI_Coverage_Status(objLetterHistory.FK_COI_Coverage_Status_Prfessional).Fld_Desc;

        lblCancellationNotice.Text = (objLetterHistory.Cancellation_Notice == "Y") ? "NO" : "YES";
        lblSignedCertificate.Text = (objLetterHistory.Signed_Certificate_Received == "Y") ? "NO" : "YES";
        lblAMBestRating.Text = (objLetterHistory.AM_Best == "Y") ? "NO" : "YES";
        lblOrdinanceOrLaw.Text = (objLetterHistory.Ordinance_Law == "Y") ? "NO" : "YES";
        lblSubrogation.Text = (objLetterHistory.Subrogation_Waiver == "Y") ? "NO" : "YES";
        lblInsuredPerils.Text = (objLetterHistory.Insured_Perils == "Y") ? "NO" : "YES";
        lblReplacementCost.Text = (objLetterHistory.Replacement_Cost == "Y") ? "NO" : "YES";
        lblProperty.Text = (objLetterHistory.Property_On_Acord == "Y") ? "NO" : "YES";
        lblLevel1Text.Text = objLetterHistory.LeveL_1_Text;
        lblLevel2Text.Text = objLetterHistory.LeveL_2_Text;
        lblLevel3Text.Text = objLetterHistory.LeveL_3_Text;
        lblLevel4Text.Text = objLetterHistory.LeveL_4_Text;
        BindComplianceGridForView();

    }

    /// <summary>
    /// Handle Attachment Control Add Attachment Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddAttachment_Click(object sender, EventArgs e)
    {
        // check if producer reocord is saved or not.
        // if not don't save any attachment
        if (PK_COI_Letter_History > 0)
        {
            Attachment.Add(clsGeneral.Tables.Letter_History, PK_COI_Letter_History);
            // after saving attachment bind attachment details again.
            BindAttachmentDetails();
        }
    }
    /// <summary>
    /// show attachment details div and bind the details.
    /// </summary>
    private void BindAttachmentDetails()
    {
        AttachDetails.Bind();
    }
    /// <summary>
    /// Handle Back Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("LetterHistoryList.aspx");
    }

    /// <summary>
    /// Bind Compliance data for View
    /// </summary>
    private void BindComplianceGridForView()
    {
        DataTable dt = COI_Compliance_Text.SelectAll().Tables[0];
        DataTable dtTemp = new DataTable();
        dtTemp = dt.Clone();
        DataRow[] dr;
        if (dt.Rows.Count > 0)
        {
            dr = dt.Select("IsTurnedOn = 'Y'");
            for (int i = 0; i < dr.Length; i++)
            {
                dtTemp.ImportRow(dr[i]);
            }
        }
        dlComplianceView.DataSource = dtTemp;
        dlComplianceView.DataBind();
    }

    /// <summary>
    /// Compliance Item Data Bound Event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void dlComplianceTextView_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (PK_COIs != 0)
        {
            COIs objCOI = new COIs(PK_COIs);
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int ID = Convert.ToInt32(((HiddenField)e.Item.FindControl("hdnPK")).Value);
                Label lblIsTurnedOn = (Label)e.Item.FindControl("lblIsTurnedOn");
                if (objCOI.Compliance_01 == "Y" && ID == 1)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_02 == "Y" && ID == 2)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_03 == "Y" && ID == 3)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_04 == "Y" && ID == 4)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_05 == "Y" && ID == 5)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_06 == "Y" && ID == 6)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_07 == "Y" && ID == 7)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_08 == "Y" && ID == 8)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_09 == "Y" && ID == 9)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else if (objCOI.Compliance_10 == "Y" && ID == 10)
                {
                    lblIsTurnedOn.Text = "YES";
                }
                else
                {
                    lblIsTurnedOn.Text = "NO";
                }
            }
        }
    }
}

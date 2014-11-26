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
public partial class ExecutiveRisk_InvestigatorNotes : clsBasePage
{
    #region Property

    /// <summary>
    /// Denotes primary key for Investigator_Notes record
    /// </summary>
    public int PK_Investigator_Notes
    {
        get { return Convert.ToInt32(ViewState["PK_Investigator_Notes"]); }
        set { ViewState["PK_Investigator_Notes"] = value; }
    }

    /// <summary>
    /// Get executive risk id which foreign key for Investigator_Notes record
    /// </summary>
    public int FK_Executive_Risk
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["eid"]))
            {
                return Convert.ToInt32(Convert.ToString(Request.QueryString["eid"]));
            }
            else
            {
                return -1;
            }
        }
    }

    /// <summary>
    /// Gets operation either edit or view if passed in querystring else it returns empty string
    /// </summary>
    public String strOperation
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                return Convert.ToString(Request.QueryString["op"]);
            }
            else
            {
                return String.Empty;
            }
        }
    }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        ExecutiveRiskInfo.SetSelectedTab(CtrlExecutiveRiskInfo.Tab.Executive_Risk);
        Attachment.btnHandler += new Controls_Attachments_Attachment.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            // check the foreign key is available otherwise redirect to executive risk page
            if (FK_Executive_Risk > 0)
            {
                // if querystring for operation to be performed is passed(view or edit)
                if (strOperation != string.Empty)
                {
                    // set PK_Investigator_Notes
                    PK_Investigator_Notes = Convert.ToInt32(Request.QueryString["id"]);

                    if (strOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                        // set attachment details control in readonly mode.
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Investigator_Notes, PK_Investigator_Notes, false, 2);
                    }
                    else
                    {
                        // Bind Controls
                        BindDetailsForEdit();
                        // set attachment details control in read/write mode. so user can add or remove attachment as well.                        
                        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.Investigator_Notes, PK_Investigator_Notes, true, 2);
                        //bind state drop down list                 
                    }
                    // bind attachment details to show attachment for current risk profile.
                    BindAttachmentDetails();
                }
                else
                {
                    // check for the access 
                    if (UserAccessType == AccessType.Executive_Risk_View)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    }
                    else
                    {
                        // hide Add Attachment button
                        Attachment.ShowAttachmentButton = false;
                        btnViewAudit.Visible = false;
                        btnAuditView.Visible = false;
                        // don't show div for view mode
                        dvView.Style["Display"] = "None";
                        BindAttachmentDetails();
                    }
                }

                if (strOperation != "view")
                    SetValidations();
            }
            else
            {
                Response.Redirect("ExecutiveRisk.aspx");
            }           
        }
    }

    #endregion

    #region Controls Event
    /// <summary>
    /// Handles Save And View Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        // check for page valid
        if (Page.IsValid)
        {
            // create object for Investigator_Notes class
            Investigator_Notes objNote = new Investigator_Notes(PK_Investigator_Notes);

            // set key values
            objNote.PK_Investigator_Notes = PK_Investigator_Notes;
            objNote.FK_Executive_Risk = FK_Executive_Risk;

            // set values from page controls
            objNote.Date_Of_Note = clsGeneral.FormatDateToStore(txtDateOfNotes);
            objNote.Investigator_Name = txtInvestigatorName.Text.Trim();
            objNote.Note_Subject = txtNoteSubject.Text.Trim();
            objNote.Notes = txtNotes.Text.Trim();


            // insert or update the record depending on Primary key
            if (PK_Investigator_Notes > 0)
                objNote.Update();
            else
                PK_Investigator_Notes = objNote.Insert();
            Upload_File(string.Empty);

            //redirect page in view mode
            String strQueryString = Request.QueryString.ToString();
            if (!String.IsNullOrEmpty(strOperation) && strOperation == "edit")
                strQueryString = strQueryString.Replace("edit", "view");
            else
                strQueryString = strQueryString + "&op=view&id=" + PK_Investigator_Notes;

            Response.Redirect("InvestigatorNotes.aspx?" + strQueryString);

        }
    }

    /// <summary>
    /// Handles back button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirect to executive risk page
        Response.Redirect("ExecutiveRisk.aspx?id=" + FK_Executive_Risk + "&pnl=7");
    }

    #endregion

    #region Methods

    /// <summary>
    /// Sets the page in view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // show view div
        dvView.Style["Display"] = "block";

        // don't show div edit in viewmode.
        dvEdit.Style["Display"] = "None";
        btnBack.Visible = true;
        btnViewAudit.Visible = false;
        btnAuditView.Visible = true;
        // create object for Investigator_Notes class
        Investigator_Notes objNote = new Investigator_Notes(PK_Investigator_Notes);

        // set values from page controls
        lblDateOfNotes.Text = clsGeneral.FormatDateToDisplay(objNote.Date_Of_Note);
        lblInvestigatorName.Text = objNote.Investigator_Name;
        lblNoteSubject.Text = objNote.Note_Subject;
        lblNotes.Text = objNote.Notes;
    }

    /// <summary>
    /// Sets the page in edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // create object for Investigator_Notes class
        Investigator_Notes objNote = new Investigator_Notes(PK_Investigator_Notes);

        btnViewAudit.Visible = true;
        btnAuditView.Visible = false;

        // set values in page controls
        txtDateOfNotes.Text = clsGeneral.FormatDateToDisplay(objNote.Date_Of_Note);
        txtInvestigatorName.Text = objNote.Investigator_Name;
        txtNoteSubject.Text = objNote.Note_Subject;
        txtNotes.Text = objNote.Notes;
    }


    #endregion

    #region "Attachments Management"

    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["Display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Upload_File(string strValue)
    {
        if (PK_Investigator_Notes > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.Investigator_Notes, PK_Investigator_Notes);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
    }

    #endregion

    #region Dynamic Validations
    /// <summary>
    /// Set all Validations
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region "Investigator Notes"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(83).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Investigator Name":
                    strCtrlsIDs += txtInvestigatorName.ClientID + ",";
                    strMessages += "Please enter [Investigator Notes]/Investigator Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Date of Note(s)":
                    strCtrlsIDs += txtDateOfNotes.ClientID + ",";
                    strMessages += "Please enter [Investigator Notes]/Date of Note(s)" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Investigator Note(s) Subject":
                    strCtrlsIDs += txtNoteSubject.ClientID + ",";
                    strMessages += "Please enter [Investigator Notes]/Investigator Note(s) Subject" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Investigator Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter [Investigator Notes]/Investigator Notes" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion
}

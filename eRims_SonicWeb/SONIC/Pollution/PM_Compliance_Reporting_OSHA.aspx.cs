using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Pollution_PM_Compliance_Reporting_OSHA : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Compliance_Reporting_OSHA
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Compliance_Reporting_OSHA"]);
        }
        set { ViewState["PK_PM_Compliance_Reporting_OSHA"] = value; }
    }

    public decimal FK_PM_Complaince_Reporting
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Complaince_Reporting"]);
        }
        set { ViewState["FK_PM_Complaince_Reporting"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            // shows the first panel
            txtDateCompleted.Focus();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            PK_PM_Compliance_Reporting_OSHA = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Complaince_Reporting = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);

            //Show SIC code from Site Information
            if (Session["SIC"] != null)
            {
                string s = Convert.ToString(Session["SIC"]);
                // Split string on spaces.
                // ... This will separate all the words.
                string[] sicDESC = s.Split(':');
                if (!string.IsNullOrEmpty(sicDESC[0]))
                    txtSIC.Text = lblvwSICCode.Text = sicDESC[0];

                if (!string.IsNullOrEmpty(sicDESC[1]))
                    lblSIC.Text = lblvwSICDesc.Text = sicDESC[1];

            }

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            if (PK_PM_Compliance_Reporting_OSHA > 0)
            {
                if (Request.QueryString["op"] != null)
                {
                    StrOperation = Request.QueryString["op"];
                }
                else
                    StrOperation = "edit";

                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    dvView.Style["display"] = "inline";
                    dvEdit.Style["display"] = "none";
                    btnSave.Visible = false;
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    //set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments, Convert.ToInt32(PK_PM_Compliance_Reporting_OSHA), "FK_PM_Complaince_Reporting_OSHA", "PK_PM_Compliance_Reporting_OSHA_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    ShowHideEdit();
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                    dvView.Style["display"] = "none";
                    dvEdit.Style["display"] = "inline";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    //set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments, Convert.ToInt32(PK_PM_Compliance_Reporting_OSHA), "FK_PM_Complaince_Reporting_OSHA", "PK_PM_Compliance_Reporting_OSHA_Attachments", true, 2);
                }
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                rdoLogPosted.SelectedIndex = -1;
                ShowHideEdit();
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();
                //BindDropdown();
                // disable Add Attachment button

                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnEdit.Visible = false;
                btnSave.Visible = true;
                btnAuditTrail.Visible = false;
            }

        }
    }
    #endregion

    #region Methods



    //private void BindDropdown()
    //{
    //    ComboHelper.FillUtilityType(new DropDownList[] { drpFK_LU_Utility_Type }, true);
    //    ComboHelper.FillState(new DropDownList[] { drpFK_State }, 0, true);
    //}

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnBack.Visible = true;
        btnSave.Visible = true;
        btnEdit.Visible = false;
        //BindDropdown();
        clsPM_Complaince_Reporting_OSHA objPM_Compliance_Reporting_OSHA = new clsPM_Complaince_Reporting_OSHA(PK_PM_Compliance_Reporting_OSHA);

        txtDateCompleted.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Compliance_Reporting_OSHA.Date_Completed);

        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Log_Posted_Feb_1))
            rdoLogPosted.SelectedValue = Convert.ToString(objPM_Compliance_Reporting_OSHA.Log_Posted_Feb_1);
        else
            rdoLogPosted.SelectedIndex = -1;
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.OSHA_Recordable.ToString()))
            txtNumberofOsha.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.OSHA_Recordable);
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Lost_Work_Days.ToString()))
            txtNumberofLostWorkDays.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Lost_Work_Days);
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Restsricted_Work_Days.ToString()))
            txtNumberofRestrictedWorkDays.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Restsricted_Work_Days);
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Total_Associates.ToString()))
            txtTotalNumberofAssociates.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Total_Associates);
        txtComments.Text = objPM_Compliance_Reporting_OSHA.Comments;
        txtExplainOsha.Text = objPM_Compliance_Reporting_OSHA.ExplainReason;
        ShowHideEdit();
    }

    private void ShowHideEdit()
    {
        if (rdoLogPosted.SelectedValue == "N")
        {
            divExplain.Visible = true;
        }
        else
        {
            divExplain.Visible = false;
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    private void ShowHideView()
    {
        if (lblLogPosted.Text == "No")
        {
            viewExplain.Visible = true;
        }
        else
        {
            viewExplain.Visible = false;
        }
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnSave.Visible = false;
        btnBack.Visible = true;
        btnEdit.Visible = true;
        lblError.Visible = false;
        clsPM_Complaince_Reporting_OSHA objPM_Compliance_Reporting_OSHA = new clsPM_Complaince_Reporting_OSHA(PK_PM_Compliance_Reporting_OSHA);

        lblDateCompleted.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Compliance_Reporting_OSHA.Date_Completed);

        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Log_Posted_Feb_1))
            lblLogPosted.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Log_Posted_Feb_1) == "Y" ? "Yes" : "No";

        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.OSHA_Recordable.ToString()))
            lblNumberofOshaRecordableIncidents.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.OSHA_Recordable);
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Lost_Work_Days.ToString()))
            lblNumberofLostWorkDays.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Lost_Work_Days);
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Restsricted_Work_Days.ToString()))
            lblNumberofRestrictedWorkDays.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Restsricted_Work_Days);
        if (!string.IsNullOrEmpty(objPM_Compliance_Reporting_OSHA.Total_Associates.ToString()))
            lblTotalNumberofAssociates.Text = Convert.ToString(objPM_Compliance_Reporting_OSHA.Total_Associates);
        lblComments.Text = objPM_Compliance_Reporting_OSHA.Comments;
        lblExplainOsha.Text = objPM_Compliance_Reporting_OSHA.ExplainReason;
        ShowHideView();

    }
    #endregion

    #region Control Events

    /// <summary>
    /// Button Edit Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_Compliance_Reporting_OSHA > 0)
            Response.Redirect("PM_Compliance_Reporting_OSHA.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Compliance_Reporting_OSHA)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Complaince_Reporting)));
    }

    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsPM_Complaince_Reporting_OSHA objPM_Compliance_Reporting_OSHA = new clsPM_Complaince_Reporting_OSHA();
        objPM_Compliance_Reporting_OSHA.PK_PM_Compliance_Reporting_OSHA = PK_PM_Compliance_Reporting_OSHA;
        objPM_Compliance_Reporting_OSHA.Date_Completed = clsGeneral.FormatNullDateToStore(txtDateCompleted.Text);
        objPM_Compliance_Reporting_OSHA.FK_PM_Complaince_Reporting = FK_PM_Complaince_Reporting;
        if (!string.IsNullOrEmpty(rdoLogPosted.SelectedValue))
            objPM_Compliance_Reporting_OSHA.Log_Posted_Feb_1 = rdoLogPosted.SelectedValue;
        if(!string.IsNullOrEmpty(txtNumberofOsha.Text)) objPM_Compliance_Reporting_OSHA.OSHA_Recordable = Convert.ToInt32(txtNumberofOsha.Text);
        if (!string.IsNullOrEmpty(txtNumberofLostWorkDays.Text)) objPM_Compliance_Reporting_OSHA.Lost_Work_Days = Convert.ToInt32(txtNumberofLostWorkDays.Text);
        if (!string.IsNullOrEmpty(txtNumberofRestrictedWorkDays.Text)) objPM_Compliance_Reporting_OSHA.Restsricted_Work_Days = Convert.ToInt32(txtNumberofRestrictedWorkDays.Text);
        if (!string.IsNullOrEmpty(txtTotalNumberofAssociates.Text)) objPM_Compliance_Reporting_OSHA.Total_Associates = Convert.ToInt32(txtTotalNumberofAssociates.Text);
        objPM_Compliance_Reporting_OSHA.Comments = Convert.ToString(txtComments.Text);

        if (rdoLogPosted.SelectedValue == "N")
            objPM_Compliance_Reporting_OSHA.ExplainReason = Convert.ToString(txtExplainOsha.Text);
        else
            objPM_Compliance_Reporting_OSHA.ExplainReason = string.Empty;

        objPM_Compliance_Reporting_OSHA.Updated_By = clsSession.UserID;
        objPM_Compliance_Reporting_OSHA.Updated_Date = DateTime.Now;
        decimal _retval;
        if (PK_PM_Compliance_Reporting_OSHA > 0)
        {
            //_retval = objPM_Compliance_Reporting_OSHA.Update();
            objPM_Compliance_Reporting_OSHA.Update();
            //if (_retval == -2)
            //{
            //    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Utility Type and Sonic Location Code already exist in the Utility Provider table');ShowPanel(1);", true);
            //}
            //else
            //{
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Compliance_Reporting_OSHA);
            Attachment.FK_Field_Name = "FK_PM_Complaince_Reporting_OSHA";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments);
            Response.Redirect("PM_Compliance_Reporting_OSHA.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Compliance_Reporting_OSHA)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Complaince_Reporting)));
            //}
        }
        else
        {
            _retval = objPM_Compliance_Reporting_OSHA.Insert();
            if (_retval == -2)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The selected Utility Type and Sonic Location Code already exist in the Utility Provider table');ShowPanel(3);", true);
            }
            else
            {
                PK_PM_Compliance_Reporting_OSHA = _retval;
                Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Compliance_Reporting_OSHA);
                Attachment.FK_Field_Name = "FK_PM_Complaince_Reporting_OSHA";
                Attachment.Add(clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments);
                Response.Redirect("PM_Compliance_Reporting_OSHA.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Compliance_Reporting_OSHA)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Complaince_Reporting)));
            }
        }

    }
    /// <summary>
    /// Directs back to the parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Complaince_Reporting)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("3"));
        else
            Response.Redirect("Pollution.aspx?op=edit&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Complaince_Reporting)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("3"));
    }

    protected void rdoLogPosted_SelectedIndexChanged(object sender, EventArgs e)
    {
        ShowHideEdit();
    }

    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        if (StrOperation == "view")
        {
            AttachDetailsView.Bind();
        }
        else
        {
            AttachDetails.Bind();
        }
    }

    /// <summary>
    /// Upload File
    /// </summary>
    /// <param name="strValue"></param>
    void Upload_File(string strValue)
    {
        if (PK_PM_Compliance_Reporting_OSHA > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Compliance_Reporting_OSHA);
            Attachment.FK_Field_Name = "FK_PM_Complaince_Reporting_OSHA";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Compliance_Reporting_OSHA_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Osha details first');ShowPanel(1);", true);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreen(215).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date Completed": strCtrlsIDs += txtDateCompleted.ClientID + ","; strMessages += "Please select [Osha Log]/Date Completed" + ","; spnDateCompleted.Style["display"] = "inline-block"; break;
                case "Number of Osha Recordable Incidents": strCtrlsIDs += txtNumberofOsha.ClientID + ","; strMessages += "Please select [Osha Log]/Number of Osha Recordable Incidents" + ","; spnNumberofOsha.Style["display"] = "inline-block"; break;
                case "Number of Lost Work Days": strCtrlsIDs += txtNumberofLostWorkDays.ClientID + ","; strMessages += "Please select [Osha Log]/Number of Lost Work Days" + ","; spnNumberofLostWorkDays.Style["display"] = "inline-block"; break;
                case "Number of Restricted Work Days": strCtrlsIDs += txtNumberofRestrictedWorkDays.ClientID + ","; strMessages += "Please select [Osha Log]/Number of Restricted Work Days" + ","; spnNumberofRestrictedWorkDays.Style["display"] = "inline-block"; break;
                case "Total Number of Associates": strCtrlsIDs += txtTotalNumberofAssociates.ClientID + ","; strMessages += "Please select [Osha Log]/Total Number of Associates" + ","; spnTotalNumberofAssociates.Style["display"] = "inline-block"; break;
                case "Comments": strCtrlsIDs += txtComments.ClientID + ","; strMessages += "Please select [Osha Log]/Comments" + ","; spnComments.Style["display"] = "inline-block"; break;
                case "Log Posted By Feb 1st": strCtrlsIDs += rdoLogPosted.ClientID + ","; strMessages += "Please select [Osha Log]/Log Posted By Feb 1st" + ","; spnLogPosted.Style["display"] = "inline-block"; break;
                case "Explain why the OSHA Log was not posted by Feb 1st": strCtrlsIDs += txtExplainOsha.ClientID + ","; strMessages += "Please select [Osha Log]/Explain why the OSHA Log was not posted by Feb 1st" + ","; spnExplainReason.Style["display"] = "inline-block"; break;
            }
            #endregion
        }


        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion

}
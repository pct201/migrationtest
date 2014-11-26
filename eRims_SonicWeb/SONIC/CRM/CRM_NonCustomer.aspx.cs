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
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;

public partial class SONIC_CRM_CRM_NonCustomer : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_CRM_Non_Customer
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_CRM_Non_Customer"]);
        }
        set { ViewState["PK_CRM_Non_Customer"] = value; }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    /// <summary>
    /// Denotes the Email string
    /// </summary>
    public string VSStrEmail
    {
        get { return Convert.ToString(ViewState["VSStrEmail"]); }
        set { ViewState["VSStrEmail"] = value; }
    }
    /// <summary>
    /// Denotes the category
    /// </summary>
    public string VSStrCategory
    {
        get { return Convert.ToString(ViewState["VSStrCategory"]); }
        set { ViewState["VSStrCategory"] = value; }
    }
    #endregion

    #region Page Events
    /// <summary>
    /// Handles page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ucCRMTab.IsNonCustomer = true;
        ucCRMTab.SetSelectedTab(CRMTab.Tab.Customer);
        if (!Page.IsPostBack)
        {
            ((Button)Attachment.FindControl("btnAddAttachment")).OnClientClick = "javascript:return IfSave();";
            BindDropDown();
            PK_CRM_Non_Customer = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            hdnPanel.Value = clsGeneral.GetPanelId(Request.QueryString["pnl"]).ToString();
            StrOperation = Request.QueryString["op"];
            if (PK_CRM_Non_Customer > 0)
            {
                trCustomerInfo.Visible = true;
                ucCRMInfo.BindCRMDetails(PK_CRM_Non_Customer);
                if (StrOperation == "view")
                {
                    // Bind Controls in view mode
                    BindDetailsForView();
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    // Bind Controls in edit mode
                    BindDetailsForEdit();
                }
            }
            else
            {
                // Check User Rights
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                // Hide div for view mode
                dvView.Visible = false;
                btnEdit.Visible = btnLAAudit_View.Visible = false;
                BindNotesEdit();
                BindResolutionGrid();
                BindAttachmentDetails();
            }
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
            SetValidations();
        }
        else
        {
            string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
            string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
            if (eventTarget == "CalculateNumDaysClosed")
            {
                CalculateDaysClosed();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + eventArgument + ");", true);
                drpFK_LU_Location.Focus();
            }
        }
        clsGeneral.SetDropDownToolTip(new DropDownList[] { drpFK_LU_CRM_Source, drpFK_State, drpFK_LU_Location, drpFK_LU_CRM_Response_Method, drpFK_LU_CRM_Category });
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnSave.Visible = true;
        btnEdit.Visible = false;
        CRM_Non_Customer objCRM_Non_Customer = new CRM_Non_Customer(PK_CRM_Non_Customer);
        txtContactNumber.Text = Convert.ToString(objCRM_Non_Customer.PK_CRM_Non_Customer);
        txtRecord_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Non_Customer.Record_Date);
        if (objCRM_Non_Customer.FK_LU_CRM_Source != null) drpFK_LU_CRM_Source.SelectedValue = objCRM_Non_Customer.FK_LU_CRM_Source.ToString();
        if (objCRM_Non_Customer.FK_LU_Location != null) drpFK_LU_Location.SelectedValue = objCRM_Non_Customer.FK_LU_Location.ToString();
        txtCompany_Name.Text = objCRM_Non_Customer.Company_Name;
        txtLast_Name.Text = objCRM_Non_Customer.Last_Name;
        txtFirst_Name.Text = objCRM_Non_Customer.First_Name;
        txtCity.Text = objCRM_Non_Customer.City;
        if (objCRM_Non_Customer.FK_State != null) drpFK_State.SelectedValue = objCRM_Non_Customer.FK_State.ToString();
        txtZip_Code.Text = objCRM_Non_Customer.Zip_Code;
        txtEmail.Text = objCRM_Non_Customer.Email;
        txtHome_Telephone.Text = objCRM_Non_Customer.Home_Telephone;
        txtCell_Telephone.Text = objCRM_Non_Customer.Cell_Telephone;
        txtWork_Telephone.Text = objCRM_Non_Customer.Work_Telephone;
        txtWork_Telephone_Extension.Text = objCRM_Non_Customer.Work_Telephone_Extension;
        txtComment_Call_Inquiry_Summary.Text = objCRM_Non_Customer.Comment_Call_Inquiry_Summary;
        txtMedia_Call_Response_Summary.Text = objCRM_Non_Customer.Media_Call_Response_Summary;
        txtAction_Summary.Text = objCRM_Non_Customer.Action_Summary;
        if (objCRM_Non_Customer.FK_LU_CRM_Category != null)
        {
            drpFK_LU_CRM_Category.SelectedValue = objCRM_Non_Customer.FK_LU_CRM_Category.ToString();
            VSStrCategory = drpFK_LU_CRM_Category.SelectedItem.Text;
            hdnCheckCategory.Value = drpFK_LU_CRM_Category.SelectedItem.Text;
        }
        rdoResponse_Sent.SelectedValue = objCRM_Non_Customer.Response_Sent;
        if (objCRM_Non_Customer.FK_LU_CRM_Response_Method != null) drpFK_LU_CRM_Response_Method.SelectedValue = objCRM_Non_Customer.FK_LU_CRM_Response_Method.ToString();
        txtResponse_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Non_Customer.Response_Date);
        rdoResponse_NA.SelectedValue = objCRM_Non_Customer.Response_NA;
        txtDays_To_Close.Text = Convert.ToString(objCRM_Non_Customer.Days_To_Close);        
        VSStrEmail = txtEmail.Text;
        hdnCheckEmail.Value = txtEmail.Text;
        BindNotesEdit();
        BindResolutionGrid();
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.CRM_Non_Customer, (int)PK_CRM_Non_Customer, true, 4);
        AttachDetails.Bind();
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = true;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        CRM_Non_Customer objCRM_Non_Customer = new CRM_Non_Customer(PK_CRM_Non_Customer);
        lblContactNumber.Text = Convert.ToString(objCRM_Non_Customer.PK_CRM_Non_Customer);
        lblRecord_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Non_Customer.Record_Date);
        if (objCRM_Non_Customer.FK_LU_CRM_Source != null)
            lblFK_LU_CRM_Source.Text = new LU_CRM_Source((decimal)objCRM_Non_Customer.FK_LU_CRM_Source).Fld_Desc;
        if (objCRM_Non_Customer.FK_LU_Location != null)
            lblFK_LU_Location.Text = new LU_Location((decimal)objCRM_Non_Customer.FK_LU_Location).dba;
        lblCompany_Name.Text = objCRM_Non_Customer.Company_Name;
        lblLast_Name.Text = objCRM_Non_Customer.Last_Name;
        lblFirst_Name.Text = objCRM_Non_Customer.First_Name;
        lblCity.Text = objCRM_Non_Customer.City;
        if (objCRM_Non_Customer.FK_State != null)
            lblFK_State.Text = new State((decimal)objCRM_Non_Customer.FK_State).FLD_state;
        lblZip_Code.Text = objCRM_Non_Customer.Zip_Code;
        lblEmail.Text = objCRM_Non_Customer.Email;
        lblHome_Telephone.Text = objCRM_Non_Customer.Home_Telephone;
        lblCell_Telephone.Text = objCRM_Non_Customer.Cell_Telephone;
        lblWork_Telephone.Text = objCRM_Non_Customer.Work_Telephone;
        lblWork_Telephone_Extension.Text = objCRM_Non_Customer.Work_Telephone_Extension;
        lblComment_Call_Inquiry_Summary.Text = objCRM_Non_Customer.Comment_Call_Inquiry_Summary;
        lblMedia_Call_Response_Summary.Text = objCRM_Non_Customer.Media_Call_Response_Summary;
        lblAction_Summary.Text = objCRM_Non_Customer.Action_Summary;
        if (objCRM_Non_Customer.FK_LU_CRM_Category != null)
            lblFK_LU_CRM_Category.Text = new LU_CRM_Category((decimal)objCRM_Non_Customer.FK_LU_CRM_Category).Fld_Desc;
        lblResponse_Sent.Text = objCRM_Non_Customer.Response_Sent == "Y" ? "Yes" : "No";
        if (objCRM_Non_Customer.FK_LU_CRM_Response_Method != null)
            lblFK_LU_CRM_Response_Method.Text = new LU_CRM_Response_Method((decimal)objCRM_Non_Customer.FK_LU_CRM_Response_Method).Fld_Desc;
        lblResponse_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Non_Customer.Response_Date);
        lblResponse_NA.Text = objCRM_Non_Customer.Response_NA == "Y" ? "Yes" : "No";
        lblDays_To_Close.Text = Convert.ToString(objCRM_Non_Customer.Days_To_Close);
        //lblUpdated_By.Text = objCRM_Non_Customer.Updated_By;
        //lblUpdate_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCRM_Non_Customer.Update_Date);        
        BindGridView();
        AttachDetails.InitializeAttachmentDetails(clsGeneral.Tables.CRM_Non_Customer, (int)PK_CRM_Non_Customer, false, 4);
        AttachDetails.Bind();
    }

    /// <summary>
    /// Bind DropDown List
    /// </summary>
    private void BindDropDown()
    {
        //Source  
        ComboHelper.FillCRM_Source(new DropDownList[] { drpFK_LU_CRM_Source }, true);
        //used to fill dba Dropdown
        ComboHelper.FillLocationDBA_All(new DropDownList[] { drpFK_LU_Location }, 0, true);
        drpFK_LU_Location.Style.Remove("font-size");
        ComboHelper.FillState(new DropDownList[] { drpFK_State }, 0, true);
        ComboHelper.FillCRM_Category(new DropDownList[] { drpFK_LU_CRM_Category }, true);
        ComboHelper.FillCRM_Response_Method(new DropDownList[] { drpFK_LU_CRM_Response_Method }, true);
    }

    /// <summary>
    /// Notes Grid Bind Edit Mode
    /// </summary>
    private void BindNotesEdit()
    {
        //Notes Grid Bind
        if (PK_CRM_Non_Customer > 0)
        {
            DataSet dsResult = CRM_Notes.SelectByFK_CRM(PK_CRM_Non_Customer, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Notes));
            gvNotes.DataSource = dsResult.Tables[0];
            gvNotes.DataBind();
            gvNotes.Columns[gvNotes.Columns.Count - 1].Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
            if (dsResult.Tables[0].Rows.Count > 0)
            {
                divgvNotes.Style["overflow-y"] = "scroll";
                divgvNotes.Style["height"] = "200px";
            }
            else
            {
                divgvNotes.Style["overflow-y"] = "hidden";
                divgvNotes.Style["height"] = "40px";
            }
        }
        else
        {
            gvNotes.DataSource = null;
            gvNotes.DataBind();
        }
    }

    /// <summary>
    /// Resolution Grid Bind Edit Mode
    /// </summary>
    private void BindResolutionGrid()
    {
        if (PK_CRM_Non_Customer > 0)
        {
            //Resolution Grid Bind
            DataSet dsResolutin = CRM_Notes.SelectByFK_CRM(PK_CRM_Non_Customer, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Resolution));
            gvResolution.DataSource = dsResolutin.Tables[0];
            gvResolution.DataBind();
            gvResolution.Columns[gvResolution.Columns.Count - 1].Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
            if (dsResolutin.Tables[0].Rows.Count > 0)
            {
                divgvResolution.Style["overflow-y"] = "scroll";
                divgvResolution.Style["height"] = "200px";
            }
            else
            {
                divgvResolution.Style["overflow-y"] = "hidden";
                divgvResolution.Style["height"] = "40px";
            }
        }
        else
        {
            gvResolution.DataSource = null;
            gvResolution.DataBind();
        }
    }

    /// <summary>
    ///  Notes and Resolution Grid Bind View Mode
    /// </summary>
    private void BindGridView()
    {
        //Notes Grid Bind
        DataSet dsResult = CRM_Notes.SelectByFK_CRM(PK_CRM_Non_Customer, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Notes));
        gvNotesView.DataSource = dsResult.Tables[0];
        gvNotesView.DataBind();
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            divgvNotesView.Style["overflow-y"] = "scroll";
            divgvNotesView.Style["height"] = "200px";
        }
        else
        {
            divgvNotesView.Style["overflow-y"] = "hidden";
            divgvNotesView.Style["height"] = "40px";
        }

        //Resolution Grid bind
        DataSet dsResolution = CRM_Notes.SelectByFK_CRM(PK_CRM_Non_Customer, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Resolution));
        gvResolutionView.DataSource = dsResolution.Tables[0];
        gvResolutionView.DataBind();
        if (dsResolution.Tables[0].Rows.Count > 0)
        {
            divgvResolutionView.Style["overflow-y"] = "scroll";
            divgvResolutionView.Style["height"] = "200px";
        }
        else
        {
            divgvResolutionView.Style["overflow-y"] = "hidden";
            divgvResolutionView.Style["height"] = "40px";
        }
    }

    /// <summary>
    /// Save Data
    /// </summary>
    private void SaveValues()
    {
        CRM_Non_Customer objCRM_Non_Customer = new CRM_Non_Customer();
        objCRM_Non_Customer.PK_CRM_Non_Customer = PK_CRM_Non_Customer;
        objCRM_Non_Customer.Record_Date = clsGeneral.FormatNullDateToStore(txtRecord_Date.Text);
        if (drpFK_LU_CRM_Source.SelectedIndex > 0) objCRM_Non_Customer.FK_LU_CRM_Source = Convert.ToDecimal(drpFK_LU_CRM_Source.SelectedValue);
        if (drpFK_LU_Location.SelectedIndex > 0) objCRM_Non_Customer.FK_LU_Location = Convert.ToDecimal(drpFK_LU_Location.SelectedValue);
        objCRM_Non_Customer.Company_Name = txtCompany_Name.Text.Trim();
        objCRM_Non_Customer.Last_Name = txtLast_Name.Text.Trim();
        objCRM_Non_Customer.First_Name = txtFirst_Name.Text.Trim();
        objCRM_Non_Customer.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objCRM_Non_Customer.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objCRM_Non_Customer.Zip_Code = txtZip_Code.Text.Trim();
        objCRM_Non_Customer.Email = txtEmail.Text.Trim();
        objCRM_Non_Customer.Home_Telephone = txtHome_Telephone.Text.Trim();
        objCRM_Non_Customer.Cell_Telephone = txtCell_Telephone.Text.Trim();
        objCRM_Non_Customer.Work_Telephone = txtWork_Telephone.Text.Trim();
        objCRM_Non_Customer.Work_Telephone_Extension = txtWork_Telephone_Extension.Text.Trim();
        objCRM_Non_Customer.Comment_Call_Inquiry_Summary = txtComment_Call_Inquiry_Summary.Text.Trim();
        objCRM_Non_Customer.Media_Call_Response_Summary = txtMedia_Call_Response_Summary.Text.Trim();
        objCRM_Non_Customer.Action_Summary = txtAction_Summary.Text.Trim();
        if (drpFK_LU_CRM_Category.SelectedIndex > 0) objCRM_Non_Customer.FK_LU_CRM_Category = Convert.ToDecimal(drpFK_LU_CRM_Category.SelectedValue);
        objCRM_Non_Customer.Response_Sent = rdoResponse_Sent.SelectedValue;
        if (drpFK_LU_CRM_Response_Method.SelectedIndex > 0) objCRM_Non_Customer.FK_LU_CRM_Response_Method = Convert.ToDecimal(drpFK_LU_CRM_Response_Method.SelectedValue);
        objCRM_Non_Customer.Response_Date = clsGeneral.FormatNullDateToStore(txtResponse_Date.Text);
        objCRM_Non_Customer.Response_NA = rdoResponse_NA.SelectedValue;
        if (txtDays_To_Close.Text != "") objCRM_Non_Customer.Days_To_Close = clsGeneral.GetDecimalValue(txtDays_To_Close);
        objCRM_Non_Customer.Updated_By = clsSession.UserID;
        objCRM_Non_Customer.Update_Date = (DateTime.Now);
        if (PK_CRM_Non_Customer > 0)
        {
            objCRM_Non_Customer.Update();
            if (hdnSendMail.Value == "true")
            {
                SendMail();
                hdnSendMail.Value = "false";
            }
        }
        else
        {
            PK_CRM_Non_Customer = objCRM_Non_Customer.Insert();
            SendMail();
        }        
    }

    /// <summary>
    /// Calculate Days Closed
    /// </summary>
    private void CalculateDaysClosed()
    {
        txtDays_To_Close.Text = "";

        DateTime? dtStart = null;
        DateTime? dtEnd = null;

        DateTime dtTemp1, dtTemp2;
        if (DateTime.TryParse(txtRecord_Date.Text, out dtTemp1))
            dtStart = dtTemp1;
        if (DateTime.TryParse(txtResponse_Date.Text, out dtTemp2))
            dtEnd = dtTemp2;

        int cntDays = 0;
        if (dtStart.HasValue && dtEnd.HasValue)
        {
            if (dtStart < dtEnd)
            {
                int i = 0;
                DateTime dtTemp = Convert.ToDateTime(dtStart);
                while (dtTemp < dtEnd)
                {
                    dtTemp = Convert.ToDateTime(dtStart).AddDays(i);
                    if (Convert.ToDateTime(dtTemp).DayOfWeek != DayOfWeek.Sunday)
                        cntDays++;
                    i++;
                }
                txtDays_To_Close.Text = (cntDays).ToString();
            }
            else if (dtStart == dtEnd)
            {
                txtDays_To_Close.Text = "1";
                //DateTime dtTemp = Convert.ToDateTime(dtStart);
                //if (Convert.ToDateTime(dtTemp).DayOfWeek != DayOfWeek.Sunday)
                //    cntDays++;
                //if (cntDays == 0)
                //txtDays_To_Close.Text = "0";
                //else
                //    txtDays_To_Close.Text = (cntDays-1).ToString();
            }
        }
    }
    #endregion

    #region Control Events
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SaveValues();
            //Bind CRM_Non_Customer Information Bar Control
            ucCRMInfo.BindCRMDetails(PK_CRM_Non_Customer);
            //Page Control in View Mode
            StrOperation = "view";
            BindDetailsForView();
            Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        }
        catch (Exception ex)
        {
            if ((ex) is System.Threading.ThreadAbortException)
                return;
        }
    }

    /// <summary>
    /// Handle Add New Notes Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lbtAddNotes_Click(object sender, EventArgs e)
    {
        try
        {
            SaveValues();
            string str_PK_CRM_Non_Customer = Encryption.Encrypt(PK_CRM_Non_Customer.ToString());
            Response.Redirect("CRM_NonCustomer_Notes.aspx?pid=" + str_PK_CRM_Non_Customer + "&bmode=edit");

        }
        catch (Exception ex)
        {
            if ((ex) is System.Threading.ThreadAbortException)
                return;
        }
    }

    /// <summary>
    /// Handle Add New Resolution Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkResolution_Click(object sender, EventArgs e)
    {
        SaveValues();
        string str_PK_CRM_Non_Customer = Encryption.Encrypt(PK_CRM_Non_Customer.ToString());
        Response.Redirect("CRM_NonCustomer_Resolution_Notes.aspx?pid=" + str_PK_CRM_Non_Customer + "&bmode=edit");
    }
    
    /// <summary>
    /// Edit Button Click Event Page Control View Mode to Edit Mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        StrOperation = "edit";
        Response.Redirect("CRM_NonCustomer.aspx?id=" + Encryption.Encrypt(Convert.ToString(PK_CRM_Non_Customer)) + "&op=" + StrOperation, true);
    }
    #endregion

    #region Grid Event
    /// <summary>
    /// handle Notes row command event for remove
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            decimal PK_ID = Convert.ToDecimal(e.CommandArgument);
            // Delete CRM_Notes record
            CRM_Notes.DeleteByPK(PK_ID);
            // Rebind Grid after Delete record           
            BindNotesEdit();
            // Show Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
    }

    /// <summary>
    /// handle Resolution row command event for remove
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvResolution_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            decimal PK_ID = Convert.ToDecimal(e.CommandArgument);
            // Delete CRM_Notes record
            CRM_Notes.DeleteByPK(PK_ID);
            // Rebind Grid after Delete record           
            BindResolutionGrid();
            // Show Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
        }
    }
    #endregion

    #region Attachments Management
    /// <summary>
    /// Binds the attachment details
    /// </summary>
    private void BindAttachmentDetails()
    {
        dvAttachment.Style["display"] = "block";
        AttachDetails.Bind();
    }

    /// <summary>
    /// handles Add Attachment button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Attachment_btnHandler(object sender)
    {
        if (PK_CRM_Non_Customer > 0)
        {
            // add attachment if any.
            Attachment.Add(clsGeneral.Tables.CRM_Non_Customer, (int)PK_CRM_Non_Customer);
            // Bind the attachment detail to view the added attachment
            BindAttachmentDetails();
            // show attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(4);", true);
        }
        else
            ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript: alert('Please Save Non Customer Information First');ShowPanel(1);", true);
    }

    private void SendMail()
    {
        string StrCategoryType = "";
        ListItem lstCategory = drpFK_LU_CRM_Category.Items.FindByText(drpFK_LU_CRM_Category.SelectedItem.Text);
        if (lstCategory != null)
        {
            StrCategoryType = lstCategory.Text;
        }
        if (txtEmail.Text != "" && (StrCategoryType == "Resume Submission" || StrCategoryType == "Vendor"))
        {
            string strMailFrom = AppConfig.MailFrom;
            string StrMailTo = txtEmail.Text.Trim();
            string strSubject = "Sonic Automotive Response";
            string strHTML = "";
            StringBuilder sb = new StringBuilder();
            sb.Append("<table cellpadding=1 cellspacing=1 width='100%' style='color:#333333;font-family:Tahoma;font-size:10pt;'>");
            if (StrCategoryType == "Resume Submission")
            {
                sb.Append("<tr>");
                sb.Append("<td width='100%' align='left'>Thank you for your interest in employment with Sonic Automotive.  Your resume has been received and forwarded to Human Resources.  Questions related to employment should be directed to the HR staff at 704-566-2400.</td>");
                sb.Append("</tr>");
            }
            else if (StrCategoryType == "Vendor")
            {
                sb.Append("<tr>");
                sb.Append("<td width='100%' align='left'>Thank you for contacting Sonic Automotive.  We welcome interested businesses to complete an online vendor application at www.sonicvendor.com.  If you have additional questions related to purchasing, please contact Jeff King at 704-566-2400.</td>");
                sb.Append("</tr>");
            }
            sb.Append("<tr>");
            sb.Append("<td align='left'>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Regards,</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>&nbsp;</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Vicky Comer</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Customer Relations Manager</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Sonic Automotive, Inc.</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>6415 Idlewild Road, Ste. 109</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Charlotte, NC 28212</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Phone: (704) 927-3446</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>e-Fax: (919) 882-9718</td>");
            sb.Append("</tr>");
            sb.Append("<tr>");
            sb.Append("<td align='left'>Email: vicky.comer@sonicautomotive.com</td>");
            sb.Append("</tr>");
            sb.Append("</table>");
            strHTML = sb.ToString();
            clsGeneral.SendMailMessage(strMailFrom, StrMailTo, "", "", strSubject, strHTML, true);
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

        #region "Customer Information"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(127).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Source":
                    strCtrlsIDs += drpFK_LU_CRM_Source.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Source" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Date of Contact":
                    strCtrlsIDs += txtRecord_Date.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Date of Contact" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Company Name":
                    strCtrlsIDs += txtCompany_Name.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Company Name" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Location D/B/A":
                    strCtrlsIDs += drpFK_LU_Location.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Location D/B/A" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "Last Name":
                    strCtrlsIDs += txtLast_Name.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Last Name" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "First Name":
                    strCtrlsIDs += txtFirst_Name.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/First Name" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/City" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpFK_State.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/State" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Zip":
                    strCtrlsIDs += txtZip_Code.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Zip" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Email":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Email" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strCtrlsIDs += txtHome_Telephone.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Home Telephone" + ",";
                    Span11.Style["display"] = "inline-block";
                    break;
                case "Cell Telephone":
                    strCtrlsIDs += txtCell_Telephone.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Cell Telephone" + ",";
                    Span12.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strCtrlsIDs += txtWork_Telephone.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Work Telephone" + ",";
                    Span13.Style["display"] = "inline-block";
                    break;
                case "Work Telephone Extension":
                    strCtrlsIDs += txtWork_Telephone_Extension.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Work Telephone Extension" + ",";
                    Span14.Style["display"] = "inline-block";
                    break;
                case "Comment/Call/Inquiry Summary":
                    strCtrlsIDs += txtComment_Call_Inquiry_Summary.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Comment/Call/Inquiry Summary" + ",";
                    Span15.Style["display"] = "inline-block";
                    break;
                case "Media Call Response Summary":
                    strCtrlsIDs += txtMedia_Call_Response_Summary.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Media Call Response Summary" + ",";
                    Span16.Style["display"] = "inline-block";
                    break;
                case "Action Summary":
                    strCtrlsIDs += txtAction_Summary.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Action Summary" + ",";
                    Span17.Style["display"] = "inline-block";
                    break;
                case "Category ":
                    strCtrlsIDs += drpFK_LU_CRM_Category.ClientID + ",";
                    strMessages += "Please enter [Contact Information]/Category " + ",";
                    Span18.Style["display"] = "inline-block";
                    break;
            }
            #endregion
        }
        #endregion

        #region "Resolution"
        dtFields = clsScreen_Validators.SelectByScreen(129).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk3.Style["display"] = (dtFields.Select("LeftMenuIndex = 3").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Method of Response":
                    strCtrlsIDs += drpFK_LU_CRM_Response_Method.ClientID + ",";
                    strMessages += "Please select [Resolution]/Method of Response" + ",";
                    Span19.Style["display"] = "inline-block";
                    break;
                case "Date Response Sent":
                    strCtrlsIDs += txtResponse_Date.ClientID + ",";
                    strMessages += "Please enter [Resolution]/Date Response Sent" + ",";
                    Span20.Style["display"] = "inline-block";
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
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

public partial class SONIC_CRM_CRM_Customer_Complaint_Notes : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_CRM_Notes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_CRM_Notes"]);
        }
        set { ViewState["PK_CRM_Notes"] = value; }
    }
    /// <summary>
    /// Denotes the Foreign Key
    /// </summary>
    public decimal FK_Table_Name
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Table_Name"]);
        }
        set { ViewState["FK_Table_Name"] = value; }
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
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrNonCustomerOperation
    {
        get { return Convert.ToString(ViewState["StrCustomerOperation"]); }
        set { ViewState["StrCustomerOperation"] = value; }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrCustomerOperation
    {
        get { return Convert.ToString(ViewState["StrCustomerOperation"]); }
        set { ViewState["StrCustomerOperation"] = value; }
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
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            // Check if Parameter ID is passed or not
            FK_Table_Name = clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["pid"]));
            if (FK_Table_Name > 0)
            {
                ucCRMInfo.BindCRMDetails(FK_Table_Name);
                //Set Previous Customer Notes Page Operation
                StrCustomerOperation = Convert.ToString(Request.QueryString["bmode"]);
                // Check if Parameter ID is passed or not
                PK_CRM_Notes = clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"])); ;
                StrOperation = Convert.ToString(Request.QueryString["mode"]);
                BindNotesGridEdit();
                if (PK_CRM_Notes > 0)
                {
                    if (StrOperation == "view") //View Mode
                    {
                        // Bind Controls in View Mode
                        BindDetailsForView();
                        BindNotesGridView();
                    }
                    else
                    {
                        // Check User Rights
                        if (App_Access == AccessType.View_Only)
                            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                        StrOperation = "edit";
                        // Bind Controls in Edit Mode
                        BindDetailsForEdit();
                    }
                }
                else
                {
                    // Check User Rights
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    btnViewAuditTrial.Visible = false;
                    dvView.Style["display"] = "none";
                    txtNotesDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);                    
                    ((LinkButton)txtNotes.FindControl("btnExport")).Visible = false;
                }
            }
            else
                Response.Redirect("CRM_Customer.aspx", true);
            SetValidations();
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        //Set div and button show and hide
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        btnViewAuditTrial.Visible = true;
        // create object for CRM_Notes
        CRM_Notes objNotes = new CRM_Notes(PK_CRM_Notes);
        // set values in page controls
        txtNotesDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
        txtNotes.Text = objNotes.Note;
        
        ((LinkButton)txtNotes.FindControl("btnExport")).Visible = true;
        lblNotesHTML.Text = BindNotesData().ToString();
    }

    /// <summary>
    /// Bind Notes Data
    /// </summary>
    /// <returns></returns>
    private StringBuilder BindNotesData()
    {
        string strComNumber = ((Label)ucCRMInfo.FindControl("lblComplaintNumber")).Text;
        System.Text.StringBuilder sbRecorords = new System.Text.StringBuilder("");
        sbRecorords.Append("<style type='text/css'></style><table border='0' style='border: black 0.5px solid;border-collapse: collapse;' cellpadding='0' cellspacing='0'  Width='100%'><tr><td class='cols_' >");

        sbRecorords.Append("<table style='padding-left:4px;font-size:8.5pt;font-family:Tahoma' cellpadding='4' cellspacing='0' Width='100%'>");//Sub Table
        sbRecorords.Append("<tr style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:11pt;height:25'>"); //Title
        sbRecorords.Append("<td >&nbsp;</td>");
        sbRecorords.Append("<td align='center' style='font-size:9pt;' ><b>Customer Information Complaint Notes Grid </b></td>");
        sbRecorords.Append("<td style='font-size:9pt' align='right' >Date Run: " + DateTime.Now.ToString("MM/dd/yyyy") + "</td></tr>");

        sbRecorords.Append("<tr align='left'  style='font-weight: bold;background-color:#7f7f7f;color:White;font-size:8.5pt'>");
        sbRecorords.Append("<td class='cols_' width='20%'>Compliant Number</td>");
        sbRecorords.Append("<td class='cols_' width='20%'>Date of Note</td>");
        sbRecorords.Append("<td class='cols_' width='60%'>Description of Complaint</td>");
        sbRecorords.Append("</tr>");

        sbRecorords.Append("<tr align='left' style='font-size:8pt;background-color:#EAEAEA;font-family:Tahoma;'>");
        sbRecorords.Append("<td  class='cols_'>" + Convert.ToString(strComNumber) + "</td>");
        if (StrOperation == "view")
        {
            sbRecorords.Append("<td  class='cols_'>" + clsGeneral.FormatDBNullDateToDisplay(lblNotesDate.Text) + "</td>");
            sbRecorords.Append("<td  class='cols_'>" + Convert.ToString(lblNotes.Text) + "</td>");
        }
        else
        {
            sbRecorords.Append("<td  class='cols_'>" + clsGeneral.FormatDBNullDateToDisplay(txtNotesDate.Text) + "</td>");
            sbRecorords.Append("<td  class='cols_'>" + Convert.ToString(txtNotes.Text) + "</td>");
        }
        sbRecorords.Append("</tr>");
        sbRecorords.Append("</table>");

        sbRecorords.Append("</td>");
        sbRecorords.Append("</tr>");
        sbRecorords.Append("</table>");
        return sbRecorords;
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        //Set div and button show and hide
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = (App_Access != AccessType.View_Only);
        btnSave.Visible = false;

        // create object for CRM_Notes
        CRM_Notes objNotes = new CRM_Notes(PK_CRM_Notes);
        // set values in page controls
        lblNotesDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
        lblNotes.Text = objNotes.Note;
        lblNotesHTML.Text = BindNotesData().ToString();
    }

    /// <summary>
    /// Binds Notes Grid for Edit mode
    /// </summary>
    private void BindNotesGridEdit()
    {

        DataSet dsResult = CRM_Notes.SelectByFK_CRM(FK_Table_Name, clsGeneral.CRM_Tables.CRM_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Customer_Complaint));
        gvNotes.DataSource = dsResult.Tables[0];
        gvNotes.DataBind();
        gvNotes.Columns[gvNotes.Columns.Count - 1].Visible = !(App_Access == AccessType.View_Only || App_Access == AccessType.CRM_Add);
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            divgvComplaint.Style["overflow-y"] = "scroll";
            divgvComplaint.Style["height"] = "200px";
        }
        else
        {
            divgvComplaint.Style["overflow-y"] = "hidden";
            divgvComplaint.Style["height"] = "50px";
        }
    }

    /// <summary>
    /// Binds Note Grid for View mode
    /// </summary>
    private void BindNotesGridView()
    {

        DataSet dsResult = CRM_Notes.SelectByFK_CRM(FK_Table_Name, clsGeneral.CRM_Tables.CRM_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Customer_Complaint));
        gvNotesView.DataSource = dsResult.Tables[0];
        gvNotesView.DataBind();
        if (dsResult.Tables[0].Rows.Count > 0)
        {
            divgvComplaintView.Style["overflow-y"] = "scroll";
            divgvComplaintView.Style["height"] = "200px";
        }
        else
        {
            divgvComplaintView.Style["overflow-y"] = "hidden";
            divgvComplaintView.Style["height"] = "50px";
        }
    }

    /// <summary>
    /// Save Data
    /// </summary>
    private void SaveData()
    {
        // create object for CRM_Notes
        CRM_Notes objNotes = new CRM_Notes();
        // get objCRM_Notes details from page controls
        objNotes.FK_Table_Name = FK_Table_Name;
        objNotes.Table_Name = Convert.ToString(clsGeneral.CRM_Tables.CRM_Customer);
        objNotes.FK_LU_CRM_Note_Type = Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Customer_Complaint);
        objNotes.Note_Date = clsGeneral.FormatNullDateToStore(txtNotesDate.Text);
        objNotes.Note = txtNotes.Text.Trim();
        objNotes.Updated_By = clsSession.UserName;
        objNotes.Update_Date = DateTime.Now;
        // Check if PK is Greater than 0 then Update record else insert new records.
        if (PK_CRM_Notes > 0)
        {
            objNotes.PK_CRM_Notes = PK_CRM_Notes;
            objNotes.Update();
        }
        else
        {
            PK_CRM_Notes = objNotes.Insert();
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
        SaveData();
        BindDetailsForEdit();
        BindNotesGridEdit();
        //Show current Panel in Save Record
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:ShowPanel(" + hdnPanel.Value + ");", true);
        txtNotes.Text = "";
        txtNotesDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
        PK_CRM_Notes = 0;   
        ((LinkButton)txtNotes.FindControl("btnExport")).Visible = false;
    }

    /// <summary>
    /// Handles RevertReturn Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRM_Customer.aspx?id=" + Encryption.Encrypt(Convert.ToString(FK_Table_Name)) + "&op=" + StrCustomerOperation + "&pnl=4");
    }

    /// <summary>
    /// Handles Edit Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        StrOperation = "edit";
        Response.Redirect("CRM_Customer_Complaint_Notes.aspx?pid=" + Encryption.Encrypt(Convert.ToString(FK_Table_Name)) + "&id=" + Encryption.Encrypt(Convert.ToString(PK_CRM_Notes)) + "&mode=" + StrOperation, true);
    }   
    
    /// <summary>
    /// Handles Export to Excel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    protected void ExportToExcel_btnHandler(object sender)
    {
        // Export the data into excel spreadsheet       
        string strcols = "border: black 1px solid;vertical-align: top;font-size: 8pt;border-collapse: collapse;";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new System.Web.UI.HtmlTextWriter(stringWrite);

        //PrepareControlForExport(gvReportGrid.HeaderRow);
        lblNotesHTML.RenderControl(htmlWrite);
        // gvReportGrid.RenderControl(htmlWrite);

        MemoryStream memorystream = new MemoryStream();
        byte[] _bytes = Encoding.UTF8.GetBytes(stringWrite.ToString().Replace("border-top:#EAEAEA", "border-top:#000000").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>"));
        memorystream.Write(_bytes, 0, _bytes.Length);
        memorystream.Seek(0, SeekOrigin.Begin);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", "CRM_Customer_FieldNotes.xls"));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        HttpContext.Current.Response.Write(stringWrite.ToString().Replace("#EAEAEA", "White").Replace("#eaeaea", "White").Replace("background-color:#C0C0C0", "background-color:White;").Replace("<style type='text/css'></style>", "<style type='text/css'> .cols_{" + strcols + " }</style>").Replace("background-color:#7f7f7f;color:White", "background-color:White;color:Black"));
        HttpContext.Current.Response.End();
    }

    /// <summary>
    /// Handles Next Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (txtNotesDate.Text.Trim() != "" && txtNotes.Text.Trim() != "")
        {
            SaveData();
        }
        Response.Redirect("CRM_Customer.aspx?id=" + Encryption.Encrypt(Convert.ToString(FK_Table_Name)) + "&op=" + StrCustomerOperation + "&pnl=5");
    }
    #endregion

    #region "Grid Event"
    /// <summary>
    /// handle Notes row command event for remove
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Remove")
        {
            decimal PK_Policy_Notes = Convert.ToDecimal(e.CommandArgument);
            // Delete CRM_Notes record
            CRM_Notes.DeleteByPK(PK_Policy_Notes);
            // Rebind Grid after Delete record
            gvNotes.DataSource = CRM_Notes.SelectByFK_CRM(FK_Table_Name, clsGeneral.CRM_Tables.CRM_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Customer_Complaint));
            gvNotes.DataBind();
            // Show Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            txtNotes.Text = "";
            txtNotesDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
            PK_CRM_Notes = 0;         
            ((LinkButton)txtNotes.FindControl("btnExport")).Visible = false;
        }
        if (e.CommandName == "Edit")
        {
            PK_CRM_Notes = Convert.ToDecimal(e.CommandArgument);
            BindDetailsForEdit();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }

    /// <summary>
    /// Handles RowEditing Event of Notes Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotes_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Handles RowEditing Event of NotesView Grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotesView_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Notes Grid Row command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvNotesView_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "View")
        {
            PK_CRM_Notes = Convert.ToDecimal(e.CommandArgument);
            BindDetailsForView();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
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

        #region "Incident Grid"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(123).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 4").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Note":
                    strCtrlsIDs += txtNotesDate.ClientID + ",";
                    strMessages += "Please enter Date of Note" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Description of Incident":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter Description of Incident" + ",";
                    Span2.Style["display"] = "inline-block";
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
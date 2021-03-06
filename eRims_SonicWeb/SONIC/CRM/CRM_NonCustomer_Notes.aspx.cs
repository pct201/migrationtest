﻿using System;
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

public partial class SONIC_CRM_CRM_NonCustomer_Notes : clsBasePage
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
    /// Handles Page Load Event
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
                }
            }
            else
                Response.Redirect("CRM_NonCustomer.aspx", true);
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

    }

    /// <summary>
    /// Binds Notes Grid for Edit mode
    /// </summary>
    private void BindNotesGridEdit()
    {

        DataSet dsResult = CRM_Notes.SelectByFK_CRM(FK_Table_Name, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Notes)); 
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
            divgvNotes.Style["height"] = "50px";
        } 
    }
    /// <summary>
    /// Binds Note Grid for View mode
    /// </summary>
    private void BindNotesGridView()
    {

        DataSet dsResult = CRM_Notes.SelectByFK_CRM(FK_Table_Name, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Notes));
        gvNotesView.DataSource = dsResult.Tables[0];
        gvNotesView.DataBind();
         if (dsResult.Tables[0].Rows.Count > 0)
        {
            divgvFieldNotesView.Style["overflow-y"] = "scroll";
            divgvFieldNotesView.Style["height"] = "200px";
        }
        else
        {
            divgvFieldNotesView.Style["overflow-y"] = "hidden";
            divgvFieldNotesView.Style["height"] = "50px";
        } 
    }

    private void SaveData()
    {
        // create object for CRM_Notes
        CRM_Notes objNotes = new CRM_Notes();
        // get objCRM_Notes details from page controls
        objNotes.FK_Table_Name = FK_Table_Name;
        objNotes.Table_Name = Convert.ToString(clsGeneral.CRM_Tables.CRM_Non_Customer);
        objNotes.FK_LU_CRM_Note_Type = Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Notes);
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
    }
    /// <summary>
    /// Handles RevertReturn Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("CRM_NonCustomer.aspx?id=" + Encryption.Encrypt(Convert.ToString(FK_Table_Name)) + "&op=" + StrCustomerOperation + "&pnl=2");
    }

    /// <summary>
    /// Handles Edit Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        StrOperation = "edit";
        Response.Redirect("CRM_NonCustomer_Notes.aspx?pid=" + Encryption.Encrypt(Convert.ToString(FK_Table_Name)) + "&id=" + Encryption.Encrypt(Convert.ToString(PK_CRM_Notes)) + "&mode=" + StrOperation, true);
    }

    protected void btnNext_Click(object sender, EventArgs e)
    {
        if (StrOperation != "view")
        {
            if (txtNotes.Text.Trim() != string.Empty && txtNotesDate.Text.Trim() != string.Empty)
            {
                SaveData();
            }
        }
        Response.Redirect("CRM_NonCustomer.aspx?id=" + Encryption.Encrypt(Convert.ToString(FK_Table_Name)) + "&op=" + StrCustomerOperation + "&pnl=3");
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
            gvNotes.DataSource = CRM_Notes.SelectByFK_CRM(FK_Table_Name, clsGeneral.CRM_Tables.CRM_Non_Customer, Convert.ToDecimal(clsGeneral.CRM_Note_Type.CRM_Notes));
            gvNotes.DataBind();

            // Show Panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            txtNotes.Text = "";
            txtNotesDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
            PK_CRM_Notes = 0;
        }

        if (e.CommandName == "EditDetails")
        {
            PK_CRM_Notes = Convert.ToDecimal(e.CommandArgument);
            BindDetailsForEdit();
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

        }
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

        #region "Notes"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(128).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 2").Length > 0) ? "inline-block" : "none";

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
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please enter Notes" + ",";
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
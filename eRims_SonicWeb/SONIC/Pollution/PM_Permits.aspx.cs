using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Drawing;

public partial class SONIC_Pollution_PM_Permits : clsBasePage
{
    #region Properties

    /// <summary>
    /// Denotes foriegn key for site information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]);
        }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_Permits
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_Permits"]);
        }
        set { ViewState["PK_PM_Permits"] = value; hiddenPKPermit.Value = value.ToString(); }
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
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    /// <summary>
    /// Denotes primary key for Permits VOC Emissions record
    /// </summary>
    public decimal PK_PM_Permits_VOC_Emissions
    {
        get { return Convert.ToDecimal(ViewState["PK_PM_Permits_VOC_Emissions"]); }
        set { ViewState["PK_PM_Permits_VOC_Emissions"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for VOC Category record
    /// </summary>
    public decimal FK_LU_VOC_Category
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_VOC_Category"]); }
        set { ViewState["FK_LU_VOC_Category"] = value; }
    }
    /// <summary>
    /// Denotes foriegn key for Permit record
    /// </summary>
    public decimal FK_PM_Permits
    {
        get { return Convert.ToDecimal(ViewState["FK_PM_Permits"]); }
        set { ViewState["FK_PM_Permits"] = value; }
    }
    /// <summary>
    /// Denotes Current Month
    /// </summary>
    public int CurrentMonth
    {
        get { return Convert.ToInt16(ViewState["CurrentMonth"]); }
        set { ViewState["CurrentMonth"] = value; }
    }
    /// <summary>
    /// Denotes Current Year
    /// </summary>
    public int CurrentYear
    {
        get { return Convert.ToInt16(ViewState["CurrentYear"]); }
        set { ViewState["CurrentYear"] = value; }
    }
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int IsFromTable
    {
        get
        {
            return clsGeneral.GetInt(ViewState["IsFromTable"]);
        }
        set { ViewState["IsFromTable"] = value; }
    }

    #endregion

    #region Page Events

    /// <summary>
    /// Handles Page Load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        Attachment.btnHandler += new Attachment_Pollution.OnButtonClick(Upload_File);
        if (!Page.IsPostBack)
        {
            //if (App_Access != AccessType.Administrative_Access && App_Access != AccessType.VOC_Import)
            //    lnkImport.Visible = false;
            //else
            //    lnkImport.Visible = true;

            DateTime date = DateTime.Now;
            CurrentYear = date.Year;
            CurrentMonth = date.Month;
            PK_PM_Permits = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);

            if (PK_PM_Permits == 0)
            {
                pnlVOCView.Visible = false;
                lnkPreviousYear.Visible = false;
                lnkNextYear.Visible = false;
                lnkNextMonth.Visible = false;
                lnkPreviousMonth.Visible = false;
                lnkCancel.Visible = false;
                lbl.Visible = false;
                pnlVOCEdit.Visible = false;
                BindVOCGrid();
            }

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            if (PK_PM_Permits > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["op"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForView();
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    // set attachment details control in readonly mode.
                    AttachDetailsView.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Permits_Attachments, Convert.ToInt32(PK_PM_Permits), "FK_PM_Permits", "PK_PM_Permits_Attachments", false, 2);
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    // Bind Controls
                    BindDropdowns();
                    BindDetailsForEdit();
                    // set attachment details control in read/write mode. so user can add or remove attachment as well.
                    AttachDetails.InitializeAttachmentDetails(clsGeneral.Pollution_Tables.PM_Permits_Attachments, Convert.ToInt32(PK_PM_Permits), "FK_PM_Permits", "PK_PM_Permits_Attachments", true, 2);
                }
                pnlVOCEdit.Visible = false;
                pnlVOCView.Visible = false;
                BindVOCGrid();
                // bind attachment details to show attachment for current risk profile.
                BindAttachmentDetails();
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                SetValidations();
                // disable Add Attachment button                
                btnEdit.Visible = false;
                BindDropdowns();
                BindAttachmentDetails();
                // don't show div for view mode
                dvView.Style["display"] = "none";
                btnAuditTrail.Visible = false;
                if (FK_PM_Site_Information > 0)
                    btnBack.Visible = true;
                else
                    btnBack.Visible = false;
            }
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Binds all dropdowns
    /// </summary>
    private void BindDropdowns()
    {
        ComboHelper.FillPermitType(new DropDownList[] { drpFK_Permit_Type }, true);
        ComboHelper.BindMonth(ddlMonth);
        ddlMonth.Items.Insert(0, new ListItem("-- Select --", "0"));
        ComboHelper.FillPaintCategory(new DropDownList[] { drpPaintCategory }, true);
        ComboHelper.FillYear(new DropDownList[] { ddlYear }, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        PM_Permits objPM_Permits = new PM_Permits(PK_PM_Permits);
        if (objPM_Permits.FK_Permit_Type != null)
        {
            ListItem lst = drpFK_Permit_Type.Items.FindByValue(objPM_Permits.FK_Permit_Type.ToString());
            if (lst != null)
                lst.Selected = true;
            //drpFK_Permit_Type.SelectedValue = objPM_Permits.FK_Permit_Type.ToString();
        }

        if (drpFK_Permit_Type.SelectedIndex > 0 && drpFK_Permit_Type.SelectedItem.Text.ToUpper() == "AIR PERMIT")
        {
            dvVOCGrid.Visible = true;
        }

        rdoPermit_Required.SelectedValue = objPM_Permits.Permit_Required;
        txtCertification_Number.Text = objPM_Permits.Certification_Number;
        txtApplication_Regulation_Number.Text = objPM_Permits.Application_Regulation_Number;
        txtPermit_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_Start_Date);
        txtPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_End_Date);
        txtLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Last_Inspection_Date);
        txtNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Inspection_Date);
        txtNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Report_Date);
        txtNotes.Text = objPM_Permits.Notes;
        txtRecommendations.Text = objPM_Permits.Recommendations;
        if (objPM_Permits.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Permits.FK_PM_Site_Information);
        rdoApply_To_Location.SelectedValue = objPM_Permits.Application_Regulation_Number;
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        PM_Permits objPM_Permits = new PM_Permits(PK_PM_Permits);
        if (objPM_Permits.FK_Permit_Type != null)
            lblFK_Permit_Type.Text = new clsLU_Permit_Type((decimal)objPM_Permits.FK_Permit_Type).Fld_Desc;

        if (!string.IsNullOrEmpty(lblFK_Permit_Type.Text) && lblFK_Permit_Type.Text.ToUpper() == "AIR PERMIT")
        {
            dvVOCGrid.Visible = true;
        }

        lblPermit_Required.Text = objPM_Permits.Permit_Required == "Y" ? "Yes" : "No";
        lblCertification_Number.Text = objPM_Permits.Certification_Number;
        lblApplication_Regulation_Number.Text = objPM_Permits.Application_Regulation_Number;
        lblPermit_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_Start_Date);
        lblPermit_End_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Permit_End_Date);
        lblLast_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Last_Inspection_Date);
        lblNext_Inspection_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Inspection_Date);
        lblNext_Report_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_Permits.Next_Report_Date);
        lblNotes.Text = objPM_Permits.Notes;
        lblRecommendations.Text = objPM_Permits.Recommendations;
        if (objPM_Permits.FK_PM_Site_Information != null) FK_PM_Site_Information = Convert.ToDecimal(objPM_Permits.FK_PM_Site_Information);
        if (FK_PM_Site_Information > 0)
            btnBack.Visible = true;
        else
            btnBack.Visible = false;
        lblApply_To_Location.Text = objPM_Permits.Apply_To_Location == "Y" ? "Yes" : "No";
    }

    /// <summary>
    /// Bind VOC Grid
    /// </summary>
    public void BindVOCGrid()
    {
        DataSet dsVOCEmmission = clsPM_Permits_VOC_Emissions.SelectByFKPermit(PK_PM_Permits, CurrentMonth, CurrentYear);
        DataTable dtVOCEmission = dsVOCEmmission.Tables[0];
        DataTable dtCategoryGrandTotal = dsVOCEmmission.Tables[1];
        DataTable dtGrandTotal = dsVOCEmmission.Tables[2];
        DataTable dtVOC = dtVOCEmission.Clone();
        DataTable dtCategory = clsLU_VOC_Category.SelectAll().Tables[0];

        if (dtCategory != null && dtCategory.Rows.Count > 0)
        {
            foreach (DataRow drCategory in dtCategory.Rows)
            {
                string category = Convert.ToString(drCategory["Category"]);
                DataRow[] drVOCEmissions = dtVOCEmission.Select("Category = '" + category + "'");
                decimal totalGallons = 0, totalVOC_Emissions = 0;
                string SubTotalText = string.Empty;

                if (drVOCEmissions != null && drVOCEmissions.Length > 0)
                {
                    foreach (DataRow drVOCEmission in drVOCEmissions)
                    {
                        totalGallons += clsGeneral.GetDecimal(drVOCEmission["Gallons"]);
                        totalVOC_Emissions += clsGeneral.GetDecimal(drVOCEmission["VOC_Emissions"]);
                        SubTotalText = Convert.ToString(drVOCEmission["Subtotal_Text"]);
                        dtVOC.Rows.Add(drVOCEmission.ItemArray);
                    }

                    // dtVOC.Rows.Add("0", "0", category + " Sub Total", CurrentYear, GetMonthString(CurrentMonth), totalGallons, totalVOC_Emissions, SubTotalText, totalGallons + totalVOC_Emissions, 0);
                    dtVOC.Rows.Add("0", "0", category + " Sub Total", CurrentYear, GetMonthString(CurrentMonth), totalGallons, totalVOC_Emissions, SubTotalText, "", 0);

                    if (dtCategoryGrandTotal != null && dtCategoryGrandTotal.Rows.Count > 0)
                    {
                        DataRow[] drCategoryGrandTotal = dtCategoryGrandTotal.Select("Category = '" + category + "'");
                        dtVOC.Rows.Add("0", "0", category + " Grand Total", CurrentYear, "", clsGeneral.GetDecimal(drCategoryGrandTotal[0]["Gallons"]), clsGeneral.GetDecimal(drCategoryGrandTotal[0]["VOC_Emmisions"]), "", "", 0);
                    }
                }
            }

            if (dtVOCEmission != null && dtVOCEmission.Rows.Count > 0)
            {
                dtVOC.Rows.Add("0", "0", " Grand Total", CurrentYear, "", clsGeneral.GetDecimal(dtGrandTotal.Rows[0]["Gallons"]), clsGeneral.GetDecimal(dtGrandTotal.Rows[0]["VOC_Emmisions"]), "", "", 0);
            }
        }

        gvVOCEmission.DataSource = dtVOC;

        if (dtVOCEmission == null || dtVOCEmission.Rows.Count <= 0)
            //Assign text when no record found
            gvVOCEmission.EmptyDataText = "No Other VOC Records Found for Month&nbsp;" + GetMonthString(CurrentMonth) + " and Year " + CurrentYear;

        gvVOCEmission.DataBind();

        if (StrOperation == "view")
        {
            lnkAddNew.Visible = false;
            lnkImport.Visible = false;
        }
        else
        {
            lnkAddNew.Visible = true;
            lnkImport.Visible = true;
        }
    }

    /// <summary>
    /// Bind VOC Details for Edit and View mode
    /// </summary>
    private void BindVOCDetails()
    {
        clsPM_Permits_VOC_Emissions objPM_Permits_VOC_Emissions = new clsPM_Permits_VOC_Emissions(PK_PM_Permits_VOC_Emissions);

        if (StrOperation == "view")
        {
            pnlVOCView.Visible = true;
            lblItemNumber.Text = objPM_Permits_VOC_Emissions.Part_Number;
            lblGallon.Text = objPM_Permits_VOC_Emissions.Gallons.ToString();
            lblQuantity.Text = objPM_Permits_VOC_Emissions.Quantity;
            lblUnit.Text = objPM_Permits_VOC_Emissions.Unit;
            lblVOCEmissions.Text = objPM_Permits_VOC_Emissions.VOC_Emissions.ToString();
            lblMonth.Text = GetMonthString(Convert.ToInt32(objPM_Permits_VOC_Emissions.Month));
            lblYear.Text = objPM_Permits_VOC_Emissions.Year.ToString();
            lblPaintCategory.Text = new clsLU_VOC_Category((decimal)objPM_Permits_VOC_Emissions.FK_LU_VOC_Category).Category;
        }
        else if (StrOperation == "edit")
        {
            pnlVOCEdit.Visible = true;
            txtItemNumber.Text = objPM_Permits_VOC_Emissions.Part_Number;
            txtGallons.Text = objPM_Permits_VOC_Emissions.Gallons.ToString();
            txtQuantity.Text = objPM_Permits_VOC_Emissions.Quantity;
            txtUnit.Text = objPM_Permits_VOC_Emissions.Unit;
            txtVOCEmissions.Text = objPM_Permits_VOC_Emissions.VOC_Emissions.ToString();
            drpPaintCategory.SelectedValue = objPM_Permits_VOC_Emissions.FK_LU_VOC_Category.ToString();
            ddlMonth.SelectedValue = objPM_Permits_VOC_Emissions.Month.ToString();
            ddlYear.SelectedValue = objPM_Permits_VOC_Emissions.Year.ToString();
        }
    }

    /// <summary>
    /// Returns Month Name from number
    /// </summary>
    /// <param name="Month"></param>
    /// <returns></returns>
    private string GetMonthString(Int32 Month)
    {
        string strMonthName = string.Empty;
        switch (Month)
        {
            case 1:
                strMonthName = "January";
                break;
            case 2:
                strMonthName = "February";
                break;
            case 3:
                strMonthName = "March";
                break;
            case 4:
                strMonthName = "April";
                break;
            case 5:
                strMonthName = "May";
                break;
            case 6:
                strMonthName = "June";
                break;
            case 7:
                strMonthName = "July";
                break;
            case 8:
                strMonthName = "August";
                break;
            case 9:
                strMonthName = "September";
                break;
            case 10:
                strMonthName = "October";
                break;
            case 11:
                strMonthName = "November";
                break;
            case 12:
                strMonthName = "December";
                break;
        }
        return strMonthName;
    }

    /// <summary>
    /// Calculate the SubTotal 
    /// </summary>
    /// <param name="dtVOC"></param>
    /// <returns></returns>
    public decimal GetSubTotal(DataTable dtVOC)
    {
        decimal subtotalCalculate = 0;
        foreach (DataRow drField in dtVOC.Rows)
        {
            if (drField["Quantity"] != null)
            {
                subtotalCalculate += clsGeneral.GetDecimal(drField["Quantity"]) * clsGeneral.GetDecimal(drField["Gallons"]);
            }
        }

        return subtotalCalculate;
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
        PM_Permits objPM_Permits = new PM_Permits();
        objPM_Permits.PK_PM_Permits = PK_PM_Permits;
        if (drpFK_Permit_Type.SelectedIndex > 0) objPM_Permits.FK_Permit_Type = Convert.ToDecimal(drpFK_Permit_Type.SelectedValue);
        objPM_Permits.Permit_Required = rdoPermit_Required.SelectedValue;
        objPM_Permits.Certification_Number = txtCertification_Number.Text.Trim();
        objPM_Permits.Application_Regulation_Number = txtApplication_Regulation_Number.Text.Trim();
        objPM_Permits.Permit_Start_Date = clsGeneral.FormatNullDateToStore(txtPermit_Start_Date.Text);
        objPM_Permits.Permit_End_Date = clsGeneral.FormatNullDateToStore(txtPermit_End_Date.Text);
        objPM_Permits.Last_Inspection_Date = clsGeneral.FormatNullDateToStore(txtLast_Inspection_Date.Text);
        objPM_Permits.Next_Inspection_Date = clsGeneral.FormatNullDateToStore(txtNext_Inspection_Date.Text);
        objPM_Permits.Next_Report_Date = clsGeneral.FormatNullDateToStore(txtNext_Report_Date.Text);
        objPM_Permits.Notes = txtNotes.Text.Trim();
        objPM_Permits.Recommendations = txtRecommendations.Text.Trim();
        objPM_Permits.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_Permits.Update_Date = DateTime.Now;
        objPM_Permits.Updated_By = clsSession.UserID;
        objPM_Permits.Apply_To_Location = rdoApply_To_Location.SelectedValue;

        decimal _retVal;
        if (PK_PM_Permits > 0)
            _retVal = objPM_Permits.Update();
        else
            _retVal = PK_PM_Permits = objPM_Permits.Insert();

        if (_retVal == -2)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('The Permits that you are trying to add already exists.');ShowPanel(1);", true);
            return;
        }

        // add the attachment 
        Attachment.FK_Field_Value = Convert.ToInt32(_retVal.ToString());
        Attachment.FK_Field_Name = "FK_PM_Permits";
        Attachment.Add(clsGeneral.Pollution_Tables.PM_Permits_Attachments);
        Response.Redirect("PM_Permits.aspx?id=" + Encryption.Encrypt(_retVal.ToString()) + "&op=view" + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }

    /// <summary>
    /// Handles Edit button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("PM_Permits.aspx?id=" + Encryption.Encrypt(PK_PM_Permits.ToString()) + "&op=edit" + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }

    /// <summary>
    /// Handles Back button click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("2"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("2"));
    }

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAdd_Click(object sender, EventArgs e)
    {
        if (PK_PM_Permits == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Save Permit Details First');", true);
            pnlVOCEdit.Visible = false;
        }
        else
        {
            PK_PM_Permits_VOC_Emissions = 0;

            foreach (Control ctrl in pnlVOCEdit.Controls)
            {
                if (ctrl.GetType() == typeof(TextBox))
                {
                    ((TextBox)ctrl).Text = "";
                }
            }

            ddlMonth.SelectedIndex = 0;
            ddlYear.SelectedIndex = 0;
            drpPaintCategory.SelectedIndex = 0;
            pnlVOCEdit.Visible = true;
        }
    }

    /// <summary>
    /// Handles VOC Emission grid rowcommand event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVOCEmission_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        // if passed command is for viewing detail then get PK from passed argument and bind VOC details
        if (e.CommandName == "ViewVOCDetail")
        {
            PK_PM_Permits_VOC_Emissions = Convert.ToInt32(e.CommandArgument);
            BindVOCDetails();
        }
        else if (e.CommandName == "Remove")
        {
            PK_PM_Permits_VOC_Emissions = Convert.ToInt32(e.CommandArgument);
            clsPM_Permits_VOC_Emissions objPM_Permits_VOC_Emissions = new clsPM_Permits_VOC_Emissions(PK_PM_Permits_VOC_Emissions);
            objPM_Permits_VOC_Emissions.FK_PM_Permits = PK_PM_Permits;
            //objPM_Permits_VOC_Emissions.PK_PM_Permits_VOC_Emissions = PK_PM_Permits_VOC_Emissions;
            objPM_Permits_VOC_Emissions.Update_Date = DateTime.Now;
            objPM_Permits_VOC_Emissions.Updated_By = clsSession.UserID;
            DataTable dtVOC = objPM_Permits_VOC_Emissions.SelectByFK(PK_PM_Permits).Tables[0];

            if (dtVOC != null && dtVOC.Rows.Count > 0)
            {
                objPM_Permits_VOC_Emissions.SubTotal_Text = new clsLU_VOC_Category((decimal)objPM_Permits_VOC_Emissions.FK_LU_VOC_Category).Category + (GetSubTotal(dtVOC)).ToString();
            }
            else
            {
                objPM_Permits_VOC_Emissions.SubTotal_Text = new clsLU_VOC_Category((decimal)objPM_Permits_VOC_Emissions.FK_LU_VOC_Category).Category + (clsGeneral.GetDecimal(txtQuantity.Text) * (clsGeneral.GetDecimal(txtGallons.Text)));
            }

            objPM_Permits_VOC_Emissions.DeleteByPK(PK_PM_Permits_VOC_Emissions);

            pnlVOCEdit.Visible = false;
            pnlVOCView.Visible = false;
            BindVOCGrid();
        }

    }

    /// <summary>
    /// Handles link button Previous Next Command event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkPreviousNext_RowCommand(object sender, CommandEventArgs e)
    {
        if (e.CommandName == "PreviousYear")
        {
            CurrentYear = CurrentYear - 1;
        }
        else if (e.CommandName == "PreviousMonth")
        {
            if (CurrentMonth == 1)
            {
                CurrentMonth = 12;
                CurrentYear = CurrentYear - 1;
            }
            else
            {
                CurrentMonth = CurrentMonth - 1;
            }
        }
        else if (e.CommandName == "NextMonth")
        {
            if (CurrentMonth == 12)
            {
                CurrentMonth = 1;
                CurrentYear = CurrentYear + 1;
            }
            else
            {
                CurrentMonth = CurrentMonth + 1;
            }
        }
        else if (e.CommandName == "NextYear")
        {
            CurrentYear = CurrentYear + 1;
        }
        pnlVOCEdit.Visible = false;
        pnlVOCView.Visible = false;
        BindVOCGrid();
    }

    /// <summary>
    /// Link Cancel click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        pnlVOCEdit.Visible = false;
        lnkAddNew.Visible = true;
    }

    /// <summary>
    /// Button Save click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveVOCData_Click(object sender, EventArgs e)
    {
        if (PK_PM_Permits > 0)
        {
            clsPM_Permits_VOC_Emissions objPM_Permits_VOC_Emissions = new clsPM_Permits_VOC_Emissions();
            objPM_Permits_VOC_Emissions.PK_PM_Permits_VOC_Emissions = PK_PM_Permits_VOC_Emissions;
            if (drpPaintCategory.SelectedIndex > 0) objPM_Permits_VOC_Emissions.FK_LU_VOC_Category = Convert.ToDecimal(drpPaintCategory.SelectedValue);
            if (ddlMonth.SelectedIndex > 0) objPM_Permits_VOC_Emissions.Month = Convert.ToInt16(ddlMonth.SelectedValue);
            if (ddlYear.SelectedIndex > 0) objPM_Permits_VOC_Emissions.Year = Convert.ToInt16(ddlYear.SelectedValue);
            objPM_Permits_VOC_Emissions.Part_Number = txtItemNumber.Text;
            objPM_Permits_VOC_Emissions.FK_PM_Permits = PK_PM_Permits;
            objPM_Permits_VOC_Emissions.Unit = txtUnit.Text;
            objPM_Permits_VOC_Emissions.Quantity = txtQuantity.Text;
            objPM_Permits_VOC_Emissions.Gallons = clsGeneral.GetDecimal(txtGallons.Text);
            objPM_Permits_VOC_Emissions.VOC_Emissions = clsGeneral.GetDecimal(txtVOCEmissions.Text);
            objPM_Permits_VOC_Emissions.Update_Date = DateTime.Now;
            objPM_Permits_VOC_Emissions.Updated_By = clsSession.UserID;

            DataTable dtVOC = objPM_Permits_VOC_Emissions.SelectByFK(PK_PM_Permits).Tables[0];

            if (dtVOC != null && dtVOC.Rows.Count > 0)
            {
                objPM_Permits_VOC_Emissions.SubTotal_Text = drpPaintCategory.SelectedItem.Text + ((clsGeneral.GetDecimal(txtQuantity.Text) * (clsGeneral.GetDecimal(txtGallons.Text))) + GetSubTotal(dtVOC)).ToString();
            }
            else
            {
                objPM_Permits_VOC_Emissions.SubTotal_Text = drpPaintCategory.SelectedItem.Text + (clsGeneral.GetDecimal(txtQuantity.Text) * (clsGeneral.GetDecimal(txtGallons.Text)));
            }

            if (PK_PM_Permits_VOC_Emissions > 0)
                objPM_Permits_VOC_Emissions.Update();
            else
                objPM_Permits_VOC_Emissions.Insert();

            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('VOC Details Saved successfully.');", true);

            BindVOCGrid();

            pnlVOCEdit.Visible = false;
            lnkAddNew.Visible = true;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Permit details first.');", true);
        }
    }

    /// <summary>
    /// Link Cancel click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancelView_Click(object sender, EventArgs e)
    {
        pnlVOCView.Visible = false;
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
        if (PK_PM_Permits > 0)
        {
            // add the attachment 
            Attachment.FK_Field_Value = Convert.ToInt32(PK_PM_Permits);
            Attachment.FK_Field_Name = "FK_PM_Permits";
            Attachment.Add(clsGeneral.Pollution_Tables.PM_Permits_Attachments);

            // bind the details to view added attachment
            BindAttachmentDetails();

            // show the attachment panel as the page is loaded again
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(2);", true);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('Please save Permit details first');ShowPanel(2);", true);
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


        DataTable dtFields = clsScreen_Validators.SelectByScreen(156).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Permit Type": strCtrlsIDs += drpFK_Permit_Type.ClientID + ","; strMessages += "Please select [Permits]/Permit Type" + ","; Span1.Style["display"] = "inline-block"; break;
                case "Certification Number": strCtrlsIDs += txtCertification_Number.ClientID + ","; strMessages += "Please enter [Permits]/Certification Number" + ","; Span2.Style["display"] = "inline-block"; break;
                case "Application Regulation Number": strCtrlsIDs += txtApplication_Regulation_Number.ClientID + ","; strMessages += "Please enter [Permits]/Application Regulation Number" + ","; Span3.Style["display"] = "inline-block"; break;
                case "Permit Start Date": strCtrlsIDs += txtPermit_Start_Date.ClientID + ","; strMessages += "Please enter [Permits]/Permit Start Date" + ","; Span4.Style["display"] = "inline-block"; break;
                case "Permit End Date": strCtrlsIDs += txtPermit_End_Date.ClientID + ","; strMessages += "Please enter [Permits]/Permit End Date" + ","; Span5.Style["display"] = "inline-block"; break;
                case "Last Inspection Date": strCtrlsIDs += txtLast_Inspection_Date.ClientID + ","; strMessages += "Please enter [Permits]/Last Inspection Date" + ","; Span6.Style["display"] = "inline-block"; break;
                case "Next Inspection Date": strCtrlsIDs += txtNext_Inspection_Date.ClientID + ","; strMessages += "Please enter [Permits]/Next Inspection Date" + ","; Span7.Style["display"] = "inline-block"; break;
                case "Next Report Date": strCtrlsIDs += txtNext_Report_Date.ClientID + ","; strMessages += "Please enter [Permits]/Next Report Date" + ","; Span8.Style["display"] = "inline-block"; break;
                case "Notes": strCtrlsIDs += txtNotes.ClientID + ","; strMessages += "Please enter [Permits]/Notes" + ","; Span9.Style["display"] = "inline-block"; break;
                case "Recommendations": strCtrlsIDs += txtRecommendations.ClientID + ","; strMessages += "Please enter [Permits]/Recommendations" + ","; Span10.Style["display"] = "inline-block"; break;
                case "Year": strCtrlsIDs += ddlYear.ClientID + ","; strMessages += "Please enter [VOC]/Year" + ","; Span12.Style["display"] = "inline-block"; break;
                case "Month": strCtrlsIDs += ddlMonth.ClientID + ","; strMessages += "Please enter [VOC]/Month" + ","; Span11.Style["display"] = "inline-block"; break;
                case "Paint Category": strCtrlsIDs += drpPaintCategory.ClientID + ","; strMessages += "Please enter [VOC]/Paint Category" + ","; Span13.Style["display"] = "inline-block"; break;
                case "Item Number": strCtrlsIDs += txtItemNumber.ClientID + ","; strMessages += "Please enter [VOC]/Item Number" + ","; Span14.Style["display"] = "inline-block"; break;
                case "Unit": strCtrlsIDs += txtUnit.ClientID + ","; strMessages += "Please enter [VOC]/Unit" + ","; Span15.Style["display"] = "inline-block"; break;
                case "Quantity": strCtrlsIDs += txtQuantity.ClientID + ","; strMessages += "Please enter [VOC]/Quantity" + ","; Span16.Style["display"] = "inline-block"; break;
                case "Gallons": strCtrlsIDs += txtGallons.ClientID + ","; strMessages += "Please enter [VOC]/Gallons" + ","; Span17.Style["display"] = "inline-block"; break;
                case "VOC Emissions": strCtrlsIDs += txtGallons.ClientID + ","; strMessages += "Please enter [VOC]/VOC Emissions" + ","; Span18.Style["display"] = "inline-block"; break;
            }
            #endregion
        }

        strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
        strMessages = strMessages.TrimEnd(',');

        hdnControlIDs.Value = strCtrlsIDs;
        hdnErrorMsgs.Value = strMessages;
    }
    #endregion

    protected void lnkImport_Click(object sender, EventArgs e)
    {
        if (PK_PM_Permits == 0)
        {
            ScriptManager.RegisterStartupScript(UpdatePanel1, UpdatePanel1.GetType(), DateTime.Now.ToString(), "javascript:alert('Please Save Permit Details First');", true);
        }
        else
        {
            Response.Redirect("VOCEmissionsImport.aspx?id=" + Encryption.Encrypt(Convert.ToString(PK_PM_Permits)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
        }
    }

    /// <summary>
    /// VOC Grid Row Data Bound
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvVOCEmission_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HiddenField lnkHidden = (HiddenField)e.Row.FindControl("hdnLink");

            if (Convert.ToInt16(lnkHidden.Value) == 0)
            {
                e.Row.CssClass = "SubTotalRowStyle";
                ((LinkButton)e.Row.FindControl("lnkRemove")).Visible = false;
                ((LinkButton)e.Row.FindControl("lnkYear")).Enabled = false;
                ((LinkButton)e.Row.FindControl("lnkMonth")).Enabled = false;
                ((LinkButton)e.Row.FindControl("lnkCategory")).Enabled = false;
                ((LinkButton)e.Row.FindControl("lnkPart_Number")).Enabled = false;
                ((LinkButton)e.Row.FindControl("lnkGallons")).Enabled = false;
                ((LinkButton)e.Row.FindControl("lnkVOC_Emissions")).Enabled = false;
            }
        }
    }

    protected void drpFK_Permit_Type_SelectedIndexChanged(object sender, EventArgs e)
    {
        dvVOCGrid.Visible = false;
        if (drpFK_Permit_Type.SelectedIndex > 0)
        {
            dvVOCGrid.Visible = true;
        }
    }

    /// <summary>
    /// VOC Audit Trail Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnVOCAuditTrail_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, Page.GetType(), DateTime.Now.ToString(), "javascript:OpenVOCAuditPopUp(" + PK_PM_Permits_VOC_Emissions.ToString() + ");", true);
    }
}
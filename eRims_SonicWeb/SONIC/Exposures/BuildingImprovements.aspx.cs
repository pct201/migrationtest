using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using ERIMS.DAL;

/// <summary>
/// Date : 06 JUNE 09
/// 
/// By : Hetal Prajapati
/// 
/// Purpose: 
/// To add, edit and view the Building Improvements record
/// 
/// Functionality:
/// Checks for the querystring passed for operation
/// and sets the page controls in view or edit or add mode
/// Also performs attachments adding, listing and removing
/// </summary>
public partial class SONIC_Exposures_BuildingImprovements : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Building_Improvements
    {
        get
        {
            return Convert.ToDecimal(ViewState["PK_Building_Improvements"]);
        }
        set { ViewState["PK_Building_Improvements"] = value; }
    }

    /// <summary>
    /// Denotes the foreign key referring to the Building record
    /// </summary>
    public decimal FK_Property_Cope
    {
        get
        {
            return Convert.ToDecimal(ViewState["FK_Property_Cope"]);
        }
        set { ViewState["FK_Property_Cope"] = value; }
    }

    /// <summary>
    /// Denotes the foreign key referring to the Building record
    /// </summary>
    public decimal PK_Building_Improvement_Notes
    {
        get
        {
            return Convert.ToDecimal(ViewState["PK_Building_Improvement_Notes"]);
        }
        set { ViewState["PK_Building_Improvement_Notes"] = value; }
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

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // Check if User has right To Add or Edit 
            if (App_Access == AccessType.NotAssigned)
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
            }
            // Set Tab selection
            Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Property);
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            // set operation if passed in querystring
            StrOperation = Convert.ToString(Request.QueryString["op"]);

            // if id is passed in querystring 
            if (Request.QueryString["id"] != null)
            {
                // check for valid ID and set PK property
                decimal decID;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out decID)) PK_Building_Improvements = decID;
            }

            // if building id is passed in querystring
            if (Request.QueryString["FK_Property_Cope"] != null)
            {
                // check for valid ID and set FK property
                decimal decFK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["FK_Property_Cope"]), out decFK)) FK_Property_Cope = decFK;
            }

            // if opertaion flag is set
            if (StrOperation != string.Empty)
            {
                // if operation is for viewing
                if (StrOperation == "view")
                {
                    // Bind Controls for page in view mode
                    BindDetailsForView();
                }
                else
                {
                    // Check if User has right To Add or Edit 
                    if (App_Access == AccessType.View_Only)
                    {
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                    }
                    else
                    {
                        SetValidations();
                        // Bind Controls for page in edit mode
                        txtSubtotal1.Attributes.Add("readonly", "readonly");
                        txtSubtotal2.Attributes.Add("readonly", "readonly");
                        txtTotalCost.Attributes.Add("readonly", "readonly");
                        txtTotalSquareFootageRevised.Attributes.Add("readonly", "readonly");
                        txtNote_Date.Attributes.Add("readonly", "readonly");
                        txtLast_Modified_date.Attributes.Add("readonly", "readonly");

                        BindDetailsForEdit();
                    }
                }
                BindProjectNotesGrid();
            }
            else
            {
                // Check if User has right To Add or Edit 
                if (App_Access == AccessType.View_Only)
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
                else
                {
                    SetValidations();
                    // don't show div for view mode
                    dvView.Style["display"] = "none";
                }
            }

            if (Session["ExposureLocation"] == null)
            {
                Response.Redirect("ExposureSearch.aspx");
            }

            // Bind location information
            ucCtrlExposureInfo.PK_LU_Location = Convert.ToDecimal(Session["ExposureLocation"]);
            ucCtrlExposureInfo.BindExposureInfo();
            //ucCtrlExposureInfo.SetRMLocationCode((int)FK_Property_Cope);
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        // show or hide div required for edit mode
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";

        // create object for Building_Improvements record
        Building_Improvements objBuilding_Improvements = new Building_Improvements(PK_Building_Improvements);

        ComboHelper.FillBuildingForBuildingImprovements(new ListBox[] { lstBuildingNumber }, clsGeneral.GetInt(Session["ExposureLocation"]), false);
        ComboHelper.FillBuildingImprovementStatus(new DropDownList[] { drpFK_LU_BI_Status }, true);

        if (PK_Building_Improvements > 0)
        {

            DataTable dtBuildings = Building_Improvements.SelectBuildingByFK_Building_Improvements(PK_Building_Improvements).Tables[0];
            if (dtBuildings != null && dtBuildings.Rows.Count > 0)
            {
                foreach (DataRow drBuilding in dtBuildings.Rows)
                {
                    if (lstBuildingNumber.Items.FindByValue(Convert.ToString(drBuilding["FK_Building"])) != null)
                    {
                        lstBuildingNumber.Items.FindByValue(Convert.ToString(drBuilding["FK_Building"])).Selected = true;
                    }
                }
            }

            // set values in page controls using object variables


            txtProjectImprovementDescription.Text = objBuilding_Improvements.Improvement_Description;
            txtProject_Number.Text = objBuilding_Improvements.Project_Number;
            txtProject_Start_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Start_Date);
            txtTarget_Completion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Target_Completion_Date);
            txtActual_Completion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Completion_Date);
            txtProjectImprovementDescription.Text = objBuilding_Improvements.Improvement_Description;
            txtContactName.Text = objBuilding_Improvements.Contact_Name;
            rdoNew_Build.SelectedValue = objBuilding_Improvements.New_Build;

            txtProjectStatusAsOf.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Project_Status_As_Of_Date);
            rdoOpen.SelectedValue = objBuilding_Improvements.Open;

            if (objBuilding_Improvements.FK_LU_BI_Status.HasValue && drpFK_LU_BI_Status.Items.FindByValue(objBuilding_Improvements.FK_LU_BI_Status.Value.ToString()) != null)
            {
                drpFK_LU_BI_Status.ClearSelection();
                drpFK_LU_BI_Status.Items.FindByValue(objBuilding_Improvements.FK_LU_BI_Status.Value.ToString()).Selected = true;
                if (drpFK_LU_BI_Status.SelectedItem.Text == "Other - Describe")
                {
                    string strCtrlsIDs = hdnControlIDs.Value;
                    string strMessages = hdnErrorMsgs.Value;
                    strCtrlsIDs += "," + txtStatusDescription.ClientID;
                    strMessages += "," + "Please enter Status Description - If Other ";
                    Span16.Style["display"] = "inline-block";
                    MenuAsterisk1.Style["display"] = "inline-block";
                    txtStatusDescription.Attributes.Remove("disabled");

                    strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
                    strMessages = strMessages.TrimEnd(',');

                    hdnControlIDs.Value = strCtrlsIDs;
                    hdnErrorMsgs.Value = strMessages;
                }
            }

            txtStatusDescription.Text = objBuilding_Improvements.Status_Other;

            rdlRevisedSquareFootage.SelectedValue = objBuilding_Improvements.Revised_Square_Footage;

            txtSales.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Sales);
            txtPart.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Parts);
            txtOther.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Other);

            txtServiceLane.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Service_Lane);
            txtServiceDepartment.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Service);

            txtTotalSquareFootageRevised.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Total_Square_Footage_Revised);

            txtConstruction.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Construction);
            txtLand.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Land);
            txtMiscellaneous.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Misc);

            txtInformationTechnology.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_IT);
            txtFurniture.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Furniture);
            txtEquipment.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Equipment);
            txtSignage.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Signage);

            txtSubtotal1.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_SubTotal_1);
            txtSubtotal2.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_SubTotal_2);

            txtTotalCost.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Total);
        }
        //txtService_Capacity_Increase.Text = objBuilding_Improvements.Service_Capacity_Increase;


        // calculate and display total square footage field

    }


    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        // show or hide div required for edit mode
        dvView.Style["display"] = "block";
        dvBack.Style["display"] = "block";
        dvEdit.Style["display"] = "none";
        dvSave.Style["display"] = "none";

        //ComboHelper.FillBuildingForBuildingImprovements(new ListBox[] { lstBuildingNumberView }, false);
        ComboHelper.FillBuildingForBuildingImprovements(new ListBox[] { lstBuildingNumberView }, clsGeneral.GetInt(Session["ExposureLocation"]), false);

        DataTable dtBuildings = Building_Improvements.SelectBuildingByFK_Building_Improvements(PK_Building_Improvements).Tables[0];
        if (dtBuildings != null && dtBuildings.Rows.Count > 0)
        {
            foreach (DataRow drBuilding in dtBuildings.Rows)
            {
                if (lstBuildingNumberView.Items.FindByValue(Convert.ToString(drBuilding["FK_Building"])) != null)
                {
                    lstBuildingNumberView.Items.FindByValue(Convert.ToString(drBuilding["FK_Building"])).Selected = true;
                }
            }
        }

        // create object for Building_Improvements record
        Building_Improvements objBuilding_Improvements = new Building_Improvements(PK_Building_Improvements);

        lblProjectNumber.Text = objBuilding_Improvements.Project_Number;
        lblProjectStartDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Start_Date);
        lblTargetCompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Target_Completion_Date);
        lblActualCompletionDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Completion_Date);
        CtrlMultiLineLabelProjectImprovementDescription.Text = objBuilding_Improvements.Improvement_Description;
        lblContactName.Text = objBuilding_Improvements.Contact_Name;
        lblContactName.Text = objBuilding_Improvements.Contact_Name;
        lblNewBuildView.Text = objBuilding_Improvements.New_Build == "Y" ? "Yes" : "No";
        lblProjectStatusAsOfDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Project_Status_As_Of_Date);
        lblOpenview.Text = objBuilding_Improvements.Open == "Y" ? "Yes" : "No";

        if (objBuilding_Improvements.FK_LU_BI_Status.HasValue)
            lblStatus.Text = (new clsLU_BI_Status(objBuilding_Improvements.FK_LU_BI_Status.Value)).Fld_Desc;

        lblStatusDescription.Text = objBuilding_Improvements.Status_Other;

        switch (objBuilding_Improvements.Revised_Square_Footage)
        {
            case "A":
                lblRevisedSquareFootageView.Text = "Add";
                break;
            case "R":
                lblRevisedSquareFootageView.Text = "Reduce";
                break;
            case "N":
                lblRevisedSquareFootageView.Text = "No Change";
                break;
            default: break;
        }

        lblSales.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Sales);
        lblPart.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Parts);
        lblOther.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Other);

        lblServiceLane.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Service_Lane);
        lblServiceDepartment.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Revised_Square_Footage_Service);

        lblTotalSquareFootageRevised.Text = clsGeneral.FormatCommaSeperatorNumber(objBuilding_Improvements.Total_Square_Footage_Revised);

        lblConstruction.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Construction);
        lblLand.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Land);
        lblMiscellaneous.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Misc);

        lblInformationTechnology.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_IT);
        lblFurniture.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Furniture);
        lblEquipment.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Equipment);
        lblSignage.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Signage);

        lblSubTotal_1.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_SubTotal_1);
        lblSubTotal_2.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_SubTotal_2);

        lblTotalCost.Text = clsGeneral.FormatCommaSeperatorCurrency(objBuilding_Improvements.Budget_Total);


        // set values in labels using object variables
        //lblImprovement_Description.Text = objBuilding_Improvements.Improvement_Description;
        //lblService_Capacity_Increase.Text = objBuilding_Improvements.Service_Capacity_Increase;
        //lblRevised_Square_Footage_Sales.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Sales).Replace(".00", "");
        //lblRevised_Square_Footage_Service.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Service).Replace(".00", "");
        //lblRevised_Square_Footage_Parts.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Parts).Replace(".00", "");
        //lblRevised_Square_Footage_Other.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Other).Replace(".00", "");
        //lblImprovement_Value.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Improvement_Value);
        //lblCompletion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Completion_Date);

        // calculate and display total square footage field
        //decimal decSales = (objBuilding_Improvements.Revised_Square_Footage_Sales != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Sales : 0;
        //decimal decService = (objBuilding_Improvements.Revised_Square_Footage_Service != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Service : 0;
        //decimal decParts = (objBuilding_Improvements.Revised_Square_Footage_Parts != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Parts : 0;
        //decimal decOthers = (objBuilding_Improvements.Revised_Square_Footage_Other != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Other : 0;
        //decimal decTotal = decSales + decService + decOthers + decParts;
        //lblTotalSquareFootageView.Text = clsGeneral.GetStringValue(decTotal).Replace(".00", "");
    }

    /// <summary>
    /// Bind Notes Grid
    /// </summary>
    private void BindProjectNotesGrid()
    {
        DataTable dtProjectNotes = new DataTable();

        if (PK_Building_Improvements > 0)
        {
            dtProjectNotes = clsBuilding_Improvements_Notes.SelectByFK_Building_Improvements(PK_Building_Improvements).Tables[0]; ;
        }

        if (StrOperation != "view")
        {
            gvProjectNotes.DataSource = dtProjectNotes;
            gvProjectNotes.DataBind();
            if (StrOperation == "add")
            {
                lnkAddProjectNotesGrid.Visible = false;
            }
        }
        else
        {
            gvProjectNotesview.DataSource = dtProjectNotes;
            gvProjectNotesview.DataBind();
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
        // create object for Building_Improvements record
        Building_Improvements objBuilding_Improvements = new Building_Improvements();

        string FK_Building_Ids = string.Empty;
        foreach (ListItem lstItem in lstBuildingNumber.Items)
        {
            if (lstItem.Selected)
                FK_Building_Ids += lstItem.Value + ",";
        }

        FK_Building_Ids = FK_Building_Ids.TrimEnd(',');

        // set PK and FK
        objBuilding_Improvements.FK_Building_Ids = FK_Building_Ids;
        objBuilding_Improvements.PK_Building_Improvements = PK_Building_Improvements;
        //objBuilding_Improvements.FK_Building = FK_Building;
        objBuilding_Improvements.FK_Property_Cope = FK_Property_Cope;
        objBuilding_Improvements.Project_Number = txtProject_Number.Text;
        objBuilding_Improvements.Start_Date = clsGeneral.FormatNullDateToStore(txtProject_Start_Date.Text);
        objBuilding_Improvements.Target_Completion_Date = clsGeneral.FormatNullDateToStore(txtTarget_Completion_Date.Text);
        objBuilding_Improvements.Completion_Date = clsGeneral.FormatNullDateToStore(txtActual_Completion_Date.Text);


        // get values from page controls
        objBuilding_Improvements.Improvement_Description = txtProjectImprovementDescription.Text.Trim();

        objBuilding_Improvements.Contact_Name = txtContactName.Text;
        objBuilding_Improvements.New_Build = rdoNew_Build.SelectedValue;
        objBuilding_Improvements.Project_Status_As_Of_Date = clsGeneral.FormatNullDateToStore(txtProjectStatusAsOf.Text);
        objBuilding_Improvements.Open = rdoOpen.SelectedValue;
        if (drpFK_LU_BI_Status.SelectedValue != "0")
            objBuilding_Improvements.FK_LU_BI_Status = Convert.ToDecimal(drpFK_LU_BI_Status.SelectedValue);

        objBuilding_Improvements.Status_Other = txtStatusDescription.Text;
        objBuilding_Improvements.Revised_Square_Footage = rdlRevisedSquareFootage.SelectedValue;

        objBuilding_Improvements.Revised_Square_Footage_Sales = clsGeneral.GetDecimalNullableValue(txtSales);
        objBuilding_Improvements.Revised_Square_Footage_Service_Lane = clsGeneral.GetDecimalNullableValue(txtServiceLane);
        objBuilding_Improvements.Revised_Square_Footage_Parts = clsGeneral.GetDecimalNullableValue(txtPart);
        objBuilding_Improvements.Revised_Square_Footage_Service = clsGeneral.GetDecimalNullableValue(txtServiceDepartment);
        objBuilding_Improvements.Revised_Square_Footage_Other = clsGeneral.GetDecimalNullableValue(txtOther);
        objBuilding_Improvements.Total_Square_Footage_Revised = clsGeneral.GetDecimalNullableValue(txtTotalSquareFootageRevised);

        objBuilding_Improvements.Budget_Construction = clsGeneral.GetDecimalNullableValue(txtConstruction);
        objBuilding_Improvements.Budget_IT = clsGeneral.GetDecimalNullableValue(txtInformationTechnology);
        objBuilding_Improvements.Budget_Land = clsGeneral.GetDecimalNullableValue(txtLand);
        objBuilding_Improvements.Budget_Furniture = clsGeneral.GetDecimalNullableValue(txtFurniture);
        objBuilding_Improvements.Budget_Misc = clsGeneral.GetDecimalNullableValue(txtMiscellaneous);
        objBuilding_Improvements.Budget_Equipment = clsGeneral.GetDecimalNullableValue(txtEquipment);
        objBuilding_Improvements.Budget_Signage = clsGeneral.GetDecimalNullableValue(txtSignage);

        objBuilding_Improvements.Budget_SubTotal_1 = clsGeneral.GetDecimalNullableValue(txtSubtotal1);
        objBuilding_Improvements.Budget_SubTotal_2 = clsGeneral.GetDecimalNullableValue(txtSubtotal2);

        objBuilding_Improvements.Budget_Total = clsGeneral.GetDecimalNullableValue(txtTotalCost);



        objBuilding_Improvements.Updated_By = clsSession.UserID;
        objBuilding_Improvements.Updated_Date = DateTime.Now;

        // insert or update the record as per the PK availability
        if (PK_Building_Improvements > 0)
            objBuilding_Improvements.Update();
        else
            PK_Building_Improvements = objBuilding_Improvements.Insert();

        //redirect back to the Property page
        //Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&panel=4");
        if (StrOperation == "add")
            Response.Redirect(Request.RawUrl.Replace("op=" + StrOperation, "op=view") + "&id=" + Encryption.Encrypt(Convert.ToString(PK_Building_Improvements)));
        else
            Response.Redirect(Request.RawUrl.Replace("op=" + StrOperation, "op=view"));
    }

    /// <summary>
    /// Handles Revert And Return button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertReturn_Click(object sender, EventArgs e)
    {
        // redirec to the Property page for edit 
        //Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&FK_Property_Cope=" + Request.QueryString["FK_Property_Cope"]);
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&panel=4");
    }

    /// <summary>
    /// Handles Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirect to Property page for view
        Response.Redirect("PropertyView.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&panel=4");
    }

    /// <summary>
    /// Handles Save Notes button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveNotes_Click(object sender, EventArgs e)
    {
        //string script = " $(\"#<%=pnlNoteGridAdd.ClientID%>\").css(\"display\", \"none\");$(\"#<%=pnl1.ClientID%>\").css(\"display\", \"\");";
        //ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString(), script, true);
        clsBuilding_Improvements_Notes objProjectNotes = new clsBuilding_Improvements_Notes();

        objProjectNotes.FK_Building_Improvements = PK_Building_Improvements;
        objProjectNotes.Note = txtProjectNotes.Text;
        objProjectNotes.Date_Of_Note = DateTime.Now;
        objProjectNotes.Updated_By = clsSession.UserName;

        if (hdnPK_Building_Improvement_Notes.Value != "0")
        {
            objProjectNotes.PK_Building_Improvements_Notes = Convert.ToDecimal(hdnPK_Building_Improvement_Notes.Value);
            objProjectNotes.Update_Date = DateTime.Now;
            objProjectNotes.Update();
        }
        else
        {
            objProjectNotes.Insert();
        }

        //objProjectNotes.Update_Date = DateTime.Now;


        Response.Redirect(Request.RawUrl);
    }

    protected void gvProjectNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvEdit")
        {
            clsBuilding_Improvements_Notes objProjectNotes = new clsBuilding_Improvements_Notes(Convert.ToDecimal(e.CommandArgument));
            txtProjectNotes.Text = objProjectNotes.Note;
            txtNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objProjectNotes.Date_Of_Note);
            txtLast_Modified_date.Text = clsGeneral.FormatDBNullDateToDisplay(objProjectNotes.Update_Date);
            hdnPK_Building_Improvement_Notes.Value = Convert.ToString(objProjectNotes.PK_Building_Improvements_Notes.Value);

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString(), "OpenNotesPopup();", true);
        }
        else if (e.CommandName == "Remove")
        {
            clsBuilding_Improvements_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));
            Response.Redirect(Request.RawUrl);
        }
    }
    protected void gvProjectNotesGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "gvView")
        {
            clsBuilding_Improvements_Notes objProjectNotes = new clsBuilding_Improvements_Notes(Convert.ToDecimal(e.CommandArgument));
            lblProjectNotes.Text = objProjectNotes.Note;
            lblNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objProjectNotes.Date_Of_Note);
            lblLast_Modified_date.Text = clsGeneral.FormatDBNullDateToDisplay(objProjectNotes.Update_Date);

            ScriptManager.RegisterStartupScript(this, this.GetType(), DateTime.Now.ToString(), "OpenNotesPopupView();", true);
        }
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl.Replace("op=view", "op=edit"));
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

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(213).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        //MenuAsterisk1.Style["display"] = "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Building Number": strCtrlsIDs += lstBuildingNumber.ClientID + ","; strMessages += "Please select Building Number " + ","; Span9.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Project Number": strCtrlsIDs += txtProject_Number.ClientID + ","; strMessages += "Please enter Project Number " + ","; Span10.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Project Start Date": strCtrlsIDs += txtProject_Start_Date.ClientID + ","; strMessages += "Please enter Project Start Date " + ","; Span11.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Target Completion Date": strCtrlsIDs += txtTarget_Completion_Date.ClientID + ","; strMessages += "Please enter Target Completion Date " + ","; Span13.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Actual Completion Date": strCtrlsIDs += txtActual_Completion_Date.ClientID + ","; strMessages += "Please enter Actual Completion Date " + ","; Span12.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Project Improvement Description": strCtrlsIDs += txtProjectImprovementDescription.ClientID + ","; strMessages += "Please enter Project Improvement Description " + ","; Span92.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Contact Name": strCtrlsIDs += txtContactName.ClientID + ","; strMessages += "Please enter Contact Name " + ","; Span14.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Project Status As Of": strCtrlsIDs += txtProjectStatusAsOf.ClientID + ","; strMessages += "Please enter Project Status As Of " + ","; Span1.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Status": strCtrlsIDs += drpFK_LU_BI_Status.ClientID + ","; strMessages += "Please select Status " + ","; Span15.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Sales": strCtrlsIDs += txtSales.ClientID + ","; strMessages += "Please enter Sales " + ","; Span18.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Parts": strCtrlsIDs += txtPart.ClientID + ","; strMessages += "Please enter Parts " + ","; Span20.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Other": strCtrlsIDs += txtOther.ClientID + ","; strMessages += "Please enter Other " + ","; Span22.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Service Lane": strCtrlsIDs += txtServiceLane.ClientID + ","; strMessages += "Please enter Other " + ","; Span19.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Service Department": strCtrlsIDs += txtServiceDepartment.ClientID + ","; strMessages += "Please enter Service Department " + ","; Span21.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Construction": strCtrlsIDs += txtConstruction.ClientID + ","; strMessages += "Please enter Construction " + ","; Span23.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Land": strCtrlsIDs += txtLand.ClientID + ","; strMessages += "Please enter Land " + ","; Span25.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Miscellaneous": strCtrlsIDs += txtMiscellaneous.ClientID + ","; strMessages += "Please enter Miscellaneous " + ","; Span27.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Information Technology": strCtrlsIDs += txtInformationTechnology.ClientID + ","; strMessages += "Please enter Information Technology " + ","; Span24.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Furniture": strCtrlsIDs += txtFurniture.ClientID + ","; strMessages += "Please enter Furniture " + ","; Span26.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Equipment": strCtrlsIDs += txtEquipment.ClientID + ","; strMessages += "Please enter Equipment " + ","; Span28.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Signage": strCtrlsIDs += txtSignage.ClientID + ","; strMessages += "Please enter Signage " + ","; Span30.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;

                //case "Improvements Grid - Improvement Description": strCtrlsIDs += txtProjectImprovementDescription.ClientID + ","; strMessages += "Please enter Improvements Grid - Improvement Description" + ","; Span1.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                //case "Improvements Grid - Revised Square Footage Sales": strCtrlsIDs += txtRevised_Square_Footage_Sales.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Sales" + ","; Span3.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                //case "Improvements Grid - Revised Square Footage Service": strCtrlsIDs += txtRevised_Square_Footage_Service.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Service" + ","; Span4.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                //case "Improvements Grid - Revised Square Footage Parts": strCtrlsIDs += txtRevised_Square_Footage_Parts.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Parts" + ","; Span5.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                //case "Improvements Grid - Revised Square Footage Other": strCtrlsIDs += txtRevised_Square_Footage_Other.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Other" + ","; Span6.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                //case "Improvements Grid - Improvement Value": strCtrlsIDs += txtImprovement_Value.ClientID + ","; strMessages += "Please enter Improvements Grid - Improvement Value" + ","; Span7.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                //case "Improvements Grid - Completion Date": strCtrlsIDs += txtCompletion_Date.ClientID + ","; strMessages += "Please enter Improvements Grid - Completion Date" + ","; Span8.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
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

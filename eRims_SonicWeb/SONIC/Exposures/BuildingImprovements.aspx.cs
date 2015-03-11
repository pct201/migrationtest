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
                        BindDetailsForEdit();
                    }
                }
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

        ComboHelper.FillBuildingForBuildingImprovements(new ListBox[] { lstBuildingNumber }, false);
        ComboHelper.FillBuildingImprovementStatus(new DropDownList[] { drpFK_LU_BI_Status }, true);

        // set values in page controls using object variables
        txtProjectImprovementDescription.Text = objBuilding_Improvements.Improvement_Description;
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

        // create object for Building_Improvements record
        Building_Improvements objBuilding_Improvements = new Building_Improvements(PK_Building_Improvements);

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
        decimal decSales = (objBuilding_Improvements.Revised_Square_Footage_Sales != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Sales : 0;
        decimal decService = (objBuilding_Improvements.Revised_Square_Footage_Service != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Service : 0;
        decimal decParts = (objBuilding_Improvements.Revised_Square_Footage_Parts != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Parts : 0;
        decimal decOthers = (objBuilding_Improvements.Revised_Square_Footage_Other != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Other : 0;
        decimal decTotal = decSales + decService + decOthers + decParts;
        //lblTotalSquareFootageView.Text = clsGeneral.GetStringValue(decTotal).Replace(".00", "");
    }

    /// <summary>
    /// Bind Notes Grid
    /// </summary>
    private void BindProjectNotesGrid()
    {
        if (StrOperation != "view")
        {
            if (PK_Building_Improvements > 0)
            {
                gvProjectNotes.DataSource = AP_FE_PA_Notes.SelectNotesByFKFraudEvent(PK_Building_Improvements, "desc").Tables[0];
            }
            gvProjectNotes.DataBind();

        }
        else
        {
            //if (PK_Building_Improvements > 0)
            //{
            //    gvNotesGridFraudView.DataSource = AP_FE_PA_Notes.SelectNotesByFKFraudEvent(PK_AP_Fraud_Events, _SortOrder_FraudNotes).Tables[0];
            //}
            //gvNotesGridFraudView.DataBind();

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
            objBuilding_Improvements.Insert();

        //redirect back to the Property page
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&FK_Property_Cope=" + Request.QueryString["FK_Property_Cope"]);
    }

    /// <summary>
    /// Handles Revert And Return button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertReturn_Click(object sender, EventArgs e)
    {
        // redirec to the Property page for edit 
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&FK_Property_Cope=" + Request.QueryString["FK_Property_Cope"]);
    }

    /// <summary>
    /// Handles Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        // redirect to Property page for view
        Response.Redirect("PropertyView.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&build=" + Request.QueryString["build"]);
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(55).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            //switch (Convert.ToString(drField["Field_Name"]))
            {
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

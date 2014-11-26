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
    public decimal FK_Building
    {
        get
        {
            return Convert.ToDecimal(ViewState["FK_Building"]);
        }
        set { ViewState["FK_Building"] = value; }
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
            if (Request.QueryString["build"] != null)
            {
                // check for valid ID and set FK property
                decimal decFK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["build"]), out decFK)) FK_Building = decFK;
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
            ucCtrlExposureInfo.SetRMLocationCode((int)FK_Building);
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

        // set values in page controls using object variables
        txtImprovement_Description.Text = objBuilding_Improvements.Improvement_Description;
        txtService_Capacity_Increase.Text = objBuilding_Improvements.Service_Capacity_Increase;
        txtRevised_Square_Footage_Sales.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Sales).Replace(".00", "");
        txtRevised_Square_Footage_Service.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Service).Replace(".00", "");
        txtRevised_Square_Footage_Parts.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Parts).Replace(".00", "");
        txtRevised_Square_Footage_Other.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Other).Replace(".00", "");
        txtImprovement_Value.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Improvement_Value);
        txtCompletion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Completion_Date);

        // calculate and display total square footage field
        decimal decSales = (objBuilding_Improvements.Revised_Square_Footage_Sales != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Sales : 0;
        decimal decService = (objBuilding_Improvements.Revised_Square_Footage_Service != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Service : 0;
        decimal decParts = (objBuilding_Improvements.Revised_Square_Footage_Parts != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Parts : 0;
        decimal decOthers = (objBuilding_Improvements.Revised_Square_Footage_Other != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Other : 0;
        decimal decTotal = decSales + decService + decOthers + decParts;
        lblTotalSquareFootage.Text = clsGeneral.GetStringValue(decTotal).Replace(".00", "");
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
        lblImprovement_Description.Text = objBuilding_Improvements.Improvement_Description;
        lblService_Capacity_Increase.Text = objBuilding_Improvements.Service_Capacity_Increase;
        lblRevised_Square_Footage_Sales.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Sales).Replace(".00", "");
        lblRevised_Square_Footage_Service.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Service).Replace(".00", "");
        lblRevised_Square_Footage_Parts.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Parts).Replace(".00", "");
        lblRevised_Square_Footage_Other.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Revised_Square_Footage_Other).Replace(".00", "");
        lblImprovement_Value.Text = clsGeneral.GetStringValue(objBuilding_Improvements.Improvement_Value);
        lblCompletion_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_Improvements.Completion_Date);

        // calculate and display total square footage field
        decimal decSales = (objBuilding_Improvements.Revised_Square_Footage_Sales != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Sales : 0;
        decimal decService = (objBuilding_Improvements.Revised_Square_Footage_Service != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Service : 0;
        decimal decParts = (objBuilding_Improvements.Revised_Square_Footage_Parts != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Parts : 0;
        decimal decOthers = (objBuilding_Improvements.Revised_Square_Footage_Other != null) ? (decimal)objBuilding_Improvements.Revised_Square_Footage_Other : 0;
        decimal decTotal = decSales + decService + decOthers + decParts;
        lblTotalSquareFootageView.Text = clsGeneral.GetStringValue(decTotal).Replace(".00", "");
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

        // set PK and FK
        objBuilding_Improvements.PK_Building_Improvements = PK_Building_Improvements;
        objBuilding_Improvements.FK_Building = FK_Building;

        // get values from page controls
        objBuilding_Improvements.Improvement_Description = txtImprovement_Description.Text.Trim();
        objBuilding_Improvements.Service_Capacity_Increase = txtService_Capacity_Increase.Text.Trim();
        objBuilding_Improvements.Revised_Square_Footage_Sales = clsGeneral.GetDecimalValue(txtRevised_Square_Footage_Sales);
        objBuilding_Improvements.Revised_Square_Footage_Service = clsGeneral.GetDecimalValue(txtRevised_Square_Footage_Service);
        objBuilding_Improvements.Revised_Square_Footage_Parts = clsGeneral.GetDecimalValue(txtRevised_Square_Footage_Parts);
        objBuilding_Improvements.Revised_Square_Footage_Other = clsGeneral.GetDecimalValue(txtRevised_Square_Footage_Other);
        objBuilding_Improvements.Improvement_Value = clsGeneral.GetDecimalValue(txtImprovement_Value);
        objBuilding_Improvements.Completion_Date = clsGeneral.FormatNullDateToStore(txtCompletion_Date.Text);
        objBuilding_Improvements.Updated_By = clsSession.UserID;
        objBuilding_Improvements.Updated_Date = DateTime.Now;

        // insert or update the record as per the PK availability
        if (PK_Building_Improvements > 0)
            objBuilding_Improvements.Update();
        else
            objBuilding_Improvements.Insert();

        //redirect back to the Property page
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&build=" + Request.QueryString["build"]);
    }

    /// <summary>
    /// Handles Revert And Return button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertReturn_Click(object sender, EventArgs e)
    {
        // redirec to the Property page for edit 
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&build=" + Request.QueryString["build"]);
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
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Improvements Grid - Improvement Description": strCtrlsIDs += txtImprovement_Description.ClientID + ","; strMessages += "Please enter Improvements Grid - Improvement Description" + ","; Span1.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Service Capacity Increase": strCtrlsIDs += txtService_Capacity_Increase.ClientID + ","; strMessages += "Please enter Improvements Grid - Service Capacity Increase" + ","; Span2.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Revised Square Footage Sales": strCtrlsIDs += txtRevised_Square_Footage_Sales.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Sales" + ","; Span3.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Revised Square Footage Service": strCtrlsIDs += txtRevised_Square_Footage_Service.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Service" + ","; Span4.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Revised Square Footage Parts": strCtrlsIDs += txtRevised_Square_Footage_Parts.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Parts" + ","; Span5.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Revised Square Footage Other": strCtrlsIDs += txtRevised_Square_Footage_Other.ClientID + ","; strMessages += "Please enter Improvements Grid - Revised Square Footage Other" + ","; Span6.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Improvement Value": strCtrlsIDs += txtImprovement_Value.ClientID + ","; strMessages += "Please enter Improvements Grid - Improvement Value" + ","; Span7.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Improvements Grid - Completion Date": strCtrlsIDs += txtCompletion_Date.ClientID + ","; strMessages += "Please enter Improvements Grid - Completion Date" + ","; Span8.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
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

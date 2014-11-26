using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_BuildingFinancilaLimit : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_Building_Financial_Limits
    {
        get
        {
            return Convert.ToDecimal(ViewState["PK_Building_Financial_Limits"]);
        }
        set { ViewState["PK_Building_Financial_Limits"] = value; }
    }

    /// <summary>
    /// Denotes the foreign key referring to the Building record
    /// </summary>
    public decimal _FK_Building
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
    public string _StrOperation
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
            _PK_Building_Financial_Limits = 0;
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
            if (Request.QueryString["op"] != null)
            {
                _StrOperation = Convert.ToString(Request.QueryString["op"]);
            }

            // if id is passed in querystring 
            if (Request.QueryString["id"] != null)
            {
                // check for valid ID and set PK property
                decimal decID;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out decID)) _PK_Building_Financial_Limits = decID;
            }

            // if building id is passed in querystring
            if (Request.QueryString["build"] != null)
            {
                // check for valid ID and set FK property
                decimal decFK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["build"]), out decFK)) _FK_Building = decFK;
            }

            // if opertaion flag is set
            if (_StrOperation != string.Empty)
            {
                // if operation is for viewing
                if (_StrOperation == "view")
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
            if (Session["ExposureLocation"] != null)
            {
                ucCtrlExposureInfo.PK_LU_Location = Convert.ToDecimal(Session["ExposureLocation"]);
                ucCtrlExposureInfo.BindExposureInfo();
                ucCtrlExposureInfo.SetRMLocationCode((int)_FK_Building);
            }
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

        // create object for Building_Financial_Limits record
        Building_Financial_Limits objBuilding_FinancialLImit = new Building_Financial_Limits(_PK_Building_Financial_Limits);

        // set values in page controls using object variables
        txtPropertyValuationDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_FinancialLImit.Property_Valuation_Date);
        txtBuildingLimit.Text = clsGeneral.GetStringValue(objBuilding_FinancialLImit.Building_Limit).Replace(".00", "");
        txtAssociateToolsLimit.Text = clsGeneral.GetStringValue(objBuilding_FinancialLImit.Associate_Tools_Limit).Replace(".00", "");
        txtContentsLimit.Text = clsGeneral.GetStringValue(objBuilding_FinancialLImit.Contents_Limit).Replace(".00", "");
        txtPartsLimit.Text = clsGeneral.GetStringValue(objBuilding_FinancialLImit.Parts_Limit).Replace(".00", "");
        txtBusinessInterruption.Text = clsGeneral.GetStringValue(objBuilding_FinancialLImit.Business_Interruption).Replace(".00", "");
        txtBuildingTotal.Text = clsGeneral.GetStringValue(objBuilding_FinancialLImit.Total).Replace(".00", "");
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

        // create object for Building_Financial_Limits record
        Building_Financial_Limits objBuilding_FinancialLimit = new Building_Financial_Limits(_PK_Building_Financial_Limits);

        // set values in labels using object variables        
        lblPropertyValueDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_FinancialLimit.Property_Valuation_Date);
        lblBuildingLimit.Text = clsGeneral.GetStringValue(objBuilding_FinancialLimit.Building_Limit).Replace(".00", "");
        lblAssociatedLimits.Text = clsGeneral.GetStringValue(objBuilding_FinancialLimit.Associate_Tools_Limit).Replace(".00", "");
        lblContentLimit.Text = clsGeneral.GetStringValue(objBuilding_FinancialLimit.Contents_Limit).Replace(".00", "");
        lblPartsLimits.Text = clsGeneral.GetStringValue(objBuilding_FinancialLimit.Parts_Limit).Replace(".00", "");
        lblBuildingInteruption.Text = clsGeneral.GetStringValue(objBuilding_FinancialLimit.Business_Interruption);
        lblTotal.Text = clsGeneral.GetStringValue(objBuilding_FinancialLimit.Total);
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
        // create object for Building_Financial_Limits record
        Building_Financial_Limits objBuilding_FinancialLimit = new Building_Financial_Limits();

        // set PK and FK
        objBuilding_FinancialLimit.PK_Building_Financial_Limits = _PK_Building_Financial_Limits;
        objBuilding_FinancialLimit.FK_Building_Id = _FK_Building;

        // get values from page controls
        objBuilding_FinancialLimit.Property_Valuation_Date = clsGeneral.FormatNullDateToStore(txtPropertyValuationDate.Text);

        objBuilding_FinancialLimit.Building_Limit = clsGeneral.GetDecimalValue(txtBuildingLimit);
        objBuilding_FinancialLimit.Business_Interruption = clsGeneral.GetDecimalValue(txtBusinessInterruption);
        objBuilding_FinancialLimit.Parts_Limit = clsGeneral.GetDecimalValue(txtPartsLimit);
        objBuilding_FinancialLimit.Associate_Tools_Limit = clsGeneral.GetDecimalValue(txtAssociateToolsLimit);
        objBuilding_FinancialLimit.Contents_Limit = clsGeneral.GetDecimalValue(txtContentsLimit);
        objBuilding_FinancialLimit.Total = Convert.ToDecimal(objBuilding_FinancialLimit.Building_Limit + objBuilding_FinancialLimit.Business_Interruption + objBuilding_FinancialLimit.Parts_Limit + objBuilding_FinancialLimit.Associate_Tools_Limit + objBuilding_FinancialLimit.Contents_Limit);

        objBuilding_FinancialLimit.Updated_By = Convert.ToDecimal(clsSession.UserID);
        objBuilding_FinancialLimit.Update_Date = DateTime.Now;

        // insert or update the record as per the PK availability
        if (_PK_Building_Financial_Limits > 0)
            objBuilding_FinancialLimit.Update();
        else
            objBuilding_FinancialLimit.Insert();

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
                case "Financial Limits Grid - Property Valuation Date": strCtrlsIDs += txtPropertyValuationDate.ClientID + ","; strMessages += "Please enter Financial Limits Grid - Property Valuation Date" + ","; Span1.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Financial Limits Grid - RS Means Building Limit ($)": strCtrlsIDs += txtBuildingLimit.ClientID + ","; strMessages += "Please enter Financial Limits Grid - RS Means Building Limit ($)" + ","; Span2.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Financial Limits Grid - Associate Tools Limit ($)": strCtrlsIDs += txtAssociateToolsLimit.ClientID + ","; strMessages += "Please enter Financial Limits Grid - Associate Tools Limit ($)" + ","; Span3.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Financial Limits Grid - Contents Limit ($)": strCtrlsIDs += txtContentsLimit.ClientID + ","; strMessages += "Please enter Financial Limits Grid - Contents Limit ($)" + ","; Span4.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Financial Limits Grid - Parts Limit ($)": strCtrlsIDs += txtPartsLimit.ClientID + ","; strMessages += "Please enter Financial Limits Grid - Parts Limit ($)" + ","; Span5.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Financial Limits Grid - Business Interruption ($)": strCtrlsIDs += txtBusinessInterruption.ClientID + ","; strMessages += "Please enter Financial Limits Grid - Business Interruption ($)" + ","; Span6.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "Financial Limits Grid - Total ($)": strCtrlsIDs += txtBuildingTotal.ClientID + ","; strMessages += "Please enter Financial Limits Grid - Total ($)" + ","; Span7.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
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

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_Building_GGKL : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Building_GGKL
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Building_GGKL"]);
        }
        set { ViewState["PK_Building_GGKL"] = value; }
    }

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal FK_Building_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Building_ID"]);
        }
        set { ViewState["FK_Building_ID"] = value; }
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
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Set Tab selection
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Property);

        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);

            PK_Building_GGKL = 0;
            FK_Building_ID = 0;

            if (Request.QueryString["build"] != null)
            {
                decimal decFK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["build"]), out decFK))
                    FK_Building_ID = decFK;
            }


            if (Request.QueryString["id"] != null)
            {
                decimal decPK;
                if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out decPK))
                    PK_Building_GGKL = decPK;
            }

            StrOperation = Convert.ToString(Request.QueryString["op"]);


            if (StrOperation != string.Empty && PK_Building_GGKL > 0)
            {
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                }
                else
                {
                    SetValidations();
                    // Bind Controls
                    BindDetailsForEdit();
                }
            }
            else
            {
                SetValidations();
                // don't show div for view mode
                dvView.Style["display"] = "none";
            }

            // Bind location information
            ucCtrlExposureInfo.PK_LU_Location = Convert.ToDecimal(Session["ExposureLocation"]);
            ucCtrlExposureInfo.BindExposureInfo();
            ucCtrlExposureInfo.SetRMLocationCode((int)FK_Building_ID);
        }
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
        dvSave.Visible = true;
        dvBack.Visible = false;
        Building_GGKL objBuilding_GGKL = new Building_GGKL(PK_Building_GGKL);
        txtDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_GGKL.Date);
        txtOperators_With_Demos.Text = string.Format("{0:N0}", objBuilding_GGKL.Operators_With_Demos);
        txtOperators_Without_Demos.Text = string.Format("{0:N0}", objBuilding_GGKL.Operators_Without_Demos);
        txtAll_Other_Associates.Text = string.Format("{0:N0}", objBuilding_GGKL.All_Other_Associates);
        txtNon_Employee_Demos.Text = string.Format("{0:N0}", objBuilding_GGKL.Non_Employee_Demos);
        txtDealer_Plates.Text = string.Format("{0:N0}", objBuilding_GGKL.Dealer_Plates);
        txtAssociates_Work_On_Vehicles.Text = string.Format("{0:N0}", objBuilding_GGKL.Associates_Work_On_Vehicles);
        txtNotes.Text = objBuilding_GGKL.Notes;
        txtTotal.Text = string.Format("{0:N0}", objBuilding_GGKL.Total);
        hdnTotal.Value = txtTotal.Text;
    }


    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = false;
        dvBack.Style["display"] = "block";

        Building_GGKL objBuilding_GGKL = new Building_GGKL(PK_Building_GGKL);
        lblDate.Text = clsGeneral.FormatDBNullDateToDisplay(objBuilding_GGKL.Date);
        lblOperators_With_Demos.Text = string.Format("{0:N0}", objBuilding_GGKL.Operators_With_Demos);
        lblOperators_Without_Demos.Text = string.Format("{0:N0}", objBuilding_GGKL.Operators_Without_Demos);
        lblAll_Other_Associates.Text = string.Format("{0:N0}", objBuilding_GGKL.All_Other_Associates);
        lblNon_Employee_Demos.Text = string.Format("{0:N0}", objBuilding_GGKL.Non_Employee_Demos);
        lblDealer_Plates.Text = string.Format("{0:N0}", objBuilding_GGKL.Dealer_Plates);
        lblAssociates_Work_On_Vehicles.Text = string.Format("{0:N0}", objBuilding_GGKL.Associates_Work_On_Vehicles);
        lblNotes.Text = objBuilding_GGKL.Notes;
        lblTotal.Text = string.Format("{0:N0}", objBuilding_GGKL.Total);
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
        Building_GGKL objBuilding_GGKL = new Building_GGKL();
        objBuilding_GGKL.PK_Building_GGKL = PK_Building_GGKL;
        objBuilding_GGKL.FK_Building_Id = FK_Building_ID;

        objBuilding_GGKL.Date = clsGeneral.FormatNullDateToStore(txtDate.Text);
        if (txtOperators_With_Demos.Text.Trim() != "") objBuilding_GGKL.Operators_With_Demos = Convert.ToInt32(txtOperators_With_Demos.Text.Trim().Replace(",",""));
        if (txtOperators_Without_Demos.Text.Trim() != "") objBuilding_GGKL.Operators_Without_Demos = Convert.ToInt32(txtOperators_Without_Demos.Text.Trim().Replace(",", ""));
        if (txtAll_Other_Associates.Text.Trim() != "") objBuilding_GGKL.All_Other_Associates = Convert.ToInt32(txtAll_Other_Associates.Text.Trim().Replace(",", ""));
        if (txtNon_Employee_Demos.Text.Trim() != "") objBuilding_GGKL.Non_Employee_Demos = Convert.ToInt32(txtNon_Employee_Demos.Text.Trim().Replace(",", ""));
        if (txtDealer_Plates.Text.Trim() != "") objBuilding_GGKL.Dealer_Plates = Convert.ToInt32(txtDealer_Plates.Text.Trim().Replace(",", ""));
        if (txtAssociates_Work_On_Vehicles.Text.Trim() != "") objBuilding_GGKL.Associates_Work_On_Vehicles = Convert.ToInt32(txtAssociates_Work_On_Vehicles.Text.Trim().Replace(",", ""));
        objBuilding_GGKL.Notes = txtNotes.Text.Trim();
        string strTotal = hdnTotal.Value;
        if (!string.IsNullOrEmpty(strTotal)) objBuilding_GGKL.Total = Convert.ToInt32(strTotal.Replace(",", ""));
        objBuilding_GGKL.Update_Date = DateTime.Now;
        objBuilding_GGKL.Updated_By = Convert.ToDecimal(clsSession.UserID);

        if (PK_Building_GGKL > 0)
            objBuilding_GGKL.Update();
        else
            PK_Building_GGKL = objBuilding_GGKL.Insert();

        //redirect back to the Property page
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&build=" + Request.QueryString["build"]);

    }
    protected void btnRevertReturn_Click(object sender, EventArgs e)
    {
        // redirect to Property page for view
        Response.Redirect("Property.aspx?loc=" + Encryption.Encrypt(Session["ExposureLocation"].ToString()) + "&build=" + Request.QueryString["build"]);
    }

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
                case "GGKL Renewal Information Date": strCtrlsIDs += txtDate.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Date" + ","; Span1.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information Operators With Demos": strCtrlsIDs += txtOperators_With_Demos.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Operators With Demos" + ","; Span2.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information Operators Without Demos  ": strCtrlsIDs += txtOperators_Without_Demos.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Operators Without Demos  " + ","; Span3.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information All Other Associates ": strCtrlsIDs += txtAll_Other_Associates.ClientID + ","; strMessages += "Please enter GGKL Renewal Information All Other Associates " + ","; Span4.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information Non-Employee Demos ": strCtrlsIDs += txtNon_Employee_Demos.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Non-Employee Demos " + ","; Span5.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information Number of Dealer Plates ": strCtrlsIDs += txtDealer_Plates.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Number of Dealer Plates " + ","; Span6.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information Number of Associates Who Work On Vehicles ": strCtrlsIDs += txtAssociates_Work_On_Vehicles.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Number of Associates Who Work On Vehicles " + ","; Span7.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
                case "GGKL Renewal Information Notes ": strCtrlsIDs += txtNotes.ClientID + ","; strMessages += "Please enter GGKL Renewal Information Notes " + ","; Span8.Style["display"] = "inline-block"; MenuAsterisk1.Style["display"] = "inline-block"; break;
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

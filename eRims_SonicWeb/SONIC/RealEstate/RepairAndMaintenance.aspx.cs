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
using Microsoft.VisualBasic;

public partial class SONIC_RealEstate_RepairAndMaintenance : clsBasePage
{

    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_RE_Repair_Maintenance
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_RE_Repair_Maintenance"]);
        }
        set { ViewState["PK_RE_Repair_Maintenance"] = value; }
    }
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    { 
        get { return Convert.ToString(clsSession.Str_RE_Operation); }
    }

    #endregion

    #region Page Events

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (clsSession.Current_RE_Information_ID > 0)
            {
                RealEstate_Info.PK_RE_Information = clsSession.Current_RE_Information_ID;
                RealEstate_Info.BindrRealEstateInfo();
                BindDropDownList();
                PK_RE_Repair_Maintenance = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_RE_Repair_Maintenance = index;
                    }
                }

                btnViewAudit.Visible = (PK_RE_Repair_Maintenance > 0);
                if (StrOperation != string.Empty)
                {
                    //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                    if (StrOperation == "view")
                    {
                        // Bind Controls
                        BindDetailsForView();
                    }
                    else
                    {
                        // check if user has only view rights and try to edit record.
                        if (App_Access == AccessType.View_Only)
                        {
                            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                        }
                        // Bind Controls
                        BindDetailsForEdit();
                    }
                }
                else
                {
                    // don't show div for view mode
                    dvView.Style["display"] = "none";
                }
            }
            else
            {
                Response.Redirect("RealEstateAddEdit.aspx", true);
            }
            SetValidations();
        }
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Lease);
    }

    #endregion

    #region Methods

    /// <summary>
    /// Bind All drop Down list
    /// </summary>
    private void BindDropDownList()
    {
        ComboHelper.FillResponsibleParty(new DropDownList[] { drpFK_LU_Responsibilie_Party_HVAC_Capital }, true);
        ComboHelper.FillResponsibleParty(new DropDownList[] { drpFK_LU_Responsibilie_Party_HVAC_Repairs }, true);
        ComboHelper.FillResponsibleParty(new DropDownList[] { drpFK_LU_Responsibilie_Party_Roof_Capital }, true);
        ComboHelper.FillResponsibleParty(new DropDownList[] { drpFK_LU_Responsibilie_Party_Roof_Repairs }, true);
        ComboHelper.FillResponsibleParty(new DropDownList[] { drpFK_LU_Responsibilie_Party_Other_Repairs }, true);
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Style["display"] = "none";
        dvEdit.Style["display"] = "block";

        RE_Repair_And_Maintenance objRE_Repair_Maintenance = new RE_Repair_And_Maintenance(PK_RE_Repair_Maintenance);
        drpFK_LU_Responsibilie_Party_HVAC_Capital.SelectedValue = Convert.ToString(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Capital);
        drpFK_LU_Responsibilie_Party_HVAC_Repairs.SelectedValue = Convert.ToString(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Repairs);
        drpFK_LU_Responsibilie_Party_Roof_Capital.SelectedValue = Convert.ToString(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Capital);
        drpFK_LU_Responsibilie_Party_Roof_Repairs.SelectedValue = Convert.ToString(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Repairs);
        drpFK_LU_Responsibilie_Party_Other_Repairs.SelectedValue = Convert.ToString(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Other_Repairs);
        txtMaintenance_Notes.Text = Convert.ToString(objRE_Repair_Maintenance.Maintenance_Notes);

    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        if (PK_RE_Repair_Maintenance > 0)
        {
            dvView.Style["display"] = "block";
            dvEdit.Style["display"] = "none";
            dvSave.Style["display"] = "none";

            RE_Repair_And_Maintenance objRE_Repair_Maintenance = new RE_Repair_And_Maintenance(PK_RE_Repair_Maintenance);
            lblFK_LU_Responsibilie_Party_HVAC_Capital.Text = objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Capital != null ? new LU_Responsible_Party(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Capital)).Description : "";
            lblFK_LU_Responsibilie_Party_HVAC_Repairs.Text = objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Repairs != null ? new LU_Responsible_Party(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Repairs)).Description : "";
            lblFK_LU_Responsibilie_Party_Roof_Capital.Text = objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Capital != null ? new LU_Responsible_Party(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Capital)).Description : "";
            lblFK_LU_Responsibilie_Party_Roof_Repairs.Text = objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Repairs != null ? new LU_Responsible_Party(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Repairs)).Description : "";
            lblFK_LU_Responsibilie_Party_Other_Repairs.Text = objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Other_Repairs != null ? new LU_Responsible_Party(Convert.ToDecimal(objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Other_Repairs)).Description : "";
            lblMaintenance_Notes.Text = Convert.ToString(objRE_Repair_Maintenance.Maintenance_Notes);
        }
        else
        {
            Response.Redirect("RealEstateAddEdit.aspx?id=" + Encryption.Encrypt(clsSession.Current_RE_Information_ID.ToString()) + "&pnl=5", true);
        }
    }

    /// <summary>
    /// set properties for save
    /// </summary>
    /// <param name="objRE_Repair_Maintenance"></param>
    private void setProperties(RE_Repair_And_Maintenance objRE_Repair_Maintenance)
    {
        objRE_Repair_Maintenance.PK_RE_Repair_Maintenance = PK_RE_Repair_Maintenance;
        objRE_Repair_Maintenance.FK_RE_Information = clsSession.Current_RE_Information_ID;
        objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Capital = drpFK_LU_Responsibilie_Party_HVAC_Capital.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Responsibilie_Party_HVAC_Capital.SelectedValue) : -1;
        objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_HVAC_Repairs = drpFK_LU_Responsibilie_Party_HVAC_Capital.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Responsibilie_Party_HVAC_Repairs.SelectedValue) : -1;
        objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Capital = drpFK_LU_Responsibilie_Party_HVAC_Capital.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Responsibilie_Party_Roof_Capital.SelectedValue) : -1;
        objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Roof_Repairs = drpFK_LU_Responsibilie_Party_Roof_Capital.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Responsibilie_Party_Roof_Repairs.SelectedValue) : -1;
        objRE_Repair_Maintenance.FK_LU_Responsibilie_Party_Other_Repairs = drpFK_LU_Responsibilie_Party_Other_Repairs.SelectedIndex > 0 ? Convert.ToDecimal(drpFK_LU_Responsibilie_Party_Other_Repairs.SelectedValue) : -1;
        objRE_Repair_Maintenance.Maintenance_Notes = txtMaintenance_Notes.Text;
        objRE_Repair_Maintenance.Update_Date = DateTime.Now;
        objRE_Repair_Maintenance.Updated_By = clsSession.UserID;
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
        RE_Repair_And_Maintenance objRE_Repair_Maintenance = new RE_Repair_And_Maintenance();
        setProperties(objRE_Repair_Maintenance);
        if (PK_RE_Repair_Maintenance > 0)
        {
            objRE_Repair_Maintenance.Update();
        }
        else
        {
            objRE_Repair_Maintenance.Insert();
        }

        if (Request.QueryString["loc"] != null)
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=6&op=" + clsSession.Str_RE_Operation, true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=6", true);
    }

    /// <summary>
    /// Handel Back Button event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["loc"] != null)
            Response.Redirect("Lease.aspx?loc=" + Request.QueryString["loc"] + "&pnl=6&op=" + clsSession.Str_RE_Operation, true);
        else
            Response.Redirect("RealEstateAddEdit.aspx?pnl=6", true);
    }

    #endregion

    #region Dynamic Validations

  private void SetValidations()
  {
      string strCtrlsIDs = "";
      string strMessages = "";

      #region "Rent Projections - Term Rent Schedule"
      DataTable dtFields = clsScreen_Validators.SelectByScreen(73).Tables[0];
      dtFields.DefaultView.RowFilter = "IsRequired = '1'";
      dtFields = dtFields.DefaultView.ToTable();

      MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

      foreach (DataRow drField in dtFields.Rows)
      {
          #region " set validation control IDs and messages "
          switch (Convert.ToString(drField["Field_Name"]))
          {
              case "HVAC Repairs":
                  strCtrlsIDs += drpFK_LU_Responsibilie_Party_HVAC_Repairs.ClientID + ",";
                  strMessages += "Please Select HVAC Repairs" + ",";
                  Span1.Style["display"] = "inline-block";
                  break;
              case "HVAC Capital":
                  strCtrlsIDs += drpFK_LU_Responsibilie_Party_HVAC_Capital.ClientID + ",";
                  strMessages += "Please select HVAC Capital" + ",";
                  Span5.Style["display"] = "inline-block";
                  break;
              case "Roof Repairs":
                  strCtrlsIDs += drpFK_LU_Responsibilie_Party_Roof_Repairs.ClientID + ",";
                  strMessages += "Please select Roof Repairs" + ",";
                  Span2.Style["display"] = "inline-block";
                  break;
              case "Roof Capital":
                  strCtrlsIDs += drpFK_LU_Responsibilie_Party_Roof_Capital.ClientID + ",";
                  strMessages += "Please select Roof Capital" + ",";
                  Span3.Style["display"] = "inline-block";
                  break;
              case "Other Repairs":
                  strCtrlsIDs += drpFK_LU_Responsibilie_Party_Other_Repairs.ClientID + ",";
                  strMessages += "Please select Other Repairs" + ",";
                  Span4.Style["display"] = "inline-block";
                  break;
              case "Maintenance Notes":
                  strCtrlsIDs += txtMaintenance_Notes.ClientID + ",";
                  strMessages += "Please enter Maintenance Notes" + ",";
                  Span7.Style["display"] = "inline-block";
                  break;
          }
          #endregion
      }
      strCtrlsIDs = strCtrlsIDs.TrimEnd(',');
      strMessages = strMessages.TrimEnd(',');

      hdnControlIDs.Value = strCtrlsIDs;
      hdnErrorMsgs.Value = strMessages;
      #endregion
  }

    #endregion

}
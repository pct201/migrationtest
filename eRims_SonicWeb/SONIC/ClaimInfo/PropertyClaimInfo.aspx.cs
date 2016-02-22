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

public partial class SONIC_PropertyClaimInfo : clsBasePage
{
    #region Private Variable and Property

    /// <summary>
    /// Denotes the DPD First Report ID
    /// </summary>
    public long PK_Property_Claims_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Property_Claims_ID"]);
        }
        set { ViewState["PK_Property_Claims_ID"] = value; }
    }

    /// <summary>
    /// Denotes the Property Building Affected ID
    /// </summary>
    public int PK_Prop_Claims_Building_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Prop_Claims_Building_ID"]);
        }
        set { ViewState["PK_Prop_Claims_Building_ID"] = value; }
    }

    /// <summary>
    /// Denotes the Property Witness Affected ID
    /// </summary>
    public int PK_Prop_Claims_Witness_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Prop_Claims_Witness_ID"]);
        }
        set { ViewState["PK_Prop_Claims_Witness_ID"] = value; }
    }

    /// <summary>
    /// Gets or sets PK_First_Report_Wizard_ID
    /// </summary>
    public int PK_First_Report_Wizard_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_First_Report_Wizard_ID"]);
        }
        set { ViewState["PK_First_Report_Wizard_ID"] = value; }
    }

    /// <summary>
    /// Get or set based on Claim ID
    /// </summary>
    public int FK_Property_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Property_FR_ID"]);
        }
        set { ViewState["FK_Property_FR_ID"] = value; }
    }

    /// <summary>
    /// Denotes first report number
    /// </summary>
    public decimal First_Report_Number
    {
        get
        {
            return clsGeneral.IsNull(ViewState["First_Report_Number"]) ? 0 : Convert.ToDecimal(ViewState["First_Report_Number"]);
        }
        set
        {
            ViewState["First_Report_Number"] = value;
        }
    }

    /// <summary>
    /// Gets or sets PK_Property_Claims_Proof_Of_Loss
    /// </summary>
    public decimal PK_Property_Claims_Proof_Of_Loss
    {
        get { return clsGeneral.GetInt(ViewState["PK_Property_Claims_Proof_Of_Loss"]); }
        set { ViewState["PK_Property_Claims_Proof_Of_Loss"] = value; }
    }

    /// <summary>
    /// Gets or sets Mode of page either View or Edit
    /// </summary>
    public string Mode
    {
        get { return Convert.ToString(ViewState["Mode"]); }
        set { ViewState["Mode"] = value; }
    }

    /// <summary>
    /// Gets or set Proof of loss data
    /// </summary>
    public DataTable Dt_ProofOfLossData
    {
        get { return (DataTable)ViewState["ProofOfLossData"]; }
        set { ViewState["ProofOfLossData"] = value; }
    }

    #endregion

    #region Events

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.Property);
        if (!IsPostBack)
        {
            #region General

            if (Request.QueryString["from"] != null && Request.QueryString["from"].ToUpper() == "PROPERTY")
            {
                Property_Claims property_Claims = new Property_Claims((int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"])));
                PK_Property_Claims_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                PK_First_Report_Wizard_ID = Convert.ToInt32(property_Claims.FK_First_Report_Wizard_ID);
            }
            else if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty && Request.QueryString["wz_id"] != null && Request.QueryString["wz_id"] != string.Empty)
            {
                try
                {
                    PK_Property_Claims_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    PK_First_Report_Wizard_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["wz_id"]));
                    clsSession.ClaimID_Diary = Request.QueryString["id"].ToString();
                    ucAttachment.FK_Table = PK_Property_Claims_ID;
                }
                catch
                {
                    Response.Redirect("ClaimInformationSearch.aspx");
                }
            }
            else
            {
                Response.Redirect("ClaimInformationSearch.aspx");
            }

            #endregion

            ComboHelper.FillState(new DropDownList[] { ddlB_State, ddlW_State }, 0, true);
            ComboHelper.FillSonicLocationNumberOnly(new DropDownList[] { ddlLocationNumber }, 0, true);
            FillProofOfLossType(new DropDownList[] { ddlProofOfLossType }, 0, false);

            BindPropertyClaimInfo();
            Mode = (Request.QueryString["Mode"] != null && Request.QueryString["Mode"] != string.Empty && !(Request.QueryString["Mode"] != "edit" && Request.QueryString["Mode"] != "view")) ? Request.QueryString["Mode"] : "view";
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
        if (Mode.ToUpper() == "EDIT")
            btnEdit.Visible = false;
        else
            btnEdit.Visible = true;
    }

    /// <summary>
    /// Used to Bind State DropDown
    /// </summary>
    /// <param name="dropDowns">Dropdown Lists</param>
    /// <param name="intID">used to selected a value using this param</param>
    /// <param name="addSelectAsFirstElement">Require to add "--Select--" as a first element of dropdown</param>
    public void FillProofOfLossType(DropDownList[] dropDowns, int intID, bool booladdSelectAsFirstElement)
    {
        DataSet dsData = ERIMS.DAL.LU_Partial_Final.SelectAllActive();
        foreach (DropDownList ddlToFill in dropDowns)
        {
            ddlToFill.Items.Clear();
            ddlToFill.DataTextField = "Desc";
            ddlToFill.DataValueField = "PK_LU_Partial_Final";
            ddlToFill.DataSource = dsData;
            ddlToFill.DataBind();
            if (booladdSelectAsFirstElement)
            {
                ddlToFill.Items.Insert(0, new ListItem("---Select---", "0"));
            }

            if (intID > 0)
            {
                ListItem lst = new ListItem();
                lst = ddlToFill.Items.FindByValue(intID.ToString());
                if (lst != null)
                {
                    lst.Selected = true;
                }
            }
        }
    }

    /// <summary>
    /// Handles event associated first number
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Click(object sender, EventArgs e)
    {
        DataSet ds = Property_FR.SelectByProperty_FR_Number(First_Report_Number);
        if (ds.Tables[0].Rows.Count > 0)
        {
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            Response.Redirect("../FirstReport/PropertyFirstReport.aspx?id=" + Encryption.Encrypt(ds.Tables[0].Rows[0]["PK_Property_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    /// <summary>
    /// Handles event when Add link is clicked for Notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
   { 
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_Property_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PropertyClaim.ToString());
    }

    #endregion

    #region Private Methods

    /// <summary>
    /// Binds property claim information
    /// </summary>
    protected void BindPropertyClaimInfo()
    {
        // get data for selected claim
        DataSet dsProperty_FR = Property_ClaimInfo.SelectByClaimID(PK_Property_Claims_ID);
        DataTable dtProperty_FR = dsProperty_FR.Tables[0];
        // if data is available
        if (dtProperty_FR.Rows.Count > 0)
        {
            DataRow drProperty_FR = dtProperty_FR.Rows[0];

            FK_Property_FR_ID = Convert.ToInt32(drProperty_FR["FK_Property_FR_ID"]);
            //Header Information
            lblClaimNumber.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
            lblLocationdba.Text = Convert.ToString(drProperty_FR["dba1"]);
            lnkAssociatedFirstReport.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);

            if (!string.IsNullOrEmpty(lnkAssociatedFirstReport.Text.Trim()))
                lnkAssociatedFirstReport.Text = "Prop-" + lnkAssociatedFirstReport.Text;

            decimal _FR_Number;
            if (decimal.TryParse(Convert.ToString(drProperty_FR["Property_FR_Number"]), out _FR_Number))
                First_Report_Number = _FR_Number;

            lblDateIncident.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));

            //Contact Information
            lblLocationRMNumber.Text = Convert.ToString(drProperty_FR["FK_Location_Code"]) + "-" + Convert.ToString(drProperty_FR["dba"]);
            lblAddress1.Text = Convert.ToString(drProperty_FR["Address_1"]);
            lblAddress2.Text = Convert.ToString(drProperty_FR["Address_2"]);
            lblCity.Text = Convert.ToString(drProperty_FR["City"]);
            lblState.Text = Convert.ToString(drProperty_FR["State"]);
            lblZip.Text = Convert.ToString(drProperty_FR["Zip_Code"]);

            lblClaimNumberAgain.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
            lblLocationDBAAgain.Text = drProperty_FR["FK_Contact"] == null && drProperty_FR["dba"] == null ? "" : drProperty_FR["FK_Contact"].ToString() + "-" + drProperty_FR["dba1"].ToString();
            lblEmployeeName.Text = Convert.ToString(drProperty_FR["Last_Name"]) + ", " + Convert.ToString(drProperty_FR["First_Name"]) + " " + Convert.ToString(drProperty_FR["Middle_Name"]);
            lblEmployeeAddress1.Text = Convert.ToString(drProperty_FR["Employee_Address_1"]);
            lblEmployeeAddress2.Text = Convert.ToString(drProperty_FR["Employee_Address_2"]);
            lblEmployeeCity.Text = Convert.ToString(drProperty_FR["Employee_City"]);
            lblEmployeeState.Text = Convert.ToString(drProperty_FR["Employee_State"]);
            lblEmployeeZip.Text = Convert.ToString(drProperty_FR["Employee_Zip_Code"]);
            lblEmployeeCellPhone.Text = Convert.ToString(drProperty_FR["Employee_Cell_Phone"]);
            lblEmployeeEmail.Text = Convert.ToString(drProperty_FR["Email"]);
            lblEmployeeWorkPhone.Text = Convert.ToString(drProperty_FR["Work_Phone"]);
            //lblEmployeeHomePhone.Text = Convert.ToString(drEmployee["Employee_Home_Phone"]);
            //lblTimetoContact.Text = Convert.ToString(drProperty_FR["Contact_Best_Time"]);
            //lblFax.Text = Convert.ToString(drProperty_FR["Contact_Fax"]);

            //PK_First_Report_Wizard_ID = drProperty_FR["PK_First_Report_Wizard_ID"] != DBNull.Value ? Convert.ToInt32(drProperty_FR["PK_First_Report_Wizard_ID"]) : 0;

            #region Edit Location Fields
            ListItem lstRLM = new ListItem();
            lstRLM = ddlLocationNumber.Items.FindByText(Convert.ToString(drProperty_FR["FK_Location_Code"]));
            //check list item if not null than list item selected = true
            if (lstRLM != null)
            {
                lstRLM.Selected = true;
            }

            txtLocationAddress1.Text = Convert.ToString(drProperty_FR["Address_1"]);
            txtLocationAddress2.Text = Convert.ToString(drProperty_FR["Address_2"]);
            txtLocationCity.Text = Convert.ToString(drProperty_FR["City"]);
            txtLocationState.Text = Convert.ToString(drProperty_FR["State"]);
            txtLocationZipCode.Text = Convert.ToString(drProperty_FR["Zip_Code"]);
            txtCostCenterdba.Text = Convert.ToString(drProperty_FR["dba1"]);
            txtContactName.Text = Convert.ToString(drProperty_FR["Last_Name"]) + ", " + Convert.ToString(drProperty_FR["First_Name"]) + " " + Convert.ToString(drProperty_FR["Middle_Name"]);
            //txtContact_Best_Time.Text = Convert.ToString(drProperty_FR["Contact_Best_Time"]);
            txtContactTelephoneNumber1.Text = Convert.ToString(drProperty_FR["Work_Phone"]);
            txtContactTelephoneNumber2.Text = Convert.ToString(drProperty_FR["Employee_Cell_Phone"]);
            //txtContactFaxNumber.Text = Convert.ToString(drProperty_FR["Contact_Fax"]);
            txtContactEmailAddress.Text = Convert.ToString(drProperty_FR["Email"]);
            txtCostCenterAddress1.Text = Convert.ToString(drProperty_FR["Employee_Address_1"]);
            txtCostCenterAddress2.Text = Convert.ToString(drProperty_FR["Employee_Address_2"]);
            txtCostCenterCity.Text = Convert.ToString(drProperty_FR["Employee_City"]);
            txtCostCenterState.Text = Convert.ToString(drProperty_FR["Employee_State"]);
            txtCostCenterZipCode.Text = Convert.ToString(drProperty_FR["Employee_Zip_Code"]);
            txtDate_Reported_To_Sonic.Text = drProperty_FR["Date_Reported_to_Sonic"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Reported_to_Sonic"]));

            #endregion

            lblDateofLoss.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));
            lblTimeofLoss.Text = Convert.ToString(drProperty_FR["Time_of_Loss"]);

            txtDate_Of_Loss.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));
            txtTime_Of_Loss.Text = Convert.ToString(drProperty_FR["Time_of_Loss"]);

            lblDateReportedtoSonic.Text = drProperty_FR["Date_Reported_to_Sonic"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Reported_to_Sonic"]));

            //Loss Information
            lblLossInfoTimeofLoss.Text = Convert.ToString(drProperty_FR["Time_of_Loss"]);
            txtDescriptionofLoss.Text = Convert.ToString(drProperty_FR["Description_of_Loss"]);
            txtDescription_of_Loss.Text = Convert.ToString(drProperty_FR["Description_of_Loss"]);

            gvBuildingAffected.DataSource = gvBUilding.DataSource = Property_Claims_Building.GetBuildingResultByPropertyID(PK_Property_Claims_ID);
            gvBuildingAffected.DataBind();
            gvBUilding.DataBind();

            gvWitnesses.DataSource = gvWitness.DataSource = Property_Claims_Witness.GetWitnessResultByPropertyID(PK_Property_Claims_ID);
            gvWitnesses.DataBind();
            gvWitness.DataBind();

            DataTable dtProofOfLoss = Property_Claims_Proof_Of_Loss.GetProofOfLossResultByPropertyID(PK_Property_Claims_ID);
            if (dtProofOfLoss.Rows.Count == 1)
            {
                dtProofOfLoss.Rows[0].Delete();
            }

            gvProofOfLoss.DataSource = gvProofOfLosses.DataSource = Dt_ProofOfLossData = dtProofOfLoss;
            gvProofOfLoss.DataBind();
            gvProofOfLosses.DataBind();

            #region Maintain CheckBox

            chkFire.Checked = chkFireEdit.Checked = drProperty_FR["Fire"].ToString().ToLower() == "true" ? true : false;
            chkDamageBySonicAssociates.Checked = chkPropertyDamagebySonicAssociateEdit.Checked = drProperty_FR["Property_Damage_by_Sonic_Associate"].ToString().ToLower() == "true" ? true : false;
            chkWindDamage.Checked = chkWindDamageEdit.Checked = drProperty_FR["Wind_Damage"].ToString().ToLower() == "true" ? true : false;
            chkHallDamage.Checked = chkHailDamageEdit.Checked = drProperty_FR["Hail_Damage"].ToString().ToLower() == "true" ? true : false;
            chkEarthMovement.Checked = chkEarthMovementEdit.Checked = drProperty_FR["Earth_Movement"].ToString().ToLower() == "true" ? true : false;
            chkFlood.Checked = chkFloodEdit.Checked = drProperty_FR["Flood"].ToString().ToLower() == "true" ? true : false;
            chkThirdPartyPropertyDamage.Checked = chkThirdPartyPropertyDamageEdit.Checked = drProperty_FR["Third_Party_Property_Damage"].ToString().ToLower() == "true" ? true : false;
            chkEnvironmetalLoss.Checked = chkEnvironmentalLossEdit.Checked = drProperty_FR["Environmental_Loss"].ToString().ToLower() == "true" ? true : false;
            chkVandalismtotheProperty.Checked = chkVandalismToThePropertyEdit.Checked = drProperty_FR["Vandalism_To_The_Property"].ToString().ToLower() == "true" ? true : false;
            chkTheftAssociateTools.Checked = chkTheftAssociateToolsEdit.Checked = drProperty_FR["Theft_Associate_Tools"].ToString().ToLower() == "true" ? true : false;
            chkTheftAllOther.Checked = chkTheftAllOtherEdit.Checked = drProperty_FR["Theft_All_Other"].ToString().ToLower() == "true" ? true : false;
            chkOther.Checked = chkOtherEdit.Checked = drProperty_FR["Other"].ToString().ToLower() == "true" ? true : false;

            #endregion

            lblDamageBuildingFacilitiesEstCost.Text = drProperty_FR["Damage_Building_Facilities_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Est_Cost"])) : "";
            lblDamageBuildingFacilitiesActualCost.Text = drProperty_FR["Damage_Building_Facilities_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Actual_Cost"])) : "";
            lblDamageEquipmentEstCost.Text = drProperty_FR["Damage_Equipment_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Equipment_Est_Cost"])) : "";
            lblDamageEquipmentActualCost.Text = drProperty_FR["Damage_Equipment_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Equipment_Actual_Cost"])) : "";
            lblDamageProductDamageEstCost.Text = drProperty_FR["Damage_Product_Damage_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Est_Cost"])) : "";
            lblDamageProductDamageActualCost.Text = drProperty_FR["Damage_Product_Damage_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Actual_Cost"])) : "";
            lblDamagePartsEstCost.Text = drProperty_FR["Damage_Parts_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Parts_Est_Cost"])) : "";
            lblDamagePartsActualCost.Text = drProperty_FR["Damage_Parts_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Parts_Actual_Cost"])) : "";
            lblDamageSalvageCleanupEstCost.Text = drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"])) : "";
            lblDamageSalvageCleanupActualCost.Text = drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"])) : "";
            lblDamageDecontaminationEstCost.Text = drProperty_FR["Damage_Decontamination_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Est_Cost"])) : "";
            lblDamageDecontaminationActualCost.Text = drProperty_FR["Damage_Decontamination_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Actual_Cost"])) : "";
            lblDamageElectronicDataEstCost.Text = drProperty_FR["Damage_Electronic_Data_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Est_Cost"])) : "";
            lblDamageElectronicDataActualCost.Text = drProperty_FR["Damage_Electronic_Data_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Actual_Cost"])) : "";
            lblDamageServiceInterruptionEstCost.Text = drProperty_FR["Damage_Service_Interruption_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Est_Cost"])) : "";
            lblDamageServiceInterruptionActualCost.Text = drProperty_FR["Damage_Service_Interruption_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Actual_Cost"])) : "";
            lblDamagePayrollEstCost.Text = drProperty_FR["Damage_Payroll_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Payroll_Est_Cost"])) : "";
            lblDamagePayrollActualCost.Text = drProperty_FR["Damage_Payroll_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Payroll_Actual_Cost"])) : "";
            lblDamageLossofSalesEstCost.Text = drProperty_FR["Damage_Loss_of_Sales_Est_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Est_Cost"])) : "";
            lblDamageLossofSalesActualCost.Text = drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"])) : "";
            lblTotalActualCoat.Text = drProperty_FR["TotalActualCost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["TotalActualCost"])) : "";
            lblTotalEstimatedCost.Text = drProperty_FR["TotalEstCost"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drProperty_FR["TotalEstCost"])) : "";

            #region Damage Textbox binding for Editing
            txtDamage_Building_Facilities_Est_Cost.Text = drProperty_FR["Damage_Building_Facilities_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Est_Cost"])) : "";
            txtDamage_Building_Facilities_Actual_Cost.Text = drProperty_FR["Damage_Building_Facilities_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Building_Facilities_Actual_Cost"])) : "";
            txtDamage_Equipment_Est_Cost.Text = drProperty_FR["Damage_Equipment_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Equipment_Est_Cost"])) : "";
            txtDamage_Equipment_Actual_Cost.Text = drProperty_FR["Damage_Equipment_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Equipment_Actual_Cost"])) : "";
            txtDamage_Product_Damage_Est_Cost.Text = drProperty_FR["Damage_Product_Damage_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Est_Cost"])) : "";
            txtDamage_Product_Damage_Actual_Cost.Text = drProperty_FR["Damage_Product_Damage_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Product_Damage_Actual_Cost"])) : "";
            txtDamage_Parts_Est_Cost.Text = drProperty_FR["Damage_Parts_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Parts_Est_Cost"])) : "";
            txtDamage_Parts_Actual_Cost.Text = drProperty_FR["Damage_Parts_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Parts_Actual_Cost"])) : "";
            txtDamage_Salvage_Cleanup_Est_Cost.Text = drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Est_Cost"])) : "";
            txtDamage_Salvage_Cleanup_Actual_Cost.Text = drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Salvage_Cleanup_Actual_Cost"])) : "";
            txtDamage_Decontamination_Est_Cost.Text = drProperty_FR["Damage_Decontamination_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Est_Cost"])) : "";
            txtDamage_Decontamination_Actual_Cost.Text = drProperty_FR["Damage_Decontamination_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Decontamination_Actual_Cost"])) : "";
            txtDamage_Electronic_Data_Est_Cost.Text = drProperty_FR["Damage_Electronic_Data_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Est_Cost"])) : "";
            txtDamage_Electronic_Data_Actual_Cost.Text = drProperty_FR["Damage_Electronic_Data_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Electronic_Data_Actual_Cost"])) : "";
            txtDamage_Service_Interruption_Est_Cost.Text = drProperty_FR["Damage_Service_Interruption_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Est_Cost"])) : "";
            txtDamage_Service_Interruption_Actual_Cost.Text = drProperty_FR["Damage_Service_Interruption_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Service_Interruption_Actual_Cost"])) : "";
            txtDamage_Payroll_Est_Cost.Text = drProperty_FR["Damage_Payroll_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Payroll_Est_Cost"])) : "";
            txtDamage_Payroll_Actual_Cost.Text = drProperty_FR["Damage_Payroll_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Payroll_Actual_Cost"])) : "";
            txtDamage_Loss_of_Sales_Est_Cost.Text = drProperty_FR["Damage_Loss_of_Sales_Est_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Est_Cost"])) : "";
            txtDamage_Loss_of_Sales_Actual_Cost.Text = drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["Damage_Loss_of_Sales_Actual_Cost"])) : "";
            txtTotalActualCost.Text = drProperty_FR["TotalActualCost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["TotalActualCost"])) : "";
            txtTotalEstCost.Text = drProperty_FR["TotalEstCost"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drProperty_FR["TotalEstCost"])) : "";
            #endregion

            lblDateCleanupComplete.Text = txtDate_Cleanup_Complete.Text = drProperty_FR["Date_Cleanup_Complete"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Cleanup_Complete"]));
            lblDateRepairsComplete.Text = txtDate_Repairs_Complete.Text = drProperty_FR["Date_Repairs_Complete"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Repairs_Complete"]));
            lblDateFullServiceResumed.Text = txtDate_Full_Service_Resumed.Text = drProperty_FR["Date_Full_Service_Resumed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Full_Service_Resumed"]));
            lblDateFireProtectionServicesResumed.Text = txtDate_Fire_Protection_Services_Resumed.Text = drProperty_FR["Date_Fire_Protection_Services_Resumed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Fire_Protection_Services_Resumed"]));

            if (drProperty_FR["Security_Video_Surveillance"] != DBNull.Value)
            {
                if (Convert.ToBoolean(drProperty_FR["Security_Video_Surveillance"]))
                    rdo_Security_Video_Surveillance.SelectedValue = "1";
                else
                    rdo_Security_Video_Surveillance.SelectedValue = "0";
            }

            //Comments
            txtComments.Text = txtCommentsEdit.Text = Convert.ToString(drProperty_FR["Comments"]);
            lblDateReportComplete.Text = txtDate_Report_Completed.Text = drProperty_FR["Date_Report_Complete"] == DBNull.Value || Convert.ToString(drProperty_FR["Date_Report_Complete"]) == "" ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Report_Complete"]));
            lblDateClaimClosed.Text = txtDate_Claim_Closed.Text = drProperty_FR["Date_Claim_Closed"] == DBNull.Value || Convert.ToString(drProperty_FR["Date_Claim_Closed"]) == "" ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Claim_Closed"]));

            ctrlSonicNotes.PK_Property_CI_ID = PK_Property_Claims_ID;
            ctrlSonicNotes.CurrentClaimType = clsGeneral.Tables.PropertyClaim.ToString();
            ctrlSonicNotes.BindGridSonicNotes(PK_Property_Claims_ID, clsGeneral.Tables.PropertyClaim.ToString());

            //BindGridSonicNotes();
            //gvAttachments.DataSource = Property_FR_Attacments.SelectByFR_ID(PK_Property_CI_ID);
            //gvAttachments.DataBind();
        }

        DataSet dsFRW = First_Report_Wizard.GetInfoByWizardID(PK_First_Report_Wizard_ID, First_Report_Wizard.Tables.Property_FR, FK_Property_FR_ID);
        DataTable dtFRW = dsFRW.Tables[0];

        if (dtFRW.Rows.Count > 0)
        {
            DataRow drFRW = dtFRW.Rows[0];
            txtContact_Best_Time.Text = lblTimetoContact.Text = (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "";
            txtContactFaxNumber.Text = lblFax.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
        }
    }

    /// <summary>
    /// Used to Add BUilding Affetced record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddBuilding_Click(object sender, EventArgs e)
    {
        //if main Property Id that are used in Property_FR_Building table as Foreign kry. if this id is equal to 0 than no record is inserted
        if (PK_Property_Claims_ID > 0)
        {
            Property_Claims_Building objPFB = new Property_Claims_Building(PK_Prop_Claims_Building_ID);
            objPFB.Occupancy = txtB_Occupancy.Text;
            objPFB.Address_1 = txtB_Address_1.Text;
            objPFB.Address_2 = txtB_Address_2.Text;
            objPFB.City = txtB_City.Text;
            objPFB.State = (ddlB_State.SelectedIndex > 0) ? ddlB_State.SelectedValue.ToString() : "0";
            objPFB.Zip = txtB_Zip.Text;
            objPFB.FK_Property_Claims_ID = PK_Property_Claims_ID;
            if (PK_Prop_Claims_Building_ID > 0)
            {
                objPFB.Update();
                PK_Prop_Claims_Building_ID = 0;
                btnAddBuilding.Text = "Add";
            }
            else
            {
                PK_Prop_Claims_Building_ID = objPFB.Insert();
                PK_Prop_Claims_Building_ID = 0;
            }

            btnBuildingAudit.Visible = false;
            BindBuildingGrid();
            clearBuldingControls();
        }
    }

    /// <summary>
    /// Used to add new Witness Record
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAddWitness_Click(object sender, EventArgs e)
    {
        //if main Property Id that are used in Property_FR_Witness table as Foreign kry. if this id is equal to 0 than no record is inserted
        if (PK_Property_Claims_ID > 0)
        {
            Property_Claims_Witness objPFW = new Property_Claims_Witness(PK_Prop_Claims_Witness_ID);
            {
                objPFW.Name = txtW_Name.Text;
                objPFW.Address_1 = txtW_Address_1.Text;
                objPFW.Address_2 = txtW_Address_2.Text;
                objPFW.City = txtW_City.Text;
                objPFW.State = (ddlW_State.SelectedIndex > 0) ? ddlW_State.SelectedValue.ToString() : "0";
                objPFW.Zip = txtW_Zip.Text;
                objPFW.FK_Property_Claims_ID = PK_Property_Claims_ID;
                objPFW.Updated_By = Convert.ToDecimal(clsSession.UserID);
                if (PK_Prop_Claims_Witness_ID > 0)
                {
                    objPFW.Update();
                    PK_Prop_Claims_Witness_ID = 0;
                    btnAddWitness.Text = "Add";
                }
                else
                {
                    PK_Prop_Claims_Witness_ID = objPFW.Insert();
                    PK_Prop_Claims_Witness_ID = 0;
                }
                btnWitnessAudit.Visible = false;
                BindWitnessGrid();
                clearWitnessControls();
            }
        }
    }

    /// <summary>
    /// Used to Bind Location Information and Contact Details
    /// </summary>
    public void BindLocationandContactInfo()
    {
        DataSet dsFRW = null;
        DataTable dtFRW = dsFRW.Tables[0];
        foreach (DataRow drFRW in dtFRW.Rows)
        {
            #region Fill Location Information Controls
            //select value from Location Number Dropdown
            if (drFRW["Sonic_Location_Code"] != null)
            {
                ListItem lstRLM = new ListItem();
                lstRLM = ddlLocationNumber.Items.FindByText(drFRW["Sonic_Location_Code"].ToString());
                //check list item if not null than list item selected = true
                if (lstRLM != null)
                {
                    lstRLM.Selected = true;
                }
            }

            txtLocationAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
            txtLocationAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
            txtLocationCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
            txtLocationState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtLocationZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";
            #endregion

            #region Fill Contact Information Controls
            txtContactName.Text = (drFRW["EmployeeName"] != null) ? Convert.ToString(drFRW["EmployeeName"]) : "";
            txtContact_Best_Time.Text = (drFRW["Contact_Best_Time"] != null) ? Convert.ToString(drFRW["Contact_Best_Time"]) : "";
            txtContactTelephoneNumber1.Text = (drFRW["TelephoneNumber1"] != null) ? Convert.ToString(drFRW["TelephoneNumber1"]) : "";
            txtContactTelephoneNumber2.Text = (drFRW["TelephoneNumber2"] != null) ? Convert.ToString(drFRW["TelephoneNumber2"]) : "";
            txtContactFaxNumber.Text = (drFRW["Contact_Fax"] != null) ? Convert.ToString(drFRW["Contact_Fax"]) : "";
            txtContactEmailAddress.Text = (drFRW["FRWEmail"] != null) ? Convert.ToString(drFRW["FRWEmail"]) : "";
            txtCostCenterdba.Text = (drFRW["dba"] != null) ? Convert.ToString(drFRW["dba"]) : "";
            txtCostCenterAddress1.Text = (drFRW["Address_1"] != null) ? Convert.ToString(drFRW["Address_1"]) : "";
            txtCostCenterAddress2.Text = (drFRW["Address_2"] != null) ? Convert.ToString(drFRW["Address_2"]) : "";
            txtCostCenterCity.Text = (drFRW["City"] != null) ? Convert.ToString(drFRW["City"]) : "";
            txtCostCenterState.Text = new State(!string.IsNullOrEmpty(Convert.ToString(drFRW["State"])) ? Convert.ToDecimal(drFRW["State"]) : 0).FLD_state;
            txtCostCenterZipCode.Text = (drFRW["Zip_Code"] != null) ? Convert.ToString(drFRW["Zip_Code"]) : "";
            #endregion

            DisableEnableControls(false);
        }
    }

    /// <summary>
    /// Used to disable Location Information
    /// </summary>
    /// <param name="value"></param>
    public void DisableEnableControls(bool value)
    {
        ddlLocationNumber.Enabled = value;
        //ddlLegalEntity.Enabled = value;
        txtLocationAddress1.Enabled = value;
        txtLocationAddress2.Enabled = value;
        txtLocationCity.Enabled = value;
        txtLocationState.Enabled = value;
        txtLocationZipCode.Enabled = value;
        txtContactName.Enabled = value;
        txtContactTelephoneNumber1.Enabled = value;
        txtContactTelephoneNumber2.Enabled = value;
        txtContactEmailAddress.Enabled = value;
        txtCostCenterdba.Enabled = value;
        txtCostCenterAddress1.Enabled = value;
        txtCostCenterAddress2.Enabled = value;
        txtCostCenterCity.Enabled = value;
        txtCostCenterState.Enabled = value;
        txtCostCenterZipCode.Enabled = value;
    }

    #endregion

    #region Clear Building Affected and Witness Controls

    /// <summary>
    /// Use to Clear Building Controls
    /// </summary>
    public void clearBuldingControls()
    {
        txtB_Occupancy.Text = "";
        txtB_Address_1.Text = "";
        txtB_Address_2.Text = "";
        txtB_City.Text = "";
        ddlB_State.SelectedValue = "0";
        txtB_Zip.Text = "";
    }

    //Use to Clear Witness Controls
    public void clearWitnessControls()
    {
        txtW_Name.Text = "";
        txtW_Address_1.Text = "";
        txtW_Address_2.Text = "";
        txtW_City.Text = "";
        ddlW_State.SelectedValue = "0";
        txtW_Zip.Text = "";
    }

    /// <summary>
    /// Clear all Proof Of Loss Controls
    /// </summary>
    public void clearProofOfLossControls()
    {
        txtProofOfLossAmount.Text = "";
        txtProofOfLossDate.Text = "";

    }
    #endregion

    #region Building, Witness and Proof of Loss Grid Events

    /// <summary>
    /// Gridview Row Created Event - Building
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBUilding_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //Check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            //Check Link BUtton Found or Not
            if (lnkbtnRemove != null)
                lnkbtnRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //Check Link Button Found Or Not
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Grid View RowCommand EVent
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBUilding_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //check Command Name
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvBUilding.DataKeys[Index].Values["PK_Property_Claims_Building_ID"] != null) ? Convert.ToInt32(gvBUilding.DataKeys[Index].Values["PK_Property_Claims_Building_ID"]) : 0;
            //check if PK_ID > 0 than Delete selected row
            if (PK_ID > 0)
            {
                Property_Claims_Building.DeleteByPK(PK_ID);
            }
            //Bind Grid
            BindBuildingGrid();
        }
        else if (e.CommandName == "Edit")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            PK_Prop_Claims_Building_ID = (gvBUilding.DataKeys[Index].Values["PK_Property_Claims_Building_ID"] != null) ? Convert.ToInt32(gvBUilding.DataKeys[Index].Values["PK_Property_Claims_Building_ID"]) : 0;
            //check Property FR building ID if it is greater than 0  than set values to all building controls
            if (PK_Prop_Claims_Building_ID > 0)
            {
                btnAddBuilding.Text = "Update";
                btnBuildingAudit.Visible = true;
                Property_Claims_Building objPFB = new Property_Claims_Building(PK_Prop_Claims_Building_ID);
                txtB_Occupancy.Text = objPFB.Occupancy;
                txtB_Address_1.Text = objPFB.Address_1;
                txtB_Address_2.Text = objPFB.Address_2;
                txtB_City.Text = objPFB.City;
                //check string is null or empty. if false than select value to state Dropdown
                if (string.IsNullOrEmpty(objPFB.State) == false)
                {
                    ddlB_State.ClearSelection();
                    ListItem lstPFB_State = new ListItem();
                    lstPFB_State = ddlB_State.Items.FindByValue(objPFB.State.ToString());
                    if (lstPFB_State != null)
                        lstPFB_State.Selected = true;
                }
                txtB_Zip.Text = objPFB.Zip;
                btnBuildingAudit.Attributes.Add("onClick", "return AuditPopUpForBuilding(" + PK_Prop_Claims_Building_ID + ");");
            }
        }
    }

    /// <summary>
    /// Grid view Rowediting event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvBUilding_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Grid View Row Created Event - Witness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWitness_RowCreated(object sender, GridViewRowEventArgs e)
    {
        // Used to check Row Type
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton lnkbtnRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            //used to check Link button found or not
            if (lnkbtnRemove != null)
                lnkbtnRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);

            LinkButton lnkbtnEdit = (LinkButton)e.Row.FindControl("lnkEdit");
            //used to check Link Button Found or not.
            if (lnkbtnEdit != null)
                lnkbtnEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
        }
    }

    /// <summary>
    /// Grid View Row Command Event - Witness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWitness_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //used to check Command Name if it is "Remove" than remove the selected Row.
        if (e.CommandName == "Remove")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            int PK_ID = (gvWitness.DataKeys[Index].Values["PK_Property_Claims_Witness_ID"] != null) ? Convert.ToInt32(gvWitness.DataKeys[Index].Values["PK_Property_Claims_Witness_ID"]) : 0;
            //check if PK id grater than 0 than delete selected value
            if (PK_ID > 0)
            {
                Property_Claims_Witness.DeleteByPK(PK_ID);
            }
            //Bind Grid
            BindWitnessGrid();
        }
        else if (e.CommandName == "Edit")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            PK_Prop_Claims_Witness_ID = (gvWitness.DataKeys[Index].Values["PK_Property_Claims_Witness_ID"] != null) ? Convert.ToInt32(gvWitness.DataKeys[Index].Values["PK_Property_Claims_Witness_ID"]) : 0;
            //check id Witness id > 0 than set all witness fields
            if (PK_Prop_Claims_Witness_ID > 0)
            {
                btnAddWitness.Text = "Update";
                btnWitnessAudit.Visible = true;
                Property_Claims_Witness objPFW = new Property_Claims_Witness(PK_Prop_Claims_Witness_ID);
                txtW_Name.Text = objPFW.Name;
                txtW_Address_1.Text = objPFW.Address_1;
                txtW_Address_2.Text = objPFW.Address_2;
                txtW_City.Text = objPFW.City;
                //check string is null or empty for State. if false than selected State value to drodown
                if (string.IsNullOrEmpty(objPFW.State) == false)
                {
                    ListItem lstPFW_State = new ListItem();
                    ddlW_State.ClearSelection();
                    lstPFW_State = ddlW_State.Items.FindByValue(objPFW.State.ToString());
                    //check list item if not null than list item selected = true
                    if (lstPFW_State != null)
                        lstPFW_State.Selected = true;
                }
                txtW_Zip.Text = objPFW.Zip;
                btnWitnessAudit.Attributes.Add("onClick", "return AuditPopUpForWitness(" + PK_Prop_Claims_Witness_ID + ");");
            }
        }
    }

    /// <summary>
    /// Gridview Row Editing event - Witness
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWitness_RowEditing(object sender, GridViewEditEventArgs e)
    {
    }

    /// <summary>
    /// Grid View Proof of Loss Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProofOfLoss_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        PK_Property_Claims_Proof_Of_Loss = (gvProofOfLoss.DataKeys[index].Values["PK_Property_Claims_Proof_Of_Loss"] != null) ? Convert.ToInt32(gvProofOfLoss.DataKeys[index].Values["PK_Property_Claims_Proof_Of_Loss"]) : 0;
        if (PK_Property_Claims_Proof_Of_Loss > 0)
        {
            if (e.CommandName == "edit")
            {
                tblAddEditProofOfLoss.Style.Add("display", "block");
                Property_Claims_Proof_Of_Loss property_Claims_Proof_Of_Loss = new Property_Claims_Proof_Of_Loss(PK_Property_Claims_Proof_Of_Loss);
                txtProofOfLossDate.Text = clsGeneral.FormatDateToDisplay(property_Claims_Proof_Of_Loss.Date.Value);
                txtProofOfLossAmount.Text = Convert.ToString(property_Claims_Proof_Of_Loss.Amount);
                btnProofOfLossSave.Text = "Save";
                if (property_Claims_Proof_Of_Loss.FK_LU_Partial_Final != null)
                {
                    ddlProofOfLossType.ClearSelection();
                    ListItem lstType = new ListItem();
                    lstType = ddlProofOfLossType.Items.FindByValue(property_Claims_Proof_Of_Loss.FK_LU_Partial_Final.ToString());
                    if (lstType != null)
                        lstType.Selected = true;
                }
            }
            else if (e.CommandName == "remove")
            {
                Property_Claims_Proof_Of_Loss.Delete(PK_Property_Claims_Proof_Of_Loss);
            }

            BindProofOfLossGrid();
        }
    }

    /// <summary>
    /// Grid View Proof of Loss Row Data Bound Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProofOfLoss_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drProofOfLoss = Dt_ProofOfLossData.Rows[e.Row.RowIndex];
            LinkButton lnkDescription = (LinkButton)e.Row.FindControl("lnkDescription");
            LinkButton lnkAmount = (LinkButton)e.Row.FindControl("lnkAmount");
            LinkButton lnkDate = (LinkButton)e.Row.FindControl("lnkDate");
            LinkButton lnkRemove = (LinkButton)e.Row.FindControl("lnkRemoveProofOfLoss");
            Label lblDescription = (Label)e.Row.FindControl("lblDescription");
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            lnkRemove.CommandArgument = lnkDescription.CommandArgument = lnkAmount.CommandArgument = lnkDate.CommandArgument = Convert.ToString(e.Row.RowIndex);

            if (Convert.ToString(drProofOfLoss["PK_Property_Claims_Proof_Of_Loss"]) != null && Convert.ToString(drProofOfLoss["PK_Property_Claims_Proof_Of_Loss"]) == "0")
            {
                lblDescription.Text = "Total";
                lblDescription.Font.Bold = true;
                lblAmount.Font.Bold = true;
                lblAmount.Text = Convert.ToString(drProofOfLoss["Amount"]);
                lnkDate.Text = "";
                lnkDescription.Visible = false;
                lnkAmount.Visible = false;
                lnkRemove.Visible = false;
            }
            else
            {
                lnkDate.Text = Convert.ToDateTime(drProofOfLoss["Date"]) != null ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProofOfLoss["Date"])) : "";
                lnkAmount.Text = Convert.ToString(drProofOfLoss["Amount"]);
                lnkDescription.Text = Convert.ToString(drProofOfLoss["Desc"]);
                lblAmount.Visible = false;
                lblDescription.Visible = false;
            }
        }
    }

    /// <summary>
    /// Grid View Proof of Loss Row Editing Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProofOfLoss_RowEditing(object sender, GridViewEditEventArgs e)
    { }

    /// <summary>
    /// Grid View Proof of Losses Row Command Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvProofOfLosses_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRow drProofOfLoss = Dt_ProofOfLossData.Rows[e.Row.RowIndex];
            Label lblDescription = (Label)e.Row.FindControl("lblDescription");
            Label lblAmount = (Label)e.Row.FindControl("lblAmount");
            Label lblDate = (Label)e.Row.FindControl("lblDate");

            if (Convert.ToString(drProofOfLoss["PK_Property_Claims_Proof_Of_Loss"]) != null && Convert.ToString(drProofOfLoss["PK_Property_Claims_Proof_Of_Loss"]) == "0")
            {
                lblDescription.Text = "Total";
                lblDescription.Font.Bold = true;
                lblAmount.Font.Bold = true;
                lblAmount.Text = Convert.ToString(drProofOfLoss["Amount"]);
                lblDate.Text = "";
            }
            else
            {
                lblDate.Text = Convert.ToDateTime(drProofOfLoss["Date"]) != null ? clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProofOfLoss["Date"])) : "";
                lblAmount.Text = Convert.ToString(drProofOfLoss["Amount"]);
                lblDescription.Text = Convert.ToString(drProofOfLoss["Desc"]);
            }
        }
    }
    
    #endregion

    #region Building Affected and Witness Grid View Bind

    /// <summary>
    /// Used to Bind a Building Grid
    /// </summary>
    public void BindBuildingGrid()
    {
        if (PK_Property_Claims_ID > 0)
        {
            DataTable dtBuilding = Property_Claims_Building.GetBuildingResultByPropertyID(PK_Property_Claims_ID);
            gvBUilding.DataSource = dtBuilding;
            gvBUilding.DataBind();
        }
    }

    /// <summary>
    /// Used to Bind Witness Grid
    /// </summary>
    public void BindWitnessGrid()
    {
        if (PK_Property_Claims_ID > 0)
        {
            DataTable dtWitness = Property_Claims_Witness.GetWitnessResultByPropertyID(PK_Property_Claims_ID);
            gvWitness.DataSource = dtWitness;
            gvWitness.DataBind();
        }
    }

    /// <summary>
    /// Used to bind Proof of loss grid
    /// </summary>
    public void BindProofOfLossGrid()
    {
        if (PK_Property_Claims_ID > 0)
        {
            DataTable dtProofOfLoss = Property_Claims_Proof_Of_Loss.GetProofOfLossResultByPropertyID(PK_Property_Claims_ID);
            if (dtProofOfLoss.Rows.Count == 1)
            {
                dtProofOfLoss.Rows[0].Delete();
            }

            gvProofOfLoss.DataSource = gvProofOfLosses.DataSource = Dt_ProofOfLossData = dtProofOfLoss;
            gvProofOfLoss.DataBind();
        }
    }

    #endregion

    #region Save, Edit and Continue Button EVents
    
    /// <summary>
    /// Button Click Event - To Save Location Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLocationSave_Click(object sender, EventArgs e)
    {
        //Update Location information
        UpdateLocationInformation();
        //used to open Loss Information panel using ShowPanel Javascript function
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(2);", true);
    }

    /// <summary>
    /// Button Click Event - To Save Loss Details
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLossSave_Click(object sender, EventArgs e)
    {
        UpdateLossInformation();
        //setSonicHeaderInfo();
        ScriptManager.RegisterClientScriptBlock(Page, GetType(), "", "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Edit button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
        {
            try
            {
                Response.Redirect("PropertyClaimInfo.aspx?id=" + Request.QueryString["id"] + "&mode=edit&wz_id=" + Encryption.Encrypt(PK_First_Report_Wizard_ID.ToString()), false);
            }
            catch (Exception ex)
            {
                Response.Redirect("ClaimInformationSearch.aspx");
            }
        }
    }

    /// <summary>
    /// Used to Update Location Information
    /// </summary>
    public void UpdateLocationInformation()
    {
        //Update Fax Number to First_Report_Wizard Table
        First_Report_Wizard objFRW = new First_Report_Wizard(PK_First_Report_Wizard_ID);
        objFRW.Contact_Best_Time = txtContact_Best_Time.Text;
        objFRW.Contact_Fax = txtContactFaxNumber.Text;
        if (PK_First_Report_Wizard_ID > 0)
        {
            objFRW.Update();
        }

        Property_Claims objPro_FR = new Property_Claims(PK_Property_Claims_ID);
        objPro_FR.Date_Reported_to_Sonic = clsGeneral.FormatDateToStore(txtDate_Reported_To_Sonic);
        if (PK_Property_Claims_ID > 0)
        {
            objPro_FR.Update();
        }
    }

    /// <summary>
    /// Used to update loss of information data
    /// </summary>
    public void UpdateLossInformation()
    {
        Property_Claims objPro_FR = new Property_Claims(PK_Property_Claims_ID);
        objPro_FR.Date_Of_Loss = clsGeneral.FormatDateToStore(txtDate_Of_Loss);
        objPro_FR.Time_Of_Loss = txtTime_Of_Loss.Text;
        objPro_FR.Fire = chkFireEdit.Checked;
        objPro_FR.Property_Damage_by_Sonic_Associate = chkPropertyDamagebySonicAssociateEdit.Checked;
        objPro_FR.Wind_Damage = chkWindDamageEdit.Checked;
        objPro_FR.Environmental_Loss = chkEnvironmentalLossEdit.Checked;
        objPro_FR.Hail_Damage = chkHailDamageEdit.Checked;
        objPro_FR.Vandalism_To_The_Property = chkVandalismToThePropertyEdit.Checked;
        objPro_FR.Earth_Movement = chkEarthMovementEdit.Checked;
        objPro_FR.Theft_Associate_Tools = chkTheftAssociateToolsEdit.Checked;
        objPro_FR.Flood = chkFloodEdit.Checked;
        objPro_FR.Theft_All_Other = chkTheftAllOtherEdit.Checked;
        objPro_FR.Third_Party_Property_Damage = chkThirdPartyPropertyDamageEdit.Checked;
        objPro_FR.Other = chkOtherEdit.Checked;
        objPro_FR.Description_of_Loss = txtDescription_of_Loss.Text;
        objPro_FR.Damage_Building_Facilities_Est_Cost = string.IsNullOrEmpty(txtDamage_Building_Facilities_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Building_Facilities_Est_Cost.Text);
        objPro_FR.Damage_Building_Facilities_Actual_Cost = string.IsNullOrEmpty(txtDamage_Building_Facilities_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Building_Facilities_Actual_Cost.Text);
        objPro_FR.Damage_Equipment_Est_Cost = string.IsNullOrEmpty(txtDamage_Equipment_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Equipment_Est_Cost.Text);
        objPro_FR.Damage_Equipment_Actual_Cost = string.IsNullOrEmpty(txtDamage_Equipment_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Equipment_Actual_Cost.Text);
        objPro_FR.Damage_Product_Damage_Est_Cost = string.IsNullOrEmpty(txtDamage_Product_Damage_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Product_Damage_Est_Cost.Text);
        objPro_FR.Damage_Product_Damage_Actual_Cost = string.IsNullOrEmpty(txtDamage_Product_Damage_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Product_Damage_Actual_Cost.Text);
        objPro_FR.Damage_Parts_Est_Cost = string.IsNullOrEmpty(txtDamage_Parts_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Parts_Est_Cost.Text);
        objPro_FR.Damage_Parts_Actual_Cost = string.IsNullOrEmpty(txtDamage_Parts_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Parts_Actual_Cost.Text);
        objPro_FR.Damage_Salvage_Cleanup_Est_Cost = string.IsNullOrEmpty(txtDamage_Salvage_Cleanup_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Salvage_Cleanup_Est_Cost.Text);
        objPro_FR.Damage_Salvage_Cleanup_Actual_Cost = string.IsNullOrEmpty(txtDamage_Salvage_Cleanup_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Salvage_Cleanup_Actual_Cost.Text);
        objPro_FR.Damage_Decontamination_Est_Cost = string.IsNullOrEmpty(txtDamage_Decontamination_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Decontamination_Est_Cost.Text);
        objPro_FR.Damage_Decontamination_Actual_Cost = string.IsNullOrEmpty(txtDamage_Decontamination_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Decontamination_Actual_Cost.Text);
        objPro_FR.Damage_Electronic_Data_Est_Cost = string.IsNullOrEmpty(txtDamage_Electronic_Data_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Electronic_Data_Est_Cost.Text);
        objPro_FR.Damage_Electronic_Data_Actual_Cost = string.IsNullOrEmpty(txtDamage_Electronic_Data_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Electronic_Data_Actual_Cost.Text);
        objPro_FR.Damage_Service_Interruption_Est_Cost = string.IsNullOrEmpty(txtDamage_Service_Interruption_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Service_Interruption_Est_Cost.Text);
        objPro_FR.Damage_Service_Interruption_Actual_Cost = string.IsNullOrEmpty(txtDamage_Service_Interruption_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Service_Interruption_Actual_Cost.Text);
        objPro_FR.Damage_Payroll_Est_Cost = string.IsNullOrEmpty(txtDamage_Payroll_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Payroll_Est_Cost.Text);
        objPro_FR.Damage_Payroll_Actual_Cost = string.IsNullOrEmpty(txtDamage_Payroll_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Payroll_Actual_Cost.Text);
        objPro_FR.Damage_Loss_of_Sales_Est_Cost = string.IsNullOrEmpty(txtDamage_Loss_of_Sales_Est_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Loss_of_Sales_Est_Cost.Text);
        objPro_FR.Damage_Loss_of_Sales_Actual_Cost = string.IsNullOrEmpty(txtDamage_Loss_of_Sales_Actual_Cost.Text) ? 0 : Convert.ToDecimal(txtDamage_Loss_of_Sales_Actual_Cost.Text);
        objPro_FR.Date_Cleanup_Complete = clsGeneral.FormatDateToStore(txtDate_Cleanup_Complete);
        objPro_FR.Date_Repairs_Complete = clsGeneral.FormatDateToStore(txtDate_Repairs_Complete);
        objPro_FR.Date_Full_Service_Resumed = clsGeneral.FormatDateToStore(txtDate_Full_Service_Resumed);
        objPro_FR.Date_Fire_Protection_Services_Resumed = clsGeneral.FormatDateToStore(txtDate_Fire_Protection_Services_Resumed);
        if (rdo_Security_Video_Surveillance.SelectedValue == "1")
        {
            objPro_FR.Security_Video_Surveillance = true;
        }
        else if (rdo_Security_Video_Surveillance.SelectedValue == "0")
        {
            objPro_FR.Security_Video_Surveillance = false;
        }
        else
            objPro_FR.Security_Video_Surveillance = null;

        if (PK_Property_Claims_ID > 0)
        {
            objPro_FR.Update();
        }
    }

    /// <summary>
    /// Saves comments for property Claims
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveComments_Click(object sender, EventArgs e)
    {
        //Update Sonic Reported Date to Property Table
        Property_Claims objPro_FR = new Property_Claims(PK_Property_Claims_ID);
        objPro_FR.Date_Report_Complete = txtDate_Report_Completed.Text;
        objPro_FR.Date_Claim_Closed = txtDate_Claim_Closed.Text;
        objPro_FR.Comments = txtCommentsEdit.Text;
        if (PK_Property_Claims_ID > 0)
        {
            objPro_FR.Update();
        }

        ScriptManager.RegisterStartupScript(Page, GetType(), "", "javascript: ShowPanel(4);alert('Data updated successfully');", true);
    }

    /// <summary>
    /// add update proof of loss data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnProofOfLossSave_Click(object sender, EventArgs e)
    {
        if (PK_Property_Claims_ID > 0)
        {
            Property_Claims_Proof_Of_Loss property_Claims_Proof_Of_Loss = new Property_Claims_Proof_Of_Loss(PK_Property_Claims_Proof_Of_Loss);
            property_Claims_Proof_Of_Loss.Amount = string.IsNullOrEmpty(txtProofOfLossAmount.Text) ? 0 : Convert.ToDecimal(txtProofOfLossAmount.Text);
            property_Claims_Proof_Of_Loss.Date = clsGeneral.FormatDateToStore(txtProofOfLossDate);
            property_Claims_Proof_Of_Loss.FK_LU_Partial_Final = Convert.ToDecimal(ddlProofOfLossType.SelectedValue);
            property_Claims_Proof_Of_Loss.UpdateDate = DateTime.Now;
            property_Claims_Proof_Of_Loss.UpdatedBy = clsSession.UserID;
            property_Claims_Proof_Of_Loss.FK_Property_Claims_Id = PK_Property_Claims_ID;

            if (PK_Property_Claims_Proof_Of_Loss == 0)
            {
                property_Claims_Proof_Of_Loss.Insert();
            }
            else
            {
                property_Claims_Proof_Of_Loss.Update();
                PK_Property_Claims_Proof_Of_Loss = 0;
            }

            tblAddEditProofOfLoss.Style.Add("display", "none");
            BindProofOfLossGrid();
            clearProofOfLossControls();
        }
    }

    /// <summary>
    /// Display the proof of loss form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddProofOfLoss_Click(object sender, EventArgs e)
    {
        tblAddEditProofOfLoss.Style.Add("display", "block");
        PK_Property_Claims_Proof_Of_Loss = 0;
        btnProofOfLossSave.Text = "Add";
        clearProofOfLossControls();
    }

    /// <summary>
    /// Cancel the proof of loss data form
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnProofOfLossCancel_Click(object sender, EventArgs e)
    {
        tblAddEditProofOfLoss.Style.Add("display", "none");
        clearProofOfLossControls();
    }
    
    #endregion
}

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
    public long PK_Property_CI_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Property_CI_ID"]);
        }
        set { ViewState["PK_Property_CI_ID"] = value; }
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
        CtrlAttachment_Cliam.btnHandler += new Controls_ClaimAttachment_Attachment.OnButtonClick(Upload_File);
        // if page is loaded first time
        if (!IsPostBack)
        {
            #region General
            //Used to get PK id from QUery string
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {                   
                    //Get claim id from query string and store in viewstate.   
                    PK_Property_CI_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    clsSession.ClaimID_Diary = Request.QueryString["id"].ToString();
                    //set Page Mode as per User Access Type if it is View ONly than always open page in
                    //View Mode Only. else if the report is completed  than open page in View MOde Else in Edit MOde
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

            BindPropertyClaimInfo();

            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
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
        //DataSet ds = Property_FR.SelectByPKForClaim(Convert.ToDecimal(lnkAssociatedFirstReport.Text));
        if (ds.Tables[0].Rows.Count > 0)
        {
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            Response.Redirect("../FirstReport/PropertyFirstReport.aspx?id=" + Encryption.Encrypt(ds.Tables[0].Rows[0]["PK_Property_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }

    /// <summary>
    /// Handles rowcommand for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name
    //    if (e.CommandName == "EditRecord")
    //    {
    //        //Get the Claim Note ID
    //        Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_Property_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PropertyClaim.ToString());
    //    }
    //    else if (e.CommandName == "Remove")
    //    {
    //        // Delete record
    //        Claim_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

    //        BindGridSonicNotes();

    //        ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(3);", true);

    //    }
    //}

    /// <summary>
    /// Handles event when Add link is clicked for Notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        // redirect to claim notes page
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_Property_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PropertyClaim.ToString());
    }

    /// <summary>
    /// Handles View button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    // get selected Notes ID
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');
    //    // redirect to claim notes page with selected claim IDs
    //    Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_Property_CI_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.PropertyClaim.ToString());
    //}

    /// <summary>
    /// Handles Print button click event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    // get selected Notes ID
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');
    //    //display selected notes details in word doc
    //    clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Tables.PropertyClaim.ToString(), (long)PK_Property_CI_ID);
    //}

    #endregion

    #region Private Methods

    /// <summary>
    /// Binds property claim information
    /// </summary>
    protected void BindPropertyClaimInfo()
    {
        // get data for selected claim
        DataSet dsProperty_FR = Property_ClaimInfo.SelectByPK(PK_Property_CI_ID);
        DataTable dtProperty_FR = dsProperty_FR.Tables[0];
        // if data is available
        if (dtProperty_FR.Rows.Count > 0)
        {
            DataRow drProperty_FR = dtProperty_FR.Rows[0];

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
            lblTimetoContact.Text = Convert.ToString(drProperty_FR["Contact_Best_Time"]);
            lblFax.Text = Convert.ToString(drProperty_FR["Contact_Fax"]);

            lblDateofLoss.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));
            lblTimeofLoss.Text = Convert.ToString(drProperty_FR["Time_of_Loss"]);
            lblDateReportedtoSonic.Text = drProperty_FR["Date_Reported_to_Sonic"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Reported_to_Sonic"]));

            //Loss Information
            lblLossInfoTimeofLoss.Text = Convert.ToString(drProperty_FR["Time_of_Loss"]);
            txtDescriptionofLoss.Text = Convert.ToString(drProperty_FR["Description_of_Loss"]);

            gvBuildingAffected.DataSource = Property_FR_Building.GetBuildingResultByPropertyID(PK_Property_CI_ID);
            gvBuildingAffected.DataBind();

            gvWitnesses.DataSource = Property_FR_Witness.GetWitnessResultByPropertyID(PK_Property_CI_ID);
            gvWitnesses.DataBind();

            #region Maintain CheckBox
            if (drProperty_FR["Fire"].ToString().ToLower() == "true")
            {
                chkFire.Checked = true;
            }
            else
            {
                chkFire.Checked = false;
            }

            if (drProperty_FR["Wind_Damage"].ToString().ToLower() == "true")
            {
                chkWindDamage.Checked = true;
            }
            else
            {
                chkWindDamage.Checked = false;
            }
            if (drProperty_FR["Hail_Damage"].ToString().ToLower() == "true")
            {
                chkHallDamage.Checked = true;
            }
            else
            {
                chkHallDamage.Checked = false;
            }
            if (drProperty_FR["Earth_Movement"].ToString().ToLower() == "true")
            {
                chkEarthMovement.Checked = true;
            }
            else
            {
                chkEarthMovement.Checked = false;
            }
            if (drProperty_FR["Flood"].ToString().ToLower() == "true")
            {
                chkFlood.Checked = true;
            }
            else
            {
                chkFlood.Checked = false;
            }
            if (drProperty_FR["Third_Party_Property_Damage"].ToString().ToLower() == "true")
            {
                chkThirdPartyPropertyDamage.Checked = true;
            }
            else
            {
                chkThirdPartyPropertyDamage.Checked = false;
            }
            if (drProperty_FR["Property_Damage_by_Sonic_Associate"].ToString().ToLower() == "true")
            {
                chkDamageBySonicAssociates.Checked = true;
            }
            else
            {
                chkDamageBySonicAssociates.Checked = false;
            }
            if (drProperty_FR["Environmental_Loss"].ToString().ToLower() == "true")
            {
                chkEnvironmetalLoss.Checked = true;
            }
            else
            {
                chkEnvironmetalLoss.Checked = false;
            }
            if (drProperty_FR["Vandalism_To_The_Property"].ToString().ToLower() == "true")
            {
                chkVandalismtotheProperty.Checked = true;
            }
            else
            {
                chkVandalismtotheProperty.Checked = false;
            }
            if (drProperty_FR["Theft_Associate_Tools"].ToString().ToLower() == "true")
            {
                chkTheftAssociateTools.Checked = true;
            }
            else
            {
                chkTheftAssociateTools.Checked = false;
            }
            if (drProperty_FR["Theft_All_Other"].ToString().ToLower() == "true")
            {
                chkTheftAllOther.Checked = true;
            }
            else
            {
                chkTheftAllOther.Checked = false;
            }
            if (drProperty_FR["Other"].ToString().ToLower() == "true")
            {
                chkOther.Checked = true;
            }
            else
            {
                chkOther.Checked = false;
            }
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


            lblDateCleanupComplete.Text = drProperty_FR["Date_Cleanup_Complete"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Cleanup_Complete"]));
            lblDateRepairsComplete.Text = drProperty_FR["Date_Repairs_Complete"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Repairs_Complete"]));
            lblDateFullServiceResumed.Text = drProperty_FR["Date_Full_Service_Resumed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Full_Service_Resumed"]));
            lblDateFireProtectionServicesResumed.Text = drProperty_FR["Date_Fire_Protection_Services_Resumed"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Fire_Protection_Services_Resumed"]));

            //Comments
            txtComments.Text = Convert.ToString(drProperty_FR["Comments"]);
            lblDateReportComplete.Text = drProperty_FR["Date_Report_Complete"] == DBNull.Value || Convert.ToString(drProperty_FR["Date_Report_Complete"]) == "" ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Report_Complete"]));
            lblDateClaimClosed.Text = drProperty_FR["Date_Claim_Closed"] == DBNull.Value || Convert.ToString(drProperty_FR["Date_Claim_Closed"]) == "" ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Claim_Closed"]));

            CtlAttachDetail_Cliam.InitializeAttachmentDetails(clsGeneral.Tables.PropertyClaim, Convert.ToInt32(PK_Property_CI_ID), true, 3);
            CtlAttachDetail_Cliam.Bind();

            ctrlSonicNotes.PK_Property_CI_ID = PK_Property_CI_ID;
            ctrlSonicNotes.CurrentClaimType = clsGeneral.Tables.PropertyClaim.ToString();
            ctrlSonicNotes.BindGridSonicNotes(PK_Property_CI_ID, clsGeneral.Tables.PropertyClaim.ToString());
            //BindGridSonicNotes();
            //gvAttachments.DataSource = Property_FR_Attacments.SelectByFR_ID(PK_Property_CI_ID);
            //gvAttachments.DataBind();
        }
    }

    /// <summary>
    /// Used to upload the file
    /// </summary>
    /// <param name="strValue"></param>
    protected void Upload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachment_Cliam.Add(clsGeneral.Tables.PropertyClaim, Convert.ToInt32(PK_Property_CI_ID));
        // Used to Bind Grid with Attached Data
        CtlAttachDetail_Cliam.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(3);", true);
    }

    /// <summary>
    /// Binds the notes grid
    /// </summary>
    //private void BindGridSonicNotes()
    //{
    //    // select notes record for claim and bind the grid
    //    DataTable dtNotes = Claim_Notes.SelectByFK_Table(PK_Property_CI_ID, clsGeneral.Tables.PropertyClaim.ToString()).Tables[0];
    //    gvNotes.DataSource = dtNotes;
    //    gvNotes.DataBind();

    //    // make visible the print and view buttons if notes records are available
    //    btnView.Visible = dtNotes.Rows.Count > 0;
    //    btnPrint.Visible = dtNotes.Rows.Count > 0;
    //}

    #endregion
}

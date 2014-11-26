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

/// <summary>
/// Date : 14 NOV 2008
/// 
/// By : Amit Makwana
/// 
/// Purpose: 
/// To view the claim information for the type DPD
/// 
/// Functionality:
/// Gets the DPD Claim ID from querystring and provides the information 
/// for that in view mode
/// </summary>
public partial class SONIC_DPDClaimInfo : clsBasePage
{
    #region Private Variable and Property

    /// <summary>
    /// Denotes the PK DPD Claim ID
    /// </summary>
    public int PK_DPD_Claims_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_DPD_Claims_ID"]);
        }
        set { ViewState["PK_DPD_Claims_ID"] = value; }
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

    #region Page Events

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //Set Tab selection
        ClaimTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.DPD);
        CtrlAttachment_Cliam.btnHandler += new Controls_ClaimAttachment_Attachment.OnButtonClick(Upload_File);
        //used to check Page Post Back Event
        if (!IsPostBack)
        {
            #region General
            // check claim id is passed in querystring or not.
            if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
            {
                try
                {                   
                    //Get claim id from query string and store in viewstate.   
                    PK_DPD_Claims_ID = (int)clsGeneral.GetQueryStringID(Convert.ToString(Request.QueryString["id"]));
                    clsSession.ClaimID_Diary = Request.QueryString["id"].ToString();
                }
                catch
                {
                    Response.Redirect("DPDClaimInfo.aspx");
                }
            }
            else
            {
                //Response.Redirect("DPDClaimInfo.aspx");
            }

            #endregion

            CtlAttachDetail_Cliam.InitializeAttachmentDetails(clsGeneral.Tables.DPDClaim, PK_DPD_Claims_ID, true, 5);
            CtlAttachDetail_Cliam.Bind();
            //Bind the DPD Claim Information
            FillControls();
            ctrlSonicNotes.BindGridSonicNotes(PK_DPD_Claims_ID, clsGeneral.Claim_Tables.DPDClaim.ToString());
            
            //Set the first panel active
            int intPanle = 1;
            if (int.TryParse(Convert.ToString(Request.QueryString["pnl"]), out intPanle))
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(" + intPanle.ToString() + ");", true);
            else
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
        }
    }
    #endregion

    #region Controls Events
    /// <summary>
    /// Handles click event for Associated First report link in header
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsDPDFirstReport = DPD_FR.SelectByDPD_FR_Number(First_Report_Number);   

        //Check First report found or not
        if (dsDPDFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsDPDFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the DPD first report page
            Response.Redirect("../FirstReport/DPDFirstReport.aspx?id=" + Encryption.Encrypt(dsDPDFirstReport.Tables[0].Rows[0]["PK_DPD_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
    
    /// <summary>
    /// Used to upload file
    /// </summary>
    /// <param name="strValue"></param>
    protected void Upload_File(string strValue)
    {
        //Insert values into AL_FR_Attachment table
        CtrlAttachment_Cliam.Add(clsGeneral.Tables.DPDClaim, PK_DPD_Claims_ID);
        // Used to Bind Grid with Attached Data
        CtlAttachDetail_Cliam.Bind();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(5);", true);
    }

    /// <summary>
    /// Handles Add link click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNotesAdd_Click(object sender, EventArgs e)
    {
        // redirect to claim notes page
        Response.Redirect("ClaimNotes.aspx?FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString());
    }    

    /// <summary>
    /// Handles View button click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnView_Click(object sender, EventArgs e)
    //{
    //    // get selected notes IDs from grid
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');

    //    // redirect to claim notes page with selected IDs
    //    Response.Redirect("ClaimNotes.aspx?viewIDs=" + Encryption.Encrypt(strPK) + "&FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString());
    //}

    /// <summary>
    /// Handles Print button click event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void btnPrint_Click(object sender, EventArgs e)
    //{
    //    // get selected notes IDs from grid
    //    string strPK = "";
    //    foreach (GridViewRow gRow in gvNotes.Rows)
    //    {
    //        if (((CheckBox)gRow.FindControl("chkSelectSonicNotes")).Checked)
    //            strPK = strPK + ((HtmlInputHidden)gRow.FindControl("hdnPK")).Value + ",";
    //    }
    //    strPK = strPK.TrimEnd(',');

    //    // generage word doc
    //    clsPrintClaimNotes.PrintSelectedSonicNotes(strPK, clsGeneral.Claim_Tables.DPDClaim.ToString(), PK_DPD_Claims_ID);
    //}
    #endregion

    #region Gridview Events

    /// <summary>
    /// Handles Rowcommand event for Fraud list grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Make the Fraud Panel visible and Hide MVADamage panel
        pnlMVADamageDetail.Visible = false;
        pnlFraudDetail.Visible = true;

        //File the controls of the current row
        LinkButton lnkbtnMake = (LinkButton)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lnkFraudListMake");
        Label lblFraudListModel = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListModel");
        Label lblFraudListYear = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListYear");
        Label lblFraudListVIN = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListVIN");
        Label lblFraudListDamageEstimate = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListDamageEstimate");
        Label lblFraudListDrivenByAssociate = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListDrivenByAssociate");
        Label lblFraudListVehicleDrivenByCustomer = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListVehicleDrivenByCustomer");
        Label lblFraudListPoliceNotified = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListPoliceNotified");
        Label lblFraudListPoliceReportNumber = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListPoliceReportNumber");
        Label lblFraudListVehicleRecovered = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListVehicleRecovered");
        Label lblFraudListDealershipWishToTakePossession = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListDealershipWishToTakePossession");
        Label lblFraudListInvoiceAmount = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblFraudListInvoiceAmount");
        Label lblLossDescription = (Label)gvFraudList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblLossDescription");

        //Assign all values to the fileds in details panel
        lblFraudMake.Text = lnkbtnMake.Text;
        lblFraudModel.Text = lblFraudListModel.Text;
        lblFraudYear.Text = lblFraudListYear.Text;
        lblFraudVIN.Text = lblFraudListVIN.Text;
        lblFraudVehicleRecovered.Text = lblFraudListVehicleRecovered.Text.ToLower().Equals("true") ? "Yes" : "No";
        lblFraudDealershipWishToTakePossession.Text = lblFraudListDealershipWishToTakePossession.Text.ToLower().Equals("true") ? "Yes" : "No";
        lblFraudInvoiceAmount.Text = lblFraudListInvoiceAmount.Text == "" ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(lblFraudListInvoiceAmount.Text));
        lblPoliceNotified.Text = String.IsNullOrEmpty(lblFraudListPoliceNotified.Text) ? "" : Convert.ToBoolean(lblFraudListPoliceNotified.Text) ? "Yes" : "No";
        lblPoliceReportNumber.Text = lblFraudListPoliceReportNumber.Text;
        txtLossDescription.Text = lblLossDescription.Text;
    }

    /// <summary>
    /// Handles Rowcommand for transaction grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvWCTransList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Check the Command name
        if (e.CommandName == "ViewWCTransList")
        {
            //Make MVA Damage panel visible and hide fraud panel
            pnlMVADamageDetail.Visible = true;
            pnlFraudDetail.Visible = false;

            //Find all controls from the current grid row
            LinkButton lnkbtnMake = (LinkButton)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lnkWCTransListMake");
            Label lblWCTransListModel = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListModel");
            Label lblWCTransListYear = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListYear");
            Label lblWCTransListVIN = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListVIN");
            Label lblWCTransListDamageEstimate = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListDamageEstimate");
            Label lblWCTransListDrivenByAssociate = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListDrivenByAssociate");
            Label lblWCTransListVehicleDrivenByCustomer = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListVehicleDrivenByCustomer");
            Label lblWCTransListPoliceNotified = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListPoliceNotified");
            Label lblWCTransListPoliceReportNumber = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListPoliceReportNumber");
            Label lblWCTransListLossDescription = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListLossDescription");
            Label lblWCTransListAssociateCited = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListAssociateCited");
            Label lblWCTransListDescriptionOfCitation = (Label)gvWCTransList.Rows[Convert.ToInt32(e.CommandArgument)].FindControl("lblWCTransListDescriptionOfCitation");

            //Assign value to a contorl in detials panel
            lblWCTransMake.Text = lnkbtnMake.Text;
            lblWCTransModel.Text = lblWCTransListModel.Text;
            lblWCTransYear.Text = lblWCTransListYear.Text;
            lblWCTransVIN.Text = lblWCTransListVIN.Text;
            lblWCTransDrivenByAssociate.Text = lblWCTransListDrivenByAssociate.Text.ToLower().Equals("true") ? "Yes" : "No";
            lblWCTransDrivenbyCustomer.Text = lblWCTransListVehicleDrivenByCustomer.Text.ToLower().Equals("true") ? "Yes" : "No";
            lblWCTransPoliceNotified.Text = string.IsNullOrEmpty(lblWCTransListPoliceNotified.Text) ? "" : Convert.ToBoolean(lblWCTransListPoliceNotified.Text) ? "Yes" : "No";
            lblWCTransPoliceReportNumber.Text = lblWCTransListPoliceReportNumber.Text;
            txtWCTransLossDescription.Text = lblWCTransListLossDescription.Text;
            lblWCTransDamageAmount.Text = lblWCTransListDamageEstimate.Text == "" ? "" : String.Format("$ {0:N2}", Convert.ToDecimal(lblWCTransListDamageEstimate.Text));
            lblWCTransDescriptionOfCitation.Text = lblWCTransListDescriptionOfCitation.Text;
            lblWCTransAssociateCited.Text = lblWCTransListAssociateCited.Text.ToLower().Equals("true") ? "Yes" : "No";
        }
    }

    /// <summary>
    /// Handles event when row data is bound in fraud list
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvFraudList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //check Rowtype
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblFraudListVehicleRecovered = (Label)e.Row.FindControl("lblFraudListVehicleRecovered");

            //check Date_Of_Incident value from datset. if it is not null than display it in proper format.
            if (DataBinder.Eval(e.Row.DataItem, "Vehicle_Recovered") != DBNull.Value)
                lblFraudListVehicleRecovered.Text = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "Vehicle_Recovered")) ? "Yes" : "No";
        }
    }

    /// <summary>
    /// Handles Rowcommand event for notes grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void gvNotes_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    //check Command Name
    //    if (e.CommandName == "EditRecord")
    //    {
    //        //Get the Claim Note ID
    //        Response.Redirect("ClaimNotes.aspx?id=" + Encryption.Encrypt(e.CommandArgument.ToString()) + "&FK_Claim=" + Encryption.Encrypt(PK_DPD_Claims_ID.ToString()) + "&tbl=" + clsGeneral.Claim_Tables.DPDClaim.ToString());
    //    }
    //    else if (e.CommandName == "Remove")
    //    {
    //        // Delete record
    //        Claim_Notes.DeleteByPK(Convert.ToDecimal(e.CommandArgument));

    //        BindGridSonicNotes();

    //        ScriptManager.RegisterStartupScript(this, this.GetType(), System.DateTime.Now.ToString(), "javascrip:ShowPanel(4);", true);

    //    }
    //}
    #endregion

    #region Private Methods

    /// <summary>
    /// Function to Bind the DPD Claim Information
    /// </summary>
    protected void FillControls()
    {
        // get data for DPD claim 
        DataSet dsDPD_Claims = DPD_ClaimInfo.SelectViewClaim(PK_DPD_Claims_ID);

        // get data
        DataTable dtDPD_Claims = dsDPD_Claims.Tables[0];

        // if data is available
        if (dtDPD_Claims.Rows.Count > 0)
        {
            DataRow drDPD_Claims = dtDPD_Claims.Rows[0];

            // set values in page controls
            lblClaimNumber.Text = Convert.ToString(drDPD_Claims["Claim_Number"]);
            lblLocationdba.Text = Convert.ToString(drDPD_Claims["dba1"]);
            lblDateLoss.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
            lnkAssociatedFirstReport.Text = Convert.ToString(drDPD_Claims["FR_Number"]);
            if (!string.IsNullOrEmpty(lnkAssociatedFirstReport.Text.Trim()))
                lnkAssociatedFirstReport.Text = "DPD-" + lnkAssociatedFirstReport.Text;

            decimal _FR_Number;
            if (decimal.TryParse(Convert.ToString(drDPD_Claims["FR_Number"]), out _FR_Number))
                First_Report_Number = _FR_Number;

            lblDateofUpdate.Text = drDPD_Claims["Date_Of_Update"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Update"].ToString()));
            lblLocationRMNumber.Text = Convert.ToString(drDPD_Claims["FK_Loss_Location"]) + "-" + Convert.ToString(drDPD_Claims["dba"].ToString());
            lblAddress1.Text = Convert.ToString(drDPD_Claims["Loss_Address_1"]);
            lblAddress2.Text = Convert.ToString(drDPD_Claims["Loss_Address_2"]);
            lblCity.Text = Convert.ToString(drDPD_Claims["Loss_City"]);
            lblState.Text = Convert.ToString(drDPD_Claims["DPD_state"]);
            lblZip.Text = Convert.ToString(drDPD_Claims["Loss_Zip_Code"]);
            lblAccidentonCompanyProperty.Text = drDPD_Claims["On_Company_Property"] != DBNull.Value ? Convert.ToBoolean(drDPD_Claims["On_Company_Property"]) ? "Yes" : "No" : "";
            lblDateofLoss.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
            lblTimeofLoss.Text = Convert.ToString(drDPD_Claims["Time_of_Loss"]);
            lblDateReportedtoSonic.Text = drDPD_Claims["Date_Reported_To_Sonic"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Reported_To_Sonic"].ToString()));

            lblDataSource.Text = Convert.ToString(drDPD_Claims["DataSource"]);
            lblClaimNumberAgain.Text = Convert.ToString(drDPD_Claims["Claim_Number"]);
            lblLocationDBAAgain.Text = Convert.ToString(drDPD_Claims["FK_Contact"]) + "-" + Convert.ToString(drDPD_Claims["dba1"].ToString());
            lblEmployeeName.Text = Convert.ToString(drDPD_Claims["Last_Name"]) + ", " + Convert.ToString(drDPD_Claims["First_Name"]) + " " + Convert.ToString(drDPD_Claims["Middle_Name"]);
            lblEmployeeAddress1.Text = Convert.ToString(drDPD_Claims["Employee_Address_1"]);
            lblEmployeeAddress2.Text = Convert.ToString(drDPD_Claims["Employee_Address_2"]);
            lblEmployeeCity.Text = Convert.ToString(drDPD_Claims["Employee_City"]);
            lblEmployeeState.Text = Convert.ToString(drDPD_Claims["emp_state"]);
            lblEmployeeZip.Text = Convert.ToString(drDPD_Claims["Employee_Zip_Code"]);
            lblTimetoContact.Text = Convert.ToString(drDPD_Claims["Contact_Best_Time"]);
            lblEmployeeWorkPhone.Text = Convert.ToString(drDPD_Claims["Work_Phone"]);
            lblEmployeeCellPhone.Text = Convert.ToString(drDPD_Claims["Employee_Cell_Phone"]);
            lblFax.Text = Convert.ToString(drDPD_Claims["Contact_Fax"]);
            lblEmployeeEmail.Text = Convert.ToString(drDPD_Claims["Email"]);

            lblTheftMake.Text = Convert.ToString(drDPD_Claims["Theft_Make"]);
            lblTheftModel.Text = Convert.ToString(drDPD_Claims["Theft_Model"]);
            lblTheftYear.Text = Convert.ToString(drDPD_Claims["Theft_Year"]);
            lblTheftVIN.Text = Convert.ToString(drDPD_Claims["Theft_VIN"]);

            lblVehicleRecovered.Text = drDPD_Claims["Vehicle_Recovered"] == DBNull.Value ? "" : Convert.ToBoolean(drDPD_Claims["Vehicle_Recovered"]) ? "Yes" : "No";
            lblVehicleInvoiceValue.Text = Convert.ToString(drDPD_Claims["Vehicle_Invoice_Value"]);

            lblTheftDealershipWishToTakePossession.Text = drDPD_Claims["Theft_Dealership_Wish_To_Take_Possession"] == DBNull.Value ? "" : Convert.ToBoolean(drDPD_Claims["Theft_Dealership_Wish_To_Take_Possession"]) ? "Yes" : "No";
            lblTheftVehicleDamageAmount.Text = drDPD_Claims["Theft_Vehicle_Damage_Amount"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Theft_Vehicle_Damage_Amount"])) : "";

            lblPartialTheftNumberofVehiclesDamaged.Text = drDPD_Claims["Partial_Theft_Number_of_Vehicles_Damaged"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Partial_Theft_Number_of_Vehicles_Damaged"])) : "";
            lblParialTheftDamageEstimate.Text = drDPD_Claims["Parial_Theft_Damage_Estimate"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Parial_Theft_Damage_Estimate"])) : "";

            lblHailNumberOfVehiclesDamaged.Text = drDPD_Claims["Hail_Number_Of_Vehicles_Damaged"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drDPD_Claims["Hail_Number_Of_Vehicles_Damaged"])) : "";
            lblHailDamageEstimate.Text = drDPD_Claims["Hail_Damage_Estimate"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Hail_Damage_Estimate"])) : "";

            lblFloodNumberOfVehiclesDamaged.Text = drDPD_Claims["Flood_Number_Of_Vehicles_Damaged"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drDPD_Claims["Flood_Number_Of_Vehicles_Damaged"])) : "";
            lblFloodDamageEstimate.Text = drDPD_Claims["Flood_Damage_Estimate"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Flood_Damage_Estimate"])) : "";

            lblFireNumberOfVehiclesDamaged.Text = drDPD_Claims["Fire_Number_Of_Vehicles_Damaged"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drDPD_Claims["Fire_Number_Of_Vehicles_Damaged"])) : "";
            lblFireDamageEstimate.Text = drDPD_Claims["Fire_Damage_Estimate"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Fire_Damage_Estimate"])) : "";

            lblWindNumberOfVehiclesDamaged.Text = drDPD_Claims["Wind_Number_Of_Vehicles_Damaged"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drDPD_Claims["Wind_Number_Of_Vehicles_Damaged"])) : "";
            lblWindDamageEstimate.Text = drDPD_Claims["Wind_Damage_Estimate"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Wind_Damage_Estimate"])) : "";

            lblVandalismNumberofVehiclesDamaged.Text = drDPD_Claims["Vandalism_Number_of_Vehicles_Damaged"] != DBNull.Value ? String.Format("{0:N2}", Convert.ToDecimal(drDPD_Claims["Vandalism_Number_of_Vehicles_Damaged"])) : "";
            lblVandalismTotalEstimateofDamages.Text = drDPD_Claims["Vandalism_Total_Estimate_of_Damages"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drDPD_Claims["Vandalism_Total_Estimate_of_Damages"])) : "";

            txtComments.Text = Convert.ToString(drDPD_Claims["Comments"]);

            ctrlSonicNotes.PK_DPD_Claims_ID = PK_DPD_Claims_ID;
            ctrlSonicNotes.CurrentClaimType = clsGeneral.Claim_Tables.DPDClaim.ToString();
            ctrlSonicNotes.BindGridSonicNotes(PK_DPD_Claims_ID, clsGeneral.Claim_Tables.DPDClaim.ToString());

            DataSet dsViewVehicle = DPD_Claims_Vehicle_ClaimInfo.SelectByDPDClaim(PK_DPD_Claims_ID);

            #region MVASingle
            DataRow[] drMVASingle = dsViewVehicle.Tables[0].Select("Incident_Type=1");
            if (drMVASingle.Length != 0)
            {
                lblDPDClaimsVehicleMake.Text = Convert.ToString(drMVASingle[0]["Make"]);
                lblDPDClaimsVehicleModel.Text = Convert.ToString(drMVASingle[0]["Model"]);
                lblDPDClaimsVehicleYear.Text = Convert.ToString(drMVASingle[0]["Year"]);
                lblDPDClaimsVehicleVIN.Text = Convert.ToString(drMVASingle[0]["VIN#"]);
                lblDPDClaimsVehicleDamageEstimate.Text = drMVASingle[0]["Damage_Estimate"] != DBNull.Value ? String.Format("$ {0:N2}", Convert.ToDecimal(drMVASingle[0]["Damage_Estimate"])) : "";
                lblDPDClaimsVehicleDrivenByAssociate.Text = Convert.ToString(drMVASingle[0]["Driven_By_Associate"]).ToString().ToLower().Equals("true") ? "Yes" : "No";
                lblDPDClaimsVehicleDrivenByCustomer.Text = Convert.ToString(drMVASingle[0]["Vehicle_Driven_By_Customer"]).ToString().ToLower().Equals("true") ? "Yes" : "No";
                lblMVASinglePoliceNotified.Text = drMVASingle[0]["Police_Notified"] == DBNull.Value ? "" : Convert.ToBoolean(drMVASingle[0]["Police_Notified"]) ? "Yes" : "No";
                lblMVASinglePoliceReportNumber.Text = Convert.ToString(drMVASingle[0]["Police_Report_Number"]);
                txtMVASingleLossDescription.Text = Convert.ToString(drMVASingle[0]["Loss_Description"]);
            }
            #endregion

            #region Multiple
            DataTable dtWCTransList = new DataTable();
            dtWCTransList = dsViewVehicle.Tables[0].Clone();
            DataRow[] drWCTransList = dsViewVehicle.Tables[0].Select("Incident_Type=2");
            if (drWCTransList.Length != 0)
            {
                for (int i = 0; i < drWCTransList.Length; i++)
                {
                    DataRow dr = dtWCTransList.NewRow();
                    dr["Make"] = drWCTransList[i]["Make"];
                    dr["Model"] = drWCTransList[i]["Model"];
                    dr["Year"] = drWCTransList[i]["Year"];
                    dr["VIN#"] = drWCTransList[i]["VIN#"];
                    dr["Damage_Estimate"] = drWCTransList[i]["Damage_Estimate"];
                    dr["Driven_By_Associate"] = drWCTransList[i]["Driven_By_Associate"];
                    dr["Vehicle_Driven_By_Customer"] = drWCTransList[i]["Vehicle_Driven_By_Customer"];
                    dr["Police_Notified"] = drWCTransList[i]["Police_Notified"];
                    dr["Police_Report_Number"] = drWCTransList[i]["Police_Report_Number"];
                    dr["Loss_Description"] = drWCTransList[i]["Loss_Description"];
                    dr["Invoice_Value"] = drWCTransList[i]["Invoice_Value"];
                    dr["Vehicle_Recovered"] = drWCTransList[i]["Vehicle_Recovered"];
                    dr["Dealership_Wish_To_Take_Possession"] = drWCTransList[i]["Dealership_Wish_To_Take_Possession"];
                    dr["Associate_Cited"] = drWCTransList[i]["Associate_Cited"];
                    dr["Description_Of_Citation"] = drWCTransList[i]["Description_Of_Citation"];
                    dtWCTransList.Rows.Add(dr);
                }

            }
            gvWCTransList.DataSource = dtWCTransList;
            gvWCTransList.DataBind();
            #endregion

            #region Fraud
            DataTable dtFraudList = new DataTable();
            dtFraudList = dsViewVehicle.Tables[0].Clone();
            DataRow[] drFraudList = dsViewVehicle.Tables[0].Select("Incident_Type=3");

            if (drFraudList.Length != 0)
            {
                for (int i = 0; i < drFraudList.Length; i++)
                {
                    DataRow dr = dtFraudList.NewRow();
                    dr["Make"] = drFraudList[i]["Make"];
                    dr["Model"] = drFraudList[i]["Model"];
                    dr["Year"] = drFraudList[i]["Year"];
                    dr["VIN#"] = drFraudList[i]["VIN#"];
                    dr["Damage_Estimate"] = drFraudList[i]["Damage_Estimate"];
                    dr["Driven_By_Associate"] = drFraudList[i]["Driven_By_Associate"];
                    dr["Vehicle_Driven_By_Customer"] = drFraudList[i]["Vehicle_Driven_By_Customer"];
                    dr["Description_Of_Citation"] = drFraudList[i]["Description_Of_Citation"];
                    dr["Associate_Cited"] = drFraudList[i]["Associate_Cited"];
                    dr["Vehicle_Recovered"] = drFraudList[i]["Vehicle_Recovered"];
                    dr["Dealership_Wish_To_Take_Possession"] = drFraudList[i]["Dealership_Wish_To_Take_Possession"];
                    dr["Invoice_Value"] = drFraudList[i]["Invoice_Value"];
                    dr["Police_Notified"] = drFraudList[i]["Police_Notified"];
                    dr["Police_Report_Number"] = drFraudList[i]["Police_Report_Number"];
                    dr["Loss_Description"] = drFraudList[i]["Loss_Description"];
                    dtFraudList.Rows.Add(dr);
                }

            }
            gvFraudList.DataSource = dtFraudList;
            gvFraudList.DataBind();
            #endregion
        }
    }

    /// <summary>
    /// Used to bind the notes grid
    /// </summary>
    //private void BindGridSonicNotes()
    //{
    //    // get the data for claim notes and bind the notes grid
    //    DataTable dtNotes = Claim_Notes.SelectByFK_Table(PK_DPD_Claims_ID, clsGeneral.Claim_Tables.DPDClaim.ToString()).Tables[0];
    //    gvNotes.DataSource = dtNotes;
    //    gvNotes.DataBind();

    //    // show the View and Print buttons if notes records are available
    //    btnView.Visible = dtNotes.Rows.Count > 0;
    //    btnPrint.Visible = dtNotes.Rows.Count > 0;
    //}

    #endregion
}

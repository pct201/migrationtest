using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;

public partial class SONIC_ClaimNotes : clsBasePage
{
    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Claim_Notes
    {
        get
        {
            return clsGeneral.GetLong(ViewState["PK_Claim_Notes"]);
        }
        set { ViewState["PK_Claim_Notes"] = value; }
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
    /// Denotes the Foreign key 
    /// </summary>
    public decimal FK_Claim
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_Claim"]);
        }
        set { ViewState["FK_Claim"] = value; }
    }

    /// <summary>
    /// Denotes primary key of table for which diary record is to be managed
    /// </summary>
    public string FK_Table_Name
    {
        get { return clsGeneral.IsNull(ViewState["FK_Table_Name"]) ? string.Empty : Convert.ToString(ViewState["FK_Table_Name"]); }
        set { ViewState["FK_Table_Name"] = value; }
    }

    /// <summary>
    /// Denotes primary key of table for which diary record is to be managed
    /// </summary>
    public string ClaimNoteIDs
    {
        get { return clsGeneral.IsNull(ViewState["ClaimNoteIDs"]) ? string.Empty : Convert.ToString(ViewState["ClaimNoteIDs"]); }
        set { ViewState["ClaimNoteIDs"] = value; }
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
    /// Denotes primary key of table for which diary record is to be managed
    /// </summary>
    public string PageToRediect
    {
        get { return clsGeneral.IsNull(ViewState["PageToRediect"]) ? string.Empty : Convert.ToString(ViewState["PageToRediect"]); }
        set { ViewState["PageToRediect"] = value; }
    }


    /// <summary>
    /// Denotes the Foreign key 
    /// </summary>
    public decimal Location_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["Location_ID"]);
        }
        set { ViewState["Location_ID"] = value; }
    }
    #endregion

    #region "Page Events"
    /// <summary>
    /// Handles Page events
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // if page is loaded first time
        if (!Page.IsPostBack)
        {
            txtNote_Date.Focus();

            // Check Valid Claim ID is passed or not.
            if (CheckClaimInfo())
            {
                if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
                {
                    #region " List Notes "
                    ClaimNoteIDs = Encryption.Decrypt(Request.QueryString["viewIDs"]);
                    FK_Table_Name = Convert.ToString(Request.QueryString["tbl"]);

                    // Rebind Grid
                    rptNotes.DataSource = Claim_Notes.SelectByIDs(Encryption.Decrypt(Request.QueryString["viewIDs"]));
                    rptNotes.DataBind();

                    dvNotesList.Style["display"] = "block";
                    trButtons.Style["display"] = "none";

                    #endregion
                }
                else
                {
                    decimal _decPk = 0;

                    // Check Parameter ID is passed or Not. If not Passed then page in ADD Mode.
                    if (Request.QueryString["id"] != null)
                    {
                        if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"].ToString()), out _decPk))
                        {
                            PK_Claim_Notes = _decPk;
                        }
                    }

                    if (_decPk > 0)
                    {
                        // Set Page Mode
                        if (!string.IsNullOrEmpty(Request.QueryString["op"]))
                            StrOperation = Request.QueryString["op"].ToString();

                        // Check page Mode for Edit Or View
                        if (StrOperation == "view")
                            BindControlForView();
                        else
                            BindControlForEdit();

                    }
                    else
                    {
                        BindControlForAdd();
                    }
                }

                // Show Claim Information Bar
                BindWCClaimInfo();
            }
            else
                Response.Redirect("ClaimSearch.aspx");

            if (PK_Claim_Notes <= 0)
                btnLAAudit_View.Visible = false;
            SetValidations();
        }

        // set Selected Tab
        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
            ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.WC);
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())
            ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.AL);
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
            ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.DPD);
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
            ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.Property);
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())
            ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.PL);


    }

    #endregion

    #region "Events"

    /// <summary>
    /// Hanlde Save Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Claim_Notes objClaim_Notes = new Claim_Notes(PK_Claim_Notes);

        // set Control Value to Objects
        if (!string.IsNullOrEmpty(txtNote_Date.Text))
            objClaim_Notes.Note_Date = Convert.ToDateTime(txtNote_Date.Text.Trim());
        objClaim_Notes.Note = txtNotes.Text.Trim();
        objClaim_Notes.FK_Table = FK_Claim;
        objClaim_Notes.FK_Table_Name = FK_Table_Name;
        objClaim_Notes.Update_Date = DateTime.Now;
        objClaim_Notes.Updated_By = clsSession.UserID;

        // Check if Pk Is Greater Than 0 then Update Record else Add Record.
        if (PK_Claim_Notes > 0)
        {
            // Update Records
            objClaim_Notes.PK_Claim_Notes = PK_Claim_Notes;
            objClaim_Notes.Update();
        }
        else
        {
            // Insert New Record
            PK_Claim_Notes = objClaim_Notes.Insert();
        }

        // Set Page Mode In View

        if (!string.IsNullOrEmpty(Request.QueryString["loc"]) && !string.IsNullOrEmpty(Request.QueryString["page"]) && !string.IsNullOrEmpty(Request.QueryString["op"]))
        {
            PageToRediect = Request.QueryString["page"];
            Location_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"].ToString()));

            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_Claim_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=view" + "&page=" + PageToRediect + "&loc=" + Encryption.Encrypt(Location_ID.ToString()));
        }
        else
        {
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_Claim_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=view");
        }
    }

    /// <summary>
    /// handle Revert and Return Button Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevert_Click(object sender, EventArgs e)
    {
        // Back To Claim page.
        RedirectToBack();
    }

    /// <summary>
    /// handle Edit Button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        // Set Page Mode In Edit
        if (!string.IsNullOrEmpty(Request.QueryString["loc"]) && !string.IsNullOrEmpty(Request.QueryString["page"]) && !string.IsNullOrEmpty(Request.QueryString["op"]))
        {
            PageToRediect = Request.QueryString["page"];
            Location_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"].ToString()));

            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_Claim_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=edit" + "&page=" + PageToRediect + "&loc=" + Encryption.Encrypt(Location_ID.ToString()));
        }
        else
        {
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_Claim_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=edit");
        }
    }

    /// <summary>
    /// Print Seleted Notes Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {
        string strSelected = Encryption.Decrypt(Request.QueryString["viewIDs"]);
        clsPrintClaimNotes.PrintSelectedSonicNotes(strSelected, FK_Table_Name, (long)FK_Claim);
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Used to redirect back to the claim page
    /// </summary>
    private void RedirectToBack()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["loc"]) && !string.IsNullOrEmpty(Request.QueryString["page"]) && !string.IsNullOrEmpty(Request.QueryString["op"]))
        {
            if (Request.QueryString["page"].ToString() == "AP_AL")
            {
                Response.Redirect(AppConfig.SiteURL + "SONIC/Exposures/Asset_Protection.aspx?loc=" + Request.QueryString["loc"] + "&pnl=3" + "&op=" + Request.QueryString["op"]);
            }
            if (Request.QueryString["page"].ToString() == "AP_DPD")
            {
                Response.Redirect(AppConfig.SiteURL + "SONIC/Exposures/Asset_Protection.aspx?loc=" + Request.QueryString["loc"] + "&pnl=2" + "&op=" + Request.QueryString["op"]);
            }
        }
        // depending on the FK claim passed in the querystring redirect back to the claim page
        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
            Response.Redirect("WCClaimInfo.aspx?id=" + Encryption.Encrypt(FK_Claim.ToString()) + "&pnl=6");
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())
            Response.Redirect("PLClaimInfo.aspx?id=" + Encryption.Encrypt(FK_Claim.ToString()) + "&pnl=6");
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
            Response.Redirect("DPDClaimInfo.aspx?id=" + Encryption.Encrypt(FK_Claim.ToString()) + "&pnl=6");
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())
            Response.Redirect("ALClaimInfo.aspx?id=" + Encryption.Encrypt(FK_Claim.ToString()) + "&pnl=6");
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
            Response.Redirect("PropertyClaimInfo.aspx?id=" + Encryption.Encrypt(FK_Claim.ToString()) + "&pnl=3");
    }

    /// <summary>
    /// Bind Control In Edit Mode of screen
    /// </summary>
    private void BindControlForEdit()
    {
        // Show Edit Panel and Show View Panel
        dvEdit.Visible = true;
        dvView.Visible = false;
        btnSave.Visible = true;

        // create object
        Claim_Notes objClaim_Notes = new Claim_Notes(PK_Claim_Notes);

        // Bind Control value
        txtNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objClaim_Notes.Note_Date);
        FK_Table_Name = objClaim_Notes.FK_Table_Name;
        if (objClaim_Notes.Note != null)
            txtNotes.Text = objClaim_Notes.Note.Trim();

        txtNote_Date.Focus();
        dvEdit.Style["display"] = "block";
    }

    /// <summary>
    /// Bind Control In View Mode of screen
    /// </summary>
    private void BindControlForView()
    {
        // Show View Panel and Show Edit Panel
        dvView.Visible = true;
        dvEdit.Visible = false;
        btnEdit.Visible = true;
        btnSave.Visible = false;
        btnRevert.Text = "Return";
        btnRevert.OnClientClick = "return true";
        // create object
        Claim_Notes objClaim_Notes = new Claim_Notes(PK_Claim_Notes);
        FK_Table_Name = objClaim_Notes.FK_Table_Name;
        // Bind Control value
        lblNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objClaim_Notes.Note_Date);

        if (objClaim_Notes.Note != null)
            lblNotes.Text = objClaim_Notes.Note.Trim();
        dvView.Style["display"] = "block";
    }

    /// <summary>
    /// Used to set controls in view mode
    /// </summary>
    private void BindControlForAdd()
    {
        FK_Table_Name = Convert.ToString(Request.QueryString["tbl"]);
        // Show Edit Panel and hide View Panle
        dvEdit.Visible = true;
        dvView.Visible = false;
        // Show Claim Information Bar
        BindWCClaimInfo();
        dvEdit.Style["display"] = "block";

    }

    /// <summary>
    /// function which check Claim ID is Valid Or Not.
    /// </summary>
    /// <returns></returns>
    private bool CheckClaimInfo()
    {
        // Check parameter ClaimID is passed or not
        if (Request.QueryString["FK_Claim"] != null)
        {
            decimal _decFK_Claim;

            // Check ClaimID is Valid or Not.
            if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["FK_Claim"]), out _decFK_Claim))
            {
                FK_Claim = _decFK_Claim;
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Used to bind the basic claim information
    /// </summary>
    public void BindWCClaimInfo()
    {
        // WC claim 
        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
        {
            trWCHeader.Style.Add("display", "block");

            // get records by claim PK
            DataSet dsWorkers_Comp_Claims = WC_ClaimInfo.SelectByPK((long)FK_Claim);
            DataTable dtWorkers_Comp_Claims = dsWorkers_Comp_Claims.Tables[0];

            // if record is available
            if (dtWorkers_Comp_Claims.Rows.Count > 0)
            {
                // get the data and set valules to page controls
                DataRow drWorkers_Comp_Claims = dtWorkers_Comp_Claims.Rows[0];
                lblClaimNumber_WC.Text = Convert.ToString(drWorkers_Comp_Claims["Origin_Claim_Number"]);
                lblDateIncident1_WC.Text = drWorkers_Comp_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drWorkers_Comp_Claims["Date_Of_Accident"]));
                lblLocationdba_WC.Text = Convert.ToString(drWorkers_Comp_Claims["dba"]);
                lnkAssociatedFirstReport_WC.Text = Convert.ToString(drWorkers_Comp_Claims["Associated_First_Report"]);
                decimal _decFR_Number;

                // if WC_FR_Number is not null
                if (drWorkers_Comp_Claims["WC_FR_Number"] != DBNull.Value)
                {
                    if (decimal.TryParse(Convert.ToString(drWorkers_Comp_Claims["WC_FR_Number"]), out _decFR_Number))
                    {
                        // set WC_FR_Number for claim navigation
                        First_Report_Number = _decFR_Number;
                        lnkAssociatedFirstReport_WC.Text = "WC-" + Convert.ToString(_decFR_Number);
                        //Get the details of Associated first report from the report number.
                        int int_WC_FR = Convert.ToInt32(drWorkers_Comp_Claims["PK_WC_FR_ID"]);
                        int intInvID = Investigation.SelectPKByWc_FR_ID(int_WC_FR);
                        lnkInvestigation_WC.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?wc=" + int_WC_FR;

                        // if investigation ID is avaialble then set the link url 
                        if (intInvID > 0)
                        {
                            lnkInvestigation_WC.Text = intInvID.ToString();
                            lnkInvestigation_WC.PostBackUrl = AppConfig.SiteURL + "SONIC/FirstReport/Investigation.aspx?id=" + Encryption.Encrypt(intInvID.ToString()) + "&wc=" + Encryption.Encrypt(int_WC_FR.ToString());
                            lnkAddInvestigation_WC.Visible = false;
                        }
                    }
                }
                else
                {
                    lnkAddInvestigation_WC.Visible = false;
                }

                lblName_WC.Text = Convert.ToString(drWorkers_Comp_Claims["Employee_Name"]);
            }

        }
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())   // AL claim
        {
            trALHeader.Style.Add("display", "block");

            // get data by claim ID
            DataSet dsAuto_Loss_Claims = AL_ClaimInfo.SelectByPK((long)FK_Claim);
            DataTable dtAuto_Loss_Claims = dsAuto_Loss_Claims.Tables[0];

            // if record is avaialble
            if (dtAuto_Loss_Claims.Rows.Count > 0)
            {
                // get the data and set the claim data into controls
                DataRow drAuto_Loss_Claims = dtAuto_Loss_Claims.Rows[0];

                lblClaimNumber_AL.Text = Convert.ToString(drAuto_Loss_Claims["Origin_Claim_Number"]);
                lblDateIncident_AL.Text = drAuto_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drAuto_Loss_Claims["Date_Of_Accident"]));
                lblLocationdba_AL.Text = Convert.ToString(drAuto_Loss_Claims["dba"]);
                lnkAssociatedFirstReport_AL.Text = Convert.ToString(drAuto_Loss_Claims["Associated_First_Report"]);
                lblName_AL.Text = Convert.ToString(drAuto_Loss_Claims["Employee_Name"]);
            }
        }
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())  // DPD Claim
        {
            trDPDHeader.Style.Add("display", "block");

            // get data for the claim ID
            DataSet dsDPD_Claims = DPD_ClaimInfo.SelectViewClaim((long)FK_Claim);
            DataTable dtDPD_Claims = dsDPD_Claims.Tables[0];

            // if data is available
            if (dtDPD_Claims.Rows.Count > 0)
            {
                // get the data and set the values to page controls
                DataRow drDPD_Claims = dtDPD_Claims.Rows[0];
                lblClaimNumber_DPD.Text = Convert.ToString(drDPD_Claims["Origin_Claim_Number"]);
                lblLocationdba_DPD.Text = Convert.ToString(drDPD_Claims["dba"]);
                lblDateLoss_DPD.Text = drDPD_Claims["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drDPD_Claims["Date_Of_Loss"].ToString()));
                lnkAssociatedFirstReport_DPD.Text = Convert.ToString(drDPD_Claims["DPD_FR_Number"]);
                if (!string.IsNullOrEmpty(lnkAssociatedFirstReport_DPD.Text.Trim()))
                    lnkAssociatedFirstReport_DPD.Text = "DPD-" + lnkAssociatedFirstReport_DPD.Text;

                decimal _FR_Number;
                if (decimal.TryParse(Convert.ToString(drDPD_Claims["DPD_FR_Number"]), out _FR_Number))
                    First_Report_Number = _FR_Number;

            }
        }
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())   // PL Claim
        {
            trPLHeader.Style.Add("display", "block");

            // get data for the claim ID
            DataSet dsPremises_Loss_Claims = PL_ClaimInfo.SelectByPK((long)FK_Claim);
            DataTable dtPremises_Loss_Claims = dsPremises_Loss_Claims.Tables[0];

            // if data is avaialble
            if (dtPremises_Loss_Claims.Rows.Count > 0)
            {
                // get data and set values to page controls
                DataRow drPremises_Loss_Claims = dtPremises_Loss_Claims.Rows[0];
                lblClaimNumber_PL.Text = Convert.ToString(drPremises_Loss_Claims["Origin_Claim_Number"]);
                lblDateIncident_PL.Text = drPremises_Loss_Claims["Date_Of_Accident"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drPremises_Loss_Claims["Date_Of_Accident"]));
                lblLocationdba_PL.Text = Convert.ToString(drPremises_Loss_Claims["dba"]);
                lnkAssociatedFirstReport_PL.Text = Convert.ToString(drPremises_Loss_Claims["FR_Number"]);
                if (!string.IsNullOrEmpty(lnkAssociatedFirstReport_PL.Text.Trim()))
                    lnkAssociatedFirstReport_PL.Text = "PL-" + lnkAssociatedFirstReport_PL.Text;

                decimal _FR_Number;
                if (decimal.TryParse(Convert.ToString(drPremises_Loss_Claims["FR_Number"]), out _FR_Number))
                    First_Report_Number = _FR_Number;
                lblName_PL.Text = Convert.ToString(drPremises_Loss_Claims["Employee_Name"]);
            }
        }
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower()) // Property Claim
        {
            trPROPHeader.Style.Add("display", "block");

            // get data for claim ID
            DataSet dsProperty_FR = Property_ClaimInfo.SelectByPK((long)FK_Claim);
            DataTable dtProperty_FR = dsProperty_FR.Tables[0];

            // if data is available
            if (dtProperty_FR.Rows.Count > 0)
            {
                DataRow drProperty_FR = dtProperty_FR.Rows[0];

                //Header Information
                lblClaimNumber_Prop.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblLocationdba_Prop.Text = Convert.ToString(drProperty_FR["dba"]);
                lnkAssociatedFirstReport_Prop.Text = Convert.ToString(drProperty_FR["Property_FR_Number"]);
                lblDateIncident_Prop.Text = drProperty_FR["Date_Of_Loss"] == DBNull.Value ? "" : clsGeneral.FormatDateToDisplay(Convert.ToDateTime(drProperty_FR["Date_Of_Loss"]));
            }
        }
    }

    /// <summary>
    /// Handles Associate First Report link click event for WC claim
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_WC_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsWCFirstReport = WC_FR.SelectByWC_FR_Number(Convert.ToDecimal(First_Report_Number));

        //Check First report found or not
        if (dsWCFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsWCFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the Workers Compensation  first report page
            Response.Redirect("../FirstReport/WCFirstReport.aspx?id=" + Encryption.Encrypt(dsWCFirstReport.Tables[0].Rows[0]["PK_WC_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
    /// <summary>
    /// Handles Associate First Report link click event for AL claim
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_AL_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsALFirstReport = AL_FR.SelectByAL_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_AL.Text));

        //Check First report found or not
        if (dsALFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsALFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the auto loss first report page
            Response.Redirect("../FirstReport/ALFirstReport.aspx?id=" + Encryption.Encrypt(dsALFirstReport.Tables[0].Rows[0]["PK_AL_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
    /// <summary>
    /// Handles Associate First Report link click event for DPD claim
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_DPD_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsDPDFirstReport = DPD_FR.SelectByDPD_FR_Number(Convert.ToDecimal(First_Report_Number));

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
    /// Handles Associate First Report link click event for PL claim
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_PL_Click(object sender, EventArgs e)
    {
        //Get the details of Associated first report from the report number.
        DataSet dsPLFirstReport = PL_FR.SelectByPL_FR_Number(Convert.ToDecimal(First_Report_Number));

        //Check First report found or not
        if (dsPLFirstReport.Tables[0].Rows.Count > 0)
        {
            //set the wizard id in session
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(dsPLFirstReport.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);

            //redirect to the Premises Loss first report page
            Response.Redirect("../FirstReport/PLFirstReport.aspx?id=" + Encryption.Encrypt(dsPLFirstReport.Tables[0].Rows[0]["PK_PL_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
    }
    /// <summary>
    /// Handles Associate First Report link click event for Property claim
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAssociatedFirstReport_Prop_Click(object sender, EventArgs e)
    {
        DataSet ds = Property_FR.SelectByProperty_FR_Number(Convert.ToDecimal(lnkAssociatedFirstReport_Prop.Text));
        if (ds.Tables[0].Rows.Count > 0)
        {
            clsSession.First_Report_Wizard_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["FK_First_Report_Wizard_ID"]);
            Response.Redirect("../FirstReport/PropertyFirstReport.aspx?id=" + Encryption.Encrypt(ds.Tables[0].Rows[0]["PK_Property_FR_ID"].ToString()));
        }
        else
            Response.Redirect("ClaimInformationSearch.aspx");
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

        #region "Sonic Notes"
        DataTable dtFields = null;
        if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
            dtFields = clsScreen_Validators.SelectByScreen(33).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())
            dtFields = clsScreen_Validators.SelectByScreen(39).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
            dtFields = clsScreen_Validators.SelectByScreen(43).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
            dtFields = clsScreen_Validators.SelectByScreen(47).Tables[0];
        else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())
            dtFields = clsScreen_Validators.SelectByScreen(53).Tables[0];

        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Date of Note":
                    strCtrlsIDs += txtNote_Date.ClientID + ",";
                    strMessages += "Please Enter Date of Note" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Notes":
                    strCtrlsIDs += txtNotes.ClientID + ",";
                    strMessages += "Please Enter Notes" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
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

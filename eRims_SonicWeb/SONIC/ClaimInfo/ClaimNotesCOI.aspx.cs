using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;


public partial class SONIC_ClaimInfo_ClaimNotesCOI : System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_COI_Notes
    {
        get
        {
            return clsGeneral.GetLong(ViewState["PK_COI_Notes"]);
        }
        set { ViewState["PK_COI_Notes"] = value; }
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
            if (Request.QueryString["loc"].ToString() != string.Empty)
                Location_ID = Convert.ToDecimal(Request.QueryString["loc"].ToString());
            
            BindHeaderInfo();
            StrOperation = Convert.ToString(Request.QueryString["op"]);
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
                    rptNotes.DataSource = clsCOI_Notes.SelectByIDs(Encryption.Decrypt(Request.QueryString["viewIDs"]));
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
                            PK_COI_Notes = _decPk;
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
                //BindWCClaimInfo();
            }
            else
                Response.Redirect("ExposureSearch.aspx");

            if (PK_COI_Notes <= 0)
                btnLAAudit_View.Visible = false;
            //SetValidations();
        }

        //// set Selected Tab
        //if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.WCClaim.ToString().ToLower())
        //    ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.WC);
        //else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.ALClaim.ToString().ToLower())
        //    ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.AL);
        //else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.DPDClaim.ToString().ToLower())
        //    ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.DPD);
        //else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PropertyClaim.ToString().ToLower())
        //    ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.Property);
        //else if (FK_Table_Name.ToLower() == clsGeneral.Claim_Tables.PLClaim.ToString().ToLower())
        //    ctlTab.SetSelectedTab(Controls_ClaimTab_ClaimTab.Tab.PL);


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
        clsCOI_Notes objCOI_Notes = new clsCOI_Notes(PK_COI_Notes);

        // set Control Value to Objects
        if (!string.IsNullOrEmpty(txtNote_Date.Text))
            objCOI_Notes.Note_Date = Convert.ToDateTime(txtNote_Date.Text.Trim());
        objCOI_Notes.Note = txtNotes.Text.Trim();
        objCOI_Notes.FK_COIs = FK_Claim;
        objCOI_Notes.Update_Date = DateTime.Now;        
        objCOI_Notes.Updated_By = clsSession.UserID;

        // Check if Pk Is Greater Than 0 then Update Record else Add Record.
        if (PK_COI_Notes > 0)
        {
            // Update Records
            objCOI_Notes.PK_COI_Notes = PK_COI_Notes;
            objCOI_Notes.Update();
        }
        else
        {
            // Insert New Record
            objCOI_Notes.Created_Date = DateTime.Now;
            PK_COI_Notes = objCOI_Notes.Insert();
        }

        // Set Page Mode In View

        if (!string.IsNullOrEmpty(Request.QueryString["loc"]) && !string.IsNullOrEmpty(Request.QueryString["page"]) && !string.IsNullOrEmpty(Request.QueryString["op"]))
        {
            PageToRediect = Request.QueryString["page"];
            Location_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_COI_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=view" + "&page=" + PageToRediect + "&loc=" + Encryption.Encrypt(Location_ID.ToString()));
        }
        else
        {
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_COI_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=view&loc=" + Request.QueryString["loc"].ToString());
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

            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_COI_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=edit" + "&page=" + PageToRediect + "&loc=" + Encryption.Encrypt(Location_ID.ToString()));
        }
        else
        {
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_COI_Notes.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=edit&loc=" + Request.QueryString["loc"]);
        }
    }

    /// <summary>
    /// Print Seleted Notes Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {
        string strPK = "";
        if(ClaimNoteIDs != null)
            strPK = ClaimNoteIDs;
        clsPrintClaimNotesCOI.PrintSelectedSonicNotes(strPK, "COIs", (long)FK_Claim);
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Used to redirect back to the claim page
    /// </summary>
    private void RedirectToBack()
    {

        Response.Redirect(AppConfig.SiteURL + "COI/COIAddEdit.aspx?loc=" + Request.QueryString["loc"] + "&pnl=10" + "&op=" + StrOperation + "&id=" + Encryption.Encrypt(FK_Claim.ToString()));
        
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
        clsCOI_Notes objCOI_Notes = new clsCOI_Notes(PK_COI_Notes);

        // Bind Control value
        txtNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCOI_Notes.Note_Date);
        //  FK_Table_Name = objCOI_Notes.FK_Table_Name;
        if (objCOI_Notes.Note != null)
            txtNotes.Text = objCOI_Notes.Note.Trim();

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
        clsCOI_Notes objCOI_Notes = new clsCOI_Notes(PK_COI_Notes);
        //FK_Table_Name = objCOI_Notes.FK_Table_Name;
        // Bind Control value
        lblNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objCOI_Notes.Note_Date);

        if (objCOI_Notes.Note != null)
            lblNotes.Text = objCOI_Notes.Note.Trim();
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
        //BindWCClaimInfo();
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

    
   
    #endregion

    

    private void BindHeaderInfo()
    {
        if (!string.IsNullOrEmpty(Request.QueryString["FK_Claim"].ToString()))
        {
            COIs objCOI = new COIs(Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["FK_Claim"].ToString())));
            LU_Location objLocation = new LU_Location(Convert.ToDecimal(objCOI.FK_LU_Location_ID));
            COI_Insureds objInsured = new COI_Insureds(objCOI.FK_COI_Insureds);

            lblLocationName.Text = Convert.ToString(objLocation.dba);
            if (objLocation.Sonic_Location_Code < 0)
            {
                lblLocationNumber.Text = "";
            }
            else
                lblLocationNumber.Text = Convert.ToString(objLocation.Sonic_Location_Code);
            lblInsuredName.Text = Convert.ToString(objInsured.Insured_Name);
            lblIssueDate.Text = clsGeneral.FormatDate(objCOI.Issue_Date);
            lblEffectiveDate.Text = clsGeneral.FormatDate(objInsured.Date_Closed);
        }
    }
}
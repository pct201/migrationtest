using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;



public partial class SONIC_ClaimInfo_ClaimNotesEPMActionNotesRM : System.Web.UI.Page
{
    #region Properties

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_EPM_Action_Notes_RM
    {
        get
        {
            return clsGeneral.GetLong(ViewState["PK_EPM_Action_Notes_RM"]);
        }
        set { ViewState["PK_EPM_Action_Notes_RM"] = value; }
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

    public int LocationID
    {
        get { return Convert.ToInt32(ViewState["LocationId"]); }
        set { ViewState["LocationId"] = value; }
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
            //if (Request.QueryString["loc"].ToString() != string.Empty)
            //    Location_ID = Convert.ToDecimal(Request.QueryString["loc"].ToString());

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
                    rptNotes.DataSource = clsEPM_Action_Notes_RM.SelectByIDs(Encryption.Decrypt(Request.QueryString["viewIDs"]));
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
                            PK_EPM_Action_Notes_RM = _decPk;
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

            if (PK_EPM_Action_Notes_RM <= 0)
                btnLAAudit_View.Visible = false;
            //SetValidations();
        }

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
        clsEPM_Action_Notes_RM objEPM_Action_Notes_RM = new clsEPM_Action_Notes_RM(PK_EPM_Action_Notes_RM);
        clsEPM_Action_Notes ObjEPM_Action_Notes = new clsEPM_Action_Notes(Convert.ToInt32(FK_Claim));

        // set Control Value to Objects
        if (!string.IsNullOrEmpty(txtNote_Date.Text))
            objEPM_Action_Notes_RM.Note_Date = Convert.ToDateTime(txtNote_Date.Text.Trim());
        else
            objEPM_Action_Notes_RM.Note_Date = null;
        objEPM_Action_Notes_RM.Note = txtNotes.Text.Trim();

        if (!string.IsNullOrEmpty(ObjEPM_Action_Notes.PK_EPM_Action_Notes.ToString()))
            objEPM_Action_Notes_RM.FK_EPM_Action_Notes = ObjEPM_Action_Notes.PK_EPM_Action_Notes.Value;
        objEPM_Action_Notes_RM.Update_Date = DateTime.Now;
        objEPM_Action_Notes_RM.Updated_By = clsSession.UserID;

        if (objEPM_Action_Notes_RM.FK_EPM_Action_Notes > 0)
        {
            // Check if Pk Is Greater Than 0 then Update Record else Add Record.
            if (PK_EPM_Action_Notes_RM > 0)
            {
                // Update Records
                objEPM_Action_Notes_RM.PK_EPM_Action_Notes_RM = PK_EPM_Action_Notes_RM;
                objEPM_Action_Notes_RM.Update();
            }
            else
            {
                // Insert New Record
                objEPM_Action_Notes_RM.Created_Date = DateTime.Now;
                PK_EPM_Action_Notes_RM = objEPM_Action_Notes_RM.Insert();
            }
        }
        else
        {
            Response.Redirect(AppConfig.SiteURL + "/Sonic/Exposures/Project_Management.aspx?loc=" + Encryption.Encrypt(Request.QueryString["loc"]) + "&pnl=5" + "&op=" + StrOperation + "&id=" + Encryption.Encrypt(FK_Claim.ToString()));
        }
        // Set Page Mode In View

        if (!string.IsNullOrEmpty(Request.QueryString["loc"]) && !string.IsNullOrEmpty(Request.QueryString["page"]) && !string.IsNullOrEmpty(Request.QueryString["op"]))
        {
            PageToRediect = Request.QueryString["page"];
            Location_ID = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["loc"].ToString()));
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_EPM_Action_Notes_RM.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=view" + "&page=" + PageToRediect + "&loc=" + Encryption.Encrypt(Location_ID.ToString()) + "&tbl=" + "EPM_Action_Notes_RM");
        }
        else
        {
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_EPM_Action_Notes_RM.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=view&loc=" + Request.QueryString["loc"].ToString() + "&tbl=" + "EPM_Action_Notes_RM");
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

            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_EPM_Action_Notes_RM.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=edit" + "&page=" + PageToRediect + "&loc=" + Encryption.Encrypt(Location_ID.ToString()));
        }
        else
        {
            Response.Redirect(Request.AppRelativeCurrentExecutionFilePath + "?id=" + Encryption.Encrypt(PK_EPM_Action_Notes_RM.ToString()) + "&FK_Claim=" + Encryption.Encrypt(FK_Claim.ToString()) + "&op=edit&loc=" + Request.QueryString["loc"]);
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
        if (ClaimNoteIDs != null)
            strPK = ClaimNoteIDs;
        clsPrintClaimNotesEPMActionNotes.PrintSelectedSonicNotes(strPK, (long)FK_Claim);
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// Used to redirect back to the claim page
    /// </summary>
    private void RedirectToBack()
    {

        Response.Redirect(AppConfig.SiteURL + "/Sonic/Exposures/Project_Management.aspx?loc=" + Encryption.Encrypt(Request.QueryString["loc"]) + "&pnl=5" + "&op=" + StrOperation + "&id=" + Encryption.Encrypt(FK_Claim.ToString()));

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
        clsEPM_Action_Notes_RM objEPM_Action_Notes_RM = new clsEPM_Action_Notes_RM(PK_EPM_Action_Notes_RM);

        // Bind Control value
        txtNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Action_Notes_RM.Note_Date);
        //  FK_Table_Name = objEPM_Action_Notes_RM.FK_Table_Name;
        if (objEPM_Action_Notes_RM.Note != null)
            txtNotes.Text = objEPM_Action_Notes_RM.Note.Trim();

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
        clsEPM_Action_Notes_RM objEPM_Action_Notes_RM = new clsEPM_Action_Notes_RM(PK_EPM_Action_Notes_RM);
        //FK_Table_Name = objEPM_Action_Notes_RM.FK_Table_Name;
        // Bind Control value
        lblNote_Date.Text = clsGeneral.FormatDBNullDateToDisplay(objEPM_Action_Notes_RM.Note_Date);
        if (objEPM_Action_Notes_RM.Note != null)
            lblNotes.Text = objEPM_Action_Notes_RM.Note.Trim();
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
        clsEPM_Identification objEPM_Identification = new clsEPM_Identification(Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["FK_Claim"].ToString())));
        LU_Location objLocation = new LU_Location(Convert.ToDecimal(objEPM_Identification.FK_LU_Location_Id));

        if (objEPM_Identification.FK_LU_EPM_Project_Type != null) lblHeaderProject_Type.Text = new LU_EPM_Project_Type((decimal)objEPM_Identification.FK_LU_EPM_Project_Type).Fld_Desc;
        if (objEPM_Identification.Project_Number != null) lblHeaderProject_Number.Text = objEPM_Identification.Project_Number;
        lblLocation_Number.Text = Convert.ToString(objLocation.Sonic_Location_Code);
        lblLocationdba.Text = Convert.ToString(objLocation.dba);
        lblAddress.Text = Convert.ToString(objLocation.Address_1);
        lblCity.Text = Convert.ToString(objLocation.City);
        if (!string.IsNullOrEmpty(objLocation.State)) lblState.Text = new State(Convert.ToDecimal(objLocation.State)).FLD_state;
        lblZip.Text = Convert.ToString(objLocation.Zip_Code);
    }
}
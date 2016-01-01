using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Management_Management_Note : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Foreign Key of Management
    /// </summary>
    public decimal FK_Management
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }
    }

    /// <summary>
    /// Denotes the Foreign Key of Management
    /// </summary>
    public decimal PK_Notes
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["nid"]) ? Convert.ToInt32(Request.QueryString["nid"]) : -1); }
    }

    /// <summary>
    /// Denotes list of primary key of Management
    /// </summary>
    public string ManagementNoteIDs
    {
        get { return clsGeneral.IsNull(ViewState["ManagementNoteIDs"]) ? string.Empty : Convert.ToString(ViewState["ManagementNoteIDs"]); }
        set { ViewState["ManagementNoteIDs"] = value; }
    }

    /// <summary>
    /// Denotes the Type whether ACI or SONIC
    /// </summary>
    public string _Type
    {
        get { return ViewState["Type"] != null ? Convert.ToString(ViewState["Type"]) : "Management"; }
        set { ViewState["Type"] = value; }
    }


    #endregion
    #region Page Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            _Type = Request.QueryString["type"].ToUpper();
            lblListNoteType.Text = "Management Note";

            if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
            {
                #region " List Notes "
                ManagementNoteIDs = Request.QueryString["viewIDs"];
                rptNotes.DataSource = clsSonic_Management_Notes.SelectByIDs(ManagementNoteIDs);
                
                rptNotes.DataBind();

                dvNotesList.Style["display"] = "block";
                dvView.Style["display"] = "none";
                //trButtons.Style["display"] = "none";

                #endregion
            }
            else if (!string.IsNullOrEmpty(_Type) && _Type.ToLower().Contains("view"))
            {
                #region "List of All Notes"
                rptNotes.DataSource = clsSonic_Management_Notes.SelectByFK_Management(FK_Management);

                rptNotes.DataBind();
                dvNotesList.Style["display"] = "block";
                dvView.Style["display"] = "none";
                #endregion
            }
            else if (FK_Management > 0 && PK_Notes > 0)
            {
                BindNoteDetails();
                BindManagementDetail();
                dvNotesList.Style["display"] = "none";
                dvView.Style["display"] = "block";
            }
            else
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
        }
    }
    #endregion

    #region Method
    private void BindManagementDetail()
    {
        clsManagement objManagement = new clsManagement(FK_Management);
        lblManagementNo.Text = objManagement.Reference_Number;
    }

    private void BindNoteDetails()
    {
        clsSonic_Management_Notes objNotes = new clsSonic_Management_Notes(PK_Notes);
        lblNote.Text = objNotes.Note;
        lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
        lblNoteType.Text = "Management Note";
        
    }
    #endregion

    #region " Events "

    protected void btnPrintSelectedNotes_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request.QueryString["viewIDs"]))
            ManagementNoteIDs = Request.QueryString["viewIDs"];

        clsPrintManagementNotes.PrintSelectedNotes(ManagementNoteIDs, FK_Management, "Management");
    }

    #endregion
}
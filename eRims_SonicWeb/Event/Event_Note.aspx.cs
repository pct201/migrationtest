using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class Event_Event_Note : System.Web.UI.Page
{
    #region Properties
    /// <summary>
    /// Denotes the Foreign Key of Event
    /// </summary>
    public decimal FK_Event
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["id"]) ? Convert.ToInt32(Request.QueryString["id"]) : -1); }        
    }

    /// <summary>
    /// Denotes the Foreign Key of Event
    /// </summary>
    public decimal PK_Notes
    {
        get { return (!clsGeneral.IsNull(Request.QueryString["nid"]) ? Convert.ToInt32(Request.QueryString["nid"]) : -1); }        
    }

 

    /// <summary>
    /// Denotes the Type whether ACI or SONIC
    /// </summary>
    public string _Type
    {
        get { return ViewState["Type"] != null ? Convert.ToString(ViewState["Type"]) : "ACI"; }
        set { ViewState["Type"] = value; }
    }


    #endregion
    #region Page Eveny
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {            
            _Type = Request.QueryString["type"].ToUpper();
            if (FK_Event > 0 && PK_Notes > 0)
            {
                BindNoteDetails();
                BindEventDetail();
            }
            else
            {
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
            }
        }
    }
    #endregion

    #region Method
    private void BindEventDetail()
    {
        clsEvent objEvent = new clsEvent(FK_Event);
        lblEventNo.Text = objEvent.Event_Number;
    }

    private void BindNoteDetails()
    {
        if (_Type == "ACI")
        {
            clsACI_Event_Notes objNotes = new clsACI_Event_Notes(PK_Notes);
            lblNote.Text = objNotes.Note;
            lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objNotes.Note_Date);
            lblNoteType.Text = "ACI Event Note";
        }
        else
        {
            clsSonic_Event_Notes objSonicNote = new clsSonic_Event_Notes(PK_Notes);
            lblNote.Text = objSonicNote.Note;
            lblNoteDate.Text = clsGeneral.FormatDBNullDateToDisplay(objSonicNote.Note_Date);
            lblNoteType.Text = "Sonic Event Note";
        }
    }
    #endregion

    
}
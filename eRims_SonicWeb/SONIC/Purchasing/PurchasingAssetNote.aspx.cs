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

public partial class SONIC_Purchasing_PurchasingAssetNote : clsBasePage
{
    #region Property
    private decimal PK_Purchasing_Asset_Notes
    {
        get
        {
            return (ViewState["PK_Purchasing_Asset_Notes"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_Asset_Notes"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_Asset_Notes"] = value;
        }
    }

    /// <summary>
    /// Gets operation either edit or view if passed in querystring else it returns empty string
    /// </summary>
    public String StrOperation
    {
        get
        {
            if (!String.IsNullOrEmpty(Request.QueryString["op"]))
            {
                return Convert.ToString(Request.QueryString["op"]);
            }
            else
            {
                return String.Empty;
            }
        }
    }
    // <summary>
    /// Denotes operation either view or edit
    /// </summary>
    public string strOperation
    {
        get
        {
            return clsSession.Str_Asset_Operation;
        }
    }

    #endregion

    #region "Page event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // check the foreign key is available otherwise redirect to asset information band page
            if (clsSession.Current_Purchasing_Asset_ID > 0)
            {
                btnAssetNotesAudit.Visible = false;
                PK_Purchasing_Asset_Notes = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_Purchasing_Asset_Notes = index;
                    }
                    // if querystring for operation to be performed is passed(view or edit)
                    if (clsSession.Str_Asset_Operation != "add")
                    //{
                        // set panel notes                      
                        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
                        if (clsSession.Str_Asset_Operation == "view")
                        {
                            // Bind Controls in View mode                           
                            BindDetailForNotesView();
                            btnAssetNotesAudit.Visible = true;
                        }
                        else
                        {
                            // Bind Controls in Edit mode                          
                            BindDetailForNotesEdit();
                            btnAssetNotesAudit.Visible = true;
                        }
                    //}
                }
                else
                {
                    // shows the first panel
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanelNew(1);", true);
                }
            }
            else
            {
                clsSession.Str_Asset_Operation = "edit";
                Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Asset_ID.ToString())  , true);
            }
            CheckUserRights();
            if (clsSession.Str_Asset_Operation != "view")
                SetValidations();
           
        }        
    }
    #endregion

    #region Controls Event
    /// <summary>
    /// Save and View event to store data in notes information 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        // check for page valid
        if (IsValid)
        {
            // create object for Purchasing Notes class
            Purchasing_Asset_Notes objNotes = new Purchasing_Asset_Notes();
            NotesBindSaveData(objNotes); //Function to call bind data in Asset Notes
            //Insert or update mode 
            if (PK_Purchasing_Asset_Notes > 0)
            {
                objNotes.Update();
                clsSession.Str_Asset_Operation = "edit";
                Response.Redirect("PurchasingAssetInformation.aspx?" + "id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Asset_ID.ToString()) + "&pnl=2", true);
            }
            else
            {
                objNotes.Insert();
                if (!String.IsNullOrEmpty(clsSession.Str_Asset_Operation) && clsSession.Str_Asset_Operation == "edit")
                    Response.Redirect("PurchasingAssetInformation.aspx?" + "id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Asset_ID.ToString()) + "&pnl=2", true);
                else
                    clsSession.Str_Asset_Operation = "view";
                    Response.Redirect("PurchasingAssetInformation.aspx?" + "id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Asset_ID.ToString()) +  "&pnl=2", true);
            }
        }
    }
    /// <summary>
    /// Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        clsSession.Str_Asset_Operation = "view";
        Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Asset_ID.ToString()) +  "&pnl=2", true);
    }
    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        clsSession.Str_Asset_Operation = "edit";
        Response.Redirect("PurchasingAssetInformation.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Asset_ID.ToString()) + "&pnl=2", true);
    }
    #endregion

    #region "Methods"

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only && clsSession.Str_Asset_Operation  != "view")
        {            
                Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);       
        }
    }

    /// <summary>
    /// Function to call in Purchasing Asset notes bind data
    /// </summary>
    /// <param name="objNotes"></param>
    private void NotesBindSaveData(Purchasing_Asset_Notes objNotes)
    {
        objNotes.PK_Purchasing_Asset_Notes = PK_Purchasing_Asset_Notes;
        objNotes.FK_Purchasing_Service_Contract = clsSession.Current_Purchasing_Asset_ID;
        objNotes.Note = txtNote.Text.Trim();
        objNotes.Note_Date = clsGeneral.FormatDateToStore(txtNoteDate);
        objNotes.Update_Date = DateTime.Now;
        objNotes.Updated_By = clsSession.UserID.ToString();
    }

    /// <summary>
    /// Set view mode in asset notes
    /// </summary>
    private void BindDetailForNotesView()
    {
        Purchasing_Asset_Notes objNotes = new Purchasing_Asset_Notes(PK_Purchasing_Asset_Notes);
        lblNotesDate.Text = clsGeneral.FormatDateToDisplay(objNotes.Note_Date);
        lblNotes.Text = objNotes.Note;
    }
    /// <summary>
    /// Edit mode in asset notes  
    /// </summary>
    private void BindDetailForNotesEdit()
    {
        Purchasing_Asset_Notes objNotes = new Purchasing_Asset_Notes(PK_Purchasing_Asset_Notes);
        txtNoteDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objNotes.Note_Date));
        txtNote.Text = objNotes.Note;
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

        #region "Notes"
        DataTable dtFields = clsScreen_Validators.SelectByScreen(88).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 88").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Note Date":
                    strCtrlsIDs += txtNoteDate.ClientID + ",";
                    strMessages += "Please enter Note Date" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Note":
                    strCtrlsIDs += txtNote.ClientID + ",";
                    strMessages += "Please enter Note" + ",";
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

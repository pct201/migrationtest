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

public partial class SONIC_Purchasing_ServiceContractNote : clsBasePage
{
    #region "Prperties"
    /// <summary>
    /// PK_Purchasing_SC_Notes
    /// </summary>
    private decimal PK_Purchasing_SC_Notes
    {
        get
        {
            return (ViewState["PK_Purchasing_SC_Notes"] != null ? Convert.ToDecimal(ViewState["PK_Purchasing_SC_Notes"]) : 0);
        }
        set
        {
            ViewState["PK_Purchasing_SC_Notes"] = value;
        }
    }
    #endregion

    #region "Page Event"

    /// <summary>
    /// Handle page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (clsSession.Current_Purchasing_Service_Contract_ID > 0)
            {
                CheckUserRights();
                txtNoteDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
                PK_Purchasing_SC_Notes = 0;
                if (Request.QueryString["id"] != null)
                {
                    decimal index;
                    btnContractNotesAudit.Visible = true;
                    if (decimal.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out index))
                    {
                        PK_Purchasing_SC_Notes = index;
                        setControls();
                    }
                }
                else
                    btnContractNotesAudit.Visible = false;
                txtNoteDate.Attributes.Add("readonly", "true");
            }
            else
            {
                if (clsSession.Current_Purchasing_Service_Contract_ID > 0)
                    Response.Redirect("ServiceContract.aspx?id=" + clsSession.Current_Purchasing_Service_Contract_ID + "&pnl=3", true);
                else
                    Response.Redirect("ServiceContract.aspx?op=add");
            }
            Purchasing_SearchTAB.StrRedirectTo = "";
            if (clsSession.Str_ServiceContract_Operation != "view")
                SetValidations();
           
        }
        if (Purchasing_SearchTAB.Visible)
            Purchasing_SearchTAB.SetSelectedTab(CtrlPurchasing_Search.Tab.Purchasing);
    }

    #endregion

    #region "Events"

    /// <summary>
    /// handle Save button click event -to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSaveAndView_Click(object sender, EventArgs e)
    {
        if (IsValid)
        {
            Purchasing_SC_Notes objNotes = new Purchasing_SC_Notes();
            setProperties(objNotes);
            if (PK_Purchasing_SC_Notes > 0)
            {
                objNotes.Update();
            }
            else
            {
                objNotes.Insert();
            }
            Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Service_Contract_ID.ToString()) + "&pnl=3", true);
        }
    }

    /// <summary>
    /// Handle Back button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevertandReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("ServiceContract.aspx?id=" + Encryption.Encrypt(clsSession.Current_Purchasing_Service_Contract_ID.ToString()) + "&pnl=3", true);
    }

    #endregion

    #region "Methods"

    /// <summary>
    /// set properties from controls to save data
    /// </summary>
    /// <param name="objNotes"></param>
    private void setProperties(Purchasing_SC_Notes objNotes)
    {
        objNotes.PK_Purchasing_SC_Notes = PK_Purchasing_SC_Notes;
        objNotes.FK_Purchasing_Service_Contract = clsSession.Current_Purchasing_Service_Contract_ID;
        objNotes.Note = txtNote.Text.Trim();
        objNotes.Note_Date = clsGeneral.FormatDateToStore(txtNoteDate);
        objNotes.Update_Date = DateTime.Now;
        objNotes.Updated_By = clsSession.UserID.ToString();
    }

    /// <summary>
    /// set controls from properties to view data
    /// </summary>
    private void setControls()
    {
        DataSet ds = Purchasing_SC_Notes.SelectByPK(PK_Purchasing_SC_Notes);
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            if (ds.Tables[0].Rows[0]["Note_Date"] != null)
            {
                txtNoteDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(ds.Tables[0].Rows[0]["Note_Date"]));
                lblNoteDate.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(ds.Tables[0].Rows[0]["Note_Date"]));
            }
            else
            {
                txtNoteDate.Text = clsGeneral.FormatDateToDisplay(DateTime.Now);
            }

            if (ds.Tables[0].Rows[0]["Note"] != null)
            {
                txtNote.Text = ds.Tables[0].Rows[0]["Note"].ToString();
            }
        }
        if (clsSession.Str_ServiceContract_Operation == "view")
        {
            txtNote.ControlType = Controls_LongDescription_LongDescription.CtrlType.Label;
            btnSave.Visible = false;
            txtNoteDate.Visible = false;
            lblNoteDate.Visible = true;
            btnRevertandReturn.Text = "Back";
        }
        else
        {
            txtNoteDate.Visible = true;
            lblNoteDate.Visible = false;
        }
    }

    /// <summary>
    /// check user rights
    /// </summary>
    private void CheckUserRights()
    {
        if (App_Access == AccessType.View_Only)
        {
            Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
        }
        else
        {
            if (App_Access == AccessType.Purchasing_Edit)
            {
                PurchasingServiceContract objServiceContract = new PurchasingServiceContract();
                objServiceContract.View(clsSession.Current_Purchasing_Service_Contract_ID);
                if (objServiceContract.Legal_Confidential.ToLower().Trim() == "y")
                {
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc", true);
                }
            }
        }
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
        DataTable dtFields = clsScreen_Validators.SelectByScreen(94).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 94").Length > 0) ? "inline-block" : "none";
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

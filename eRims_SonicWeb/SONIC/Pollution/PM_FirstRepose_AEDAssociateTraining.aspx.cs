using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Pollution_PM_FirstRepose_AEDAssociateTraining : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_AssociateTrainingFirstRepose_AED
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_AssociateTrainingFirstRepose_AED"]);
        }
        set { ViewState["PK_PM_AssociateTrainingFirstRepose_AED"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Site Information
    /// </summary>
    public decimal FK_PM_Site_Information
    {
        get { return clsGeneral.GetInt(ViewState["FK_PM_Site_Information"]); }
        set { ViewState["FK_PM_Site_Information"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }

    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    #endregion

    #region Page Events
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        if (!Page.IsPostBack)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetMenuStyle(1);", true);
            PK_PM_AssociateTrainingFirstRepose_AED = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            else
                Response.Redirect("../Exposures/ExposureSearch.aspx");

            if (PK_PM_AssociateTrainingFirstRepose_AED > 0)
            {
                if (Request.QueryString["op"] != null)
                {
                    StrOperation = Request.QueryString["op"];
                }
                else
                    StrOperation = "edit";

                if (StrOperation == "view")
                {
                    BindDetailsForView();
                    dvView.Style["display"] = "inline";
                    dvEdit.Style["display"] = "none";
                    btnSave.Visible = false;
                    btnEdit.Visible = (App_Access == AccessType.Administrative_Access);
                    AttachmentsView.StrOperation = StrOperation;
                    AttachmentsView.PK_ID = PK_PM_AssociateTrainingFirstRepose_AED;
                }
                else
                {
                    if (App_Access == AccessType.View_Only)
                        Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");
                    SetValidations();
                    BindDetailsForEdit();
                    dvView.Style["display"] = "none";
                    dvEdit.Style["display"] = "inline";
                    btnSave.Visible = true;
                    btnEdit.Visible = false;
                    Attachments.PK_ID = PK_PM_AssociateTrainingFirstRepose_AED;
                }
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                SetValidations();
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnEdit.Visible = false;
                btnAuditTrail.Visible = false;
            }
        }
    }
    #endregion

    #region Methods
    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        clsPM_AssociateTrainingFirstRepose_AED objPM_AssociateTrainingFirstRepose_AED = new clsPM_AssociateTrainingFirstRepose_AED(PK_PM_AssociateTrainingFirstRepose_AED);
        txtAssociateName.Text = objPM_AssociateTrainingFirstRepose_AED.AssociateName;
        txtAssociateTitle.Text = objPM_AssociateTrainingFirstRepose_AED.AssociateTitle;
        txtTrainingDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_AssociateTrainingFirstRepose_AED.AssociateTrainingDate);
        txtNotesComments.Text = objPM_AssociateTrainingFirstRepose_AED.Notes_Comments;
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = true;
        btnSave.Visible = false;
        btnEdit.Visible = true;
        clsPM_AssociateTrainingFirstRepose_AED objPM_AssociateTrainingFirstRepose_AED = new clsPM_AssociateTrainingFirstRepose_AED(PK_PM_AssociateTrainingFirstRepose_AED);
        lblAssociateName.Text = objPM_AssociateTrainingFirstRepose_AED.AssociateName;
        lblAssociateTitle.Text = objPM_AssociateTrainingFirstRepose_AED.AssociateTitle;
        lblTrainingDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_AssociateTrainingFirstRepose_AED.AssociateTrainingDate);
        lblNotesComments.Text = objPM_AssociateTrainingFirstRepose_AED.Notes_Comments;
    }

    /// <summary>
    /// Saves the data.
    /// </summary>
    private void SaveData()
    {
        clsPM_AssociateTrainingFirstRepose_AED objPM_AssociateTrainingFirstRepose_AED = new clsPM_AssociateTrainingFirstRepose_AED();
        objPM_AssociateTrainingFirstRepose_AED.PK_PM_AssociateTrainingFirstRepose_AED = PK_PM_AssociateTrainingFirstRepose_AED;
        objPM_AssociateTrainingFirstRepose_AED.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_AssociateTrainingFirstRepose_AED.FK_LU_Location = FK_LU_Location_ID;
        objPM_AssociateTrainingFirstRepose_AED.AssociateName = Convert.ToString(txtAssociateName.Text);
        objPM_AssociateTrainingFirstRepose_AED.AssociateTitle = Convert.ToString(txtAssociateTitle.Text);
        objPM_AssociateTrainingFirstRepose_AED.AssociateTrainingDate = clsGeneral.FormatNullDateToStore(txtTrainingDate.Text);
        objPM_AssociateTrainingFirstRepose_AED.Notes_Comments = Convert.ToString(txtNotesComments.Text);
        objPM_AssociateTrainingFirstRepose_AED.Updated_By = clsSession.UserID;
        objPM_AssociateTrainingFirstRepose_AED.Update_Date = DateTime.Now;

        decimal _retVal;
        if (PK_PM_AssociateTrainingFirstRepose_AED > 0)
        {
            objPM_AssociateTrainingFirstRepose_AED.Update();
        }
        else
        {
            _retVal = objPM_AssociateTrainingFirstRepose_AED.Insert();
            PK_PM_AssociateTrainingFirstRepose_AED = _retVal;
        }
        Response.Redirect("PM_FirstRepose_AEDAssociateTraining.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_AssociateTrainingFirstRepose_AED)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }

    #endregion

    #region Control Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_AssociateTrainingFirstRepose_AED > 0)
            Response.Redirect("PM_FirstRepose_AEDAssociateTraining.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_AssociateTrainingFirstRepose_AED)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
    }

    /// <summary>
    /// Directs back to the parent page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
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

        #region " Site Information "

        DataTable dtFields = clsScreen_Validators.SelectByScreenName("Associate Training for First Response and AED").Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Associate Name":
                    strCtrlsIDs += txtAssociateName.ClientID + ",";
                    strMessages += "Please enter [First Response and AED]/Training Required Associate Name" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Associate Title":
                    strCtrlsIDs += txtAssociateTitle.ClientID + ",";
                    strMessages += "Please enter [First Response and AED]/Associate Title" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Training Date":
                    strCtrlsIDs += txtTrainingDate.ClientID + ",";
                    strMessages += "Please select [First Response and AED]/Training Date" + ",";
                    Span3.Style["display"] = "inline-block";
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
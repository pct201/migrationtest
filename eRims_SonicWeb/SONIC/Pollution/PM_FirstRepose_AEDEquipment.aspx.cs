using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Pollution_PM_FirstRepose_AEDEquipment : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_PM_FirstRepose_AEDEquipment
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_PM_FirstRepose_AEDEquipment"]);
        }
        set { ViewState["PK_PM_FirstRepose_AEDEquipment"] = value; }
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
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }

    /// <summary>
    /// Denotes foriegn key for Location record
    /// </summary>
    public decimal FK_LU_Location_ID
    {
        get { return Convert.ToDecimal(ViewState["FK_LU_Location_ID"]); }
        set { ViewState["FK_LU_Location_ID"] = value; }
    }
    #endregion
    protected void Page_Load(object sender, EventArgs e)
    {
        Tab.SetSelectedTab(Controls_ExposuresTab_ExposuresTab.Tab.Pollution);
        if (!Page.IsPostBack)
        {
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetMenuStyle(1);", true);
            PK_PM_FirstRepose_AEDEquipment = clsGeneral.GetQueryStringID(Request.QueryString["id"]);
            FK_LU_Location_ID = clsGeneral.GetQueryStringID(Request.QueryString["loc"]);
            FK_PM_Site_Information = clsGeneral.GetQueryStringID(Request.QueryString["fid"]);

            if (FK_LU_Location_ID > 0)
            {
                Session["ExposureLocation"] = FK_LU_Location_ID;
                ucCtrlExposureInfo.PK_LU_Location = FK_LU_Location_ID;
                ucCtrlExposureInfo.BindExposureInfo();
            }
            //else
            //    Response.Redirect("../Exposures/ExposureSearch.aspx");

            if (PK_PM_FirstRepose_AEDEquipment > 0)
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
                    AttachmentsView.PK_ID = PK_PM_FirstRepose_AEDEquipment;
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
                    Attachments.PK_ID = PK_PM_FirstRepose_AEDEquipment;
                }
            }
            else
            {
                if (App_Access == AccessType.View_Only)
                    Response.Redirect(AppConfig.SiteURL + "Error.aspx?msg=errAcc");

                BindDropdown();
                SetValidations();
                dvView.Style["display"] = "none";
                dvEdit.Style["display"] = "inline";
                btnEdit.Visible = false;
                btnAuditTrail.Visible = false;
            }
        }
    }

    #region Control Events
    protected void btnSave_Click(object sender, EventArgs e)
    {
        SaveData();
    }

    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (PK_PM_FirstRepose_AEDEquipment > 0)
            Response.Redirect("PM_FirstRepose_AEDEquipment.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_FirstRepose_AEDEquipment)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)));
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        if (StrOperation == "view")
            Response.Redirect("Pollution.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
        else
            Response.Redirect("Pollution.aspx?op=edit&id=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&pnl=" + Encryption.Encrypt("7"));
    }
    #endregion

    #region
    private void BindDropdown()
    {
        drpFK_AEDLoaction.Items.Clear();
        DataSet dsAED_Location = clsLU_AED_Location.SelectAll();
        if (dsAED_Location.Tables.Count > 0)
        {
            drpFK_AEDLoaction.DataSource = dsAED_Location.Tables[0];
            drpFK_AEDLoaction.DataTextField = "Fld_Desc";
            drpFK_AEDLoaction.DataValueField = "PK_LU_AED_Location";
            drpFK_AEDLoaction.DataBind();
        }
        drpFK_AEDLoaction.Items.Insert(0, new ListItem("--Select--", "-1"));
    }

    /// <summary>
    /// Saves the data.
    /// </summary>
    private void SaveData()
    {
        clsPM_FirstRepose_AEDEquipment objPM_FirstRepose_AEDEquipment = new clsPM_FirstRepose_AEDEquipment();
        objPM_FirstRepose_AEDEquipment.PK_PM_FirstRepose_AEDEquipment = PK_PM_FirstRepose_AEDEquipment;
        objPM_FirstRepose_AEDEquipment.FK_PM_Site_Information = FK_PM_Site_Information;
        objPM_FirstRepose_AEDEquipment.FK_LU_Location = FK_LU_Location_ID;
        objPM_FirstRepose_AEDEquipment.Store_Service = rdoStoreService.SelectedValue;
        objPM_FirstRepose_AEDEquipment.AEDManufacturer = Convert.ToString(txtAEDManufacturer.Text);
        if (drpFK_AEDLoaction.SelectedIndex > 0) objPM_FirstRepose_AEDEquipment.FK_LU_AED_Location = clsGeneral.GetDecimal(drpFK_AEDLoaction.SelectedValue);
        objPM_FirstRepose_AEDEquipment.AEDInstallDate = clsGeneral.FormatNullDateToStore(txtInstallDate.Text);
        //objPM_FirstRepose_AEDEquipment.AssociateName = Convert.ToString(txtAssociateName.Text);
        //objPM_FirstRepose_AEDEquipment.AssociateTitle = Convert.ToString(txtAssociateTitle.Text);
        //objPM_FirstRepose_AEDEquipment.AssociateTrainingDate = clsGeneral.FormatNullDateToStore(txtTrainingDate.Text);
        objPM_FirstRepose_AEDEquipment.Notes_Comments = Convert.ToString(txtNotesComments.Text);
        objPM_FirstRepose_AEDEquipment.Updated_By = clsSession.UserID;
        objPM_FirstRepose_AEDEquipment.Update_Date = DateTime.Now;

        decimal _retVal;
        if(PK_PM_FirstRepose_AEDEquipment > 0)
        {
            objPM_FirstRepose_AEDEquipment.Update();
        }
        else
        {
            _retVal = objPM_FirstRepose_AEDEquipment.Insert();
            PK_PM_FirstRepose_AEDEquipment = _retVal;

            clsPM_FirstRepose_AEDEquipment_Attachments objAttachments = new clsPM_FirstRepose_AEDEquipment_Attachments();

            if (Attachments.dtAttachment_AEDFirstResponse != null)
            {
                DataTable dtAttachment = Attachments.dtAttachment_AEDFirstResponse;
                for (int i = 0; i < dtAttachment.Rows.Count; i++)
                {
                    objAttachments.Updated_By = clsSession.UserID;
                    objAttachments.Update_Date = DateTime.Now;
                    objAttachments.FK_PM_FirstRepose_AEDEquipment = PK_PM_FirstRepose_AEDEquipment;
                    objAttachments.Attachment_Name = Convert.ToString(dtAttachment.Rows[i]["Attachment_Name"]);
                    objAttachments.File_Name = Convert.ToString(dtAttachment.Rows[i]["File_Name"]);

                    objAttachments.Insert();
                }
            }
        }
        Response.Redirect("PM_FirstRepose_AEDEquipment.aspx?op=view&id=" + Encryption.Encrypt(Convert.ToString(PK_PM_FirstRepose_AEDEquipment)) + "&loc=" + Encryption.Encrypt(Convert.ToString(FK_LU_Location_ID)) + "&fid=" + Encryption.Encrypt(Convert.ToString(FK_PM_Site_Information)));
    }

    /// <summary>
    /// Bind Page Controls for edit mode
    /// </summary>
    private void BindDetailsForEdit()
    {
        dvView.Visible = false;
        dvEdit.Visible = true;
        btnEdit.Visible = false;
        BindDropdown();
        clsPM_FirstRepose_AEDEquipment objPM_FirstRepose_AEDEquipment = new clsPM_FirstRepose_AEDEquipment(PK_PM_FirstRepose_AEDEquipment);
        if (objPM_FirstRepose_AEDEquipment.Store_Service != null) rdoStoreService.SelectedValue = objPM_FirstRepose_AEDEquipment.Store_Service;
        txtAEDManufacturer.Text = objPM_FirstRepose_AEDEquipment.AEDManufacturer;
        if (objPM_FirstRepose_AEDEquipment.FK_LU_AED_Location != null) drpFK_AEDLoaction.SelectedValue = objPM_FirstRepose_AEDEquipment.FK_LU_AED_Location.ToString();
        txtInstallDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_FirstRepose_AEDEquipment.AEDInstallDate);
        //txtAssociateName.Text = objPM_FirstRepose_AEDEquipment.AssociateName;
        //txtAssociateTitle.Text = objPM_FirstRepose_AEDEquipment.AssociateTitle;
        //txtTrainingDate.Text = clsGeneral.FormatDBNullDateToDisplay(objPM_FirstRepose_AEDEquipment.AssociateTrainingDate );
        txtNotesComments.Text = objPM_FirstRepose_AEDEquipment.Notes_Comments;
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
        DataTable dtAEDEquipment = clsPM_FirstRepose_AEDEquipment.SelectViewByPK(PK_PM_FirstRepose_AEDEquipment).Tables[0];

        lblStoreService.Text = Convert.ToString(dtAEDEquipment.Rows[0]["Store_Service"]);
        lblAEDManufacturer.Text = Convert.ToString(dtAEDEquipment.Rows[0]["AEDManufacturer"]);
        lblFK_AEDLoaction.Text = Convert.ToString(dtAEDEquipment.Rows[0]["AED_Location_Desc"]);
        lblInstallDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtAEDEquipment.Rows[0]["AEDInstallDate"]);
        //lblAssociateName.Text = Convert.ToString(dtAEDEquipment.Rows[0]["AssociateName"]);
        //lblAssociateTitle.Text = Convert.ToString(dtAEDEquipment.Rows[0]["AssociateTitle"]);
        //lblTrainingDate.Text = clsGeneral.FormatDBNullDateToDisplay(dtAEDEquipment.Rows[0]["AssociateTrainingDate"]);
        lblNotesComments.Text = Convert.ToString(dtAEDEquipment.Rows[0]["Notes_Comments"]);
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

        DataTable dtFields = clsScreen_Validators.SelectByScreenName("First Response and AED Equipments").Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();

        MenuAsterisk1.Style["display"] = (dtFields.Rows.Count > 0) ? "inline-block" : "none";

        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "AED Manufacturer":
                    strCtrlsIDs += txtAEDManufacturer.ClientID + ",";
                    strMessages += "Please enter [First Response and AED]/AED Manufacturer" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "AED Locations":
                    strCtrlsIDs += drpFK_AEDLoaction.ClientID + ",";
                    strMessages += "Please select [First Response and AED]/AED Locations" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "AED Install Date":
                    strCtrlsIDs += txtInstallDate.ClientID + ",";
                    strMessages += "Please select [First Response and AED]/AED Install Date" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                //case "Associate Name":
                //    strCtrlsIDs += txtAssociateName.ClientID + ",";
                //    strMessages += "Please enter [First Response and AED]/Training Required Associate Name" + ",";
                //    Span4.Style["display"] = "inline-block";
                //    break;
                //case "Associate Title":
                //    strCtrlsIDs += txtAssociateTitle.ClientID + ",";
                //    strMessages += "Please enter [First Response and AED]/Associate Title" + ",";
                //    Span5.Style["display"] = "inline-block";
                //    break;
                //case "Training Date":
                //    strCtrlsIDs += txtTrainingDate.ClientID + ",";
                //    strMessages += "Please select [First Response and AED]/Training Date" + ",";
                //    Span6.Style["display"] = "inline-block";
                //    break;
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
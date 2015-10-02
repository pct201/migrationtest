using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_FirstReport_IncidentInvolvement : clsBasePage
{
    #region Properties
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_FR_PL_Involvement
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_FR_PL_Involvement"]);
        }
        set { ViewState["PK_FR_PL_Involvement"] = value; }
    }

    /// <summary>
    /// Foreign key
    /// </summary>
    public decimal FK_PL_FR_ID
    {
        get
        {
            return clsGeneral.GetInt(ViewState["FK_PL_FR_ID"]);
        }
        set { ViewState["FK_PL_FR_ID"] = value; }
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

    /// <summary>
    /// Page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            // shows the first panel
            Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
            BindDropdownList();
            PK_FR_PL_Involvement = clsGeneral.GetQueryStringID(Request.QueryString["id"]);

            if (PK_FR_PL_Involvement > 0)
            {
                StrOperation = Convert.ToString(Request.QueryString["mode"]);
                //PK_Executive_Risk_Contacts = Convert.ToInt32(Request.QueryString["id"]);
                if (StrOperation == "view")
                {
                    // Bind Controls
                    BindDetailsForView();
                    dvViewbutton.Visible = true;
                    dvSave.Visible = false;
                }
                else
                {
                    // Bind Controls
                    BindDetailsForEdit();
                    dvViewbutton.Visible = false;
                    dvSave.Visible = true;
                }
            }
            else
            {
                FK_PL_FR_ID = clsGeneral.GetQueryStringID(Request.QueryString["prid"]);
                if (FK_PL_FR_ID > 0)
                {
                    // don't show div for view mode
                    PK_FR_PL_Involvement = 0;
                    dvView.Style["display"] = "none";
                    dvViewbutton.Visible = false;
                    dvSave.Visible = true;
                    btnRevert.Visible = false;
                    btnAuditTrail.Visible = false;
                }
                else
                    Response.Redirect("FirstReportSearch.aspx", true);
            }
            SetValidations();
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

        clsFR_PL_Involvement objFR_PL_Involvement = new clsFR_PL_Involvement(PK_FR_PL_Involvement);
        if (objFR_PL_Involvement.FK_LU_PL_Involvement != null) drpFK_LU_PL_Involvement.SelectedValue = objFR_PL_Involvement.FK_LU_PL_Involvement.ToString();
        txtName.Text = objFR_PL_Involvement.Name;
        txtAddress_1.Text = objFR_PL_Involvement.Address_1;
        txtAddress_2.Text = objFR_PL_Involvement.Address_2;
        txtCity.Text = objFR_PL_Involvement.City;
        if (objFR_PL_Involvement.FK_State != null) drpFK_State.SelectedValue = objFR_PL_Involvement.FK_State.ToString();
        txtZip_Code.Text = objFR_PL_Involvement.Zip_Code;
        txtHome_Telephone.Text = objFR_PL_Involvement.Home_Telephone;
        txtWork_Telephone.Text = objFR_PL_Involvement.Work_Telephone;
        txtCell_Telephone.Text = objFR_PL_Involvement.Cell_Telephone;
        txtEmail.Text = objFR_PL_Involvement.Email;
        FK_PL_FR_ID = Convert.ToDecimal(objFR_PL_Involvement.FK_PL_FR_ID);

        if (objFR_PL_Involvement.Gender == "M")
        {
            chkMale.Checked = true;
        }
        else if (objFR_PL_Involvement.Gender == "F")
        {
            chkFemale.Checked = true;
        }

        if (!string.IsNullOrEmpty(objFR_PL_Involvement.Medical_Attention_Required))
        {
            rdoMedicalAttentionRequired.SelectedValue = objFR_PL_Involvement.Medical_Attention_Required;
        }

        if (!string.IsNullOrEmpty(objFR_PL_Involvement.Medical_Attention_Declined))
        {
            rdoMedicalAttentionDeclined.SelectedValue = objFR_PL_Involvement.Medical_Attention_Declined;
        }
    }

    /// <summary>
    /// Binds Page Controls for view mode
    /// </summary>
    private void BindDetailsForView()
    {
        dvView.Visible = true;
        dvEdit.Visible = false;
        dvSave.Visible = false;
        clsFR_PL_Involvement objFR_PL_Involvement = new clsFR_PL_Involvement(PK_FR_PL_Involvement);
        if (objFR_PL_Involvement.FK_LU_PL_Involvement != null)
            lblFK_LU_PL_Involvement.Text = new clsLU_PL_Involvement((decimal)objFR_PL_Involvement.FK_LU_PL_Involvement).Fld_Desc;
        lblName.Text = objFR_PL_Involvement.Name;
        lblAddress_1.Text = objFR_PL_Involvement.Address_1;
        lblAddress_2.Text = objFR_PL_Involvement.Address_2;
        lblCity.Text = objFR_PL_Involvement.City;
        if (objFR_PL_Involvement.FK_State != null)
            lblFK_State.Text = new State((decimal)objFR_PL_Involvement.FK_State).FLD_state;
        lblZip_Code.Text = objFR_PL_Involvement.Zip_Code;
        lblHome_Telephone.Text = objFR_PL_Involvement.Home_Telephone;
        lblWork_Telephone.Text = objFR_PL_Involvement.Work_Telephone;
        lblCell_Telephone.Text = objFR_PL_Involvement.Cell_Telephone;
        lblEmail.Text = objFR_PL_Involvement.Email;

        if (objFR_PL_Involvement.Gender == "M")
        {
            lblGender.Text = "Male";
        }
        else if (objFR_PL_Involvement.Gender == "F")
        {
            lblGender.Text = "Female";
        }

        if (!string.IsNullOrEmpty(objFR_PL_Involvement.Medical_Attention_Required) && objFR_PL_Involvement.Medical_Attention_Required == "Y")
        {
            lblMedicalAttentionRequired.Text = "Yes";
        }
        else
        {
            lblMedicalAttentionRequired.Text = "No";
        }

        if (!string.IsNullOrEmpty(objFR_PL_Involvement.Medical_Attention_Declined) && objFR_PL_Involvement.Medical_Attention_Declined == "Y")
        {
            lblMedicalAttentionDeclined.Text = "Yes";
        }
        else
        {
            lblMedicalAttentionDeclined.Text = "No";
        }

        FK_PL_FR_ID = Convert.ToDecimal(objFR_PL_Involvement.FK_PL_FR_ID);
    }

    /// <summary>
    /// Method to bind drop down
    /// </summary>
    private void BindDropdownList()
    {
        DataSet dsType = clsLU_PL_Involvement.SelectAll();

        dsType.Tables[0].DefaultView.RowFilter = "Active='Y'";
        drpFK_LU_PL_Involvement.DataSource = dsType.Tables[0].DefaultView;
        drpFK_LU_PL_Involvement.DataTextField = "Fld_Desc";
        drpFK_LU_PL_Involvement.DataValueField = "PK_LU_PL_Involvement";
        drpFK_LU_PL_Involvement.DataBind();

        drpFK_LU_PL_Involvement.Items.Insert(0, new ListItem("--Select--", "0"));

        ComboHelper.FillState(new DropDownList[] { drpFK_State }, 0, true);
    }

    #endregion

    #region Control Events
    /// <summary>
    /// Handles Save Button click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsFR_PL_Involvement objFR_PL_Involvement = new clsFR_PL_Involvement();
        objFR_PL_Involvement.PK_FR_PL_Involvement = PK_FR_PL_Involvement;
        objFR_PL_Involvement.FK_PL_FR_ID = FK_PL_FR_ID;
        if (drpFK_LU_PL_Involvement.SelectedIndex > 0) objFR_PL_Involvement.FK_LU_PL_Involvement = Convert.ToDecimal(drpFK_LU_PL_Involvement.SelectedValue);
        objFR_PL_Involvement.Name = txtName.Text.Trim();
        objFR_PL_Involvement.Address_1 = txtAddress_1.Text.Trim();
        objFR_PL_Involvement.Address_2 = txtAddress_2.Text.Trim();
        objFR_PL_Involvement.City = txtCity.Text.Trim();
        if (drpFK_State.SelectedIndex > 0) objFR_PL_Involvement.FK_State = Convert.ToDecimal(drpFK_State.SelectedValue);
        objFR_PL_Involvement.Zip_Code = txtZip_Code.Text.Trim();
        objFR_PL_Involvement.Home_Telephone = txtHome_Telephone.Text.Trim();
        objFR_PL_Involvement.Work_Telephone = txtWork_Telephone.Text.Trim();
        objFR_PL_Involvement.Cell_Telephone = txtCell_Telephone.Text.Trim();
        objFR_PL_Involvement.Email = txtEmail.Text.Trim();
        objFR_PL_Involvement.Update_Date = DateTime.Now;
        objFR_PL_Involvement.Updated_By = clsSession.UserName;
        
        if(chkMale.Checked)
        {
            objFR_PL_Involvement.Gender = "M";
        }
        else if (chkFemale.Checked)
        {
            objFR_PL_Involvement.Gender = "F";
        }

        objFR_PL_Involvement.Medical_Attention_Required = rdoMedicalAttentionRequired.SelectedValue;
        objFR_PL_Involvement.Medical_Attention_Declined = rdoMedicalAttentionDeclined.SelectedValue;

        if (PK_FR_PL_Involvement > 0)
            objFR_PL_Involvement.Update();
        else
            PK_FR_PL_Involvement = objFR_PL_Involvement.Insert();

        btnRevert.Visible = true;
        btnAuditTrail.Visible = true;
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Button Edit Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        Response.Redirect("IncidentInvolvement.aspx?id=" + Encryption.Encrypt(PK_FR_PL_Involvement.ToString()) + "&mode=edit", true);
    }

    /// <summary>
    /// Button Edit Click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("PLFirstReport.aspx?id=" + Encryption.Encrypt(FK_PL_FR_ID.ToString()) + "&pnl=" + Encryption.Encrypt(Convert.ToString(2)), true);
    }

    /// <summary>
    /// Button Revert Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnRevert_Click(object sender, EventArgs e)
    {
        BindDetailsForEdit();
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ShowPanel(1);", true);
    }

    /// <summary>
    /// Event to Change Gender
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkMale_CheckedChanged(object sender, EventArgs e)
    {
        if (chkMale.Checked)
        {
            chkFemale.Checked = false;
        }
    }

    /// <summary>
    /// Event to Change Gender
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void chkFemale_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFemale.Checked)
        {
            chkMale.Checked = false;
        }
    }

    #endregion

    #region "Dynamic validation"

    /// <summary>
    /// Set all Validations - Loss Information
    /// </summary>
    private void SetValidations()
    {
        string strCtrlsIDs = "";
        string strMessages = "";

        #region ""
        DataTable dtFields = clsScreen_Validators.SelectByScreen(146).Tables[0];
        dtFields.DefaultView.RowFilter = "IsRequired = '1'";
        dtFields = dtFields.DefaultView.ToTable();
        MenuAsterisk1.Style["display"] = (dtFields.Select("LeftMenuIndex = 1").Length > 0) ? "inline-block" : "none";
        foreach (DataRow drField in dtFields.Rows)
        {
            #region " set validation control IDs and messages "
            switch (Convert.ToString(drField["Field_Name"]))
            {
                case "Type":
                    strCtrlsIDs += drpFK_LU_PL_Involvement.ClientID + ",";
                    strMessages += "Please select Type" + ",";
                    Span1.Style["display"] = "inline-block";
                    break;
                case "Name":
                    strCtrlsIDs += txtName.ClientID + ",";
                    strMessages += "Please enter Name" + ",";
                    Span2.Style["display"] = "inline-block";
                    break;
                case "Address 1":
                    strCtrlsIDs += txtAddress_1.ClientID + ",";
                    strMessages += "Please enter Address 1" + ",";
                    Span3.Style["display"] = "inline-block";
                    break;
                case "Address 2":
                    strCtrlsIDs += txtAddress_2.ClientID + ",";
                    strMessages += "Please enter Address 2" + ",";
                    Span4.Style["display"] = "inline-block";
                    break;
                case "City":
                    strCtrlsIDs += txtCity.ClientID + ",";
                    strMessages += "Please enter City" + ",";
                    Span5.Style["display"] = "inline-block";
                    break;
                case "State":
                    strCtrlsIDs += drpFK_State.ClientID + ",";
                    strMessages += "Please select State" + ",";
                    Span6.Style["display"] = "inline-block";
                    break;
                case "Zip Code":
                    strCtrlsIDs += txtZip_Code.ClientID + ",";
                    strMessages += "Please enter Zip Code" + ",";
                    Span7.Style["display"] = "inline-block";
                    break;
                case "Home Telephone":
                    strCtrlsIDs += txtHome_Telephone.ClientID + ",";
                    strMessages += "Please enter Home Telephone" + ",";
                    Span8.Style["display"] = "inline-block";
                    break;
                case "Work Telephone":
                    strCtrlsIDs += txtWork_Telephone.ClientID + ",";
                    strMessages += "Please enter Work Telephone" + ",";
                    Span9.Style["display"] = "inline-block";
                    break;
                case "Cell Telephone":
                    strCtrlsIDs += txtCell_Telephone.ClientID + ",";
                    strMessages += "Please enter Cell Telephone" + ",";
                    Span10.Style["display"] = "inline-block";
                    break;
                case "Email Address":
                    strCtrlsIDs += txtEmail.ClientID + ",";
                    strMessages += "Please enter E-Mail Address" + ",";
                    Span11.Style["display"] = "inline-block";
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
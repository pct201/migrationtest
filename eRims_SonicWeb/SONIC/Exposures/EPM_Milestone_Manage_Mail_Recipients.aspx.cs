using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_Exposures_EPM_Milestone_Manage_Mail_Recipients : clsBasePage
{
    #region " Properties "
    /// <summary>
    /// Denotes Pk Of EPM_MilestoneRecipients table
    /// </summary>
    public decimal PK_EPM_MilestoneRecipients
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_EPM_MilestoneRecipients"]);
        }
        set { ViewState["PK_EPM_MilestoneRecipients"] = value; }
    }
    #endregion

    #region " page Load "
    /// <summary>
    /// Page Load Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindExistingEmailAddress();
        }
    }
    #endregion

    #region " page Methods "
    /// <summary>
    /// Bind Esisting mail Address List
    /// </summary>
    private void BindExistingEmailAddress()
    {
        DataTable dtExistingEmailAddress = clsEPM_MilestoneRecipients.SelectAll().Tables[0];
        lstEMail_Recipients.Items.Clear();
        lstEMail_Recipients.DataTextField = "Name";
        lstEMail_Recipients.DataValueField = "PK_EPM_MilestoneRecipients";
        lstEMail_Recipients.DataSource = dtExistingEmailAddress;
        lstEMail_Recipients.DataBind();
    }

    /// <summary>
    /// Clear Controls
    /// </summary>
    private void ClearControls()
    {
        txtName.Text = "";
        txtEmail.Text = "";
        PK_EPM_MilestoneRecipients = 0;
        btnSave.Visible = false;
        btnAdd.Visible = true;
        trDeleteEmail.Visible = false;
        hdnBackTo.Value = "1";
    }
    #endregion

    #region " Control Events "
    /// <summary>
    /// Handles Add Button's click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_OnClick(object sender, EventArgs e)
    {
        txtName.Focus();
        btnAdd.Visible = false;
        btnSave.Visible = true;
        hdnBackTo.Value = "2";
    }

    /// <summary>
    /// Handles Save Button's click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_OnClick(object sender, EventArgs e)
    {
        clsEPM_MilestoneRecipients ObjEPM_MilestoneRecipients = new clsEPM_MilestoneRecipients();
        ObjEPM_MilestoneRecipients.PK_EPM_MilestoneRecipients = PK_EPM_MilestoneRecipients;
        if (txtName.Text != "") ObjEPM_MilestoneRecipients.Name = txtName.Text;
        if (txtEmail.Text != "") ObjEPM_MilestoneRecipients.EMail = txtEmail.Text;
        ObjEPM_MilestoneRecipients.Updated_By = clsSession.UserName;
        ObjEPM_MilestoneRecipients.Update_Date = clsGeneral.FormatDateToStore(DateTime.Now);

        if (PK_EPM_MilestoneRecipients > 0)
        {
            ObjEPM_MilestoneRecipients.Update();
        }
        else
            PK_EPM_MilestoneRecipients = ObjEPM_MilestoneRecipients.Insert();

        if (rdoDeleteEMail.SelectedValue == "Y")
        {
            clsEPM_MilestoneRecipients.DeleteByPK(PK_EPM_MilestoneRecipients);
            trDeleteEmail.Visible = false;
            btnSave.Text = btnSave.Text.Replace("Edit", "Save");
        }

        BindExistingEmailAddress();
        ClearControls();
    }

    /// <summary>
    /// Handles Cancel Button's click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_OnClick(object sender, EventArgs e)
    {
        if (hdnBackTo.Value == "1")
        {
            ClientScript.RegisterClientScriptBlock(Page.GetType(), DateTime.Now.ToString(), "javascript:BindMailRecipientList();", true);
        }

        if (hdnBackTo.Value == "2")
        {
            btnAdd.Visible = true;
            btnSave.Visible = false;
            trDeleteEmail.Visible = false;
            lstEMail_Recipients.ClearSelection();
            txtName.Text = "";
            txtEmail.Text = "";
            hdnBackTo.Value = "1";
        }

    }

    /// <summary>
    /// Handles selected index Change of lstEMail_Recipients
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lstEMail_Recipients_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        if (lstEMail_Recipients.SelectedIndex >= 0)
        {
            hdnBackTo.Value = "2";
            trDeleteEmail.Visible = true;
            btnAdd.Visible = false;
            btnSave.Visible = true;
            rdoDeleteEMail.SelectedValue = "N";
            DataTable dtMailRecipients = clsEPM_MilestoneRecipients.SelectByPK(Convert.ToDecimal(lstEMail_Recipients.SelectedValue)).Tables[0];
            if (dtMailRecipients != null && dtMailRecipients.Rows.Count > 0)
            {
                PK_EPM_MilestoneRecipients = dtMailRecipients.Rows[0]["PK_EPM_MilestoneRecipients"].ToString() != "" ? Convert.ToDecimal(dtMailRecipients.Rows[0]["PK_EPM_MilestoneRecipients"].ToString()) : 0;
                txtName.Text = dtMailRecipients.Rows[0]["Name"].ToString() != "" ? dtMailRecipients.Rows[0]["Name"].ToString() : "";
                txtEmail.Text = dtMailRecipients.Rows[0]["EMail"].ToString() != "" ? dtMailRecipients.Rows[0]["EMail"].ToString() : "";
            }
        }
    }
    #endregion
}
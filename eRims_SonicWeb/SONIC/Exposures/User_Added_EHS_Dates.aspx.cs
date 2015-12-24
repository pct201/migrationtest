using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;

public partial class SONIC_Exposures_User_Added_EHS_Dates : System.Web.UI.Page
{

    #region ::Properties::

    private decimal PK_RLCM_QA_QC_EHS_Dates
    {
        get { return clsGeneral.GetDecimal(ViewState["PK_RLCM_QA_QC_EHS_Dates"]); }
        set { ViewState["PK_RLCM_QA_QC_EHS_Dates"] = value; }
    }

    private decimal PK_RLCM
    {
        get { return clsGeneral.GetDecimal(ViewState["PK_RLCM"]); }
        set { ViewState["PK_RLCM"] = value; }
    }

    #endregion

    #region ::Page Load::

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int intRLCM;
            int intID;
            //if (!string.IsNullOrEmpty(Request.QueryString["RLCM"]))
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["RLCM"]), out intRLCM))
            {
                PK_RLCM = intRLCM;
                ComboHelper.FillLocationByRLCM(new DropDownList[] { ddlLocation }, PK_RLCM, true, false);
            }


            //if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            if (int.TryParse(Encryption.Decrypt(Request.QueryString["id"]), out intID))
            {
                PK_RLCM_QA_QC_EHS_Dates = intID;
                Edit();
            }
        }
    }

    #endregion

    #region ::Click Event::

    /// <summary>
    /// Save click.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsRLCM_QA_QC_EHS_Dates objclsRLCM_QA_QC_EHS_Dates = new clsRLCM_QA_QC_EHS_Dates();

        objclsRLCM_QA_QC_EHS_Dates.FK_LU_Location = ddlLocation.SelectedIndex > 0 ? Convert.ToDecimal(ddlLocation.SelectedValue) : 0;
        objclsRLCM_QA_QC_EHS_Dates.Category = txtCategory.Text.Trim();
        objclsRLCM_QA_QC_EHS_Dates.Type = txtType.Text.Trim();

        if (!string.IsNullOrEmpty(txtDue_Date.Text))
            objclsRLCM_QA_QC_EHS_Dates.Date = clsGeneral.FormatDateToStore(txtDue_Date.Text);

        objclsRLCM_QA_QC_EHS_Dates.FK_RLCM_QA_QC = PK_RLCM;
        objclsRLCM_QA_QC_EHS_Dates.Updated_By = clsSession.UserName;
        objclsRLCM_QA_QC_EHS_Dates.Update_Date = DateTime.Now;

        if (PK_RLCM_QA_QC_EHS_Dates > 0)
        {
            objclsRLCM_QA_QC_EHS_Dates.PK_RLCM_QA_QC_EHS_Dates = PK_RLCM_QA_QC_EHS_Dates;
            objclsRLCM_QA_QC_EHS_Dates.Update();
        }
        else
        {
            PK_RLCM_QA_QC_EHS_Dates = objclsRLCM_QA_QC_EHS_Dates.Insert();
        }

        ClosePage();
    }

    /// <summary>
    /// Delete record.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        clsRLCM_QA_QC_EHS_Dates.DeleteByPK(PK_RLCM_QA_QC_EHS_Dates);
        ClosePage();
    }

    #endregion

    #region ::Methods::

    /// <summary>
    /// Edit Mode.
    /// </summary>
    public void Edit()
    {
        if (PK_RLCM_QA_QC_EHS_Dates > 0)
        {
            btnDelete.Visible = true;

            clsRLCM_QA_QC_EHS_Dates objclsRLCM_QA_QC_EHS_Dates = new clsRLCM_QA_QC_EHS_Dates(PK_RLCM_QA_QC_EHS_Dates);
            txtCategory.Text = objclsRLCM_QA_QC_EHS_Dates.Category;

            if (!string.IsNullOrEmpty(Convert.ToString(objclsRLCM_QA_QC_EHS_Dates.Date)))
                txtDue_Date.Text = clsGeneral.FormatDateToDisplay(Convert.ToDateTime(objclsRLCM_QA_QC_EHS_Dates.Date));

            txtType.Text = objclsRLCM_QA_QC_EHS_Dates.Type;

            if (objclsRLCM_QA_QC_EHS_Dates.FK_LU_Location > 0)
                ddlLocation.SelectedValue = Convert.ToString(objclsRLCM_QA_QC_EHS_Dates.FK_LU_Location);
        }
        else
        {
            btnDelete.Visible = false;
        }
    }

    /// <summary>
    /// Close Current Page.
    /// </summary>
    private void ClosePage()
    {
        Page.ClientScript.RegisterStartupScript(typeof(string), "keyclosewindow", " window.opener.document.getElementById('ctl00_ContentPlaceHolder1_btnRefresh').click(); window.close();", true);
    }

    #endregion
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_CRM_Legal_Email : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_CRM_Legal_Email
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_CRM_Legal_Email"]);
        }
        set { ViewState["PK_LU_CRM_Legal_Email"] = value; }
    }

    #endregion

    #region "Page Event"

    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
        }
    }

    #endregion

    #region "Event"

    /// <summary>
    /// Add new button link event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {
        btnAdd.Text = "Add";
        _PK_LU_CRM_Legal_Email = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtSubject.Text = "";
        txtBody.Text = "";
        txtRecipients.Text = "";
        txtCCRecipients.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSubject);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trStatusAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtSubject.Text = "";
        txtBody.Text = "";
        txtRecipients.Text = "";
        txtCCRecipients.Text = "";
        rdblActive.SelectedValue = "Y";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        LU_CRM_Legal_Email objCRMLegalEmail = new LU_CRM_Legal_Email();
        objCRMLegalEmail.Subject = txtSubject.Text.Trim();
        objCRMLegalEmail.Body = txtBody.Text.Trim();
        objCRMLegalEmail.Recipients = txtRecipients.Text.Trim();
        objCRMLegalEmail.CC_Recpients = txtCCRecipients.Text.Trim();
        objCRMLegalEmail.PK_LU_CRM_Legal_Email = _PK_LU_CRM_Legal_Email;
        objCRMLegalEmail.Active = rdblActive.SelectedValue;

        if (_PK_LU_CRM_Legal_Email > 0)
        {
            _retVal = objCRMLegalEmail.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "Legal Email with the same Subject already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSubject);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objCRMLegalEmail.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "Legal Email with the same Subject already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSubject);
                return;
            }
            _PK_LU_CRM_Legal_Email = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region "Grid Event"

    protected void gvCRMLegalEmail_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCRMLegalEmail.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvCRMLegalEmail_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_CRM_Legal_Email = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_CRM_Legal_Email objEmail = new LU_CRM_Legal_Email(_PK_LU_CRM_Legal_Email);
            txtSubject.Text = objEmail.Subject;
            txtBody.Text = objEmail.Body;
            txtRecipients.Text = objEmail.Recipients;
            txtCCRecipients.Text = objEmail.CC_Recpients;
            if (objEmail.Active != null)
                rdblActive.SelectedValue = objEmail.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtSubject);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_CRM_Legal_Email.SelectAll();
        //Apply Dataset to Grid
        gvCRMLegalEmail.DataSource = dsGroup;
        gvCRMLegalEmail.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_CRM_Legal_Email = 0;
    }

    #endregion
}
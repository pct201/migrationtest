using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_LU_Document_Type : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Document_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Document_Type"]);
        }
        set { ViewState["PK_Document_Type"] = value; }
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
        PK_Document_Type = 0;
        trDocumentAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtDocumentType.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDocumentType);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trDocumentAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtDocumentType.Text = "";
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
        LU_Document_Type objLU_Document_Type = new LU_Document_Type();
        objLU_Document_Type.Document_Type = txtDocumentType.Text.Trim();
        objLU_Document_Type.PK_Document_Type = PK_Document_Type;
        objLU_Document_Type.Active = rdblActive.SelectedValue;

        if (PK_Document_Type > 0)
        {
            _retVal = objLU_Document_Type.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Document Type that you are trying to Update already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDocumentType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Document_Type.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Document Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDocumentType);
                return;
            }
            PK_Document_Type = _retVal;
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

    protected void gvDocument_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDocument_Type.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvDocument_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_Document_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trDocumentAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Document_Type objDocument_Type = new LU_Document_Type(PK_Document_Type);
            txtDocumentType.Text = objDocument_Type.Document_Type.ToString();
            if (objDocument_Type.Active != null)
                rdblActive.SelectedValue = objDocument_Type.Active;
            else
                rdblActive.SelectedIndex = 0;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtDocumentType);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Brand Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Document_Type.SelectAll();
        //Apply Dataset to Grid
        gvDocument_Type.DataSource = dsGroup;
        gvDocument_Type.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_Document_Type = 0;
    }

    #endregion
}
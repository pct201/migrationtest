using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Origin_Type : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Origin_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Origin_Type"]);
        }
        set { ViewState["PK_LU_Origin_Type"] = value; }
    }

    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
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
        PK_LU_Origin_Type = 0;
        trStatusAdd.Style.Add("display", "");
        lnkCancel.Style.Add("display", "");
        txtOrigin_Type.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrigin_Type);
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
        txtOrigin_Type.Text = "";
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        clsLU_Origin_Type objclsLU_Origin_Type = new clsLU_Origin_Type();
        objclsLU_Origin_Type.Descriptoin = txtOrigin_Type.Text.Trim();
        objclsLU_Origin_Type.PK_LU_Origin_Type = PK_LU_Origin_Type;

        if (PK_LU_Origin_Type > 0)
        {
            _retVal = objclsLU_Origin_Type.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Origin Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrigin_Type);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objclsLU_Origin_Type.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Origin Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrigin_Type);
                return;
            }
            PK_LU_Origin_Type = _retVal;
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

    protected void gvOrigin_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOrigin_Type.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvOrigin_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Origin_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            clsLU_Origin_Type objclsLU_Origin_Type = new clsLU_Origin_Type(PK_LU_Origin_Type);
            txtOrigin_Type.Text = Convert.ToString(objclsLU_Origin_Type.Descriptoin);
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtOrigin_Type);
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
        DataSet dsGroup = clsLU_Origin_Type.SelectAll();
        //Apply Dataset to Grid
        gvOrigin_Type.DataSource = dsGroup;
        gvOrigin_Type.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Origin_Type = 0;
    }

    #endregion
}
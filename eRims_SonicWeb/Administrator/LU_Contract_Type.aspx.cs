using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class Administrator_LU_Contract_Type : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_LU_Contract_Type
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Contract_Type"]);
        }
        set { ViewState["PK_LU_Contract_Type"] = value; }
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
        PK_LU_Contract_Type = 0;
        trStatusAdd.Style.Add("display", "");
        lnkCancel.Style.Add("display", "");
        txtContractType.Text = "";
        
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtContractType);
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
        txtContractType.Text = "";
        
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        LU_Contract_Type objLU_Contract_Type = new LU_Contract_Type();
        objLU_Contract_Type.Descr = txtContractType.Text.Trim();
        objLU_Contract_Type.PK_LU_Contract_Type = PK_LU_Contract_Type;
        

        if (PK_LU_Contract_Type > 0)
        {
            _retVal = objLU_Contract_Type.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Contract Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtContractType);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objLU_Contract_Type.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Contract Type that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtContractType);
                return;
            }
            PK_LU_Contract_Type = _retVal;
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

    protected void gvContract_Type_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvContract_Type.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid();
    }
    protected void gvContract_Type_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_LU_Contract_Type = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_Contract_Type objLU_Contract_Type = new LU_Contract_Type(PK_LU_Contract_Type);
            txtContractType.Text = Convert.ToString(objLU_Contract_Type.Descr);
            
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtContractType);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Contract Type Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Contract_Type.SelectAll();
        //Apply Dataset to Grid
        gvContract_Type.DataSource = dsGroup;
        gvContract_Type.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_LU_Contract_Type = 0;
    }

    #endregion
}
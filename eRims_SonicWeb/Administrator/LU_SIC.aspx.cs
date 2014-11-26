using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class Administrator_LU_SIC : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal _PK_LU_SIC
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_SIC"]);
        }
        set { ViewState["PK_LU_SIC"] = value; }
    }

    #endregion

    #region "Page Event"

    /// <summary>
    /// Handles event when page is loaded
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //check Is Page Post Back
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid(1,10);
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
        _PK_LU_SIC = 0;
        trStatusAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtCode.Text = "";
        txtDesc1.Text = "";
        txtDesc2.Text = "";
        txtDesc3.Text = "";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCode);
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
        txtCode.Text = "";
        
    }

    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        decimal _retVal;
        LU_SIC objSIC = new LU_SIC();
        objSIC.PK_LU_SIC = _PK_LU_SIC;
        objSIC.Fld_Code = txtCode.Text.Trim();
        objSIC.Fld_Desc_1 = txtDesc1.Text.Trim();
        objSIC.Fld_Desc_2 = txtDesc2.Text.Trim();
        objSIC.Fld_Desc_3 = txtDesc3.Text.Trim();
        
        if (_PK_LU_SIC > 0)
        {
            _retVal = objSIC.Update();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The code and descriptions combination that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCode);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objSIC.Insert();
            // Used to Check Duplicate CRM Brand ID?
            if (_retVal == -2)
            {
                lblError.Text = "The code and descriptions combination that you are trying to add already exists.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCode);
                return;
            }
            _PK_LU_SIC = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid(ucPaging.CurrentPage, ucPaging.PageSize);
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region "Grid Event"

    /// <summary>
    /// Handles Rowcommand event for grid
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvSIC_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            _PK_LU_SIC = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trStatusAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            LU_SIC objSIC = new LU_SIC(_PK_LU_SIC);
            txtCode.Text = objSIC.Fld_Code;
            txtDesc1.Text = objSIC.Fld_Desc_1;
            txtDesc2.Text = objSIC.Fld_Desc_2;
            txtDesc3.Text = objSIC.Fld_Desc_3;
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtCode);
        }
        else if (e.CommandName == "DeleteRecord")
        {
            LU_SIC.DeleteByPK(Convert.ToDecimal(e.CommandArgument.ToString()));
            BindGrid(ucPaging.CurrentPage, ucPaging.PageSize);
        }
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind CRM Brand Grid
    /// </summary>
    private void BindGrid(int intPageNum, int intPageSize)
    {
        //Get Record into Dataset
        DataSet dsSIC = LU_SIC.SelectByPaging(intPageNum, intPageSize);
        DataTable dtSIC = dsSIC.Tables[0];
        
        //Apply Dataset to Grid
        gvSIC.DataSource = dtSIC;
        gvSIC.DataBind();

        // set values for paging control,so it shows values as needed.
        ucPaging.TotalRecords = (dsSIC.Tables.Count >= 2) ? Convert.ToInt32(dsSIC.Tables[1].Rows[0][0]) : 0;
        ucPaging.CurrentPage = (dsSIC.Tables.Count > 1) ? Convert.ToInt32(dsSIC.Tables[2].Rows[0][2]) : 1;
        ucPaging.RecordsToBeDisplayed = dtSIC.Rows.Count;
        ucPaging.SetPageNumbers();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        _PK_LU_SIC = 0;
    }

    /// <summary>
    /// Binds the grid with currently selected page
    /// </summary>
    protected void GetPage()
    {
        BindGrid(ucPaging.CurrentPage, ucPaging.PageSize);
    }
    #endregion
}
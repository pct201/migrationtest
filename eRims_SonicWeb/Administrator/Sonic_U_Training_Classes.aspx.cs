using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrator_Sonic_U_Training_Classes : clsBasePage
{
    #region "Properties"

    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public decimal PK_Sonic_U_Training_Classes
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_Sonic_U_Training_Classes"]);
        }
        set { ViewState["PK_Sonic_U_Training_Classes"] = value; }
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

    #region "Grid Event"

    /// <summary>
    /// Training row command event in edit,view or remove mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTrainingClasses_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditRecord")
        {
            PK_Sonic_U_Training_Classes = Convert.ToDecimal(e.CommandArgument);
            // show and hide Add-edit row
            trTrainingAdd.Style.Add("display", "block");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
            // get record from database
            Sonic_U_Training_Classes objSonic_U_Training_Classes = new Sonic_U_Training_Classes(PK_Sonic_U_Training_Classes);
            txtClassName.Text = objSonic_U_Training_Classes.Class_Name.ToString();
            if (objSonic_U_Training_Classes.Active != null)
                rdblActive.SelectedValue = objSonic_U_Training_Classes.Active;
            else
                rdblActive.SelectedIndex = 0;
            // set focus to control
            ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtClassName);
        }
    }

    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvTrainingClasses_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //Page new index call
        gvTrainingClasses.PageIndex = e.NewPageIndex;
        //Bind Grid Function
        BindGrid();
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
        PK_Sonic_U_Training_Classes = 0;
        trTrainingAdd.Style.Add("display", "block");
        lnkCancel.Style.Add("display", "inline");
        txtClassName.Text = "";
        rdblActive.SelectedValue = "Y";
        ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtClassName);
    }

    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trTrainingAdd.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtClassName.Text = "";
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
        Sonic_U_Training_Classes objSonic_U_Training_Classes = new Sonic_U_Training_Classes();
        objSonic_U_Training_Classes.Class_Name = txtClassName.Text.Trim();
        objSonic_U_Training_Classes.PK_Sonic_U_Training_Classes = PK_Sonic_U_Training_Classes;
        objSonic_U_Training_Classes.Active = rdblActive.SelectedValue;
        objSonic_U_Training_Classes.Update_Date = DateTime.Now;
        objSonic_U_Training_Classes.Updated_By = clsSession.UserID;

        if (PK_Sonic_U_Training_Classes > 0)
        {
            _retVal = objSonic_U_Training_Classes.Update();
            // Used to Check Duplicate Class Name ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Class Name that you are trying to add already exists in the table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtClassName);
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            _retVal = objSonic_U_Training_Classes.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (_retVal == -2)
            {
                lblError.Text = "The Class NAme that you are trying to add already exists in the table.";
                ((ScriptManager)this.Master.FindControl("scMain")).SetFocus(txtClassName);
                return;
            }
            PK_Sonic_U_Training_Classes = _retVal;
        }
        //claer Control
        ClearControls();
        //Bind Grid Function
        BindGrid();
        //Cancel CLick
        lnkCancel_Click(null, null);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Bind Training Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = Sonic_U_Training_Classes.SelectAll();
        //Apply Dataset to Grid
        gvTrainingClasses.DataSource = dsGroup;
        gvTrainingClasses.DataBind();
    }

    /// Used to Clear the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        PK_Sonic_U_Training_Classes = 0;
    }
    #endregion
}
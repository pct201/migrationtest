using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;


public partial class Administrator_Manufacturer :clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_LU_Manufacturer
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Manufacturer"]);
        }
        set { ViewState["PK_LU_Manufacturer"] = value; }
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
    /// Manufacturer row command event in edit,view or remove mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManufacturer_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //View mode
        //if (e.CommandName == "View")
        //{
        //    int Index = Convert.ToInt32(e.CommandArgument);
        //    //trManufacturerView.Style.Add("display", "none");
        //    //trManufacturerView.Style.Add("display", "block");
        //    lnkCancel.Style.Add("display", "inline");
        //    LinkButton lnkvv = (LinkButton)gvManufacturer.Rows[Index].FindControl("lnkView");
        //    HiddenField hdnManufacturerID = (HiddenField)gvManufacturer.Rows[Index].FindControl("hdnManufacturerID");
        //    //lblManufacturer.Text = lnkvv.Text;
        //}
        //Remove mode 
        //if (e.CommandName == "Remove")
        //{
        //    int Index = Convert.ToInt32(e.CommandArgument);
        //    HiddenField hdnManufacturerID = (HiddenField)gvManufacturer.Rows[Index].FindControl("hdnManufacturerID");
        //    //used to check PK id. if greater than 0 than delete record                    
        //    if (Convert.ToInt32(hdnManufacturerID.Value) > 0)
        //    {
        //        LU_Manufacturer.DeleteByPK(Convert.ToInt32(hdnManufacturerID.Value));
        //    }           
        //    //Bind Grid
        //    BindGrid();
        //    trManufacturerAdd.Style.Add("display", "none");
        //    //trManufacturerView.Style.Add("display", "none");
        //}
        //Edit mode
        if (e.CommandName == "Edit")
        {
            int Index = Convert.ToInt32(e.CommandArgument);
            trManufacturerAdd.Style.Add("display", "block");
            //trManufacturerView.Style.Add("display", "none");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
           // LinkButton lnkvv = (LinkButton)gvManufacturer.Rows[Index].FindControl("lnkView");
            Label lbldesc = (Label)gvManufacturer.Rows[Index].FindControl("lbldesc");
            HiddenField hdnManufacturerID = (HiddenField)gvManufacturer.Rows[Index].FindControl("hdnManufacturerID");
            PK_LU_Manufacturer = Convert.ToInt32(hdnManufacturerID.Value);
            //txtManufacturer.Text = lnkvv.Text;
            txtManufacturer.Text = lbldesc.Text;
            txtManufacturer.Focus();
        }
    }
    /// <summary>
    /// Manufacturer row created event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManufacturer_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton LnkRemove = (LinkButton)e.Row.FindControl("lnkRemove");
            //LinkButton LnkView = (LinkButton)e.Row.FindControl("lnkView");
            LinkButton LnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");

            if (LnkRemove != null)
            {
                LnkRemove.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
            //if (LnkView != null)
            //{
            //    LnkView.CommandArgument = Convert.ToString(e.Row.RowIndex);
            //}
            if (LnkEdit != null)
            {
                LnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }
    }
    /// <summary>
    /// Row editing click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManufacturer_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManufacturer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvManufacturer.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(); //Bind Grid Function
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
        PK_LU_Manufacturer = 0;
        trManufacturerAdd.Style.Add("display", "block");
        //trManufacturerView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "inline");
        txtManufacturer.Text = "";
        txtManufacturer.Focus();  
    }
    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trManufacturerAdd.Style.Add("display", "none");
        //trManufacturerView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtManufacturer.Text = "";
    }
    /// <summary>
    /// Add new button to save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        LU_Manufacturer objGroup = new LU_Manufacturer(PK_LU_Manufacturer);
        objGroup.PK_LU_Manufacturer = PK_LU_Manufacturer;
        objGroup.Fld_Desc = txtManufacturer.Text;
        if (PK_LU_Manufacturer > 0)
        {
           PK_LU_Manufacturer = objGroup.Update();
            // Used to Check Duplicate Manufacturer ID?
            if (PK_LU_Manufacturer == -2)
            {
                lblError.Text = "The Manufacturer that you are trying to add already exists in the Manufacturer table.";
                //claer Control
                ClearControls();
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            PK_LU_Manufacturer = objGroup.Insert();
            // Used to Check Duplicate Manufacturer ID?
            if (PK_LU_Manufacturer == -2)
            {
                lblError.Text = "The Manufacturer that you are trying to add already exists in the Manufacturer table.";
                //claer Control
                ClearControls();
                return;
            }
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
    /// Bind Manufacturer Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Manufacturer.SelectAll();
        //Apply Dataset to Grid
        gvManufacturer.DataSource = dsGroup;
        gvManufacturer.DataBind();
    }

    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        //txtManufacturer.Text = "";        
        PK_LU_Manufacturer = 0;
    }
    #endregion
    
}

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


public partial class Administrator_DealershipDepartment : clsBasePage
{
    #region "Properties"
    /// <summary>
    /// Denotes the Primary Key
    /// </summary>
    public int PK_LU_Dealership_Department
    {
        get
        {
            return clsGeneral.GetInt(ViewState["PK_LU_Dealership_Department"]);
        }
        set { ViewState["PK_LU_Dealership_Department"] = value; }
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

    #region "GridView Event"
    /// <summary>
    /// Delership Department Row command event in view,edit or remove mode
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDelershipDept_RowCommand(object sender, GridViewCommandEventArgs e)
    {        
        //Edit mode
        if (e.CommandName == "Edit")
        {           
            int Index = Convert.ToInt32(e.CommandArgument);
            trDelearshipAdd.Style.Add("display", "block");
            //trDelearshipView.Style.Add("display", "none");
            lnkCancel.Style.Add("display", "inline");
            btnAdd.Text = "Update";
           // LinkButton lnkvv = (LinkButton)gvDelershipDept.Rows[Index].FindControl("lnkView");
            Label lbldesc = (Label)gvDelershipDept.Rows[Index].FindControl("lbldesc");
            HiddenField hdnDealershipID = (HiddenField)gvDelershipDept.Rows[Index].FindControl("hdnDealershipID");
            PK_LU_Dealership_Department = Convert.ToInt32(hdnDealershipID.Value);
            txtDealership.Text = lbldesc.Text;
            txtDealership.Focus();  
        }
    }
    /// <summary>
    /// Delership Department row created event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDelershipDept_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {         
            LinkButton LnkEdit = (LinkButton)e.Row.FindControl("lnkEdit");            
            if (LnkEdit != null)
            {
                LnkEdit.CommandArgument = Convert.ToString(e.Row.RowIndex);
            }
        }
    }
    protected void gvDelershipDept_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    /// <summary>
    /// Page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvDelershipDept_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDelershipDept.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(); //Bind Grid Function
    }
    #endregion

    #region "Event"
    /// <summary>
    /// Add new link button click event 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkAddNew_Click(object sender, EventArgs e)
    {       
        btnAdd.Text = "Add";
        PK_LU_Dealership_Department = 0;
        trDelearshipAdd.Style.Add("display", "block");
        //trDelearshipView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "inline");
        txtDealership.Text = "";
        txtDealership.Focus();  
    }
    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void lnkCancel_Click(object sender, EventArgs e)
    {
        trDelearshipAdd.Style.Add("display", "none");
        //trDelearshipView.Style.Add("display", "none");
        lnkCancel.Style.Add("display", "none");
        txtDealership.Text = "";       
    }
    /// <summary>
    /// Add new button to click save data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {       
        LU_Dealership_Department objGroup = new LU_Dealership_Department(PK_LU_Dealership_Department);
        objGroup.PK_LU_Dealership_Department = PK_LU_Dealership_Department;
        objGroup.Fld_Desc = txtDealership.Text;
        if (PK_LU_Dealership_Department > 0)
        {
            PK_LU_Dealership_Department = objGroup.Update();
            // Used to Check Duplicate Dealership Department ID?
            if (PK_LU_Dealership_Department == -2)
            {
                lblError.Text = "Dealership Department Name already exists.";
                //claer Control
                ClearControls();
                return;
            }
            btnAdd.Text = "Add";
        }
        else
        {
            PK_LU_Dealership_Department = objGroup.Insert();
            // Used to Check Duplicate Dealership Department ID?
            if (PK_LU_Dealership_Department == -2)
            {
                lblError.Text = "Dealership Department Name already exists.";
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
    /// Bind Delership Department Grid
    /// </summary>
    private void BindGrid()
    {
        //Get Record into Dataset
        DataSet dsGroup = LU_Dealership_Department.SelectAll();
        //Apply Dataset to Grid
        gvDelershipDept.DataSource = dsGroup;
        gvDelershipDept.DataBind();
    }
      
    /// Used to Claer the controls
    /// </summary>
    private void ClearControls()
    {
        //clear control
        //txtDealership.Text = "";
        PK_LU_Dealership_Department = 0;
    }
    #endregion
   
}

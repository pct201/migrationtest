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
public partial class SONIC_Purchasing_ManufacturerPopupWinodow : System.Web.UI.Page
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

    #region "Variable"
    DataTable dtSearch = null;
    #endregion

    #region "Page Event"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Bind Grid Function
            BindGrid();
            // check whether the textbox ID of the caller form 
            // is passed for setting the value if required or not
            if (Request.QueryString["txtID"] != null)
            {
                // store the ID in hidden field
                hdnID.Value = Request.QueryString["txtID"].ToString();
            }
            txtManufacture.Attributes.Add("onkeypress", "trapKey(event,'" + btnSearch.ClientID + "');");
        }
    }
    #endregion

    #region "Event"
    /// <summary>
    /// Search button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        LU_Manufacturer objLumanufacture = new LU_Manufacturer();
        if (txtManufacture.Text != "")
        {
            DataSet dsManufactureSearch = LU_Manufacturer.ManufacturerSearch(txtManufacture.Text.Trim().Replace("'", "''"));
            if (dsManufactureSearch.Tables[0].Rows.Count > 0)
            {
                dtSearch = dsManufactureSearch.Tables[0];
                gvManufacturer.DataSource = dtSearch;
                gvManufacturer.DataBind();
            }
            else
            {
                dtSearch = dsManufactureSearch.Tables[0];
                gvManufacturer.DataSource = dtSearch;
                gvManufacturer.DataBind();
            }
        }
        else
        {

            //Get Record into Dataset
            dtSearch = LU_Manufacturer.SelectAll().Tables[0];
            //Apply Dataset to Grid
            gvManufacturer.DataSource = dtSearch;
            gvManufacturer.DataBind();

        }
        btnSave.Text = "Save";
        //txtManufacture.Text = "";       
    }
    /// <summary>
    /// Add button click event in panel is add or search visible set 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        pnlAdd.Visible = true;
        pnlSearch.Visible = false;
        txtAddManufacture.Text = "";
        BindGrid();//Bind Grid Function
        btnSave.Text = "Save";
    }
    /// <summary>
    /// Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LU_Manufacturer objGroup = new LU_Manufacturer();
        ManufacturerSaveData(objGroup);
        PK_LU_Manufacturer = objGroup.Insert();
        // Used to Check Duplicate Manufacturer ID?
        if (PK_LU_Manufacturer == -2)
        {
            if (btnSave.Text.Trim().ToLower() != "ok")
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('The Manufacturer that you are trying to add already exists in the Manufacturer table');", true);

                //lblError.Text = "The Manufacturer that you are trying to add already exists in the Manufacturer table.";
                //txtAddManufacture.Text = "";
                btnSave.Text = "OK";
            }
            else
            {
                pnlSearch.Visible = true;
                pnlAdd.Visible = false;
                string strID = PK_LU_Manufacturer.ToString();
                string strManufacture = txtAddManufacture.Text.ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:SetValue(" + strID + ",'" + strManufacture + "','');", true);
            }
        }
        else
        {
            pnlSearch.Visible = true;
            pnlAdd.Visible = false;
            string strID = PK_LU_Manufacturer.ToString();
            BindGrid();//Bind Grid Function
        }
    }
    /// <summary>
    /// Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        txtAddManufacture.Text = "";
        pnlAdd.Visible = false;
        pnlSearch.Visible = true;
    }
    #endregion

    #region "Methods"
    /// <summary>
    /// Bind Manufacture function Grid
    /// </summary>
    private void BindGrid()
    {
        //if (dtSearch != null)
        //{
        if (txtManufacture.Text != "")
        {
            DataSet dsManufactureSearch = LU_Manufacturer.ManufacturerSearch(txtManufacture.Text.Trim().Replace("'", "''"));
            if (dsManufactureSearch.Tables[0].Rows.Count > 0)
            {
                dtSearch = dsManufactureSearch.Tables[0];
                gvManufacturer.DataSource = dtSearch;
                gvManufacturer.DataBind();
            }
        }
        else
        {
            //Get Record into Dataset
            dtSearch = LU_Manufacturer.SelectAll().Tables[0];
            //Apply Dataset to Grid
            gvManufacturer.DataSource = dtSearch;
            gvManufacturer.DataBind();
        }
        //}
    }

    /// <summary>
    /// Function to call in Manufacturer bind data
    /// </summary>
    /// <param name="objNotes"></param>
    private void ManufacturerSaveData(LU_Manufacturer objGroup)
    {
        objGroup.PK_LU_Manufacturer = PK_LU_Manufacturer;
        objGroup.Fld_Desc = txtAddManufacture.Text;
    }
    #endregion

    #region "GridEvent"
    /// <summary>
    /// Row data bound event in manufacturer 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManufacturer_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (dtSearch != null)
            {
                for (int i = 1; i < dtSearch.Columns.Count; i++)
                {
                    string strID = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "PK_LU_Manufacturer"));
                    string strManufacture = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "Fld_Desc"));
                    HtmlAnchor a = (HtmlAnchor)e.Row.FindControl("lnkmanufacturer");
                    if (Request.QueryString["txtID"] != null)
                    {
                        a.HRef = "javascript:SetValue(" + strID + ",'" + strManufacture + "','');";
                    }
                }
            }
        }
    }
    /// <summary>
    /// Grid Manufacturer page index change event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void gvManufacturer_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvManufacturer.PageIndex = e.NewPageIndex; //Page new index call
        BindGrid(); //Bind Grid Function       
    }
    #endregion

}

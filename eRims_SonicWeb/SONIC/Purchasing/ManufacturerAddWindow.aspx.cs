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

public partial class SONIC_Purchasing_ManufacturerAddWindow : System.Web.UI.Page
{
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

    /// <summary>
    /// Handles Page load event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    /// <summary>
    /// Handles Save button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSave_Click(object sender, EventArgs e)
    {
        // create object for manufacturer
        LU_Manufacturer objGroup = new LU_Manufacturer(PK_LU_Manufacturer);

        // set values from page controls
        objGroup.PK_LU_Manufacturer = PK_LU_Manufacturer;
        objGroup.Fld_Desc = txtManufacture.Text;
        if (PK_LU_Manufacturer > 0)
        {
            PK_LU_Manufacturer = objGroup.Update();
            // Used to Check Duplicate User ID?
            if (PK_LU_Manufacturer == -2)
            {
                lblError.Text = "The Manufacturer that you are trying to add already exists in the Manufacturer table.";
                txtManufacture.Text = "";             
                return;
            }           
        }
        else
        {
            PK_LU_Manufacturer = objGroup.Insert();
            // Used to Check Duplicate User ID?
            if (PK_LU_Manufacturer == -2)
            {
                lblError.Text = "The Manufacturer that you are trying to add already exists in the Manufacturer table.";
                txtManufacture.Text = "";
                return;
            }
            else
            {
                Response.Redirect("ManufacturerPopupWinodow.aspx");
            }
        }
    }

    /// <summary>
    /// Handles Cancel button click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManufacturerPopupWinodow.aspx");
    }
}

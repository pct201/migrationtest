using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
public partial class SONIC_Pollution_NAICS_PopUp : System.Web.UI.Page
{
    /// <summary>
    /// Page Load Event. This Page Bind NAICS Level Description and Bind Another NAICS Level Description by Selected DropDowlnList Wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            BindDropDown();
            //First 2 To 5 3 NAICS Description DropDown List Bind 
            drpNAICSLevel2.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));           
            drpNAICSLevel1.Focus();
            btnSelect.Enabled = false;
        }
    }
    /// <summary>
    /// Bind First NAICS Description Level Dropdown list   
    /// </summary>
    private void BindDropDown()
    {
        //Bind/Fill Dropdown list   
        DataSet dsData = LU_NAICS.GetLevelDesc(0,2);
        drpNAICSLevel1.DataTextField = "fld_Code_Description";
        drpNAICSLevel1.DataValueField = "PK_LU_NAICS";
        drpNAICSLevel1.DataSource = dsData;
        drpNAICSLevel1.DataBind();
        drpNAICSLevel1.Items.Insert(0, new ListItem("--Select--", "0"));
        
    }
    /// <summary>
    /// Handle Select Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string strPK_LU_NAICS = "", strFld_Code = "",  strFld_Desc = "";
        string strNAICSLevel1 = Convert.ToString(drpNAICSLevel1.SelectedItem.Text);
        string strNAICSLevel2 = Convert.ToString(drpNAICSLevel2.SelectedItem.Text);
        string strNAICSLevel3 = Convert.ToString(drpNAICSLevel3.SelectedItem.Text);
        string strNAICSLevel4 = Convert.ToString(drpNAICSLevel4.SelectedItem.Text);
        string strNAICSLevel5 = Convert.ToString(drpNAICSLevel5.SelectedItem.Text);   
        strNAICSLevel1 = strNAICSLevel1.Substring(5, strNAICSLevel1.Length-5);
        strNAICSLevel2 = strNAICSLevel2.Substring(6, strNAICSLevel2.Length - 6);
        strNAICSLevel3 = strNAICSLevel3.Substring(7, strNAICSLevel3.Length - 7);
        strNAICSLevel4 = strNAICSLevel4.Substring(8, strNAICSLevel4.Length - 8);

        //If NAICS Level 5 Description is selected value "0" then  NAICS Level 4 Description value save 
        if (Convert.ToString(drpNAICSLevel5.SelectedValue) == "0")
        {          
            strFld_Desc = strNAICSLevel1 + "<br/>" + strNAICSLevel2 + "<br/>" + strNAICSLevel3 + "<br/>" + strNAICSLevel4;
            strFld_Code = drpNAICSLevel4.SelectedItem.Text.Substring(0, 5);
        }
        else
        {
            strNAICSLevel5 = strNAICSLevel5.Substring(9, strNAICSLevel5.Length - 9);          
            strFld_Desc = strNAICSLevel1 + "<br/>" + strNAICSLevel2 + "<br/>" + strNAICSLevel3 + "<br/>" + strNAICSLevel4 + "<br/>" + strNAICSLevel5;
            strFld_Code = drpNAICSLevel5.SelectedItem.Text.Substring(0, 6);
        }      

        strPK_LU_NAICS = Convert.ToString(drpNAICSLevel4.SelectedValue);
        string strJSFunction = "SelectValue('" + strPK_LU_NAICS + "','" + strFld_Code + "','" + strFld_Desc + "','" + Server.HtmlEncode(strFld_Desc) + "');";
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), strJSFunction, true);
    }
    /// <summary>
    /// Handle Cancel Button Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {       
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.close();", true);
    }
    #region "DropDownList Selected Index Event"
    /// <summary>
    /// NAICS Level 1 Description DropDownList Selected Index changed event and Bind NAICS Level 2 Description data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpNAICSLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal strNAICSLevel1 = (drpNAICSLevel1.SelectedIndex > 0) ? Convert.ToDecimal(drpNAICSLevel1.SelectedValue) : -1;
        //Get NAICS Level 1 Description DropDownList Wise Descriprtion Bind Data      
        DataSet dsSICLevel1 = LU_NAICS.GetLevelDesc(strNAICSLevel1, 3);
        if (dsSICLevel1 != null && dsSICLevel1.Tables.Count > 0)
        {
            drpNAICSLevel2.Items.Clear();
            drpNAICSLevel2.DataTextField = "fld_Code_Description";
            drpNAICSLevel2.DataValueField = "PK_LU_NAICS";
            drpNAICSLevel2.DataSource = dsSICLevel1;
            drpNAICSLevel2.DataBind();
            drpNAICSLevel2.Items.Insert(0, new ListItem("--Select--", "0"));

            drpNAICSLevel3.Items.Clear();
            drpNAICSLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel4.Items.Clear();
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
        }

        if (drpNAICSLevel1.SelectedValue == "0")
        {
            drpNAICSLevel2.Items.Clear();
            drpNAICSLevel3.Items.Clear();
            drpNAICSLevel4.Items.Clear();
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel2.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;
        }
    }
    /// <summary>
    /// NAICS Level 2 Description DropDownList Selected Index changed event and Bind NAICS Level 3 Description data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpNAICSLevel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal strNAICSLevel2 = (drpNAICSLevel2.SelectedIndex > 0) ? Convert.ToDecimal(drpNAICSLevel2.SelectedValue) : -1;
        //Get Get NAICS Level 2 Wise Descriprtion Bind Data      
        DataSet dsSICLevel2 = LU_NAICS.GetLevelDesc(strNAICSLevel2, 4);
        if (dsSICLevel2 != null && dsSICLevel2.Tables.Count > 0)
        {
            drpNAICSLevel3.Items.Clear();
            drpNAICSLevel3.DataTextField = "fld_Code_Description";
            drpNAICSLevel3.DataValueField = "PK_LU_NAICS";
            drpNAICSLevel3.DataSource = dsSICLevel2;
            drpNAICSLevel3.DataBind();
            drpNAICSLevel3.Items.Insert(0, new ListItem("--Select--", "0"));

            drpNAICSLevel4.Items.Clear();
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        if (drpNAICSLevel2.SelectedValue == "0")
        {
            drpNAICSLevel3.Items.Clear();
            drpNAICSLevel4.Items.Clear();
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;
        }
    }
    /// <summary>
    /// NAICS Level 3 Description DropDownList Selected Index changed event and Bind NAICS Level 4 Description data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpNAICSLevel3_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal strNAICSLevel3 = (drpNAICSLevel3.SelectedIndex > 0) ? Convert.ToDecimal(drpNAICSLevel3.SelectedValue) : -1;
        //Get Get NAICS Level 3 Wise Descriprtion Bind Data      
        DataSet dsSICLevel3 = LU_NAICS.GetLevelDesc(strNAICSLevel3, 5);
        if (dsSICLevel3 != null && dsSICLevel3.Tables.Count > 0)
        {
            drpNAICSLevel4.Items.Clear();
            drpNAICSLevel4.DataTextField = "fld_Code_Description";
            drpNAICSLevel4.DataValueField = "PK_LU_NAICS";
            drpNAICSLevel4.DataSource = dsSICLevel3;
            drpNAICSLevel4.DataBind();
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));

            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
        }
        if (drpNAICSLevel3.SelectedValue == "0")
        {
            drpNAICSLevel4.Items.Clear();
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel4.Items.Insert(0, new ListItem("--Select--", "0"));
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;
        }
    }
    /// <summary>
    /// NAICS Level 4 Description DropDownList Selected Index changed event and Bind NAICS Level 5 Description data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpNAICSLevel4_SelectedIndexChanged(object sender, EventArgs e)
    {
        decimal strNAICSLevel4 = (drpNAICSLevel4.SelectedIndex > 0) ? Convert.ToDecimal(drpNAICSLevel4.SelectedValue) : -1;
        //Get NAICS Level 4  Wise Descriprtion Bind Data      
        DataSet dsSICLevel4 = LU_NAICS.GetLevelDesc(strNAICSLevel4, 6);
        if (dsSICLevel4 != null && dsSICLevel4.Tables.Count > 0)
        {
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel5.DataTextField = "fld_Code_Description";
            drpNAICSLevel5.DataValueField = "PK_LU_NAICS";
            drpNAICSLevel5.DataSource = dsSICLevel4;
            drpNAICSLevel5.DataBind();
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
            if(drpNAICSLevel5.Items.Count>1)
               btnSelect.Enabled = false;
            else
               btnSelect.Enabled = true;
        }
        if (drpNAICSLevel4.SelectedValue == "0")
        {
            drpNAICSLevel5.Items.Clear();
            drpNAICSLevel5.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;
        }
    } 
    /// <summary>
    /// NAICS Level 4 Description DropDownList Selected Index changed event and Bind NAICS Level 5 Description data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpNAICSLevel5_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (drpNAICSLevel5.SelectedValue == "0")
            btnSelect.Enabled = false;
        else
            btnSelect.Enabled = true;
    }
   
    #endregion
}
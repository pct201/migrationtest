using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;
public partial class SONIC_Pollution_SIC_PopUp : System.Web.UI.Page
{
    /// <summary>
    /// Page Load Event .This Page Bind SIC Level Description and Bind Another SIC Level Description by Selected DropDowlnList Wise
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {           
            BindDropDown();
            //First 2 and 3 Description DropDown List Bind 
            drpSICLevel2.Items.Insert(0, new ListItem("--Select--", "0"));
            drpSICLevel3.Items.Insert(0, new ListItem("--Select--", "0"));  
            drpSICLevel1.Focus();
            btnSelect.Enabled = false;
        }
    }
    /// <summary>
    /// Bind First SIC Level Dropdown list   
    /// </summary>
    private void BindDropDown()
    {
        //Bind First SIC Level Dropdown list   
        DataSet dsData = LU_SIC.SelectAllDistinct();
        drpSICLevel1.DataTextField = "fld_Desc_1";
        drpSICLevel1.DataValueField = "fld_Desc_1";
        drpSICLevel1.DataSource = dsData.Tables[0].DefaultView;
        drpSICLevel1.DataBind();           
        drpSICLevel1.Items.Insert(0, new ListItem("--Select--", "0"));
        
   
    }
    /// <summary>
    /// Handle Select Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSelect_Click(object sender, EventArgs e)
    {
        string strPK_LU_SIC = "", strFld_Code = "", strFld_Desc_1 = "", strFld_Desc_2 = "", strFld_Desc_3 = "", strFld_Desc = "" ;
        string strSICLevel1 =  Convert.ToString(drpSICLevel1.SelectedValue);
        string strSICLevel2 =  Convert.ToString(drpSICLevel2.SelectedValue);
        string strSICLevel3 = Convert.ToString(drpSICLevel3.SelectedValue);
        //Select By All There DropDownList Wise Fld Code Description and PK_LU_SIC Id return in data
        DataSet dsSICLevel = LU_SIC.SelectByFldCode(strSICLevel1, strSICLevel2, strSICLevel3);
        if (dsSICLevel != null && dsSICLevel.Tables.Count > 0 && dsSICLevel.Tables[0].Rows.Count > 0)
        {
            DataRow drRow = dsSICLevel.Tables[0].Rows[0];
            strPK_LU_SIC = Convert.ToString(drRow["PK_LU_SIC"]).Replace("'", "\\'");
            strFld_Code = Convert.ToString(drRow["Fld_Code"]).Replace("'", "\\'");
            strFld_Desc_1 = Convert.ToString(drRow["Fld_Desc_1"]).Replace("'", "\\'");
            strFld_Desc_2 = Convert.ToString(drRow["Fld_Desc_2"]).Replace("'", "\\'");
            strFld_Desc_3 = Convert.ToString(drRow["Fld_Desc_3"]).Replace("'", "\\'");    
            strFld_Desc = strFld_Desc_1 + "<br/>" + strFld_Desc_2 + "<br/>" + strFld_Desc_3;            
        }
        string strJSFunction = "SelectValue('" + strPK_LU_SIC + "','" + strFld_Code + "','" + strFld_Desc + "','" + Server.HtmlEncode(strFld_Desc) + "');";             
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), strJSFunction, true);
    }
    /// <summary>
    /// Handel Cancel Button Click Event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCancel_Click(object sender, EventArgs e)
    {      
        Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "window.close();", true);
    }
    #region "DropDownList Selected Index Event"
    /// <summary>
    /// SIC Level 1 Description DropDownList Selected Index changed event and Bind SIC Level 2 Description Data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpSICLevel1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSICLevel1 = (drpSICLevel1.SelectedIndex > 0) ? drpSICLevel1.SelectedValue : "";      
        //Get SIC Level 1 Wise Descriprtion Bind Data      
        DataSet dsSICLevel2 = LU_SIC.SelectByFld_Desc2(strSICLevel1);
        if (dsSICLevel2 != null && dsSICLevel2.Tables.Count > 0)
        {
            drpSICLevel2.Items.Clear();
            drpSICLevel2.DataTextField = "Fld_Desc_2";
            drpSICLevel2.DataValueField = "Fld_Desc_2";
            drpSICLevel2.DataSource = dsSICLevel2;
            drpSICLevel2.DataBind();
            drpSICLevel2.Items.Insert(0, new ListItem("--Select--", "0"));
            //Clear SIC 3 Level DropDownList Data
            drpSICLevel3.Items.Clear();
            drpSICLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;   
        }

        if(drpSICLevel1.SelectedValue=="0") 
        {
            drpSICLevel2.Items.Clear();
            drpSICLevel3.Items.Clear();
            drpSICLevel2.Items.Insert(0, new ListItem("--Select--", "0"));
            drpSICLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;
        }
    }
    /// <summary>
    /// SIC Level 2 Description DropDownList Selected Index changed event and Bind SIC Level 3 Description Data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpSICLevel2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string strSICLevel2 = (drpSICLevel2.SelectedIndex > 0) ? drpSICLevel2.SelectedValue : "";
        //Get SIC Level 2 Wise Descriprtion Bind Data      
        DataSet dsSICLevel2 = LU_SIC.SelectByFld_Desc3(strSICLevel2);
        if (dsSICLevel2 != null && dsSICLevel2.Tables.Count > 0)
        {
            drpSICLevel3.Items.Clear();
            drpSICLevel3.DataTextField = "Fld_Desc_3";
            drpSICLevel3.DataValueField = "Fld_Desc_3";
            drpSICLevel3.DataSource = dsSICLevel2;
            drpSICLevel3.DataBind();
            drpSICLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;   
        }
        if (drpSICLevel2.SelectedValue == "0")
        {
            drpSICLevel3.Items.Clear();           
            drpSICLevel3.Items.Insert(0, new ListItem("--Select--", "0"));
            btnSelect.Enabled = false;
        }
    }
     /// <summary>
    /// SIC Level 2 Description DropDownList Selected Index changed event and Bind SIC Level 3 Description Data 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpSICLevel3_SelectedIndexChanged(object sender, EventArgs e)
    {
      
        if (drpSICLevel3.SelectedValue == "0")        
            btnSelect.Enabled = false;      
        else
            btnSelect.Enabled = true;

    }
    #endregion
}
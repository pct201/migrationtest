using System;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using ERIMS.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data;

public partial class SONIC_SLT_SLT_Meeting_Location : clsBasePage
{
    #region properties
    /// <summary>
    /// Denotes the operation whether edit or view
    /// </summary>
    public string StrOperation
    {
        get { return Convert.ToString(ViewState["strOperation"]); }
        set { ViewState["strOperation"] = value; }
    }
    /// <summary>
    /// Denotes the UniqueVal whether edit or view
    /// </summary>
    public string UniqueVal
    {
        get { return Convert.ToString(ViewState["UniqueVal"]); }
        set { ViewState["UniqueVal"] = value; }
    }
    #endregion
    #region "Page Events"
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (App_Access == AccessType.Administrative_Access)
                StrOperation = "edit";
            else if (App_Access == AccessType.View_Only)
                StrOperation = "view";
            Binddropdown();
        }
    }
    #endregion
    #region "Methods"
    private void Binddropdown()
    {
        Nullable<decimal> CurrentEmployee = new Security(Convert.ToDecimal(clsSession.UserID)).Employee_Id;
        if (CurrentEmployee.ToString() != string.Empty && CurrentEmployee.ToString() != "0")
            CurrentEmployee = Convert.ToDecimal(CurrentEmployee);
        else
            CurrentEmployee = 0;
        string Regional = string.Empty;
        DataSet dsRegion = Regional_Access.SelectBySecurityID(Convert.ToInt32(clsSession.UserID));
        if (dsRegion.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow drRegion in dsRegion.Tables[0].Rows)
            {
                Regional += drRegion["Region"].ToString() + ",";
            }
            //Regional = dsRegion.Tables[0].Rows[0]["Region"].ToString();
        }
        else
            Regional = string.Empty;
        DataTable dtData = ERIMS.DAL.LU_Location.SelectAll(CurrentEmployee, Regional.ToString().TrimEnd(Convert.ToChar(","))).Tables[0];
        dtData.DefaultView.RowFilter = " Active = 'Y' AND Show_On_Dashboard= 'Y' ";
        dtData.DefaultView.Sort = "Sonic_Location_Code";
        dtData = dtData.DefaultView.ToTable();
        ddlRMLocationNumber.Items.Clear();
        ddlRMLocationNumber.DataTextField = "dba1";
        ddlRMLocationNumber.DataValueField = "PK_LU_Location_ID";
        ddlRMLocationNumber.DataSource = dtData;
        ddlRMLocationNumber.Style.Add("font-size", "x-small");
        ddlRMLocationNumber.DataBind();
        //check require to add "-- select --" at first item of dropdown.

        ddlRMLocationNumber.Items.Insert(0, new ListItem("--Select--","0"));
    }

    #endregion
    #region "Control Events"
    protected void btnnext_Click(object sender, EventArgs e)
    {
        decimal PK_ID;
        if (StrOperation.ToLower() != "view")
        {
            UniqueVal = System.Guid.NewGuid().ToString();
            SLT_Meeting objSLT_Meeting = new SLT_Meeting();
            objSLT_Meeting.FK_LU_Location_ID = Convert.ToDecimal(ddlRMLocationNumber.SelectedValue);
            objSLT_Meeting.UniqueVal = UniqueVal;
            PK_ID = objSLT_Meeting.Insert();
            if (PK_ID > 0)
            {
                Response.Redirect("SLT_Meeting.aspx?id=" + Encryption.Encrypt(PK_ID.ToString()) + "&LID=" + Encryption.Encrypt(objSLT_Meeting.FK_LU_Location_ID.ToString()) + "&op=" + StrOperation);
            }

        }
        else
        {
            DataTable dtSLT_Meeting = SLT_Meeting.SelectByLocationID(Convert.ToDecimal(ddlRMLocationNumber.SelectedValue)).Tables[0];
            if (dtSLT_Meeting.Rows.Count > 0)
                PK_ID = Convert.ToDecimal(dtSLT_Meeting.Rows[0]["PK_SLT_Meeting"]);
            else
                PK_ID = 0;
            if (PK_ID > 0)
            {
                Response.Redirect("SLT_Meeting.aspx?id=" + Encryption.Encrypt(PK_ID.ToString()) + "&LID=" + Encryption.Encrypt(ddlRMLocationNumber.SelectedValue.ToString()) + "&op=" + StrOperation);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:alert('No meeting record exist for the location to view !');", true);
            }
        }
    }
    #endregion

    #region "Grid Events"

    #endregion
}
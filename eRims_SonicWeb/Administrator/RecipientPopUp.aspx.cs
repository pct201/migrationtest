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
using System.Collections.Generic;
using ERIMS.DAL;

public partial class Administrator_RecipientPopUp : System.Web.UI.Page
{
    #region "Private Variables"
    string strSortExp = String.Empty;
    string strSelectedList = string.Empty;
    #endregion

    #region "Page Event"
    /// <summary>
    /// Page Load Event.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["list"] != null)
                {
                    strSelectedList = Convert.ToString(Request.QueryString["list"]);
                }
                BindUserData();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    #endregion

    #region "Event"

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:clearRecipients();", true);
        for (int j = 0; j <= dgUsers.Rows.Count - 1; j++)
        {
            string strPK = ((LinkButton)dgUsers.Rows[j].FindControl("lblPK_Recipient_ID")).CommandArgument.ToString();
            CheckBox chkSelected = (CheckBox)dgUsers.Rows[j].FindControl("chkSelected");
            if (chkSelected.Checked)
            {
                LinkButton lbtnTemp = new LinkButton();
                lbtnTemp = ((LinkButton)(dgUsers.Rows[j].FindControl("lbtnFirstName")));
                string Name;
                Name = lbtnTemp.CommandArgument.ToString();
                string strPK_Recipient_ID = ((LinkButton)dgUsers.Rows[j].FindControl("lblPK_Recipient_ID")).CommandArgument.ToString();
                string strReturnID = Name + ',' + strPK_Recipient_ID;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), j.ToString(), "javascript:selectRecord('" + strReturnID + "');", true);
            }
        }
    }

    // -- Bind the Column of the DataGrid
    protected void dgUsers_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //LinkButton lbtnTemp = new LinkButton();
            //lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnFirstName")));
            //string Name;
            //Name = lbtnTemp.CommandArgument.ToString();
            //string strPK_Recipient_ID = ((LinkButton)e.Row.FindControl("lblPK_Recipient_ID")).CommandArgument.ToString();
            //string assignTO = Name +',' + strPK_Recipient_ID;

            //lbtnTemp.Attributes.Add("onclick", "selectRecord('" + assignTO + "');");

            //lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnFirstName")));
            //Name = lbtnTemp.CommandArgument.ToString();
            //lbtnTemp.Attributes.Add("onclick", "selectRecord('" + assignTO + "');");

            //lbtnTemp = ((LinkButton)(e.Row.FindControl("lblMidleName")));
            //Name = lbtnTemp.CommandArgument.ToString();
            //lbtnTemp.Attributes.Add("onclick", "selectRecord('" + assignTO + "');");

            //lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnLastName")));
            //Name = lbtnTemp.CommandArgument.ToString();
            //lbtnTemp.Attributes.Add("onclick", "selectRecord('" + assignTO + "');");

            //lbtnTemp = ((LinkButton)(e.Row.FindControl("lbtnEmail")));
            //Name = lbtnTemp.CommandArgument.ToString();
            //lbtnTemp.Attributes.Add("onclick", "selectRecord('" + assignTO + "');");
        }
    }

    /// <summary>
    /// Event to Handle Sorting
    /// </summary>
    protected void dgUsers_Sorting(object sender, GridViewSortEventArgs e)
    {
        string strDir = "ASC";
        if (ViewState["sortDirection"] == null)
            ViewState["sortDirection"] = SortDirection.Ascending;
        // Changes the sort direction 
        else
        {
            if (((SortDirection)ViewState["sortDirection"]) == SortDirection.Ascending)
                ViewState["sortDirection"] = SortDirection.Descending;
            else
                ViewState["sortDirection"] = SortDirection.Ascending;
        }
        ViewState["SortExp"] = strSortExp = e.SortExpression;
        DataView dvView = BindUserData().Tables[0].DefaultView;
        if (ViewState["sortDirection"].ToString() == SortDirection.Ascending.ToString()) strDir = "ASC";
        else strDir = "DESC";
        dvView.Sort = e.SortExpression + " " + strDir;
        dgUsers.DataSource = dvView;
        dgUsers.DataBind();


    }

    /// <summary>
    /// Event Call at Row Created time.
    /// </summary>
    protected void dgUsers_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
            if (String.Empty != strSortExp)
            {
                AddSortImage(e.Row);
            }
        }
    }
    #endregion

    #region "Method"
    /// <summary>
    /// Get User Data 
    /// </summary>
    public DataSet BindUserData()
    {
        DataSet m_dsUserList = null;
        try
        {

            m_dsUserList = Tatva_Recipient.SelectAll();
            dgUsers.DataSource = m_dsUserList;
            dgUsers.DataBind();
            SelectCheckbox();
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return m_dsUserList;
    }

    /// <summary>
    /// Sets the checkboxes to checked for the selected recipients
    /// </summary>
    private void SelectCheckbox()
    {
        if (!string.IsNullOrEmpty(strSelectedList))
        {
            for (int j = 0; j <= dgUsers.Rows.Count - 1; j++)
            {
                string strPK = ((LinkButton)dgUsers.Rows[j].FindControl("lblPK_Recipient_ID")).CommandArgument.ToString();
                CheckBox chkSelected = (CheckBox)dgUsers.Rows[j].FindControl("chkSelected");
                string[] arrList = strSelectedList.Split(',');
                for (int i = 0; i <= arrList.Length - 1; i++)
                {
                    if (strPK == arrList[i].ToString())
                    {
                        chkSelected.Checked = true;
                        break;
                    }
                    else
                        chkSelected.Checked = false;
                }
            }
        }
    }

    private int GetSortColumnIndex(string strSortExp)
    {
        int nRet = 0;
        // Iterate through the Columns collection to determine the index
        // of the column being sorted.
        foreach (DataControlField field in dgUsers.Columns)
        {
            if (field.SortExpression.ToString() == ViewState["SortExp"].ToString())
            {
                nRet = dgUsers.Columns.IndexOf(field);
            }
        }
        return nRet;
    }
    private void AddSortImage(GridViewRow headerRow)
    {

        Int32 iCol = GetSortColumnIndex(strSortExp);
        if (-1 == iCol)
        {
            return;
        }
        // Create the sorting image based on the sort direction.
        Image sortImage = new Image();

        if (SortDirection.Ascending.ToString() == ViewState["sortDirection"].ToString())
        {
            sortImage.ImageUrl = "~/Images/up-arrow.gif";
            sortImage.AlternateText = "Descending Order";
        }
        else
        {
            sortImage.ImageUrl = "~/Images/down-arrow.gif";
            sortImage.AlternateText = "Ascending Order";
        }

        // Add the image to the appropriate header cell.
        headerRow.Cells[iCol].Controls.Add(sortImage);
    }
    #endregion
}
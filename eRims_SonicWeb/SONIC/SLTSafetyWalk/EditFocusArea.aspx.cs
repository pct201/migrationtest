using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
public partial class SONIC_SLTSafetyWalk_EditFocusArea : clsBasePage
{

    #region Properties
    /// <summary>
    /// Year for SLT Safety
    /// </summary>
    private int Year
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Year"]))
            {
                return Convert.ToInt32(Request.QueryString["Year"]);
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Month for SLT Safety
    /// </summary>
    private string Month
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Month"]))
            {
                return Request.QueryString["Month"];
            }
            else
            {
                return string.Empty;
            }
        }
    }

    /// <summary>
    /// IsAnnual for SLT Safety
    /// </summary>
    private bool IsAnnual
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["IsAnnual"]))
            {
                return Convert.ToBoolean(Request.QueryString["IsAnnual"]);
            }
            else
            {
                return false;
            }
        }
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Year, Month, IsAnnual, "Sort_Order", "ASC", 1, 10);
            if (dsMonthlyQuestions != null)
            {
                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];
                if (dtMonthlyQuestions.Rows.Count > 0)
                {
                    txtFocusArea.Text = dtMonthlyQuestions.Rows[0]["Focus_Area"].ToString();
                }
            }
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (txtFocusArea.Text != "")
            LU_SLT_Safety_Walk_Focus_Area.EditFocusArea(Year, Month, Convert.ToString(txtFocusArea.Text), IsAnnual);

        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Page.ClientScript.RegisterStartupScript(Page.GetType(), DateTime.Now.ToString(), "javascript:ClosePopup();", true);
    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ERIMS.DAL;

public partial class SONIC_SLTBTSecurityWalk_YearlyQuestions : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindYear();
        }
    }

    private void BindYear()
    {
        ddlYear.Items.Clear();
        int intMinYear, intMaxYear;
        intMinYear = 2014; //DateTime.Now.Year;
        intMaxYear = DateTime.Now.Year + 2;
        for (int i = intMinYear; i <= intMaxYear; i++)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
        ddlYear.SelectedValue = DateTime.Now.Year.ToString();
    }

   

    #region Search Button Click Event
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Int32 Tmp_Year = Convert.ToInt32(ddlYear.SelectedValue);

        DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Tmp_Year, "",true, "Sort_Order", "ASC", 1, 10);
        DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];
        if (dtMonthlyQuestions.Rows.Count > 0)
            Response.Redirect("SLT_BTSecurity_Walk_Management_Annual_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Tmp_Year)), true);
        else
            Response.Redirect("SLT_BTSecurity_Walk_Management_Annual.aspx?id=" + Encryption.Encrypt("0") + "&Year=" + Encryption.Encrypt(Convert.ToString(Tmp_Year)), true);
    }
    #endregion
}
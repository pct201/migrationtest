using ERIMS.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SONIC_Exposures_Learning_Program_Items_Report : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BindDropDownList();
    }

    private void BindGrid()
    {
        int year = (ddlYear.SelectedIndex>0 ? Convert.ToInt32(ddlYear.SelectedValue) : 0);
        int quarter = (ddlQuarter.SelectedIndex > 0 ? Convert.ToInt32(ddlQuarter.SelectedValue) : 0);

        DataTable dtDetail = Sonic_U_Training.Learning_Program(year,quarter).Tables[0];

        gvLearning_Program.DataSource = dtDetail;
        gvLearning_Program.DataBind();
    }


    /// <summary>
    /// Bind Drop Downs
    /// </summary>
    private void BindDropDownList()
    {
        for (int i = DateTime.Now.Year; i >= 2013; i--)
        {
            ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        BindGrid();
    }
}
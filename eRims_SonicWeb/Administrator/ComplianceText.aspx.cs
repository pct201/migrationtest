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

public partial class Administration_ComplianceText : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    # region Methods
    private void BindGrid()
    {
        DataTable dt = COI_Compliance_Text.SelectAll().Tables[0];
        gvCOICompliance.DataSource = dt;
        gvCOICompliance.DataBind();
    }
    private void BindControlforEdit(Int32 PK)
    {
        DataTable dt = COI_Compliance_Text.SelectByPK(PK).Tables[0];
        if (dt.Rows.Count > 0)
        {
            txtComplianceText.Text = dt.Rows[0]["Compliance_Text"].ToString();
            hdnPK.Value = PK.ToString();
            if (dt.Rows[0]["IsTurnedOn"].ToString() == "Y")
            {
                rdoOn.Checked = true;
                rdoOff.Checked = false;
            }
            else if (dt.Rows[0]["IsTurnedOn"].ToString() == "N")
            {
                rdoOff.Checked = true;
                rdoOn.Checked = false;
            }
        }
    }
    # endregion

    #region "Control Events"

    protected void gvCOICompliance_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "EditCOM")
        {
            dvEdit.Style["display"] = "block";
            txtComplianceText.Focus();
            BindControlforEdit(Convert.ToInt32(e.CommandArgument));
        }
    }
    protected void gvCOICompliance_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        // check for the row type if it is header row or data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblYES = (Label)e.Row.FindControl("lblTurnedOn");
            if (DataBinder.Eval(e.Row.DataItem, "IsTurnedOn").ToString() == "Y")
                lblYES.Text = "Yes";
            else
                lblYES.Text = "No";
        }
    }
    protected void gvCOICompliance_RowCreated(object sender, GridViewRowEventArgs e)
    {
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        COI_Compliance_Text obj = new COI_Compliance_Text(Convert.ToDecimal(hdnPK.Value));
        obj.Compliance_Text = txtComplianceText.Text;
        if (rdoOn.Checked)
            obj.IsTurnedOn = "Y";
        else if (rdoOff.Checked)
            obj.IsTurnedOn = "N";

        obj.PK_Compliance = Convert.ToDecimal(hdnPK.Value);
        obj.Update();
        BindGrid();
        dvEdit.Style["display"] = "none";
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        dvEdit.Style["display"] = "none";
    }

    # endregion
}

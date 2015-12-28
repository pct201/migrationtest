using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_BT_Security_Walk_Management_Monthly : clsBasePage
{
    #region Properties

    /// <summary>
    /// PK_LU_SLT_BT_Security_Walk_Focus_Area for SLT Safety
    /// </summary>
    private decimal PK_LU_SLT_BT_Security_Walk_Focus_Area
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                return Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"]));
            }
            else
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// Year for SLT Safety
    /// </summary>
    private int Year
    {
        get
        {
            if (!string.IsNullOrEmpty(Request.QueryString["Year"]))
            {
                return Convert.ToInt32(Encryption.Decrypt(Request.QueryString["Year"]));
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
                return Encryption.Decrypt(Request.QueryString["Month"]);
            }
            else
            {
                return string.Empty;
            }
        }
    }

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblYear.Text = Year.ToString();
            lblMonth.Text = Month.ToString();
            if (PK_LU_SLT_BT_Security_Walk_Focus_Area > 0)
            {
                BindControls();
                txtFocusArea.Enabled = false;   
            }
            else
            {
                DataSet dsMonthlyQuestions = clsLU_SLT_BT_Security_Walk_Focus_Area.Search(Year, Month, false, "Sort_Order", "ASC", 1, 10);
                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];
                if (dtMonthlyQuestions.Rows.Count > 0)
                {
                    txtFocusArea.Text = dtMonthlyQuestions.Rows[0]["Focus_Area"].ToString();
                    txtFocusArea.Enabled = false;   
                }
                
            }
        }
    }

    

    private void BindControls()
    {
        clsLU_SLT_BT_Security_Walk_Focus_Area objSBSWFA = new clsLU_SLT_BT_Security_Walk_Focus_Area(PK_LU_SLT_BT_Security_Walk_Focus_Area);
        if (!string.IsNullOrEmpty(objSBSWFA.Focus_Area))
            txtFocusArea.Text = objSBSWFA.Focus_Area.ToString();
        if (!string.IsNullOrEmpty(objSBSWFA.Question))
            txtQuestion.Text = objSBSWFA.Question.ToString();
        if (!string.IsNullOrEmpty(objSBSWFA.Guidance))
            txtGuidance.Text = objSBSWFA.Guidance.ToString();
        if (!string.IsNullOrEmpty(objSBSWFA.Reference))
            txtReference.Text = objSBSWFA.Reference.ToString();
        if (!string.IsNullOrEmpty(objSBSWFA.Active))
            rblActive.SelectedValue = objSBSWFA.Active.ToString();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        clsLU_SLT_BT_Security_Walk_Focus_Area objSBSWFA = new clsLU_SLT_BT_Security_Walk_Focus_Area();
        int ReturnVal = 0;
        decimal PK_LU_SLT_BT_Security_Walk_Focus_Area = 0;
        if (Request.QueryString["id"] != null)
        {
            PK_LU_SLT_BT_Security_Walk_Focus_Area = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"]));
        }

        objSBSWFA.Year = Year;
        objSBSWFA.Month = Month;
        objSBSWFA.Focus_Area = txtFocusArea.Text.ToString();
        objSBSWFA.Question = txtQuestion.Text.ToString();
        objSBSWFA.Guidance = txtGuidance.Text.ToString();
        objSBSWFA.Reference = txtReference.Text.ToString();
        objSBSWFA.Active = rblActive.SelectedValue.ToString();
        if (PK_LU_SLT_BT_Security_Walk_Focus_Area > 0)
        {
            objSBSWFA.PK_LU_SLT_BT_Security_Walk_Focus_Area = PK_LU_SLT_BT_Security_Walk_Focus_Area;
            ReturnVal = objSBSWFA.Update();
            if (ReturnVal == -1)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No more than five (5) Monthly questions for a Year and Month combination can be active at one time.');", true);
            }
            else
                Response.Redirect("SLT_BTSecurity_Walk_Management_Monthly_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);
        }
        else
        {
            ReturnVal = objSBSWFA.Insert();
            if (ReturnVal == -1)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No more than five (5) Monthly questions for a Year and Month combination can be active at one time.');", true);
            }
            else
                Response.Redirect("SLT_BTSecurity_Walk_Management_Monthly_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SLT_BTSecurity_Walk_Management_Monthly_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);
    }
}
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;

public partial class SONIC_SLT_Safety_Walk_SLT_Safety_Walk_Management_Monthly : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblYear.Text = Year.ToString();
            lblMonth.Text = Month.ToString();
            if (PK_LU_SLT_Safety_Walk_Focus_Area > 0)
            {
                BindControls();
                //txtFocusArea.Enabled = false;   
            }
            else
            {
                DataSet dsMonthlyQuestions = LU_SLT_Safety_Walk_Focus_Area.Search(Year, Month,false, "Sort_Order", "ASC", 1, 10);
                DataTable dtMonthlyQuestions = dsMonthlyQuestions.Tables[0];
                if (dtMonthlyQuestions.Rows.Count > 0)
                {
                    txtFocusArea.Text = dtMonthlyQuestions.Rows[0]["Focus_Area"].ToString();
                    //txtFocusArea.Enabled = false;   
                }
                
            }
        }
    }

    #region Properties

    /// <summary>
    /// PK_LU_SLT_Safety_Walk_Focus_Area for SLT Safety
    /// </summary>
    private decimal PK_LU_SLT_Safety_Walk_Focus_Area
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

    private void BindControls()
    {
        LU_SLT_Safety_Walk_Focus_Area objSSWFA = new LU_SLT_Safety_Walk_Focus_Area(PK_LU_SLT_Safety_Walk_Focus_Area);
        if (!string.IsNullOrEmpty(objSSWFA.Focus_Area))
            txtFocusArea.Text = objSSWFA.Focus_Area.ToString();
        if (!string.IsNullOrEmpty(objSSWFA.Question))
            txtQuestion.Text = objSSWFA.Question.ToString();
        if (!string.IsNullOrEmpty(objSSWFA.Guidance))
            txtGuidance.Text = objSSWFA.Guidance.ToString();
        if (!string.IsNullOrEmpty(objSSWFA.Reference))
            txtReference.Text = objSSWFA.Reference.ToString();
        if (!string.IsNullOrEmpty(objSSWFA.Active))
            rblActive.SelectedValue = objSSWFA.Active.ToString();

    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        LU_SLT_Safety_Walk_Focus_Area objSSWFA = new LU_SLT_Safety_Walk_Focus_Area();
        int ReturnVal = 0;
        decimal PK_LU_SLT_Safety_Walk_Focus_Area = 0;
        if (Request.QueryString["id"] != null)
        {
            PK_LU_SLT_Safety_Walk_Focus_Area = Convert.ToDecimal(Encryption.Decrypt(Request.QueryString["id"]));
        }

        objSSWFA.Year = Year;
        objSSWFA.Month = Month;
        objSSWFA.Focus_Area = txtFocusArea.Text.ToString();
        objSSWFA.Question = txtQuestion.Text.ToString();
        objSSWFA.Guidance = txtGuidance.Text.ToString();
        objSSWFA.Reference = txtReference.Text.ToString();
        objSSWFA.Active = rblActive.SelectedValue.ToString();
        if (PK_LU_SLT_Safety_Walk_Focus_Area > 0)
        {
            objSSWFA.PK_LU_SLT_Safety_Walk_Focus_Area = PK_LU_SLT_Safety_Walk_Focus_Area;
            ReturnVal = objSSWFA.Update();
            if (ReturnVal == -1)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No more than five (5) Monthly questions for a Year and Month combination can be active at one time.');", true);
            }
            else
                Response.Redirect("SLT_Safety_Walk_Management_Monthly_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);
        }
        else
        {
            ReturnVal = objSSWFA.Insert();
            if (ReturnVal == -1)
            {
                Page.ClientScript.RegisterStartupScript(typeof(string), DateTime.Now.ToString(), "javascript:alert('No more than five (5) Monthly questions for a Year and Month combination can be active at one time.');", true);
            }
            else
                Response.Redirect("SLT_Safety_Walk_Management_Monthly_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);

        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("SLT_Safety_Walk_Management_Monthly_Grid.aspx?Year=" + Encryption.Encrypt(Convert.ToString(Year)) + "&Month=" + Encryption.Encrypt(Convert.ToString(Month)), true);
    }
}
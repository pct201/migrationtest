using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERIMS.DAL;
using System.Data;
public partial class Administrator_BuildingInsuranceCOPE : clsBasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindGrid();
        }
    }

    /// <summary>
    /// Bind Insurance cope Descriptors list
    /// </summary>
    private void BindGrid()
    {
        DataSet objDs = Building_Insurance_COPE_Descriptors.BuildingInsuranceCOPEDescriptorsSelectALL();
        gvBuildingInsuranceCope.DataSource = objDs;
        gvBuildingInsuranceCope.DataBind();
    }

    private void SetBuildingInsuranceCope()
    {
        DataSet objDs = Building_Insurance_COPE_Descriptors.BuildingInsuranceCOPEDescriptorsSelectALL();
        if (objDs != null && objDs.Tables.Count > 0 && objDs.Tables[0].Rows.Count > 0)
        {
            for (int i = 0 ; i < objDs.Tables[0].Rows.Count; i++)
            {
                HiddenField hdnItemNumber = pnlInsuranceCope.FindControl("hdnItemNumber" + (i + 1)) as HiddenField;
                hdnItemNumber.Value = objDs.Tables[0].Rows[i]["Item_Number"].ToString();

                TextBox txtField = pnlInsuranceCope.FindControl("txtField" + (i + 1)) as TextBox;
                txtField.Text = objDs.Tables[0].Rows[i]["Item_Descriptor"].ToString();

                RadioButtonList rblItem = pnlInsuranceCope.FindControl("rblItem" + (i + 1)) as RadioButtonList;
                if (!string.IsNullOrEmpty(Convert.ToString(objDs.Tables[0].Rows[i]["Active"])))
                    rblItem.SelectedValue = objDs.Tables[0].Rows[i]["Active"].ToString();
                else
                    rblItem.SelectedValue = "N";

                RadioButtonList rblMandatory = pnlInsuranceCope.FindControl("rblMandatory" + (i + 1)) as RadioButtonList;

                if (!string.IsNullOrEmpty(Convert.ToString(objDs.Tables[0].Rows[i]["Mandatory"])))
                    rblMandatory.SelectedValue = objDs.Tables[0].Rows[i]["Mandatory"].ToString();
                else
                    rblMandatory.SelectedValue = "N";
            }
        }
        pnlInsuranceCopeList.Visible = false;
        pnlInsuranceCope.Visible = true;
    }

    protected void lnkBuildingInsuranceCopeManage_Click(object sender, EventArgs e)
    {
        SetBuildingInsuranceCope();      
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string strXml = string.Empty;
        strXml = "<InsuranceRecords>";
        for (int i = 0; i < 25; i++)
        {
            HiddenField hdnItemNumber = pnlInsuranceCope.FindControl("hdnItemNumber" + (i + 1)) as HiddenField;
            TextBox txtField = pnlInsuranceCope.FindControl("txtField" + (i + 1)) as TextBox;
            RadioButtonList rblItem = pnlInsuranceCope.FindControl("rblItem" + (i + 1)) as RadioButtonList;
            RadioButtonList rblMandatory = pnlInsuranceCope.FindControl("rblMandatory" + (i + 1)) as RadioButtonList;

            strXml += "<Record>";
            strXml += "<ItemNumber>" + hdnItemNumber.Value+ "</ItemNumber>";
            strXml += "<ItemDescriptor>" + txtField.Text + "</ItemDescriptor>";
            strXml += "<Active>" + rblItem.SelectedValue + "</Active>";
            strXml += "<Mandatory>" + rblMandatory.SelectedValue + "</Mandatory>";
            strXml += "</Record>";
        }
        strXml += "</InsuranceRecords>";
        Building_Insurance_COPE_Descriptors.BuildingInsuranceCOPEDescriptorsUpdate(strXml);
        SetBuildingInsuranceCope();
        BindGrid();
        pnlInsuranceCopeList.Visible = true;
        pnlInsuranceCope.Visible = false;

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        BindGrid();
        pnlInsuranceCopeList.Visible = true;
        pnlInsuranceCope.Visible = false;
    }
}
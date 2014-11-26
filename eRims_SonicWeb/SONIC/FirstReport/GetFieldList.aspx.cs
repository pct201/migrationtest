using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class Administrator_GetFieldList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnGetFields_Click(object sender, EventArgs e)
    {
        DataTable dt = GetDataToImport(@"D:\Projects\Field_List.xls");
        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                DataTable dtFinal = dt.Clone();
                dtFinal.Clear();
                dtFinal.Columns.Add("Code", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    string strCodeLIne = Convert.ToString(dr["Code_Line"]).Trim();

                    if (strCodeLIne.IndexOf("Replace") > 0)
                    {
                        strCodeLIne = strCodeLIne.Replace(".Replace(\"[", "");
                        strCodeLIne = strCodeLIne.Replace(".ToString()", "");
                        strCodeLIne = strCodeLIne.Replace(".ToString(\"HH:mm\")", "");
                        strCodeLIne = strCodeLIne.Replace(".Replace(\".00\", \"\")", "");

                        string strFieldName = "";
                        if (strCodeLIne.IndexOf('[') > 0)
                        {
                            int len = strCodeLIne.LastIndexOf(']') - strCodeLIne.LastIndexOf('[') - 2;
                            strFieldName = strCodeLIne.Substring(strCodeLIne.LastIndexOf('[') + 2, len - 1);
                        }
                        else if(strCodeLIne.LastIndexOf(".") > 0)
                            strFieldName = strCodeLIne.Substring(strCodeLIne.LastIndexOf(".") + 1);
                        strFieldName = strFieldName.Replace(" == true) ? \"Yes\" : \"No\"", "");
                        strFieldName = strFieldName.TrimEnd(';');
                        strFieldName = strFieldName.TrimEnd(')');
                        strFieldName = strFieldName.TrimEnd(')');
                        
                        if(!string.IsNullOrEmpty(strFieldName))
                            dtFinal.Rows.Add(dtFinal.NewRow()[0] = "'" + strFieldName + "',", dtFinal.NewRow()[1] = strCodeLIne);
                    }
                }

                GridView gv = new GridView();
                gv.DataSource = dtFinal;
                gv.DataBind();

                GridViewExportUtil.ExportGrid("FieldList.xls", gv);
            }
        }
    }

    public static DataTable GetDataToImport(string strFileName)
    {
        //Check the following registry settings for the *machine*: 
        //Hkey_Local_Machine/Software/Microsoft/Jet/4.0/Engines/Excel/TypeGuessRows 
        //Hkey_Local_Machine/Software/Microsoft/Jet/4.0/Engines/Excel/ImportMixedType­s 
        //TypeGuessRows: setting the value to 0 (zero) will force ADO to scan all column values before choosing the appropriate data type. 
        //ImportMixedTypes: should be set to value 'Text' i.e. import mixed-type columns as text: 


        //string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strFileName + @";Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""";
        string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strFileName + @";Extended Properties=""Excel 12.0;HDR=YES;IMEX=1;""";
        OleDbConnection objConn = new OleDbConnection(strConn);
        try
        {
            objConn.Open();

            DataTable dtSheets = objConn.GetSchema("Tables");

            OleDbCommand objCommand = new OleDbCommand("Select * from [" + dtSheets.Rows[0]["Table_name"] + "]", objConn);

            OleDbDataAdapter da = new OleDbDataAdapter(objCommand);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (objConn.State == ConnectionState.Open) objConn.Close();
            objConn.Dispose();

            return ds.Tables[0];

        }
        catch
        {
            if (objConn.State == ConnectionState.Open) objConn.Close();
            objConn.Dispose();
            return null;
        }
    }
}
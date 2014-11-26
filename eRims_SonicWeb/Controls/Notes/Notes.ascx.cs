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
/// <summary>
/// Date : 19 July 2008
/// 
/// By : Ravi Gupta
/// 
/// Purpose: 
/// Used to display multiline textbox or label for large data
/// 
/// Functionality:
/// Checks for the control type and sets the css as per either label or textbox
/// Expands or collapse the control depending on the plus or minus image clicked
/// </summary>
public partial class Controls_LongDescription_LongDescription : System.Web.UI.UserControl
{
    #region "Enums"
    /// <summary>
    /// Denotes control type whether label or textbox used to set the css
    /// </summary>
    public enum CtrlType
    {
        TextBox = 1,
        Label = 2
    }
    #endregion
    int intWidth = 567;

    #region "Properties"

    /// <summary>
    /// Value to be displayed in control
    /// </summary>
    public string Text
    {
        get { return txtNote.Text; }
        set { txtNote.Text = value; }
    }

    /// <summary>
    /// Denotes whether it is required field
    /// </summary>
    public bool IsRequired
    {
        set { rfvNotes.Enabled = value; }
        get { return rfvNotes.Enabled; }
    }

    /// <summary>
    /// Denotes whether it is required focus of Error
    /// </summary>
    public bool SetFocusOnError
    {
        set { rfvNotes.SetFocusOnError = value; }
        get { return rfvNotes.SetFocusOnError; }
    }

    /// <summary>
    /// Denotes the required field validation message
    /// </summary>
    public string RequiredFieldMessage
    {
        get { return rfvNotes.ErrorMessage; }
        set { rfvNotes.ErrorMessage = value; }
    }

    /// <summary>
    /// Denotes validation group
    /// </summary>
    public string ValidationGroup
    {
        get { return rfvNotes.ValidationGroup; }
        set { rfvNotes.ValidationGroup = value; }
    }

    public int Width
    {
        get { return intWidth; }
        set { intWidth = value; }
    }

    /// <summary>
    /// Sets the css as per the control type enum (label or textbox)
    /// </summary>
    public CtrlType ControlType
    {
        get
        {
            if (ViewState["controltype"] == null)
            { ViewState["controltype"] = CtrlType.TextBox; }

            return (CtrlType)ViewState["controltype"];
        }
        set
        {
            if (value == CtrlType.Label)
            {
                txtNote.ReadOnly = true;
                txtNote.CssClass = "readOnlyTextBox";
                ViewState["controltype"] = CtrlType.Label;
            }
        }
    }
    /// <summary>
    /// Denotes the Max Length of the textbox
    /// </summary>
    public int MaxLength
    {
        get { return Convert.ToInt32(txtNote.MaxLength); }
        set { txtNote.MaxLength = value; }
    }

    /// <summary>
    /// Denotes the Max Length of the textbox
    /// </summary>
    public string ClientID
    {
        get { return txtNote.ClientID; }        
    }
    #endregion

    #region "Page Events"

    protected void Page_Load(object sender, EventArgs e)
    {
        //// if page is loaded first time
        //if (!IsPostBack)
        //{
            // set javascript attributes for textbox
            txtNote.Attributes.Add("onkeypress", "return CheckMaxLength(event, this," + MaxLength + ");");
            txtNote.Attributes.Add("onchange", "return CheckMaxLength(event, this," + MaxLength + ");");

            // Add attributes for images to expand or collapse the textbox
            imgPlus.Attributes.Add("onclick", "javascript:ExpandNotes(true,'" + imgPlus.ClientID + "','" + imgMinus.ClientID + "','" + txtNote.ClientID + "');");
            imgMinus.Attributes.Add("onclick", "javascript:ExpandNotes(false,'" + imgPlus.ClientID + "','" + imgMinus.ClientID + "','" + txtNote.ClientID + "');");
            txtNote.Width = new Unit(intWidth);
            // check whether the value length is zero and page is in view mode then hide the control
            if (Text.Length == 0 && ControlType == CtrlType.Label)
            {
                tblNotes.Style["Display"] = "none";
                txtNote.ReadOnly = true;
            }
        //}
    }

    protected void Page_PreRender(object sender, EventArgs e)
    {
        if (Text.Length == 0 && ControlType == CtrlType.Label)
        {
            tblNotes.Style["Display"] = "none";
            txtNote.ReadOnly = true;
        }
        else if (Text.Length > 0 && ControlType == CtrlType.Label)
        {
            tblNotes.Style["Display"] = "inline";
            txtNote.ReadOnly = true;
        }
    }

    #endregion
}

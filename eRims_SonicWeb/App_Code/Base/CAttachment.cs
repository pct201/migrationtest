#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CAttachment
{

	#region Constructor
    public CAttachment()
	{
		this._pK_Attachment_Id = 0;
		this._attachment_Table = string.Empty;
		this._foreign_Key = 0;
		this._fK_Attachment_Type = 0;
		this._attachment_Description = string.Empty;
		this._attachment_Name = string.Empty;
		this._updated_By = string.Empty;
		this._update_Date = DateTime.Now;
        this._fld_Desc = string.Empty;
	}
	#endregion

	#region Private Variables 
	private System.Int32 _pK_Attachment_Id;
	private System.String _attachment_Table;
    private System.Int32 _foreign_Key;
    private System.Int32 _fK_Attachment_Type;
	private System.String _attachment_Description;
	private System.String _attachment_Name;
    private System.String _attachment_Name1;
	private System.String _updated_By;
	private System.DateTime _update_Date;
    private System.String _fld_Desc;
	#endregion

	#region Public Properties
    public System.Int32 PK_Attachment_Id
	{
		get { return  _pK_Attachment_Id; }
		set { _pK_Attachment_Id = value; }
	}

	public System.String Attachment_Table
	{
		get { return  _attachment_Table; }
		set { _attachment_Table = value; }
	}

    public System.Int32 Foreign_Key
	{
		get { return  _foreign_Key; }
		set { _foreign_Key = value; }
	}

    public System.Int32 FK_Attachment_Type
	{
		get { return  _fK_Attachment_Type; }
		set { _fK_Attachment_Type = value; }
	}

	public System.String Attachment_Description
	{
		get { return  _attachment_Description; }
		set { _attachment_Description = value; }
	}

	public System.String Attachment_Name
	{
		get { return  _attachment_Name; }
		set { _attachment_Name = value; }
	}
    public System.String Attachment_Name1
	{
		get { return  _attachment_Name1; }
		set { _attachment_Name1 = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

    public System.String Attachment_Type
    {
        get { return _fld_Desc; }
        set { _fld_Desc = value; }
    }

	#endregion

	#region Abstract Methods
    public abstract List<CAttachment> GetAll(Int32 pK_Attachment_Id, Int32 Foreign_Key,System.String Table_Name );
    public abstract CAttachment GetchmentByID(System.Decimal lPK_Attachment_Id);
    public abstract int InsertUpdateAttachment(RIMS_Base.CAttachment obj);
	public abstract int DeleteAttachment(System.String lPK_Attachment_Id);
	public abstract string ActivateInactivateAttachment(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<RIMS_Base.CAttachment> GetAllAttachmentGroup(System.String lPK_Attachment_Id,System.String Table_Name);
    public abstract List<RIMS_Base.CAttachment> GetAttachMentMail(System.String Attachment_Ids);	
#endregion

}

}


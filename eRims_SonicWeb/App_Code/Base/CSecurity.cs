#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
    using System.Data.SqlClient;
    using System.Data;
    
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CSecurity
{

	#region Constructor
    public CSecurity()
	{
        this._pK_Security_ID = -1;
        this._fIRST_NAME = string.Empty;
        this._lAST_NAME = string.Empty;
        this._uSER_NAME = string.Empty;
        this._pASSWORD = string.Empty;
        this._uSER_ROLE = string.Empty;
        this._uPDATED_BY = string.Empty;
        this._uPDATE_DATE = DateTime.Now;
        this._cost_Center = string.Empty;
        this._email = string.Empty;
        this._fkUserRole = 0;
	}
	#endregion

	#region Private Variables 
    private System.Decimal _fkUserRole;
	private System.Int32 _pK_Security_ID;
	private System.String _fIRST_NAME;
	private System.String _lAST_NAME;
	private System.String _uSER_NAME;
	private System.String _pASSWORD;
	private System.String _uSER_ROLE;
	private System.String _uPDATED_BY;
	private System.DateTime _uPDATE_DATE;
	private System.String _cost_Center;
	private System.String _email;
	#endregion

	#region Public Properties
    public System.Decimal FKUserRole
    {
        get { return _fkUserRole; }
        set { _fkUserRole = value; }
    }
	public System.Int32 PK_Security_ID
	{
		get { return  _pK_Security_ID; }
		set { _pK_Security_ID = value; }
	}

	public System.String FIRST_NAME
	{
		get { return  _fIRST_NAME; }
		set { _fIRST_NAME = value; }
	}

	public System.String LAST_NAME
	{
		get { return  _lAST_NAME; }
		set { _lAST_NAME = value; }
	}

	public System.String USER_NAME
	{
		get { return  _uSER_NAME; }
		set { _uSER_NAME = value; }
	}

	public System.String PASSWORD
	{
		get { return  _pASSWORD; }
		set { _pASSWORD = value; }
	}

	public System.String USER_ROLE
	{
		get { return  _uSER_ROLE; }
		set { _uSER_ROLE = value; }
	}

	public System.String UPDATED_BY
	{
		get { return  _uPDATED_BY; }
		set { _uPDATED_BY = value; }
	}

	public System.DateTime UPDATE_DATE
	{
		get { return  _uPDATE_DATE; }
		set { _uPDATE_DATE = value; }
	}

	public System.String Cost_Center
	{
		get { return  _cost_Center; }
		set { _cost_Center = value; }
	}

	public System.String Email
	{
		get { return  _email; }
		set { _email = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CSecurity> GetAll();
    public abstract List<CSecurity> GetSecurityByID(System.Int32 lPK_Security_ID);
    public abstract int InsertUpdateSecurity(RIMS_Base.CSecurity obj);
    public abstract int DeleteSecurity(System.String PK_Security_ID);
	public abstract string ActivateInactivaterity(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract DataSet GetUserRole();
    public abstract DataSet Check_Login(System.String m_strUserName, System.String m_strPwd);
    public abstract DataSet GetCostCenter();
    public abstract List<CSecurity> GetAllSecurity(System.String SearchText);
    public abstract int UpdatePassword(System.Int32 PK_Security_ID, System.String UserName, System.String NewPwd, System.String UpdateBy);
    public abstract int GetPWDType();
    public abstract List<CSecurity> GetAdminByID(System.Int32 USER_ROLE);
  
	#endregion

}

}

#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CLiabilityClaimWitness
{

	#region Constructor
    public CLiabilityClaimWitness()
	{
        this._pK_witness = -1;
		this._fK_Liability_Claim = -1;
		this._witeness_Name = string.Empty;
		this._witness_Address1 = string.Empty;
		this._witness_Address2 = string.Empty;
		this._witness_City = string.Empty;
		//this._fK_Witness_State = -1;
		this._witness_Zipcode = string.Empty;
		this._witness_Telephone = string.Empty;
		this._witness_Statement = string.Empty;
		this._updated_By = string.Empty;
		this._updated_Date = DateTime.Now;
        this._fld_State = string.Empty;
	}
	#endregion

	#region Private Variables 
    private System.Int32 _pK_witness;
	private System.Decimal _fK_Liability_Claim;
	private System.String _witeness_Name;
	private System.String _witness_Address1;
	private System.String _witness_Address2;
	private System.String _witness_City;
	private System.Decimal ? _fK_Witness_State;
	private System.String _witness_Zipcode;
	private System.String _witness_Telephone;
	private System.String _witness_Statement;
	private System.String _updated_By;
	private System.DateTime _updated_Date;
    private System.String _fld_State;
	#endregion

	#region Public Properties

    public System.Int32 PK_Witness
    {
        get { return _pK_witness; }
        set { _pK_witness = value; }
    }

    public System.String FLD_State
    {
        get { return _fld_State; }
        set { _fld_State = value; }
    }


	public System.Decimal FK_Liability_Claim
	{
		get { return  _fK_Liability_Claim; }
		set { _fK_Liability_Claim = value; }
	}

	public System.String Witeness_Name
	{
		get { return  _witeness_Name; }
		set { _witeness_Name = value; }
	}

	public System.String Witness_Address1
	{
		get { return  _witness_Address1; }
		set { _witness_Address1 = value; }
	}

	public System.String Witness_Address2
	{
		get { return  _witness_Address2; }
		set { _witness_Address2 = value; }
	}

	public System.String Witness_City
	{
		get { return  _witness_City; }
		set { _witness_City = value; }
	}

	public System.Decimal ? FK_Witness_State
	{
		get { return  _fK_Witness_State; }
		set { _fK_Witness_State = value; }
	}

	public System.String Witness_Zipcode
	{
		get { return  _witness_Zipcode; }
		set { _witness_Zipcode = value; }
	}

	public System.String Witness_Telephone
	{
		get { return  _witness_Telephone; }
		set { _witness_Telephone = value; }
	}

	public System.String Witness_Statement
	{
		get { return  _witness_Statement; }
		set { _witness_Statement = value; }
	}

	public System.String Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime Updated_Date
	{
		get { return  _updated_Date; }
		set { _updated_Date = value; }
	}

	#endregion

	#region Abstract Methods
    public abstract List<CLiabilityClaimWitness> GetAll();
    public abstract List<CLiabilityClaimWitness> GetAL_Claim_WitnessByID(System.Decimal lFK_Liability_Claim);
    public abstract int InsertUpdateility_Claim_Witness(RIMS_Base.CLiabilityClaimWitness obj);
    public abstract int Delete_Claim_Witness(System.Int32 pk_Witness);
	public abstract string ActivateInactivateility_Claim_Witness(string strIDs, int intModifiedBy, bool bIsActive);
    public abstract List<CLiabilityClaimWitness> Get_Witness_ByID(System.Int32 pk_Witness);
	#endregion

}

}

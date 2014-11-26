#region Includes
	using System;
	using System.Collections.Generic;
	using System.Text;
using System.Data;
#endregion

namespace RIMS_Base
{

[Serializable]
public abstract class CPropEnvTanks
{

	#region Constructor
    public CPropEnvTanks()
	{
        //this._pK_Environmental_Tanks = -1;
        //this._fK_Property_Environmental = -1;
        //this._identification = string.Empty;
        //this._fK_Tank_Type = -1;
        //this._fK_Tank_Contents = -1;
        //this._contents_Other = string.Empty;
        //this._capacity = -1;
        //this._fK_Tank_Status = -1;
        //this._fK_Tank_Material = -1;
        //this._material_Other = string.Empty;
        //this._fK_Tank_Construction = -1;
        //this._construction_Other = string.Empty;
        //this._release_Equipment_Present = string.Empty;
        //this._release_Eqiupment_Description = string.Empty;
        //this._installation = DateTime.Now;
        //this._removal = DateTime.Now;
        //this._closure = DateTime.Now;
        //this._last_Inspection = DateTime.Now;
        //this._next_Inspection = DateTime.Now;
        //this._inspection_Company = string.Empty;
        //this._inspection_Company_Contact_Name = string.Empty;
        //this._inspection_Company_Telephone_Number = string.Empty;
        //this._permit_Required = string.Empty;
        //this._registration_Number = string.Empty;
        //this._certificate_Number = string.Empty;
        //this._permit_Begin = DateTime.Now;
        //this._permit_End = DateTime.Now;
        //this._other_Reporting_Requirements = string.Empty;
        //this._reporting_Requirements_Description = string.Empty;
        //this._next_Report = DateTime.Now;
        //this._notes = string.Empty;
        //this._sPCCP_Identification = string.Empty;
        //this._sPCCP_Effective = DateTime.Now;
        //this._sPCCP_Expiration = DateTime.Now;
        //this._sPCCP_Last_Revision = DateTime.Now;
        //this._sPCCP_Vendor = string.Empty;
        //this._sPCCP_Vendor_Contact = string.Empty;
        //this._sPCCP_Vendor_Telephone_Number = string.Empty;
        //this._updated_By = string.Empty;
        //this._update_Date = DateTime.Now;
	}
	#endregion

	#region Private Variables 
	private System.Decimal _pK_Environmental_Tanks;
	private System.Decimal _fK_Property_Environmental;
	private System.String _identification;
	private System.Decimal? _fK_Tank_Type;
	private System.Decimal? _fK_Tank_Contents;
	private System.String _contents_Other;
	private System.Decimal? _capacity;
	private System.Decimal? _fK_Tank_Status;
	private System.Decimal? _fK_Tank_Material;
	private System.String _material_Other;
	private System.Decimal? _fK_Tank_Construction;
	private System.String _construction_Other;
	private System.String _release_Equipment_Present;
	private System.String _release_Eqiupment_Description;
	private System.DateTime? _installation;
	private System.DateTime? _removal;
	private System.DateTime? _closure;
	private System.DateTime? _last_Inspection;
	private System.DateTime? _next_Inspection;
	private System.String _inspection_Company;
	private System.String _inspection_Company_Contact_Name;
	private System.String _inspection_Company_Telephone_Number;
	private System.String _permit_Required;
	private System.String _registration_Number;
	private System.String _certificate_Number;
	private System.DateTime? _permit_Begin;
	private System.DateTime? _permit_End;
	private System.String _other_Reporting_Requirements;
	private System.String _reporting_Requirements_Description;
	private System.DateTime? _next_Report;
	private System.String _notes;
	private System.String _sPCCP_Identification;
	private System.DateTime? _sPCCP_Effective;
	private System.DateTime? _sPCCP_Expiration;
	private System.DateTime? _sPCCP_Last_Revision;
	private System.String _sPCCP_Vendor;
	private System.String _sPCCP_Vendor_Contact;
	private System.String _sPCCP_Vendor_Telephone_Number;
	private System.Decimal? _updated_By;
	private System.DateTime? _update_Date;
	#endregion

	#region Public Properties
	public System.Decimal PK_Environmental_Tanks
	{
		get { return  _pK_Environmental_Tanks; }
		set { _pK_Environmental_Tanks = value; }
	}

	public System.Decimal FK_Property_Environmental
	{
		get { return  _fK_Property_Environmental; }
		set { _fK_Property_Environmental = value; }
	}

	public System.String Identification
	{
		get { return  _identification; }
		set { _identification = value; }
	}

	public System.Decimal? FK_Tank_Type
	{
		get { return  _fK_Tank_Type; }
		set { _fK_Tank_Type = value; }
	}

	public System.Decimal? FK_Tank_Contents
	{
		get { return  _fK_Tank_Contents; }
		set { _fK_Tank_Contents = value; }
	}

	public System.String Contents_Other
	{
		get { return  _contents_Other; }
		set { _contents_Other = value; }
	}

    public System.Decimal? Capacity
	{
		get { return  _capacity; }
		set { _capacity = value; }
	}

    public System.Decimal? FK_Tank_Status
	{
		get { return  _fK_Tank_Status; }
		set { _fK_Tank_Status = value; }
	}

    public System.Decimal? FK_Tank_Material
	{
		get { return  _fK_Tank_Material; }
		set { _fK_Tank_Material = value; }
	}

	public System.String Material_Other
	{
		get { return  _material_Other; }
		set { _material_Other = value; }
	}

    public System.Decimal? FK_Tank_Construction
	{
		get { return  _fK_Tank_Construction; }
		set { _fK_Tank_Construction = value; }
	}

	public System.String Construction_Other
	{
		get { return  _construction_Other; }
		set { _construction_Other = value; }
	}

	public System.String Release_Equipment_Present
	{
		get { return  _release_Equipment_Present; }
		set { _release_Equipment_Present = value; }
	}

	public System.String Release_Eqiupment_Description
	{
		get { return  _release_Eqiupment_Description; }
		set { _release_Eqiupment_Description = value; }
	}

    public System.DateTime? Installation
	{
		get { return  _installation; }
		set { _installation = value; }
	}

    public System.DateTime? Removal
	{
		get { return  _removal; }
		set { _removal = value; }
	}

    public System.DateTime? Closure
	{
		get { return  _closure; }
		set { _closure = value; }
	}

    public System.DateTime? Last_Inspection
	{
		get { return  _last_Inspection; }
		set { _last_Inspection = value; }
	}

    public System.DateTime? Next_Inspection
	{
		get { return  _next_Inspection; }
		set { _next_Inspection = value; }
	}

	public System.String Inspection_Company
	{
		get { return  _inspection_Company; }
		set { _inspection_Company = value; }
	}

	public System.String Inspection_Company_Contact_Name
	{
		get { return  _inspection_Company_Contact_Name; }
		set { _inspection_Company_Contact_Name = value; }
	}

	public System.String Inspection_Company_Telephone_Number
	{
		get { return  _inspection_Company_Telephone_Number; }
		set { _inspection_Company_Telephone_Number = value; }
	}

	public System.String Permit_Required
	{
		get { return  _permit_Required; }
		set { _permit_Required = value; }
	}

	public System.String Registration_Number
	{
		get { return  _registration_Number; }
		set { _registration_Number = value; }
	}

	public System.String Certificate_Number
	{
		get { return  _certificate_Number; }
		set { _certificate_Number = value; }
	}

    public System.DateTime? Permit_Begin
	{
		get { return  _permit_Begin; }
		set { _permit_Begin = value; }
	}

    public System.DateTime? Permit_End
	{
		get { return  _permit_End; }
		set { _permit_End = value; }
	}

	public System.String Other_Reporting_Requirements
	{
		get { return  _other_Reporting_Requirements; }
		set { _other_Reporting_Requirements = value; }
	}

	public System.String Reporting_Requirements_Description
	{
		get { return  _reporting_Requirements_Description; }
		set { _reporting_Requirements_Description = value; }
	}

    public System.DateTime? Next_Report
	{
		get { return  _next_Report; }
		set { _next_Report = value; }
	}

	public System.String Notes
	{
		get { return  _notes; }
		set { _notes = value; }
	}

	public System.String SPCCP_Identification
	{
		get { return  _sPCCP_Identification; }
		set { _sPCCP_Identification = value; }
	}

    public System.DateTime? SPCCP_Effective
	{
		get { return  _sPCCP_Effective; }
		set { _sPCCP_Effective = value; }
	}

    public System.DateTime? SPCCP_Expiration
	{
		get { return  _sPCCP_Expiration; }
		set { _sPCCP_Expiration = value; }
	}

    public System.DateTime? SPCCP_Last_Revision
	{
		get { return  _sPCCP_Last_Revision; }
		set { _sPCCP_Last_Revision = value; }
	}

	public System.String SPCCP_Vendor
	{
		get { return  _sPCCP_Vendor; }
		set { _sPCCP_Vendor = value; }
	}

	public System.String SPCCP_Vendor_Contact
	{
		get { return  _sPCCP_Vendor_Contact; }
		set { _sPCCP_Vendor_Contact = value; }
	}

	public System.String SPCCP_Vendor_Telephone_Number
	{
		get { return  _sPCCP_Vendor_Telephone_Number; }
		set { _sPCCP_Vendor_Telephone_Number = value; }
	}

	public System.Decimal? Updated_By
	{
		get { return  _updated_By; }
		set { _updated_By = value; }
	}

	public System.DateTime? Update_Date
	{
		get { return  _update_Date; }
		set { _update_Date = value; }
	}

	#endregion

	#region Abstract Methods
	public abstract DataSet GetAll();
    public abstract DataSet PropEnvTanks_GetByID(System.Decimal lPK_Environmental_Tanks);
    public abstract int PropEnvTanks_InsertUpdate(RIMS_Base.CPropEnvTanks obj);
    public abstract int PropEnvTanks_Delete(System.String lPK_Environmental_Tanks);
    public abstract DataSet GetAllCombo();
    public abstract DataSet GetOtherReportingReq(System.Decimal Pk_Environmental_Tanks);
	#endregion

}

}

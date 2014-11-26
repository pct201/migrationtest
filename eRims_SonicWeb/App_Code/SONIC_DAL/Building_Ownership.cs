using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Building_Ownership table.
    /// </summary>
    public sealed class Building_Ownership
    {

        #region Fields


        private int _PK_Building_Ownership_ID;
        private int _FK_Building_ID;
        private string _Owner_Name;
        private string _Owner_Address_1;
        private string _Owner_Address_2;
        private string _Owner_City;
        private string _Owner_State;
        private string _Owner_Zip;
        private string _Lease_Sublease;
        private string _Landlord_Name;
        private string _Landlord_Address_1;
        private string _Landlord_Address_2;
        private string _Landlord_City;
        private string _Landlord_State;
        private string _Landlord_Zip;
        private string _Lease_ID;
        private string _Sublease;
        private string _SubLandlord;
        private DateTime _Commencement_Date;
        private DateTime _Expiration_Date;
        private string _COI_Wording;
        private bool _REQ_WC;
        private bool _REQ_EL;
        private bool _REQ_GL;
        private bool _REQ_Pollution;
        private bool _REQ_Property;
        private bool _REQ_Flood;
        private bool _REQ_EQ;
        private bool _REQ_WaiverofSubrogation;
        private bool _SubResponsible_WC;
        private bool _SubResponsible_EL;
        private bool _SubResponsible_GL;
        private bool _SubResponsible_Pollution;
        private bool _SubResponsible_Property;
        private bool _SubResponsible_Flood;
        private bool _EQ;
        private bool _WaiverofSubrogation;
        private string _COI_WC;
        private string _COI_EL;
        private string _COI_GL;
        private string _COI_Pollution;
        private string _COI_Property;
        private string _COI_Flood;
        private string _COI_EQ;
        private string _COI_WaiverofSubrogation;
        private DateTime _COI_WC_Date;
        private DateTime _COI_EL_Date;
        private DateTime _COI_GL_Date;
        private DateTime _COI_Pollution_Date;
        private DateTime _COI_Property_Date;
        private DateTime _COI_Flood_Date;
        private DateTime _COI_EQ_Date;
        private DateTime _COI_WaiverofSubrogation_Date;
        private Nullable<decimal> _ReqLim_WC;
        private Nullable<decimal> _ReqLim_EL;
        private Nullable<decimal> _ReqLim_GL;
        private Nullable<decimal> _ReqLim_Pollution;
        private Nullable<decimal> _ReqLim_Property;
        private Nullable<decimal> _ReqLim_Flood;
        private Nullable<decimal> _ReqLim_EQ;
        private Nullable<decimal> _ReqLim_WaiverofSubrogation;
        private string _Landlord_Legal_Entity;
        private decimal _Updated_By;
        private DateTime _Updated_Date;
        private string _Sublease_Name;
        private string _Sublease_Address_1;
        private string _Sublease_Address_2;
        private string _Sublease_City;
        private string _Sublease_State;
        private string _Sublease_Zip;
        private string _Sublease_FirstName;
        private string _Sublease_LastName ;
        private string _Sublease_Title;
        private string _Sublease_Phone;
        private string _Sublease_Fax;
        private string _Sublease_Email;

        #endregion


        #region Properties

        /// <summary> 
        /// Gets or sets the PK_Building_Ownership_ID value.
        /// </summary>
        public int PK_Building_Ownership_ID
        {
            get { return _PK_Building_Ownership_ID; }
            set { _PK_Building_Ownership_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the FK_Building_ID value.
        /// </summary>
        public int FK_Building_ID
        {
            get { return _FK_Building_ID; }
            set { _FK_Building_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Name value.
        /// </summary>
        public string Owner_Name
        {
            get { return _Owner_Name; }
            set { _Owner_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Address_1 value.
        /// </summary>
        public string Owner_Address_1
        {
            get { return _Owner_Address_1; }
            set { _Owner_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Address_2 value.
        /// </summary>
        public string Owner_Address_2
        {
            get { return _Owner_Address_2; }
            set { _Owner_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_City value.
        /// </summary>
        public string Owner_City
        {
            get { return _Owner_City; }
            set { _Owner_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_State value.
        /// </summary>
        public string Owner_State
        {
            get { return _Owner_State; }
            set { _Owner_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Owner_Zip value.
        /// </summary>
        public string Owner_Zip
        {
            get { return _Owner_Zip; }
            set { _Owner_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Lease_Sublease value.
        /// </summary>
        public string Lease_Sublease
        {
            get { return _Lease_Sublease; }
            set { _Lease_Sublease = value; }
        }


        /// <summary> 
        /// Gets or sets the Landlord_Name value.
        /// </summary>
        public string Landlord_Name
        {
            get { return _Landlord_Name; }
            set { _Landlord_Name = value; }
        }


        /// <summary> 
        /// Gets or sets the Landlord_Address_1 value.
        /// </summary>
        public string Landlord_Address_1
        {
            get { return _Landlord_Address_1; }
            set { _Landlord_Address_1 = value; }
        }


        /// <summary> 
        /// Gets or sets the Landlord_Address_2 value.
        /// </summary>
        public string Landlord_Address_2
        {
            get { return _Landlord_Address_2; }
            set { _Landlord_Address_2 = value; }
        }


        /// <summary> 
        /// Gets or sets the Landlord_City value.
        /// </summary>
        public string Landlord_City
        {
            get { return _Landlord_City; }
            set { _Landlord_City = value; }
        }


        /// <summary> 
        /// Gets or sets the Landlord_State value.
        /// </summary>
        public string Landlord_State
        {
            get { return _Landlord_State; }
            set { _Landlord_State = value; }
        }


        /// <summary> 
        /// Gets or sets the Landlord_Zip value.
        /// </summary>
        public string Landlord_Zip
        {
            get { return _Landlord_Zip; }
            set { _Landlord_Zip = value; }
        }


        /// <summary> 
        /// Gets or sets the Lease_ID value.
        /// </summary>
        public string Lease_ID
        {
            get { return _Lease_ID; }
            set { _Lease_ID = value; }
        }


        /// <summary> 
        /// Gets or sets the Sublease value.
        /// </summary>
        public string Sublease
        {
            get { return _Sublease; }
            set { _Sublease = value; }
        }


        /// <summary> 
        /// Gets or sets the SubLandlord value.
        /// </summary>
        public string SubLandlord
        {
            get { return _SubLandlord; }
            set { _SubLandlord = value; }
        }


        /// <summary> 
        /// Gets or sets the Commencement_Date value.
        /// </summary>
        public DateTime Commencement_Date
        {
            get { return _Commencement_Date; }
            set { _Commencement_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the Expiration_Date value.
        /// </summary>
        public DateTime Expiration_Date
        {
            get { return _Expiration_Date; }
            set { _Expiration_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_Wording value.
        /// </summary>
        public string COI_Wording
        {
            get { return _COI_Wording; }
            set { _COI_Wording = value; }
        }


        /// <summary> 
        /// Gets or sets the REQ_WC value.
        /// </summary>
        public bool REQ_WC
        {
            get { return _REQ_WC; }
            set { _REQ_WC = value; }
        }


        /// <summary> 
        /// Gets or sets the REQ_EL value.
        /// </summary>
        public bool REQ_EL
        {
            get { return _REQ_EL; }
            set { _REQ_EL = value; }
        }


        /// <summary> 
        /// Gets or sets the REQ_GL value.
        /// </summary>
        public bool REQ_GL
        {
            get { return _REQ_GL; }
            set { _REQ_GL = value; }
        }

        public bool REQ_Pollution
        {
            get { return _REQ_Pollution; }
            set { _REQ_Pollution = value; }
        }

        /// <summary> 
        /// Gets or sets the REQ_Property value.
        /// </summary>
        public bool REQ_Property
        {
            get { return _REQ_Property; }
            set { _REQ_Property = value; }
        }


        /// <summary> 
        /// Gets or sets the REQ_Flood value.
        /// </summary>
        public bool REQ_Flood
        {
            get { return _REQ_Flood; }
            set { _REQ_Flood = value; }
        }


        /// <summary> 
        /// Gets or sets the REQ_EQ value.
        /// </summary>
        public bool REQ_EQ
        {
            get { return _REQ_EQ; }
            set { _REQ_EQ = value; }
        }


        /// <summary> 
        /// Gets or sets the REQ_WaiverofSubrogation value.
        /// </summary>
        public bool REQ_WaiverofSubrogation
        {
            get { return _REQ_WaiverofSubrogation; }
            set { _REQ_WaiverofSubrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the SubResponsible_WC value.
        /// </summary>
        public bool SubResponsible_WC
        {
            get { return _SubResponsible_WC; }
            set { _SubResponsible_WC = value; }
        }


        /// <summary> 
        /// Gets or sets the SubResponsible_EL value.
        /// </summary>
        public bool SubResponsible_EL
        {
            get { return _SubResponsible_EL; }
            set { _SubResponsible_EL = value; }
        }


        /// <summary> 
        /// Gets or sets the SubResponsible_GL value.
        /// </summary>
        public bool SubResponsible_GL
        {
            get { return _SubResponsible_GL; }
            set { _SubResponsible_GL = value; }
        }

        public bool SubResponsible_Pollution
        {
            get { return _SubResponsible_Pollution; }
            set { _SubResponsible_Pollution = value; }
        }

        /// <summary> 
        /// Gets or sets the SubResponsible_Property value.
        /// </summary>
        public bool SubResponsible_Property
        {
            get { return _SubResponsible_Property; }
            set { _SubResponsible_Property = value; }
        }


        /// <summary> 
        /// Gets or sets the SubResponsible_Flood value.
        /// </summary>
        public bool SubResponsible_Flood
        {
            get { return _SubResponsible_Flood; }
            set { _SubResponsible_Flood = value; }
        }


        /// <summary> 
        /// Gets or sets the EQ value.
        /// </summary>
        public bool EQ
        {
            get { return _EQ; }
            set { _EQ = value; }
        }


        /// <summary> 
        /// Gets or sets the WaiverofSubrogation value.
        /// </summary>
        public bool WaiverofSubrogation
        {
            get { return _WaiverofSubrogation; }
            set { _WaiverofSubrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_WC value.
        /// </summary>
        public string COI_WC
        {
            get { return _COI_WC; }
            set { _COI_WC = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_EL value.
        /// </summary>
        public string COI_EL
        {
            get { return _COI_EL; }
            set { _COI_EL = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_GL value.
        /// </summary>
        public string COI_GL
        {
            get { return _COI_GL; }
            set { _COI_GL = value; }
        }

        public string COI_Pollution
        {
            get { return _COI_Pollution; }
            set { _COI_Pollution = value; }
        }

        /// <summary> 
        /// Gets or sets the COI_Property value.
        /// </summary>
        public string COI_Property
        {
            get { return _COI_Property; }
            set { _COI_Property = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_Flood value.
        /// </summary>
        public string COI_Flood
        {
            get { return _COI_Flood; }
            set { _COI_Flood = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_EQ value.
        /// </summary>
        public string COI_EQ
        {
            get { return _COI_EQ; }
            set { _COI_EQ = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_WaiverofSubrogation value.
        /// </summary>
        public string COI_WaiverofSubrogation
        {
            get { return _COI_WaiverofSubrogation; }
            set { _COI_WaiverofSubrogation = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_WC_Date value.
        /// </summary>
        public DateTime COI_WC_Date
        {
            get { return _COI_WC_Date; }
            set { _COI_WC_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_EL_Date value.
        /// </summary>
        public DateTime COI_EL_Date
        {
            get { return _COI_EL_Date; }
            set { _COI_EL_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_GL_Date value.
        /// </summary>
        public DateTime COI_GL_Date
        {
            get { return _COI_GL_Date; }
            set { _COI_GL_Date = value; }
        }

        public DateTime COI_Pollution_Date
        {
            get { return _COI_Pollution_Date; }
            set { _COI_Pollution_Date = value; }
        }

        /// <summary> 
        /// Gets or sets the COI_Property_Date value.
        /// </summary>
        public DateTime COI_Property_Date
        {
            get { return _COI_Property_Date; }
            set { _COI_Property_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_Flood_Date value.
        /// </summary>
        public DateTime COI_Flood_Date
        {
            get { return _COI_Flood_Date; }
            set { _COI_Flood_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_EQ_Date value.
        /// </summary>
        public DateTime COI_EQ_Date
        {
            get { return _COI_EQ_Date; }
            set { _COI_EQ_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the COI_WaiverofSubrogation_Date value.
        /// </summary>
        public DateTime COI_WaiverofSubrogation_Date
        {
            get { return _COI_WaiverofSubrogation_Date; }
            set { _COI_WaiverofSubrogation_Date = value; }
        }


        /// <summary> 
        /// Gets or sets the ReqLim_WC value.
        /// </summary>
        public Nullable<decimal> ReqLim_WC
        {
            get { return _ReqLim_WC; }
            set { _ReqLim_WC = value; }
        }


        /// <summary> 
        /// Gets or sets the ReqLim_EL value.
        /// </summary>
        public Nullable<decimal> ReqLim_EL
        {
            get { return _ReqLim_EL; }
            set { _ReqLim_EL = value; }
        }


        /// <summary> 
        /// Gets or sets the ReqLim_GL value.
        /// </summary>
        public Nullable<decimal> ReqLim_GL
        {
            get { return _ReqLim_GL; }
            set { _ReqLim_GL = value; }
        }

        public Nullable<decimal> ReqLim_Pollution
        {
            get { return _ReqLim_Pollution; }
            set { _ReqLim_Pollution = value; }
        }

        /// <summary> 
        /// Gets or sets the ReqLim_Property value.
        /// </summary>
        public Nullable<decimal> ReqLim_Property
        {
            get { return _ReqLim_Property; }
            set { _ReqLim_Property = value; }
        }


        /// <summary> 
        /// Gets or sets the ReqLim_Flood value.
        /// </summary>
        public Nullable<decimal> ReqLim_Flood
        {
            get { return _ReqLim_Flood; }
            set { _ReqLim_Flood = value; }
        }


        /// <summary> 
        /// Gets or sets the ReqLim_EQ value.
        /// </summary>
        public Nullable<decimal> ReqLim_EQ
        {
            get { return _ReqLim_EQ; }
            set { _ReqLim_EQ = value; }
        }

        public Nullable<decimal> ReqLim_WaiverofSubrogation
        {
            get { return _ReqLim_WaiverofSubrogation; }
            set { _ReqLim_WaiverofSubrogation = value; }
        }

        public string Landlord_Legal_Entity
        {
            get { return _Landlord_Legal_Entity; }
            set { _Landlord_Legal_Entity = value; }
        }

        /// <summary> 
        /// Gets or sets the Updated_By value.
        /// </summary>
        public decimal Updated_By
        {
            get { return _Updated_By; }
            set { _Updated_By = value; }
        }


        /// <summary> 
        /// Gets or sets the Updated_Date value.
        /// </summary>
        public DateTime Updated_Date
        {
            get { return _Updated_Date; }
            set { _Updated_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_Name value.
        /// </summary>
        public string Sublease_Name
        {
            get { return _Sublease_Name; }
            set { _Sublease_Name = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_Address_1 value.
        /// </summary>
        public string Sublease_Address_1
        {
            get { return _Sublease_Address_1; }
            set { _Sublease_Address_1 = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_Address_2 value.
        /// </summary>
        public string Sublease_Address_2
        {
            get { return _Sublease_Address_2; }
            set { _Sublease_Address_2 = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_City value.
        /// </summary>
        public string Sublease_City
        {
            get { return _Sublease_City; }
            set { _Sublease_City = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_State value.
        /// </summary>
        public string Sublease_State
        {
            get { return _Sublease_State; }
            set { _Sublease_State = value; }
        }

        /// <summary>
        /// Gets or sets the Sublease_Zip value.
        /// </summary>
        public string Sublease_Zip
        {
            get { return _Sublease_Zip; }
            set { _Sublease_Zip = value; }
        }

        public string Sublease_FirstName
        {
            get { return _Sublease_FirstName; }
            set { _Sublease_FirstName = value; }
        }
        public string Sublease_LastName
        {
            get { return _Sublease_LastName; }
            set { _Sublease_LastName = value; }
        }
        public string Sublease_Title
        {
            get { return _Sublease_Title; }
            set { _Sublease_Title = value; }
        }
        public string Sublease_Phone
        {
            get { return _Sublease_Phone; }
            set { _Sublease_Phone = value; }
        }
        public string Sublease_Fax
        {
            get { return _Sublease_Fax; }
            set { _Sublease_Fax = value; }
        }
        public string Sublease_Email
        {
            get { return _Sublease_Email; }
            set { _Sublease_Email = value; }
        }
        #endregion


        #region Constructors

        /// <summary> 

        /// Initializes a new instance of the Building_Ownership class. with the default value.

        /// </summary>
        public Building_Ownership()
        {

            this._PK_Building_Ownership_ID = -1;
            this._FK_Building_ID = -1;
            this._Owner_Name = "";
            this._Owner_Address_1 = "";
            this._Owner_Address_2 = "";
            this._Owner_City = "";
            this._Owner_State = "";
            this._Owner_Zip = "";
            this._Lease_Sublease = "";
            this._Landlord_Name = "";
            this._Landlord_Address_1 = "";
            this._Landlord_Address_2 = "";
            this._Landlord_City = "";
            this._Landlord_State = "";
            this._Landlord_Zip = "";
            this._Lease_ID = "";
            this._Sublease = "";
            this._SubLandlord = "";
            this._Commencement_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_Wording = "";
            this._REQ_WC = false;
            this._REQ_EL = false;
            this._REQ_GL = false;
            this._REQ_Pollution = false;
            this._REQ_Property = false;
            this._REQ_Flood = false;
            this._REQ_EQ = false;
            this._REQ_WaiverofSubrogation = false;
            this._SubResponsible_WC = false;
            this._SubResponsible_EL = false;
            this._SubResponsible_GL = false;
            this._SubResponsible_Pollution = false;
            this._SubResponsible_Property = false;
            this._SubResponsible_Flood = false;
            this._EQ = false;
            this._WaiverofSubrogation = false;
            this._COI_WC = "";
            this._COI_EL = "";
            this._COI_GL = "";
            this._COI_Pollution = "";
            this._COI_Property = "";
            this._COI_Flood = "";
            this._COI_EQ = "";
            this._COI_WaiverofSubrogation = "";
            this._COI_WC_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_EL_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_GL_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_Pollution_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_Property_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_Flood_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_EQ_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._COI_WaiverofSubrogation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._ReqLim_WC = null;
            this._ReqLim_EL = null;
            this._ReqLim_GL = null;
            this._ReqLim_Property = null;
            this._ReqLim_Flood = null;
            this._ReqLim_EQ = null;
            this._ReqLim_WaiverofSubrogation = null;
            this._Landlord_Legal_Entity = null;
            this._Updated_By = -1;
            this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
            this._Sublease_Name = null;
            this._Sublease_Address_1 = null;
            this._Sublease_Address_2 = null;
            this._Sublease_City = null;
            this._Sublease_State = null;
            this._Sublease_Zip = null;
            this._Sublease_FirstName = null;
            this._Sublease_LastName = null;           
            this._Sublease_Title = null;
            this._Sublease_Phone = null;           
            this._Sublease_Fax = null;
            this._Sublease_Email = null;
        }



        /// <summary> 

        /// Initializes a new instance of the Building_Ownership class for passed PrimaryKey with the values set from Database.


        /// </summary>
        public Building_Ownership(int PK)
        {

            DataTable dtBuilding_Ownership = SelectByPK(PK).Tables[0];

            if (dtBuilding_Ownership.Rows.Count > 0)
            {
                DataRow drBuilding_Ownership = dtBuilding_Ownership.Rows[0];
                this._PK_Building_Ownership_ID = drBuilding_Ownership["PK_Building_Ownership_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding_Ownership["PK_Building_Ownership_ID"]) : 0;
                this._FK_Building_ID = drBuilding_Ownership["FK_Building_ID"] != DBNull.Value ? Convert.ToInt32(drBuilding_Ownership["FK_Building_ID"]) : 0;
                this._Owner_Name = Convert.ToString(drBuilding_Ownership["Owner_Name"]);
                this._Owner_Address_1 = Convert.ToString(drBuilding_Ownership["Owner_Address_1"]);
                this._Owner_Address_2 = Convert.ToString(drBuilding_Ownership["Owner_Address_2"]);
                this._Owner_City = Convert.ToString(drBuilding_Ownership["Owner_City"]);
                this._Owner_State = Convert.ToString(drBuilding_Ownership["Owner_State"]);
                this._Owner_Zip = Convert.ToString(drBuilding_Ownership["Owner_Zip"]);
                this._Lease_Sublease = Convert.ToString(drBuilding_Ownership["Lease_Sublease"]);
                this._Landlord_Name = Convert.ToString(drBuilding_Ownership["Landlord_Name"]);
                this._Landlord_Address_1 = Convert.ToString(drBuilding_Ownership["Landlord_Address_1"]);
                this._Landlord_Address_2 = Convert.ToString(drBuilding_Ownership["Landlord_Address_2"]);
                this._Landlord_City = Convert.ToString(drBuilding_Ownership["Landlord_City"]);
                this._Landlord_State = Convert.ToString(drBuilding_Ownership["Landlord_State"]);
                this._Landlord_Zip = Convert.ToString(drBuilding_Ownership["Landlord_Zip"]);
                this._Lease_ID = Convert.ToString(drBuilding_Ownership["Lease_ID"]);
                this._Sublease = Convert.ToString(drBuilding_Ownership["Sublease"]);
                this._SubLandlord = Convert.ToString(drBuilding_Ownership["SubLandlord"]);
                this._Commencement_Date = drBuilding_Ownership["Commencement_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["Commencement_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Expiration_Date = drBuilding_Ownership["Expiration_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["Expiration_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Wording = Convert.ToString(drBuilding_Ownership["COI_Wording"]);
                this._REQ_WC = drBuilding_Ownership["REQ_WC"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_WC"]) : false;
                this._REQ_EL = drBuilding_Ownership["REQ_EL"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_EL"]) : false;
                this._REQ_GL = drBuilding_Ownership["REQ_GL"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_GL"]) : false;
                this._REQ_Pollution = drBuilding_Ownership["REQ_Pollution"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_Pollution"]) : false;
                this._REQ_Property = drBuilding_Ownership["REQ_Property"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_Property"]) : false;
                this._REQ_Flood = drBuilding_Ownership["REQ_Flood"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_Flood"]) : false;
                this._REQ_EQ = drBuilding_Ownership["REQ_EQ"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_EQ"]) : false;
                this._REQ_WaiverofSubrogation = drBuilding_Ownership["REQ_WaiverofSubrogation"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["REQ_WaiverofSubrogation"]) : false;
                this._SubResponsible_WC = drBuilding_Ownership["SubResponsible_WC"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["SubResponsible_WC"]) : false;
                this._SubResponsible_EL = drBuilding_Ownership["SubResponsible_EL"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["SubResponsible_EL"]) : false;
                this._SubResponsible_GL = drBuilding_Ownership["SubResponsible_GL"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["SubResponsible_GL"]) : false;
                this._SubResponsible_Pollution = drBuilding_Ownership["SubResponsible_Pollution"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["SubResponsible_Pollution"]) : false;
                this._SubResponsible_Property = drBuilding_Ownership["SubResponsible_Property"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["SubResponsible_Property"]) : false;
                this._SubResponsible_Flood = drBuilding_Ownership["SubResponsible_Flood"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["SubResponsible_Flood"]) : false;
                this._EQ = drBuilding_Ownership["EQ"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["EQ"]) : false;
                this._WaiverofSubrogation = drBuilding_Ownership["WaiverofSubrogation"] != DBNull.Value ? Convert.ToBoolean(drBuilding_Ownership["WaiverofSubrogation"]) : false;
                this._COI_WC = Convert.ToString(drBuilding_Ownership["COI_WC"]);
                this._COI_EL = Convert.ToString(drBuilding_Ownership["COI_EL"]);
                this._COI_GL = Convert.ToString(drBuilding_Ownership["COI_GL"]);
                this._COI_Pollution = Convert.ToString(drBuilding_Ownership["COI_Pollution"]);
                this._COI_Property = Convert.ToString(drBuilding_Ownership["COI_Property"]);
                this._COI_Flood = Convert.ToString(drBuilding_Ownership["COI_Flood"]);
                this._COI_EQ = Convert.ToString(drBuilding_Ownership["COI_EQ"]);
                this._COI_WaiverofSubrogation = Convert.ToString(drBuilding_Ownership["COI_WaiverofSubrogation"]);
                this._COI_WC_Date = drBuilding_Ownership["COI_WC_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_WC_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_EL_Date = drBuilding_Ownership["COI_EL_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_EL_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_GL_Date = drBuilding_Ownership["COI_GL_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_GL_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Pollution_Date = drBuilding_Ownership["COI_Pollution_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_Pollution_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Property_Date = drBuilding_Ownership["COI_Property_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_Property_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Flood_Date = drBuilding_Ownership["COI_Flood_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_Flood_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_EQ_Date = drBuilding_Ownership["COI_EQ_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_EQ_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_WaiverofSubrogation_Date = drBuilding_Ownership["COI_WaiverofSubrogation_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["COI_WaiverofSubrogation_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;

                if (drBuilding_Ownership["ReqLim_WC"] != DBNull.Value) this._ReqLim_WC = Convert.ToDecimal(drBuilding_Ownership["ReqLim_WC"]);
                if (drBuilding_Ownership["ReqLim_EL"] != DBNull.Value) this._ReqLim_EL = Convert.ToDecimal(drBuilding_Ownership["ReqLim_EL"]);
                if (drBuilding_Ownership["ReqLim_GL"] != DBNull.Value) this._ReqLim_GL = Convert.ToDecimal(drBuilding_Ownership["ReqLim_GL"]);
                if (drBuilding_Ownership["ReqLim_Pollution"] != DBNull.Value) this._ReqLim_Pollution = Convert.ToDecimal(drBuilding_Ownership["ReqLim_Pollution"]);
                if (drBuilding_Ownership["ReqLim_Property"] != DBNull.Value) this._ReqLim_Property = Convert.ToDecimal(drBuilding_Ownership["ReqLim_Property"]);
                if (drBuilding_Ownership["ReqLim_Flood"] != DBNull.Value) this._ReqLim_Flood = Convert.ToDecimal(drBuilding_Ownership["ReqLim_Flood"]);
                if (drBuilding_Ownership["ReqLim_EQ"] != DBNull.Value) this._ReqLim_EQ = Convert.ToDecimal(drBuilding_Ownership["ReqLim_EQ"]);
                if (drBuilding_Ownership["ReqLim_WaiverofSubrogation"] != DBNull.Value) this._ReqLim_WaiverofSubrogation = Convert.ToDecimal(drBuilding_Ownership["ReqLim_WaiverofSubrogation"]);
                this._Landlord_Legal_Entity = Convert.ToString(drBuilding_Ownership["Landlord_Legal_Entity"]);
                this._Updated_By = drBuilding_Ownership["Updated_By"] != DBNull.Value ? Convert.ToDecimal(drBuilding_Ownership["Updated_By"]) : 0;
                this._Updated_Date = drBuilding_Ownership["Updated_Date"] != DBNull.Value ? Convert.ToDateTime(drBuilding_Ownership["Updated_Date"]) : (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                
                if (drBuilding_Ownership["Sublease_Name"] == DBNull.Value)
                    this._Sublease_Name = null;
                else
                    this._Sublease_Name = (string)drBuilding_Ownership["Sublease_Name"];

                if (drBuilding_Ownership["Sublease_Address_1"] == DBNull.Value)
                    this._Sublease_Address_1 = null;
                else
                    this._Sublease_Address_1 = (string)drBuilding_Ownership["Sublease_Address_1"];

                if (drBuilding_Ownership["Sublease_Address_2"] == DBNull.Value)
                    this._Sublease_Address_2 = null;
                else
                    this._Sublease_Address_2 = (string)drBuilding_Ownership["Sublease_Address_2"];

                if (drBuilding_Ownership["Sublease_City"] == DBNull.Value)
                    this._Sublease_City = null;
                else
                    this._Sublease_City = (string)drBuilding_Ownership["Sublease_City"];

                if (drBuilding_Ownership["Sublease_State"] == DBNull.Value)
                    this._Sublease_State = null;
                else
                    this._Sublease_State = (string)drBuilding_Ownership["Sublease_State"];

                if (drBuilding_Ownership["Sublease_Zip"] == DBNull.Value)
                    this._Sublease_Zip = null;
                else
                    this._Sublease_Zip = (string)drBuilding_Ownership["Sublease_Zip"];

                if (drBuilding_Ownership["Sublease_FirstName"] == DBNull.Value)
                    this._Sublease_FirstName = null;
                else
                    this._Sublease_FirstName = (string)drBuilding_Ownership["Sublease_FirstName"];

                if (drBuilding_Ownership["Sublease_LastName"] == DBNull.Value)
                    this._Sublease_LastName = null;
                else
                    this._Sublease_LastName = (string)drBuilding_Ownership["Sublease_LastName"];

                if (drBuilding_Ownership["Sublease_Title"] == DBNull.Value)
                    this._Sublease_Title = null;
                else
                    this._Sublease_Title = (string)drBuilding_Ownership["Sublease_Title"];

                if (drBuilding_Ownership["Sublease_Phone"] == DBNull.Value)
                    this._Sublease_Phone = null;
                else
                    this._Sublease_Phone = (string)drBuilding_Ownership["Sublease_Phone"];

                if (drBuilding_Ownership["Sublease_Fax"] == DBNull.Value)
                    this._Sublease_Fax = null;
                else
                    this._Sublease_Fax = (string)drBuilding_Ownership["Sublease_Fax"];

                if (drBuilding_Ownership["Sublease_Email"] == DBNull.Value)
                    this._Sublease_Email = null;
                else
                    this._Sublease_Email = (string)drBuilding_Ownership["Sublease_Email"];
            }
            else
            {
                this._PK_Building_Ownership_ID = -1;
                this._FK_Building_ID = -1;
                this._Owner_Name = "";
                this._Owner_Address_1 = "";
                this._Owner_Address_2 = "";
                this._Owner_City = "";
                this._Owner_State = "";
                this._Owner_Zip = "";
                this._Lease_Sublease = "";
                this._Landlord_Name = "";
                this._Landlord_Address_1 = "";
                this._Landlord_Address_2 = "";
                this._Landlord_City = "";
                this._Landlord_State = "";
                this._Landlord_Zip = "";
                this._Lease_ID = "";
                this._Sublease = "";
                this._SubLandlord = "";
                this._Commencement_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Expiration_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Wording = "";
                this._REQ_WC = false;
                this._REQ_EL = false;
                this._REQ_GL = false;
                this._REQ_Pollution = false;
                this._REQ_Property = false;
                this._REQ_Flood = false;
                this._REQ_EQ = false;
                this._REQ_WaiverofSubrogation = false;
                this._SubResponsible_WC = false;
                this._SubResponsible_EL = false;
                this._SubResponsible_GL = false;
                this._SubResponsible_Pollution = false;
                this._SubResponsible_Property = false;
                this._SubResponsible_Flood = false;
                this._EQ = false;
                this._WaiverofSubrogation = false;
                this._COI_WC = "";
                this._COI_EL = "";
                this._COI_GL = "";
                this._COI_Pollution = "";
                this._COI_Property = "";
                this._COI_Flood = "";
                this._COI_EQ = "";
                this._COI_WaiverofSubrogation = "";
                this._COI_WC_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_EL_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_GL_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Pollution_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Property_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_Flood_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_EQ_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._COI_WaiverofSubrogation_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._ReqLim_WC = null;
                this._ReqLim_EL = null;
                this._ReqLim_GL = null;
                this._ReqLim_Property = null;
                this._ReqLim_Flood = null;
                this._ReqLim_EQ = null;
                this._ReqLim_WaiverofSubrogation = null;
                this._Landlord_Legal_Entity = null;
                this._Updated_By = -1;
                this._Updated_Date = (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue;
                this._Sublease_Name = null;
                this._Sublease_Address_1 = null;
                this._Sublease_Address_2 = null;
                this._Sublease_City = null;
                this._Sublease_State = null;
                this._Sublease_Zip = null;
                this._Sublease_FirstName = null;
                this._Sublease_LastName = null;
                this._Sublease_Title = null;
                this._Sublease_Phone = null;
                this._Sublease_Fax = null;
                this._Sublease_Email = null;
            }
        }



        #endregion

        #region Methods
        /// <summary>
        /// Inserts a record into the Building_Ownership table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_OwnershipInsert");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
            db.AddInParameter(dbCommand, "Owner_Name", DbType.String, this._Owner_Name);
            db.AddInParameter(dbCommand, "Owner_Address_1", DbType.String, this._Owner_Address_1);
            db.AddInParameter(dbCommand, "Owner_Address_2", DbType.String, this._Owner_Address_2);
            db.AddInParameter(dbCommand, "Owner_City", DbType.String, this._Owner_City);
            db.AddInParameter(dbCommand, "Owner_State", DbType.String, this._Owner_State);
            db.AddInParameter(dbCommand, "Owner_Zip", DbType.String, this._Owner_Zip);
            db.AddInParameter(dbCommand, "Lease_Sublease", DbType.String, this._Lease_Sublease);
            db.AddInParameter(dbCommand, "Landlord_Name", DbType.String, this._Landlord_Name);
            db.AddInParameter(dbCommand, "Landlord_Address_1", DbType.String, this._Landlord_Address_1);
            db.AddInParameter(dbCommand, "Landlord_Address_2", DbType.String, this._Landlord_Address_2);
            db.AddInParameter(dbCommand, "Landlord_City", DbType.String, this._Landlord_City);
            db.AddInParameter(dbCommand, "Landlord_State", DbType.String, this._Landlord_State);
            db.AddInParameter(dbCommand, "Landlord_Zip", DbType.String, this._Landlord_Zip);
            db.AddInParameter(dbCommand, "Lease_ID", DbType.String, this._Lease_ID);
            db.AddInParameter(dbCommand, "Sublease", DbType.String, this._Sublease);
            db.AddInParameter(dbCommand, "SubLandlord", DbType.String, this._SubLandlord);

            if (this._Commencement_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Commencement_Date", DbType.DateTime, this._Commencement_Date);
            else
                db.AddInParameter(dbCommand, "Commencement_Date", DbType.DateTime, DBNull.Value);

            if (this._Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, this._Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "COI_Wording", DbType.String, this._COI_Wording);
            db.AddInParameter(dbCommand, "REQ_WC", DbType.Boolean, this._REQ_WC);
            db.AddInParameter(dbCommand, "REQ_EL", DbType.Boolean, this._REQ_EL);
            db.AddInParameter(dbCommand, "REQ_GL", DbType.Boolean, this._REQ_GL);
            db.AddInParameter(dbCommand, "REQ_Pollution", DbType.Boolean, this._REQ_Pollution);
            db.AddInParameter(dbCommand, "REQ_Property", DbType.Boolean, this._REQ_Property);
            db.AddInParameter(dbCommand, "REQ_Flood", DbType.Boolean, this._REQ_Flood);
            db.AddInParameter(dbCommand, "REQ_EQ", DbType.Boolean, this._REQ_EQ);
            db.AddInParameter(dbCommand, "REQ_WaiverofSubrogation", DbType.Boolean, this._REQ_WaiverofSubrogation);
            db.AddInParameter(dbCommand, "SubResponsible_WC", DbType.Boolean, this._SubResponsible_WC);
            db.AddInParameter(dbCommand, "SubResponsible_EL", DbType.Boolean, this._SubResponsible_EL);
            db.AddInParameter(dbCommand, "SubResponsible_GL", DbType.Boolean, this._SubResponsible_GL);
            db.AddInParameter(dbCommand, "SubResponsible_Pollution", DbType.Boolean, this._SubResponsible_Pollution);
            db.AddInParameter(dbCommand, "SubResponsible_Property", DbType.Boolean, this._SubResponsible_Property);
            db.AddInParameter(dbCommand, "SubResponsible_Flood", DbType.Boolean, this._SubResponsible_Flood);
            db.AddInParameter(dbCommand, "EQ", DbType.Boolean, this._EQ);
            db.AddInParameter(dbCommand, "WaiverofSubrogation", DbType.Boolean, this._WaiverofSubrogation);
            db.AddInParameter(dbCommand, "COI_WC", DbType.String, this._COI_WC);
            db.AddInParameter(dbCommand, "COI_EL", DbType.String, this._COI_EL);
            db.AddInParameter(dbCommand, "COI_GL", DbType.String, this._COI_GL);
            db.AddInParameter(dbCommand, "COI_Pollution", DbType.String, this._COI_Pollution);
            db.AddInParameter(dbCommand, "COI_Property", DbType.String, this._COI_Property);
            db.AddInParameter(dbCommand, "COI_Flood", DbType.String, this._COI_Flood);
            db.AddInParameter(dbCommand, "COI_EQ", DbType.String, this._COI_EQ);
            db.AddInParameter(dbCommand, "COI_WaiverofSubrogation", DbType.String, this._COI_WaiverofSubrogation);

            if (this._COI_WC_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_WC_Date", DbType.DateTime, this._COI_WC_Date);
            else
                db.AddInParameter(dbCommand, "COI_WC_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_EL_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_EL_Date", DbType.DateTime, this._COI_EL_Date);
            else
                db.AddInParameter(dbCommand, "COI_EL_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_GL_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_GL_Date", DbType.DateTime, this._COI_GL_Date);
            else
                db.AddInParameter(dbCommand, "COI_GL_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_Pollution_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_Pollution_Date ", DbType.DateTime, this._COI_Pollution_Date);
            else
                db.AddInParameter(dbCommand, "COI_Pollution_Date ", DbType.DateTime, DBNull.Value);

            if (this._COI_Property_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_Property_Date", DbType.DateTime, this._COI_Property_Date);
            else
                db.AddInParameter(dbCommand, "COI_Property_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_Flood_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_Flood_Date", DbType.DateTime, this._COI_Flood_Date);
            else
                db.AddInParameter(dbCommand, "COI_Flood_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_EQ_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_EQ_Date", DbType.DateTime, this._COI_EQ_Date);
            else
                db.AddInParameter(dbCommand, "COI_EQ_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_WaiverofSubrogation_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_WaiverofSubrogation_Date", DbType.DateTime, this._COI_WaiverofSubrogation_Date);
            else
                db.AddInParameter(dbCommand, "COI_WaiverofSubrogation_Date", DbType.DateTime, DBNull.Value);

            if (this._ReqLim_WC != null)
                db.AddInParameter(dbCommand, "ReqLim_WC", DbType.Decimal, this._ReqLim_WC);
            else
                db.AddInParameter(dbCommand, "ReqLim_WC", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_EL != null)
                db.AddInParameter(dbCommand, "ReqLim_EL", DbType.Decimal, this._ReqLim_EL);
            else
                db.AddInParameter(dbCommand, "ReqLim_EL", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_GL != null)
                db.AddInParameter(dbCommand, "ReqLim_GL", DbType.Decimal, this._ReqLim_GL);
            else
                db.AddInParameter(dbCommand, "ReqLim_GL", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_Pollution != null)
                db.AddInParameter(dbCommand, "ReqLim_Pollution", DbType.Decimal, this._ReqLim_Pollution);
            else
                db.AddInParameter(dbCommand, "ReqLim_Pollution", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_Property != null)
                db.AddInParameter(dbCommand, "ReqLim_Property", DbType.Decimal, this._ReqLim_Property);
            else
                db.AddInParameter(dbCommand, "ReqLim_Property", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_Flood != null)
                db.AddInParameter(dbCommand, "ReqLim_Flood", DbType.Decimal, this._ReqLim_Flood);
            else
                db.AddInParameter(dbCommand, "ReqLim_Flood", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_EQ != null)
                db.AddInParameter(dbCommand, "ReqLim_EQ", DbType.Decimal, this._ReqLim_EQ);
            else
                db.AddInParameter(dbCommand, "ReqLim_EQ", DbType.Decimal, DBNull.Value);

            if (this.ReqLim_WaiverofSubrogation != null)
                db.AddInParameter(dbCommand, "ReqLim_WaiverofSubrogation", DbType.Decimal, this._ReqLim_WaiverofSubrogation);
            else
                db.AddInParameter(dbCommand, "ReqLim_WaiverofSubrogation", DbType.Decimal, DBNull.Value);

            if (string.IsNullOrEmpty(this._Landlord_Legal_Entity))
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, this._Landlord_Legal_Entity);


            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            if (string.IsNullOrEmpty(this._Sublease_Name))
                db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, this._Sublease_Name);

            if (string.IsNullOrEmpty(this._Sublease_Address_1))
                db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, this._Sublease_Address_1);

            if (string.IsNullOrEmpty(this._Sublease_Address_2))
                db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, this._Sublease_Address_2);

            if (string.IsNullOrEmpty(this._Sublease_City))
                db.AddInParameter(dbCommand, "Sublease_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_City", DbType.String, this._Sublease_City);

            if (string.IsNullOrEmpty(this._Sublease_State))
                db.AddInParameter(dbCommand, "Sublease_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_State", DbType.String, this._Sublease_State);

            if (string.IsNullOrEmpty(this._Sublease_Zip))
                db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, this._Sublease_Zip);

            if (string.IsNullOrEmpty(this._Sublease_FirstName))
                db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, this._Sublease_FirstName);


            if (string.IsNullOrEmpty(this._Sublease_LastName))
                db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, this._Sublease_LastName);

            if (string.IsNullOrEmpty(this._Sublease_Title))
                db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, this._Sublease_Title);

            if (string.IsNullOrEmpty(this._Sublease_Phone))
                db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, this._Sublease_Phone);

            if (string.IsNullOrEmpty(this._Sublease_Fax))
                db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, this._Sublease_Fax);

            if (string.IsNullOrEmpty(this._Sublease_Email))
                db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, this._Sublease_Email);
                    
               
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the Building_Ownership table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectByPK(int pK_Building_Ownership_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_OwnershipSelectByPK");

            db.AddInParameter(dbCommand, "PK_Building_Ownership_ID", DbType.Int32, pK_Building_Ownership_ID);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the Building_Ownership table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_OwnershipSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the Building_Ownership table.
        /// </summary>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_OwnershipUpdate");

            db.AddInParameter(dbCommand, "PK_Building_Ownership_ID", DbType.Int32, this._PK_Building_Ownership_ID);
            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, this._FK_Building_ID);
            db.AddInParameter(dbCommand, "Owner_Name", DbType.String, this._Owner_Name);
            db.AddInParameter(dbCommand, "Owner_Address_1", DbType.String, this._Owner_Address_1);
            db.AddInParameter(dbCommand, "Owner_Address_2", DbType.String, this._Owner_Address_2);
            db.AddInParameter(dbCommand, "Owner_City", DbType.String, this._Owner_City);
            db.AddInParameter(dbCommand, "Owner_State", DbType.String, this._Owner_State);
            db.AddInParameter(dbCommand, "Owner_Zip", DbType.String, this._Owner_Zip);
            db.AddInParameter(dbCommand, "Lease_Sublease", DbType.String, this._Lease_Sublease);
            db.AddInParameter(dbCommand, "Landlord_Name", DbType.String, this._Landlord_Name);
            db.AddInParameter(dbCommand, "Landlord_Address_1", DbType.String, this._Landlord_Address_1);
            db.AddInParameter(dbCommand, "Landlord_Address_2", DbType.String, this._Landlord_Address_2);
            db.AddInParameter(dbCommand, "Landlord_City", DbType.String, this._Landlord_City);
            db.AddInParameter(dbCommand, "Landlord_State", DbType.String, this._Landlord_State);
            db.AddInParameter(dbCommand, "Landlord_Zip", DbType.String, this._Landlord_Zip);
            db.AddInParameter(dbCommand, "Lease_ID", DbType.String, this._Lease_ID);
            db.AddInParameter(dbCommand, "Sublease", DbType.String, this._Sublease);
            db.AddInParameter(dbCommand, "SubLandlord", DbType.String, this._SubLandlord);

            if (this._Commencement_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Commencement_Date", DbType.DateTime, this._Commencement_Date);
            else
                db.AddInParameter(dbCommand, "Commencement_Date", DbType.DateTime, DBNull.Value);

            if (this._Expiration_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, this._Expiration_Date);
            else
                db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, DBNull.Value);

            db.AddInParameter(dbCommand, "COI_Wording", DbType.String, this._COI_Wording);
            db.AddInParameter(dbCommand, "REQ_WC", DbType.Boolean, this._REQ_WC);
            db.AddInParameter(dbCommand, "REQ_EL", DbType.Boolean, this._REQ_EL);
            db.AddInParameter(dbCommand, "REQ_GL", DbType.Boolean, this._REQ_GL);
            db.AddInParameter(dbCommand, "REQ_Pollution", DbType.Boolean, this._REQ_Pollution);
            db.AddInParameter(dbCommand, "REQ_Property", DbType.Boolean, this._REQ_Property);
            db.AddInParameter(dbCommand, "REQ_Flood", DbType.Boolean, this._REQ_Flood);
            db.AddInParameter(dbCommand, "REQ_EQ", DbType.Boolean, this._REQ_EQ);
            db.AddInParameter(dbCommand, "REQ_WaiverofSubrogation", DbType.Boolean, this._REQ_WaiverofSubrogation);
            db.AddInParameter(dbCommand, "SubResponsible_WC", DbType.Boolean, this._SubResponsible_WC);
            db.AddInParameter(dbCommand, "SubResponsible_EL", DbType.Boolean, this._SubResponsible_EL);
            db.AddInParameter(dbCommand, "SubResponsible_GL", DbType.Boolean, this._SubResponsible_GL);
            db.AddInParameter(dbCommand, "SubResponsible_Pollution", DbType.Boolean, this._SubResponsible_Pollution);
            db.AddInParameter(dbCommand, "SubResponsible_Property", DbType.Boolean, this._SubResponsible_Property);
            db.AddInParameter(dbCommand, "SubResponsible_Flood", DbType.Boolean, this._SubResponsible_Flood);
            db.AddInParameter(dbCommand, "EQ", DbType.Boolean, this._EQ);
            db.AddInParameter(dbCommand, "WaiverofSubrogation", DbType.Boolean, this._WaiverofSubrogation);
            db.AddInParameter(dbCommand, "COI_WC", DbType.String, this._COI_WC);
            db.AddInParameter(dbCommand, "COI_EL", DbType.String, this._COI_EL);
            db.AddInParameter(dbCommand, "COI_GL", DbType.String, this._COI_GL);
            db.AddInParameter(dbCommand, "COI_Pollution", DbType.String, this._COI_Pollution);
            db.AddInParameter(dbCommand, "COI_Property", DbType.String, this._COI_Property);
            db.AddInParameter(dbCommand, "COI_Flood", DbType.String, this._COI_Flood);
            db.AddInParameter(dbCommand, "COI_EQ", DbType.String, this._COI_EQ);
            db.AddInParameter(dbCommand, "COI_WaiverofSubrogation", DbType.String, this._COI_WaiverofSubrogation);

            if (this._COI_WC_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_WC_Date", DbType.DateTime, this._COI_WC_Date);
            else
                db.AddInParameter(dbCommand, "COI_WC_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_EL_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_EL_Date", DbType.DateTime, this._COI_EL_Date);
            else
                db.AddInParameter(dbCommand, "COI_EL_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_GL_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_GL_Date", DbType.DateTime, this._COI_GL_Date);
            else
                db.AddInParameter(dbCommand, "COI_GL_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_Pollution_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_Pollution_Date ", DbType.DateTime, this._COI_Pollution_Date);
            else
                db.AddInParameter(dbCommand, "COI_Pollution_Date ", DbType.DateTime, DBNull.Value);

            if (this._COI_Property_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_Property_Date", DbType.DateTime, this._COI_Property_Date);
            else
                db.AddInParameter(dbCommand, "COI_Property_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_Flood_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_Flood_Date", DbType.DateTime, this._COI_Flood_Date);
            else
                db.AddInParameter(dbCommand, "COI_Flood_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_EQ_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_EQ_Date", DbType.DateTime, this._COI_EQ_Date);
            else
                db.AddInParameter(dbCommand, "COI_EQ_Date", DbType.DateTime, DBNull.Value);

            if (this._COI_WaiverofSubrogation_Date != AppConfig.SqlMinDateValue)
                db.AddInParameter(dbCommand, "COI_WaiverofSubrogation_Date", DbType.DateTime, this._COI_WaiverofSubrogation_Date);
            else
                db.AddInParameter(dbCommand, "COI_WaiverofSubrogation_Date", DbType.DateTime, DBNull.Value);

            if (this._ReqLim_WC != null)
                db.AddInParameter(dbCommand, "ReqLim_WC", DbType.Decimal, this._ReqLim_WC);
            else
                db.AddInParameter(dbCommand, "ReqLim_WC", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_EL != null)
                db.AddInParameter(dbCommand, "ReqLim_EL", DbType.Decimal, this._ReqLim_EL);
            else
                db.AddInParameter(dbCommand, "ReqLim_EL", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_GL != null)
                db.AddInParameter(dbCommand, "ReqLim_GL", DbType.Decimal, this._ReqLim_GL);
            else
                db.AddInParameter(dbCommand, "ReqLim_GL", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_Pollution != null)
                db.AddInParameter(dbCommand, "ReqLim_Pollution", DbType.Decimal, this._ReqLim_Pollution);
            else
                db.AddInParameter(dbCommand, "ReqLim_Pollution", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_Property != null)
                db.AddInParameter(dbCommand, "ReqLim_Property", DbType.Decimal, this._ReqLim_Property);
            else
                db.AddInParameter(dbCommand, "ReqLim_Property", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_Flood != null)
                db.AddInParameter(dbCommand, "ReqLim_Flood", DbType.Decimal, this._ReqLim_Flood);
            else
                db.AddInParameter(dbCommand, "ReqLim_Flood", DbType.Decimal, DBNull.Value);

            if (this._ReqLim_EQ != null)
                db.AddInParameter(dbCommand, "ReqLim_EQ", DbType.Decimal, this._ReqLim_EQ);
            else
                db.AddInParameter(dbCommand, "ReqLim_EQ", DbType.Decimal, DBNull.Value);

            if (this.ReqLim_WaiverofSubrogation != null)
                db.AddInParameter(dbCommand, "ReqLim_WaiverofSubrogation", DbType.Decimal, this._ReqLim_WaiverofSubrogation);
            else
                db.AddInParameter(dbCommand, "ReqLim_WaiverofSubrogation", DbType.Decimal, DBNull.Value);

            if (string.IsNullOrEmpty(this._Landlord_Legal_Entity))
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Landlord_Legal_Entity", DbType.String, this._Landlord_Legal_Entity);

            db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
            db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
            if (string.IsNullOrEmpty(this._Sublease_Name))
                db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Name", DbType.String, this._Sublease_Name);

            if (string.IsNullOrEmpty(this._Sublease_Address_1))
                db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Address_1", DbType.String, this._Sublease_Address_1);

            if (string.IsNullOrEmpty(this._Sublease_Address_2))
                db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Address_2", DbType.String, this._Sublease_Address_2);

            if (string.IsNullOrEmpty(this._Sublease_City))
                db.AddInParameter(dbCommand, "Sublease_City", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_City", DbType.String, this._Sublease_City);

            if (string.IsNullOrEmpty(this._Sublease_State))
                db.AddInParameter(dbCommand, "Sublease_State", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_State", DbType.String, this._Sublease_State);

            if (string.IsNullOrEmpty(this._Sublease_Zip))
                db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Zip", DbType.String, this._Sublease_Zip);

            if (string.IsNullOrEmpty(this._Sublease_FirstName))
                db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_FirstName", DbType.String, this._Sublease_FirstName);

            if (string.IsNullOrEmpty(this._Sublease_LastName))
                db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_LastName", DbType.String, this._Sublease_LastName);

            if (string.IsNullOrEmpty(this._Sublease_Title))
                db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Title", DbType.String, this._Sublease_Title);

            if (string.IsNullOrEmpty(this._Sublease_Phone))
                db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Phone", DbType.String, this._Sublease_Phone);

            if (string.IsNullOrEmpty(this._Sublease_Fax))
                db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Fax", DbType.String, this._Sublease_Fax);

            if (string.IsNullOrEmpty(this._Sublease_Email))
                db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Sublease_Email", DbType.String, this._Sublease_Email);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Building_Ownership table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(int pK_Building_Ownership_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_OwnershipDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Building_Ownership_ID", DbType.Int32, pK_Building_Ownership_ID);

            db.ExecuteNonQuery(dbCommand);
        }

        public static int SelectPKByBuildingID(int fK_Building_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Building_OwnershipSelectPKByBuildingID");

            db.AddInParameter(dbCommand, "FK_Building_ID", DbType.Int32, fK_Building_ID);
            db.AddOutParameter(dbCommand, "PK_Building_Ownership_ID", DbType.Int32, 1);

            db.ExecuteNonQuery(dbCommand);

            return Convert.ToInt32(dbCommand.Parameters["@PK_Building_Ownership_ID"].Value);
        }
        #endregion
    }
}

using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for PM_Equipment_Tank table.
	/// </summary>
	public sealed class clsPM_Equipment_Tank
	{

		#region Private variables used to hold the property values

		private decimal? _PK_PM_Equipment_Tank;
		private string _Description;
		private string _Ground_Location;
		private string _Identification;
		private string _Certificate_Number;
		private DateTime? _Installation_Date;
		private string _Installation_Firm;
		private DateTime? _Last_Maintenance_Date;
		private DateTime? _Last_Revision_Date;
		private string _Tank_In_Use;
		private DateTime? _Last_Inspection_Date;
		private DateTime? _Closure_Date;
		private DateTime? _Removal_Date;
		private DateTime? _Revised_Removal_Date;
		private DateTime? _Permit_Begin_Date;
		private DateTime? _Permit_End_Date;
		private string _Registration_Required;
		private string _Registration_Number;
		private string _Leak_Detection_Required;
		private string _Leak_Detection_Type;
		private string _Overfill_Protection;
		private string _Secondary_Containment_Adequate;
		private decimal? _FK_LU_Secondary_Containment_Type;
		private string _Description_Other_Reporting_Requirements;
		private DateTime? _Plan_Date;
		private string _Plan_Identification;
		private string _Recommendations;
		private DateTime? _Effective_Date;
		private DateTime? _Expiration_Date;
		private string _Recordkeeping_Requirements;
		private string _Release_Control_Countermeasures_Plan;
        private string _SPCC_Required;
        private DateTime? _SPCCDate_Developed;
        private DateTime? _SPCCExpiration_Date;
		private string _Maintenance_Vendor;
		private string _Vendor_Contact_Name;
		private string _Vendor_Contact_Telephone;
		private string _Insurer;
		private DateTime? _Coverage_Start_Date;
		private DateTime? _Coverage_End_Date;
		private decimal? _Multiple_Event_Total_Coverage;
		private decimal? _Single_Event_Coverage;
		private string _Inspection_Company;
		private string _Inspection_Company_Contact_Name;
		private string _Inspection_Company_Contact_Telephone;
		private string _Notes;
		private decimal? _FK_Tank_Contents;
		private string _Contents_Other;
		private decimal? _Capcity;
		private decimal? _FK_Tank_Material;
		private string _Material_Other;
		private decimal? _FK_Tank_Construction;
		private string _Construction_Other;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _PK_PM_Equipment;
        private string _Manufacturer;
        private string _UL_Certified;
        private string _Secure_Non_Business;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_PM_Equipment_Tank value.
		/// </summary>
		public decimal? PK_PM_Equipment_Tank
		{
			get { return _PK_PM_Equipment_Tank; }
			set { _PK_PM_Equipment_Tank = value; }
		}

		/// <summary>
		/// Gets or sets the Description value.
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string UL_Certified
        {
            get { return _UL_Certified; }
            set { _UL_Certified = value; }
        }

        /// <summary>
        /// Gets or sets the Description value.
        /// </summary>
        public string Secure_Non_Business
        {
            get { return _Secure_Non_Business; }
            set { _Secure_Non_Business = value; }
        }

		/// <summary>
		/// Gets or sets the Ground_Location value.
		/// </summary>
		public string Ground_Location
		{
			get { return _Ground_Location; }
			set { _Ground_Location = value; }
		}

		/// <summary>
		/// Gets or sets the Identification value.
		/// </summary>
		public string Identification
		{
			get { return _Identification; }
			set { _Identification = value; }
		}

		/// <summary>
		/// Gets or sets the Certificate_Number value.
		/// </summary>
		public string Certificate_Number
		{
			get { return _Certificate_Number; }
			set { _Certificate_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Installation_Date value.
		/// </summary>
		public DateTime? Installation_Date
		{
			get { return _Installation_Date; }
			set { _Installation_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Installation_Firm value.
		/// </summary>
		public string Installation_Firm
		{
			get { return _Installation_Firm; }
			set { _Installation_Firm = value; }
		}

		/// <summary>
		/// Gets or sets the Last_Maintenance_Date value.
		/// </summary>
		public DateTime? Last_Maintenance_Date
		{
			get { return _Last_Maintenance_Date; }
			set { _Last_Maintenance_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Last_Revision_Date value.
		/// </summary>
		public DateTime? Last_Revision_Date
		{
			get { return _Last_Revision_Date; }
			set { _Last_Revision_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Tank_In_Use value.
		/// </summary>
		public string Tank_In_Use
		{
			get { return _Tank_In_Use; }
			set { _Tank_In_Use = value; }
		}

		/// <summary>
		/// Gets or sets the Last_Inspection_Date value.
		/// </summary>
		public DateTime? Last_Inspection_Date
		{
			get { return _Last_Inspection_Date; }
			set { _Last_Inspection_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Closure_Date value.
		/// </summary>
		public DateTime? Closure_Date
		{
			get { return _Closure_Date; }
			set { _Closure_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Removal_Date value.
		/// </summary>
		public DateTime? Removal_Date
		{
			get { return _Removal_Date; }
			set { _Removal_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Revised_Removal_Date value.
		/// </summary>
		public DateTime? Revised_Removal_Date
		{
			get { return _Revised_Removal_Date; }
			set { _Revised_Removal_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Permit_Begin_Date value.
		/// </summary>
		public DateTime? Permit_Begin_Date
		{
			get { return _Permit_Begin_Date; }
			set { _Permit_Begin_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Permit_End_Date value.
		/// </summary>
		public DateTime? Permit_End_Date
		{
			get { return _Permit_End_Date; }
			set { _Permit_End_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Registration_Required value.
		/// </summary>
		public string Registration_Required
		{
			get { return _Registration_Required; }
			set { _Registration_Required = value; }
		}

		/// <summary>
		/// Gets or sets the Registration_Number value.
		/// </summary>
		public string Registration_Number
		{
			get { return _Registration_Number; }
			set { _Registration_Number = value; }
		}

		/// <summary>
		/// Gets or sets the Leak_Detection_Required value.
		/// </summary>
		public string Leak_Detection_Required
		{
			get { return _Leak_Detection_Required; }
			set { _Leak_Detection_Required = value; }
		}

		/// <summary>
		/// Gets or sets the Leak_Detection_Type value.
		/// </summary>
		public string Leak_Detection_Type
		{
			get { return _Leak_Detection_Type; }
			set { _Leak_Detection_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Overfill_Protection value.
		/// </summary>
		public string Overfill_Protection
		{
			get { return _Overfill_Protection; }
			set { _Overfill_Protection = value; }
		}

		/// <summary>
		/// Gets or sets the Secondary_Containment_Adequate value.
		/// </summary>
		public string Secondary_Containment_Adequate
		{
			get { return _Secondary_Containment_Adequate; }
			set { _Secondary_Containment_Adequate = value; }
		}

		/// <summary>
		/// Gets or sets the FK_LU_Secondary_Containment_Type value.
		/// </summary>
		public decimal? FK_LU_Secondary_Containment_Type
		{
			get { return _FK_LU_Secondary_Containment_Type; }
			set { _FK_LU_Secondary_Containment_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Description_Other_Reporting_Requirements value.
		/// </summary>
		public string Description_Other_Reporting_Requirements
		{
			get { return _Description_Other_Reporting_Requirements; }
			set { _Description_Other_Reporting_Requirements = value; }
		}

		/// <summary>
		/// Gets or sets the Plan_Date value.
		/// </summary>
		public DateTime? Plan_Date
		{
			get { return _Plan_Date; }
			set { _Plan_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Plan_Identification value.
		/// </summary>
		public string Plan_Identification
		{
			get { return _Plan_Identification; }
			set { _Plan_Identification = value; }
		}

		/// <summary>
		/// Gets or sets the Recommendations value.
		/// </summary>
		public string Recommendations
		{
			get { return _Recommendations; }
			set { _Recommendations = value; }
		}

		/// <summary>
		/// Gets or sets the Effective_Date value.
		/// </summary>
		public DateTime? Effective_Date
		{
			get { return _Effective_Date; }
			set { _Effective_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Expiration_Date value.
		/// </summary>
		public DateTime? Expiration_Date
		{
			get { return _Expiration_Date; }
			set { _Expiration_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Recordkeeping_Requirements value.
		/// </summary>
		public string Recordkeeping_Requirements
		{
			get { return _Recordkeeping_Requirements; }
			set { _Recordkeeping_Requirements = value; }
		}

		/// <summary>
		/// Gets or sets the Release_Control_Countermeasures_Plan value.
		/// </summary>
		public string Release_Control_Countermeasures_Plan
		{
			get { return _Release_Control_Countermeasures_Plan; }
			set { _Release_Control_Countermeasures_Plan = value; }
		}

        /// <summary>
        /// Gets or sets the SPCC_Required value.
        /// </summary>

        public string SPCC_Required 
        { 
            get { return _SPCC_Required; }
            set { _SPCC_Required = value; }
        }

        /// <summary>
        /// Gets or sets the SPCCDate_Developed value.
        /// </summary>

        public DateTime? SPCCDate_Developed
        {
            get { return _SPCCDate_Developed; }
            set { _SPCCDate_Developed = value; }
        }

        /// <summary>
        /// Gets or sets the SPCCExpiration_Date value.
        /// </summary>

        public DateTime? SPCCExpiration_Date
        {
            get { return _SPCCExpiration_Date; }
            set { _SPCCExpiration_Date = value; }
        }
        
		/// <summary>
		/// Gets or sets the Maintenance_Vendor value.
		/// </summary>
		public string Maintenance_Vendor
		{
			get { return _Maintenance_Vendor; }
			set { _Maintenance_Vendor = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Contact_Name value.
		/// </summary>
		public string Vendor_Contact_Name
		{
			get { return _Vendor_Contact_Name; }
			set { _Vendor_Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Vendor_Contact_Telephone value.
		/// </summary>
		public string Vendor_Contact_Telephone
		{
			get { return _Vendor_Contact_Telephone; }
			set { _Vendor_Contact_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Insurer value.
		/// </summary>
		public string Insurer
		{
			get { return _Insurer; }
			set { _Insurer = value; }
		}

		/// <summary>
		/// Gets or sets the Coverage_Start_Date value.
		/// </summary>
		public DateTime? Coverage_Start_Date
		{
			get { return _Coverage_Start_Date; }
			set { _Coverage_Start_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Coverage_End_Date value.
		/// </summary>
		public DateTime? Coverage_End_Date
		{
			get { return _Coverage_End_Date; }
			set { _Coverage_End_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Multiple_Event_Total_Coverage value.
		/// </summary>
		public decimal? Multiple_Event_Total_Coverage
		{
			get { return _Multiple_Event_Total_Coverage; }
			set { _Multiple_Event_Total_Coverage = value; }
		}

		/// <summary>
		/// Gets or sets the Single_Event_Coverage value.
		/// </summary>
		public decimal? Single_Event_Coverage
		{
			get { return _Single_Event_Coverage; }
			set { _Single_Event_Coverage = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Company value.
		/// </summary>
		public string Inspection_Company
		{
			get { return _Inspection_Company; }
			set { _Inspection_Company = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Company_Contact_Name value.
		/// </summary>
		public string Inspection_Company_Contact_Name
		{
			get { return _Inspection_Company_Contact_Name; }
			set { _Inspection_Company_Contact_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Inspection_Company_Contact_Telephone value.
		/// </summary>
		public string Inspection_Company_Contact_Telephone
		{
			get { return _Inspection_Company_Contact_Telephone; }
			set { _Inspection_Company_Contact_Telephone = value; }
		}

		/// <summary>
		/// Gets or sets the Notes value.
		/// </summary>
		public string Notes
		{
			get { return _Notes; }
			set { _Notes = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Tank_Contents value.
		/// </summary>
		public decimal? FK_Tank_Contents
		{
			get { return _FK_Tank_Contents; }
			set { _FK_Tank_Contents = value; }
		}

		/// <summary>
		/// Gets or sets the Contents_Other value.
		/// </summary>
		public string Contents_Other
		{
			get { return _Contents_Other; }
			set { _Contents_Other = value; }
		}

		/// <summary>
		/// Gets or sets the Capcity value.
		/// </summary>
		public decimal? Capcity
		{
			get { return _Capcity; }
			set { _Capcity = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Tank_Material value.
		/// </summary>
		public decimal? FK_Tank_Material
		{
			get { return _FK_Tank_Material; }
			set { _FK_Tank_Material = value; }
		}

		/// <summary>
		/// Gets or sets the Material_Other value.
		/// </summary>
		public string Material_Other
		{
			get { return _Material_Other; }
			set { _Material_Other = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Tank_Construction value.
		/// </summary>
		public decimal? FK_Tank_Construction
		{
			get { return _FK_Tank_Construction; }
			set { _FK_Tank_Construction = value; }
		}

		/// <summary>
		/// Gets or sets the Construction_Other value.
		/// </summary>
		public string Construction_Other
		{
			get { return _Construction_Other; }
			set { _Construction_Other = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Update_Date value.
		/// </summary>
		public DateTime? Update_Date
		{
			get { return _Update_Date; }
			set { _Update_Date = value; }
		}
        /// <summary>
        /// Gets or sets the PM_Equipment value.
        /// </summary>
        public decimal? PK_PM_Equipment
        {
            get { return _PK_PM_Equipment; }
            set { _PK_PM_Equipment = value; }
        }

        public string Manufacturer
        {
            get { return _Manufacturer; }
            set { _Manufacturer = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Tank class with default value.
		/// </summary>
		public clsPM_Equipment_Tank() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Tank class based on Primary Key.
		/// </summary>
		public clsPM_Equipment_Tank(decimal pK_PM_Equipment_Tank) 
		{
			DataTable dtPM_Equipment_Tank = SelectByPK(pK_PM_Equipment_Tank).Tables[0];

			if (dtPM_Equipment_Tank.Rows.Count == 1)
			{
				 SetValue(dtPM_Equipment_Tank.Rows[0]);
			}
		}
        
		/// <summary>
		/// Initializes a new instance of the clsPM_Equipment_Tank class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drPM_Equipment_Tank) 
		{
				if (drPM_Equipment_Tank["PK_PM_Equipment_Tank"] == DBNull.Value)
					this._PK_PM_Equipment_Tank = null;
				else
					this._PK_PM_Equipment_Tank = (decimal?)drPM_Equipment_Tank["PK_PM_Equipment_Tank"];

				if (drPM_Equipment_Tank["Description"] == DBNull.Value)
					this._Description = null;
				else
					this._Description = (string)drPM_Equipment_Tank["Description"];

				if (drPM_Equipment_Tank["Ground_Location"] == DBNull.Value)
					this._Ground_Location = null;
				else
					this._Ground_Location = (string)drPM_Equipment_Tank["Ground_Location"];

				if (drPM_Equipment_Tank["Identification"] == DBNull.Value)
					this._Identification = null;
				else
					this._Identification = (string)drPM_Equipment_Tank["Identification"];

				if (drPM_Equipment_Tank["Certificate_Number"] == DBNull.Value)
					this._Certificate_Number = null;
				else
					this._Certificate_Number = (string)drPM_Equipment_Tank["Certificate_Number"];

				if (drPM_Equipment_Tank["Installation_Date"] == DBNull.Value)
					this._Installation_Date = null;
				else
					this._Installation_Date = (DateTime?)drPM_Equipment_Tank["Installation_Date"];

				if (drPM_Equipment_Tank["Installation_Firm"] == DBNull.Value)
					this._Installation_Firm = null;
				else
					this._Installation_Firm = (string)drPM_Equipment_Tank["Installation_Firm"];

				if (drPM_Equipment_Tank["Last_Maintenance_Date"] == DBNull.Value)
					this._Last_Maintenance_Date = null;
				else
					this._Last_Maintenance_Date = (DateTime?)drPM_Equipment_Tank["Last_Maintenance_Date"];

				if (drPM_Equipment_Tank["Last_Revision_Date"] == DBNull.Value)
					this._Last_Revision_Date = null;
				else
					this._Last_Revision_Date = (DateTime?)drPM_Equipment_Tank["Last_Revision_Date"];

				if (drPM_Equipment_Tank["Tank_In_Use"] == DBNull.Value)
					this._Tank_In_Use = null;
				else
					this._Tank_In_Use = (string)drPM_Equipment_Tank["Tank_In_Use"];

				if (drPM_Equipment_Tank["Last_Inspection_Date"] == DBNull.Value)
					this._Last_Inspection_Date = null;
				else
					this._Last_Inspection_Date = (DateTime?)drPM_Equipment_Tank["Last_Inspection_Date"];

				if (drPM_Equipment_Tank["Closure_Date"] == DBNull.Value)
					this._Closure_Date = null;
				else
					this._Closure_Date = (DateTime?)drPM_Equipment_Tank["Closure_Date"];

				if (drPM_Equipment_Tank["Removal_Date"] == DBNull.Value)
					this._Removal_Date = null;
				else
					this._Removal_Date = (DateTime?)drPM_Equipment_Tank["Removal_Date"];

				if (drPM_Equipment_Tank["Revised_Removal_Date"] == DBNull.Value)
					this._Revised_Removal_Date = null;
				else
					this._Revised_Removal_Date = (DateTime?)drPM_Equipment_Tank["Revised_Removal_Date"];

				if (drPM_Equipment_Tank["Permit_Begin_Date"] == DBNull.Value)
					this._Permit_Begin_Date = null;
				else
					this._Permit_Begin_Date = (DateTime?)drPM_Equipment_Tank["Permit_Begin_Date"];

				if (drPM_Equipment_Tank["Permit_End_Date"] == DBNull.Value)
					this._Permit_End_Date = null;
				else
					this._Permit_End_Date = (DateTime?)drPM_Equipment_Tank["Permit_End_Date"];

				if (drPM_Equipment_Tank["Registration_Required"] == DBNull.Value)
					this._Registration_Required = null;
				else
					this._Registration_Required = (string)drPM_Equipment_Tank["Registration_Required"];

				if (drPM_Equipment_Tank["Registration_Number"] == DBNull.Value)
					this._Registration_Number = null;
				else
					this._Registration_Number = (string)drPM_Equipment_Tank["Registration_Number"];

				if (drPM_Equipment_Tank["Leak_Detection_Required"] == DBNull.Value)
					this._Leak_Detection_Required = null;
				else
					this._Leak_Detection_Required = (string)drPM_Equipment_Tank["Leak_Detection_Required"];

				if (drPM_Equipment_Tank["Leak_Detection_Type"] == DBNull.Value)
					this._Leak_Detection_Type = null;
				else
					this._Leak_Detection_Type = (string)drPM_Equipment_Tank["Leak_Detection_Type"];

				if (drPM_Equipment_Tank["Overfill_Protection"] == DBNull.Value)
					this._Overfill_Protection = null;
				else
					this._Overfill_Protection = (string)drPM_Equipment_Tank["Overfill_Protection"];

				if (drPM_Equipment_Tank["Secondary_Containment_Adequate"] == DBNull.Value)
					this._Secondary_Containment_Adequate = null;
				else
					this._Secondary_Containment_Adequate = (string)drPM_Equipment_Tank["Secondary_Containment_Adequate"];

				if (drPM_Equipment_Tank["FK_LU_Secondary_Containment_Type"] == DBNull.Value)
					this._FK_LU_Secondary_Containment_Type = null;
				else
					this._FK_LU_Secondary_Containment_Type = (decimal?)drPM_Equipment_Tank["FK_LU_Secondary_Containment_Type"];

				if (drPM_Equipment_Tank["Description_Other_Reporting_Requirements"] == DBNull.Value)
					this._Description_Other_Reporting_Requirements = null;
				else
					this._Description_Other_Reporting_Requirements = (string)drPM_Equipment_Tank["Description_Other_Reporting_Requirements"];

				if (drPM_Equipment_Tank["Plan_Date"] == DBNull.Value)
					this._Plan_Date = null;
				else
					this._Plan_Date = (DateTime?)drPM_Equipment_Tank["Plan_Date"];

				if (drPM_Equipment_Tank["Plan_Identification"] == DBNull.Value)
					this._Plan_Identification = null;
				else
					this._Plan_Identification = (string)drPM_Equipment_Tank["Plan_Identification"];

				if (drPM_Equipment_Tank["Recommendations"] == DBNull.Value)
					this._Recommendations = null;
				else
					this._Recommendations = (string)drPM_Equipment_Tank["Recommendations"];

				if (drPM_Equipment_Tank["Effective_Date"] == DBNull.Value)
					this._Effective_Date = null;
				else
					this._Effective_Date = (DateTime?)drPM_Equipment_Tank["Effective_Date"];

				if (drPM_Equipment_Tank["Expiration_Date"] == DBNull.Value)
					this._Expiration_Date = null;
				else
					this._Expiration_Date = (DateTime?)drPM_Equipment_Tank["Expiration_Date"];

				if (drPM_Equipment_Tank["Recordkeeping_Requirements"] == DBNull.Value)
					this._Recordkeeping_Requirements = null;
				else
					this._Recordkeeping_Requirements = (string)drPM_Equipment_Tank["Recordkeeping_Requirements"];

				if (drPM_Equipment_Tank["Release_Control_Countermeasures_Plan"] == DBNull.Value)
					this._Release_Control_Countermeasures_Plan = null;
				else
					this._Release_Control_Countermeasures_Plan = (string)drPM_Equipment_Tank["Release_Control_Countermeasures_Plan"];

                if (drPM_Equipment_Tank["SPCC_Required"] == DBNull.Value)
                    this._SPCC_Required = null;
                else
                    this._SPCC_Required = (string)drPM_Equipment_Tank["SPCC_Required"];

                if (drPM_Equipment_Tank["SPCC_Date_Developed"] == DBNull.Value)
                    this._SPCCDate_Developed = null;
                else
                    this._SPCCDate_Developed = (DateTime?)drPM_Equipment_Tank["SPCC_Date_Developed"];

                if (drPM_Equipment_Tank["SPCC_Expiration_Date"] == DBNull.Value)
                    this._SPCCExpiration_Date = null;
                else
                    this._SPCCExpiration_Date = (DateTime?)drPM_Equipment_Tank["SPCC_Expiration_Date"];

				if (drPM_Equipment_Tank["Maintenance_Vendor"] == DBNull.Value)
					this._Maintenance_Vendor = null;
				else
					this._Maintenance_Vendor = (string)drPM_Equipment_Tank["Maintenance_Vendor"];

				if (drPM_Equipment_Tank["Vendor_Contact_Name"] == DBNull.Value)
					this._Vendor_Contact_Name = null;
				else
					this._Vendor_Contact_Name = (string)drPM_Equipment_Tank["Vendor_Contact_Name"];

				if (drPM_Equipment_Tank["Vendor_Contact_Telephone"] == DBNull.Value)
					this._Vendor_Contact_Telephone = null;
				else
					this._Vendor_Contact_Telephone = (string)drPM_Equipment_Tank["Vendor_Contact_Telephone"];

				if (drPM_Equipment_Tank["Insurer"] == DBNull.Value)
					this._Insurer = null;
				else
					this._Insurer = (string)drPM_Equipment_Tank["Insurer"];

				if (drPM_Equipment_Tank["Coverage_Start_Date"] == DBNull.Value)
					this._Coverage_Start_Date = null;
				else
					this._Coverage_Start_Date = (DateTime?)drPM_Equipment_Tank["Coverage_Start_Date"];

				if (drPM_Equipment_Tank["Coverage_End_Date"] == DBNull.Value)
					this._Coverage_End_Date = null;
				else
					this._Coverage_End_Date = (DateTime?)drPM_Equipment_Tank["Coverage_End_Date"];

				if (drPM_Equipment_Tank["Multiple_Event_Total_Coverage"] == DBNull.Value)
					this._Multiple_Event_Total_Coverage = null;
				else
					this._Multiple_Event_Total_Coverage = (decimal?)drPM_Equipment_Tank["Multiple_Event_Total_Coverage"];

				if (drPM_Equipment_Tank["Single_Event_Coverage"] == DBNull.Value)
					this._Single_Event_Coverage = null;
				else
					this._Single_Event_Coverage = (decimal?)drPM_Equipment_Tank["Single_Event_Coverage"];

				if (drPM_Equipment_Tank["Inspection_Company"] == DBNull.Value)
					this._Inspection_Company = null;
				else
					this._Inspection_Company = (string)drPM_Equipment_Tank["Inspection_Company"];

				if (drPM_Equipment_Tank["Inspection_Company_Contact_Name"] == DBNull.Value)
					this._Inspection_Company_Contact_Name = null;
				else
					this._Inspection_Company_Contact_Name = (string)drPM_Equipment_Tank["Inspection_Company_Contact_Name"];

				if (drPM_Equipment_Tank["Inspection_Company_Contact_Telephone"] == DBNull.Value)
					this._Inspection_Company_Contact_Telephone = null;
				else
					this._Inspection_Company_Contact_Telephone = (string)drPM_Equipment_Tank["Inspection_Company_Contact_Telephone"];

				if (drPM_Equipment_Tank["Notes"] == DBNull.Value)
					this._Notes = null;
				else
					this._Notes = (string)drPM_Equipment_Tank["Notes"];

				if (drPM_Equipment_Tank["FK_Tank_Contents"] == DBNull.Value)
					this._FK_Tank_Contents = null;
				else
					this._FK_Tank_Contents = (decimal?)drPM_Equipment_Tank["FK_Tank_Contents"];

				if (drPM_Equipment_Tank["Contents_Other"] == DBNull.Value)
					this._Contents_Other = null;
				else
					this._Contents_Other = (string)drPM_Equipment_Tank["Contents_Other"];

				if (drPM_Equipment_Tank["Capcity"] == DBNull.Value)
					this._Capcity = null;
				else
					this._Capcity = (decimal?)drPM_Equipment_Tank["Capcity"];

				if (drPM_Equipment_Tank["FK_Tank_Material"] == DBNull.Value)
					this._FK_Tank_Material = null;
				else
					this._FK_Tank_Material = (decimal?)drPM_Equipment_Tank["FK_Tank_Material"];

				if (drPM_Equipment_Tank["Material_Other"] == DBNull.Value)
					this._Material_Other = null;
				else
					this._Material_Other = (string)drPM_Equipment_Tank["Material_Other"];

				if (drPM_Equipment_Tank["FK_Tank_Construction"] == DBNull.Value)
					this._FK_Tank_Construction = null;
				else
					this._FK_Tank_Construction = (decimal?)drPM_Equipment_Tank["FK_Tank_Construction"];

				if (drPM_Equipment_Tank["Construction_Other"] == DBNull.Value)
					this._Construction_Other = null;
				else
					this._Construction_Other = (string)drPM_Equipment_Tank["Construction_Other"];

				if (drPM_Equipment_Tank["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drPM_Equipment_Tank["Updated_By"];

				if (drPM_Equipment_Tank["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drPM_Equipment_Tank["Update_Date"];

                if (drPM_Equipment_Tank["PK_PM_Equipment"] == DBNull.Value)
                    this._PK_PM_Equipment = null;
                else
                    this._PK_PM_Equipment = (decimal?)drPM_Equipment_Tank["PK_PM_Equipment"];

                if (drPM_Equipment_Tank["Manufacturer"] == DBNull.Value)
                    this._Manufacturer = null;
                else
                    this._Manufacturer = (string)drPM_Equipment_Tank["Manufacturer"];

                if (drPM_Equipment_Tank["UL_Certified"] == DBNull.Value)
                    this._UL_Certified = null;
                else
                    this._UL_Certified = (string)drPM_Equipment_Tank["UL_Certified"];

                if (drPM_Equipment_Tank["Secure_Non_Business"] == DBNull.Value)
                    this._Secure_Non_Business = null;
                else
                    this._Secure_Non_Business = (string)drPM_Equipment_Tank["Secure_Non_Business"];
		}

		#endregion

		/// <summary>
		/// Inserts a record into the PM_Equipment_Tank table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_TankInsert");

			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Ground_Location))
				db.AddInParameter(dbCommand, "Ground_Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Ground_Location", DbType.String, this._Ground_Location);
			
			if (string.IsNullOrEmpty(this._Identification))
				db.AddInParameter(dbCommand, "Identification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Identification", DbType.String, this._Identification);
			
			if (string.IsNullOrEmpty(this._Certificate_Number))
				db.AddInParameter(dbCommand, "Certificate_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Certificate_Number", DbType.String, this._Certificate_Number);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Installation_Firm))
				db.AddInParameter(dbCommand, "Installation_Firm", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Installation_Firm", DbType.String, this._Installation_Firm);
			
			db.AddInParameter(dbCommand, "Last_Maintenance_Date", DbType.DateTime, this._Last_Maintenance_Date);
			
			db.AddInParameter(dbCommand, "Last_Revision_Date", DbType.DateTime, this._Last_Revision_Date);
			
			if (string.IsNullOrEmpty(this._Tank_In_Use))
				db.AddInParameter(dbCommand, "Tank_In_Use", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tank_In_Use", DbType.String, this._Tank_In_Use);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Closure_Date", DbType.DateTime, this._Closure_Date);
			
			db.AddInParameter(dbCommand, "Removal_Date", DbType.DateTime, this._Removal_Date);
			
			db.AddInParameter(dbCommand, "Revised_Removal_Date", DbType.DateTime, this._Revised_Removal_Date);
			
			db.AddInParameter(dbCommand, "Permit_Begin_Date", DbType.DateTime, this._Permit_Begin_Date);
			
			db.AddInParameter(dbCommand, "Permit_End_Date", DbType.DateTime, this._Permit_End_Date);
			
			if (string.IsNullOrEmpty(this._Registration_Required))
				db.AddInParameter(dbCommand, "Registration_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Registration_Required", DbType.String, this._Registration_Required);
			
			if (string.IsNullOrEmpty(this._Registration_Number))
				db.AddInParameter(dbCommand, "Registration_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Registration_Number", DbType.String, this._Registration_Number);
			
			if (string.IsNullOrEmpty(this._Leak_Detection_Required))
				db.AddInParameter(dbCommand, "Leak_Detection_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Leak_Detection_Required", DbType.String, this._Leak_Detection_Required);
			
			if (string.IsNullOrEmpty(this._Leak_Detection_Type))
				db.AddInParameter(dbCommand, "Leak_Detection_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Leak_Detection_Type", DbType.String, this._Leak_Detection_Type);
			
			if (string.IsNullOrEmpty(this._Overfill_Protection))
				db.AddInParameter(dbCommand, "Overfill_Protection", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Overfill_Protection", DbType.String, this._Overfill_Protection);
			
			if (string.IsNullOrEmpty(this._Secondary_Containment_Adequate))
				db.AddInParameter(dbCommand, "Secondary_Containment_Adequate", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Secondary_Containment_Adequate", DbType.String, this._Secondary_Containment_Adequate);
			
			db.AddInParameter(dbCommand, "FK_LU_Secondary_Containment_Type", DbType.Decimal, this._FK_LU_Secondary_Containment_Type);
			
			if (string.IsNullOrEmpty(this._Description_Other_Reporting_Requirements))
				db.AddInParameter(dbCommand, "Description_Other_Reporting_Requirements", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description_Other_Reporting_Requirements", DbType.String, this._Description_Other_Reporting_Requirements);
			
			db.AddInParameter(dbCommand, "Plan_Date", DbType.DateTime, this._Plan_Date);
			
			if (string.IsNullOrEmpty(this._Plan_Identification))
				db.AddInParameter(dbCommand, "Plan_Identification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Plan_Identification", DbType.String, this._Plan_Identification);
			
			if (string.IsNullOrEmpty(this._Recommendations))
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, this._Recommendations);
			
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, this._Effective_Date);
			
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, this._Expiration_Date);
			
			if (string.IsNullOrEmpty(this._Recordkeeping_Requirements))
				db.AddInParameter(dbCommand, "Recordkeeping_Requirements", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recordkeeping_Requirements", DbType.String, this._Recordkeeping_Requirements);
			
			if (string.IsNullOrEmpty(this._Release_Control_Countermeasures_Plan))
				db.AddInParameter(dbCommand, "Release_Control_Countermeasures_Plan", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Release_Control_Countermeasures_Plan", DbType.String, this._Release_Control_Countermeasures_Plan);

            db.AddInParameter(dbCommand, "SPCC_Date_Developed", DbType.DateTime, this._SPCCDate_Developed);

            db.AddInParameter(dbCommand, "SPCC_Expiration_Date", DbType.DateTime, this._SPCCExpiration_Date);

            if (string.IsNullOrEmpty(this._SPCC_Required))
                db.AddInParameter(dbCommand, "SPCC_Required", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SPCC_Required", DbType.String, this._SPCC_Required);

			if (string.IsNullOrEmpty(this._Maintenance_Vendor))
				db.AddInParameter(dbCommand, "Maintenance_Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Maintenance_Vendor", DbType.String, this._Maintenance_Vendor);
			
			if (string.IsNullOrEmpty(this._Vendor_Contact_Name))
				db.AddInParameter(dbCommand, "Vendor_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Contact_Name", DbType.String, this._Vendor_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Vendor_Contact_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Contact_Telephone", DbType.String, this._Vendor_Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Insurer))
				db.AddInParameter(dbCommand, "Insurer", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Insurer", DbType.String, this._Insurer);
			
			db.AddInParameter(dbCommand, "Coverage_Start_Date", DbType.DateTime, this._Coverage_Start_Date);
			
			db.AddInParameter(dbCommand, "Coverage_End_Date", DbType.DateTime, this._Coverage_End_Date);
			
			db.AddInParameter(dbCommand, "Multiple_Event_Total_Coverage", DbType.Decimal, this._Multiple_Event_Total_Coverage);
			
			db.AddInParameter(dbCommand, "Single_Event_Coverage", DbType.Decimal, this._Single_Event_Coverage);
			
			if (string.IsNullOrEmpty(this._Inspection_Company))
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, this._Inspection_Company);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Name))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, this._Inspection_Company_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Telephone))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, this._Inspection_Company_Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			db.AddInParameter(dbCommand, "FK_Tank_Contents", DbType.Decimal, this._FK_Tank_Contents);
			
			if (string.IsNullOrEmpty(this._Contents_Other))
				db.AddInParameter(dbCommand, "Contents_Other", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contents_Other", DbType.String, this._Contents_Other);
			
			db.AddInParameter(dbCommand, "Capcity", DbType.Decimal, this._Capcity);
			
			db.AddInParameter(dbCommand, "FK_Tank_Material", DbType.Decimal, this._FK_Tank_Material);
			
			if (string.IsNullOrEmpty(this._Material_Other))
				db.AddInParameter(dbCommand, "Material_Other", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Material_Other", DbType.String, this._Material_Other);
			
			db.AddInParameter(dbCommand, "FK_Tank_Construction", DbType.Decimal, this._FK_Tank_Construction);
			
			if (string.IsNullOrEmpty(this._Construction_Other))
				db.AddInParameter(dbCommand, "Construction_Other", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Construction_Other", DbType.String, this._Construction_Other);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            if (string.IsNullOrEmpty(this._Manufacturer))
                db.AddInParameter(dbCommand, "Manufacturer", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Manufacturer", DbType.String, this._Manufacturer);

            if (string.IsNullOrEmpty(this._UL_Certified))
                db.AddInParameter(dbCommand, "UL_Certified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UL_Certified", DbType.String, this._UL_Certified);

            if (string.IsNullOrEmpty(this._Secure_Non_Business))
                db.AddInParameter(dbCommand, "Secure_Non_Business", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Secure_Non_Business", DbType.String, this._Secure_Non_Business);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the PM_Equipment_Tank table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_PM_Equipment_Tank)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_TankSelectByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_Tank", DbType.Decimal, pK_PM_Equipment_Tank);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the PM_Equipment_Tank table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_TankSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the PM_Equipment_Tank table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_TankUpdate");

			
			db.AddInParameter(dbCommand, "PK_PM_Equipment_Tank", DbType.Decimal, this._PK_PM_Equipment_Tank);
			
			if (string.IsNullOrEmpty(this._Description))
				db.AddInParameter(dbCommand, "Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description", DbType.String, this._Description);
			
			if (string.IsNullOrEmpty(this._Ground_Location))
				db.AddInParameter(dbCommand, "Ground_Location", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Ground_Location", DbType.String, this._Ground_Location);
			
			if (string.IsNullOrEmpty(this._Identification))
				db.AddInParameter(dbCommand, "Identification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Identification", DbType.String, this._Identification);
			
			if (string.IsNullOrEmpty(this._Certificate_Number))
				db.AddInParameter(dbCommand, "Certificate_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Certificate_Number", DbType.String, this._Certificate_Number);
			
			db.AddInParameter(dbCommand, "Installation_Date", DbType.DateTime, this._Installation_Date);
			
			if (string.IsNullOrEmpty(this._Installation_Firm))
				db.AddInParameter(dbCommand, "Installation_Firm", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Installation_Firm", DbType.String, this._Installation_Firm);
			
			db.AddInParameter(dbCommand, "Last_Maintenance_Date", DbType.DateTime, this._Last_Maintenance_Date);
			
			db.AddInParameter(dbCommand, "Last_Revision_Date", DbType.DateTime, this._Last_Revision_Date);
			
			if (string.IsNullOrEmpty(this._Tank_In_Use))
				db.AddInParameter(dbCommand, "Tank_In_Use", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Tank_In_Use", DbType.String, this._Tank_In_Use);
			
			db.AddInParameter(dbCommand, "Last_Inspection_Date", DbType.DateTime, this._Last_Inspection_Date);
			
			db.AddInParameter(dbCommand, "Closure_Date", DbType.DateTime, this._Closure_Date);
			
			db.AddInParameter(dbCommand, "Removal_Date", DbType.DateTime, this._Removal_Date);
			
			db.AddInParameter(dbCommand, "Revised_Removal_Date", DbType.DateTime, this._Revised_Removal_Date);
			
			db.AddInParameter(dbCommand, "Permit_Begin_Date", DbType.DateTime, this._Permit_Begin_Date);
			
			db.AddInParameter(dbCommand, "Permit_End_Date", DbType.DateTime, this._Permit_End_Date);
			
			if (string.IsNullOrEmpty(this._Registration_Required))
				db.AddInParameter(dbCommand, "Registration_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Registration_Required", DbType.String, this._Registration_Required);
			
			if (string.IsNullOrEmpty(this._Registration_Number))
				db.AddInParameter(dbCommand, "Registration_Number", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Registration_Number", DbType.String, this._Registration_Number);
			
			if (string.IsNullOrEmpty(this._Leak_Detection_Required))
				db.AddInParameter(dbCommand, "Leak_Detection_Required", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Leak_Detection_Required", DbType.String, this._Leak_Detection_Required);
			
			if (string.IsNullOrEmpty(this._Leak_Detection_Type))
				db.AddInParameter(dbCommand, "Leak_Detection_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Leak_Detection_Type", DbType.String, this._Leak_Detection_Type);
			
			if (string.IsNullOrEmpty(this._Overfill_Protection))
				db.AddInParameter(dbCommand, "Overfill_Protection", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Overfill_Protection", DbType.String, this._Overfill_Protection);
			
			if (string.IsNullOrEmpty(this._Secondary_Containment_Adequate))
				db.AddInParameter(dbCommand, "Secondary_Containment_Adequate", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Secondary_Containment_Adequate", DbType.String, this._Secondary_Containment_Adequate);
			
			db.AddInParameter(dbCommand, "FK_LU_Secondary_Containment_Type", DbType.Decimal, this._FK_LU_Secondary_Containment_Type);
			
			if (string.IsNullOrEmpty(this._Description_Other_Reporting_Requirements))
				db.AddInParameter(dbCommand, "Description_Other_Reporting_Requirements", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description_Other_Reporting_Requirements", DbType.String, this._Description_Other_Reporting_Requirements);
			
			db.AddInParameter(dbCommand, "Plan_Date", DbType.DateTime, this._Plan_Date);
			
			if (string.IsNullOrEmpty(this._Plan_Identification))
				db.AddInParameter(dbCommand, "Plan_Identification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Plan_Identification", DbType.String, this._Plan_Identification);
			
			if (string.IsNullOrEmpty(this._Recommendations))
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recommendations", DbType.String, this._Recommendations);
			
			db.AddInParameter(dbCommand, "Effective_Date", DbType.DateTime, this._Effective_Date);
			
			db.AddInParameter(dbCommand, "Expiration_Date", DbType.DateTime, this._Expiration_Date);
			
			if (string.IsNullOrEmpty(this._Recordkeeping_Requirements))
				db.AddInParameter(dbCommand, "Recordkeeping_Requirements", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Recordkeeping_Requirements", DbType.String, this._Recordkeeping_Requirements);
			
			if (string.IsNullOrEmpty(this._Release_Control_Countermeasures_Plan))
				db.AddInParameter(dbCommand, "Release_Control_Countermeasures_Plan", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Release_Control_Countermeasures_Plan", DbType.String, this._Release_Control_Countermeasures_Plan);

            db.AddInParameter(dbCommand, "SPCC_Date_Developed", DbType.DateTime, this._SPCCDate_Developed);

            db.AddInParameter(dbCommand, "SPCC_Expiration_Date", DbType.DateTime, this._SPCCExpiration_Date);

            if (string.IsNullOrEmpty(this._SPCC_Required))
                db.AddInParameter(dbCommand, "SPCC_Required", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "SPCC_Required", DbType.String, this._SPCC_Required);

			if (string.IsNullOrEmpty(this._Maintenance_Vendor))
				db.AddInParameter(dbCommand, "Maintenance_Vendor", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Maintenance_Vendor", DbType.String, this._Maintenance_Vendor);
			
			if (string.IsNullOrEmpty(this._Vendor_Contact_Name))
				db.AddInParameter(dbCommand, "Vendor_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Contact_Name", DbType.String, this._Vendor_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Vendor_Contact_Telephone))
				db.AddInParameter(dbCommand, "Vendor_Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vendor_Contact_Telephone", DbType.String, this._Vendor_Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Insurer))
				db.AddInParameter(dbCommand, "Insurer", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Insurer", DbType.String, this._Insurer);
			
			db.AddInParameter(dbCommand, "Coverage_Start_Date", DbType.DateTime, this._Coverage_Start_Date);
			
			db.AddInParameter(dbCommand, "Coverage_End_Date", DbType.DateTime, this._Coverage_End_Date);
			
			db.AddInParameter(dbCommand, "Multiple_Event_Total_Coverage", DbType.Decimal, this._Multiple_Event_Total_Coverage);
			
			db.AddInParameter(dbCommand, "Single_Event_Coverage", DbType.Decimal, this._Single_Event_Coverage);
			
			if (string.IsNullOrEmpty(this._Inspection_Company))
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company", DbType.String, this._Inspection_Company);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Name))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Name", DbType.String, this._Inspection_Company_Contact_Name);
			
			if (string.IsNullOrEmpty(this._Inspection_Company_Contact_Telephone))
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Inspection_Company_Contact_Telephone", DbType.String, this._Inspection_Company_Contact_Telephone);
			
			if (string.IsNullOrEmpty(this._Notes))
				db.AddInParameter(dbCommand, "Notes", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Notes", DbType.String, this._Notes);
			
			db.AddInParameter(dbCommand, "FK_Tank_Contents", DbType.Decimal, this._FK_Tank_Contents);
			
			if (string.IsNullOrEmpty(this._Contents_Other))
				db.AddInParameter(dbCommand, "Contents_Other", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Contents_Other", DbType.String, this._Contents_Other);
			
			db.AddInParameter(dbCommand, "Capcity", DbType.Decimal, this._Capcity);
			
			db.AddInParameter(dbCommand, "FK_Tank_Material", DbType.Decimal, this._FK_Tank_Material);
			
			if (string.IsNullOrEmpty(this._Material_Other))
				db.AddInParameter(dbCommand, "Material_Other", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Material_Other", DbType.String, this._Material_Other);
			
			db.AddInParameter(dbCommand, "FK_Tank_Construction", DbType.Decimal, this._FK_Tank_Construction);
			
			if (string.IsNullOrEmpty(this._Construction_Other))
				db.AddInParameter(dbCommand, "Construction_Other", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Construction_Other", DbType.String, this._Construction_Other);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
            if (string.IsNullOrEmpty(this._Manufacturer))
                db.AddInParameter(dbCommand, "Manufacturer", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Manufacturer", DbType.String, this._Manufacturer);

            if (string.IsNullOrEmpty(this._UL_Certified))
                db.AddInParameter(dbCommand, "UL_Certified", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "UL_Certified", DbType.String, this._UL_Certified);

            if (string.IsNullOrEmpty(this._Secure_Non_Business))
                db.AddInParameter(dbCommand, "Secure_Non_Business", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Secure_Non_Business", DbType.String, this._Secure_Non_Business);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the PM_Equipment_Tank table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_PM_Equipment_Tank)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_TankDeleteByPK");

			db.AddInParameter(dbCommand, "PK_PM_Equipment_Tank", DbType.Decimal, pK_PM_Equipment_Tank);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Equipment_Tank)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Equipment_Tank_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Equipment_Tank", DbType.Decimal, pK_PM_Equipment_Tank);

            return db.ExecuteDataSet(dbCommand);
        }
	}
}

using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table Property_Claims
	/// </summary>
	public sealed class Property_Claims
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Property_Claims_ID;
		private decimal? _FK_Property_FR_ID;
		private decimal? _Property_FR_Number;
		private decimal? _FK_Location_Code;
		private decimal? _FK_Contact;
		private DateTime? _Date_Reported_to_Sonic;
		private bool? _Fire;
		private bool? _Wind_Damage;
		private bool? _Hail_Damage;
		private bool? _Earth_Movement;
		private bool? _Flood;
		private bool? _Third_Party_Property_Damage;
		private bool? _Property_Damage_by_Sonic_Associate;
		private bool? _Environmental_Loss;
		private bool? _Vandalism_To_The_Property;
		private bool? _Theft_Associate_Tools;
		private bool? _Theft_All_Other;
		private bool? _Other;
		private DateTime? _Date_Of_Loss;
		private string _Time_Of_Loss;
		private string _Description_of_Loss;
		private decimal? _Damage_Building_Facilities_Est_Cost;
		private decimal? _Damage_Building_Facilities_Actual_Cost;
		private decimal? _Damage_Equipment_Est_Cost;
		private decimal? _Damage_Equipment_Actual_Cost;
		private decimal? _Damage_Product_Damage_Est_Cost;
		private decimal? _Damage_Product_Damage_Actual_Cost;
		private decimal? _Damage_Parts_Est_Cost;
		private decimal? _Damage_Parts_Actual_Cost;
		private decimal? _Damage_Salvage_Cleanup_Est_Cost;
		private decimal? _Damage_Salvage_Cleanup_Actual_Cost;
		private decimal? _Damage_Decontamination_Est_Cost;
		private decimal? _Damage_Decontamination_Actual_Cost;
		private decimal? _Damage_Electronic_Data_Est_Cost;
		private decimal? _Damage_Electronic_Data_Actual_Cost;
		private decimal? _Damage_Service_Interruption_Est_Cost;
		private decimal? _Damage_Service_Interruption_Actual_Cost;
		private decimal? _Damage_Payroll_Est_Cost;
		private decimal? _Damage_Payroll_Actual_Cost;
		private decimal? _Damage_Loss_of_Sales_Est_Cost;
		private decimal? _Damage_Loss_of_Sales_Actual_Cost;
		private DateTime? _Date_Cleanup_Complete;
		private DateTime? _Date_Repairs_Complete;
		private DateTime? _Date_Full_Service_Resumed;
		private DateTime? _Date_Fire_Protection_Services_Resumed;
		private string _Comments;
		private string _Date_Report_Complete;
		private string _Date_Claim_Closed;
		private bool? _Complete;
		private decimal? _Updated_By;
		private DateTime? _Updated_Date;
		private decimal? _FK_SLT_Incident_Review;
		private DateTime? _Created_Date;
		private bool? _Security_Video_Surveillance;
        private decimal _FK_First_Report_Wizard_ID;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Property_Claims_ID value.
		/// </summary>
		public decimal? PK_Property_Claims_ID
		{
			get { return _PK_Property_Claims_ID; }
			set { _PK_Property_Claims_ID = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Property_FR_ID value.
		/// </summary>
		public decimal? FK_Property_FR_ID
		{
			get { return _FK_Property_FR_ID; }
			set { _FK_Property_FR_ID = value; }
		}

		/// <summary>
		/// Gets or sets the Property_FR_Number value.
		/// </summary>
		public decimal? Property_FR_Number
		{
			get { return _Property_FR_Number; }
			set { _Property_FR_Number = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Location_Code value.
		/// </summary>
		public decimal? FK_Location_Code
		{
			get { return _FK_Location_Code; }
			set { _FK_Location_Code = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Contact value.
		/// </summary>
		public decimal? FK_Contact
		{
			get { return _FK_Contact; }
			set { _FK_Contact = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Reported_to_Sonic value.
		/// </summary>
		public DateTime? Date_Reported_to_Sonic
		{
			get { return _Date_Reported_to_Sonic; }
			set { _Date_Reported_to_Sonic = value; }
		}

		/// <summary>
		/// Gets or sets the Fire value.
		/// </summary>
		public bool? Fire
		{
			get { return _Fire; }
			set { _Fire = value; }
		}

		/// <summary>
		/// Gets or sets the Wind_Damage value.
		/// </summary>
		public bool? Wind_Damage
		{
			get { return _Wind_Damage; }
			set { _Wind_Damage = value; }
		}

		/// <summary>
		/// Gets or sets the Hail_Damage value.
		/// </summary>
		public bool? Hail_Damage
		{
			get { return _Hail_Damage; }
			set { _Hail_Damage = value; }
		}

		/// <summary>
		/// Gets or sets the Earth_Movement value.
		/// </summary>
		public bool? Earth_Movement
		{
			get { return _Earth_Movement; }
			set { _Earth_Movement = value; }
		}

		/// <summary>
		/// Gets or sets the Flood value.
		/// </summary>
		public bool? Flood
		{
			get { return _Flood; }
			set { _Flood = value; }
		}

		/// <summary>
		/// Gets or sets the Third_Party_Property_Damage value.
		/// </summary>
		public bool? Third_Party_Property_Damage
		{
			get { return _Third_Party_Property_Damage; }
			set { _Third_Party_Property_Damage = value; }
		}

		/// <summary>
		/// Gets or sets the Property_Damage_by_Sonic_Associate value.
		/// </summary>
		public bool? Property_Damage_by_Sonic_Associate
		{
			get { return _Property_Damage_by_Sonic_Associate; }
			set { _Property_Damage_by_Sonic_Associate = value; }
		}

		/// <summary>
		/// Gets or sets the Environmental_Loss value.
		/// </summary>
		public bool? Environmental_Loss
		{
			get { return _Environmental_Loss; }
			set { _Environmental_Loss = value; }
		}

		/// <summary>
		/// Gets or sets the Vandalism_To_The_Property value.
		/// </summary>
		public bool? Vandalism_To_The_Property
		{
			get { return _Vandalism_To_The_Property; }
			set { _Vandalism_To_The_Property = value; }
		}

		/// <summary>
		/// Gets or sets the Theft_Associate_Tools value.
		/// </summary>
		public bool? Theft_Associate_Tools
		{
			get { return _Theft_Associate_Tools; }
			set { _Theft_Associate_Tools = value; }
		}

		/// <summary>
		/// Gets or sets the Theft_All_Other value.
		/// </summary>
		public bool? Theft_All_Other
		{
			get { return _Theft_All_Other; }
			set { _Theft_All_Other = value; }
		}

		/// <summary>
		/// Gets or sets the Other value.
		/// </summary>
		public bool? Other
		{
			get { return _Other; }
			set { _Other = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Of_Loss value.
		/// </summary>
		public DateTime? Date_Of_Loss
		{
			get { return _Date_Of_Loss; }
			set { _Date_Of_Loss = value; }
		}

		/// <summary>
		/// Gets or sets the Time_Of_Loss value.
		/// </summary>
		public string Time_Of_Loss
		{
			get { return _Time_Of_Loss; }
			set { _Time_Of_Loss = value; }
		}

		/// <summary>
		/// Gets or sets the Description_of_Loss value.
		/// </summary>
		public string Description_of_Loss
		{
			get { return _Description_of_Loss; }
			set { _Description_of_Loss = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Building_Facilities_Est_Cost value.
		/// </summary>
		public decimal? Damage_Building_Facilities_Est_Cost
		{
			get { return _Damage_Building_Facilities_Est_Cost; }
			set { _Damage_Building_Facilities_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Building_Facilities_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Building_Facilities_Actual_Cost
		{
			get { return _Damage_Building_Facilities_Actual_Cost; }
			set { _Damage_Building_Facilities_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Equipment_Est_Cost value.
		/// </summary>
		public decimal? Damage_Equipment_Est_Cost
		{
			get { return _Damage_Equipment_Est_Cost; }
			set { _Damage_Equipment_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Equipment_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Equipment_Actual_Cost
		{
			get { return _Damage_Equipment_Actual_Cost; }
			set { _Damage_Equipment_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Product_Damage_Est_Cost value.
		/// </summary>
		public decimal? Damage_Product_Damage_Est_Cost
		{
			get { return _Damage_Product_Damage_Est_Cost; }
			set { _Damage_Product_Damage_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Product_Damage_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Product_Damage_Actual_Cost
		{
			get { return _Damage_Product_Damage_Actual_Cost; }
			set { _Damage_Product_Damage_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Parts_Est_Cost value.
		/// </summary>
		public decimal? Damage_Parts_Est_Cost
		{
			get { return _Damage_Parts_Est_Cost; }
			set { _Damage_Parts_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Parts_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Parts_Actual_Cost
		{
			get { return _Damage_Parts_Actual_Cost; }
			set { _Damage_Parts_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Salvage_Cleanup_Est_Cost value.
		/// </summary>
		public decimal? Damage_Salvage_Cleanup_Est_Cost
		{
			get { return _Damage_Salvage_Cleanup_Est_Cost; }
			set { _Damage_Salvage_Cleanup_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Salvage_Cleanup_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Salvage_Cleanup_Actual_Cost
		{
			get { return _Damage_Salvage_Cleanup_Actual_Cost; }
			set { _Damage_Salvage_Cleanup_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Decontamination_Est_Cost value.
		/// </summary>
		public decimal? Damage_Decontamination_Est_Cost
		{
			get { return _Damage_Decontamination_Est_Cost; }
			set { _Damage_Decontamination_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Decontamination_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Decontamination_Actual_Cost
		{
			get { return _Damage_Decontamination_Actual_Cost; }
			set { _Damage_Decontamination_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Electronic_Data_Est_Cost value.
		/// </summary>
		public decimal? Damage_Electronic_Data_Est_Cost
		{
			get { return _Damage_Electronic_Data_Est_Cost; }
			set { _Damage_Electronic_Data_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Electronic_Data_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Electronic_Data_Actual_Cost
		{
			get { return _Damage_Electronic_Data_Actual_Cost; }
			set { _Damage_Electronic_Data_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Service_Interruption_Est_Cost value.
		/// </summary>
		public decimal? Damage_Service_Interruption_Est_Cost
		{
			get { return _Damage_Service_Interruption_Est_Cost; }
			set { _Damage_Service_Interruption_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Service_Interruption_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Service_Interruption_Actual_Cost
		{
			get { return _Damage_Service_Interruption_Actual_Cost; }
			set { _Damage_Service_Interruption_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Payroll_Est_Cost value.
		/// </summary>
		public decimal? Damage_Payroll_Est_Cost
		{
			get { return _Damage_Payroll_Est_Cost; }
			set { _Damage_Payroll_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Payroll_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Payroll_Actual_Cost
		{
			get { return _Damage_Payroll_Actual_Cost; }
			set { _Damage_Payroll_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Loss_of_Sales_Est_Cost value.
		/// </summary>
		public decimal? Damage_Loss_of_Sales_Est_Cost
		{
			get { return _Damage_Loss_of_Sales_Est_Cost; }
			set { _Damage_Loss_of_Sales_Est_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Damage_Loss_of_Sales_Actual_Cost value.
		/// </summary>
		public decimal? Damage_Loss_of_Sales_Actual_Cost
		{
			get { return _Damage_Loss_of_Sales_Actual_Cost; }
			set { _Damage_Loss_of_Sales_Actual_Cost = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Cleanup_Complete value.
		/// </summary>
		public DateTime? Date_Cleanup_Complete
		{
			get { return _Date_Cleanup_Complete; }
			set { _Date_Cleanup_Complete = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Repairs_Complete value.
		/// </summary>
		public DateTime? Date_Repairs_Complete
		{
			get { return _Date_Repairs_Complete; }
			set { _Date_Repairs_Complete = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Full_Service_Resumed value.
		/// </summary>
		public DateTime? Date_Full_Service_Resumed
		{
			get { return _Date_Full_Service_Resumed; }
			set { _Date_Full_Service_Resumed = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Fire_Protection_Services_Resumed value.
		/// </summary>
		public DateTime? Date_Fire_Protection_Services_Resumed
		{
			get { return _Date_Fire_Protection_Services_Resumed; }
			set { _Date_Fire_Protection_Services_Resumed = value; }
		}

		/// <summary>
		/// Gets or sets the Comments value.
		/// </summary>
		public string Comments
		{
			get { return _Comments; }
			set { _Comments = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Report_Complete value.
		/// </summary>
		public string Date_Report_Complete
		{
			get { return _Date_Report_Complete; }
			set { _Date_Report_Complete = value; }
		}

		/// <summary>
		/// Gets or sets the Date_Claim_Closed value.
		/// </summary>
		public string Date_Claim_Closed
		{
			get { return _Date_Claim_Closed; }
			set { _Date_Claim_Closed = value; }
		}

		/// <summary>
		/// Gets or sets the Complete value.
		/// </summary>
		public bool? Complete
		{
			get { return _Complete; }
			set { _Complete = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_By value.
		/// </summary>
		public decimal? Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}

		/// <summary>
		/// Gets or sets the Updated_Date value.
		/// </summary>
		public DateTime? Updated_Date
		{
			get { return _Updated_Date; }
			set { _Updated_Date = value; }
		}

		/// <summary>
		/// Gets or sets the FK_SLT_Incident_Review value.
		/// </summary>
		public decimal? FK_SLT_Incident_Review
		{
			get { return _FK_SLT_Incident_Review; }
			set { _FK_SLT_Incident_Review = value; }
		}

		/// <summary>
		/// Gets or sets the Created_Date value.
		/// </summary>
		public DateTime? Created_Date
		{
			get { return _Created_Date; }
			set { _Created_Date = value; }
		}

		/// <summary>
		/// Gets or sets the Security_Video_Surveillance value.
		/// </summary>
		public bool? Security_Video_Surveillance
		{
			get { return _Security_Video_Surveillance; }
			set { _Security_Video_Surveillance = value; }
		}

        /// <summary>
        /// Set or get FK_First_Report_Wizard_ID
        /// </summary>
        public decimal FK_First_Report_Wizard_ID
        {
            get { return _FK_First_Report_Wizard_ID; }
            set {
                _FK_First_Report_Wizard_ID = value;    
            }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims class with default value.
		/// </summary>
		public Property_Claims() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Property_Claims class based on Primary Key.
		/// </summary>
		public Property_Claims(decimal pK_Property_Claims_ID) 
		{
			DataTable dtProperty_Claims = Select(pK_Property_Claims_ID).Tables[0];

			if (dtProperty_Claims.Rows.Count == 1)
			{
				 SetValue(dtProperty_Claims.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Property_Claims class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drProperty_Claims) 
		{
				if (drProperty_Claims["PK_Property_Claims_ID"] == DBNull.Value)
					this._PK_Property_Claims_ID = null;
				else
					this._PK_Property_Claims_ID = (decimal?)drProperty_Claims["PK_Property_Claims_ID"];

				if (drProperty_Claims["FK_Property_FR_ID"] == DBNull.Value)
					this._FK_Property_FR_ID = null;
				else
					this._FK_Property_FR_ID = (decimal?)drProperty_Claims["FK_Property_FR_ID"];

				if (drProperty_Claims["Property_FR_Number"] == DBNull.Value)
					this._Property_FR_Number = null;
				else
					this._Property_FR_Number = (decimal?)drProperty_Claims["Property_FR_Number"];

				if (drProperty_Claims["FK_Location_Code"] == DBNull.Value)
					this._FK_Location_Code = null;
				else
					this._FK_Location_Code = (decimal?)drProperty_Claims["FK_Location_Code"];

				if (drProperty_Claims["FK_Contact"] == DBNull.Value)
					this._FK_Contact = null;
				else
					this._FK_Contact = (decimal?)drProperty_Claims["FK_Contact"];

				if (drProperty_Claims["Date_Reported_to_Sonic"] == DBNull.Value)
					this._Date_Reported_to_Sonic = null;
				else
					this._Date_Reported_to_Sonic = (DateTime?)drProperty_Claims["Date_Reported_to_Sonic"];

				if (drProperty_Claims["Fire"] == DBNull.Value)
					this._Fire = null;
				else
					this._Fire = (bool?)drProperty_Claims["Fire"];

				if (drProperty_Claims["Wind_Damage"] == DBNull.Value)
					this._Wind_Damage = null;
				else
					this._Wind_Damage = (bool?)drProperty_Claims["Wind_Damage"];

				if (drProperty_Claims["Hail_Damage"] == DBNull.Value)
					this._Hail_Damage = null;
				else
					this._Hail_Damage = (bool?)drProperty_Claims["Hail_Damage"];

				if (drProperty_Claims["Earth_Movement"] == DBNull.Value)
					this._Earth_Movement = null;
				else
					this._Earth_Movement = (bool?)drProperty_Claims["Earth_Movement"];

				if (drProperty_Claims["Flood"] == DBNull.Value)
					this._Flood = null;
				else
					this._Flood = (bool?)drProperty_Claims["Flood"];

				if (drProperty_Claims["Third_Party_Property_Damage"] == DBNull.Value)
					this._Third_Party_Property_Damage = null;
				else
					this._Third_Party_Property_Damage = (bool?)drProperty_Claims["Third_Party_Property_Damage"];

				if (drProperty_Claims["Property_Damage_by_Sonic_Associate"] == DBNull.Value)
					this._Property_Damage_by_Sonic_Associate = null;
				else
					this._Property_Damage_by_Sonic_Associate = (bool?)drProperty_Claims["Property_Damage_by_Sonic_Associate"];

				if (drProperty_Claims["Environmental_Loss"] == DBNull.Value)
					this._Environmental_Loss = null;
				else
					this._Environmental_Loss = (bool?)drProperty_Claims["Environmental_Loss"];

				if (drProperty_Claims["Vandalism_To_The_Property"] == DBNull.Value)
					this._Vandalism_To_The_Property = null;
				else
					this._Vandalism_To_The_Property = (bool?)drProperty_Claims["Vandalism_To_The_Property"];

				if (drProperty_Claims["Theft_Associate_Tools"] == DBNull.Value)
					this._Theft_Associate_Tools = null;
				else
					this._Theft_Associate_Tools = (bool?)drProperty_Claims["Theft_Associate_Tools"];

				if (drProperty_Claims["Theft_All_Other"] == DBNull.Value)
					this._Theft_All_Other = null;
				else
					this._Theft_All_Other = (bool?)drProperty_Claims["Theft_All_Other"];

				if (drProperty_Claims["Other"] == DBNull.Value)
					this._Other = null;
				else
					this._Other = (bool?)drProperty_Claims["Other"];

				if (drProperty_Claims["Date_Of_Loss"] == DBNull.Value)
					this._Date_Of_Loss = null;
				else
					this._Date_Of_Loss = (DateTime?)drProperty_Claims["Date_Of_Loss"];

				if (drProperty_Claims["Time_Of_Loss"] == DBNull.Value)
					this._Time_Of_Loss = null;
				else
					this._Time_Of_Loss = (string)drProperty_Claims["Time_Of_Loss"];

				if (drProperty_Claims["Description_of_Loss"] == DBNull.Value)
					this._Description_of_Loss = null;
				else
					this._Description_of_Loss = (string)drProperty_Claims["Description_of_Loss"];

				if (drProperty_Claims["Damage_Building_Facilities_Est_Cost"] == DBNull.Value)
					this._Damage_Building_Facilities_Est_Cost = null;
				else
					this._Damage_Building_Facilities_Est_Cost = (decimal?)drProperty_Claims["Damage_Building_Facilities_Est_Cost"];

				if (drProperty_Claims["Damage_Building_Facilities_Actual_Cost"] == DBNull.Value)
					this._Damage_Building_Facilities_Actual_Cost = null;
				else
					this._Damage_Building_Facilities_Actual_Cost = (decimal?)drProperty_Claims["Damage_Building_Facilities_Actual_Cost"];

				if (drProperty_Claims["Damage_Equipment_Est_Cost"] == DBNull.Value)
					this._Damage_Equipment_Est_Cost = null;
				else
					this._Damage_Equipment_Est_Cost = (decimal?)drProperty_Claims["Damage_Equipment_Est_Cost"];

				if (drProperty_Claims["Damage_Equipment_Actual_Cost"] == DBNull.Value)
					this._Damage_Equipment_Actual_Cost = null;
				else
					this._Damage_Equipment_Actual_Cost = (decimal?)drProperty_Claims["Damage_Equipment_Actual_Cost"];

				if (drProperty_Claims["Damage_Product_Damage_Est_Cost"] == DBNull.Value)
					this._Damage_Product_Damage_Est_Cost = null;
				else
					this._Damage_Product_Damage_Est_Cost = (decimal?)drProperty_Claims["Damage_Product_Damage_Est_Cost"];

				if (drProperty_Claims["Damage_Product_Damage_Actual_Cost"] == DBNull.Value)
					this._Damage_Product_Damage_Actual_Cost = null;
				else
					this._Damage_Product_Damage_Actual_Cost = (decimal?)drProperty_Claims["Damage_Product_Damage_Actual_Cost"];

				if (drProperty_Claims["Damage_Parts_Est_Cost"] == DBNull.Value)
					this._Damage_Parts_Est_Cost = null;
				else
					this._Damage_Parts_Est_Cost = (decimal?)drProperty_Claims["Damage_Parts_Est_Cost"];

				if (drProperty_Claims["Damage_Parts_Actual_Cost"] == DBNull.Value)
					this._Damage_Parts_Actual_Cost = null;
				else
					this._Damage_Parts_Actual_Cost = (decimal?)drProperty_Claims["Damage_Parts_Actual_Cost"];

				if (drProperty_Claims["Damage_Salvage_Cleanup_Est_Cost"] == DBNull.Value)
					this._Damage_Salvage_Cleanup_Est_Cost = null;
				else
					this._Damage_Salvage_Cleanup_Est_Cost = (decimal?)drProperty_Claims["Damage_Salvage_Cleanup_Est_Cost"];

				if (drProperty_Claims["Damage_Salvage_Cleanup_Actual_Cost"] == DBNull.Value)
					this._Damage_Salvage_Cleanup_Actual_Cost = null;
				else
					this._Damage_Salvage_Cleanup_Actual_Cost = (decimal?)drProperty_Claims["Damage_Salvage_Cleanup_Actual_Cost"];

				if (drProperty_Claims["Damage_Decontamination_Est_Cost"] == DBNull.Value)
					this._Damage_Decontamination_Est_Cost = null;
				else
					this._Damage_Decontamination_Est_Cost = (decimal?)drProperty_Claims["Damage_Decontamination_Est_Cost"];

				if (drProperty_Claims["Damage_Decontamination_Actual_Cost"] == DBNull.Value)
					this._Damage_Decontamination_Actual_Cost = null;
				else
					this._Damage_Decontamination_Actual_Cost = (decimal?)drProperty_Claims["Damage_Decontamination_Actual_Cost"];

				if (drProperty_Claims["Damage_Electronic_Data_Est_Cost"] == DBNull.Value)
					this._Damage_Electronic_Data_Est_Cost = null;
				else
					this._Damage_Electronic_Data_Est_Cost = (decimal?)drProperty_Claims["Damage_Electronic_Data_Est_Cost"];

				if (drProperty_Claims["Damage_Electronic_Data_Actual_Cost"] == DBNull.Value)
					this._Damage_Electronic_Data_Actual_Cost = null;
				else
					this._Damage_Electronic_Data_Actual_Cost = (decimal?)drProperty_Claims["Damage_Electronic_Data_Actual_Cost"];

				if (drProperty_Claims["Damage_Service_Interruption_Est_Cost"] == DBNull.Value)
					this._Damage_Service_Interruption_Est_Cost = null;
				else
					this._Damage_Service_Interruption_Est_Cost = (decimal?)drProperty_Claims["Damage_Service_Interruption_Est_Cost"];

				if (drProperty_Claims["Damage_Service_Interruption_Actual_Cost"] == DBNull.Value)
					this._Damage_Service_Interruption_Actual_Cost = null;
				else
					this._Damage_Service_Interruption_Actual_Cost = (decimal?)drProperty_Claims["Damage_Service_Interruption_Actual_Cost"];

				if (drProperty_Claims["Damage_Payroll_Est_Cost"] == DBNull.Value)
					this._Damage_Payroll_Est_Cost = null;
				else
					this._Damage_Payroll_Est_Cost = (decimal?)drProperty_Claims["Damage_Payroll_Est_Cost"];

				if (drProperty_Claims["Damage_Payroll_Actual_Cost"] == DBNull.Value)
					this._Damage_Payroll_Actual_Cost = null;
				else
					this._Damage_Payroll_Actual_Cost = (decimal?)drProperty_Claims["Damage_Payroll_Actual_Cost"];

				if (drProperty_Claims["Damage_Loss_of_Sales_Est_Cost"] == DBNull.Value)
					this._Damage_Loss_of_Sales_Est_Cost = null;
				else
					this._Damage_Loss_of_Sales_Est_Cost = (decimal?)drProperty_Claims["Damage_Loss_of_Sales_Est_Cost"];

				if (drProperty_Claims["Damage_Loss_of_Sales_Actual_Cost"] == DBNull.Value)
					this._Damage_Loss_of_Sales_Actual_Cost = null;
				else
					this._Damage_Loss_of_Sales_Actual_Cost = (decimal?)drProperty_Claims["Damage_Loss_of_Sales_Actual_Cost"];

				if (drProperty_Claims["Date_Cleanup_Complete"] == DBNull.Value)
					this._Date_Cleanup_Complete = null;
				else
					this._Date_Cleanup_Complete = (DateTime?)drProperty_Claims["Date_Cleanup_Complete"];

				if (drProperty_Claims["Date_Repairs_Complete"] == DBNull.Value)
					this._Date_Repairs_Complete = null;
				else
					this._Date_Repairs_Complete = (DateTime?)drProperty_Claims["Date_Repairs_Complete"];

				if (drProperty_Claims["Date_Full_Service_Resumed"] == DBNull.Value)
					this._Date_Full_Service_Resumed = null;
				else
					this._Date_Full_Service_Resumed = (DateTime?)drProperty_Claims["Date_Full_Service_Resumed"];

				if (drProperty_Claims["Date_Fire_Protection_Services_Resumed"] == DBNull.Value)
					this._Date_Fire_Protection_Services_Resumed = null;
				else
					this._Date_Fire_Protection_Services_Resumed = (DateTime?)drProperty_Claims["Date_Fire_Protection_Services_Resumed"];

				if (drProperty_Claims["Comments"] == DBNull.Value)
					this._Comments = null;
				else
					this._Comments = (string)drProperty_Claims["Comments"];

				if (drProperty_Claims["Date_Report_Complete"] == DBNull.Value)
					this._Date_Report_Complete = null;
				else
					this._Date_Report_Complete = (string)drProperty_Claims["Date_Report_Complete"];

				if (drProperty_Claims["Date_Claim_Closed"] == DBNull.Value)
					this._Date_Claim_Closed = null;
				else
					this._Date_Claim_Closed = (string)drProperty_Claims["Date_Claim_Closed"];

				if (drProperty_Claims["Complete"] == DBNull.Value)
					this._Complete = null;
				else
					this._Complete = (bool?)drProperty_Claims["Complete"];

				if (drProperty_Claims["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (decimal?)drProperty_Claims["Updated_By"];

				if (drProperty_Claims["Updated_Date"] == DBNull.Value)
					this._Updated_Date = null;
				else
					this._Updated_Date = (DateTime?)drProperty_Claims["Updated_Date"];

				if (drProperty_Claims["FK_SLT_Incident_Review"] == DBNull.Value)
					this._FK_SLT_Incident_Review = null;
				else
					this._FK_SLT_Incident_Review = (decimal?)drProperty_Claims["FK_SLT_Incident_Review"];

				if (drProperty_Claims["Created_Date"] == DBNull.Value)
					this._Created_Date = null;
				else
					this._Created_Date = (DateTime?)drProperty_Claims["Created_Date"];

				if (drProperty_Claims["Security_Video_Surveillance"] == DBNull.Value)
					this._Security_Video_Surveillance = null;
				else
					this._Security_Video_Surveillance = (bool?)drProperty_Claims["Security_Video_Surveillance"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Property_Claims table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsInsert");

			
			db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);
			
			db.AddInParameter(dbCommand, "Property_FR_Number", DbType.Decimal, this._Property_FR_Number);
			
			db.AddInParameter(dbCommand, "FK_Location_Code", DbType.Decimal, this._FK_Location_Code);
			
			db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
			
			db.AddInParameter(dbCommand, "Date_Reported_to_Sonic", DbType.DateTime, this._Date_Reported_to_Sonic);
			
			db.AddInParameter(dbCommand, "Fire", DbType.Boolean, this._Fire);
			
			db.AddInParameter(dbCommand, "Wind_Damage", DbType.Boolean, this._Wind_Damage);
			
			db.AddInParameter(dbCommand, "Hail_Damage", DbType.Boolean, this._Hail_Damage);
			
			db.AddInParameter(dbCommand, "Earth_Movement", DbType.Boolean, this._Earth_Movement);
			
			db.AddInParameter(dbCommand, "Flood", DbType.Boolean, this._Flood);
			
			db.AddInParameter(dbCommand, "Third_Party_Property_Damage", DbType.Boolean, this._Third_Party_Property_Damage);
			
			db.AddInParameter(dbCommand, "Property_Damage_by_Sonic_Associate", DbType.Boolean, this._Property_Damage_by_Sonic_Associate);
			
			db.AddInParameter(dbCommand, "Environmental_Loss", DbType.Boolean, this._Environmental_Loss);
			
			db.AddInParameter(dbCommand, "Vandalism_To_The_Property", DbType.Boolean, this._Vandalism_To_The_Property);
			
			db.AddInParameter(dbCommand, "Theft_Associate_Tools", DbType.Boolean, this._Theft_Associate_Tools);
			
			db.AddInParameter(dbCommand, "Theft_All_Other", DbType.Boolean, this._Theft_All_Other);
			
			db.AddInParameter(dbCommand, "Other", DbType.Boolean, this._Other);
			
			db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
			
			if (string.IsNullOrEmpty(this._Time_Of_Loss))
				db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, this._Time_Of_Loss);
			
			if (string.IsNullOrEmpty(this._Description_of_Loss))
				db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, this._Description_of_Loss);
			
			db.AddInParameter(dbCommand, "Damage_Building_Facilities_Est_Cost", DbType.Decimal, this._Damage_Building_Facilities_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Building_Facilities_Actual_Cost", DbType.Decimal, this._Damage_Building_Facilities_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Equipment_Est_Cost", DbType.Decimal, this._Damage_Equipment_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Equipment_Actual_Cost", DbType.Decimal, this._Damage_Equipment_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Product_Damage_Est_Cost", DbType.Decimal, this._Damage_Product_Damage_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Product_Damage_Actual_Cost", DbType.Decimal, this._Damage_Product_Damage_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Parts_Est_Cost", DbType.Decimal, this._Damage_Parts_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Parts_Actual_Cost", DbType.Decimal, this._Damage_Parts_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Est_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Actual_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Decontamination_Est_Cost", DbType.Decimal, this._Damage_Decontamination_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Decontamination_Actual_Cost", DbType.Decimal, this._Damage_Decontamination_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Electronic_Data_Est_Cost", DbType.Decimal, this._Damage_Electronic_Data_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Electronic_Data_Actual_Cost", DbType.Decimal, this._Damage_Electronic_Data_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Service_Interruption_Est_Cost", DbType.Decimal, this._Damage_Service_Interruption_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Service_Interruption_Actual_Cost", DbType.Decimal, this._Damage_Service_Interruption_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Payroll_Est_Cost", DbType.Decimal, this._Damage_Payroll_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Payroll_Actual_Cost", DbType.Decimal, this._Damage_Payroll_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Est_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Actual_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Date_Cleanup_Complete", DbType.DateTime, this._Date_Cleanup_Complete);
			
			db.AddInParameter(dbCommand, "Date_Repairs_Complete", DbType.DateTime, this._Date_Repairs_Complete);
			
			db.AddInParameter(dbCommand, "Date_Full_Service_Resumed", DbType.DateTime, this._Date_Full_Service_Resumed);
			
			db.AddInParameter(dbCommand, "Date_Fire_Protection_Services_Resumed", DbType.DateTime, this._Date_Fire_Protection_Services_Resumed);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Date_Report_Complete))
				db.AddInParameter(dbCommand, "Date_Report_Complete", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Date_Report_Complete", DbType.String, this._Date_Report_Complete);
			
			if (string.IsNullOrEmpty(this._Date_Claim_Closed))
				db.AddInParameter(dbCommand, "Date_Claim_Closed", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Date_Claim_Closed", DbType.String, this._Date_Claim_Closed);
			
			db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
			
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			
			db.AddInParameter(dbCommand, "FK_SLT_Incident_Review", DbType.Decimal, this._FK_SLT_Incident_Review);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
			
			db.AddInParameter(dbCommand, "Security_Video_Surveillance", DbType.Boolean, this._Security_Video_Surveillance);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Property_Claims table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal pK_Property_Claims_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsSelect");

			db.AddInParameter(dbCommand, "PK_Property_Claims_ID", DbType.Decimal, pK_Property_Claims_ID);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Property_Claims table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Property_Claims table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsUpdate");

			
			db.AddInParameter(dbCommand, "PK_Property_Claims_ID", DbType.Decimal, this._PK_Property_Claims_ID);
			
			db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, this._FK_Property_FR_ID);
			
			db.AddInParameter(dbCommand, "Property_FR_Number", DbType.Decimal, this._Property_FR_Number);
			
			db.AddInParameter(dbCommand, "FK_Location_Code", DbType.Decimal, this._FK_Location_Code);
			
			db.AddInParameter(dbCommand, "FK_Contact", DbType.Decimal, this._FK_Contact);
			
			db.AddInParameter(dbCommand, "Date_Reported_to_Sonic", DbType.DateTime, this._Date_Reported_to_Sonic);
			
			db.AddInParameter(dbCommand, "Fire", DbType.Boolean, this._Fire);
			
			db.AddInParameter(dbCommand, "Wind_Damage", DbType.Boolean, this._Wind_Damage);
			
			db.AddInParameter(dbCommand, "Hail_Damage", DbType.Boolean, this._Hail_Damage);
			
			db.AddInParameter(dbCommand, "Earth_Movement", DbType.Boolean, this._Earth_Movement);
			
			db.AddInParameter(dbCommand, "Flood", DbType.Boolean, this._Flood);
			
			db.AddInParameter(dbCommand, "Third_Party_Property_Damage", DbType.Boolean, this._Third_Party_Property_Damage);
			
			db.AddInParameter(dbCommand, "Property_Damage_by_Sonic_Associate", DbType.Boolean, this._Property_Damage_by_Sonic_Associate);
			
			db.AddInParameter(dbCommand, "Environmental_Loss", DbType.Boolean, this._Environmental_Loss);
			
			db.AddInParameter(dbCommand, "Vandalism_To_The_Property", DbType.Boolean, this._Vandalism_To_The_Property);
			
			db.AddInParameter(dbCommand, "Theft_Associate_Tools", DbType.Boolean, this._Theft_Associate_Tools);
			
			db.AddInParameter(dbCommand, "Theft_All_Other", DbType.Boolean, this._Theft_All_Other);
			
			db.AddInParameter(dbCommand, "Other", DbType.Boolean, this._Other);
			
			db.AddInParameter(dbCommand, "Date_Of_Loss", DbType.DateTime, this._Date_Of_Loss);
			
			if (string.IsNullOrEmpty(this._Time_Of_Loss))
				db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Time_Of_Loss", DbType.String, this._Time_Of_Loss);
			
			if (string.IsNullOrEmpty(this._Description_of_Loss))
				db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Description_of_Loss", DbType.String, this._Description_of_Loss);
			
			db.AddInParameter(dbCommand, "Damage_Building_Facilities_Est_Cost", DbType.Decimal, this._Damage_Building_Facilities_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Building_Facilities_Actual_Cost", DbType.Decimal, this._Damage_Building_Facilities_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Equipment_Est_Cost", DbType.Decimal, this._Damage_Equipment_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Equipment_Actual_Cost", DbType.Decimal, this._Damage_Equipment_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Product_Damage_Est_Cost", DbType.Decimal, this._Damage_Product_Damage_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Product_Damage_Actual_Cost", DbType.Decimal, this._Damage_Product_Damage_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Parts_Est_Cost", DbType.Decimal, this._Damage_Parts_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Parts_Actual_Cost", DbType.Decimal, this._Damage_Parts_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Est_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Salvage_Cleanup_Actual_Cost", DbType.Decimal, this._Damage_Salvage_Cleanup_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Decontamination_Est_Cost", DbType.Decimal, this._Damage_Decontamination_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Decontamination_Actual_Cost", DbType.Decimal, this._Damage_Decontamination_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Electronic_Data_Est_Cost", DbType.Decimal, this._Damage_Electronic_Data_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Electronic_Data_Actual_Cost", DbType.Decimal, this._Damage_Electronic_Data_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Service_Interruption_Est_Cost", DbType.Decimal, this._Damage_Service_Interruption_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Service_Interruption_Actual_Cost", DbType.Decimal, this._Damage_Service_Interruption_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Payroll_Est_Cost", DbType.Decimal, this._Damage_Payroll_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Payroll_Actual_Cost", DbType.Decimal, this._Damage_Payroll_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Est_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Est_Cost);
			
			db.AddInParameter(dbCommand, "Damage_Loss_of_Sales_Actual_Cost", DbType.Decimal, this._Damage_Loss_of_Sales_Actual_Cost);
			
			db.AddInParameter(dbCommand, "Date_Cleanup_Complete", DbType.DateTime, this._Date_Cleanup_Complete);
			
			db.AddInParameter(dbCommand, "Date_Repairs_Complete", DbType.DateTime, this._Date_Repairs_Complete);
			
			db.AddInParameter(dbCommand, "Date_Full_Service_Resumed", DbType.DateTime, this._Date_Full_Service_Resumed);
			
			db.AddInParameter(dbCommand, "Date_Fire_Protection_Services_Resumed", DbType.DateTime, this._Date_Fire_Protection_Services_Resumed);
			
			if (string.IsNullOrEmpty(this._Comments))
				db.AddInParameter(dbCommand, "Comments", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Comments", DbType.String, this._Comments);
			
			if (string.IsNullOrEmpty(this._Date_Report_Complete))
				db.AddInParameter(dbCommand, "Date_Report_Complete", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Date_Report_Complete", DbType.String, this._Date_Report_Complete);
			
			if (string.IsNullOrEmpty(this._Date_Claim_Closed))
				db.AddInParameter(dbCommand, "Date_Claim_Closed", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Date_Claim_Closed", DbType.String, this._Date_Claim_Closed);
			
			db.AddInParameter(dbCommand, "Complete", DbType.Boolean, this._Complete);
			
			db.AddInParameter(dbCommand, "Updated_By", DbType.Decimal, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Updated_Date", DbType.DateTime, this._Updated_Date);
			
			db.AddInParameter(dbCommand, "FK_SLT_Incident_Review", DbType.Decimal, this._FK_SLT_Incident_Review);
			
			db.AddInParameter(dbCommand, "Created_Date", DbType.DateTime, this._Created_Date);
			
			db.AddInParameter(dbCommand, "Security_Video_Surveillance", DbType.Boolean, this._Security_Video_Surveillance);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Property_Claims table by a composite primary key.
		/// </summary>
		public static void Delete(decimal pK_Property_Claims_ID)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsDelete");

			db.AddInParameter(dbCommand, "PK_Property_Claims_ID", DbType.Decimal, pK_Property_Claims_ID);

			db.ExecuteNonQuery(dbCommand);
		}

        public void SelectByProperty_FR_ID(decimal fK_Property_FR_ID)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsSelectByProperty_FR_ID");

            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, fK_Property_FR_ID);

            DataTable dtProperty_Claims = db.ExecuteDataSet(dbCommand).Tables[0];

            if (dtProperty_Claims.Rows.Count == 1)
            {
                SetValue(dtProperty_Claims.Rows[0]);
                _FK_First_Report_Wizard_ID = dtProperty_Claims.Rows[0]["FK_First_Report_ID"] != DBNull.Value ? Convert.ToDecimal(dtProperty_Claims.Rows[0]["FK_First_Report_Wizard_ID"]) : 0;
            }

        }

        /// <summary>
        /// Copy data from FR to claims tables
        /// </summary>
        public static void CopyDataFromFRToClaims(decimal fK_Property_FR_ID, int majorCoverage)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Property_ClaimsCopyDataFromProperty_FR_To_Property_Claims");

            db.AddInParameter(dbCommand, "FK_Property_FR_ID", DbType.Decimal, fK_Property_FR_ID);
            db.AddInParameter(dbCommand, "MajorCoverage", DbType.Decimal, majorCoverage);

            db.ExecuteNonQuery(dbCommand);
        }
	}
}

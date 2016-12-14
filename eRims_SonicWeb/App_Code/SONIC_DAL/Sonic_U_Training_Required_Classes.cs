using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Sonic_U_Training_Required_Classes table.
	/// </summary>
	public sealed class Sonic_U_Training_Required_Classes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sonic_U_Training;
		private string _Code;
		private string _Position;
		private string _Job_Type;
		private string _Department;
		private string _Associate_Safety_Certification;
		private string _Vehicle_Lift_Safety;
		private string _RCRA;
		private string _Hazardous_Materials_Transportation;
		private string _Powered_Industrial_Trucks;
		private string _Respiratory_Training;
		private string _Stormwater_Pollution;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sonic_U_Training value.
		/// </summary>
		public decimal? PK_Sonic_U_Training
		{
			get { return _PK_Sonic_U_Training; }
			set { _PK_Sonic_U_Training = value; }
		}

		/// <summary>
		/// Gets or sets the Code value.
		/// </summary>
		public string Code
		{
			get { return _Code; }
			set { _Code = value; }
		}

		/// <summary>
		/// Gets or sets the Position value.
		/// </summary>
		public string Position
		{
			get { return _Position; }
			set { _Position = value; }
		}

		/// <summary>
		/// Gets or sets the Job_Type value.
		/// </summary>
		public string Job_Type
		{
			get { return _Job_Type; }
			set { _Job_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Department value.
		/// </summary>
		public string Department
		{
			get { return _Department; }
			set { _Department = value; }
		}

		/// <summary>
		/// Gets or sets the Associate_Safety_Certification value.
		/// </summary>
		public string Associate_Safety_Certification
		{
			get { return _Associate_Safety_Certification; }
			set { _Associate_Safety_Certification = value; }
		}

		/// <summary>
		/// Gets or sets the Vehicle_Lift_Safety value.
		/// </summary>
		public string Vehicle_Lift_Safety
		{
			get { return _Vehicle_Lift_Safety; }
			set { _Vehicle_Lift_Safety = value; }
		}

		/// <summary>
		/// Gets or sets the RCRA value.
		/// </summary>
		public string RCRA
		{
			get { return _RCRA; }
			set { _RCRA = value; }
		}

		/// <summary>
		/// Gets or sets the Hazardous_Materials_Transportation value.
		/// </summary>
		public string Hazardous_Materials_Transportation
		{
			get { return _Hazardous_Materials_Transportation; }
			set { _Hazardous_Materials_Transportation = value; }
		}

		/// <summary>
		/// Gets or sets the Powered_Industrial_Trucks value.
		/// </summary>
		public string Powered_Industrial_Trucks
		{
			get { return _Powered_Industrial_Trucks; }
			set { _Powered_Industrial_Trucks = value; }
		}

		/// <summary>
		/// Gets or sets the Respiratory_Training value.
		/// </summary>
		public string Respiratory_Training
		{
			get { return _Respiratory_Training; }
			set { _Respiratory_Training = value; }
		}

		/// <summary>
		/// Gets or sets the Stormwater_Pollution value.
		/// </summary>
		public string Stormwater_Pollution
		{
			get { return _Stormwater_Pollution; }
			set { _Stormwater_Pollution = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Required_Classes class with default value.
		/// </summary>
		public Sonic_U_Training_Required_Classes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Required_Classes class based on Primary Key.
		/// </summary>
		public Sonic_U_Training_Required_Classes(decimal pK_Sonic_U_Training) 
		{
			DataTable dtSonic_U_Training_Required_Classes = SelectByPK(pK_Sonic_U_Training).Tables[0];

			if (dtSonic_U_Training_Required_Classes.Rows.Count == 1)
			{
				 SetValue(dtSonic_U_Training_Required_Classes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Required_Classes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSonic_U_Training_Required_Classes) 
		{
				if (drSonic_U_Training_Required_Classes["PK_Sonic_U_Training"] == DBNull.Value)
					this._PK_Sonic_U_Training = null;
				else
					this._PK_Sonic_U_Training = (decimal?)drSonic_U_Training_Required_Classes["PK_Sonic_U_Training"];

				if (drSonic_U_Training_Required_Classes["Code"] == DBNull.Value)
					this._Code = null;
				else
					this._Code = (string)drSonic_U_Training_Required_Classes["Code"];

				if (drSonic_U_Training_Required_Classes["Position"] == DBNull.Value)
					this._Position = null;
				else
					this._Position = (string)drSonic_U_Training_Required_Classes["Position"];

				if (drSonic_U_Training_Required_Classes["Job_Type"] == DBNull.Value)
					this._Job_Type = null;
				else
					this._Job_Type = (string)drSonic_U_Training_Required_Classes["Job_Type"];

				if (drSonic_U_Training_Required_Classes["Department"] == DBNull.Value)
					this._Department = null;
				else
					this._Department = (string)drSonic_U_Training_Required_Classes["Department"];

				if (drSonic_U_Training_Required_Classes["Associate_Safety_Certification"] == DBNull.Value)
					this._Associate_Safety_Certification = null;
				else
					this._Associate_Safety_Certification = (string)drSonic_U_Training_Required_Classes["Associate_Safety_Certification"];

				if (drSonic_U_Training_Required_Classes["Vehicle_Lift_Safety"] == DBNull.Value)
					this._Vehicle_Lift_Safety = null;
				else
					this._Vehicle_Lift_Safety = (string)drSonic_U_Training_Required_Classes["Vehicle_Lift_Safety"];

				if (drSonic_U_Training_Required_Classes["RCRA"] == DBNull.Value)
					this._RCRA = null;
				else
					this._RCRA = (string)drSonic_U_Training_Required_Classes["RCRA"];

				if (drSonic_U_Training_Required_Classes["Hazardous_Materials_Transportation"] == DBNull.Value)
					this._Hazardous_Materials_Transportation = null;
				else
					this._Hazardous_Materials_Transportation = (string)drSonic_U_Training_Required_Classes["Hazardous_Materials_Transportation"];

				if (drSonic_U_Training_Required_Classes["Powered_Industrial_Trucks"] == DBNull.Value)
					this._Powered_Industrial_Trucks = null;
				else
					this._Powered_Industrial_Trucks = (string)drSonic_U_Training_Required_Classes["Powered_Industrial_Trucks"];

				if (drSonic_U_Training_Required_Classes["Respiratory_Training"] == DBNull.Value)
					this._Respiratory_Training = null;
				else
					this._Respiratory_Training = (string)drSonic_U_Training_Required_Classes["Respiratory_Training"];

				if (drSonic_U_Training_Required_Classes["Stormwater_Pollution"] == DBNull.Value)
					this._Stormwater_Pollution = null;
				else
					this._Stormwater_Pollution = (string)drSonic_U_Training_Required_Classes["Stormwater_Pollution"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sonic_U_Training_Required_Classes table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesInsert");

			
			if (string.IsNullOrEmpty(this._Code))
				db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
			
			if (string.IsNullOrEmpty(this._Position))
				db.AddInParameter(dbCommand, "Position", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Position", DbType.String, this._Position);
			
			if (string.IsNullOrEmpty(this._Job_Type))
				db.AddInParameter(dbCommand, "Job_Type", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Job_Type", DbType.String, this._Job_Type);
			
			if (string.IsNullOrEmpty(this._Department))
				db.AddInParameter(dbCommand, "Department", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);
			
			if (string.IsNullOrEmpty(this._Associate_Safety_Certification))
				db.AddInParameter(dbCommand, "Associate_Safety_Certification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Associate_Safety_Certification", DbType.String, this._Associate_Safety_Certification);
			
			if (string.IsNullOrEmpty(this._Vehicle_Lift_Safety))
				db.AddInParameter(dbCommand, "Vehicle_Lift_Safety", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vehicle_Lift_Safety", DbType.String, this._Vehicle_Lift_Safety);
			
			if (string.IsNullOrEmpty(this._RCRA))
				db.AddInParameter(dbCommand, "RCRA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "RCRA", DbType.String, this._RCRA);
			
			if (string.IsNullOrEmpty(this._Hazardous_Materials_Transportation))
				db.AddInParameter(dbCommand, "Hazardous_Materials_Transportation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Hazardous_Materials_Transportation", DbType.String, this._Hazardous_Materials_Transportation);
			
			if (string.IsNullOrEmpty(this._Powered_Industrial_Trucks))
				db.AddInParameter(dbCommand, "Powered_Industrial_Trucks", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Powered_Industrial_Trucks", DbType.String, this._Powered_Industrial_Trucks);
			
			if (string.IsNullOrEmpty(this._Respiratory_Training))
				db.AddInParameter(dbCommand, "Respiratory_Training", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Respiratory_Training", DbType.String, this._Respiratory_Training);
			
			if (string.IsNullOrEmpty(this._Stormwater_Pollution))
				db.AddInParameter(dbCommand, "Stormwater_Pollution", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Stormwater_Pollution", DbType.String, this._Stormwater_Pollution);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Sonic_U_Training_Required_Classes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_Sonic_U_Training)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Training", DbType.Decimal, pK_Sonic_U_Training);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sonic_U_Training_Required_Classes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sonic_U_Training_Required_Classes table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sonic_U_Training", DbType.Decimal, this._PK_Sonic_U_Training);
			
            //if (string.IsNullOrEmpty(this._Code))
            //    db.AddInParameter(dbCommand, "Code", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Code", DbType.String, this._Code);
			
            //if (string.IsNullOrEmpty(this._Position))
            //    db.AddInParameter(dbCommand, "Position", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Position", DbType.String, this._Position);
			
            //if (string.IsNullOrEmpty(this._Job_Type))
            //    db.AddInParameter(dbCommand, "Job_Type", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Job_Type", DbType.String, this._Job_Type);
			
            //if (string.IsNullOrEmpty(this._Department))
            //    db.AddInParameter(dbCommand, "Department", DbType.String, DBNull.Value);
            //else
            //    db.AddInParameter(dbCommand, "Department", DbType.String, this._Department);
			
			if (string.IsNullOrEmpty(this._Associate_Safety_Certification))
				db.AddInParameter(dbCommand, "Associate_Safety_Certification", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Associate_Safety_Certification", DbType.String, this._Associate_Safety_Certification);
			
			if (string.IsNullOrEmpty(this._Vehicle_Lift_Safety))
				db.AddInParameter(dbCommand, "Vehicle_Lift_Safety", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Vehicle_Lift_Safety", DbType.String, this._Vehicle_Lift_Safety);
			
			if (string.IsNullOrEmpty(this._RCRA))
				db.AddInParameter(dbCommand, "RCRA", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "RCRA", DbType.String, this._RCRA);
			
			if (string.IsNullOrEmpty(this._Hazardous_Materials_Transportation))
				db.AddInParameter(dbCommand, "Hazardous_Materials_Transportation", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Hazardous_Materials_Transportation", DbType.String, this._Hazardous_Materials_Transportation);
			
			if (string.IsNullOrEmpty(this._Powered_Industrial_Trucks))
				db.AddInParameter(dbCommand, "Powered_Industrial_Trucks", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Powered_Industrial_Trucks", DbType.String, this._Powered_Industrial_Trucks);
			
			if (string.IsNullOrEmpty(this._Respiratory_Training))
				db.AddInParameter(dbCommand, "Respiratory_Training", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Respiratory_Training", DbType.String, this._Respiratory_Training);
			
			if (string.IsNullOrEmpty(this._Stormwater_Pollution))
				db.AddInParameter(dbCommand, "Stormwater_Pollution", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Stormwater_Pollution", DbType.String, this._Stormwater_Pollution);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the Sonic_U_Training_Required_Classes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Sonic_U_Training)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Training", DbType.Decimal, pK_Sonic_U_Training);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects a newly added Records
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectRecords()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesSelectRecords");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Import XML 
        /// </summary>
        /// <param name="xml"></param>
        public static void ImportXML(string xmlUpdate)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_Required_ClassesInsertXML");

            db.AddInParameter(dbCommand, "xmlUpdate", DbType.Xml, xmlUpdate);

            dbCommand.CommandTimeout = 10000;
            db.ExecuteNonQuery(dbCommand);
        }
	}
}

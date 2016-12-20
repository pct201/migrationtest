using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Sonic_U_Associate_Training_Manual table.
	/// </summary>
	public sealed class Sonic_U_Associate_Training_Manual
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sonic_U_Associate_Training_Manual;
		private decimal? _FK_Employee;
		private int? _Year;
		private int? _Train_Quarter;
		private decimal? _FK_Sonic_U_Training_Class;
		private bool? _Completed;
		private string _Updated_By;
		private DateTime? _Update_Date;
        private decimal? _FK_Location;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sonic_U_Associate_Training_Manual value.
		/// </summary>
		public decimal? PK_Sonic_U_Associate_Training_Manual
		{
			get { return _PK_Sonic_U_Associate_Training_Manual; }
			set { _PK_Sonic_U_Associate_Training_Manual = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Employee value.
		/// </summary>
		public decimal? FK_Employee
		{
			get { return _FK_Employee; }
			set { _FK_Employee = value; }
		}

		/// <summary>
		/// Gets or sets the Year value.
		/// </summary>
		public int? Year
		{
			get { return _Year; }
			set { _Year = value; }
		}

		/// <summary>
		/// Gets or sets the Train_Quarter value.
		/// </summary>
		public int? Train_Quarter
		{
			get { return _Train_Quarter; }
			set { _Train_Quarter = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Sonic_U_Training_Class value.
		/// </summary>
		public decimal? FK_Sonic_U_Training_Class
		{
			get { return _FK_Sonic_U_Training_Class; }
			set { _FK_Sonic_U_Training_Class = value; }
		}

		/// <summary>
		/// Gets or sets the Completed value.
		/// </summary>
		public bool? Completed
		{
			get { return _Completed; }
			set { _Completed = value; }
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
        /// Gets or sets the FK_Employee value.
        /// </summary>
        public decimal? FK_Location
        {
            get { return _FK_Location; }
            set { _FK_Location = value; }
        }


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Associate_Training_Manual class with default value.
		/// </summary>
		public Sonic_U_Associate_Training_Manual() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Associate_Training_Manual class based on Primary Key.
		/// </summary>
		public Sonic_U_Associate_Training_Manual(decimal pK_Sonic_U_Associate_Training_Manual) 
		{
			DataTable dtSonic_U_Associate_Training_Manual = SelectByPK(pK_Sonic_U_Associate_Training_Manual).Tables[0];

			if (dtSonic_U_Associate_Training_Manual.Rows.Count == 1)
			{
				 SetValue(dtSonic_U_Associate_Training_Manual.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sonic_U_Associate_Training_Manual class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSonic_U_Associate_Training_Manual) 
		{
				if (drSonic_U_Associate_Training_Manual["PK_Sonic_U_Associate_Training_Manual"] == DBNull.Value)
					this._PK_Sonic_U_Associate_Training_Manual = null;
				else
					this._PK_Sonic_U_Associate_Training_Manual = (decimal?)drSonic_U_Associate_Training_Manual["PK_Sonic_U_Associate_Training_Manual"];

				if (drSonic_U_Associate_Training_Manual["FK_Employee"] == DBNull.Value)
					this._FK_Employee = null;
				else
					this._FK_Employee = (decimal?)drSonic_U_Associate_Training_Manual["FK_Employee"];

                //if (drSonic_U_Associate_Training_Manual["FK_Location"] == DBNull.Value)
                //    this._FK_Location = null;
                //else
                //    this._FK_Location = (decimal?)drSonic_U_Associate_Training_Manual["FK_Location"];

				if (drSonic_U_Associate_Training_Manual["Year"] == DBNull.Value)
					this._Year = null;
				else
					this._Year = (int?)drSonic_U_Associate_Training_Manual["Year"];

				if (drSonic_U_Associate_Training_Manual["Train_Quarter"] == DBNull.Value)
					this._Train_Quarter = null;
				else
					this._Train_Quarter = (int?)drSonic_U_Associate_Training_Manual["Train_Quarter"];

				if (drSonic_U_Associate_Training_Manual["FK_Sonic_U_Training_Class"] == DBNull.Value)
					this._FK_Sonic_U_Training_Class = null;
				else
					this._FK_Sonic_U_Training_Class = (decimal?)drSonic_U_Associate_Training_Manual["FK_Sonic_U_Training_Class"];

				if (drSonic_U_Associate_Training_Manual["Completed"] == DBNull.Value)
					this._Completed = null;
				else
					this._Completed = (bool?)drSonic_U_Associate_Training_Manual["Completed"];

				if (drSonic_U_Associate_Training_Manual["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSonic_U_Associate_Training_Manual["Updated_By"];

				if (drSonic_U_Associate_Training_Manual["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSonic_U_Associate_Training_Manual["Update_Date"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sonic_U_Associate_Training_Manual table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Associate_Training_ManualInsert");

			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Train_Quarter", DbType.Int32, this._Train_Quarter);
			
			db.AddInParameter(dbCommand, "FK_Sonic_U_Training_Class", DbType.Decimal, this._FK_Sonic_U_Training_Class);
			
			db.AddInParameter(dbCommand, "Completed", DbType.Boolean, this._Completed);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, this._FK_Location);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the Sonic_U_Associate_Training_Manual table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		public DataSet SelectByPK(decimal pK_Sonic_U_Associate_Training_Manual)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Associate_Training_ManualSelectByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Associate_Training_Manual", DbType.Decimal, pK_Sonic_U_Associate_Training_Manual);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sonic_U_Associate_Training_Manual table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Associate_Training_ManualSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sonic_U_Associate_Training_Manual table.
		/// </summary>
		public int Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Associate_Training_ManualUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sonic_U_Associate_Training_Manual", DbType.Decimal, this._PK_Sonic_U_Associate_Training_Manual);
			
			db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, this._FK_Employee);

            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, this._FK_Location);
			
			db.AddInParameter(dbCommand, "Year", DbType.Int32, this._Year);
			
			db.AddInParameter(dbCommand, "Train_Quarter", DbType.Int32, this._Train_Quarter);
			
			db.AddInParameter(dbCommand, "FK_Sonic_U_Training_Class", DbType.Decimal, this._FK_Sonic_U_Training_Class);
			
			db.AddInParameter(dbCommand, "Completed", DbType.Boolean, this._Completed);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
		}

		/// <summary>
		/// Deletes a record from the Sonic_U_Associate_Training_Manual table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Sonic_U_Associate_Training_Manual,decimal fk_Location)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Associate_Training_ManualDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Associate_Training_Manual", DbType.Decimal, pK_Sonic_U_Associate_Training_Manual);
            db.AddInParameter(dbCommand, "FK_LU_Location_ID", DbType.Decimal, fk_Location);

			db.ExecuteNonQuery(dbCommand);
		}

        /// <summary>
        /// Selects all records from the Sonic_U_Associate_Training_Manual table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static int Sonic_U_Associate_Training_ManualDuplicateRecord(decimal FK_Employee, decimal Year, decimal Quarter, decimal FK_Sonic_U_Training_Class, bool Completed, decimal FK_Location)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Associate_Training_ManualDuplicateRecord");
            db.AddInParameter(dbCommand, "FK_Employee", DbType.Decimal, FK_Employee);
            db.AddInParameter(dbCommand, "Year", DbType.Decimal, Year);
            db.AddInParameter(dbCommand, "Quarter", DbType.Decimal, Quarter);
            db.AddInParameter(dbCommand, "FK_Sonic_U_Training_Class", DbType.Decimal, FK_Sonic_U_Training_Class);
            db.AddInParameter(dbCommand, "Completed", DbType.Boolean, Completed);
            db.AddInParameter(dbCommand, "FK_Location", DbType.Decimal, FK_Location);            

            //return db.ExecuteDataSet(dbCommand);
            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

	}
}

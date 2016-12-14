using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Sonic_U_Training_Classes table.
	/// </summary>
	public sealed class Sonic_U_Training_Classes
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Sonic_U_Training_Classes;
		private string _Class_Name;
		private string _Active;
		private DateTime? _Update_Date;
		private string _Updated_By;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Sonic_U_Training_Classes value.
		/// </summary>
		public decimal? PK_Sonic_U_Training_Classes
		{
			get { return _PK_Sonic_U_Training_Classes; }
			set { _PK_Sonic_U_Training_Classes = value; }
		}

		/// <summary>
		/// Gets or sets the Class_Name value.
		/// </summary>
		public string Class_Name
		{
			get { return _Class_Name; }
			set { _Class_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Active value.
		/// </summary>
		public string Active
		{
			get { return _Active; }
			set { _Active = value; }
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
		/// Gets or sets the Updated_By value.
		/// </summary>
		public string Updated_By
		{
			get { return _Updated_By; }
			set { _Updated_By = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Classes class with default value.
		/// </summary>
		public Sonic_U_Training_Classes() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Classes class based on Primary Key.
		/// </summary>
		public Sonic_U_Training_Classes(decimal pK_Sonic_U_Training_Classes) 
		{
			DataTable dtSonic_U_Training_Classes = SelectByPK(pK_Sonic_U_Training_Classes).Tables[0];

			if (dtSonic_U_Training_Classes.Rows.Count == 1)
			{
				 SetValue(dtSonic_U_Training_Classes.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the Sonic_U_Training_Classes class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drSonic_U_Training_Classes) 
		{
				if (drSonic_U_Training_Classes["PK_Sonic_U_Training_Classes"] == DBNull.Value)
					this._PK_Sonic_U_Training_Classes = null;
				else
					this._PK_Sonic_U_Training_Classes = (decimal?)drSonic_U_Training_Classes["PK_Sonic_U_Training_Classes"];

				if (drSonic_U_Training_Classes["Class_Name"] == DBNull.Value)
					this._Class_Name = null;
				else
					this._Class_Name = (string)drSonic_U_Training_Classes["Class_Name"];

				if (drSonic_U_Training_Classes["Active"] == DBNull.Value)
					this._Active = null;
				else
					this._Active = (string)drSonic_U_Training_Classes["Active"];

				if (drSonic_U_Training_Classes["Update_Date"] == DBNull.Value)
					this._Update_Date = null;
				else
					this._Update_Date = (DateTime?)drSonic_U_Training_Classes["Update_Date"];

				if (drSonic_U_Training_Classes["Updated_By"] == DBNull.Value)
					this._Updated_By = null;
				else
					this._Updated_By = (string)drSonic_U_Training_Classes["Updated_By"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the Sonic_U_Training_Classes table.
		/// </summary>
		/// <returns></returns>
		public decimal Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_ClassesInsert");

			
			if (string.IsNullOrEmpty(this._Class_Name))
				db.AddInParameter(dbCommand, "Class_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Class_Name", DbType.String, this._Class_Name);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

			// Execute the query and return the new identity value
            return Convert.ToDecimal(db.ExecuteScalar(dbCommand));
		}

		/// <summary>
		/// Selects a single record from the Sonic_U_Training_Classes table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet SelectByPK(decimal pK_Sonic_U_Training_Classes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_ClassesSelectByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Training_Classes", DbType.Decimal, pK_Sonic_U_Training_Classes);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Sonic_U_Training_Classes table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_ClassesSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the Sonic_U_Training_Classes table.
		/// </summary>
		public decimal Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_ClassesUpdate");

			
			db.AddInParameter(dbCommand, "PK_Sonic_U_Training_Classes", DbType.Decimal, this._PK_Sonic_U_Training_Classes);
			
			if (string.IsNullOrEmpty(this._Class_Name))
				db.AddInParameter(dbCommand, "Class_Name", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Class_Name", DbType.String, this._Class_Name);
			
			if (string.IsNullOrEmpty(this._Active))
				db.AddInParameter(dbCommand, "Active", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Active", DbType.String, this._Active);
			
			db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);
			
			if (string.IsNullOrEmpty(this._Updated_By))
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            return (Convert.ToDecimal(db.ExecuteScalar(dbCommand)));
		}

		/// <summary>
		/// Deletes a record from the Sonic_U_Training_Classes table by a composite primary key.
		/// </summary>
		public static void DeleteByPK(decimal pK_Sonic_U_Training_Classes)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Sonic_U_Training_ClassesDeleteByPK");

			db.AddInParameter(dbCommand, "PK_Sonic_U_Training_Classes", DbType.Decimal, pK_Sonic_U_Training_Classes);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}

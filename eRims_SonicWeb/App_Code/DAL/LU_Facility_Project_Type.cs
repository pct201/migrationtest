using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for table LU_Facility_Project_Type
	/// </summary>
	public sealed class LU_Facility_Project_Type
	{

		#region Private variables used to hold the property values

		private decimal? _PK_LU_Facility_Project_Type;
		private string _Type_Description;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the LU_Facility_Project_Type value.
		/// </summary>
		public decimal? PK_LU_Facility_Project_Type
		{
            get { return _PK_LU_Facility_Project_Type; }
            set { _PK_LU_Facility_Project_Type = value; }
		}

		/// <summary>
		/// Gets or sets the Type_Description value.
		/// </summary>
		public string Type_Description
		{
			get { return _Type_Description; }
			set { _Type_Description = value; }
		}


		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Project_Type class with default value.
		/// </summary>
		public LU_Facility_Project_Type() 
		{


		}

		#endregion

		#region Primary Constructors

		/// <summary>
		/// Initializes a new instance of the LU_Facility_Project_Type class based on Primary Key.
		/// </summary>
		public LU_Facility_Project_Type(decimal lU_Facility_Project_Type) 
		{
			DataTable dtLU_Facility_Project_Type = Select(lU_Facility_Project_Type).Tables[0];

			if (dtLU_Facility_Project_Type.Rows.Count == 1)
			{
				 SetValue(dtLU_Facility_Project_Type.Rows[0]);

			}

		}


		/// <summary>
		/// Initializes a new instance of the LU_Facility_Project_Type class based on Datarow passed.
		/// </summary>
		private void SetValue (DataRow drLU_Facility_Project_Type) 
		{
				if (drLU_Facility_Project_Type["LU_Facility_Project_Type"] == DBNull.Value)
                    this._PK_LU_Facility_Project_Type = null;
				else
                    this._PK_LU_Facility_Project_Type = (decimal?)drLU_Facility_Project_Type["LU_Facility_Project_Type"];

				if (drLU_Facility_Project_Type["Type_Description"] == DBNull.Value)
					this._Type_Description = null;
				else
					this._Type_Description = (string)drLU_Facility_Project_Type["Type_Description"];


		}

		#endregion

		/// <summary>
		/// Inserts a record into the LU_Facility_Project_Type table.
		/// </summary>
		/// <returns></returns>
		public int Insert()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Project_TypeInsert");

			
			if (string.IsNullOrEmpty(this._Type_Description))
				db.AddInParameter(dbCommand, "Type_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type_Description", DbType.String, this._Type_Description);

			// Execute the query and return the new identity value
			int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

			return returnValue;
		}

		/// <summary>
		/// Selects a single record from the LU_Facility_Project_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		private DataSet Select(decimal lU_Facility_Project_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Project_TypeSelect");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Project_Type", DbType.Decimal, lU_Facility_Project_Type);

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the LU_Facility_Project_Type table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Project_TypeSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Updates a record in the LU_Facility_Project_Type table.
		/// </summary>
		public void Update()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Project_TypeUpdate");


            db.AddInParameter(dbCommand, "PK_LU_Facility_Project_Type", DbType.Decimal, this._PK_LU_Facility_Project_Type);
			
			if (string.IsNullOrEmpty(this._Type_Description))
				db.AddInParameter(dbCommand, "Type_Description", DbType.String, DBNull.Value);
			else
				db.AddInParameter(dbCommand, "Type_Description", DbType.String, this._Type_Description);

			db.ExecuteNonQuery(dbCommand);
		}

		/// <summary>
		/// Deletes a record from the LU_Facility_Project_Type table by a composite primary key.
		/// </summary>
		public static void Delete(decimal lU_Facility_Project_Type)
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("LU_Facility_Project_TypeDelete");

            db.AddInParameter(dbCommand, "PK_LU_Facility_Project_Type", DbType.Decimal, lU_Facility_Project_Type);

			db.ExecuteNonQuery(dbCommand);
		}
	}
}

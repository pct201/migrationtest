using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Globalization;
using System.Collections.Generic;

namespace ERIMS.DAL
{
	/// <summary>
	/// Data access class for Business_Rules_Fields table.
	/// </summary>
	public sealed class clsBusiness_Rules_Fields
	{

		#region Private variables used to hold the property values

		private decimal? _PK_Business_Rules_Fields;
		private decimal? _FK_Buisness_Rules_Screens;
		private string _Table_Name;
		private string _Field_Name;
		private string _On_Screen_Descriptior;
		private int? _Field_Type;
        private bool _IsDollar;

		#endregion

		#region Public Property

		/// <summary>
		/// Gets or sets the PK_Business_Rules_Fields value.
		/// </summary>
		public decimal? PK_Business_Rules_Fields
		{
			get { return _PK_Business_Rules_Fields; }
			set { _PK_Business_Rules_Fields = value; }
		}

		/// <summary>
		/// Gets or sets the FK_Buisness_Rules_Screens value.
		/// </summary>
		public decimal? FK_Buisness_Rules_Screens
		{
			get { return _FK_Buisness_Rules_Screens; }
			set { _FK_Buisness_Rules_Screens = value; }
		}

		/// <summary>
		/// Gets or sets the Table_Name value.
		/// </summary>
		public string Table_Name
		{
			get { return _Table_Name; }
			set { _Table_Name = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Name value.
		/// </summary>
		public string Field_Name
		{
			get { return _Field_Name; }
			set { _Field_Name = value; }
		}

		/// <summary>
		/// Gets or sets the On_Screen_Descriptior value.
		/// </summary>
		public string On_Screen_Descriptior
		{
			get { return _On_Screen_Descriptior; }
			set { _On_Screen_Descriptior = value; }
		}

		/// <summary>
		/// Gets or sets the Field_Type value.
		/// </summary>
		public int? Field_Type
		{
			get { return _Field_Type; }
			set { _Field_Type = value; }
		}

        /// <summary>
        /// Gets or sets the IsDollar value.
        /// </summary>
        public bool IsDollar
        {
            get { return _IsDollar; }
            set { _IsDollar = value; }
        }

		#endregion

		#region Default Constructors

		/// <summary>
		/// Initializes a new instance of the clsBusiness_Rules_Fields class with default value.
		/// </summary>
		public clsBusiness_Rules_Fields() 
		{


		}

		#endregion

		#region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules_Fields class based on Primary Key.
        /// </summary>
        public clsBusiness_Rules_Fields(decimal pK_Business_Rules_Fields)
        {
            DataTable dtBusiness_Rules_Fields = SelectByPKConstructor(pK_Business_Rules_Fields).Tables[0];

            if (dtBusiness_Rules_Fields.Rows.Count == 1)
            {
                SetValue(dtBusiness_Rules_Fields.Rows[0]);

            }

        }


        /// <summary>
        /// Initializes a new instance of the clsBusiness_Rules_Fields class based on Datarow passed.
        /// </summary>
        private void SetValue(DataRow drBusiness_Rules_Fields)
        {
            if (drBusiness_Rules_Fields["PK_Business_Rules_Fields"] == DBNull.Value)
                this._PK_Business_Rules_Fields = null;
            else
                this._PK_Business_Rules_Fields = (decimal?)drBusiness_Rules_Fields["PK_Business_Rules_Fields"];

            if (drBusiness_Rules_Fields["FK_Buisness_Rules_Screens"] == DBNull.Value)
                this._FK_Buisness_Rules_Screens = null;
            else
                this._FK_Buisness_Rules_Screens = (decimal?)drBusiness_Rules_Fields["FK_Buisness_Rules_Screens"];

            if (drBusiness_Rules_Fields["Table_Name"] == DBNull.Value)
                this._Table_Name = null;
            else
                this._Table_Name = (string)drBusiness_Rules_Fields["Table_Name"];

            if (drBusiness_Rules_Fields["Field_Name"] == DBNull.Value)
                this._Field_Name = null;
            else
                this._Field_Name = (string)drBusiness_Rules_Fields["Field_Name"];

            if (drBusiness_Rules_Fields["On_Screen_Descriptior"] == DBNull.Value)
                this._On_Screen_Descriptior = null;
            else
                this._On_Screen_Descriptior = (string)drBusiness_Rules_Fields["On_Screen_Descriptior"];

            if (drBusiness_Rules_Fields["Field_Type"] == DBNull.Value)
                this._Field_Type = 0;
            else
                this._Field_Type = (int)drBusiness_Rules_Fields["Field_Type"];


        }

		#endregion

		/// <summary>
		/// Selects a single record from the Business_Rules_Fields table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
        public DataSet SelectByPKConstructor(decimal pK_Business_Rules_Fields)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_FieldsSelectByPK");

            db.AddInParameter(dbCommand, "PK_Business_Rules_Fields", DbType.Decimal, pK_Business_Rules_Fields);

            return db.ExecuteDataSet(dbCommand);
        }

		/// <summary>
		/// Selects a single record from the Business_Rules_Fields table by a primary key.
		/// </summary>
		/// <returns>DataSet</returns>
        public List<ERIMS.DAL.clsBusiness_Rules_Fields> SelectByPK(decimal pK_Business_Rules_Fields)
		{

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                List<ERIMS.DAL.clsBusiness_Rules_Fields> results = new List<ERIMS.DAL.clsBusiness_Rules_Fields>();
                ERIMS.DAL.clsBusiness_Rules_Fields objAdHoc;

                cmd = dbHelper.GetStoredProcCommand("Business_Rules_FieldsSelectByPK");
                dbHelper.AddInParameter(cmd, "PK_Business_Rules_Fields", DbType.Decimal, pK_Business_Rules_Fields);
                reader = dbHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    objAdHoc = MapFrom(reader);
                    results.Add(objAdHoc);
                }
                return results;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                reader.Close();
                reader = null;
                cmd = null;
                dbHelper = null;
            }

            //Database db = DatabaseFactory.CreateDatabase();
            //DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_FieldsSelectByPK");

            //db.AddInParameter(dbCommand, "PK_Business_Rules_Fields", DbType.Decimal, pK_Business_Rules_Fields);

            //return db.ExecuteDataSet(dbCommand);
		}

		/// <summary>
		/// Selects all records from the Business_Rules_Fields table.
		/// </summary>
		/// <returns>DataSet</returns>
		public static DataSet SelectAll()
		{
			Database db = DatabaseFactory.CreateDatabase();
			DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_FieldsSelectAll");

			return db.ExecuteDataSet(dbCommand);
		}

        /// <summary>
        /// Selects a single record from the Business_Rules_Fields table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet SelectByFK(decimal fK_Buisness_Rules_Screens)
        {

            //Database dbHelper = null;
            //DbCommand cmd = null;
            //IDataReader reader = null;
            //try
            //{
            //    dbHelper = DatabaseFactory.CreateDatabase();
            //    List<ERIMS_DAL.clsBusiness_Rules_Fields> results = new List<ERIMS_DAL.clsBusiness_Rules_Fields>();
            //    ERIMS_DAL.clsBusiness_Rules_Fields objAdHoc;

            //    cmd = dbHelper.GetStoredProcCommand("Business_Rules_FieldsSelectByFK");
            //    dbHelper.AddInParameter(cmd, "FK_Buisness_Rules_Screens", DbType.Decimal, fK_Buisness_Rules_Screens);
            //    reader = dbHelper.ExecuteReader(cmd);
            //    while (reader.Read())
            //    {
            //        objAdHoc = MapFrom(reader);
            //        results.Add(objAdHoc);
            //    }
            //    return results;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            //finally
            //{
            //    reader.Close();
            //    reader = null;
            //    cmd = null;
            //    dbHelper = null;
            //}

            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_FieldsSelectByFK");

            db.AddInParameter(dbCommand, "FK_Buisness_Rules_Screens", DbType.Decimal, fK_Buisness_Rules_Screens);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects a single record from the Business_Rules_Fields table by a foreign key.
        /// </summary>
        /// <returns>DataSet</returns>
        public DataSet SelectByFKAction(decimal fK_Buisness_Rules_Screens, bool IgnoreReadOnly)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Business_Rules_FieldsSelectByFKAction");

            db.AddInParameter(dbCommand, "FK_Buisness_Rules_Screens", DbType.Decimal, fK_Buisness_Rules_Screens);
            db.AddInParameter(dbCommand, "IgnoreReadOnly", DbType.Boolean, IgnoreReadOnly);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Map Reader Value to AdHiocReportFields 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected ERIMS.DAL.clsBusiness_Rules_Fields MapFrom(IDataReader reader)
        {
            ERIMS.DAL.clsBusiness_Rules_Fields objAdHoc = new ERIMS.DAL.clsBusiness_Rules_Fields();
            if (!Convert.IsDBNull(reader["PK_Business_Rules_Fields"])) { objAdHoc.PK_Business_Rules_Fields = Convert.ToDecimal(reader["PK_Business_Rules_Fields"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["FK_Buisness_Rules_Screens"])) { objAdHoc.FK_Buisness_Rules_Screens = Convert.ToInt32(reader["FK_Buisness_Rules_Screens"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["On_Screen_Descriptior"])) { objAdHoc.On_Screen_Descriptior = Convert.ToString(reader["On_Screen_Descriptior"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Field_Name"])) { objAdHoc.Field_Name = Convert.ToString(reader["Field_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objAdHoc.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Field_Type"])) { objAdHoc.Field_Type = Convert.ToInt16(reader["Field_Type"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["IsDollar"])) { objAdHoc.IsDollar = Convert.ToBoolean(reader["IsDollar"], CultureInfo.InvariantCulture); }
            return objAdHoc;
        }
	}
}

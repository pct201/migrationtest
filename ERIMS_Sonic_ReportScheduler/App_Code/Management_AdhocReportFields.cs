using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Globalization;

namespace ERIMS_DAL
{
    /// <summary>
    /// Summary description for Management_AdhocReportFields
    /// </summary>
    public class Management_AdhocReportFields
    {
        #region Private variables used to hold the property values

        private decimal? _PK_Management_AdhocReportFields;
        private int? _Fk_ControlType;
        private string _Table_Name;
        private string _Field_Name;
        private string _Field_Header;
        private string _WhereField;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_Management_AdhocReportFields value.
        /// </summary>
        public decimal? PK_Management_AdhocReportFields
        {
            get { return _PK_Management_AdhocReportFields; }
            set { _PK_Management_AdhocReportFields = value; }
        }

        /// <summary>
        /// Gets or sets the Fk_ControlType value.
        /// </summary>
        public int? Fk_ControlType
        {
            get { return _Fk_ControlType; }
            set { _Fk_ControlType = value; }
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
        /// Gets or sets the Field_Header value.
        /// </summary>
        public string Field_Header
        {
            get { return _Field_Header; }
            set { _Field_Header = value; }
        }


        /// <summary>
        /// Gets or sets the WhereField value.
        /// </summary>
        public string WhereField
        {
            get { return _WhereField; }
            set { _WhereField = value; }
        }

        #endregion

        public Management_AdhocReportFields()
        {
            _PK_Management_AdhocReportFields = null;
            _Fk_ControlType = null;
            _Table_Name = null;
            _Field_Header = null;
            _Field_Name = null;
            _WhereField = null;
        }

        /// <summary>
        /// Get AhHocReportField record based on PK_Management_AdhocReportFields
        /// </summary>
        /// <param name="PK_Management_AdhocReportFields"></param>
        /// <returns></returns>
        public List<Management_AdhocReportFields> GetAdHocReportFieldByPk(decimal PK_Management_AdhocReportFields)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                List<ERIMS_DAL.Management_AdhocReportFields> results = new List<ERIMS_DAL.Management_AdhocReportFields>();
                ERIMS_DAL.Management_AdhocReportFields objAdHoc;

                cmd = dbHelper.GetStoredProcCommand("Management_SelectAdHocReportField_ByPk");
                dbHelper.AddInParameter(cmd, "PK_Management_AdhocReportFields", DbType.Decimal, PK_Management_AdhocReportFields);
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

        }

        /// <summary>
        /// Get multiple AhHocReportField records based on CSV PK_Management_AdhocReportFields
        /// </summary>
        /// <param name="PK_Management_AdhocReportFields"></param>
        /// <returns></returns>
        public List<Management_AdhocReportFields> GetAdHocReportFieldByMultipleID(string PK_Management_AdhocReportFields)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {

                List<ERIMS_DAL.Management_AdhocReportFields> results = new List<ERIMS_DAL.Management_AdhocReportFields>();
                ERIMS_DAL.Management_AdhocReportFields objAdHoc = new ERIMS_DAL.Management_AdhocReportFields();

                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("Management_SelectAdHocReportWhereFileld");
                dbHelper.AddInParameter(cmd, "PK_Management_AdhocReportFields", DbType.String, PK_Management_AdhocReportFields);
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

        }

        /// <summary>
        /// Map Reader Value to AdHiocReportFields 
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        protected ERIMS_DAL.Management_AdhocReportFields MapFrom(IDataReader reader)
        {
            ERIMS_DAL.Management_AdhocReportFields objAdHoc = new ERIMS_DAL.Management_AdhocReportFields();
            if (!Convert.IsDBNull(reader["PK_Management_AdhocReportFields"])) { objAdHoc.PK_Management_AdhocReportFields = Convert.ToDecimal(reader["PK_Management_AdhocReportFields"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Fk_ControlType"])) { objAdHoc.Fk_ControlType = Convert.ToInt32(reader["Fk_ControlType"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Field_Header"])) { objAdHoc.Field_Header = Convert.ToString(reader["Field_Header"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Field_Name"])) { objAdHoc.Field_Name = Convert.ToString(reader["Field_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["Table_Name"])) { objAdHoc.Table_Name = Convert.ToString(reader["Table_Name"], CultureInfo.InvariantCulture); }
            if (!Convert.IsDBNull(reader["WhereField"])) { objAdHoc.WhereField = Convert.ToString(reader["WhereField"], CultureInfo.InvariantCulture); }
            return objAdHoc;
        }

        /// <summary>
        /// Get Ad Hoc Field Name Based on ID ,1 for Textfield and 2 for Dropdown
        /// </summary>
        /// <param name="strCoverage"></param>
        /// <param name="strFieldType"></param>
        ///  <param name="strTypes"></param>
        /// <returns></returns>
        public static DataSet GetAdHocFiled_Name(string strFilter)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_SelectAdHocReportWhereFileld");

            db.AddInParameter(dbCommand, "PK_Management_AdhocReportFields", DbType.String, strFilter);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Ad Hoc Field Name Based on Coverage Type
        /// </summary>
        /// <param name="strCoverage"></param>
        /// <param name="strFieldType"></param>
        /// <returns></returns>
        public static DataSet GetAdHocFields(string strCoverage, string strFieldType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_SelectAdHocReportFields");

            db.AddInParameter(dbCommand, "CoverageType", DbType.String, strCoverage);
            db.AddInParameter(dbCommand, "FieldType", DbType.String, strFieldType);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Get Ad Hoc Field Name Based on Coverage Type
        /// </summary>
        /// <param name="strCoverage"></param>
        /// <param name="strFieldType"></param>
        /// <returns></returns>
        public static DataSet GetAdHocFilterFields(string strCoverage, string strFieldType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Management_SelectAdHocFilterFields");

            db.AddInParameter(dbCommand, "CoverageType", DbType.String, strCoverage);
            db.AddInParameter(dbCommand, "FieldType", DbType.String, strFieldType);

            return db.ExecuteDataSet(dbCommand);
        }

    }
}
﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using System.Globalization;

namespace ERIMS.DAL
{
    public class ACI_AdhocReportFields
    {

        #region Private variables used to hold the property values

        private decimal? _Pk_AdhocReportFields;
        private int? _Fk_ControlType;
        private string _Table_Name;
        private string _Field_Name;
        private string _Field_Header;
        private string _WhereField;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the Pk_AdhocReportFields value.
        /// </summary>
        public decimal? Pk_AdhocReportFields
        {
            get { return _Pk_AdhocReportFields; }
            set { _Pk_AdhocReportFields = value; }
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

        /// <summary>
        /// Default Constructor
        /// </summary>
        public ACI_AdhocReportFields()
        {
            _Pk_AdhocReportFields = null;
            _Fk_ControlType = null;
            _Table_Name = null;
            _Field_Header = null;
            _Field_Name = null;
            _WhereField = null;
        }

        /// <summary>
        /// Get AhHocReportField record based on Pk_AdhocReportFields
        /// </summary>
        /// <param name="Pk_AdhocReportFields"></param>
        /// <returns></returns>
        public List<ACI_AdhocReportFields> GetAdHocReportFieldByPk(decimal Pk_AdhocReportFields)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {
                dbHelper = DatabaseFactory.CreateDatabase();
                List<ERIMS.DAL.ACI_AdhocReportFields> results = new List<ERIMS.DAL.ACI_AdhocReportFields>();
                ERIMS.DAL.ACI_AdhocReportFields objAdHoc;

                cmd = dbHelper.GetStoredProcCommand("ACI_SelectAdHocReportField_ByPk");
                dbHelper.AddInParameter(cmd, "Pk_AdhocReportFields", DbType.Decimal, Pk_AdhocReportFields);
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
        /// Get multiple AhHocReportField records based on CSV Pk_AdhocReportFields
        /// </summary>
        /// <param name="Pk_AdhocReportFields"></param>
        /// <returns></returns>
        public List<ACI_AdhocReportFields> GetAdHocReportFieldByMultipleID(string Pk_AdhocReportFields)
        {

            Database dbHelper = null;
            DbCommand cmd = null;
            IDataReader reader = null;
            try
            {

                List<ERIMS.DAL.ACI_AdhocReportFields> results = new List<ERIMS.DAL.ACI_AdhocReportFields>();
                ERIMS.DAL.ACI_AdhocReportFields objAdHoc = new ERIMS.DAL.ACI_AdhocReportFields();

                dbHelper = DatabaseFactory.CreateDatabase();
                cmd = dbHelper.GetStoredProcCommand("ACI_SelectAdHocReportWhereFileld");
                dbHelper.AddInParameter(cmd, "Pk_AdhocReportFields", DbType.String, Pk_AdhocReportFields);
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
        protected ERIMS.DAL.ACI_AdhocReportFields MapFrom(IDataReader reader)
        {
            ERIMS.DAL.ACI_AdhocReportFields objAdHoc = new ERIMS.DAL.ACI_AdhocReportFields();
            if (!Convert.IsDBNull(reader["Pk_AdhocReportFields"])) { objAdHoc.Pk_AdhocReportFields = Convert.ToDecimal(reader["Pk_AdhocReportFields"], CultureInfo.InvariantCulture); }
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
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_SelectAdHocReportWhereFileld");

            db.AddInParameter(dbCommand, "Pk_AdhocReportFields", DbType.String, strFilter);

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
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_SelectAdHocReportFiels");

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
            DbCommand dbCommand = db.GetStoredProcCommand("ACI_SelectAdHocFilterFileds");

            db.AddInParameter(dbCommand, "CoverageType", DbType.String, strCoverage);
            db.AddInParameter(dbCommand, "FieldType", DbType.String, strFieldType);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}

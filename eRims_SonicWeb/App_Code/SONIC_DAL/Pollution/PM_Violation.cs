using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for PM_Violation table.
    /// </summary>
    public sealed class PM_Violation
    {
        #region Private variables used to hold the property values

        private decimal? _PK_PM_Violation;
        private decimal? _FK_PM_Site_Information;
        private DateTime? _Date_Of_Violation;
        private string _Notifying_Agency;
        private string _Contact_Name;
        private string _Contact_Telephone;
        private decimal? _Cost;
        private string _Description_Of_Violations;
        private decimal? _Additional_Costs;
        private string _Additional_Costs_Description;
        private string _Updated_By;
        private DateTime? _Update_Date;
        private decimal? _Remediation_Cost;
        private decimal? _New_Equipment;
        private decimal? _Consulting_Fees;
        private decimal? _Attorney_Fees;
        private string _Regulatory_Entity;
        private decimal? _FK_LU_Regulatory_Agency;
        private string _Repeat_Violation;
        private decimal? _FK_LU_Regulatory_Notifying_Agency;
        private string _Other_Agency;
        private string _Apply_To_Location;

        #endregion

        #region Public Property

        /// <summary>
        /// Gets or sets the PK_PM_Violation value.
        /// </summary>
        public decimal? PK_PM_Violation
        {
            get { return _PK_PM_Violation; }
            set { _PK_PM_Violation = value; }
        }

        /// <summary>
        /// Gets or sets the FK_PM_Site_Information value.
        /// </summary>
        public decimal? FK_PM_Site_Information
        {
            get { return _FK_PM_Site_Information; }
            set { _FK_PM_Site_Information = value; }
        }

        /// <summary>
        /// Gets or sets the Date_Of_Violation value.
        /// </summary>
        public DateTime? Date_Of_Violation
        {
            get { return _Date_Of_Violation; }
            set { _Date_Of_Violation = value; }
        }

        /// <summary>
        /// Gets or sets the Notifying_Agency value.
        /// </summary>
        public string Notifying_Agency
        {
            get { return _Notifying_Agency; }
            set { _Notifying_Agency = value; }
        }

        /// <summary>
        /// Gets or sets the Contact_Name value.
        /// </summary>
        public string Contact_Name
        {
            get { return _Contact_Name; }
            set { _Contact_Name = value; }
        }

        public string Other_Agency
        {
            get { return _Other_Agency; }
            set { _Other_Agency = value; }
        }

        /// <summary>
        /// Gets or sets the Contact_Telephone value.
        /// </summary>
        public string Contact_Telephone
        {
            get { return _Contact_Telephone; }
            set { _Contact_Telephone = value; }
        }

        /// <summary>
        /// Gets or sets the Cost value.
        /// </summary>
        public decimal? Cost
        {
            get { return _Cost; }
            set { _Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Description_Of_Violations value.
        /// </summary>
        public string Description_Of_Violations
        {
            get { return _Description_Of_Violations; }
            set { _Description_Of_Violations = value; }
        }

        /// <summary>
        /// Gets or sets the Additional_Costs value.
        /// </summary>
        public decimal? Additional_Costs
        {
            get { return _Additional_Costs; }
            set { _Additional_Costs = value; }
        }

        /// <summary>
        /// Gets or sets the Additional_Costs_Description value.
        /// </summary>
        public string Additional_Costs_Description
        {
            get { return _Additional_Costs_Description; }
            set { _Additional_Costs_Description = value; }
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
        /// Remediation_Cost
        /// </summary>
        public decimal? Remediation_Cost
        {
            get { return _Remediation_Cost; }
            set { _Remediation_Cost = value; }
        }

        /// <summary>
        /// New_Equipment
        /// </summary>
        public decimal? New_Equipment
        {
            get { return _New_Equipment; }
            set { _New_Equipment = value; }
        }

        /// <summary>
        /// Consulting_Fees
        /// </summary>
        public decimal? Consulting_Fees
        {
            get { return _Consulting_Fees; }
            set { _Consulting_Fees = value; }
        }

        /// <summary>
        /// Attorney_Fees
        /// </summary>
        public decimal? Attorney_Fees
        {
            get { return _Attorney_Fees; }
            set { _Attorney_Fees = value; }
        }

        public decimal? FK_LU_Regulatory_Agency
        {
            get { return _FK_LU_Regulatory_Agency; }
            set { _FK_LU_Regulatory_Agency = value; }
        }

        public string Regulatory_Entity
        {
            get { return _Regulatory_Entity; }
            set { _Regulatory_Entity = value; }
        }

        public string Repeat_Violation
        {
            get { return _Repeat_Violation; }
            set { _Repeat_Violation = value; }
        }


        public decimal? FK_LU_Regulatory_Notifying_Agency
        {
            get { return _FK_LU_Regulatory_Notifying_Agency; }
            set { _FK_LU_Regulatory_Notifying_Agency = value; }
        }

        public string Apply_To_Location
        {
            get { return _Apply_To_Location; }
            set { _Apply_To_Location = value; }
        }
        #endregion

        #region Default Constructors

        /// <summary>
        /// Initializes a new instance of the PM_Violation class with default value.
        /// </summary>
        public PM_Violation()
        {
            this._PK_PM_Violation = null;
            this._FK_PM_Site_Information = null;
            this._Date_Of_Violation = null;
            this._Notifying_Agency = null;
            this._Contact_Name = null;
            this._Contact_Telephone = null;
            this._Cost = null;
            this._Description_Of_Violations = null;
            this._Updated_By = null;
            this._Update_Date = null;
            this._Remediation_Cost = null;
            this._New_Equipment = null;
            this._Consulting_Fees = null;
            this._Attorney_Fees = null;
            this._Regulatory_Entity = null;
            this._Repeat_Violation = null;
            this._FK_LU_Regulatory_Agency = null;
            this._FK_LU_Regulatory_Notifying_Agency = null;
            this._Other_Agency=null;
        }

        #endregion

        #region Primary Constructors

        /// <summary>
        /// Initializes a new instance of the PM_Violation class based on Primary Key.
        /// </summary>
        public PM_Violation(decimal pK_PM_Violation)
        {
            DataTable dtPM_Violation = SelectByPK(pK_PM_Violation).Tables[0];

            if (dtPM_Violation.Rows.Count == 1)
            {
                DataRow drPM_Violation = dtPM_Violation.Rows[0];
                                
                if (drPM_Violation["PK_PM_Violation"] == DBNull.Value)
                    this._PK_PM_Violation = null;
                else
                    this._PK_PM_Violation = (decimal?)drPM_Violation["PK_PM_Violation"];

                if (drPM_Violation["FK_PM_Site_Information"] == DBNull.Value)
                    this._FK_PM_Site_Information = null;
                else
                    this._FK_PM_Site_Information = (decimal?)drPM_Violation["FK_PM_Site_Information"];

                if (drPM_Violation["Date_Of_Violation"] == DBNull.Value)
                    this._Date_Of_Violation = null;
                else
                    this._Date_Of_Violation = (DateTime?)drPM_Violation["Date_Of_Violation"];

                if (drPM_Violation["Notifying_Agency"] == DBNull.Value)
                    this._Notifying_Agency = null;
                else
                    this._Notifying_Agency = (string)drPM_Violation["Notifying_Agency"];

                if (drPM_Violation["Contact_Name"] == DBNull.Value)
                    this._Contact_Name = null;
                else
                    this._Contact_Name = (string)drPM_Violation["Contact_Name"];

                if (drPM_Violation["Contact_Telephone"] == DBNull.Value)
                    this._Contact_Telephone = null;
                else
                    this._Contact_Telephone = (string)drPM_Violation["Contact_Telephone"];

                if (drPM_Violation["Cost"] == DBNull.Value)
                    this._Cost = null;
                else
                    this._Cost = (decimal?)drPM_Violation["Cost"];

                if (drPM_Violation["Description_Of_Violations"] == DBNull.Value)
                    this._Description_Of_Violations = null;
                else
                    this._Description_Of_Violations = (string)drPM_Violation["Description_Of_Violations"];

                if (drPM_Violation["Additional_Costs"] == DBNull.Value)
                    this._Additional_Costs = null;
                else
                    this._Additional_Costs = (decimal?)drPM_Violation["Additional_Costs"];

                if (drPM_Violation["Additional_Costs_Description"] == DBNull.Value)
                    this._Additional_Costs_Description = null;
                else
                    this._Additional_Costs_Description = (string)drPM_Violation["Additional_Costs_Description"];

                if (drPM_Violation["Updated_By"] == DBNull.Value)
                    this._Updated_By = null;
                else
                    this._Updated_By = (string)drPM_Violation["Updated_By"];

                if (drPM_Violation["Update_Date"] == DBNull.Value)
                    this._Update_Date = null;
                else
                    this._Update_Date = (DateTime?)drPM_Violation["Update_Date"];

                if (drPM_Violation["Remediation_Cost"] == DBNull.Value)
                    this._Remediation_Cost = null;
                else
                    this._Remediation_Cost = (decimal?)drPM_Violation["Remediation_Cost"];

                if (drPM_Violation["New_Equipment"] == DBNull.Value)
                    this._New_Equipment = null;
                else
                    this._New_Equipment = (decimal?)drPM_Violation["New_Equipment"];

                if (drPM_Violation["Consulting_Fees"] == DBNull.Value)
                    this._Consulting_Fees = null;
                else
                    this._Consulting_Fees = (decimal?)drPM_Violation["Consulting_Fees"];

                if (drPM_Violation["Attorney_Fees"] == DBNull.Value)
                    this._Attorney_Fees = null;
                else
                    this._Attorney_Fees = (decimal?)drPM_Violation["Attorney_Fees"];

                if (drPM_Violation["FK_LU_Regulatory_Agency"] == DBNull.Value)
                    this._FK_LU_Regulatory_Agency = null;
                else
                    this._FK_LU_Regulatory_Agency = (decimal?)drPM_Violation["FK_LU_Regulatory_Agency"];

                if (drPM_Violation["Regulatory_Entity"] == DBNull.Value)
                    this._Regulatory_Entity = null;
                else
                    this._Regulatory_Entity = (string)drPM_Violation["Regulatory_Entity"];

                if (drPM_Violation["Repeat_Violation"] == DBNull.Value)
                    this._Repeat_Violation = null;
                else
                    this._Repeat_Violation = (string)drPM_Violation["Repeat_Violation"];

                if (drPM_Violation["FK_LU_Regulatory_Notifying_Agency"] == DBNull.Value)
                    this._FK_LU_Regulatory_Notifying_Agency = null;
                else
                    this._FK_LU_Regulatory_Notifying_Agency = (decimal?)drPM_Violation["FK_LU_Regulatory_Notifying_Agency"];

                  if (drPM_Violation["Other_Agency"] == DBNull.Value)
                    this._Other_Agency = null;
                else
                    this._Other_Agency = (string)drPM_Violation["Other_Agency"];

                  if (drPM_Violation["Apply_To_Location"] == DBNull.Value)
                      this._Apply_To_Location = null;
                  else
                      this._Apply_To_Location = (string)drPM_Violation["Apply_To_Location"];
            }
            else
            {
                this._PK_PM_Violation = null;
                this._FK_PM_Site_Information = null;
                this._Date_Of_Violation = null;
                this._Notifying_Agency = null;
                this._Contact_Name = null;
                this._Contact_Telephone = null;
                this._Cost = null;
                this._Description_Of_Violations = null;
                this._Additional_Costs = null;
                this._Additional_Costs_Description = null;
                this._Updated_By = null;
                this._Update_Date = null;
                this._Remediation_Cost = null;
                this._New_Equipment = null;
                this._Consulting_Fees = null;
                this._Attorney_Fees = null;
                this._Regulatory_Entity = null;
                this._Repeat_Violation = null;
                this._FK_LU_Regulatory_Agency = null;
                this._FK_LU_Regulatory_Notifying_Agency = null;
                this._Other_Agency=null;
            }
        }

        #endregion

        /// <summary>
        /// Inserts a record into the PM_Violation table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_ViolationInsert");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);

            db.AddInParameter(dbCommand, "Date_Of_Violation", DbType.DateTime, this._Date_Of_Violation);

            if (string.IsNullOrEmpty(this._Notifying_Agency))
                db.AddInParameter(dbCommand, "Notifying_Agency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notifying_Agency", DbType.String, this._Notifying_Agency);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Contact_Telephone))
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);

            db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);

            if (string.IsNullOrEmpty(this._Description_Of_Violations))
                db.AddInParameter(dbCommand, "Description_Of_Violations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description_Of_Violations", DbType.String, this._Description_Of_Violations);

            db.AddInParameter(dbCommand, "Additional_Costs", DbType.Decimal, this._Additional_Costs);

            if (string.IsNullOrEmpty(this._Additional_Costs_Description))
                db.AddInParameter(dbCommand, "Additional_Costs_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Costs_Description", DbType.String, this._Additional_Costs_Description);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Remediation_Cost", DbType.Decimal, this._Remediation_Cost);
            db.AddInParameter(dbCommand, "New_Equipment", DbType.Decimal, this._New_Equipment);
            db.AddInParameter(dbCommand, "Consulting_Fees", DbType.Decimal, this._Consulting_Fees);
            db.AddInParameter(dbCommand, "Attorney_Fees", DbType.Decimal, this._Attorney_Fees);

            if (string.IsNullOrEmpty(this._Regulatory_Entity))
                db.AddInParameter(dbCommand, "Regulatory_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regulatory_Entity", DbType.String, this._Regulatory_Entity);
            db.AddInParameter(dbCommand, "FK_LU_Regulatory_Agency", DbType.Decimal, this._FK_LU_Regulatory_Agency);
            if (string.IsNullOrEmpty(this._Repeat_Violation))
                db.AddInParameter(dbCommand, "Repeat_Violation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repeat_Violation", DbType.String, this._Repeat_Violation);

            db.AddInParameter(dbCommand, "FK_LU_Regulatory_Notifying_Agency", DbType.Decimal, this._FK_LU_Regulatory_Notifying_Agency);
               if (string.IsNullOrEmpty(this._Other_Agency))
                db.AddInParameter(dbCommand, "Other_Agency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Agency", DbType.String, this._Other_Agency);

               if (string.IsNullOrEmpty(this._Apply_To_Location))
                   db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
               else
                   db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Selects a single record from the PM_Violation table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        private static DataSet SelectByPK(decimal pK_PM_Violation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_ViolationSelectByPK");

            db.AddInParameter(dbCommand, "PK_PM_Violation", DbType.Decimal, pK_PM_Violation);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Selects all records from the PM_Violation table.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataSet SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_ViolationSelectAll");

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Updates a record in the PM_Violation table.
        /// </summary>
        public int Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_ViolationUpdate");

            db.AddInParameter(dbCommand, "PK_PM_Violation", DbType.Decimal, this._PK_PM_Violation);

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, this._FK_PM_Site_Information);

            db.AddInParameter(dbCommand, "Date_Of_Violation", DbType.DateTime, this._Date_Of_Violation);

            if (string.IsNullOrEmpty(this._Notifying_Agency))
                db.AddInParameter(dbCommand, "Notifying_Agency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Notifying_Agency", DbType.String, this._Notifying_Agency);

            if (string.IsNullOrEmpty(this._Contact_Name))
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Name", DbType.String, this._Contact_Name);

            if (string.IsNullOrEmpty(this._Contact_Telephone))
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Contact_Telephone", DbType.String, this._Contact_Telephone);

            db.AddInParameter(dbCommand, "Cost", DbType.Decimal, this._Cost);

            if (string.IsNullOrEmpty(this._Description_Of_Violations))
                db.AddInParameter(dbCommand, "Description_Of_Violations", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Description_Of_Violations", DbType.String, this._Description_Of_Violations);

            db.AddInParameter(dbCommand, "Additional_Costs", DbType.Decimal, this._Additional_Costs);

            if (string.IsNullOrEmpty(this._Additional_Costs_Description))
                db.AddInParameter(dbCommand, "Additional_Costs_Description", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Additional_Costs_Description", DbType.String, this._Additional_Costs_Description);

            if (string.IsNullOrEmpty(this._Updated_By))
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Updated_By", DbType.String, this._Updated_By);

            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, this._Update_Date);

            db.AddInParameter(dbCommand, "Remediation_Cost", DbType.Decimal, this._Remediation_Cost);
            db.AddInParameter(dbCommand, "New_Equipment", DbType.Decimal, this._New_Equipment);
            db.AddInParameter(dbCommand, "Consulting_Fees", DbType.Decimal, this._Consulting_Fees);
            db.AddInParameter(dbCommand, "Attorney_Fees", DbType.Decimal, this._Attorney_Fees);
            if (string.IsNullOrEmpty(this._Regulatory_Entity))
                db.AddInParameter(dbCommand, "Regulatory_Entity", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Regulatory_Entity", DbType.String, this._Regulatory_Entity);
            db.AddInParameter(dbCommand, "FK_LU_Regulatory_Agency", DbType.Decimal, this._FK_LU_Regulatory_Agency);
            if (string.IsNullOrEmpty(this._Repeat_Violation))
                db.AddInParameter(dbCommand, "Repeat_Violation", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Repeat_Violation", DbType.String, this._Repeat_Violation);

            db.AddInParameter(dbCommand, "FK_LU_Regulatory_Notifying_Agency", DbType.Decimal, this._FK_LU_Regulatory_Notifying_Agency);

               if (string.IsNullOrEmpty(this._Other_Agency))
                db.AddInParameter(dbCommand, "Other_Agency", DbType.String, DBNull.Value);
            else
                db.AddInParameter(dbCommand, "Other_Agency", DbType.String, this._Other_Agency);

               if (string.IsNullOrEmpty(this._Apply_To_Location))
                   db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, DBNull.Value);
               else
                   db.AddInParameter(dbCommand, "Apply_To_Location", DbType.String, this._Apply_To_Location);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Deletes a record from the PM_Violation table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_PM_Violation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_ViolationDeleteByPK");

            db.AddInParameter(dbCommand, "PK_PM_Violation", DbType.Decimal, pK_PM_Violation);

            db.ExecuteNonQuery(dbCommand);
        }

        public static DataSet SelectByFK_SiteInfo(decimal fK_PM_Site_Information)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_ViolationSelectByFK");

            db.AddInParameter(dbCommand, "FK_PM_Site_Information", DbType.Decimal, fK_PM_Site_Information);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// Get Audit View details
        /// </summary>
        /// <param name="pK_PM_SI_Utility_Provider"></param>
        /// <returns></returns>
        public static DataSet GetAuditView(decimal pK_PM_Violation)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("PM_Violation_AuditView");

            db.AddInParameter(dbCommand, "PK_PM_Violation", DbType.Decimal, pK_PM_Violation);

            return db.ExecuteDataSet(dbCommand);
        }
    }
}

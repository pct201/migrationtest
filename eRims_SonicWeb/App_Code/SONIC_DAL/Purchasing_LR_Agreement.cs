using System;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace ERIMS.DAL
{
    /// <summary>
    /// Data access class for Investigation table.
    /// </summary>
    public sealed class Purchasing_LR_Agreement
    {
        #region Fields
        private decimal pK_Purchasing_LR_Agreement;
        private string supplier;
        private decimal fK_LU_Equipment_Type;
        private string payment_Terms;
        private decimal buyout;
        private string late_Fee;
        private decimal fK_LU_LR_Type;
        private decimal leased_Amount;
        private string lease_Rate;
        private string lease_Rate_Time_Period;
        private string end_Of_Lease_Options;
        private Nullable<DateTime> start_Date;
        private Nullable<DateTime> end_Date;
        private decimal term_In_Months;
        private Nullable<DateTime> notification_Date;
        private decimal monthly_Cost;
        private decimal annual_Cost;
        private decimal total_Committed;
        private string customer_contract_number;
        private decimal fK_LU_Auto_Renew;
        private string auto_Renew_Other;
        private string renewal_Terms;
        private string notification_Terms;
        private string applicable_Dealers;
        private decimal fK_LU_Dealership_Department;
        private decimal fK_LU_Location;
        private decimal fK_LU_Service_Contract;
        private string _COI_Needed;
        private string updated_By;
        private DateTime update_Date;
        private string status;
        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the Purchasing_LR_Agreement class.
        /// </summary>
        public Purchasing_LR_Agreement()
        {
        }

        /// <summary>
        /// Initializes a new instance of the Purchasing_LR_Agreement class by PK
        /// </summary>
        public Purchasing_LR_Agreement(decimal pK_Purchasing_LR_Agreement)
        {
            try
            {
                DataTable dt = SelectByPK(pK_Purchasing_LR_Agreement);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    clsGeneral.SetDefaultValuesForDBNull(dr);

                    PK_Purchasing_LR_Agreement = pK_Purchasing_LR_Agreement;
                    supplier = dr["supplier"].ToString();
                    fK_LU_Equipment_Type = Convert.ToDecimal(dr["fK_LU_Equipment_Type"].ToString());
                    payment_Terms = dr["payment_Terms"].ToString();
                    buyout = Convert.ToDecimal(dr["buyout"].ToString());
                    late_Fee = dr["late_Fee"].ToString();
                    fK_LU_LR_Type = Convert.ToDecimal(dr["fK_LU_LR_Type"].ToString());
                    leased_Amount = Convert.ToDecimal(dr["leased_Amount"].ToString());
                    lease_Rate = dr["lease_Rate"].ToString();
                    lease_Rate_Time_Period = dr["lease_Rate_Time_Period"].ToString();
                    end_Of_Lease_Options = dr["end_Of_Lease_Options"].ToString();
                    start_Date = Convert.ToDateTime(dr["start_Date"].ToString());
                    end_Date = Convert.ToDateTime(dr["end_Date"].ToString());
                    term_In_Months = Convert.ToDecimal(dr["term_In_Months"].ToString());
                    notification_Date = Convert.ToDateTime(dr["notification_Date"].ToString());
                    monthly_Cost = Convert.ToDecimal(dr["monthly_Cost"].ToString());
                    annual_Cost = Convert.ToDecimal(dr["annual_Cost"].ToString());
                    total_Committed = Convert.ToDecimal(dr["total_Committed"].ToString());
                    customer_contract_number = Convert.ToString(dr["customer_contract_number"]);
                    fK_LU_Auto_Renew = Convert.ToDecimal(dr["fK_LU_Auto_Renew"].ToString());
                    auto_Renew_Other = dr["auto_Renew_Other"].ToString();
                    renewal_Terms = dr["renewal_Terms"].ToString();
                    notification_Terms = dr["notification_Terms"].ToString();
                    applicable_Dealers = dr["applicable_Dealers"].ToString();
                    fK_LU_Dealership_Department = Convert.ToDecimal(dr["fK_LU_Dealership_Department"].ToString());
                    fK_LU_Location = Convert.ToDecimal(dr["fK_LU_Location"].ToString());
                    status = dr["Status"].ToString();
                    fK_LU_Service_Contract = Convert.ToDecimal(dr["fK_LU_Service_Contract"].ToString());
                    if (string.IsNullOrEmpty(Convert.ToString(dr["COI_Needed"])))
                        _COI_Needed = "N";
                    else
                        _COI_Needed = Convert.ToString(dr["COI_Needed"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the PK_Purchasing_LR_Agreement value.
        /// </summary>
        public decimal PK_Purchasing_LR_Agreement
        {
            get { return pK_Purchasing_LR_Agreement; }
            set { pK_Purchasing_LR_Agreement = value; }
        }

        /// <summary>
        /// Gets or sets the Supplier value.
        /// </summary>
        public string Supplier
        {
            get { return supplier; }
            set { supplier = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Equipment_Type value.
        /// </summary>
        public decimal FK_LU_Equipment_Type
        {
            get { return fK_LU_Equipment_Type; }
            set { fK_LU_Equipment_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Payment_Terms value.
        /// </summary>
        public string Payment_Terms
        {
            get { return payment_Terms; }
            set { payment_Terms = value; }
        }

        /// <summary>
        /// Gets or sets the Buyout value.
        /// </summary>
        public decimal Buyout
        {
            get { return buyout; }
            set { buyout = value; }
        }

        /// <summary>
        /// Gets or sets the Late_Fee value.
        /// </summary>
        public string Late_Fee
        {
            get { return late_Fee; }
            set { late_Fee = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_LR_Type value.
        /// </summary>
        public decimal FK_LU_LR_Type
        {
            get { return fK_LU_LR_Type; }
            set { fK_LU_LR_Type = value; }
        }

        /// <summary>
        /// Gets or sets the Leased_Amount value.
        /// </summary>
        public decimal Leased_Amount
        {
            get { return leased_Amount; }
            set { leased_Amount = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Rate value.
        /// </summary>
        public string Lease_Rate
        {
            get { return lease_Rate; }
            set { lease_Rate = value; }
        }

        /// <summary>
        /// Gets or sets the Lease_Rate_Time_Period value. 
        /// </summary>
        public string Lease_Rate_Time_Period
        {
            get { return lease_Rate_Time_Period; }
            set { lease_Rate_Time_Period = value; }
        }

        /// <summary>
        /// Gets or sets the End_Of_Lease_Options value.
        /// </summary>
        public string End_Of_Lease_Options
        {
            get { return end_Of_Lease_Options; }
            set { end_Of_Lease_Options = value; }
        }

        /// <summary>
        /// Gets or sets the Start_Date value.
        /// </summary>
        public Nullable<DateTime> Start_Date
        {
            get { return start_Date; }
            set { start_Date = value; }
        }

        /// <summary>
        /// Gets or sets the End_Date value.
        /// </summary>
        public Nullable<DateTime> End_Date
        {
            get { return end_Date; }
            set { end_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Term_In_Months value.
        /// </summary>
        public decimal Term_In_Months
        {
            get { return term_In_Months; }
            set { term_In_Months = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Date value.
        /// </summary>
        public Nullable<DateTime> Notification_Date
        {
            get { return notification_Date; }
            set { notification_Date = value; }
        }

        /// <summary>
        /// Gets or sets the Monthly_Cost value.
        /// </summary>
        public decimal Monthly_Cost
        {
            get { return monthly_Cost; }
            set { monthly_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Annual_Cost value.
        /// </summary>
        public decimal Annual_Cost
        {
            get { return annual_Cost; }
            set { annual_Cost = value; }
        }

        /// <summary>
        /// Gets or sets the Total_Committed value.
        /// </summary>
        public decimal Total_Committed
        {
            get { return total_Committed; }
            set { total_Committed = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Auto_Renew value.
        /// </summary>
        public decimal FK_LU_Auto_Renew
        {
            get { return fK_LU_Auto_Renew; }
            set { fK_LU_Auto_Renew = value; }
        }

        /// <summary>
        /// Gets or sets the Auto_Renew_Other value.
        /// </summary>
        public string Customer_Contract_Number
        {
            get { return customer_contract_number; }
            set { customer_contract_number = value; }
        }

        /// <summary>
        /// Gets or sets the Auto_Renew_Other value.
        /// </summary>
        public string Auto_Renew_Other
        {
            get { return auto_Renew_Other; }
            set { auto_Renew_Other = value; }
        }

        /// <summary>
        /// Gets or sets the Renewal_Terms value.
        /// </summary>
        public string Renewal_Terms
        {
            get { return renewal_Terms; }
            set { renewal_Terms = value; }
        }

        /// <summary>
        /// Gets or sets the Notification_Terms value.
        /// </summary>
        public string Notification_Terms
        {
            get { return notification_Terms; }
            set { notification_Terms = value; }
        }

        /// <summary>
        /// Gets or sets the Applicable_Dealers value.
        /// </summary>
        public string Applicable_Dealers
        {
            get { return applicable_Dealers; }
            set { applicable_Dealers = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Dealership_Department value.
        /// </summary>
        public decimal FK_LU_Dealership_Department
        {
            get { return fK_LU_Dealership_Department; }
            set { fK_LU_Dealership_Department = value; }
        }

        /// <summary>
        /// Gets or sets the FK_LU_Location value.
        /// </summary>
        public decimal FK_LU_Location
        {
            get { return fK_LU_Location; }
            set { fK_LU_Location = value; }
        }

        /// <summary>
        /// Gets or sets the Updated_By value.
        /// </summary>
        public string Updated_By
        {
            get { return updated_By; }
            set { updated_By = value; }
        }

        /// <summary>
        /// Gets or sets the Update_Date value.
        /// </summary>
        public DateTime Update_Date
        {
            get { return update_Date; }
            set { update_Date = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        /// <summary>
        /// Gets or sets the FK_LU_Service_Contract value.
        /// </summary>
        public decimal FK_LU_Service_Contract
        {
            get { return fK_LU_Service_Contract; }
            set { fK_LU_Service_Contract = value; }
        }

        /// <summary>
        /// Gets or sets the COI_Needed value.
        /// </summary>
        public string COI_Needed
        {
            get { return _COI_Needed; }
            set { _COI_Needed = value; }
        }

        #endregion

        #region "Methods"

        /// <summary>
        /// Selects a single record from the Purchasing_LR_Agreement table by a primary key.
        /// </summary>
        /// <returns>DataSet</returns>
        public static DataTable SelectByPK(decimal pK_Purchasing_LR_Agreement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AgreementSelectByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, pK_Purchasing_LR_Agreement);

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Inserts a record into the Purchasing_LR_Agreement table.
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AgreementInsert");

            db.AddInParameter(dbCommand, "Supplier", DbType.String, supplier);
            db.AddInParameter(dbCommand, "FK_LU_Equipment_Type", DbType.Decimal, fK_LU_Equipment_Type);
            db.AddInParameter(dbCommand, "Payment_Terms", DbType.String, payment_Terms);
            db.AddInParameter(dbCommand, "Buyout", DbType.Decimal, buyout);
            db.AddInParameter(dbCommand, "Late_Fee", DbType.String, late_Fee);
            db.AddInParameter(dbCommand, "FK_LU_LR_Type", DbType.Decimal, fK_LU_LR_Type);
            db.AddInParameter(dbCommand, "Leased_Amount", DbType.Decimal, leased_Amount);
            db.AddInParameter(dbCommand, "Lease_Rate", DbType.String, lease_Rate);
            db.AddInParameter(dbCommand, "Lease_Rate_Time_Period", DbType.String, lease_Rate_Time_Period);
            db.AddInParameter(dbCommand, "End_Of_Lease_Options", DbType.String, end_Of_Lease_Options);
            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, start_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, end_Date);
            db.AddInParameter(dbCommand, "Term_In_Months", DbType.Decimal, term_In_Months);
            db.AddInParameter(dbCommand, "Notification_Date", DbType.DateTime, notification_Date);
            db.AddInParameter(dbCommand, "Monthly_Cost", DbType.Decimal, monthly_Cost);
            db.AddInParameter(dbCommand, "Annual_Cost", DbType.Decimal, annual_Cost);
            db.AddInParameter(dbCommand, "Total_Committed", DbType.Decimal, total_Committed);
            db.AddInParameter(dbCommand, "customer_contract_number", DbType.String, customer_contract_number);
            db.AddInParameter(dbCommand, "FK_LU_Auto_Renew", DbType.Decimal, fK_LU_Auto_Renew);
            db.AddInParameter(dbCommand, "Auto_Renew_Other", DbType.String, auto_Renew_Other);
            db.AddInParameter(dbCommand, "Renewal_Terms", DbType.String, renewal_Terms);
            db.AddInParameter(dbCommand, "Notification_Terms", DbType.String, notification_Terms);
            db.AddInParameter(dbCommand, "Applicable_Dealers", DbType.String, applicable_Dealers);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, fK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fK_LU_Location);
            //db.AddInParameter(dbCommand, "Supplier_Contact_Name", DbType.String, supplier_Contact_Name);
            //db.AddInParameter(dbCommand, "Supplier_Title", DbType.String, supplier_Title);
            //db.AddInParameter(dbCommand, "Supplier_Address_1", DbType.String, supplier_Address_1);
            //db.AddInParameter(dbCommand, "Supplier_Address_2", DbType.String, supplier_Address_2);
            //db.AddInParameter(dbCommand, "Supplier_City", DbType.String, supplier_City);
            //db.AddInParameter(dbCommand, "FK_State_Supplier", DbType.Decimal, fK_State_Supplier);
            //db.AddInParameter(dbCommand, "Supplier_ZIP_Code", DbType.String, supplier_ZIP_Code);
            //db.AddInParameter(dbCommand, "Supplier_Work_Telephone", DbType.String, supplier_Work_Telephone);
            //db.AddInParameter(dbCommand, "Supplier_Cell_Telephone", DbType.String, supplier_Cell_Telephone);
            //db.AddInParameter(dbCommand, "Supplier_Facsimile", DbType.String, supplier_Facsimile);
            //db.AddInParameter(dbCommand, "Supplier_Email", DbType.String, supplier_Email);
            //db.AddInParameter(dbCommand, "Supplier_Notes", DbType.String, supplier_Notes);
            //db.AddInParameter(dbCommand, "Sonic_Contact_Name", DbType.String, sonic_Contact_Name);
            //db.AddInParameter(dbCommand, "Sonic_Title", DbType.String, sonic_Title);
            //db.AddInParameter(dbCommand, "Sonic_Address_1", DbType.String, sonic_Address_1);
            //db.AddInParameter(dbCommand, "Sonic_Address_2", DbType.String, sonic_Address_2);
            //db.AddInParameter(dbCommand, "Sonic_City", DbType.String, sonic_City);
            //db.AddInParameter(dbCommand, "FK_State_Sonic", DbType.Decimal, fK_State_Sonic);
            //db.AddInParameter(dbCommand, "Sonic_ZIP_Code", DbType.String, sonic_ZIP_Code);
            //db.AddInParameter(dbCommand, "Sonic_Work_Telephone", DbType.String, sonic_Work_Telephone);
            //db.AddInParameter(dbCommand, "Sonic_Cell_Telephone", DbType.String, sonic_Cell_Telephone);
            //db.AddInParameter(dbCommand, "Sonic_Facsimile", DbType.String, sonic_Facsimile);
            //db.AddInParameter(dbCommand, "Sonic_Email", DbType.String, sonic_Email);
            //db.AddInParameter(dbCommand, "Sonic_Notes", DbType.String, sonic_Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Status", DbType.String, status);
            db.AddInParameter(dbCommand, "FK_LU_Service_Contract", DbType.Decimal, this.fK_LU_Service_Contract);
            db.AddInParameter(dbCommand, "COI_Needed", DbType.String, _COI_Needed);

            // Execute the query and return the new identity value
            int returnValue = Convert.ToInt32(db.ExecuteScalar(dbCommand));

            return returnValue;
        }

        /// <summary>
        /// Inserts a record into the Purchasing_Service_Contract table.
        /// </summary>
        /// <returns></returns>
        public void Update()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AgreementUpdate");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, pK_Purchasing_LR_Agreement);
            db.AddInParameter(dbCommand, "Supplier", DbType.String, supplier);
            db.AddInParameter(dbCommand, "FK_LU_Equipment_Type", DbType.Decimal, fK_LU_Equipment_Type);
            db.AddInParameter(dbCommand, "Payment_Terms", DbType.String, payment_Terms);
            db.AddInParameter(dbCommand, "Buyout", DbType.Decimal, buyout);
            db.AddInParameter(dbCommand, "Late_Fee", DbType.String, late_Fee);
            db.AddInParameter(dbCommand, "FK_LU_LR_Type", DbType.Decimal, fK_LU_LR_Type);
            db.AddInParameter(dbCommand, "Leased_Amount", DbType.Decimal, leased_Amount);
            db.AddInParameter(dbCommand, "Lease_Rate", DbType.String, lease_Rate);
            db.AddInParameter(dbCommand, "Lease_Rate_Time_Period", DbType.String, lease_Rate_Time_Period);
            db.AddInParameter(dbCommand, "End_Of_Lease_Options", DbType.String, end_Of_Lease_Options);
            db.AddInParameter(dbCommand, "Start_Date", DbType.DateTime, start_Date);
            db.AddInParameter(dbCommand, "End_Date", DbType.DateTime, end_Date);
            db.AddInParameter(dbCommand, "Term_In_Months", DbType.Decimal, term_In_Months);
            db.AddInParameter(dbCommand, "Notification_Date", DbType.DateTime, notification_Date);
            db.AddInParameter(dbCommand, "Monthly_Cost", DbType.Decimal, monthly_Cost);
            db.AddInParameter(dbCommand, "Annual_Cost", DbType.Decimal, annual_Cost);
            db.AddInParameter(dbCommand, "Total_Committed", DbType.Decimal, total_Committed);
            db.AddInParameter(dbCommand, "customer_contract_number", DbType.String, customer_contract_number);
            db.AddInParameter(dbCommand, "FK_LU_Auto_Renew", DbType.Decimal, fK_LU_Auto_Renew);
            db.AddInParameter(dbCommand, "Auto_Renew_Other", DbType.String, auto_Renew_Other);
            db.AddInParameter(dbCommand, "Renewal_Terms", DbType.String, renewal_Terms);
            db.AddInParameter(dbCommand, "Notification_Terms", DbType.String, notification_Terms);
            db.AddInParameter(dbCommand, "Applicable_Dealers", DbType.String, applicable_Dealers);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, fK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "FK_LU_Location", DbType.Decimal, fK_LU_Location);
            //db.AddInParameter(dbCommand, "Supplier_Contact_Name", DbType.String, supplier_Contact_Name);
            //db.AddInParameter(dbCommand, "Supplier_Title", DbType.String, supplier_Title);
            //db.AddInParameter(dbCommand, "Supplier_Address_1", DbType.String, supplier_Address_1);
            //db.AddInParameter(dbCommand, "Supplier_Address_2", DbType.String, supplier_Address_2);
            //db.AddInParameter(dbCommand, "Supplier_City", DbType.String, supplier_City);
            //db.AddInParameter(dbCommand, "FK_State_Supplier", DbType.Decimal, fK_State_Supplier);
            //db.AddInParameter(dbCommand, "Supplier_ZIP_Code", DbType.String, supplier_ZIP_Code);
            //db.AddInParameter(dbCommand, "Supplier_Work_Telephone", DbType.String, supplier_Work_Telephone);
            //db.AddInParameter(dbCommand, "Supplier_Cell_Telephone", DbType.String, supplier_Cell_Telephone);
            //db.AddInParameter(dbCommand, "Supplier_Facsimile", DbType.String, supplier_Facsimile);
            //db.AddInParameter(dbCommand, "Supplier_Email", DbType.String, supplier_Email);
            //db.AddInParameter(dbCommand, "Supplier_Notes", DbType.String, supplier_Notes);
            //db.AddInParameter(dbCommand, "Sonic_Contact_Name", DbType.String, sonic_Contact_Name);
            //db.AddInParameter(dbCommand, "Sonic_Title", DbType.String, sonic_Title);
            //db.AddInParameter(dbCommand, "Sonic_Address_1", DbType.String, sonic_Address_1);
            //db.AddInParameter(dbCommand, "Sonic_Address_2", DbType.String, sonic_Address_2);
            //db.AddInParameter(dbCommand, "Sonic_City", DbType.String, sonic_City);
            //db.AddInParameter(dbCommand, "FK_State_Sonic", DbType.Decimal, fK_State_Sonic);
            //db.AddInParameter(dbCommand, "Sonic_ZIP_Code", DbType.String, sonic_ZIP_Code);
            //db.AddInParameter(dbCommand, "Sonic_Work_Telephone", DbType.String, sonic_Work_Telephone);
            //db.AddInParameter(dbCommand, "Sonic_Cell_Telephone", DbType.String, sonic_Cell_Telephone);
            //db.AddInParameter(dbCommand, "Sonic_Facsimile", DbType.String, sonic_Facsimile);
            //db.AddInParameter(dbCommand, "Sonic_Email", DbType.String, sonic_Email);
            //db.AddInParameter(dbCommand, "Sonic_Notes", DbType.String, sonic_Notes);
            db.AddInParameter(dbCommand, "Updated_By", DbType.String, updated_By);
            db.AddInParameter(dbCommand, "Update_Date", DbType.DateTime, update_Date);
            db.AddInParameter(dbCommand, "Status", DbType.String, status);
            db.AddInParameter(dbCommand, "FK_LU_Service_Contract", DbType.Decimal, this.fK_LU_Service_Contract);
            db.AddInParameter(dbCommand, "COI_Needed", DbType.String, _COI_Needed);
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Select Unique Contact information of Supplier
        /// </summary>
        /// <returns></returns>
        public static DataTable SupplierContactSelect()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Supplier_Contact_Select");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select Unique Contact information of Supplier
        /// </summary>
        /// <returns></returns>
        public static DataTable SonicContactSelect()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Sonic_Contact_Select");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// Select Contact information of Supplier by selected value
        /// </summary>
        /// <returns></returns>
        public static DataSet SupplierContactSelectByValue(string strSupplierContactInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Supplier_Contact_Select_By_Value");
            db.AddInParameter(dbCommand, "Supplier_Contact_Info", DbType.String, strSupplierContactInfo);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Select Contact information of Sonic by selected value
        /// </summary>
        /// <returns></returns>
        public static DataSet SonicContactSelectByValue(string strSonicContactInfo)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Sonic_Contact_Select_By_Value");
            db.AddInParameter(dbCommand, "Sonic_Contact_Info", DbType.String, strSonicContactInfo);

            return db.ExecuteDataSet(dbCommand);
        }
        /// <summary>
        /// select service contract by id
        /// </summary>
        /// <returns></returns>
        public static DataTable Purchasing_LRAggrementSelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AgreementSelectAll");

            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        /// <summary>
        /// select by serach criteria
        /// </summary>
        /// <returns></returns>
        public static DataSet Purchasing_LRAgreementSearch(Nullable<DateTime> dtStartDateFrom, Nullable<DateTime> dtStartDateTo, Nullable<DateTime> dtEndDateFrom, Nullable<DateTime> dtEndDateTo,
            string Region, decimal FK_LU_Location_Id, decimal FK_LU_Equipment_Type, decimal FK_LU_Dealership_Department, string Supplier, string strOrderBy, string strOrder, int intPageNo, int intPageSize, bool? bIsUserAdmin, string strIsCorporateUser)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Agreement_Search");
            db.AddInParameter(dbCommand, "dtStartDateFrom", DbType.DateTime, dtStartDateFrom);
            db.AddInParameter(dbCommand, "dtStartDateTo", DbType.DateTime, dtStartDateTo);
            db.AddInParameter(dbCommand, "dtEndDateFrom", DbType.DateTime, dtEndDateFrom);
            db.AddInParameter(dbCommand, "dtEndDateTo", DbType.DateTime, dtEndDateTo);
            db.AddInParameter(dbCommand, "Region", DbType.String, Region);
            db.AddInParameter(dbCommand, "FK_LU_Location_Id", DbType.Decimal, FK_LU_Location_Id);
            db.AddInParameter(dbCommand, "FK_LU_Equipment_Type", DbType.Decimal, FK_LU_Equipment_Type);
            db.AddInParameter(dbCommand, "FK_LU_Dealership_Department", DbType.Decimal, FK_LU_Dealership_Department);
            db.AddInParameter(dbCommand, "Supplier", DbType.String, Supplier);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.String, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.String, intPageSize);
            db.AddInParameter(dbCommand, "PK_Security_ID", DbType.Decimal, clsSession.UserID);
            db.AddInParameter(dbCommand, "bIsUserAdmin", DbType.Boolean, bIsUserAdmin);
            db.AddInParameter(dbCommand, "bIsCorporateUser", DbType.String, strIsCorporateUser);
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Deletes a record from the Purchasing_LR_Agreement table by a composite primary key.
        /// </summary>
        public static void DeleteByPK(decimal pK_Purchasing_LR_Agreement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_AgreementDeleteByPK");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, pK_Purchasing_LR_Agreement);

            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// select contact information for Generate Abstract Report
        /// </summary>
        /// <param name="pK_Purchasing_Service_Contract"></param>
        /// <returns></returns>
        public static DataSet GetLR_AgreementAbstract(decimal PK_Purchasing_LR_Agreement)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_LR_Agreement_GetAbstract");

            db.AddInParameter(dbCommand, "PK_Purchasing_LR_Agreement", DbType.Decimal, PK_Purchasing_LR_Agreement);

            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// select contact information for Generate Abstract Report
        /// </summary>
        /// <param name="pK_Purchasing_Service_Contract"></param>
        /// <returns></returns>
        public static DataTable GetPurchasing_SonicAndSupplier_ContactInformation(decimal FK_Table_Name, decimal FK_Contact_Type, string SearchType)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("Purchasing_Select_ContactInformation");

            db.AddInParameter(dbCommand, "FK_Table_Name", DbType.Decimal, FK_Table_Name);
            db.AddInParameter(dbCommand, "FK_Contact_Type", DbType.Decimal, FK_Contact_Type);
            db.AddInParameter(dbCommand, "SearchType", DbType.String, SearchType);
            return db.ExecuteDataSet(dbCommand).Tables[0];
        }

        public static DataSet SearchByPaging(string strContactName, string strTitle, string strAddress1, string strCity, string strState, string strContactType, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ContactInformation_Search");

            db.AddInParameter(dbCommand, "strContactName", DbType.String, strContactName);
            db.AddInParameter(dbCommand, "strTitle", DbType.String, strTitle);
            db.AddInParameter(dbCommand, "strAddress1", DbType.String, strAddress1);
            db.AddInParameter(dbCommand, "strCity", DbType.String, strCity);
            db.AddInParameter(dbCommand, "strState", DbType.String, strState);
            db.AddInParameter(dbCommand, "strContactType", DbType.String, strContactType);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }

        public static DataSet SearchByContactMangePaging(string strContactName, string strTitle, string strAddress1, string strCity, string strState, string strContactType, string strOrderBy, string strOrder, int intPageNo, int intPageSize)
        {
            Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetStoredProcCommand("ContactInformation_ManageContactSearch");

            db.AddInParameter(dbCommand, "strContactName", DbType.String, strContactName);
            db.AddInParameter(dbCommand, "strTitle", DbType.String, strTitle);
            db.AddInParameter(dbCommand, "strAddress1", DbType.String, strAddress1);
            db.AddInParameter(dbCommand, "strCity", DbType.String, strCity);
            db.AddInParameter(dbCommand, "strState", DbType.String, strState);
            db.AddInParameter(dbCommand, "strContactType", DbType.String, strContactType);
            db.AddInParameter(dbCommand, "strOrderBy", DbType.String, strOrderBy);
            db.AddInParameter(dbCommand, "strOrder", DbType.String, strOrder);
            db.AddInParameter(dbCommand, "intPageNo", DbType.Int32, intPageNo);
            db.AddInParameter(dbCommand, "intPageSize", DbType.Int32, intPageSize);

            return db.ExecuteDataSet(dbCommand);
        }
        #endregion
    }
}

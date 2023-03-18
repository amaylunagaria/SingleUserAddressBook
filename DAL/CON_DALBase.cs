using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MultiUserAB.Areas.CON_Contact.Models;

namespace MultiUserAB.DAL
{
    public class CON_DALBase : DALHelper
    {
        #region PR_CON_Contact_SelectAll

        public DataTable PR_CON_Contact_SelectAll()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_CON_Contact_SelectAll");
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_CON_Contact_DeleteByPK

        public Boolean PR_CON_Contact_DeleteByPK(int ContactID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_CON_Contact_DeleteByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "ContactID", DbType.Int32, ContactID);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_CON_Contact_SelectByPK

        public DataTable PR_CON_Contact_SelectByPK(int? ContactID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_CON_Contact_SelectByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, ContactID);
                DataTable dt = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    dt.Load(dr);
                }
                return dt;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_CON_Contact_Insert

        public Boolean PR_CON_Contact_Insert(CON_ContactModel modelCON_Contact)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_CON_Contact_Insert");
                SQL_DB.AddInParameter(DataBaseCommand, "Name", DbType.String, modelCON_Contact.Name);
                SQL_DB.AddInParameter(DataBaseCommand, "Mobile", DbType.String, modelCON_Contact.Mobile);
                SQL_DB.AddInParameter(DataBaseCommand, "Address", DbType.String, modelCON_Contact.Address);
                SQL_DB.AddInParameter(DataBaseCommand, "Email", DbType.String, modelCON_Contact.Email);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, modelCON_Contact.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "StateID", DbType.Int32, modelCON_Contact.StateID);
                SQL_DB.AddInParameter(DataBaseCommand, "CityID", DbType.Int32, modelCON_Contact.CityID);
                SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryID", DbType.Int32, modelCON_Contact.ContactCategoryID);
                SQL_DB.AddInParameter(DataBaseCommand, "PhotoPath", DbType.String, modelCON_Contact.PhotoPath);
                SQL_DB.AddInParameter(DataBaseCommand, "CreationDate", DbType.DateTime, DBNull.Value);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_CON_Contact_UpdateByPK

        public Boolean PR_CON_Contact_UpdateByPK(CON_ContactModel modelCON_Contact)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_CON_Contact_UpdateByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, modelCON_Contact.ContactID);
                SQL_DB.AddInParameter(DataBaseCommand, "Name", DbType.String, modelCON_Contact.Name);
                SQL_DB.AddInParameter(DataBaseCommand, "Mobile", DbType.String, modelCON_Contact.Mobile);
                SQL_DB.AddInParameter(DataBaseCommand, "Address", DbType.String, modelCON_Contact.Address);
                SQL_DB.AddInParameter(DataBaseCommand, "Email", DbType.String, modelCON_Contact.Email);
                SQL_DB.AddInParameter(DataBaseCommand, "CountryID", DbType.Int32, modelCON_Contact.CountryID);
                SQL_DB.AddInParameter(DataBaseCommand, "StateID", DbType.Int32, modelCON_Contact.StateID);
                SQL_DB.AddInParameter(DataBaseCommand, "CityID", DbType.Int32, modelCON_Contact.CityID);
                SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryID", DbType.Int32, modelCON_Contact.ContactCategoryID);
                SQL_DB.AddInParameter(DataBaseCommand, "ModificationDate", DbType.DateTime, DBNull.Value);
                SQL_DB.AddInParameter(DataBaseCommand, "PhotoPath", DbType.String, modelCON_Contact.PhotoPath);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_MST_ContactCategory_SelectfromDropDown
        public DataTable PR_MST_ContactCategory_SelectfromDropDown()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_SelectfromDropDown");

                DataTable DataTB = new DataTable();
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion

        #region PR_CON_Contact_Filter

        public DataTable PR_CON_Contact_Filter(string CityName, string StateName, string CountryName, string Name, string ContactCategoryName)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_CON_Contact_Filter");
                DataTable DataTB = new DataTable();
                if (CountryName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CountryName", DbType.String, CountryName);


                if (StateName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "StateName", DbType.String, StateName);


                if (CityName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "CityName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "CityName", DbType.String, CityName);


                if (Name == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "Name", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "Name", DbType.String, Name);


                if (ContactCategoryName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryName", DbType.String, ContactCategoryName);
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion

        #region PR_MST_ContactCategory_Filter

        public DataTable PR_MST_ContactCategory_Filter(string ContactCategoryName)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_Filter");
                DataTable DataTB = new DataTable();
                if (ContactCategoryName == null)
                    SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryName", DbType.String, DBNull.Value);
                else
                    SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryName", DbType.String, ContactCategoryName);
                using (IDataReader dr = SQL_DB.ExecuteReader(DataBaseCommand))
                {
                    DataTB.Load(dr);
                }

                return DataTB;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        #endregion
    }
}

using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using MultiUserAB.Areas.MST_ContactCategory.Models;

namespace MultiUserAB.DAL
{
    public class MST_DALBase : DALHelper
    {
        #region PR_MST_ContactCategory_SelectAll

        public DataTable PR_MST_ContactCategory_SelectAll()
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_SelectAll");
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

        #region PR_MST_ContactCategory_DeleteByPK

        public Boolean PR_MST_ContactCategory_DeleteByPK(int ContactCategoryID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_DeleteByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryID", DbType.Int32, ContactCategoryID);
                Boolean result = Convert.ToBoolean(SQL_DB.ExecuteNonQuery(DataBaseCommand));
                return result;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        #endregion

        #region PR_MST_ContactCategory_SelectByPK

        public DataTable PR_MST_ContactCategory_SelectByPK(int? ContactCategoryID)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_SelectByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, ContactCategoryID);
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

        #region PR_MST_ContactCategory_Insert

        public Boolean PR_MST_ContactCategory_Insert(MST_ContactCategoryModel modelMST_ContactCategory)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_Insert");
                SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryName", DbType.String, modelMST_ContactCategory.ContactCategoryName);
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

        #region PR_MST_ContactCategory_UpdateByPK

        public Boolean PR_MST_ContactCategory_UpdateByPK(MST_ContactCategoryModel modelMST_ContactCategory)
        {
            try
            {
                SqlDatabase SQL_DB = new SqlDatabase(ConnectionString);
                DbCommand DataBaseCommand = SQL_DB.GetStoredProcCommand("PR_MST_ContactCategory_UpdateByPK");
                SQL_DB.AddInParameter(DataBaseCommand, "getID", DbType.Int32, modelMST_ContactCategory.ContactCategoryID);
                SQL_DB.AddInParameter(DataBaseCommand, "ContactCategoryName", DbType.String, modelMST_ContactCategory.ContactCategoryName);
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
    }
}

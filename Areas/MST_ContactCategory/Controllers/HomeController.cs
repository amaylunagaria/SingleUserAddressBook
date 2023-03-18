using Microsoft.AspNetCore.Mvc;
using MultiUserAB.DAL;
using MultiUserAB.Areas.MST_ContactCategory.Models;
using System.Data;

namespace MultiUserAB.Areas.MST_ContactCategory.Controllers
{
    [Area("MST_ContactCategory")]
    [Route("MST_ContactCategory/[controller]/[action]")]
    public class HomeController : Controller
    {
        MST_DAL dalMST = new MST_DAL();

        #region Index
        public IActionResult Index()
        {
            DataTable dt = dalMST.PR_MST_ContactCategory_SelectAll();
            return View("Index", dt);
        }
        #endregion Index

        #region Add/Edit

        public IActionResult Add_Edit(int? ContactCategoryID)
        {
            if (ContactCategoryID != null)
            {
                DataTable dt = dalMST.PR_MST_ContactCategory_SelectByPK(ContactCategoryID);

                MST_ContactCategoryModel modelMST_ContactCategory = new MST_ContactCategoryModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelMST_ContactCategory.ContactCategoryID = Convert.ToInt32(dr["ContactCategoryID"]);
                    modelMST_ContactCategory.ContactCategoryName = dr["ContactCategoryName"].ToString();
                    modelMST_ContactCategory.Created = Convert.ToDateTime(dr["CreationDate"]);
                    modelMST_ContactCategory.Modified = Convert.ToDateTime(dr["ModificationDate"]);

                }
                return View("MST_ContactCategoryAddList", modelMST_ContactCategory);
            }
            return View("MST_ContactCategoryAddList");
        }

        #endregion Save

        #region Delete

        public IActionResult Delete(int ContactCategoryID)
        {
            Boolean result = dalMST.PR_MST_ContactCategory_DeleteByPK(ContactCategoryID);
            return RedirectToAction("Index");
        }

        #endregion Delete

        #region Save

        [HttpPost]
        public IActionResult Save(MST_ContactCategoryModel modelMST_ContactCategory)
        {
            Boolean result;

            if (modelMST_ContactCategory.ContactCategoryID == null)
            {
                result = dalMST.PR_MST_ContactCategory_Insert(modelMST_ContactCategory);
            }
            else
            {
                result = dalMST.PR_MST_ContactCategory_UpdateByPK(modelMST_ContactCategory);
            }

            return RedirectToAction("Index");
        }
        #endregion Save

        #region Filter
        public IActionResult Filter(string ContactCategoryName)
        {
            CON_DAL dalCON = new CON_DAL();
            DataTable DataTB = dalCON.PR_MST_ContactCategory_Filter(ContactCategoryName);

            return View("Index", DataTB);
        }
        #endregion
    }
}

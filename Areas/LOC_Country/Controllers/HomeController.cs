using Microsoft.AspNetCore.Mvc;
using MultiUserAB.DAL;
using System.Data;
using MultiUserAB.Areas.LOC_Country.Models;

namespace MultiUserAB.Areas.LOC_Country.Controllers
{
    [Area("LOC_Country")]
    [Route("LOC_Country/[controller]/[action]")]
    public class HomeController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region ShowAll(SelectAll)
        public IActionResult Index()
        {

            DataTable dt = dalLOC.PR_LOC_Country_SelectAll();
            return View("Index", dt);
        }
        #endregion ShowAll(SelectAll)

        #region Add/Edit

        public IActionResult Add_Edit(int? CountryID)
        {
            if (CountryID != null)
            {

                DataTable dt = dalLOC.PR_LOC_Country_SelectByPK(CountryID);

                LOC_CountryModel modelLOC_Country = new LOC_CountryModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_Country.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_Country.CountryName = dr["CountryName"].ToString();
                    modelLOC_Country.CountryCode = dr["CountryCode"].ToString();
                    modelLOC_Country.Created = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_Country.Modified = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_CountryAddList", modelLOC_Country);
            }
            return View("LOC_CountryAddList");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int CountryID)
        {

            Boolean result = dalLOC.PR_LOC_Country_DeleteByPK(CountryID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(LOC_CountryModel modelLOC_Country)
        {

            Boolean result;
            if (modelLOC_Country.CountryID == null)
            {
                result = dalLOC.PR_LOC_Country_Insert(modelLOC_Country);
            }
            else
            {
                result = dalLOC.PR_LOC_Country_UpdateByPK(modelLOC_Country);
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Filter
        public IActionResult Filter(string CountryName, string CountryCode)
        {

            DataTable DataTB = dalLOC.PR_LOC_Country_Filter(CountryName, CountryCode);

            return View("Index", DataTB);
        }
        #endregion
    }
}

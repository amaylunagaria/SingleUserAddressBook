using Microsoft.AspNetCore.Mvc;
using MultiUserAB.Areas.CON_Contact.Models;
using MultiUserAB.Areas.LOC_State.Models;
using MultiUserAB.DAL;
using System.Data;

namespace MultiUserAB.Areas.LOC_State.Controllers
{
    [Area("LOC_State")]
    [Route("LOC_State/[controller]/[action]")]
    public class HomeController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region Index

        public IActionResult Index()
        {
            DataTable dt = dalLOC.PR_LOC_State_SelectAll();
            return View("Index", dt);
        }

        #endregion

        #region Delete

        public IActionResult Delete(int StateID)
        {
            Boolean result = dalLOC.PR_LOC_State_DeleteByPK(StateID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Add/Edit

        public IActionResult Add_Edit(int? StateID)
        {
            DataTable DataTB = dalLOC.PR_LOC_Country_SelectfromDropDown();

            List<LOC_CountryDropDown> CountryList = new List<LOC_CountryDropDown>();
            foreach (DataRow d in DataTB.Rows)
            {
                LOC_CountryDropDown list = new LOC_CountryDropDown();
                list.CountryID = Convert.ToInt32(d["CountryID"]);
                list.CountryName = (d["CountryName"]).ToString();
                CountryList.Add(list);
            }
            ViewBag.CountryList = CountryList;


            if (StateID != null)
            {
                DataTable dt = dalLOC.PR_LOC_State_SelectByPK(StateID);

                LOC_StateModel modelLOC_State = new LOC_StateModel();

                foreach (DataRow dr in dt.Rows)
                {
                    modelLOC_State.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_State.StateName = dr["StateName"].ToString();
                    modelLOC_State.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_State.Created = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_State.Modified = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_StateAddList", modelLOC_State);
            }
            return View("LOC_StateAddList");
        }

        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(LOC_StateModel modelLOC_State)
        {
            Boolean result;

            if (modelLOC_State.StateID == null)
            {
                result = dalLOC.PR_LOC_State_Insert(modelLOC_State);
            }
            else
            {
                result = dalLOC.PR_LOC_State_UpdateByPK(modelLOC_State);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region Filter
        public IActionResult Filter(string StateName, string CountryName)
        {
            DataTable DataTB = dalLOC.PR_LOC_State_Filter(StateName, CountryName);

            return View("Index", DataTB);
        }

        #endregion
    }
}

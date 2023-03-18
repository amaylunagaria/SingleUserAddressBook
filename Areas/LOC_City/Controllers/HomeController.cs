using Microsoft.AspNetCore.Mvc;
using MultiUserAB.Areas.LOC_City.Models;
using MultiUserAB.Areas.CON_Contact.Models;
using MultiUserAB.DAL;
using System.Data;

namespace MultiUserAB.Areas.LOC_City.Controllers
{
    [Area("LOC_City")]
    [Route("LOC_City/[controller]/[action]")]
    public class HomeController : Controller
    {
        LOC_DAL dalLOC = new LOC_DAL();

        #region Index
        public IActionResult Index()
        {
            DataTable dt = dalLOC.PR_LOC_City_SelectAll();
            return View("Index", dt);
        }

        #endregion

        #region Add/Edit
        public IActionResult Add_Edit(int? CityID)
        {
            #region Country

            DataTable DataTB = dalLOC.PR_LOC_Country_SelectfromDropDown();

            List<LOC_CountryDropDown> CountryDDlist = new List<LOC_CountryDropDown>();
            ViewBag.CountryList = CountryDDlist;

            foreach (DataRow d in DataTB.Rows)
            {
                LOC_CountryDropDown list = new LOC_CountryDropDown();
                list.CountryID = Convert.ToInt32(d["CountryID"]);
                list.CountryName = (d["CountryName"]).ToString();
                CountryDDlist.Add(list);
            }
            ViewBag.CountryList = CountryDDlist;
            #endregion Country

            List<LOC_StateDropDownModel> StateDDlist = new List<LOC_StateDropDownModel>();
            ViewBag.StateList = StateDDlist;


            if (CityID != null)
            {
                DataTable dt = dalLOC.PR_LOC_City_SelectByPK(CityID);

                LOC_CityModel modelLOC_City = new LOC_CityModel();

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownByCountry(Convert.ToInt32(dr["CountryID"]));
                    modelLOC_City.CityID = Convert.ToInt32(dr["CityID"]);
                    modelLOC_City.CityName = dr["CityName"].ToString();
                    modelLOC_City.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelLOC_City.StateID = Convert.ToInt32(dr["StateID"]);
                    modelLOC_City.Created = Convert.ToDateTime(dr["CreationDate"]);
                    modelLOC_City.Modified = Convert.ToDateTime(dr["ModificationDate"]);
                }
                return View("LOC_CityAddList", modelLOC_City);
            }
            return View("LOC_CityAddList");
        }
        #endregion Add

        #region Delete
        public IActionResult Delete(int CityID)
        {
            Boolean result = dalLOC.PR_LOC_City_DeleteByPK(CityID);
            return RedirectToAction("Index");
        }
        #endregion Delete

        #region Save

        [HttpPost]
        public IActionResult Save(LOC_CityModel modelLOC_City)
        {
            Boolean result = false;

            if (modelLOC_City.CityID == null)
            {
                result = dalLOC.PR_LOC_City_Insert(modelLOC_City);
            }
            else
            {
                result = dalLOC.PR_LOC_City_UpdateByPK(modelLOC_City);
            }
            return RedirectToAction("Index");
        }
        #endregion Save

        #region DropDown from Country

        [HttpPost]
        public IActionResult DropDownByCountry(int CountryID)
        {
            DataTable DataTB = dalLOC.PR_LOC_State_SelectForDropDownByCountryID(CountryID);

            List<LOC_StateDropDownModel> Statelist = new List<LOC_StateDropDownModel>();
            ViewBag.StateList = Statelist;
            foreach (DataRow dr in DataTB.Rows)
            {
                LOC_StateDropDownModel list = new LOC_StateDropDownModel();
                list.StateID = Convert.ToInt32(dr["StateID"]);
                list.StateName = (dr["StateName"]).ToString();
                Statelist.Add(list);
            }
            var statemodel = Statelist;
            ViewBag.StateList = Statelist;
            return Json(statemodel);
        }

        #endregion

        #region Filter
        public IActionResult Filter(string CountryName, string StateName, string CityName)
        {
            DataTable DataTB = dalLOC.PR_LOC_City_Filter(CityName, StateName, CountryName);

            return View("Index", DataTB);
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Mvc;
using MultiUserAB.Areas.CON_Contact.Models;
using MultiUserAB.DAL;
using System.Data;

namespace MultiUserAB.Areas.CON_Contact.Controllers
{
    [Area("CON_Contact")]
    [Route("CON_Contact/[controller]/[action]")]
    public class HomeController : Controller
    {
        CON_DAL dalCON = new CON_DAL();

        #region Index
        public IActionResult Index()
        {
            DataTable dt = dalCON.PR_CON_Contact_SelectAll();

            return View("Index", dt);
        }

        #endregion

        #region Add/Edit

        public IActionResult Add_Edit(int? ContactID)
        {

            LOC_DAL dalLOC = new LOC_DAL();
            DataTable DataTB = dalLOC.PR_LOC_Country_SelectfromDropDown();

            #region Country

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

            List<LOC_StateDropDownModel> StateList = new List<LOC_StateDropDownModel>();
            ViewBag.StateList = StateList;

            List<LOC_CityDropDownModel> CityList = new List<LOC_CityDropDownModel>();
            ViewBag.CityList = CityList;

            #region ContactCategory


            DataTable DataTBContactCategory = dalCON.PR_MST_ContactCategory_SelectfromDropDown();

            List<MST_ContactCategoryDropDownModel> ContactCategoryDDlist = new List<MST_ContactCategoryDropDownModel>();
            foreach (DataRow dr in DataTBContactCategory.Rows)
            {
                MST_ContactCategoryDropDownModel MST_ContactCategoryDropDown = new MST_ContactCategoryDropDownModel();
                MST_ContactCategoryDropDown.ContactCategoryID = Convert.ToInt32(dr["ContactCategoryID"]);
                MST_ContactCategoryDropDown.ContactCategoryName = (dr["ContactCategoryName"]).ToString();
                ContactCategoryDDlist.Add(MST_ContactCategoryDropDown);
            }
            ViewBag.ContactCategoryList = ContactCategoryDDlist;

            #endregion


            if (ContactID != null)
            {
                DataTable dt = dalCON.PR_CON_Contact_SelectByPK(ContactID);

                CON_ContactModel modelCON_Contact = new CON_ContactModel();
                modelCON_Contact.CountryID = 0;

                foreach (DataRow dr in dt.Rows)
                {
                    DropDownByCountry(Convert.ToInt32(dr["CountryID"]));
                    DropDownByState(Convert.ToInt32(dr["StateID"]));
                    modelCON_Contact.ContactID = Convert.ToInt32(dr["ContactID"]);
                    modelCON_Contact.Name = dr["Name"].ToString();
                    modelCON_Contact.Mobile = dr["Mobile"].ToString();
                    modelCON_Contact.Address = dr["Address"].ToString();
                    modelCON_Contact.Email = dr["Email"].ToString();
                    modelCON_Contact.CityID = Convert.ToInt32(dr["CityID"]);
                    modelCON_Contact.StateID = Convert.ToInt32(dr["StateID"]);
                    modelCON_Contact.CountryID = Convert.ToInt32(dr["CountryID"]);
                    modelCON_Contact.Created = Convert.ToDateTime(dr["CreationDate"]);
                    modelCON_Contact.Modified = Convert.ToDateTime(dr["ModificationDate"]);
                    modelCON_Contact.ContactCategoryID = Convert.ToInt32(dr["ContactCategoryID"]);
                }
                return View("CON_ContactAddList", modelCON_Contact);
            }
            return View("CON_ContactAddList");
        }

        #endregion

        #region Delete

        public IActionResult Delete(int ContactID)
        {
            Boolean result = dalCON.PR_CON_Contact_DeleteByPK(ContactID);
            return RedirectToAction("Index");
        }

        #endregion

        #region Save

        [HttpPost]
        public IActionResult Save(CON_ContactModel modelCON_Contact)
        {
            if (modelCON_Contact.File != null)
            {
                string FilePath = "wwwroot\\UploadPhoto";
                string path = Path.Combine(Directory.GetCurrentDirectory(), FilePath);

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileNameWithPath = Path.Combine(path, modelCON_Contact.File.FileName);

                modelCON_Contact.PhotoPath = "~" + FilePath.Replace("wwwroot\\", "/") + "/" + modelCON_Contact.File.FileName;

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    modelCON_Contact.File.CopyTo(stream);
                }

            }

            Boolean result = false;

            if (modelCON_Contact.ContactID == null)
            {
                result = dalCON.PR_CON_Contact_Insert(modelCON_Contact);
            }
            else
            {
                result = dalCON.PR_CON_Contact_UpdateByPK(modelCON_Contact);
            }
            return RedirectToAction("Index");
        }

        #endregion

        #region DropDown from Country

        public IActionResult DropDownByCountry(int CountryID)
        {

            LOC_DAL dalLOC = new LOC_DAL();
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

        #region DropDown from State

        public IActionResult DropDownByState(int StateID)
        {

            LOC_DAL dalLOC = new LOC_DAL();
            DataTable DataTB = dalLOC.PR_LOC_City_SelectForDropDownByStateID(StateID);

            List<LOC_CityDropDownModel> CityList = new List<LOC_CityDropDownModel>();
            foreach (DataRow dr in DataTB.Rows)
            {
                LOC_CityDropDownModel list = new LOC_CityDropDownModel();
                list.CityID = Convert.ToInt32(dr["CityID"]);
                list.CityName = (dr["CityName"]).ToString();
                CityList.Add(list);
            }
            var citymodel = CityList;
            ViewBag.CityList = CityList;
            return Json(citymodel);
        }

        #endregion

        #region Filter
        public IActionResult Filter(string CountryName, string StateName, string CityName, string Name, string ContactCategoryName)
        {
            DataTable DataTB = dalCON.PR_CON_Contact_Filter(CityName, StateName, CountryName, Name, ContactCategoryName);

            return View("Index", DataTB);
        }
        #endregion
    }
}

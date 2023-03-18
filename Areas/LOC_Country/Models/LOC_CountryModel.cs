using System.ComponentModel.DataAnnotations;

namespace MultiUserAB.Areas.LOC_Country.Models
{
    public class LOC_CountryModel
    {
        public int? CountryID { get; set; }
        [Required(ErrorMessage = "Please enter the Country Name")]

        public string CountryName { get; set; }
        [Required(ErrorMessage = "Please enter the Country Code")]

        public string CountryCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    //public class LOC_CountryDropDown
    //{
    //    public int? CountryID { get; set; }
    //    public String? CountryName { get; set; }
    //}
}

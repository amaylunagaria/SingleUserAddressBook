using System.ComponentModel.DataAnnotations;

namespace MultiUserAB.Areas.LOC_City.Models
{
    public class LOC_CityModel
    {
        public int? CityID { get; set; }
        [Required(ErrorMessage = "Please enter the City Name.")]
        public string? CityName { get; set; }
        [Required(ErrorMessage = "Please select a State.")]
        public int StateID { get; set; }
        [Required(ErrorMessage = "Please select a Country.")]
        public int CountryID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    //public class LOC_CityDropDownModel
    //{
    //    public int? CityID { get; set; }
    //    public string? CityName { get; set;}
    //}
}

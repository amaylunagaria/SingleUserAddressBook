using System.ComponentModel.DataAnnotations;

namespace MultiUserAB.Areas.LOC_State.Models
{
    public class LOC_StateModel
    {
        public int? StateID { get; set; }

        [Required(ErrorMessage = "Please select a Country.")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Please enter State Name.")]
        public string? StateName { get; set; }
        public string? CountryName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    //public class LOC_StateDropDownModel
    //{
    //    public int? StateID { get; set; }
    //    public string? StateName { get; set;}
    //}
}

using System.ComponentModel.DataAnnotations;

namespace MultiUserAB.Areas.CON_Contact.Models
{
    public class CON_ContactModel
    {
        public int? ContactID { get; set; }

        [Required(ErrorMessage = "Please enter the Name.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please enter the Mobile Number.")]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Please enter the Address.")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please enter the email.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please select a State.")]
        public int StateID { get; set; }

        [Required(ErrorMessage = "Please select a Country.")]
        public int CountryID { get; set; }

        [Required(ErrorMessage = "Please select a City.")]
        public int CityID { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [Required(ErrorMessage = "Please select a Contact Category.")]
        public int? ContactCategoryID { get; set; }

        [Required(ErrorMessage = "Please select a Profile photo.")]
        public IFormFile? File { get; set; }
        public string? PhotoPath { get; set; }
    }

    public class LOC_StateDropDownModel
    {
        public int? StateID { get; set; }
        public string? StateName { get; set; }
    }
    public class LOC_CityDropDownModel
    {
        public int? CityID { get; set; }
        public string? CityName { get; set; }
    }
    public class LOC_CountryDropDown
    {
        public int? CountryID { get; set; }
        public string? CountryName { get; set; }
    }
    public class MST_ContactCategoryDropDownModel
    {
        public int? ContactCategoryID { get; set; }
        public string? ContactCategoryName { get; set; }
    }
}

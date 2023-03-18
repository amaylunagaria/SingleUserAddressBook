using System.ComponentModel.DataAnnotations;

namespace MultiUserAB.Areas.MST_ContactCategory.Models
{
    public class MST_ContactCategoryModel
    {
        public int? ContactCategoryID { get; set; }

        [Required(ErrorMessage = "Please enter the Contact Category.")]
        public string? ContactCategoryName { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }

    //public class MST_ContactCategoryDropDownModel
    //{
    //    public int? ContactCategoryID { get; set; }
    //    public string? ContactCategoryName { get; set;}
    //}
}

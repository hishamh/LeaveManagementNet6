using System.ComponentModel.DataAnnotations;

namespace LeaveManagement.Models
{
    public class LeaveTypeVM
    {

        public int Id { get; set; }
        [Display(Name = "Leave type Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Default Number of Days")]
        [Required]
        [Range(1,25, ErrorMessage = "please enter a valid numbe less than 30")]
        public int DefaulDays { get; set; }


    }
}

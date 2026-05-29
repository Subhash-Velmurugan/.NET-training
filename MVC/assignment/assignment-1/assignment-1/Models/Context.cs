using System.ComponentModel.DataAnnotations;
using ContactManagementApp.CustomValidation;

namespace ContactManagementApp.Models
{
    public class Contact
    {
        [Required]
        [NumericOnly(ErrorMessage = "ID must contain only numbers")]
        public long Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace ContactManagementApp.CustomValidation
{
    public class NumericOnlyAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return long.TryParse(value.ToString(), out _);
        }
    }
}
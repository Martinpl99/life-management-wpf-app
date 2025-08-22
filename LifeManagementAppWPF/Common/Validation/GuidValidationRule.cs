using System.Globalization;
using System.Windows.Controls;

namespace LifeManagementAppWPF.Common.Validation
{
    internal class GuidValidationRule : ValidationRule
    {
        public GuidValidationRule()
        {
            ValidatesOnTargetUpdated = true;
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is not string) return new ValidationResult(false, "Value is not string");

            if (!Guid.TryParse(value as string, out var guidResult))
                return new ValidationResult(false, "Given value is not guid");

            return ValidationResult.ValidResult;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace HRCChallenge.Validation
{
    internal class MatrixRowValueValidationRule : ValidationRule
    {
        public int MaxValue { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DataRowView dataRow = (value as BindingGroup)?.Items[0] as DataRowView;
            foreach (int element in dataRow.Row.ItemArray)
            {
                if (element == null) continue;
                if (element > MaxValue)
                {
                    return new ValidationResult(false, $"Value can't be greater than {MaxValue}");
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}

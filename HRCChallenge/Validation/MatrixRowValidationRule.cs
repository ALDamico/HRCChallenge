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
    internal class MatrixRowValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DataRowView dataRow = (value as BindingGroup)?.Items[0] as DataRowView;
            foreach (var element in dataRow.Row.ItemArray)
            {
                if (element == null || element == DBNull.Value)
                {
                    return new ValidationResult(false, null);
                }
            }
            return ValidationResult.ValidResult;
        }
    }
}

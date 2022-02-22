using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CalculationResult
    {
        public string EmployeeDeduction { get; set; }
        public string DependentDeduction { get; set; }
        public string DeductionTotalPerPayCheck { get; set; }
        public string EmployeeDeductionPerYear { get; set; }
        public string DependentDeuctionPerYear { get; set; }
        public string DeductionTotalPerYear { get; set; }
        public string TotalPayPerCheck { get; set; }
        public string TotalPayPerYear { get; set; }
    }
}

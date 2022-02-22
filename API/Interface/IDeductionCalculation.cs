using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModel;
namespace API.Interface
{
    public interface IDeductionCalculation
    {
        /// <summary>
        /// This method takes Employee and Dependent collection and number of paycheck. 
        /// </summary>
        /// <param name="empDepType">mployee and Dependent collection</param>
        /// <returns>Total decuction based on employee or dependent type</returns>   
        public decimal CalculateDeduction(List<EmployeeDependentType> empDepType, int numOfPayCheck);
    }
}

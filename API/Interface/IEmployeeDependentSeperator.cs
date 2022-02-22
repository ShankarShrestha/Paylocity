using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModel;

namespace API.Interface
{
    public interface IEmployeeDependentSeperator
    {
        /// <summary>
        /// This method takes Employee and Dependent collection from UI. 
        /// </summary>
        /// <param name="employeeDependent">employee and Dependent collection</param>
        /// <returns>seperate employee and dependent collection</returns>
        public List<EmployeeDependentType> SeperateToIndividual(EmpDepViewMode employeeDependent);
    }
}

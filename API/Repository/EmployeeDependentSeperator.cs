using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModel;
using API.Models;
using API.Enum;
using API.Constant;
using API.Interface;

namespace API.Repository
{
    public class EmployeeDependentSeperator : IEmployeeDependentSeperator
    {
        public List<EmployeeDependentType> SeperateToIndividual(EmpDepViewMode employeeDependent)
        {
            List<EmployeeDependentType> empDepCollection = new List<EmployeeDependentType>();
           // var employee = employeeDependent.Employees;
            var dependents = employeeDependent.Dependents;           
           
            empDepCollection = new List<EmployeeDependentType>()
            {
                new EmployeeDependentType{ Name = employeeDependent.Employees.Name, Type = PersonType.Employee, YearlySalary = employeeDependent.Employees.yearlySalary }
            };

            foreach (var dependent in dependents)
            {
                empDepCollection.Add(new EmployeeDependentType() { Name = dependent.Name, Type = PersonType.Dependent });
            }

            return empDepCollection;
        }                       
    }
}

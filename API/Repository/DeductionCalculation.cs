using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ViewModel;
using API.Enum;
using API.Constant;
using API.Interface;

namespace API.Repository
{
    public class DeductionCalculation : IDeductionCalculation
    {       
        public decimal CalculateDeduction(List<EmployeeDependentType> empDepType, int numOfPayCheck)
        {
            var deduction = 0.0M;
            foreach (var empDep in empDepType)
            {
                if (empDep.Type == PersonType.Employee)
                {
                    deduction = CalculateEngine(empDep.Name, BenefitConstant.EMPLOYEE_DEDUCTION, BenefitConstant.NUMBER_OF_PAYCHECK);
                }
                else
                {
                    deduction += CalculateEngine(empDep.Name, BenefitConstant.DEPENDENT_DEDUCTION, BenefitConstant.NUMBER_OF_PAYCHECK);
                }
            }
            return deduction;
        }
      

        //This method return the total cost of benefit per person
        private decimal CalculateEngine(string name, decimal benefitCost, int numberOfPaycheck)
        {
            decimal costPerPayCheck = benefitCost / numberOfPaycheck;
            decimal nameDiscount = 0.0M;

            nameDiscount = costPerPayCheck * CalculateNameDiscount(name);

            return costPerPayCheck - nameDiscount;
        }


        private decimal CalculateNameDiscount(string name)
        {
            decimal discountRate = 0.0M;
            if (name.ToUpper()[0] == 'A')
            {
                discountRate = BenefitConstant.NAME_DISCOUNT_RATE;
            }
            else
            {
                return discountRate;
            }
            return discountRate;

        }
    }
}

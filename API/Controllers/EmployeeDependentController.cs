using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Interface;
using API.ViewModel;
using API.Enum;
using API.Constant;
using API.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeDependentController : ControllerBase
    {
        private readonly IEmployeeDependentSeperator _IemployeeDependentSeperator;
        private readonly IDeductionCalculation _IDeductionCalculation;
        private readonly ILogger<EmployeeDependentController> _logger;


        public EmployeeDependentController(IEmployeeDependentSeperator IemployeeDependentSeperator, 
            IDeductionCalculation IDeductionCalculation, ILogger<EmployeeDependentController> logger)
        {
            _IemployeeDependentSeperator = IemployeeDependentSeperator;
            _IDeductionCalculation = IDeductionCalculation;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Employee Dependent API");
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] EmpDepViewMode employeeDependent)
        //public IActionResult Post([FromBody] dynamic employeeDependent1)
        {

            try
            {
                List<EmployeeDependentType> empDepCollection = _IemployeeDependentSeperator.SeperateToIndividual(employeeDependent);
                //calculate the duductions
                decimal empDeduction = _IDeductionCalculation.CalculateDeduction(empDepCollection.Where(x => x.Type == PersonType.Employee).ToList(), BenefitConstant.NUMBER_OF_PAYCHECK); // 26 is number of paycheck. Put this in contant;
                decimal depDeduction = _IDeductionCalculation.CalculateDeduction(empDepCollection.Where(x => x.Type == PersonType.Dependent).ToList(), BenefitConstant.NUMBER_OF_PAYCHECK);
                decimal deductionTotalPerPayCheck = empDeduction + depDeduction;
                decimal empDeductionPerYear = empDeduction * BenefitConstant.NUMBER_OF_PAYCHECK;
                decimal depDeductionPerYear = depDeduction * BenefitConstant.NUMBER_OF_PAYCHECK;
                decimal DeductionTotalPerYear = empDeductionPerYear + depDeductionPerYear;
                decimal totalPayPerCheck = (empDepCollection[0].YearlySalary / BenefitConstant.NUMBER_OF_PAYCHECK) - deductionTotalPerPayCheck;
                decimal totalPayPerYear = (empDepCollection[0].YearlySalary - DeductionTotalPerYear);

                List<CalculationResult> finalResult = new List<CalculationResult>()
                {
                    new CalculationResult
                    {
                        EmployeeDeduction = empDeduction.ToString("0.00"),
                        DependentDeduction = depDeduction.ToString("0.00"),
                        DeductionTotalPerPayCheck = deductionTotalPerPayCheck.ToString("0.00"),
                        EmployeeDeductionPerYear = empDeductionPerYear.ToString("0.00"),
                        DependentDeuctionPerYear = depDeductionPerYear.ToString("0.00"),
                        DeductionTotalPerYear = DeductionTotalPerYear.ToString("0.00"),
                        TotalPayPerCheck = totalPayPerCheck.ToString("0.00"),
                        TotalPayPerYear = totalPayPerYear.ToString("0.00")
                    }
                };
               // string jsonString = JsonConvert.SerializeObject(finalResult);
                return Ok(finalResult);
            }
            catch (Exception e)
            {
                _logger.LogError("Exception: " + e);
                return NotFound();
            }
            
        }
    }
}
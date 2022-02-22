using API.Models;
using System.Collections.Generic;

namespace API.ViewModel
{
    public class EmpDepViewMode
    {
        public Employee Employees { get; set; }
        //public IEnumerable<Dependent> Dependents { get; set; }


        public List<Dependent> Dependents { get; set; } = new List<Dependent>();
    }
}

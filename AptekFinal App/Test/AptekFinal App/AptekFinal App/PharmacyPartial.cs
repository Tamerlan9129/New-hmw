using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekFinal_App
{
    partial class Pharmacy
    {
        public Pharmacy()
        {
            Id = ++_id; 
        }
        public Pharmacy(string name, int minsalary, double budget, string location)
        {
            Name = name;
            
            MinSalary = minsalary;
            Budget = budget;
            Location = location;
            employees = new List<Employee>();
            drugs = new List<Drug>();

        }

        //public bool AddEmployees(Employee employee) 
        //{
        //    if (employee.Salary > MinSalary) 
        //    { 
            
        //    }
        
        //}

    }
}

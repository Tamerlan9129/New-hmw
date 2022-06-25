using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AptekFinal_App
{
    partial class Pharmacy
    {
        public string Name { get; set; }

        public  int Id { get; }
        private static int _id;

        public int MinSalary { get; set; }

        public double Budget { get; set; }

        public string Location { get; set; }

        public List<Employee> employees;

        public List<Drug> drugs;

        
    }
}

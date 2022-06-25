using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AptekFinal_App.Enums;

namespace AptekFinal_App
{
    partial class Employee
    {
        public string Name { get; set; }   

        public string Surname { get; set; }  

        public string Username { get; set; } 

        public DateTime BirthDate { get; set; }  

        public double Salary { get; set; }  
        public Role RoleType { get; set; } 
        public string Password { get; set; }

        public int Id { get;}
        private  static int _id;
       


    }
}

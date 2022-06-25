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
        public Employee()
        {
            Id = ++_id;
        }

        public Employee(string name, string surname, string username, DateTime birthday, double salary, Role roletype, string password) : this()
        {
            Name = name;
            Surname = surname;
            Username = username;
            BirthDate = birthday;
            Salary = salary;
            RoleType = roletype;
            Password = password;
            Id = ++_id;

        }
        public static bool PasswordChecker(string pass) 
        {
            bool flag = false;
            foreach (char item in pass)
            {
                
                if (char.IsDigit(item) && char.IsUpper(item) && char.IsLower(item)) 
                {
                    flag = true;
                    return flag;
                }

                return flag;
            }

            return false;
        }
    }
}

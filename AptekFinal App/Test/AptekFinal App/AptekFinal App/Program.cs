using AptekFinal_App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using static AptekFinal_App.Enums;
namespace AptekFinal_App
{
    class Program
    {
        public static void Main(string[] args)
        {
            Pharmacy pharmacy = new Pharmacy("Zeferan", 300, 12000, "Baku");
            Employee defAdmin = new Employee();
            defAdmin.Password = "Admin123!";
            defAdmin.Username = "admin";
            defAdmin.RoleType = Role.Admin;
            pharmacy.employees.Add(defAdmin);


            while (true)
            {

            login:
                Helper.PrintSimple("Enter username : ", ConsoleColor.Cyan);
                string username = Console.ReadLine();
                Helper.PrintSimple("Enter password : ", ConsoleColor.Cyan);
                string password = Console.ReadLine();
                Employee check = pharmacy.employees.Find(u => u.Username == username && u.Password == password);
                if (check == null)
                {
                    Helper.SuccessAndError("Incorrect username or password ! Try again. ", ConsoleColor.Red);
                    goto login;
                }
            Main:
                Helper.SuccessAndError("Welcome Admin ", ConsoleColor.Magenta);
                Admin();

                string choose = Console.ReadLine();

                switch (choose)
                {
                    case "1":
                        AdminPanel();
                        string panelChoose = Console.ReadLine();

                        switch (panelChoose)
                        {
                            case "1":
                                AddEmployee(pharmacy.employees,pharmacy);
                                goto Main;
                            case "2":
                                AddDrug(pharmacy.drugs, pharmacy);
                                goto Main;

                            case "3":
                                DeleteDrug(pharmacy.drugs, pharmacy);
                                goto Main;

                            case "4":
                                EditDrug(pharmacy.drugs, pharmacy);

                                goto Main;
                            case "5":
                                DeleteEmpl(pharmacy.employees ,pharmacy);
                                goto Main;
                            case "6":
                                EditEmpl(pharmacy.employees, pharmacy);
                                goto Main;
                            default:
                                break;
                        }
                        break;
                    case "2":
                        Sale(pharmacy.drugs, pharmacy);
                        break;
                    case "3":
                        break;
                    default:
                        break;
                }
                
            }
        }

        //static void LoginAsAdmin(List<Employee> employees)
        //{
        //    Helper.PrintSimple("Enter username : ", ConsoleColor.Cyan);
        //    string username = Console.ReadLine();
        //    Helper.PrintSimple("Enter password : ", ConsoleColor.Cyan);
        //    string password = Console.ReadLine();
        //    Employee check = employees.Find(u => u.Username == username && u.Password == password);
        //    if (check == null)
        //    {
        //        Helper.SuccessAndError("Incorrect username or password ! Try again. ", ConsoleColor.Red);
        //        LoginAsAdmin(employees);
        //    }
        //    Helper.SuccessAndError("Welcome Admin ", ConsoleColor.Magenta);

        //}
        static void Admin()
        {
            Helper.PrintSimple("1: Admin Panel ", ConsoleColor.Blue);
            Helper.PrintSimple("2: Sell ", ConsoleColor.Blue);
            Helper.PrintSimple("3:Update user data  ", ConsoleColor.Blue);

        }
        static void AdminPanel()
        {
            Helper.PrintSimple("1: Add Employee ", ConsoleColor.White);
            Helper.PrintSimple("2: Add Drug ", ConsoleColor.White);
            Helper.PrintSimple("3:Delete Drug  ", ConsoleColor.White);
            Helper.PrintSimple("4:Edit Drug  ", ConsoleColor.White);
            Helper.PrintSimple("5:Delete Employee  ", ConsoleColor.White);
            Helper.PrintSimple("6:Edit Employee  ", ConsoleColor.White);

        }
        //static void AddEmployee(List<Employee>addemps, Pharmacy ph)
        //{
        //    Employee emp = new Employee();
        //name:
        //    Helper.PrintSimple("Enter employee name : ", ConsoleColor.DarkCyan);
        //    string empName = Console.ReadLine();
        //    bool isName = string.IsNullOrWhiteSpace(empName);
        //    if (isName)
        //    {
        //        Helper.SuccessAndError("Please enter correct name. ", ConsoleColor.DarkRed);
        //        goto name;
        //    }
        //surname:
        //    Helper.PrintSimple("Enter employee surname : ", ConsoleColor.DarkCyan);
        //    string empSurname = Console.ReadLine();
        //    bool isSurname = string.IsNullOrWhiteSpace(empSurname);
        //    if (isSurname)
        //    {
        //        Helper.SuccessAndError("Please enter correct surname. ", ConsoleColor.DarkRed);
        //        goto surname;
        //    }
        //username:
        //    Helper.PrintSimple("Enter employee username : ", ConsoleColor.DarkCyan);
        //    string username = Console.ReadLine();
        //    bool isUsername = string.IsNullOrWhiteSpace(username);
        //    if (isUsername)
        //    {
        //        Helper.SuccessAndError("Please enter correct username. ", ConsoleColor.DarkRed);
        //        goto username;
        //    }
        //    bool existUsernam = ph.employees.Any(x => x.Username == username);
        //    if (existUsernam)
        //    {
        //        Helper.SuccessAndError("This username already exist ! Please try another username ", ConsoleColor.Red);
        //        goto username;
        //    }
        //password:
        //    Helper.PrintSimple("Enter password", ConsoleColor.DarkCyan);
        //    string password = Console.ReadLine();
        //    bool isPassword = string.IsNullOrWhiteSpace(password);
        //    if (isPassword)
        //    {
        //        Helper.SuccessAndError("Please enter correct password. ", ConsoleColor.DarkRed);
        //        goto password;
        //    }
        //birthDay:
        //    Helper.PrintSimple("Enter empoyee Birth day  (dd/mm/yyyy) : ", ConsoleColor.DarkCyan);
        //    string birthDaystr = Console.ReadLine();
        //    bool isBirthday = DateTime.TryParse(birthDaystr, out DateTime birthDay);
        //    if (!isBirthday)
        //    {
        //        Helper.SuccessAndError("Please enter correct date. ", ConsoleColor.DarkRed);
        //        goto birthDay;
        //    }
        //salary:
        //    Helper.PrintSimple("Enter empoyee salary : ", ConsoleColor.DarkCyan);
        //    string salaryStr = Console.ReadLine();
        //    bool isSalary = double.TryParse(salaryStr, out double salary);
        //    if (!isSalary)
        //    {
        //        Helper.SuccessAndError("Please enter correct salary. ", ConsoleColor.DarkRed);
        //        goto salary;
        //    }
        //    if (salary < ph.MinSalary)
        //    {
        //        Helper.SuccessAndError("Salary is lower than min pharmacy salary.Please increase salary ", ConsoleColor.DarkRed);
        //        goto salary;
        //    }

        //roleType:
        //    Helper.PrintSimple("Enter employee Role Type", ConsoleColor.DarkCyan);
        //    Helper.PrintSimple("1) Admin  2) Staff ", ConsoleColor.Yellow);
        //    string roleTypeStr = Console.ReadLine();
        //    bool isRoleTypeStr = string.IsNullOrWhiteSpace(roleTypeStr);
        //    if (isRoleTypeStr)
        //    {
        //        Helper.SuccessAndError("Please enter correct Role type. ", ConsoleColor.DarkRed);
        //        goto roleType;
        //    }

        //    if (roleTypeStr == "1")
        //    {
        //        emp.RoleType = Role.Admin;
        //    }
        //    else if (roleTypeStr == "2")
        //    {
        //        emp.RoleType = Role.Staff;

        //    }
        //    else
        //    {
        //        Helper.SuccessAndError("Enter correct number !", ConsoleColor.Red);
        //        goto roleType;
        //    }            
        //    emp.Name = empName;
        //    emp.Surname = empSurname;
        //    emp.Password = password;
        //    emp.Salary = salary;
        //    emp.Username = username;
        //    emp.BirthDate = birthDay;
        //   addemps.Add(emp);
        //    Helper.SuccessAndError($"{emp.Username}  username successfully added! ", ConsoleColor.Green);
        //    //AdminPanel();
        //    Console.WriteLine("---------------Employees-------------");
        //    foreach (var item in addemps)
        //    {
        //        Console.WriteLine($"{item.Id}  {item.Name}   {item.Surname}  {item.Username}  {item.RoleType.ToString()}  {item.Password}");
        //    }

        //}

        static void AddDrug(List<Drug> drugs, Pharmacy pharm)
        {
            Drug drug = new Drug();
        drugName:
            Helper.PrintSimple("Enter Drug name : ", ConsoleColor.Gray);
            string drugName = Console.ReadLine();
            bool isDrugName = string.IsNullOrWhiteSpace(drugName);
            if (isDrugName)
            {
                Helper.SuccessAndError("Please enter correct name. ", ConsoleColor.DarkRed);
                goto drugName;
            }

        select:
            Helper.PrintSimple("Enter Drug Type : ", ConsoleColor.Gray);
            Helper.PrintSimple("1)Syrop 2) Powder 3) Tablet ", ConsoleColor.Blue);
            string drugTypeStr = Console.ReadLine();

            switch (drugTypeStr)
            {
                case "1":
                    drug.DrugType = DrugType.Syrob;
                    break;
                case "2":
                    drug.DrugType = DrugType.Powder;
                    break;
                case "3":
                    drug.DrugType = DrugType.Tablet;
                    break;
                default:
                    Helper.SuccessAndError("Enter correct number", ConsoleColor.Red);
                    goto select;

            }
            bool existDrugName = drugs.Any(x => x.Name.ToUpper() == drugName.ToUpper() && x.DrugType == drug.DrugType);
            if (existDrugName)
            {
                Helper.SuccessAndError($"{drug.Name}  has already {drug.DrugType}. Enter correct type ", ConsoleColor.DarkRed);
                goto select;
            }
        count:
            Helper.PrintSimple("Enter Drug Count : ", ConsoleColor.Gray);
            string drugCount = Console.ReadLine();
            bool isCount = int.TryParse(drugCount, out int count);
            if (!isCount)
            {
                Helper.SuccessAndError("Please enter correct count. ", ConsoleColor.DarkRed);
                goto count;
            }
        PurchasePrice:
            Helper.PrintSimple("Enter Drug PurchasePrice : ", ConsoleColor.Gray);
            string drugPurchasePrice = Console.ReadLine();
            bool isPurchasePrice = double.TryParse(drugPurchasePrice, out double purchasePrice);
            if (!isPurchasePrice)
            {
                Helper.SuccessAndError("Please enter correct price. ", ConsoleColor.DarkRed);
                goto PurchasePrice;
            }

        SalePrice:
            Helper.PrintSimple("Enter Drug SalePrice : ", ConsoleColor.Gray);
            string drugSalePrice = Console.ReadLine();
            bool isSalePrice = double.TryParse(drugSalePrice, out double salePrice);
            if (!isSalePrice)
            {
                Helper.SuccessAndError("Please enter correct price. ", ConsoleColor.DarkRed);
                goto SalePrice;
            }
            if (purchasePrice * count > pharm.Budget)
            {
                Helper.SuccessAndError("Budget is low ! ", ConsoleColor.DarkRed);
                goto count;
            }
            drug.Name = drugName;
            drug.Count = count;
            drug.PurchasePrice = purchasePrice;
            drug.SalePrice = salePrice;
            pharm.drugs.Add(drug);
            Console.WriteLine("This drug is added");



        }
        static void EditDrug(List<Drug> drug, Pharmacy ph)
        {
        editdrug:
            Helper.PrintSimple("Enter drug name which you want to edit :", ConsoleColor.Yellow);
            string editDrug = Console.ReadLine();
            bool isEdit = string.IsNullOrWhiteSpace(editDrug);
            if (isEdit)
            {
                Helper.SuccessAndError("Please enter drug name correctly ! ", ConsoleColor.Red);
                goto editdrug;
            }
            List<Drug> editResult = drug.FindAll(x => x.Name.ToUpper().Contains(editDrug.ToUpper()));
            foreach (var item in editResult)
            {
                Helper.PrintSimple($"Drug name - {item.Name} Type- {item.DrugType} Id - {item.Id}", ConsoleColor.Green);
            }
        idedit:
            Helper.PrintSimple("Enter drug Id to edit : ", ConsoleColor.Yellow);
            string idEditStr = Console.ReadLine();
            bool isIde = int.TryParse(idEditStr, out int idEdit);
            if (!isIde)
            {
                Helper.SuccessAndError("Enter correct id ", ConsoleColor.Red);
                goto idedit;
            }
            foreach (var it in editResult)
            {
                if (it.Id == idEdit)
                {

                drugName:
                    Helper.PrintSimple("Enter Drug name : ", ConsoleColor.Gray);
                    string drugName = Console.ReadLine();
                    bool isDrugName = string.IsNullOrWhiteSpace(drugName);
                    if (isDrugName)
                    {
                        Helper.SuccessAndError("Please enter correct name. ", ConsoleColor.DarkRed);
                        goto drugName;
                    }

                select:
                    Helper.PrintSimple("Enter Drug Type : ", ConsoleColor.Gray);
                    Helper.PrintSimple("1)Syrop 2) Powder 3) Tablet ", ConsoleColor.Blue);
                    string drugTypeStr = Console.ReadLine();
                    switch (drugTypeStr)
                    {
                        case "1":
                            it.DrugType = DrugType.Syrob;
                            break;
                        case "2":
                            it.DrugType = DrugType.Powder;
                            break;
                        case "3":
                            it.DrugType = DrugType.Tablet;
                            break;
                        default:
                            Helper.SuccessAndError("Enter correct number", ConsoleColor.Red);
                            goto select;

                    }
                    bool existDrugName = ph.drugs.Any(x => x.Name.ToUpper() == drugName.ToUpper() && x.DrugType == it.DrugType);
                    if (existDrugName)
                    {
                        Helper.SuccessAndError($"{it.Name}  has already {it.DrugType}. Enter correct type ", ConsoleColor.DarkRed);
                        goto select;
                    }
                count:
                    Helper.PrintSimple("Enter Drug Count : ", ConsoleColor.Gray);
                    string drugCount = Console.ReadLine();
                    bool isCount = int.TryParse(drugCount, out int count);
                    if (!isCount)
                    {
                        Helper.SuccessAndError("Please enter correct count. ", ConsoleColor.DarkRed);
                        goto count;
                    }
                PurchasePrice:
                    Helper.PrintSimple("Enter Drug PurchasePrice : ", ConsoleColor.Gray);
                    string drugPurchasePrice = Console.ReadLine();
                    bool isPurchasePrice = double.TryParse(drugPurchasePrice, out double purchasePrice);
                    if (!isPurchasePrice)
                    {
                        Helper.SuccessAndError("Please enter correct price. ", ConsoleColor.DarkRed);
                        goto PurchasePrice;
                    }

                SalePrice:
                    Helper.PrintSimple("Enter Drug SalePrice : ", ConsoleColor.Gray);
                    string drugSalePrice = Console.ReadLine();
                    bool isSalePrice = double.TryParse(drugSalePrice, out double salePrice);
                    if (!isSalePrice)
                    {
                        Helper.SuccessAndError("Please enter correct price. ", ConsoleColor.DarkRed);
                        goto SalePrice;
                    }
                    if (purchasePrice * count > ph.Budget)
                    {
                        Helper.SuccessAndError("Budget is low ! ", ConsoleColor.DarkRed);
                        goto count;
                    }
                    Helper.SuccessAndError($"{it.Id}  drug is successfully edited ", ConsoleColor.Green);
                    double oldBudget = ph.Budget + it.PurchasePrice * it.Count;
                    it.Name = drugName;
                    it.PurchasePrice = purchasePrice;
                    it.Count = count;
                    it.SalePrice = salePrice;

                    oldBudget -= count * purchasePrice;
                    ph.Budget = oldBudget;

                }
            }

        }
        static void DeleteDrug(List<Drug> drug, Pharmacy ph)
        {
        deletName:
            Helper.PrintSimple("Enter drug name which you want to delete :", ConsoleColor.Yellow);
            string deletDrug = Console.ReadLine();
            bool isDelet = string.IsNullOrWhiteSpace(deletDrug);
            if (isDelet)
            {
                Helper.SuccessAndError("Please enter drug name correctly ! ", ConsoleColor.Red);
                goto deletName;
            }
            List<Drug> result = drug.FindAll(x => x.Name.ToUpper().Contains(deletDrug.ToUpper()));
            foreach (var item in result)
            {
                Helper.PrintSimple($"Drug name - {item.Name} Type- {item.DrugType} Id - {item.Id}", ConsoleColor.Green);
            }
        id:
            Helper.PrintSimple("Enter drug Id to delete : ", ConsoleColor.Yellow);
            string idDelStr = Console.ReadLine();
            bool isId = int.TryParse(idDelStr, out int id);
            if (!isId)
            {
                Helper.SuccessAndError("Enter correct id ", ConsoleColor.Red);
                goto id;
            }
            foreach (var it in result)
            {
                if (it.Id == id)
                {
                    drug.Remove(it);
                    Helper.SuccessAndError($"{it.Id}  drug is successfully deleted ", ConsoleColor.Green);
                    ph.Budget = it.Count * it.PurchasePrice + ph.Budget;
                }
            }
        }
        static void DeleteEmpl(List<Employee>emp,Pharmacy ph)
        {
            Console.WriteLine("-------------------------EMPLOYEEES-----------------");
            foreach (var item in emp)
            {
                Console.WriteLine($"{item.Id}  {item.Name}   {item.Surname}  {item.Username}  {item.RoleType.ToString()}  {item.Password}");
            }
        deletEmpName:
            Helper.PrintSimple("Enter employee name which you want to delete :", ConsoleColor.Cyan);
            string deletEmp = Console.ReadLine();
            bool isDelEmp = string.IsNullOrWhiteSpace(deletEmp);
            if (isDelEmp)
            {
                Helper.SuccessAndError("Please enter employee name correctly ! ", ConsoleColor.Red);
                goto deletEmpName;
            }
            List<Employee> findedemps = emp.FindAll(x => x.Name.ToUpper().Contains(deletEmp.ToUpper()));
            foreach (var item in findedemps)
            {
                Helper.PrintSimple($"Employe name - {item.Name} RoleType- {item.RoleType} Id - {item.Id}", ConsoleColor.Green);
            }
        idEmped:
            Helper.PrintSimple("Enter employee Id to delete : ", ConsoleColor.Yellow);
            string idDelempStr = Console.ReadLine();
            bool isId = int.TryParse(idDelempStr, out int id);
            if (!isId)
            {
                Helper.SuccessAndError("Enter correct id ", ConsoleColor.Red);
                goto idEmped;
            }
            foreach (var it in findedemps)
            {
                if (it.Id == id)
                {
                    ph.employees.Remove(it);
                    Helper.SuccessAndError($"{it.Name}  is successfully deleted ", ConsoleColor.Green);
                }
            }
        }

        static void EditEmpl(List<Employee> empl, Pharmacy phar)
        {
        editempl:
            Helper.PrintSimple("Enter employee name which you want to edit :", ConsoleColor.Yellow);
            string editEmpl = Console.ReadLine();
            bool isEdite = string.IsNullOrWhiteSpace(editEmpl);
            if (isEdite)
            {
                Helper.SuccessAndError("Please enter employe name correctly ! ", ConsoleColor.Red);
                goto editempl;
            }
            List<Employee> editemp = empl.FindAll(x => x.Name.ToUpper().Contains(editEmpl.ToUpper()));
            foreach (var item in editemp)
            {
                Helper.PrintSimple($"Employee name - {item.Name} Type- {item.RoleType} Id - {item.Id}", ConsoleColor.Green);
            }
        idemp:
            Helper.PrintSimple("Enter employee Id to edit : ", ConsoleColor.Yellow);
            string idEmplStr = Console.ReadLine();
            bool isIdem = int.TryParse(idEmplStr, out int idEditemp);
            if (!isIdem)
            {
                Helper.SuccessAndError("Enter correct id ", ConsoleColor.Red);
                goto idemp;
            }
            foreach (var it1 in editemp)
            {
                if (it1.Id == idEditemp)
                {

                empName:
                    Helper.PrintSimple("Enter employee name : ", ConsoleColor.Gray);
                    string emplName = Console.ReadLine();
                    bool isemplName = string.IsNullOrWhiteSpace(emplName);
                    if (isemplName)
                    {
                        Helper.SuccessAndError("Please enter correct name. ", ConsoleColor.DarkRed);
                        goto empName;
                    }

                empsurname:
                    Helper.PrintSimple("Enter employee surname : ", ConsoleColor.DarkCyan);
                    string editSurname = Console.ReadLine();
                    bool isedSurname = string.IsNullOrWhiteSpace(editSurname);
                    if (isedSurname)
                    {
                        Helper.SuccessAndError("Please enter correct surname. ", ConsoleColor.DarkRed);
                        goto empsurname;
                    }
                empusername:
                    Helper.PrintSimple("Enter employee username : ", ConsoleColor.DarkCyan);
                    string edUsername = Console.ReadLine();
                    bool isedUsername = string.IsNullOrWhiteSpace(edUsername);
                    if (isedUsername)
                    {
                        Helper.SuccessAndError("Please enter correct username. ", ConsoleColor.DarkRed);
                        goto empusername;
                    }
                    bool existedUsernam = empl.Any(x => x.Username == edUsername);
                    if (existedUsernam)
                    {
                        Helper.SuccessAndError("This username already exist ! Please try another username ", ConsoleColor.Red);
                        goto empusername;
                    }
                edpassword:
                    Helper.PrintSimple("Enter password", ConsoleColor.DarkCyan);
                    string edpassword = Console.ReadLine();
                    bool isedPassword = string.IsNullOrWhiteSpace(edpassword);
                    if (isedPassword)
                    {
                        Helper.SuccessAndError("Please enter correct password. ", ConsoleColor.DarkRed);
                        goto edpassword;
                    }
                edbirthDay:
                    Helper.PrintSimple("Enter empoyee Birth day  (dd/mm/yyyy) : ", ConsoleColor.DarkCyan);
                    string edbirthDaystr = Console.ReadLine();
                    bool isedBirthday = DateTime.TryParse(edbirthDaystr, out DateTime editbirthDay);
                    if (!isedBirthday)
                    {
                        Helper.SuccessAndError("Please enter correct date. ", ConsoleColor.DarkRed);
                        goto edbirthDay;
                    }
                edsalary:
                    Helper.PrintSimple("Enter empoyee salary : ", ConsoleColor.DarkCyan);
                    string edsalaryStr = Console.ReadLine();
                    bool isedSalary = double.TryParse(edsalaryStr, out double edsalary);
                    if (!isedSalary)
                    {
                        Helper.SuccessAndError("Please enter correct salary. ", ConsoleColor.DarkRed);
                        goto edsalary;
                    }
                    if (edsalary < phar.MinSalary)
                    {
                        Helper.SuccessAndError("Salary is lower than min pharmacy salary.Please increase salary ", ConsoleColor.DarkRed);
                        goto edsalary;
                    }

                roleType:
                    Helper.PrintSimple("Enter employee Role Type", ConsoleColor.DarkCyan);
                    Helper.PrintSimple("1) Admin  2) Staff ", ConsoleColor.Yellow);
                    string edroleTypeStr = Console.ReadLine();
                    bool isRoleTypeStr = string.IsNullOrWhiteSpace(edroleTypeStr);
                    if (isRoleTypeStr)
                    {
                        Helper.SuccessAndError("Please enter correct Role type. ", ConsoleColor.DarkRed);
                        goto roleType;
                    }



                    if (edroleTypeStr == "1")
                    {
                        it1.RoleType = Role.Admin;
                    }
                    else if (edroleTypeStr == "2")
                    {
                        it1.RoleType = Role.Staff;

                    }
                    else
                    {
                        Helper.SuccessAndError("Enter correct number !", ConsoleColor.Red);

                    }
                    it1.Name = emplName;
                    it1.Surname = editSurname;
                    it1.Password = edpassword;
                    it1.Salary = edsalary;
                    it1.Username = edUsername;
                    it1.BirthDate = editbirthDay;


                    Helper.SuccessAndError($"{it1.Username}  username successfully added! ", ConsoleColor.Green);
                }
            }
        }



        static void AddEmployee(List<Employee> employees, Pharmacy pharm)
        {
            Employee emp = new Employee();
        EmpName:
            Helper.PrintSimple("Enter  name : ", ConsoleColor.Gray);
            string empName = Console.ReadLine();
            bool isempName = string.IsNullOrWhiteSpace(empName);
            if (isempName)
            {
                Helper.SuccessAndError("Please enter correct name. ", ConsoleColor.DarkRed);
                goto EmpName;
            }
        surname:
            Helper.PrintSimple("Enter emp surname : ", ConsoleColor.Gray);
            string empSurname = Console.ReadLine();
            bool isempsurname = string.IsNullOrWhiteSpace(empSurname);
            if (isempsurname)
            {
                Helper.SuccessAndError("Please enter correct surname. ", ConsoleColor.DarkRed);
                goto surname;
            }
        username:
            Helper.PrintSimple("Enter emp username : ", ConsoleColor.Gray);
            string empUsername = Console.ReadLine();
            bool isempusername = string.IsNullOrWhiteSpace(empUsername);
            if (isempusername)
            {
                Helper.SuccessAndError("Please enter correct username. ", ConsoleColor.DarkRed);
                goto username;
            }
        select:
            Helper.PrintSimple("Enter Role Type : ", ConsoleColor.Gray);
            Helper.PrintSimple("1)Admin 2) Staff ", ConsoleColor.Blue);
            string empTypeStr = Console.ReadLine();

            switch (empTypeStr)
            {
                case "1":
                    emp.RoleType = Role.Admin;
                    break;
                case "2":
                    emp.RoleType = Role.Staff;
                    break;
               
                default:
                    Helper.SuccessAndError("Enter correct number", ConsoleColor.Red);
                    goto select;

            }
            bool existDrugName = employees.Any(x =>  x.Username == emp.Username);
            if (existDrugName)
            {
                Helper.SuccessAndError($"{emp.Name}  has already {emp.RoleType}. Enter correct type ", ConsoleColor.DarkRed);
                goto select;
            }
        
        Salary:
            Helper.PrintSimple("Enter employee salary : ", ConsoleColor.Gray);
            string salary = Console.ReadLine();
            bool isSalary = double.TryParse(salary, out double Salary);
            if (!isSalary)
            {
                Helper.SuccessAndError("Please enter correct salary. ", ConsoleColor.DarkRed);
                goto Salary;
            }

       
            
            if (Salary<pharm.MinSalary)
            {
                Helper.SuccessAndError("Salary is low ! ", ConsoleColor.DarkRed);
                goto Salary;
            }
        password:
            Helper.PrintSimple("Enter password", ConsoleColor.DarkCyan);
            string password = Console.ReadLine();
            bool isPassword = string.IsNullOrWhiteSpace(password);
            if (isPassword)
            {
                Helper.SuccessAndError("Please enter correct password. ", ConsoleColor.DarkRed);
                goto password;
            }
        birthDay:
            Helper.PrintSimple("Enter empoyee Birth day  (dd/mm/yyyy) : ", ConsoleColor.DarkCyan);
            string birthDaystr = Console.ReadLine();
            bool isBirthday = DateTime.TryParse(birthDaystr, out DateTime birthDay);
            if (!isBirthday)
            {
                Helper.SuccessAndError("Please enter correct date. ", ConsoleColor.DarkRed);
                goto birthDay;
            }
            emp.Name = empName;
            emp.Surname = empSurname;
            emp.Username = empUsername;
            emp.Password = password;
            emp.Salary = Salary;
            emp.BirthDate = birthDay;
            pharm.employees.Add(emp);
            Console.WriteLine("This empployee is added");



        }

        static void PasswordCheck(string password) 
        {
            
        }
        static void Sale(List<Drug> drugs, Pharmacy pharma) 
        {
            salename:
            Helper.PrintSimple("Enter drug name for sale : ", ConsoleColor.Blue);
            string drugname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(drugname))
            {
                Helper.SuccessAndError("Enter correct drug name !", ConsoleColor.Red);
                goto salename;
            }
            
            
            
            
            foreach (var item in drugs)
            {
                if (item.Name == drugname)
                {
                chooseType:
                    Helper.PrintSimple("Choose drug type:   1)Syrop 2) Powder 3) Tablet", ConsoleColor.Blue);
                    string chosSaletype = Console.ReadLine();
                    switch (chosSaletype)
                    {
                        case "1":
                          if( item.DrugType == DrugType.Syrob) 
                            {saleCount:
                                Helper.PrintSimple("Enter count for sale : ", ConsoleColor.Cyan);
                                string saleCountStr = Console.ReadLine();
                                bool isSalCount = double.TryParse(saleCountStr, out double saleCount);
                                if (!isSalCount) 
                                {
                                    Helper.SuccessAndError("Enter corrent count ", ConsoleColor.Red);
                                    goto saleCount;
                                }
                                if (item.Count < saleCount)
                                {
                                    Helper.SuccessAndError($"We have only {item.Count} {item.Name}  ", ConsoleColor.Yellow);
                                    Helper.PrintSimple("Do you want to sale ? Y/N ", ConsoleColor.Yellow);
                                    string answer1 = Console.ReadLine();
                                    if (answer1.ToUpper() == "Y")
                                    {
                                        drugs.Remove(item);
                                        pharma.Budget += item.Count * item.SalePrice;
                                    }
                                    else
                                    {
                                        goto saleCount;
                                    }
                                }
                                else 
                                { 
                                    Helper.PrintSimple("Are you sure ?   Y/N", ConsoleColor.Yellow);
                                    string sureAnswer = Console.ReadLine();
                                    if (sureAnswer.ToUpper() == "Y")
                                    {
                                        drugs.Remove(item);
                                        pharma.Budget += saleCount * item.SalePrice;
                                    }
                                    else
                                    {
                                        goto saleCount;
                                    }
                                }
                            }
                            break;
                        case "2":
                            if (item.DrugType == DrugType.Powder)
                            {
                            saleCount:
                                Helper.PrintSimple("Enter count for sale : ", ConsoleColor.Cyan);
                                string saleCountStr = Console.ReadLine();
                                bool isSalCount = double.TryParse(saleCountStr, out double saleCount);
                                if (!isSalCount)
                                {
                                    Helper.SuccessAndError("Enter corrent count ", ConsoleColor.Red);
                                    goto saleCount;
                                }
                                if (item.Count < saleCount)
                                {
                                    Helper.SuccessAndError($"We have only {item.Count} {item.Name}  ", ConsoleColor.Yellow);
                                    Helper.PrintSimple("Do you want to sale ? Y/N ", ConsoleColor.Yellow);
                                    string answer1 = Console.ReadLine();
                                    if (answer1.ToUpper() == "Y")
                                    {
                                        drugs.Remove(item);
                                        pharma.Budget += item.Count * item.SalePrice;
                                    }
                                    else
                                    {
                                        goto saleCount;
                                    }
                                }
                                else
                                {
                                    Helper.PrintSimple("Are you sure ?   Y/N", ConsoleColor.Yellow);
                                    string sureAnswer = Console.ReadLine();
                                    if (sureAnswer.ToUpper() == "Y")
                                    {
                                        drugs.Remove(item);
                                        pharma.Budget += saleCount * item.SalePrice;
                                    }
                                    else
                                    {
                                        goto saleCount;
                                    }
                                }
                            }
                            break;
                        case "3":
                            if (item.DrugType == DrugType.Tablet)
                            {
                            saleCount:
                                Helper.PrintSimple("Enter count for sale : ", ConsoleColor.Cyan);
                                string saleCountStr = Console.ReadLine();
                                bool isSalCount = double.TryParse(saleCountStr, out double saleCount);
                                if (!isSalCount)
                                {
                                    Helper.SuccessAndError("Enter corrent count ", ConsoleColor.Red);
                                    goto saleCount;
                                }
                                if (item.Count < saleCount)
                                {
                                    Helper.SuccessAndError($"We have only {item.Count} {item.Name}  ", ConsoleColor.Yellow);
                                    Helper.PrintSimple("Do you want to sale ? Y/N ", ConsoleColor.Yellow);
                                    string answer1 = Console.ReadLine();
                                    if (answer1.ToUpper() == "Y")
                                    {
                                        drugs.Remove(item);
                                        pharma.Budget += item.Count * item.SalePrice;
                                    }
                                    else
                                    {
                                        goto saleCount;
                                    }
                                }
                                else
                                {
                                    Helper.PrintSimple("Are you sure ?   Y/N", ConsoleColor.Yellow);
                                    string sureAnswer = Console.ReadLine();
                                    if (sureAnswer.ToUpper() == "Y")
                                    {
                                        drugs.Remove(item);
                                        pharma.Budget += saleCount * item.SalePrice;
                                    }
                                    else
                                    {
                                        goto saleCount;
                                    }
                                }
                            }
                            break;
                        default:
                            Helper.SuccessAndError("Choose correct type : ", ConsoleColor.Red);
                            goto chooseType;
                            
                    }
                }
                else 
                {
                    Helper.SuccessAndError("There is no drug with this name ", ConsoleColor.Red);
                    goto salename;
                }
            }
           

        }
    }
}

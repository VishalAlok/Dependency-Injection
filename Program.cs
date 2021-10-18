using System;
using System.Collections.Generic;

namespace Dependency_Injection
{
    //MODEL
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
    }

    //DAL
    public interface IEmployeeDAL
    {
        List<Employee> SelectAllEmployees();
    }
    public class EmployeeDAL : IEmployeeDAL
    {
        public List<Employee> SelectAllEmployees()
        {
            List<Employee> ListEmployees = new List<Employee>();
            //Code to fetch data From DB
            return ListEmployees;
        }
    }

    //BL
    public class EmployeeBL
    {
        public IEmployeeDAL _employeeDAL;
        public EmployeeBL(IEmployeeDAL employeeDAL)
        {
            this._employeeDAL = employeeDAL;
        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeDAL.SelectAllEmployees();
        }
    }

    //Client Code
    class Program
    {
        static void Main(string[] args)
        {
            EmployeeBL employeeBL = new EmployeeBL(new EmployeeDAL());

            List<Employee> ListEmployee = employeeBL.GetAllEmployees();
            foreach (Employee emp in ListEmployee)
            {
                Console.WriteLine("ID = {0}, Name = {1}, Department = {2}", emp.ID, emp.Name, emp.Department);
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProjectInCore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private IList<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id =1, Name="Marry", Department="HR", Email="marry@somehr.com"},
                new Employee() {Id =2, Name="MarryV", Department="IT", Email="v@somehr.com"},
                new Employee() {Id =3, Name="NEHA", Department="IT", Email="NEHA@somehr.com"}

            };
        }
        Employee IEmployeeRepository.GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == id);
        }
    }
}

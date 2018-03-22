using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Chinook.Data.Entities;
using ChinookSystem.DAL;
using System.ComponentModel;
using Chinook.Data.DTOs;
using Chinook.Data.POCOs;
#endregion
namespace ChinookSystem.BLL
{
    [DataObject]
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<EmployeeClients> Employee_GetClientList()
        {
            //our access to the DB is via the Context class
            using (var context = new ChinookContext())
            {

            
                var results = from employeeRow in context.Employees
                              where employeeRow.Title.Contains("Support")
                              orderby employeeRow.LastName, employeeRow.FirstName
                              select new EmployeeClients
                              {
                                  Name = employeeRow.LastName + ", " + employeeRow.FirstName,
                                  //title = employeeRow.Title,
                                  ClientCount = employeeRow.Customers.Count(),
                                  ClientList = from customerRowOfemployeeRow in employeeRow.Customers
                                               orderby customerRowOfemployeeRow.LastName,
                                                           customerRowOfemployeeRow.FirstName
                                               select new ClientInfo
                                               {
                                                   Client = customerRowOfemployeeRow.LastName + ", " +
                                                                       customerRowOfemployeeRow.FirstName,
                                                   Phone = customerRowOfemployeeRow.Phone
                                               }
                              };
                return results.ToList();
            }
        }
        public Employee Employee_Get(int employeeid)
        {
            using (var context = new ChinookContext())
            {
                return context.Employees.Find(employeeid);
            }

        }
    }
}

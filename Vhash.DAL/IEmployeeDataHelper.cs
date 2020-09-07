using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vhash.Model;
namespace Vhash.DAL
{
    public interface IEmployeeDataHelper
    {
        List<Employee> GetEmployees();
    }
}

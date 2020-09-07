using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vhash.BLL;
using Vhash.Model;
using Vhash.DAL;
using Unity;

namespace Vhash.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult EmployeeList()
        {
            //EmployeeBusinessHelper bh = new EmployeeBusinessHelper(new EmployeeDataHelper());

            var unity = new UnityContainer();
            unity.RegisterType<IEmployeeDataHelper, EmployeeDataHelper>();
            EmployeeBusinessHelper bh = unity.Resolve<EmployeeBusinessHelper>(); 
            return View(bh.GetEmployees());
        }
    }
}
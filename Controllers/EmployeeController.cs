using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
   
    public class EmployeeController : Controller
    {
      static  List<Employee> empList = new List<Employee>()
            {
                new Employee(){ Id = 1, Name="Rupali", FieldExperience =16},
                new Employee(){ Id = 2, Name="Bhavika ", FieldExperience =11},
                new Employee(){ Id = 3, Name="Aniker", FieldExperience =10},
                new Employee(){ Id = 4, Name="Abhishek", FieldExperience =14},
                new Employee(){ Id = 5, Name="Vivek", FieldExperience =12},
                new Employee(){ Id = 6, Name="Sid", FieldExperience =13},

            };
            

        // GET: Employee
        public ViewResult welcome()
        {
            return View();

        }

        public ActionResult index()
        {
            empList.OrderBy(e => e.Name);
            return View(empList);
            
        }

        [Authorize]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            //Get Record DB.
             empList.Add(emp);
           
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            //Get Record DB.
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
            //return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            //Get Record DB.
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            empList.Remove(model);
            return RedirectToAction("index");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //Get Record DB.
            var model = empList.Where(x => x.Id == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp)
        {
            //Save record in db
            Employee dbEmployee = empList.Where(x => x.Id == emp.Id).FirstOrDefault();
            empList.Remove(dbEmployee);
            dbEmployee = emp;
            empList.Add(dbEmployee);
            empList.OrderBy(e => e.Name);

           return RedirectToAction("index");
            
        }


        [HttpGet]
        public ActionResult web()
        {
            var model = new HtmlHelperModel() { Id = 1, Details = "Learning HTML Helper" };
            
            return View(model);
        }
        [HttpPost]
        public ActionResult web(HtmlHelperModel model)
        {
            //save DB
            return RedirectToAction("index");
            //return View(model);
        }
    }
    public class HtmlHelperModel
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public bool isActive { get; set; }
        public bool mood { get; set; }

    }
}
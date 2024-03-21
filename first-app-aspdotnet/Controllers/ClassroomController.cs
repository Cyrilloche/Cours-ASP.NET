using FirstAspDotnetApp.Data;
using FirstAspDotnetApp.Models;
using FirstAspDotnetApp.ViewModels.Classroom;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.Collections.Generic;
using System.Diagnostics;


namespace FirstAspDotnetApp.Controllers
{
    public class ClassroomController(AppData appData) : Controller
    {

        public IActionResult Index()
        {
            var model = new IndexViewModel
            {
                Classrooms = appData.Classrooms,
            };
            return View(model);
        }

        public IActionResult Students(int Id)
        {
            var classroom = appData.Classrooms.Find(x => x.Id ==  Id);
            if (classroom == null)
                return View("/Views/Shared/Error.cshtml", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });

            var model = new StudentsViewModel
            {
                ClassroomName = classroom.Name,
                Students = classroom.Students,
            };
            return View(model);
        }
    }
}

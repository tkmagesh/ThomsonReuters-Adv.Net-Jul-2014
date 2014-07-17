using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TaskManagerApp.Repositories;

namespace TaskManagerApp.Controllers
{
    public class TasksController : Controller
    {
        private TaskRepository _taskRepository;

        public TasksController()
        {
            _taskRepository = new TaskRepository();    
        }
        //
        // GET: /Tasks/

        public ActionResult Index()
        {
            var tasks = _taskRepository.GetAll();
            TempData["Tasks"] = tasks;
            return View();
        }

        [HttpGet]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public ActionResult New(string taskName)
        {
            _taskRepository.AddNew(taskName);
            return RedirectToAction("Index");
        }

    }
}

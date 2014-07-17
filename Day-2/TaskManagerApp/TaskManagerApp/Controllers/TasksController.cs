using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TaskManagerApp.Models;
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
            return View("NewOrEdit", new Task());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var task = _taskRepository.Get(id);
            return View("NewOrEdit", task);
        }

        [HttpPost]
        public ActionResult Save(Task task)
        {
            if (!ModelState.IsValid)
            {
                return View("NewOrEdit", task);
            }
            if (task.Id == -1)
            {
                _taskRepository.AddNew(task);
            }
            else
            {
                _taskRepository.Update(task);
            }
            
            return RedirectToAction("Index");
        }

    }
}

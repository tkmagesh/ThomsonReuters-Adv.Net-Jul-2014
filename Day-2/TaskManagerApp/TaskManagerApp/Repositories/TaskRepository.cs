﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerApp.Models;

namespace TaskManagerApp.Repositories
{
    public class TaskRepository
    {
        private static List<Task> _tasks;

        static TaskRepository()
        {
            _tasks = new List<Task>
            {
                new Task(){Name = "Explore ASP.NET MVC", Id = 1, IsCompleted = false},
                new Task(){Name = "Master JavaScript", Id = 2, IsCompleted = false},
                new Task(){Name = "Learn Angular.js", Id = 3, IsCompleted = true}
            };
        }

        public Task[] GetAll()
        {
            return _tasks.ToArray();
        }


        public void AddNew(string taskName)
        {
            var newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            _tasks.Add(new Task(){Name = taskName, Id = newId, IsCompleted = false});
        }
    }
}
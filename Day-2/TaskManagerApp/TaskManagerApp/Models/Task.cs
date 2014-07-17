using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerApp.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsCompleted { get; set; }
    }
}
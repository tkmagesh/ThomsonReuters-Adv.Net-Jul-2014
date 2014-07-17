using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskManagerApp.Models
{
    public class Task
    {
        public Task()
        {
            Id = -1;
        }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        
        public bool IsCompleted { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
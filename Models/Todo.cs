using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Todo : Base
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string Status { get; set; }
        public virtual User? User { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Dto
{
    public class UpdateTodoDto
    {
        public string NameTodo { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
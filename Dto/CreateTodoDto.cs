using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Dto
{
    public class CreateTodoDto
    {
        public string NameTodo { get; set; }
        public string Description { get; set; }

    }
}
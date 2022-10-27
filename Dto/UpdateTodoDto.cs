using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Dto
{
    public class UpdateTodoDto
    {
        public int TodoId {get; set;}
        public string NameTodo {get; set;}
        public string Description {get; set;}
        public DateTime DateUpdated {get; set;}
        public string Status {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Todo
    {
        public int TodoId {get; set;}
        public string NameTodo {get; set;}
        public string Description {get; set;}
        public string UserId {get; set;}
        public DateTime DateCreated {get; set;}
        public DateTime DateUpdated {get; set;}
        public string Status {get; set;}



    }
}
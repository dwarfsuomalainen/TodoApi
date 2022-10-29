using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class User
    {
        
        public int UserId {get; set;}
        public string UserEmail {get; set;}
        public string UserPassword {get; set;}
        public DateTime DateCreated {get; set;}
        public DateTime DateUpdated {get; set;}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevContactDirectory.Models
{
    public class Developer
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
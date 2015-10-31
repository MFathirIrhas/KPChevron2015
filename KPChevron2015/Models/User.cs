using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KPChevron2015.Models
{
    public class User
    {
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
 
    }
}
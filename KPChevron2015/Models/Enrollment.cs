using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPChevron2015.Models
{
    public class Enrollment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string EnrollmentID { get; set; }
        public int UserID { get; set; }
        public string RoleID { get; set; }
        public string Name { get; set; }
        public string RoleName { get; set; }
        public string Team { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPChevron2015.Models
{
    public class Role
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDesc { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

    }
}
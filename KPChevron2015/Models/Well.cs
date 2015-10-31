using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPChevron2015.Models
{
    public class Well
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string WellID { get; set; }
        public string WellName { get; set; }
        public string Location { get; set; }
        public string Area { get; set; }
        [Display(Name="Last Survey Type")]
        public string LastSurveyType { get; set; }
        [Display(Name = "Last Survey Date")]
        public DateTime LastSurveyDate { get; set; }

        public virtual ICollection<Survey> Surveys { get; set; }

    }
}
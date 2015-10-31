using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPChevron2015.Models
{
    public class GeneralParameter
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string GeneralParameterID { get; set; }
        public string ParameterDesc { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace KPChevron2015.Models
{
    public class Contractor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ContractorID { get; set; }
        public string ContractorName { get; set; }
        public string Remark { get; set; }

    }
}
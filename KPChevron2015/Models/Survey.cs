using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace KPChevron2015.Models
{
    public class Survey
    {
        public int SurveyID { get; set; }
        public string WellID { get; set; }
        public string SurveyDesc { get; set; }
        public string Type { get; set; }
        public string Team { get; set; }
        public string RequestBy { get; set; }
        public DateTime RequestDate { get; set; }

        public string Comment { get; set; }
        public string Status { get; set; }
        public string Progress { get; set; }

        public string ApprovedBy { get; set; }
        public DateTime ApprovedDate { get; set; }

        public string SubmitBy { get; set; }
        public DateTime SubmitDate { get; set; }
        public string PICName { get; set; }

        public byte[] FileData { get; set; }

        
        public Well Well { get; set; }

    }
}
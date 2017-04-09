using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class ICD_10_CM_Category
    {
        public int ID { get; set; }
        public int ICD_10_CM_DiagnosisSectionCodeID { get; set; }
        //public string ICD_10_CM_Code { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public virtual ICD_10_CM_DiagnosisSectionCode ICD_10_CM_DiagnosisSectionCode { get; set; }

    }
}
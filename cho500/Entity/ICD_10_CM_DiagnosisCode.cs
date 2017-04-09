using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class ICD_10_CM_DiagnosisCode
    {
        public int ID { get; set; }
        public int ICD_10_CM_CodeRangeID { get; set; }
        public string DiagnosisCodeRange { get; set; }
        public string Description { get; set; }


        public virtual ICD_10_CM_CodeRange ICD_10_CM_CodeRange { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class ICD_10_CM_DiagnosisSectionCode
    {
        public int ID { get; set; }
        public int ICD_10_CM_DiagnosisCodeID { get; set; }
        public string DiagnosisSectionCode { get; set; }
        public string Description { get; set; }

        public virtual ICD_10_CM_DiagnosisCode ICD_10_CM_DiagnosisCode { get; set; }
    }
}
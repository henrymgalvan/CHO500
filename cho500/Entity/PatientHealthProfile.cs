using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class PatientHealthProfile
    {
        public int ID { get; set; }
        public int PersonID { get; set; }
        public string AdmittedBy { get; set; }
        public DateTime DateOfConsult { get; set; }
        public string ChiefComplaint { get; set; }
        public string BPFirstReading { get; set; }
        public string BPSecondReading { get; set; }
        public int PulseRate { get; set; }
        public int RR { get; set; }
        public decimal Temperature { get; set; }
        public decimal WeightInKgms { get; set; }
        public decimal HeightInCm { get; set; }
        public decimal WaistCircumference { get; set; }
    }
}
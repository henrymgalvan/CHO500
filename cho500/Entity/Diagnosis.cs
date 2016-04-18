using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class Diagnosis
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public virtual Person Patient { get; set; }
        public int ServicesId { get; set; }
        public virtual Services ServiceDesired { get; set; }
        public string ChiefComplaint { get; set; }
        public decimal Temperature { get; set; }
        public int PulseRate { get; set; }
        public string ResperatoryRate { get; set; }
        public string BloodPressure { get; set; }
        public Staff NurseAttendant { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:YYYY-MM-dd", ApplyFormatInEditMode = true)]
        public DateTime DateOfDiagnosis { get; set; }
        public Staff AttendingPhysician { get; set; }
        public string DoctorsDiagnosis { get; set; }
        public string ReferredTo { get; set; }
        public string OtherServicesRendered { get; set; }
        public string Notes { get; set; }

        //Recommended Medication

        public virtual ICollection<RecommendedMedication> RecommendedMedications { get; set; }
    }
}
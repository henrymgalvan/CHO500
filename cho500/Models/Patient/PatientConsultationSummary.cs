using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Models.Patient
{
    public class PatientConsultationSummary
    {
        public int ConsultationID { get; set; }
        public string ChiefComplaint { get; set; }
        public string AdmittedBy { get; set; }
        public DateTime DateOfConsult { get; set; }
        public DateTime PreviousConsultDate { get; set; }
        public Entity.PlaceOfPreviousConsult PreviousConsult { get; set; }
        public int Age { get; set; }
        public string PhysiciansName { get; set; }

    }

}
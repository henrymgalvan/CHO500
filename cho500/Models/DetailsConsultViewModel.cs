﻿using cho500.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace cho500.Models
{
    public class DetailsConsultViewModel
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string AdmittedBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfConsult { get; set; }
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string PreviousConsultDate { get; set; }
        public Entity.PlaceOfPreviousConsult PreviousConsult { get; set; }
        public string ChiefComplaint { get; set; }
        public int Age { get; set; }

        public string BPFirstReading { get; set; }
        public string BPSecondReading { get; set; }
        public string BPAverage { get; set; }
        public Boolean RaisedBP { get; set; }
        public int PulseRate { get; set; }
        public int RR { get; set; }
        public decimal Temperature { get; set; }

        public decimal WeightInKgms { get; set; }
        public decimal HeightInCm { get; set; }
        public decimal WaistCircumferenceInCm { get; set; }
        public bool CentralAdiposity { get; set; }
        public decimal BMI { get; set; }
        public BMIStatus BMIStatus { get; set; }

        public string History { get; set; }
        public string PhysicalExam { get; set; }
        public string DiagnosisLabResult { get; set; }
        public string ManagementTreatment { get; set; }
        public string Recommendation { get; set; }
        public string Pharmacy { get; set; }
        public string Physician { get; set; }



    }
}
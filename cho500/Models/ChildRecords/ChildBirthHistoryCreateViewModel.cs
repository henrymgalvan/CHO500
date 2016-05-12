using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Models.ChildRecords
{
    public class ChildBirthHistoryCreateViewModel
    {
        public int Id { get; set; }
        public int Months { get; set; }
        public int Weeks { get; set; }
        public int Days { get; set; }
        public string TypeOfDelivery { get; set; }
        public decimal BirthWeightInPounds { get; set; }
        public decimal BirthLength { get; set; }
        public decimal HeadCircumference { get; set; }
        public decimal ChestCircumference { get; set; }
        public decimal AbdominalCircumference { get; set; }
        public string BloodType { get; set; }
    }
}
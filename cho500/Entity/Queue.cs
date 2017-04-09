using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class Queue
    {
        public int ID { get; set; }
        public int QueueNo { get; set; }
        public DateTime DateTimeQueued { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FamilyName { get; set; }
        public DateTime Birthday { get; set; }
        public string PhilHealthNo { get; set; }
        public string ChiefComplaint { get; set; }
        public string Barangay { get; set; }
        public string HouseholdNo { get; set; }
        public string Status { get; set; }
        public bool Served { get; set; }


    }
}
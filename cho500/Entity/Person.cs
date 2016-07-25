using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cho500.Entity
{
    public class Person
    {
        public enum Gender
        {
            Male = 1, Female = 2
        }
        public enum State
        {
            Dependent = 1, Single, Married, Separated, Annuled
        }

        [Key]
        public int PersonID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 1)]    //ErrorMessage = "First name cannot be longer than 50 characters."
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(50)]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public Gender Sex { get; set; }
        public State CivilStatus { get; set; }
        public string HouseholdProfileID { get; set; }
        public string PhilHealthNo { get; set; }   //new
        [Phone]
        public string ContactNumber { get; set; }
        public string Encoder { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName + " " + MiddleName;
            }
        }

        public virtual ICollection<Consultation> Consultations { get; set; }

        public int? BloodTypeID { get; set; }
        public virtual BloodType BloodType { get; set; }

        public virtual ChildHealthRecord ChildHealthRecords { get; set; }
        //public virtual HouseholdProfile HouseholdProfile { get; set; }
    }
}
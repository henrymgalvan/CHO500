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
            Dependent, Single, Married, Separated, Annuled
        }

        public int ID { get; set; }
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
        public DateTime DateOfBirth { get; set; }
        public Gender Sex { get; set; }
        public State Status { get; set; }
        public Boolean Deceased { get; set; }
        public int BloodTypesId { get; set; }
        public virtual BloodTypes BloodTypes { get; set; }
        public string FathersName { get; set; }
        public string MothersName { get; set; }
        public string Address { get; set; }
        public string Barangay { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string RelationshipToContact { get; set; }
        [Phone]
        public string PhoneNoOfContact { get; set; }
        [Phone]
        public string PatientContactNumber { get; set; }
        public string PhilHealth { get; set; }
        public int CreatedByStaffId { get; set; }
        public virtual Staff Staff { get; set; }
        public DateTime DateCreated { get; set; }
        public string Notes { get; set; }
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstName + " " + MiddleName;
            }
        }


    }
}
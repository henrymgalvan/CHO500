using cho500.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cho500.Models
{ 
    public class CreatePersonViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, MinimumLength = 1,ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        [Display(Name = "Middle Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Middle name cannot be longer than 50 characters.")]
        public string MiddleName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        public Person.Gender Sex { get; set; }
        public Person.State CivilStatus { get; set; }
        public int? BloodTypeID { get; set; }
        public string PhilHealthNo { get; set; }   //new
        [Phone]
        public string ContactNumber { get; set; }
        public string Encoder { get; set; }
        public DateTime DateCreated { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}
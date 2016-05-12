using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cho500.Models
{
    public class EditPersonViewModel
    {
        [HiddenInput]
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
        public Entity.Person.Gender Sex { get; set; }
        public Entity.Person.State CivilStatus { get; set; }
        public string Address { get; set; }
        public int BarangayID { get; set; }
        public int HouseHoldNo { get; set; }
        [Phone]
        public string ContactNumber { get; set; }
        public string Encoder { get; set; }
        public DateTime DateCreated { get; set; }
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}
﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidlly.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        //[Display(Name = "Date of Birth")]
        [Min18YearIfAMember]
        public DateTime? Birthdate { get; set;}
    }
}
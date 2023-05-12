using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using Vidlly.Models;

namespace Vidlly.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }
        [Required]
        [StringLength(255)]
        public string name { get; set; }
        public bool isSubscribedToNewsLetter { get; set; }
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        //[Display(Name = "Date of Birth")]
        //[Min18YearIfAMember]
        public DateTime? Birthdate { get; set; }
    }
}
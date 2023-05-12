using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Vidlly.Models;

namespace Vidlly.ViewModels
{
    public class CustomerFormViewModel
    {
         public IEnumerable<MembershipType> membershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}
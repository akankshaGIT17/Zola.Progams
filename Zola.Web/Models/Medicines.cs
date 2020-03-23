using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zola.Web.Models
{
    public class Medicines : BaseClass
    {
        
        public string Name { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpiryDate { get; set; }

    }
}
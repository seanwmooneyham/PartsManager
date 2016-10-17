using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartsManager.Models
{
    public class PartLocation
    {
        public int Id { get; set; }

        [Display(Name = " Part Location:")]
        public string LocationName { get; set; }
    }
}
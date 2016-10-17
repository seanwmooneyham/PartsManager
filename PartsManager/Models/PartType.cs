using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PartsManager.Models
{
    public class PartType
    {
        public int Id { get; set; }

        [Display(Name = " Part Type:")]
        public string PartTypeName { get; set; }
        
    }
}
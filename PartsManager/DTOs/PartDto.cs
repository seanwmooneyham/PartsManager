using PartsManager.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PartsManager.DTOs
{
    public class PartDto
    {
        public int Id { get; set; }

        // Name of Part to be cataloged
        [Required]
        [StringLength(255)]
        [Display(Name = " Part Name:")]
        public string PartName { get; set; }


        // Identifying number for part.
        [Required]
        [StringLength(30)]
        [Display(Name = " Part Number:")]
        public string PartNumber { get; set; }

        // Identifying number for part manufacturer, will always be five alpha numeric characters.
        [Required]
        [StringLength(5)]
        [Display(Name = " Manufacturer Code:")]
        public string ManufacturerCode { get; set; }

        public PartTypeDto PartType { get; set; }


        // PartType foreign key
        [Display(Name = " Part Type")]
        public int PartTypeId { get; set; }

        public PartLocationDto PartLocation { get; set; }

        // PartLocation foreign key

       // [Display(Name = " Part Location")]
        //public int PartLocationId { get; set; }

        //******Commented out PartType and PartLocation so that the Data Transfer Object is not dependent on the domain model.  ************************

        // Navigation Property (PartType.cs)
        //[Display(Name = " Part Type:")]
        //public PartType PartType { get; set; }

       


        //Navigation Property (PartLocation)
        //[Display(Name = " Part Location:")]
        //[ForeignKey("PartLocationId")]
        //public PartLocation PartLocation { get; set; }

       

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace PartsManager.Models
{
    // domain model for space craft Parts.

    public class Part
    {
        public int Id { get; set; }

        // Name of Part to be cataloged
        [Required]
        [StringLength(255)]
        [Display(Name=" Part Name:")]
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

        // Navigation Property (PartType.cs)
        [Display(Name = " Part Type:")]
        public PartType PartType { get; set; }

        // Foreign key for PartType.cs
        [Display(Name = " Part Type")]
        public int PartTypeId { get; set; }

        //Navigation Property (PartLocation)
        [Display(Name = " Part Location:")]
        [ForeignKey("PartLocationId")]
        public PartLocation PartLocation { get; set; }

        // Foreign key for PartLocation.cs
        [Display(Name = " Part Location")]
        public int PartLocationId { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace FittingsManager.Models
{
    // domain model for space craft fittings.

    public class Fitting
    {
        public int Id { get; set; }

        // Name of Fitting to be cataloged
       // [Required]
        [StringLength(255)]
        [Display(Name = " Fitting Name")]
        public string FittingName { get; set; }


        // Identifying number for fitting.
       // [Required]
        [StringLength(255)]
        [Display(Name = " Fitting Number")]
        public string FittingNumber { get; set; }

        // Identifying number for fitting manufacturer, will always be five alpha numeric characters.
       // [Required]
        [StringLength(5)]
        [Display(Name = " Manufacturer Code")]
        public string ManufacturerCode { get; set; }

        // Navigation Property (FittingType.cs)
        [Display(Name = " Fitting Type")]
        public FittingType FittingType { get; set; }

        // Foreign key for FittingType.cs
      
        public int FittingTypeId { get; set; }

        //Navigation Property (FittingLocation)

       
       [Display(Name = "Fitting Location")]
        public FittingLocation FittingLocation { get; set; }

        // Foreign key for FittingLocation.cs
        
        public int FittingLocationId { get; set; }
    }
}
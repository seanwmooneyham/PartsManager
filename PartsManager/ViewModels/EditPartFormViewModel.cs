using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PartsManager.Models;

namespace PartsManager.ViewModels
{
    public class EditPartFormViewModel
    {

        // This constructor is used for a new part, the Id populates the hidden field in PartForm.
        public EditPartFormViewModel()
        {
            Id = 0;
        }

        // This constructor is used when a part is edited.
        public EditPartFormViewModel(Part part)
        {
            PartName = part.PartName;
            PartNumber = part.PartNumber;
            ManufacturerCode = part.ManufacturerCode;
            PartLocationId = part.PartLocationId;
            PartTypeId = part.PartTypeId;
            PartImage = part.PartImage;

        }


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

        // Only the Id is used in the view model
        [Display(Name = " Part Location")]
        public int PartLocationId { get; set; }
        public IEnumerable<PartLocation> PartLocations { get; set; }

        // Only the Id is used in the view model
        [Display(Name = " Part Type")]
        public int PartTypeId { get; set; }
        public IEnumerable<PartType> PartTypes { get; set; }

        [Required(ErrorMessage = "An image is required.")]
        [Display(Name = "Module Image")]
        public string PartImage { get; set; }

    }
}
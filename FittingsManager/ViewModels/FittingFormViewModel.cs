using FittingsManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FittingsManager.ViewModels
{
    public class FittingFormViewModel
    {
        public Fitting Fitting { get; set; }

        public IEnumerable<FittingType> FittingTypes { get; set; }

        public IEnumerable<FittingLocation> FittingLocations { get; set; }
    }
}
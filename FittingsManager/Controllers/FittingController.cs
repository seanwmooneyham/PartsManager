using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FittingsManager.Models;
using FittingsManager.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace FittingsManager.Controllers
{
    public class FittingController : Controller
    {
        // declare variable to access database
        private ApplicationDbContext _context;

        // initialize ApplicationDbContext in CustomersController Constructor
        public FittingController()
        {
            _context = new ApplicationDbContext();
        }

        // dispose of ApplicaitonDbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // 'New' Action is called when user initializes 'New Fitting' button in Views/Fitting/Index.cshtml
        public ActionResult New()
        {
            // added DbSet FittingType and FittingLocation to IdentityModels.ApplicationDbContext
            var fittingTypes = _context.FittingTypes.ToList();
            var fittingLocations = _context.FittingLocations.ToList();
            var viewModel = new FittingFormViewModel
            {
                FittingTypes = fittingTypes,
                FittingLocations = fittingLocations
            };
            return View("FittingForm", viewModel);
        }

        // MVC framework will map request data to viewModel object 'model binding'
        // viewModel is binded to the request data
        [HttpPost]
        public ActionResult Save(Fitting fitting)
        {
            if (fitting.Id == 0)
            {
                
                _context.Fittings.Add(fitting);
            }
            else
            {
                var fittingInDb = _context.Fittings.Single(f => f.Id == fitting.Id);


                fittingInDb.FittingName = fitting.FittingName;
                fittingInDb.FittingNumber = fitting.FittingNumber;
                fittingInDb.ManufacturerCode = fitting.ManufacturerCode;
                fittingInDb.FittingTypeId = fitting.FittingTypeId;
                fittingInDb.FittingLocationId = fitting.FittingLocationId;



                // the following line of code will work, however it will introduce security flaws
                //TryUpdateModel(customerInDb);

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Fitting");
        }

        //public ActionResult NewFitting()
        //{
        //    var fittingTypes = _context.FittingTypes.ToList();
        //    var fittingLocations = _context.FittingLocations.ToList();
        //    var viewModel = new NewFittingViewModel()
        //    {
        //        FittingTypes = fittingTypes,
        //        FittingLocations = fittingLocations
        //    };
        //    return View(viewModel);
        //}

        public ActionResult Index()
        // retreive Fittings model via DbContext
        // Include method is used for 'eager loading' to include the navigation property (and cooresponding class)
        {
            var fittings = _context.Fittings.Include(f => f.FittingType)
                                            .Include(f => f.FittingLocation).ToList();
                                            
            

            var viewModel = new FittingListViewModel()
            {
                Fittings = fittings
            };

            return View(viewModel);
        }

        // Fitting Details Controller
        public ActionResult Details(int id)
        {
            // retreive Fittings model via DbContext
            // Include method is used for 'eager loading' to include the navigation property (and coresponding class)
            var fitting = _context.Fittings.Include(f => f.FittingLocation)
                                           .Include(f => f.FittingType).SingleOrDefault(f => f.Id == id);
            


            // create new FittingDetailViewModel object setting the property value FittingDetail to the selected part.
            var viewModel = new FittingDetailsViewModel()
            {
                FittingDetail = fitting
            };

            // if no fitting Id exists
            if (fitting == null)
                return Content("No fitting details have been found.");

            return View(viewModel);
        }


        public ActionResult Edit(int id)
        {
            var fitting = _context.Fittings.SingleOrDefault(f => f.Id == id);

            if (fitting == null)
                return HttpNotFound();

            var viewModel = new FittingFormViewModel
            {
                Fitting = fitting,
                FittingTypes = _context.FittingTypes.ToList(),
                FittingLocations = _context.FittingLocations.ToList()
            };

            return View("FittingForm", viewModel);
        }




        // creat fitting objects

        //private IEnumerable<Fitting> GetFittings()

        //{
        //    return new List<Fitting>
        //    {
        //        new Fitting()
        //        {
        //            Id = 1,
        //            PartName = "Warp Stabalizer",
        //            PartNumber = "805054-22122",
        //            ManufacturerCode = "558055",
        //            SerialNumber = "0002323554545858"
        //        },
        //        new Fitting()
        //        {
        //            Id = 2,
        //            PartName = "Heavy Missile Stabalizer",
        //            PartNumber = "909054-22122",
        //            ManufacturerCode = "558055",
        //            SerialNumber = "9811323554545858"
        //        },
        //        new Fitting()
        //        {
        //            Id = 3,
        //            PartName = "Light Rocket Stabalizer",
        //            PartNumber = "805660-22122",
        //            ManufacturerCode = "558055",
        //            SerialNumber = "6548323554545858"
        //        }
        //    };

        //}
    }
}
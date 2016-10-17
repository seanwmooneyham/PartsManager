using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PartsManager.Models;
using PartsManager.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace PartsManager.Controllers
{
    public class PartsController : Controller
    {
        // declare variable to access database
        private ApplicationDbContext _context;

        // initialize ApplicationDbContext in CustomersController Constructor
        public PartsController()
        {
            _context = new ApplicationDbContext();
        }

        // dispose of ApplicaitonDbContext
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // New part controller
        public ActionResult NewPart()
        {
            var PartTypes = _context.PartTypes.ToList();
            var PartLocations = _context.PartLocations.ToList();
            var viewModel = new PartFormViewModel()
            {
                PartTypes = PartTypes,
                PartLocations = PartLocations
            };
            return View("PartForm", viewModel);
        }

        // Edit part controller
        public ActionResult Edit(int id)
        {
            var part = _context.Parts.SingleOrDefault(c => c.Id == id);

            if (part == null)
                return HttpNotFound();

            var viewModel = new PartFormViewModel(part)
            {
                PartLocations = _context.PartLocations.ToList(),
                PartTypes = _context.PartTypes.ToList()
            };

            return View("PartForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePart(Part part)
        {
            //If user input is not valid, user is redirected to EditPartForm or NewPartForm.
            if (!ModelState.IsValid)
            {
               
                    var viewModel = new PartFormViewModel
                    {
                        PartLocations = _context.PartLocations.ToList(),
                        PartTypes = _context.PartTypes.ToList()
                    };
                    return View("PartForm", viewModel);
             
            }
            if (part.Id == 0)
            {
                _context.Parts.Add(part);
            }
            else
            {
                var partInDb = _context.Parts.Single(m => m.Id == part.Id);


                partInDb.PartName = part.PartName;
                partInDb.PartNumber = part.PartNumber;
                partInDb.ManufacturerCode = part.ManufacturerCode;
                partInDb.PartTypeId = part.PartTypeId;
                partInDb.PartLocationId = part.PartLocationId;
                
                // the following line of code will work, however it will introduce security flaws
                //TryUpdateModel(customerInDb);

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Parts");
        }

        public ActionResult Index()
        // retreive Parts model via DbContext
        // Include method is used for 'eager loading' to include the navigation property (and cooresponding class)
        {
            var Parts = _context.Parts.Include(f => f.PartType)
                                            .Include(f => f.PartLocation).ToList();
                                            
            

            var viewModel = new PartListViewModel()
            {
                Parts = Parts
            };

            return View(viewModel);
        }

        // Part Details Controller
        public ActionResult Details(int id)
        {
            // retreive Parts model via DbContext
            // Include method is used for 'eager loading' to include the navigation property (and coresponding class)
            var part = _context.Parts.Include(f => f.PartLocation)
                                           .Include(f => f.PartType).SingleOrDefault(f => f.Id == id);
            


            // create new PartDetailViewModel object setting the property value PartDetail to the selected part.
            var viewModel = new PartDetailsViewModel()
            {
                PartDetail = part
            };

            // if no part Id exists
            if (part == null)
                return Content("No part details have been found.");

            return View(viewModel);
        }

        
    }
}
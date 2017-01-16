using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AutoMapper;
using PartsManager.Models;
using PartsManager.ViewModels;

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
        [Authorize(Roles = RoleName.CanManageParts)]
        public ActionResult NewPart()
        {
            var partTypes = _context.PartTypes.ToList();
            var partLocations = _context.PartLocations.ToList();
            var viewModel = new PartFormViewModel()
            {
                PartTypes = partTypes,
                PartLocations = partLocations
            };
            return View("PartForm", viewModel);
        }

        // Edit part controller
        [Authorize(Roles = RoleName.CanManageParts)]
        public ActionResult Edit(int id)
        {
            var part = _context.Parts.SingleOrDefault(c => c.Id == id);

            if (part == null)
                return HttpNotFound();

            var viewModel = new EditPartFormViewModel(part)
            {
                PartLocations = _context.PartLocations.ToList(),
                PartTypes = _context.PartTypes.ToList(),
                PartImage = part.PartImage
            };

            return View("EditPartForm", viewModel);
        }

        // SAVE NEW part

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageParts)]
        [ValidateAntiForgeryToken]
        public ActionResult SavePart(HttpPostedFileBase file, Part part)
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

            // Add file to server.
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                if (fileName == null)
                    throw new Exception("The file does not have a file name.");

                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                file.SaveAs(path);
                part.PartImage = fileName;
            }

           // if (part.Id == 0)
            //{
                _context.Parts.Add(part);
                
           // }
            //else
            //{
            //    var partInDb = _context.Parts.Single(p => p.Id == part.Id);


            //    partInDb.PartName = part.PartName;
            //    partInDb.PartNumber = part.PartNumber;
            //    partInDb.ManufacturerCode = part.ManufacturerCode;
            //    partInDb.PartTypeId = part.PartTypeId;
            //    partInDb.PartLocationId = part.PartLocationId;
            //    partInDb.PartImage = Path.GetFileName(file.FileName);

            //}

            _context.SaveChanges();
            return RedirectToAction("Index", "Parts");
        }


        //////////////Save Edited Part ////////////////////////

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageParts)]
        [ValidateAntiForgeryToken]
        public ActionResult SavePartEdit(HttpPostedFileBase file, Part part)
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
                var partInDb = _context.Parts.Single(p => p.Id == part.Id);

                partInDb.PartName = part.PartName;
                partInDb.PartNumber = part.PartNumber;
                partInDb.ManufacturerCode = part.ManufacturerCode;
                partInDb.PartTypeId = part.PartTypeId;
                partInDb.PartLocationId = part.PartLocationId;
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Parts");
        }

        /////////// // Save Image ///////////////
        public ActionResult SaveImage(HttpPostedFileBase file, Part part)
        {
            // Add file to server.
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                if (fileName == null)
                    throw new Exception("The file does not have a file name.");

                var path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
                file.SaveAs(path);
                part.PartImage = fileName;
            }
            else
            {
                //throw new Exception("Invalid file.");
                ModelState.AddModelError("CustomError", "This field is required");
                var viewModel = new PartFormViewModel
                {
                    PartLocations = _context.PartLocations.ToList(),
                    PartTypes = _context.PartTypes.ToList()
                };
                return View("PartForm", viewModel);
            }
            var partInDb = _context.Parts.Single(p => p.Id == part.Id);
            partInDb.PartImage = Path.GetFileName(file.FileName);

            _context.SaveChanges();
            return RedirectToAction("Index", "Parts");
        }

        public ActionResult Index()
        {
           if (User.IsInRole("CanManageParts"))
            return View();

            return View("ReadOnlyIndex");

            // retreive Parts model via DbContext
            // Include method is used for 'eager loading' to include the navigation property (and cooresponding class)
            // code below was used before adding data table script to view.  This code was executed before the return statement.

            //var Parts = _context.Parts.Include(f => f.PartType).Include(f => f.PartLocation).ToList();
            //var viewModel = new PartListViewModel()
            //{
            //    Parts = Parts
            //};
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
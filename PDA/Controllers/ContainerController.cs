
using PDA.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Oracle.ManagedDataAccess.Client;
using PDA.Interceptor;
using PDA.Models;
using PDA.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace PDA.Controllers
{
    public class ContainerController : Controller
    {
     
        private readonly IInterceptorService _interceptorService;
     
        private string _connectionString;

        private readonly ApplicationContext _context;
        public ContainerController( IInterceptorService interceptorService,ApplicationContext context)
        {
          _context = context;
            _interceptorService = interceptorService;
            _connectionString = Environment.GetEnvironmentVariable("PDAConnection", EnvironmentVariableTarget.User);
        }


        public async Task<IActionResult> container()
        {
            ViewBag.DamageItems = await _context.Damages.ToListAsync();
            //if (HttpContext.Session.GetString("userName") is null)
            //{
            //    TempData["LoginExpired"] = "you should login at first!";
            //    return RedirectToAction("Login", "User");
            //}
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> container(ContainerDamageReportVM containerDamageReport)
        //{
        //    ContainerInformation addedContainer = new ContainerInformation()
        //    {
        //        ContainerNumber = containerDamageReport.ContainerNumber,
        //        RotationNumber = containerDamageReport.RotationNumber,
        //        Date = containerDamageReport.Date,
        //        Size = containerDamageReport.Size,
        //        Type = containerDamageReport.Type,
        //        MadeOf = containerDamageReport.MadeOf,
        //        ContainerImage = containerDamageReport.ContainerImage,
        //        VesselVoyageId = ViewBag.Total,
        //    };
        //    addedContainer.DamagedContainers = new List<DamageContainer>()
        //    {
        //        new DamageContainer()
        //        {
        //            DamageId = containerDamageReport.DamageCodes[0],
        //        }, new DamageContainer()
        //        {
        //            DamageId = containerDamageReport.DamageCodes[1],
        //        },

        //        new DamageContainer()
        //        {
        //            Comments=containerDamageReport.Remarks
        //        }
        //    };

        //    addedContainer.DamagedContainers = new List<VesselLashing>()
        //    {
        //         new VesselLashing()
        //        {
        //            ChiefOfficerSignature=containerDamageReport.ChiefOfficerSignature
        //        }

        //    };




        //    await _context.AddAsync(addedContainer);
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //    return View();
        //}






        //[HttpPost]
        //public async Task<IActionResult> Container(ContainerDamageReportVM containerDamageReport)
        //{
        //    // Validate DamageCodes
        //    if (containerDamageReport.DamageCodes == null || !containerDamageReport.DamageCodes.Any())
        //    {
        //        ModelState.AddModelError("", "Damage codes are required.");
        //        return View();
        //    }

        //    // Retrieve VesselVoyageId from the database or ensure it is valid
        //    //var vesselVoyage = await _context.VesselVoyages
        //    //    .FirstOrDefaultAsync(v => v.Id == ViewBag.Total); // Assuming ViewBag.Total is the VesselVoyageId

        //    //if (vesselVoyage == null)
        //    //{
        //    //    ModelState.AddModelError("", "Invalid Vessel Voyage ID.");
        //    //    return View(containerDamageReport);
        //    //}

        //    // Create a new ContainerInformation object
        //    var addedContainer = new ContainerInformation
        //    {
        //        ContainerNumber = containerDamageReport.ContainerNumber,
        //        RotationNumber = containerDamageReport.RotationNumber,
        //        Date = containerDamageReport.Date,
        //        Size = containerDamageReport.Size,
        //        Type = containerDamageReport.Type,
        //        MadeOf = containerDamageReport.MadeOf,
        //        ContainerImage = containerDamageReport.ContainerImage,
        //        //VesselVoyageId = vesselVoyage.Id, // Set the valid VesselVoyageId
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = User.Identity?.Name, // Assuming you're using authentication
        //        Actions = "Created",
        //        IsActive = true
        //    };

        //    // Add related DamageContainers
        //    addedContainer.DamagedContainers = containerDamageReport.DamageCodes.Select(code => new DamageContainer
        //    {
        //        DamageId = code,
        //        Comments = containerDamageReport.Remarks, // Add remarks if needed
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = User.Identity?.Name,
        //        Actions = "Added",
        //        IsActive = true
        //    }).ToList();

        //    // Save the ContainerInformation with related data
        //    await _context.AddAsync(addedContainer);

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //        TempData["Success"] = "Container information added successfully.";
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log exception and return error
        //        TempData["Error"] = "An error occurred while saving the data.";
        //        Console.WriteLine(ex); // Replace with proper logging
        //    }

        //    return View();
        //}





        //[HttpPost]
        //public async Task<IActionResult> Container(ContainerDamageReportVM containerDamageReport)
        //{
        //    if (containerDamageReport == null || containerDamageReport.DamageCodes == null || !containerDamageReport.DamageCodes.Any())
        //    {
        //        ModelState.AddModelError("", "Invalid input data.");
        //        return View(containerDamageReport); // Return view with validation errors.
        //    }

        //    // Create the ContainerInformation object
        //    ContainerInformation addedContainer = new ContainerInformation()
        //    {
        //        ContainerNumber = containerDamageReport.ContainerNumber,
        //        RotationNumber = containerDamageReport.RotationNumber,
        //        Date = containerDamageReport.Date,
        //        Size = containerDamageReport.Size,
        //        Type = containerDamageReport.Type,
        //        MadeOf = containerDamageReport.MadeOf,
        //        ContainerImage = containerDamageReport.ContainerImage,
        //        VesselVoyageId = 4, // Ensure ViewBag.Total is populated correctly
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = "test",//User.Identity.Name, // Optional: track logged-in user
        //        IsActive = true
        //    };

        //    // Create DamageContainer objects dynamically for each DamageId in DamageCodes
        //    addedContainer.DamagedContainers = containerDamageReport.DamageCodes
        //        .Select(damageCode => new DamageContainer
        //        {
        //            DamageId = damageCode,
        //            Comments = containerDamageReport.Remarks, // Common remarks for all damages
        //            CreatedDate = DateTime.Now,
        //            CreatedBy = User.Identity.Name,
        //            IsActive = true
        //        }).ToList();





        //    VesselLashing vessel = new VesselLashing()
        //    {
        //        ChiefOfficerSignature=containerDamageReport.ChiefOfficerSignature,
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = "test",//User.Identity.Name, // Optional: track logged-in user
        //        IsActive = true
        //    };

        //    VesselVoyage vesselvoyage = new VesselVoyage()
        //    {
        //       ChiefOfficerName="Ali",//containerDamageReport.ChiefOfficerName,
        //        CreatedDate = DateTime.Now,
        //        CreatedBy = "test",//User.Identity.Name, // Optional: track logged-in user
        //        IsActive = true
        //    };

        //    try
        //    {
        //        // Add ContainerInformation to the database
        //        await _context.AddAsync(addedContainer);

        //        // Optionally, add VesselLashing if associated with the container
        //        await _context.AddAsync(vessel);

        //        await _context.AddAsync(vesselvoyage);


        //        await _context.SaveChangesAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the error for debugging
        //        //_logger.LogError(ex, "An error occurred while saving the container information.");
        //        ModelState.AddModelError("", "An error occurred while processing your request.");
        //        return View(containerDamageReport); // Return the view with an error message
        //    }

        //    // Redirect to a success page or reload the view
        //    return RedirectToAction();
        //}


        [HttpPost]
        public async Task<IActionResult> SaveContainer(ContainerDamageReportVM containerDamageReport)
        {
            if (containerDamageReport == null || containerDamageReport.DamageCodes == null || !containerDamageReport.DamageCodes.Any())
            {
                ModelState.AddModelError("", "Invalid input data.");
                return View(containerDamageReport); // Return view with validation errors.
            }

            // Create VesselVoyage first
            VesselVoyage vesselVoyage = new VesselVoyage
            {
                ChiefOfficerName = "Ali", // Example data, replace with containerDamageReport.ChiefOfficerName if applicable
                CreatedDate = DateTime.Now,
                Actions="Add",
                VesselCode="Ado54",
                CreatedBy = "test",  // Use User.Identity.Name in real scenarios
                IsActive = true
            };

            try
            {
                // Save VesselVoyage and get its Id
                await _context.AddAsync(vesselVoyage);
                await _context.SaveChangesAsync();

                // Use the newly created VesselVoyageId
                int vesselVoyageId = vesselVoyage.Id;

                // Create the ContainerInformation object
                ContainerInformation addedContainer = new ContainerInformation
                {
                    ContainerNumber = containerDamageReport.ContainerNumber,
                    RotationNumber = containerDamageReport.RotationNumber,
                    Date = containerDamageReport.Date,
                    Size = containerDamageReport.Size,
                    Type = containerDamageReport.Type,
                    MadeOf = containerDamageReport.MadeOf,
                    ContainerImage = containerDamageReport.ContainerImage,
                    VesselVoyageId = vesselVoyageId, // Link to the created VesselVoyage
                    CreatedDate = DateTime.Now,
                    CreatedBy = "test", // Use User.Identity.Name in real scenarios
                    IsActive = true
                };

                // Create DamageContainer objects dynamically for each DamageId in DamageCodes
                addedContainer.DamagedContainers = containerDamageReport.DamageCodes
                    .Select(damageCode => new DamageContainer
                    {
                        DamageId = damageCode,
                        Comments = containerDamageReport.Remarks, // Common remarks for all damages
                        CreatedDate = DateTime.Now,
                        CreatedBy = "test", // Use User.Identity.Name
                        IsActive = true
                    }).ToList();

                // Create VesselLashing (optional)
                VesselLashing vesselLashing = new VesselLashing
                {
                    ChiefOfficerSignature = containerDamageReport.ChiefOfficerSignature,
                    CreatedDate = DateTime.Now,
                    Actions="Adding",
                    CreatedBy = "test", // Use User.Identity.Name in real scenarios
                    IsActive = true
                };

                // Save all records
                await _context.AddAsync(addedContainer);
                await _context.AddAsync(vesselLashing);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                //_logger.LogError(ex, "An error occurred while saving the container information.");
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View(); // Return the view with an error message
            }

            // Redirect to a success page or reload the view
            return View(); // Replace "Success" with your actual action
        }


        [HttpPost]
        public async Task<IActionResult> EditContainer(ContainerDamageReportVM containerDamageReport)
        {
            if (containerDamageReport == null || containerDamageReport.DamageCodes == null || !containerDamageReport.DamageCodes.Any())
            {
                ModelState.AddModelError("", "Invalid input data.");
                return View(containerDamageReport); // Return view with validation errors.
            }

            try
            {
                // Retrieve the existing container from the database
                var existingContainer = await _context.ContainerInformations
                    .Include(c => c.DamagedContainers)
                    .FirstOrDefaultAsync(c => c.Id == containerDamageReport.Id);

                if (existingContainer == null)
                {
                    ModelState.AddModelError("", "Container not found.");
                    return View(containerDamageReport); // Return view with error message
                }

                // Update container properties
                existingContainer.ContainerNumber = containerDamageReport.ContainerNumber;
                existingContainer.RotationNumber = containerDamageReport.RotationNumber;
                existingContainer.Date = containerDamageReport.Date;
                existingContainer.Size = containerDamageReport.Size;
                existingContainer.Type = containerDamageReport.Type;
                existingContainer.MadeOf = containerDamageReport.MadeOf;
                existingContainer.ContainerImage = containerDamageReport.ContainerImage;
                existingContainer.VesselVoyageId = ViewBag.Total;
                //existingContainer.ModifiedDate = DateTime.Now;
                //existingContainer.ModifiedBy = User.Identity.Name;

                // Update DamagedContainers
                // Remove existing DamagedContainers and add updated ones
                _context.DamagedContainers.RemoveRange(existingContainer.DamagedContainers);

                existingContainer.DamagedContainers = containerDamageReport.DamageCodes
                    .Select(damageCode => new DamageContainer
                    {
                        DamageId = damageCode,
                        Comments = containerDamageReport.Remarks,
                        CreatedDate = DateTime.Now,
                        CreatedBy = User.Identity.Name,
                        IsActive = true
                    }).ToList();

                // Update VesselLashing if necessary
                var vesselLashing = await _context.VesselLashings
                    .FirstOrDefaultAsync(v => v.Id == existingContainer.Id);

                if (vesselLashing != null)
                {
                    vesselLashing.ChiefOfficerSignature = containerDamageReport.ChiefOfficerSignature;
                    //vesselLashing.ModifiedDate = DateTime.Now;
                    //vesselLashing.ModifiedBy = User.Identity.Name;
                }

                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                //_logger.LogError(ex, "An error occurred while updating the container information.");
                ModelState.AddModelError("", "An error occurred while processing your request.");
                return View(containerDamageReport); // Return view with error message
            }

            return RedirectToAction("container"); // Redirect to a list or success page
        }



        [HttpPost]
        public async Task<IActionResult> DeleteContainer(int id)
        {
            try
            {
                // Retrieve the existing container from the database
                var container = await _context.ContainerInformations
                    .Include(c => c.DamagedContainers)
                    .FirstOrDefaultAsync(c => c.Id == id);

                if (container == null)
                {
                    return NotFound(); // Return 404 if container not found
                }

                // Remove associated damaged containers
                _context.DamagedContainers.RemoveRange(container.DamagedContainers);

                // Remove the container itself
                _context.ContainerInformations.Remove(container);

                // Optionally, remove associated VesselLashing
                var vesselLashing = await _context.VesselLashings.FirstOrDefaultAsync(v => v.Id == id);
                if (vesselLashing != null)
                {
                    _context.VesselLashings.Remove(vesselLashing);
                }

                await _context.SaveChangesAsync(); // Save changes to the database
            }
            catch (Exception ex)
            {
                // Log the error for debugging
                //_logger.LogError(ex, "An error occurred while deleting the container.");
                return StatusCode(500, "An error occurred while processing your request."); // Return 500 status code
            }

            return RedirectToAction("Index"); // Redirect to a list or success page
        }


        [HttpPost("GetContainerDetails")]
        public ActionResult<double?> GetContainerDetails([FromBody] string containerNo)
        {
            try
            {
                // Construct the request body with filter values
                var filters = new
                {
                    filters = new
                    {
                        eqpNbr = "OOCU8187882", 
                        
                    }
                };

                // Serialize the filters object to a JSON string
                var billingEventBody = JsonConvert.SerializeObject(filters);

                // Execute the POST request using the interceptor service
                var response = _interceptorService.ExecutePost<EquipmentInventoryResponse<Dataviews<ContainerRecord>>>("data/dataviews/eqpActiveInventory", billingEventBody);

                // Handle response when Total is 0
                if (response?.Data?.Data?.Total == 0)
                {
                    //TempData["IsSuccess"] = false;
                    //TempData["OverallMessage"] = "Invoice Not Found";
                    return NotFound("Container Not Found");
                }
                // Handle non-200 status responses
                else if (response?.Data?.Status != 200)
                {
                    //TempData["IsSuccess"] = false;
                    //TempData["OverallMessage"] = response?.Data?.Message;
                    return BadRequest(new { message = response?.Data?.Message });
                }

                // Extract Total from the response
                var total = response.Data?.Data?.Records[0];
                ViewBag.Total = total;
                //if (total == null || total == 0)
                //{
                //    return NotFound("No valid Container found.");
                //}

                // Return the Total value if successful
                return Ok(total);
            }
            catch (Exception ex)
            {
                // Log the exception (optional logging mechanism)
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");

                // Send an error email notification
                //var receivers = _configuration.GetSection("MailSettings:Receiver").Get<List<string>>();
                //var subject = "Error in CheckContainerExist API";
                //var message = $"Error Happened: {ex.Message}";
                //_mailService.SendMailAsync(receivers, subject, message);

                // Return a 500 Internal Server Error with the error message
                return StatusCode(500, new { message = "An error occurred while processing your request.", error = ex.Message });
            }
        }


         }
}

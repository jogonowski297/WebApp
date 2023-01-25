using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models.Domain;
using WebApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace WebApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext applicationDbContrext;

        private readonly UserManager<ApplicationUser> _userManager;

 

        public DashboardController(ApplicationDbContext applicationDbContrext, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            this.applicationDbContrext = applicationDbContrext;
        }


        public IActionResult Index()
        {
         
            return View();
        }


        public IActionResult Add()
        {
            return View();
        }

        public IActionResult AccidentNotifi()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTrainingFeesViewModel addTrainingFeeRequest)
        {

            string UserId = _userManager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                if(!UserId.IsNullOrEmpty())
                {
                    var trainingfee = new TrainingFees()
                    {
                        Id = Guid.NewGuid(),
                        MemberId = new Guid(UserId),
                        Track = addTrainingFeeRequest.Track,
                        TrainingDate = addTrainingFeeRequest.TrainingDate,
                        Fee = addTrainingFeeRequest.Fee


                    };

                    applicationDbContrext.TrainingFees.AddAsync(trainingfee);
                    applicationDbContrext.SaveChangesAsync();
                    return RedirectToAction("ViewTrainingFee");
                }    
      
            }
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> AccidentNotifiAdd(AddAccidentNotifiViewModel addAccident)
        {

            string UserId = _userManager.GetUserId(HttpContext.User);

            if (ModelState.IsValid)
            {
                if (!UserId.IsNullOrEmpty())
                {
                    var accident = new AccidentNotifi()
                    {
                        Id = Guid.NewGuid(),
                        Track = addAccident.Track,
                        Description = addAccident.Description,
                        Distance = addAccident.Distance

                    };

                    applicationDbContrext.AccidentNotifi.AddAsync(accident);
                    applicationDbContrext.SaveChangesAsync();
                    return RedirectToAction("AccidentNotifi");
                }

            }
            return View("~/views/shared/Error.cshtml");

        }


        [HttpGet]
        public IActionResult ViewTrainingFee()
        {
            var dc = applicationDbContrext;

            string UserId = _userManager.GetUserId(HttpContext.User);

            var feelist = dc.TrainingFees.Where(x => x.MemberId == new Guid(UserId)).ToList();

            return View(feelist);

        }
    }
}

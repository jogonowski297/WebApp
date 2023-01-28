using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;
using WebApp.Models.Domain;

namespace WebApp.Controllers
{
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext applicationDbContrext;

        public MemberController(ApplicationDbContext applicationDbContrext) 
        {
            this.applicationDbContrext = applicationDbContrext;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //if (User.IsInRole("Admin"))
            //{
            var members = await applicationDbContrext.Member.ToListAsync();
            return View(members);
            //}
            //return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Add()
        {
            if (User.IsInRole("Admin"))
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMemberViewModel addMemberRequest)
        {
            if (ModelState.IsValid)
            {
                var member = new Member()
                {
                    Id = Guid.NewGuid(),
                    Name = addMemberRequest.Name,
                    Surname = addMemberRequest.Surname,
                    Email = addMemberRequest.Email,
                    Phone = addMemberRequest.Phone,
                    Vehicle = addMemberRequest.Vehicle,
                    Brand = addMemberRequest.Brand,
                    Model = addMemberRequest.Model


                };

                applicationDbContrext.Member.AddAsync(member);
                applicationDbContrext.SaveChangesAsync();
                return RedirectToAction("Add");
            }
            return View();
            
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            if (User.IsInRole("Admin"))
            {
                var member = await applicationDbContrext.Member.FirstOrDefaultAsync(x => x.Id == id);

                if (member != null)
                {

                    var viewModel = new UpdateMemberViewModel()
                    {
                        Id = member.Id,
                        Name = member.Name,
                        Surname = member.Surname,
                        Email = member.Email,
                        Phone = member.Phone,
                        Vehicle = member.Vehicle,
                        Brand = member.Brand,
                        Model = member.Model
                    };


                    return await Task.Run(() => View("View", viewModel));

                }

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateMemberViewModel viewModel)
        {
            var member = await applicationDbContrext.Member.FindAsync(viewModel.Id);
            
            if(member != null)
            {
                member.Name = viewModel.Name;
                member.Surname = viewModel.Surname;
                member.Email = viewModel.Email;
                member.Phone = viewModel.Phone;
                member.Vehicle = viewModel.Vehicle;
                member.Brand = viewModel.Brand;
                member.Model = viewModel.Model;

                await applicationDbContrext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]

        public async Task<IActionResult> Delete(UpdateMemberViewModel viewModel)
        {
            var member = await applicationDbContrext.Member.FindAsync(viewModel.Id);

            if(member != null )
            {
                applicationDbContrext.Member.Remove(member);
                await applicationDbContrext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}

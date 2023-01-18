using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddMemberViewModel addMemberRequest)
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


    }
}

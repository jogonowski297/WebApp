using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using WebApp.Controllers;
using WebApp.Models;
using WebApp.Data;
using System;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApp.Test
{
    [TestClass]
    public class MemberControllerTests
    {

        private DbContextOptionsBuilder<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>()
                                .UseSqlServer("Data Source=DESKTOP-31B7FSI;Initial Catalog=GAMK; Integrated Security=true; TrustServerCertificate=True");


        [TestMethod]
        public void FirstNameOfMemebersTest()
        {
            var applicationDbContrext = new ApplicationDbContext(options.Options);

            var x = applicationDbContrext.Member.ToList();

            Assert.AreEqual(x[0].Name, "Jan");
        }

        [TestMethod]
        public async Task xxx()
        {
            var applicationDbContrext = new ApplicationDbContext(options.Options);

            var controller = new MemberController(applicationDbContrext);

            var result = await controller.Index() as ViewResult;

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task yyy()
        {
            var applicationDbContrext = new ApplicationDbContext(options.Options);

            var controller = new MemberController(applicationDbContrext);

            var result = await controller.Index() as ViewResult;

            Assert.AreEqual(result., 3);
        }
    }
}
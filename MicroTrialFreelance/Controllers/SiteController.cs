//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using MicroTrialFreelance;
//using MicroTrialFreelance.Routes;

//namespace MicroTrialFreelance.Controllers
//{
//    //    public class SiteController
//    //    {
//    //        public int Index()
//    //        {
//    //            return 5;
//    //        }
//    //        //[AllowAnonymous]
//    //        //public IActionResult AboutUs()
//    //        //{
//    //        //    return View();
//    //        //}
//    //    }
//    //}
//    [ApiController]
//    public class SiteController : ControllerBase
//    {
//        [HttpGet("api/news")]
//        public string GetSiteNews()
//        {
//            return "dddddddd";
//        }
//        [HttpGet("api/TestDa")]
//        public IActionResult GetTestUsers()
//        {
//            var users = new[]
//            {
//                new {Name = "da"},
//                new {Name = "da2" }
//            };
//            return Ok(users);
//        }
//    }
//}

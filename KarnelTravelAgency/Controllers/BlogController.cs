using Microsoft.AspNetCore.Mvc;

namespace KarnelTravelAgency.Controllers
{
    public class BlogController : Controller
    {
        [Route("/Blogs")]
        public IActionResult AllBlogs()
        {
            return View();
        }
        [Route("/Blogs/BlogDetails")]
        public IActionResult BlogDetails()
        {
            return View();
        }
    }
}

using Core.Web.Data;
using Core.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Linq.Dynamic.Core;

namespace Core.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IApplicationDbContext context)
        {
            _logger = logger;
            this._context = context;
        }

        public IActionResult Index()
        {
            var model = _context.Customers.ToList();
            return View(model);
        }


        [HttpPost]
        public JsonResult GetAllCustomers()
        {
            int pageLength = int.Parse(Request.Form["length"]);
            int start = int.Parse(Request.Form["start"]);
            int skip = start;
            int pageNumber = int.Parse(Request.Form["draw"]);
            string searchText = Request.Form["search[value]"];

            string sortColumnIndex = Request.Form["order[0][column]"];
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            string sortDir = Request.Form["order[0][dir"];


            var model = from customer in _context.Customers select customer;

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortDir)))
            {
                model = model.OrderBy(sortColumn + " " + sortDir);
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                model = model
                    .Where(x => string.IsNullOrEmpty(searchText) ? true :
                (x.FirstName.Contains(searchText) || x.LastName.Contains(searchText) || x.Contact.Contains(searchText) || x.Email.Contains(searchText)));
            }

            var data = model
                .Skip(start).Take(pageLength).ToList();


            int totalRecords = model.Count();
            var jsonData = new { data = data, recordsFiltered = totalRecords };
            return Json(jsonData);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
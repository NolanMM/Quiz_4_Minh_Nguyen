using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Quiz_4Minh_Nguyen.Entities;
using Quiz_4Minh_Nguyen.Models;
using System.Diagnostics;

namespace Quiz_4Minh_Nguyen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly BpmeasurementsContext _context;

        public HomeController(ILogger<HomeController> logger,BpmeasurementsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Bpmeasurement> bpMeasurements = _context.Bpmeasurements.Include(m => m.MeasurementPosition).OrderByDescending(record => record.MeasurementDate).ToList();
            return View(bpMeasurements);
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

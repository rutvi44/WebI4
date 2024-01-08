using InClass4.Entities;
using InClass4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace InClass4.Controllers
{
    public class HomeController : Controller
    {
        private readonly BPMeasurementsContext _bPMeasurementsContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, BPMeasurementsContext bPMeasurementsContext)
        {
            _logger = logger;
            _bPMeasurementsContext = bPMeasurementsContext;
        }

        public IActionResult Index()
        {
            var measurements = _bPMeasurementsContext.Bpmeasurements.Include(m => m.MeasurementPosition).OrderByDescending(m => m.MeasurementDate).ToList();
            return View(measurements);
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
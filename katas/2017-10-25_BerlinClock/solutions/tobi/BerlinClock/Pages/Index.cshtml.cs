using BerlinClock.Controller;
using BerlinClock.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BerlinClock.Pages
{
    public class IndexModel : PageModel
    {
        public const int SecondsToFetch = 5;

        private readonly ILogger<IndexModel> _logger;
        private readonly TimeController _timeController;
        public SegmentModel SegmentData { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, TimeController timeController)
        {
            _logger = logger;
            _timeController = timeController;
        }

        public void OnGet()
        {
            // Simulate Api Call
            SegmentData = _timeController.GetSegmentedTime();
        }
    }
}
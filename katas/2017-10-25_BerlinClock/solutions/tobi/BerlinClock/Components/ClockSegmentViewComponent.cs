using BerlinClock.Model;
using Microsoft.AspNetCore.Mvc;

namespace BerlinClock.Components
{
    [ViewComponent]
    public class ClockSegmentViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id, int segmentsNumber, int activeSegmentNumber)
        {
            return View("ClockSegment", new ClockSegmentModel() { Id = id, Segments = segmentsNumber, FilledSegments = activeSegmentNumber });
        }
    }
}

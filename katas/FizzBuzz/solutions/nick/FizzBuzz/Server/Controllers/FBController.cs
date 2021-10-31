using System.Collections.Generic;

using FizzBuzz.Shared.Domain.Model.Enums;
using FizzBuzz.Shared.Domain.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FizzBuzz.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public partial class FBController : ControllerBase
    {
        private readonly ILogger<FBController> Logger;
        private readonly IVariationDetectionService VariationDetectionService;
        private readonly IFBService FBService;

        public FBController(ILogger<FBController> logger, IVariationDetectionService variationDetectionService, IFBService fBService)
        {
            Logger = logger;
            VariationDetectionService = variationDetectionService;
            FBService = fBService;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return FBService.Get(EVariation.Contains, 10);
        //}

        [HttpGet]
        public IEnumerable<string> Get(int variationNumber, int max)
        {
            Logger.LogDebug("Detecting the variation...");
            EVariation variation = VariationDetectionService.Get(variationNumber);

            Logger.LogDebug("Getting data...");
            return FBService.Get(variation, max);
        }
    }
}
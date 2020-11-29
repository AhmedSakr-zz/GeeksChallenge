using GeeksChallenge.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GeeksChallenge.CloudLibrary.Application.Interfaces;
using GeeksChallenge.CloudLibrary.Dtos;

namespace GeeksChallenge.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IInfrastructureService _infrastructureService;

        public HomeController(ILogger<HomeController> logger, IInfrastructureService infrastructureService)
        {
            _logger = logger;
            _infrastructureService = infrastructureService;
        }

        public IActionResult Index()
        {
            //there is a bug in vs2019 if applicationUrl changed, it make the process fail :(
            // so i used redirect here 
            //reference https://stackoverflow.com/questions/58246822/http-error-500-35-ancm-multiple-in-process-applications-in-same-process-asp-ne/58695204#58695204
            return Redirect("/swagger");
        }

        
    }
}

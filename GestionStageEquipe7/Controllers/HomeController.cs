//asdasdasd
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GestionStageEquipe7.Models;
using GestionStageEquipe7.Services.Courriels;

namespace GestionStageEquipe7.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public IEmailService _EmailService { get; }
        public HomeController(ILogger<HomeController> logger, IEmailService emailService)
        {
            // Mon commentaire
            _logger = logger;
            _EmailService = emailService;
            //UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Privacy()
        {
            Exception erreur = await _EmailService.Send(new EmailMessage { Content = "Allo<br/><br/>Toi", FromAddresses = { new EmailAddress { Address = "linhkenny@live.ca", Name = "Kenny" } }, ToAddresses = { new EmailAddress { Address = "jemai2000@hotmail.com", Name = "Mehdi" } }, Subject = "Test travail" });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

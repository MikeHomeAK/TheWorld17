using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld17.Services;
using TheWorld17.ViewModels;

namespace TheWorld17.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }

        public IActionResult Index()
        {            
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if(ModelState.IsValid)
            { 
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "Test Subject", model.Message);
                ViewBag.UserMessage = "Message Sent!";
                ModelState.Clear();
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}

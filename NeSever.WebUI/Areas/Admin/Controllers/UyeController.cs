using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NeSever.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UyeController : BaseController
    {
        public UyeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

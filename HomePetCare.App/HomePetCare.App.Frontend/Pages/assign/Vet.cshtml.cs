using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HomePetCare.App.Frontend.Pages
{
    [Authorize]
    public class VetModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}

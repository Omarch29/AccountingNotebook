using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebookAPI.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingNotebookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IAccountNotebookService accountNotebookService;

        public DefaultController(IAccountNotebookService accountNotebookService)
        {
            this.accountNotebookService = accountNotebookService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAccountData() 
        {
            var response = await accountNotebookService.GetAccount();
            if (response != null)
            {
                return Ok(response);
            }
            return NotFound();
        }
    }
}

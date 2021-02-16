using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccountingNotebookAPI.Business;
using AccountingNotebookAPI.DTOs;
using AccountingNotebookAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AccountingNotebookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            this.transactionService = transactionService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetTransactions([FromQuery] PageParams pageParams)
        {
            var transactions = await transactionService.GetTransactions(pageParams);
            Response.AddPagination(transactions.CurrentPage, transactions.PageSize, transactions.TotalCount, transactions.TotalPages);
            return Ok(transactions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await transactionService.GetTransactionDetail(id);
            if (transaction == null)
            {
                return NotFound();
            } else
            {
                return Ok(transaction);
            }
        }


        [HttpPost]
        public IActionResult AddTransaction([FromBody]TransactionForAddDTO transaction)
        {
            var response = transactionService.AddTransaction(transaction);
            switch (response)
            {
                case TransactionReponses.ok:
                    return Ok();
                case TransactionReponses.insufficientfunds:
                    return BadRequest("Not enought funds");
                case TransactionReponses.exceedTheLimit:
                    return BadRequest("The transaction exceed the limit");
                case TransactionReponses.insufficientCredit:
                    return BadRequest("Not enought credit available");
                case TransactionReponses.error:
                    throw new Exception("Internal Error");
            }
            return NotFound();
        }
    }
}
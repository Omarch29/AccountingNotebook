using AccountingNotebookAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Business
{
    public interface IAccountNotebookService
    {
        Task<AccountDTO> GetAccount();
    }
}

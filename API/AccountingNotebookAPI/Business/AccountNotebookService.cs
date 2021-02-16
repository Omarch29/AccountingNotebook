using AccountingNotebookAPI.DATA;
using AccountingNotebookAPI.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountingNotebookAPI.Business
{
    public class AccountNotebookService: IAccountNotebookService
    {
        
        private readonly IAccountRepository accountRepository;
        private readonly IMapper _mapper;

        public AccountNotebookService(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<AccountDTO> GetAccount()
        {
            return _mapper.Map<AccountDTO>(await accountRepository.GetAccountAsync());
        }
    }
}

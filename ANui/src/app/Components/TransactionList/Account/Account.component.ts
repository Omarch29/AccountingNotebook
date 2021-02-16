import { Component, OnInit } from '@angular/core';
import { AccountService } from 'src/app/Services/account.service';
import { Account } from '../../../Models/Account';


@Component({
  selector: 'app-Account',
  templateUrl: './Account.component.html',
  styleUrls: ['./Account.component.css']
})
export class AccountComponent implements OnInit {

  account: Account = null;

  constructor(private accountService: AccountService) {
    this.accountService.GetAccount().subscribe(data => {
      this.account = data;
    })

    this.accountService.currentAccount.subscribe(data => {
      if(data) {
        this.account = data;
      }
    })
  }

  ngOnInit() {
  }

}

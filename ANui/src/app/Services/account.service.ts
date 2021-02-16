import { Injectable } from '@angular/core';
import { ApiService } from './api.service';
import { BehaviorSubject, Observable } from 'rxjs';
import { Account } from '../Models/Account';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  account = new BehaviorSubject<Account>(null);
  currentAccount = this.account.asObservable();

  constructor(private apiService: ApiService) { }

  GetAccount(): Observable<Account> {
    return this.apiService.get('default');
  }

  setNewAccount(account: Account) {
    this.account.next(account);
  }


}

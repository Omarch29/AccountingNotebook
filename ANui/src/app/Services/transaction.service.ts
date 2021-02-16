import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { TransactionDetail } from '../Models/TransactionDetail';
import { PaginatedResult } from '../Models/Paginate.model';
import { Transaction } from '../Models/Transaction';
import { TransactionForAdd } from '../Models/TransactionForAdd';

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  constructor(private apiService: ApiService) { }

  GetTransactionDetail(id: number): Observable<TransactionDetail> {
    return this.apiService.get('Transactions/' + id);
  }

  GetTransactionList( page?, itemsPerPage?): Observable<PaginatedResult<Transaction[]>> {
    return this.apiService.getPaginated('Transactions/', null ,page, itemsPerPage);
  }

  AddTransaction(transaction: TransactionForAdd): Observable<string> {
    return this.apiService.post('Transactions/', transaction);
  }



}

import { Component, OnInit } from '@angular/core';
import { ModalDismissReasons, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Transaction } from '../../Models/Transaction';
import { TransactionService } from '../../Services/transaction.service';
import { TransactionForAdd } from '../../Models/TransactionForAdd';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from '../../Services/account.service';
import { TransactionDetail } from '../../Models/TransactionDetail';

@Component({
  selector: 'app-TransactionList',
  templateUrl: './TransactionList.component.html',
  styleUrls: ['./TransactionList.component.css']
})
export class TransactionListComponent implements OnInit {

  transactions: Transaction[] = [];
  transactionDetailList: TransactionDetail[] = [];
  page = 1;
  pageSize=6;
  collectionSize=0;
  totalPages=0;
  closeResult = '';
  type=1;
  errorMessage='';

  transactionFormGroup = new FormGroup({
    amount: new FormControl('', Validators.required)
  });

  get amount() { return this.transactionFormGroup.get('amount'); }
  
  constructor(private transService: TransactionService, private modalService: NgbModal, private accService: AccountService) {
    this.transService.GetTransactionList(1, this.pageSize).subscribe(data => {
      this.transactions = data.result;
      this.collectionSize = data.pagination.totalItems;
      this.totalPages = data.pagination.totalPages;
    });
  }

  ngOnInit() {
  }

  loadList() {
    this.transService.GetTransactionList(this.page, this.pageSize).subscribe(data => {
      this.transactions = data.result;
    });
  }

  showModalForm(content) {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result) => {
      this.closeResult = `Closed with: ${result}`;
      console.log(result);
    }, (reason) => {
      this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
    });
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }

  setType(i: number){
    this.type = i;
  }


  SaveTransaction(modal) {
    let newTransaction: TransactionForAdd = { amount: 0, type: 1 };
    if (this.transactionFormGroup.value.amount !== 0 && this.type !== 0)
    {
      const formValue = this.transactionFormGroup.value;
      newTransaction.amount = formValue.amount;
      newTransaction.type = this.type;
    }
    else {
      this.errorMessage = 'Invalid Input'
      return;
    }

    this.transService.AddTransaction(newTransaction).subscribe((data: any) => {
        modal.close();
        this.RefreshListAfterAddnewItem();
        this.RefreshAccount();
        this.errorMessage=''
    }, error => {
      this.errorMessage = error.error;
    });

    this.transactionFormGroup.reset();
    this.type = 1;
  }


  RefreshListAfterAddnewItem() 
  {
    let newCollectionSize = this.collectionSize + 1;
    let newTotalPages = Math.ceil(newCollectionSize / this.pageSize);
    let pageToShow = newTotalPages;
    this.page = pageToShow;
    this.transService.GetTransactionList(pageToShow, this.pageSize).subscribe(data => {
      this.transactions = data.result;
      this.collectionSize = data.pagination.totalItems;
      this.totalPages = data.pagination.totalPages;
    });
  }

  RefreshAccount() {
    this.accService.GetAccount().subscribe(data => {
      this.accService.setNewAccount(data);
    })
  }

  GetDetailData(id: number) {
    if (this.transactionDetailList.filter(x => x.id === id).length === 0) {
    this.transService.GetTransactionDetail(id).subscribe(data => {
        this.transactionDetailList.push(data);  
    });
    }
  }

  DetailTransaction(id: number): TransactionDetail {
    return this.transactionDetailList.filter(x => x.id === id)[0];
  }

}

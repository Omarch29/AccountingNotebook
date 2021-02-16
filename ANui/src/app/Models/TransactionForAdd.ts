export enum transactionType {
    credit = 1,
    debit = 2,
}

export interface TransactionForAdd {
    type: transactionType;
    amount: number
}

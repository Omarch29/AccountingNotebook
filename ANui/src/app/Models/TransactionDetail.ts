export interface TransactionDetail {
    id: number;
    type: string;
    amount: number;
    effectiveDate: Date;
    balanceAmount: number;
    creditBalance: number;
}

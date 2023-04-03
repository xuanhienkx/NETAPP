export interface ICustomer {
    customerId: string;
    email: string;
    isActive: boolean;
    mobile: string;
    name: string;
}

export interface ICustomerResult {
    list: ICustomer[];
    totalCount:number;
} 
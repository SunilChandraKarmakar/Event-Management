export class PaymentCreateViewModel {
    id: number;
    userId: string;
    foodId: number;
    venueId: number;
    paymentTypeId: number;
    totalAmmount: number;
    isPaymentComplete: boolean;
    paymentDate: Date;
}
import { FoodViewModel } from "../food/food-view-model";
import { PaymentTypeViewModel } from "../paymenttype/payment-type-view-model";
import { UserViewModel } from "../user/user-view-model";
import { VenueViewModel } from "../venue/venue-view-model";

export class PaymentViewModel {
    id: number;
    userId: string;
    foodId: number;
    venueId: number;
    paymentTypeId: number;
    totalAmmount: number;
    isPaymentComplete: boolean;
    paymentDate: Date;
    
    user: UserViewModel;
    paymentType: PaymentTypeViewModel;
    food: FoodViewModel;
    venue: VenueViewModel;
}
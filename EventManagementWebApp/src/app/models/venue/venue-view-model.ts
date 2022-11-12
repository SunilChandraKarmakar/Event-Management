import { EventTypeViewModel } from "../eventtype/eventtype-view-model";
import  { UserViewModel } from "../user/user-view-model";
import { VenueTypeViewModel } from "../venuetype/venuetype-view-model";

export class VenueViewModel {
    id: number;
    title: string
    userId: string;
    eventTypeId: number;
    VenueTypeId: number;
    noOfGuest: number;
    bookingDate: Date;

    user: UserViewModel;
    eventType: EventTypeViewModel;
    venueType: VenueTypeViewModel
}
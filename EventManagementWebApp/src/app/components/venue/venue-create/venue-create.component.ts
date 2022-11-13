import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { EventTypeViewModel } from 'src/app/models/eventtype/eventtype-view-model';
import { VenueCreateViewModel } from 'src/app/models/venue/venue-create-view-model';
import { VenueTypeViewModel } from 'src/app/models/venuetype/venuetype-view-model';
import { EventtypeService } from 'src/app/services/eventtype.service';
import { VenueService } from 'src/app/services/venue.service';
import { VenuetypeService } from 'src/app/services/venuetype.service';

@Component({
  selector: 'app-venue-create',
  templateUrl: './venue-create.component.html',
  styleUrls: ['./venue-create.component.scss']
})

export class VenueCreateComponent implements OnInit {

  // Login user id
  private _loginUserId: string | undefined;
  private _loginUserInfo: any;

  // Venue create view model
  model: VenueCreateViewModel = new VenueCreateViewModel();

  // Select list model
  eventTypeSelectList: EventTypeViewModel[];
  venueTypeSelectList: VenueTypeViewModel[];

  constructor(private _venueService: VenueService, private _spinnerService: NgxSpinnerService, 
  private _toastrService: ToastrService, private _router: Router, private _eventTypeService: EventtypeService, private _venueTypeService: VenuetypeService) { }

  ngOnInit() {
    this._spinnerService.show();
    this.getLoginUserInfo();
    this.getEventTypes();
    this.getVenueTypes();
    this._spinnerService.hide();
  }

  private getLoginUserInfo(): void {
    this._loginUserInfo = JSON.parse(localStorage.getItem("loginUserInfo")!);
    
    if(this._loginUserInfo == null || this._loginUserInfo == undefined) {
      this._toastrService.error("You can not login user! Please, login first.", "Error");
      this._router.navigate(['/login']);
    }
    else {
      this._loginUserId = this._loginUserInfo.dataSet.id;
    }
  }

  private getEventTypes(): void {
    this._spinnerService.show();
    this._eventTypeService.getEventTypes().subscribe((res) => {
      this._spinnerService.hide();
      this.eventTypeSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Event Types can not load! Try again.", "Error");
    })
  }

  private getVenueTypes(): void {
    this._spinnerService.show();
    this._venueTypeService.getVenueTypes().subscribe((res) => {
      this._spinnerService.hide();
      this.venueTypeSelectList = res;
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Venue Types can not load! Try again.", "Error");
    })
  }

  onSaveVenue(): void {
    if(this.model.title == null || this.model.title == undefined) {
      this._toastrService.warning("Please, provied title.", "Warning");
      return;
    }
    else if(this.model.eventTypeId == null || this.model.eventTypeId == undefined) {
      this._toastrService.warning("Please, select event type.", "Warning");
      return;
    }
    else if(this.model.venueTypeId == null || this.model.venueTypeId == undefined) {
      this._toastrService.warning("Please, select venue type.", "Warning");
      return;
    }
    else if(this.model.noOfGuest == null || this.model.noOfGuest == undefined) {
      this._toastrService.warning("Please, provied no. of guest.", "Warning");
      return;
    }
    else if(this.model.bookingDate == null || this.model.bookingDate == undefined) {
      this._toastrService.warning("Please, select booking date.", "Warning");
      return;
    }
    else if(this.model.venueAmount == null || this.model.venueAmount == undefined) {
      this._toastrService.warning("Please, provied amount.", "Warning");
      return;
    }
    else {
      this._spinnerService.show();
      this.model.userId = this._loginUserId!;
      this._venueService.create(this.model).subscribe((res) => {
        this._spinnerService.hide();
        this._toastrService.success("Venue create successfull.", "Successfull");
        this._router.navigate(['/venues']);
        return;
      }, 
      (error) => {
        this._spinnerService.hide();
        this._toastrService.error("Venue can not created! Try again.", "Error");
        return;
      })
    }
  }
}
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { VenueViewModel } from 'src/app/models/venue/venue-view-model';
import { VenueService } from 'src/app/services/venue.service';

@Component({
  selector: 'app-venue-list',
  templateUrl: './venue-list.component.html',
  styleUrls: ['./venue-list.component.scss']
})

export class VenueListComponent implements OnInit {

  // Login user id
  private _loginUserId: string | undefined;
  private _loginUserInfo: any;

  // Venues
  venues: VenueViewModel[];

  // Datatable settings
  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();

  constructor(private _venueService: VenueService, private _spinnerService: NgxSpinnerService, 
  private _toastrService: ToastrService, private _router: Router) { }
  
  ngOnInit() {
    this._spinnerService.show();
    this.getLoginUserInfo();
    this.getVenues();

    this.dtOptions = {
      pagingType: 'full_numbers',
      pageLength: 10
    };

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

  private getVenues(): void {
    this._spinnerService.show();
    this._venueService.getVenues(this._loginUserId!).subscribe((res) => {
      this.venues = res;
      this.dtTrigger.next();
      this._spinnerService.hide();
      return;
    },
    (error) => {
      this._spinnerService.hide();
      console.log("Error :- ", error);
      this._toastrService.error(error, "Error");
      return;
    })
  }

  ngOnDestroy(): void {
    // Do not forget to unsubscribe the event
    this.dtTrigger.unsubscribe();
  }

  onDelete(id: number): void {
    if(id == null) {
      this._toastrService.warning("Id can not find! Try again", "Warning");
      return
    }

    this._spinnerService.show();
    this._venueService.delete(id).subscribe((res) => {
      this._spinnerService.hide();
      this._toastrService.success("Venue delete successfull.", "Successfull");
      this.ngOnInit();
    },
    (error) => {
      this._spinnerService.hide();
      this._toastrService.error("Venue can not deleted! Try again.", "Error");
      return;
    });
  }
}
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { DataTablesModule } from "angular-datatables";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxSpinnerModule } from 'ngx-spinner';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { VenueCreateComponent } from './components/venue/venue-create/venue-create.component';
import { VenueListComponent } from './components/venue/venue-list/venue-list.component';
import { VenueEditComponent } from './components/venue/venue-edit/venue-edit.component';
import { FoodListComponent } from './components/food/food-list/food-list.component';
import { FoodCreateComponent } from './components/food/food-create/food-create.component';
import { FoodEditComponent } from './components/food/food-edit/food-edit.component';
import { PaymentCreateComponent } from './components/payment-create/payment-create.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    DashboardComponent,
    VenueCreateComponent,
    VenueListComponent,
    VenueEditComponent,
    FoodListComponent,
    FoodCreateComponent,
    FoodEditComponent,
    PaymentCreateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule, // ToastrModule added
    ToastrModule.forRoot(), // ToastrModule added
    NgxSpinnerModule,
    DataTablesModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { VenueCreateComponent } from './components/venue/venue-create/venue-create.component';
import { VenueEditComponent } from './components/venue/venue-edit/venue-edit.component';
import { VenueListComponent } from './components/venue/venue-list/venue-list.component';

const routes: Routes = [
  { path: '', component: LoginComponent, pathMatch: 'full' },
  { path: '', component: LoginComponent },
  { path: 'login', component: LoginComponent, pathMatch: 'full' },
  { path: 'register', component: RegisterComponent, pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent, pathMatch: 'full' },
  { path: 'venues', component: VenueListComponent, pathMatch: 'full' },
  { path: 'venue/create', component: VenueCreateComponent, pathMatch: 'full' },
  { path: 'venue/edit/:recordId', component: VenueEditComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { Routes, RouterModule } from '@angular/router';
import { DataService } from 'src/services/data.service';
import { AppComponent } from './app.component';
import { NavComponent } from './Components/nav/nav.component';
import { AddPatientComponent } from './Components/add-patient/add-patient.component';
import { ListPatientComponent } from './Components/list-patient/list-patient.component';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PatientsListResolver } from 'src/resolvers/patients-list.resolver';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

const appRoutes:Routes = [
   { path:'', component: ListPatientComponent, resolve: {patientList: PatientsListResolver}},
   { path:'add', component: AddPatientComponent},
];

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      ListPatientComponent,
      AddPatientComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      RouterModule.forRoot(appRoutes),
      AccordionModule.forRoot(),
      PaginationModule.forRoot(),
      BsDatepickerModule.forRoot()
   ],
   providers: [
      DataService,
      PatientsListResolver
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

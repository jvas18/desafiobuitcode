import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ModalModule } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { AppComponent } from './app.component';
import { DoctorsComponent } from './Doctors/Doctors.component';
import {DoctorsEditComponent} from './Doctors/DoctorsEdit/DoctorsEdit.component'
import {DoctorsCreateComponent} from './Doctors/DoctorsCreate/DoctorsCreate.component';
import { NavComponent } from './Nav/Nav.component';
import { PatientsComponent } from './Patients/Patients.component';
import {PatientsCreateComponent} from './Patients/PatientsCreate/PatientsCreate.component';
import {TituloComponent} from './_shared/titulo/titulo.component';
import {Validacoes} from 'src/app/_validators/Validacoes';
import { PatientsEditComponent } from './Patients/PatientsEdit/PatientsEdit.component';
import { PatientsDoctorComponent } from './Patients-Doctor/Patients-Doctor.component';
import { PatientsdoctorgridComponent } from './Patients-Doctor/patientsdoctorgrid/patientsdoctorgrid.component';




@NgModule({
  declarations: [			
      AppComponent,
      DoctorsComponent,
      DoctorsEditComponent,
      DoctorsCreateComponent,
      NavComponent,
      PatientsComponent,
      PatientsCreateComponent,
      PatientsEditComponent,
      TituloComponent,
      PatientsDoctorComponent,
      PatientsdoctorgridComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    BsDropdownModule.forRoot(),
    TooltipModule.forRoot(),
    FormsModule,
    BsDatepickerModule.forRoot(),
    ModalModule.forRoot(),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

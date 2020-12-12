import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DoctorsComponent } from './Doctors/Doctors.component';
import { DoctorsCreateComponent } from './Doctors/DoctorsCreate/DoctorsCreate.component';
import { DoctorsEditComponent } from './Doctors/DoctorsEdit/DoctorsEdit.component';
import { PatientsDoctorComponent } from './Patients-Doctor/Patients-Doctor.component';
import { PatientsdoctorgridComponent } from './Patients-Doctor/patientsdoctorgrid/patientsdoctorgrid.component';
import { PatientsComponent } from './Patients/Patients.component';
import { PatientsCreateComponent } from './Patients/PatientsCreate/PatientsCreate.component';
import { PatientsEditComponent } from './Patients/PatientsEdit/PatientsEdit.component';


const routes: Routes = [

  {path: 'doctors', component: DoctorsComponent},
  {path: 'doctors/:id/edit', component: DoctorsEditComponent},
  {path: 'doctors/create', component: DoctorsCreateComponent},
  {path: 'patients', component: PatientsComponent},
  {path: 'patients/:id/edit', component: PatientsEditComponent},
  {path: 'patients/create',component:PatientsCreateComponent},
  {path: 'doctor-patients', component: PatientsDoctorComponent},
  {path: 'doctor-patients/:id/grid', component: PatientsdoctorgridComponent}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {


 }

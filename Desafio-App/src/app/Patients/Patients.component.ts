import { Component, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { PatientService } from '../_services/patient.service';
import { Patient } from '../_models/Patient';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { FormGroup } from '@angular/forms';
import { DoctorService } from '../_services/doctor.service';
import { Doctor } from '../_models/Doctor';

@Component({
  selector: 'app-Patients',
  templateUrl: './Patients.component.html',
  styleUrls: ['./Patients.component.css']
})
export class PatientsComponent implements OnInit {

  patients: Patient [];
  _filtroLista: string;

  get filtroLista():string{
      return this.filtroLista;
  }
  set filtroLista(value:string){
    this._filtroLista = value;
    this.filteredPatients = this.filtroLista ? this.filterPatients(value) : this.patients;

  }
  title = 'Patients';
  registerForm : FormGroup;
  bodyDeletarPatient= '';
  modalRef: BsModalRef;
  patient: Patient;
  filteredPatients : Patient[];
  doctors: Doctor[];

  
  constructor(private patientService: PatientService,
              private doctorService: DoctorService) { }

  ngOnInit() {
    this.getPatients();
    this.getDoctors();
  }
  filterPatients(filterBy: string):Patient[]{
    debugger
    return this.patients.filter(
      patient => patient.doctorId.indexOf(filterBy) !== -1
    );

  }
  getDoctors(){
    this.doctorService.getDoctors().subscribe((_doctors: Doctor[])=> {
      this.doctors = _doctors;
      
     },error=>{
       console.log(error);
     }
 
    );
   }
  getPatients(){
    this.patientService.getPatients().subscribe(response => {
      this.patients = response; 
     },error=>{
       console.log(error);
     }
 
    );
   }
   excluirPatient(patient: Patient, template: any) {
    debugger
    template.show();
    this.patient = patient;
    this.bodyDeletarPatient = `Do you have sure that you want to delete  ${patient.name}, Code: ${patient.id}?`;
  }
  confirmDelete(template: any) {
    debugger
    this.patientService.deletePatient(this.patient.id).subscribe(
      () => {
          template.hide();
          this.getPatients();
        }, error => {
          console.log(error);
        }
    );
  }

}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Doctor } from '../_models/Doctor';
import { DoctorService } from '../_services/doctor.service';
import { PatientService } from '../_services/patient.service';


@Component({
  selector: 'app-Patients-Doctor',
  templateUrl: './Patients-Doctor.component.html',
  styleUrls: ['./Patients-Doctor.component.scss']
})
export class PatientsDoctorComponent implements OnInit {

  title = 'Doctor´s Patients';
  registerForm : FormGroup;
  doctors: Doctor[];
  doctorId: string;
  constructor(private doctorService: DoctorService
            
  ) 
  {

  }
  validation(){
    this.registerForm = new FormGroup(({
    doctorId: new FormControl('', [Validators.required])
  }));
}


  ngOnInit() {
    this.getDoctors();
    this.validation();
  }

  getValue(id: string){
    console.log(id);
    this.doctorId = id;
    console.log(this.doctorId);
  }
  
  getDoctors(){
    debugger
    this.doctorService.getDoctors().subscribe((_doctors: Doctor[])=> {
      this.doctors = _doctors;
      console.log(this.doctors);
     },error=>{
       console.log(error);
     }
 
    );
   }

}

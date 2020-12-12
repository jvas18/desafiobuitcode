import { Component, OnInit, TemplateRef } from '@angular/core';
import { Doctor } from '../_models/Doctor';
import { DoctorService } from '../_services/doctor.service';
import {FormGroup} from'@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-Doctors',
  templateUrl: './Doctors.component.html',
  styleUrls: ['./Doctors.component.scss']
})
export class DoctorsComponent implements OnInit {


  doctors: Doctor[];
  doctor :Doctor;
  title = 'Doctors';
  registerForm : FormGroup;
  bodyDeletarDoctor= '';
  modalRef: BsModalRef;
  
  constructor(private doctorService: DoctorService,
              private modalService: BsModalService) { }

  ngOnInit() {
    this.getDoctors();
    console.log(this.doctors);
  }
  openModal(template: TemplateRef<any>){
    this.modalRef= this.modalService.show(template);

  }

  getDoctors(){
   this.doctorService.getDoctors().subscribe((_doctors: Doctor[])=> {
     this.doctors = _doctors;
     
    },error=>{
      console.log(error);
    }

   )
  }
  excluirDoctor(doctor: Doctor, template: any) {
    debugger
    template.show();
    this.doctor = doctor;
    this.bodyDeletarDoctor = `Do you have sure that you want to delete Dr. ${doctor.name}, Code: ${doctor.id}?`;
  }
  
  confirmDelete(template: any) {
    this.doctorService.deleteDoctor(this.doctor.id).subscribe(
      () => {
          template.hide();
          this.getDoctors();
        }, error => {
          console.log(error);
        }
    );
  }

}

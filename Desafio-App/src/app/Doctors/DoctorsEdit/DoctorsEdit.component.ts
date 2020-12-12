import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Doctor } from 'src/app/_models/Doctor';
import { DoctorService } from 'src/app/_services/doctor.service';
@Component({
  selector: 'app-DoctorsEdit',
  templateUrl: './DoctorsEdit.component.html',
  styleUrls: ['./DoctorsEdit.component.css']
})
export class DoctorsEditComponent implements OnInit {
  title='Edit - Doctor';
  registerForm : FormGroup;
  doctor:Doctor = new Doctor()

  constructor(
    private fb : FormBuilder,
    private doctorService: DoctorService,
    private router : ActivatedRoute
    
  ) {
   
   }

  ngOnInit() {
    this.validation();
    this.LoadDoctor();
  }
  LoadDoctor(){
    const idDoctor = this.router.snapshot.paramMap.get('id');
    this.doctorService.getDoctor(idDoctor).subscribe(
      (doctor: Doctor) => {
        this.doctor = Object.assign({}, doctor);
        
       this.registerForm.patchValue(this.doctor);
      }
    )

  }
  validation(){
    this.registerForm = new FormGroup({
    name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]),
    crm: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]),
    crmUf: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(2)])
  });

  }
  salvarAlteracao(){
    this.doctor = Object.assign({id: this.doctor.id},this.registerForm.value);

    this.doctorService.editDoctor(this.doctor).subscribe(
      ()=>{
       console.log("funcionou");
      }, error =>{
        console.log("erro");
      }
    )

    

  }

}

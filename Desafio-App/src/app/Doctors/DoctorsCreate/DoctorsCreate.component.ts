import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Doctor } from 'src/app/_models/Doctor';
import { DoctorService } from 'src/app/_services/doctor.service';

@Component({
  selector: 'app-DoctorsCreate',
  templateUrl: './DoctorsCreate.component.html',
  styleUrls: ['./DoctorsCreate.component.css']
})
export class DoctorsCreateComponent implements OnInit {
  title='Create - Doctor';
  registerForm : FormGroup;
  doctor:Doctor = new Doctor()
  
  constructor(private fb : FormBuilder,
    private doctorService: DoctorService,
    private router : ActivatedRoute) { }

  ngOnInit() {
    this.validation();
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

    this.doctorService.createDoctor(this.doctor).subscribe(
      ()=>{
       console.log("funcionou");
      }, error =>{
        console.log("erro");
      }
    )

  }

}

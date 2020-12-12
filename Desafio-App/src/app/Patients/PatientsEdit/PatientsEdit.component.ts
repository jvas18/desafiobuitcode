import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { Doctor } from 'src/app/_models/Doctor';
import { Patient } from 'src/app/_models/Patient';
import { DoctorService } from 'src/app/_services/doctor.service';
import { PatientService } from 'src/app/_services/patient.service';
import { Validacoes } from 'src/app/_validators/Validacoes';

@Component({
  selector: 'app-PatientsEdit',
  templateUrl: './PatientsEdit.component.html',
  styleUrls: ['./PatientsEdit.component.scss']
})
export class PatientsEditComponent implements OnInit {
  title='Create - Patient';
  registerForm : FormGroup;
  patient:Patient = new Patient()
  doctors: Doctor[];
  doctorid ='';

  constructor(private patientService: PatientService,
              private doctorService: DoctorService,
            private fb : FormBuilder,
            private localeService: BsLocaleService,
              private router : ActivatedRoute) {

                this.localeService.use('pt-br');
               }

  ngOnInit() {
    
    this.getDoctors();
    this.validation();
    this.LoadPatient();
  }
  getDoctors(){
    this.doctorService.getDoctors().subscribe((_doctors: Doctor[])=> {
      this.doctors = _doctors;
     },error=>{
       console.log(error);
     }
 
    )
   }
  validation(){
    this.registerForm = new FormGroup(({
    name: new FormControl('', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]),
    cpf: new FormControl('', [Validators.required, Validacoes.ValidaCpf]),
    birthDate: new FormControl('', [Validators.required]),
    doctorId: new FormControl('', [Validators.required])
  }));

  }
  getValue(id: string){
    console.log(id);
    this.doctorid = id;
    console.log(this.doctorid);
  }
  LoadPatient(){
    const idPatient = this.router.snapshot.paramMap.get('id');
    
    this.patientService.getPatient(idPatient).subscribe(
      (patient: Patient) => {
        this.patient = Object.assign({}, patient);
       this.registerForm.patchValue(this.patient);
      }
    )


  }
  salvarAlteracao(){
    debugger
    this.patient = Object.assign({id: this.patient.id},this.registerForm.value);
    

    this.patientService.editPatient(this.patient).subscribe(
      ()=>{
       console.log("funcionou");
      }, error =>{
        console.log("erro");
      }
    )

  }
}

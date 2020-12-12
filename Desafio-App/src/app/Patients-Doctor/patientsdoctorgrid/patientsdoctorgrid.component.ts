import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Patient } from 'src/app/_models/Patient';
import { PatientService } from 'src/app/_services/patient.service';

@Component({
  selector: 'app-patientsdoctorgrid',
  templateUrl: './patientsdoctorgrid.component.html',
  styleUrls: ['./patientsdoctorgrid.component.scss']
})
export class PatientsdoctorgridComponent implements OnInit {

  title = 'Patients';
  filteredPatients : Patient[];


  constructor(
    private patientService: PatientService,
    private router : ActivatedRoute
  ) { }

  ngOnInit() {
    this.getPatients();
  }
  getPatients(){
    const doctorId = this.router.snapshot.paramMap.get('id');
    this.patientService.getPatientsByDoctorId(doctorId).subscribe(response => {
      this.filteredPatients = response; 
     },error=>{
       console.log(error);
     }
 
    );
   }

}

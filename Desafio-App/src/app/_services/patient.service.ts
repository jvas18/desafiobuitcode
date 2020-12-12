import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Patient } from '../_models/Patient';

@Injectable({
  providedIn: 'root'
})
export class PatientService {
  baseUrl = 'http://localhost:5000/api/Patient';

  constructor(private http: HttpClient) { }
    getPatients():  Observable<Patient[]>{
      return this.http.get<Patient[]>(`${this.baseUrl}/patient-list`);
  
    }
    getPatientsByDoctorId(doctorId: string):  Observable<Patient[]>{
      return this.http.get<Patient[]>(`${this.baseUrl}/doctors-patients/${doctorId}`);
  
    }
    getPatient(id:string):  Observable<Patient>{
      return this.http.get<Patient>(`${this.baseUrl}/get-patient/${id}`);
  
    }
    createPatient(patient: Patient){
      return this.http.post(`${this.baseUrl}/add`,patient);

    }
    editPatient(patient:Patient){
      return this.http.post(`${this.baseUrl}/edit-patient`,patient)
    }
    deletePatient(id: string){
      return this.http.delete(`${this.baseUrl}/delete-patient/${id}`);
    }


}

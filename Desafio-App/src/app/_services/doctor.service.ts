import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Doctor } from '../_models/Doctor';

@Injectable({
  providedIn: 'root'
})
export class DoctorService {
  baseUrl = 'http://localhost:5000/api/Doctor';

constructor(private http: HttpClient) { }
  getDoctors(): Observable<Doctor[]>{
    return this.http.get<Doctor[]>(`${this.baseUrl}/doctors-list`);

  }

  getDoctor(id:string): Observable<Doctor>{
    return this.http.get<Doctor>(`${this.baseUrl}/get-doctor/${id}`);

  }

  editDoctor(doctor:Doctor){
   return this.http.post(`${this.baseUrl}/edit-doctor`,doctor);
  }

  createDoctor(doctor: Doctor){
    return this.http.post(`${this.baseUrl}/add-doctor`,doctor);
  }
  deleteDoctor(id: string){
    return this.http.delete(`${this.baseUrl}/delete-doctor/${id}`);
  }
}


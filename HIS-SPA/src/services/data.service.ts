import { PaginatedResult } from './../models/ViewModels/Pagination';
import { Patient } from './../models/patient';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { PatientListViewModel } from 'src/models/ViewModels/patientListViewModel';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor(private http: HttpClient) { }
  baseUrl: string = environment.apiUrl;

  getPatients(page?, itemsPerPage?,userParams?): Observable<PaginatedResult<PatientListViewModel[]>> {
    const paginatedResult: PaginatedResult<PatientListViewModel[]> = new PaginatedResult<PatientListViewModel[]>();
    let params = new HttpParams();

    if (page != null && itemsPerPage != null) {
      params = params.append('pageNumber', page);
      params = params.append('pageSize', itemsPerPage);
    }

    if (userParams != null) {
      params = params.append('gender', userParams.gender);
      params = params.append('name', userParams.name);
      params = params.append('nationality', userParams.nationality);
      params = params.append('mobileNumber', userParams.mobileNumber);
    }

    console.log(params);
    return this.http.get<PatientListViewModel[]>(this.baseUrl+ 'patients', { observe: 'response', params })
      .pipe(
        map(
          response => {
            paginatedResult.result = response.body;
            if (response.headers.get('Pagination') != null) {
              paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'))
            }
            return paginatedResult;
          }
        )
      );
  }

  deletePatient(id: string) {
    return this.http.delete<Patient[]>(this.baseUrl + id);
  }
  createPatient(patient: Patient) {
    return this.http.post(this.baseUrl+ 'patients', patient);
  }
  getPatientById(id: string) {
    return this.http.get<Patient>(this.baseUrl + '/' + id);
  }
  updatePatient(patient: Patient) {
    return this.http.put(this.baseUrl + '/' + patient.id, patient);
  }
}

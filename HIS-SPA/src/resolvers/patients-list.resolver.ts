import {Injectable} from '@angular/core';
import {Resolve, ActivatedRouteSnapshot} from '@angular/router';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { DataService } from 'src/services/data.service';
import { PatientListViewModel } from 'src/models/ViewModels/patientListViewModel';

@Injectable()
export class PatientsListResolver implements Resolve<PatientListViewModel[]> {
    pageNumber = 1;
    pageSize = 7;

    constructor(private service:DataService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<PatientListViewModel[]> {
        return this.service.getPatients(this.pageNumber, this.pageSize).pipe(
            catchError(error => {
                console.log(error);
                return of(null);
            })
        );
    }
}

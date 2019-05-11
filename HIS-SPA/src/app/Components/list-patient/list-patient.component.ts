import { Pagination, PaginatedResult } from './../../../models/ViewModels/Pagination';
import { DataService } from 'src/services/data.service';
import { Patient } from './../../../models/patient';
import { Component, OnInit } from '@angular/core';
import { PatientListViewModel } from 'src/models/ViewModels/patientListViewModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-list-patient',
  templateUrl: './list-patient.component.html',
  styleUrls: ['./list-patient.component.css']
})
export class ListPatientComponent implements OnInit {

  patientList:PatientListViewModel[];
  pagination: Pagination;
  genderList = [{value: 'Male', display: 'Males'}, {value: 'Female', display: 'Females'}];
  nationalityList = ['Afghanistan','Angola','Antigua and Barbuda','Barbados','Brazil','Brunei Darussalam','Bulgaria','China','Croatia (Hrvatska)','Cuba','Djibouti','Ecuador','El Salvador','Eritrea','Fiji','Finland','Ghana','Greenland','Guinea-Bissau','Iceland','Iran','Ireland','Korea (South)','Libya','Liechtenstein','Luxembourg','Macau','Macedonia','Madagascar','Marshall Islands','Mauritania','Montserrat','Nepal','Northern Mariana Islands','Norway','Oman','Pakistan','Palau','Paraguay','Pitcairn','Reunion','Romania','San Marino','Suriname','Tajikistan','Trinidad and Tobago','United Arab Emirates','Venezuela','Viet Nam','Yemen'];
  userParams: any = {};

  constructor(private service:DataService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.patientList = data['patientList'].result;
      this.pagination = data['patientList'].pagination;
    });

    this.userParams.gender = '';
    this.userParams.name = '';
    this.userParams.nationality = '';
    this.userParams.mobileNumber = '';
  }

  resetFilters(){
    this.userParams.gender = '';
    this.userParams.name = '';
    this.userParams.nationality = '';
    this.userParams.mobileNumber = '';
    this.loadPatients();
  }

  loadPatients(){
    console.log(this.userParams);
    this.service.getPatients(this.pagination.currentPage, this.pagination.itemsPerPage,this.userParams)
    .subscribe( (list:PaginatedResult<PatientListViewModel[]>) => {
      this.patientList = list.result;
      this.pagination = list.pagination;
    },
      error => console.log(error));
  }

  pageChanged(event: any): void {
    this.pagination.currentPage = event.page;
    this.loadPatients();
  }

}

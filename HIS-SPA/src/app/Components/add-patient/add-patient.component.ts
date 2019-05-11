import { Patient } from 'src/models/patient';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Name } from 'src/models/name';
import { Address } from 'src/models/address';
import { Identification } from 'src/models/identification';
import { ContactInformation } from 'src/models/contactInformation';
import { Guardian } from 'src/models/guardian';
import { Telephone } from 'src/models/telephone';
import { DataService } from 'src/services/data.service';
import { NgForm } from '@angular/forms';
@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.css']
})
export class AddPatientComponent implements OnInit {

  genderList = [{value: 'Male', display: 'Males'}, {value: 'Female', display: 'Females'}];
  nationalityList = ['Afghanistan','Angola','Antigua and Barbuda','Barbados','Brazil','Brunei Darussalam','Bulgaria','China','Croatia (Hrvatska)','Cuba','Djibouti','Ecuador','El Salvador','Eritrea','Fiji','Finland','Ghana','Greenland','Guinea-Bissau','Iceland','Iran','Ireland','Korea (South)','Libya','Liechtenstein','Luxembourg','Macau','Macedonia','Madagascar','Marshall Islands','Mauritania','Montserrat','Nepal','Northern Mariana Islands','Norway','Oman','Pakistan','Palau','Paraguay','Pitcairn','Reunion','Romania','San Marino','Suriname','Tajikistan','Trinidad and Tobago','United Arab Emirates','Venezuela','Viet Nam','Yemen'];
  insuranceList = ['Basic','Advanced','Premium'];
  maritalStatusList = ['Single','Married','Devorced'];
  guardianRelationList = ['None','GradeA','GradeB','Other']
  patient:Patient;
  @ViewChild('form') form: NgForm;
  constructor(private service:DataService) { }

  ngOnInit() {
    this.patient = new Patient();
    this.patient.patientName = new Name();
    this.patient.patientAddress = new Address();
    this.patient.PatientIdentification = new Identification();
    this.patient.PatientContactInformation = new ContactInformation();
    this.patient.PatientContactInformation.telephone = new Telephone();
    this.patient.PatientGuardian = new Guardian();
    this.patient.PatientGuardian.guardianAddress = new Address();
    this.patient.PatientGuardian.guardianName = new Name();
    this.patient.PatientGuardian.guardianTelephone = new Telephone();
  }

  onSubmit(){
        this.service.createPatient(this.patient)
          .subscribe(next => {
            this.form.reset();
          },error =>  console.log(error))
  }
}

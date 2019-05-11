import { Address } from './address';
import { Name } from './name';
import { Identification } from './identification';
import { ContactInformation } from './contactInformation';
import { Guardian } from './guardian';
export class Patient {
        id: string;
        creationDate: string;
        modificationDate: string;
        patientName:Name;
        patientAddress:Address;
        patientGender:string; 
        patientDateOfBirth: string;
        PatientIdentification:Identification;
        patientWorkTitle: string;
        PatientContactInformation:ContactInformation;
        PatientGuardian:Guardian;
        patientNationality: string;
        patientInsurance: string;
        patientMaritalStatus: string;
}


// [Id] [uniqueidentifier] NOT NULL,
// [CreationDate] [datetime2](7) NOT NULL,
// [ModificationDate] [datetime2](7) NOT NULL,

// [FirstName] [nvarchar](max) NOT NULL,
// [MidName] [nvarchar](max) NULL,
// [LastName] [nvarchar](max) NOT NULL,
// [Suffix] [nvarchar](max) NULL,

// [AddressLine1] [nvarchar](max) NOT NULL,
// [AddressLine2] [nvarchar](max) NOT NULL,
// [POBox] [nvarchar](max) NULL,

// [PatientGender] [nvarchar](max) NOT NULL,
// [PatientDateOfBirth] [datetime2](7) NOT NULL,

// [PassportNo] [nvarchar](max) NOT NULL,
// [EmirateId] [nvarchar](max) NOT NULL,
// [PatientWorkTitle] [nvarchar](max) NULL,
// [MailAddress] [nvarchar](max) NULL,
// [Mobile] [nvarchar](max) NOT NULL,
// [Home] [nvarchar](max) NULL,
// [Work] [nvarchar](max) NULL,
// [GuardianFirstName] [nvarchar](max) NULL,
// [GuardianMidName] [nvarchar](max) NULL,
// [GuardianLastName] [nvarchar](max) NULL,
// [GuardianSuffix] [nvarchar](max) NULL,
// [GuardianMobile] [nvarchar](max) NULL,
// [GuardianHome] [nvarchar](max) NULL,
// [GuardianWork] [nvarchar](max) NULL,
// [GuardianAddressLine1] [nvarchar](max) NULL,
// [GuardianAddressLine2] [nvarchar](max) NULL,
// [GuardianPOBox] [nvarchar](max) NULL,
// [GuardianRelation] [nvarchar](max) NOT NULL,
// [PatientNationality] [nvarchar](max) NOT NULL,
// [PatientInsurance] [nvarchar](max) NOT NULL,
// [PatientMaritalStatus] [nvarchar](max) NOT NULL
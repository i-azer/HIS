using System;
using HIS.Core.Enums;

namespace HIS.Core.Entities
{
    public class Patient : BaseEntity
    {
        public Name PatientName { get; set; }
        public Address PatientAddress { get; set; }
        public Sex PatientGender { get; set; }
        public DateTime PatientDateOfBirth { get; set; }
        public Identification PatientIdentification { get; set; }
        public string PatientWorkTitle { get; set; }
        public ContactInformation PatientContactInformation { get; set; }
        public Guardian PatientGuardian { get; set; }
        public string PatientNationality { get; set; }
        public Insurance PatientInsurance { get; set; }
        public MaritalStatus PatientMaritalStatus { get; set; }

    }
}
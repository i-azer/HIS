using System;

namespace HIS.Core.Dtos
{
    public class PatientListDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public Int16 Age { get; set; }
    }
}
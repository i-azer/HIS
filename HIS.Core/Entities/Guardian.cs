using HIS.Core.Enums;

namespace HIS.Core.Entities
{
    public class Guardian
    {
        public Name GuardianName { get; set; }
        public Telephone GuardianTelephone { get; set; }
        public Address GuardianAddress { get; set; }
        public Relation GuardianRelation { get; set; }
    }
}
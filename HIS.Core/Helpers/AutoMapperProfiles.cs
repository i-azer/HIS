using System;
using AutoMapper;
using HIS.Core.Dtos;
using HIS.Core.Entities;
using HIS.Core.Enums;

namespace HIS.Core.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Patient,PatientListDto>()
                .ForMember(destination => 
                    destination.FullName, member => 
                        member.MapFrom(source => 
                            $"{source.PatientName.FirstName} {source.PatientName.LastName}"))
                .ForMember(destination => 
                    destination.Address, member => 
                        member.MapFrom(source => 
                            $"AddressLine1: {source.PatientAddress.AddressLine1}<br/>AddressLine2: {source.PatientAddress.AddressLine2}"))
                .ForMember(destination => 
                    destination.Age, member => 
                        member.MapFrom(source => 
                            DateTime.Now.Year - source.PatientDateOfBirth.Year ))
                .ForMember(destination => 
                    destination.Gender,member => 
                        member.MapFrom(source => 
                            Enum.GetName(typeof(Sex),source.PatientGender)));
        }
    }
}
using System;
using System.Collections.Generic;
using HIS.Core.Entities;
using HIS.Core.Enums;
using Newtonsoft.Json;

namespace HIS.Infrastructure.DataBase
{
    public class Seed
    {
        private readonly ApplicationDbContext _context;
        public Seed(ApplicationDbContext context)
        {
            _context = context;
        }

        public void SeedPatients() 
        {
            var patientsData = System.IO.File.ReadAllText("E:/app/Core/HealthInformationSystem/HIS.Infrastructure/DataBase/patientSeedData.json");
            var patients = JsonConvert.DeserializeObject<List<Patient>>(patientsData);
            foreach (var patient in patients)
            {
                _context.Add(patient);
            }
            _context.SaveChanges();
        }
    }
}
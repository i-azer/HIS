using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HIS.Core.Dtos;
using HIS.Core.Entities;
using HIS.Core.Enums;
using HIS.Core.Helpers;
using HIS.Core.Interfaces;
using HIS.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace HIS.Infrastructure.Data
{
    public class Repository : IRepository
    {
       private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById<T>(Guid id) where T : Patient
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<PagedList<T>> List<T>(SearchParams searchParams) where T : Patient
        {
            var patients =  _dbContext.Set<T>().AsQueryable();
            if (!string.IsNullOrWhiteSpace(searchParams.Name))
            {
                patients = patients.Where(patient => patient.PatientName.FirstName.ToLower().Contains(searchParams.Name.ToLower())
                                               || patient.PatientName.LastName.ToLower().Contains(searchParams.Name.ToLower()) 
                                               || patient.PatientName.MidName.Contains(searchParams.Name.ToLower()));
            }
            if (!string.IsNullOrWhiteSpace(searchParams.Sex))
            {
                patients = patients.Where(patient => patient.PatientGender == (Sex)Enum.Parse(typeof(Sex),searchParams.Sex));
            }
            if (!string.IsNullOrWhiteSpace(searchParams.Nationality))
            {
                patients = patients.Where(patient => patient.PatientNationality.ToLower() == searchParams.Nationality.ToLower());
            }
            if (!string.IsNullOrWhiteSpace(searchParams.Telephone))
            {
                patients = patients.Where(patient => patient.PatientContactInformation.Telephone.Mobile.Contains(searchParams.Telephone));
            }
            return await PagedList<T>.CreateAsync(patients,searchParams.PageNumber,searchParams.PageSize);
        }

        public async Task<T> Add<T>(T entity) where T : Patient
        {
            await _dbContext.Set<T>().AddAsync(entity);
             _dbContext.SaveChanges();
            return entity;
        }

        public async void Delete<T>(T entity) where T : Patient
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async void Update<T>(T entity) where T : Patient
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
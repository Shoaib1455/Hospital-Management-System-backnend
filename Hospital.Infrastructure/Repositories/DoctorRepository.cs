using Hospital.Application.Interfaces;
using Hospital.Domain.Entities;
using Hospital.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Infrastructure.Repositories
{
    public class DoctorRepository: IDoctorRepository
    {
        private readonly HospitalContext _context;
        public DoctorRepository(HospitalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> UpdateDoctorAsync(Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FindAsync(doctor.Id);
            if (existingDoctor == null) return null;

            existingDoctor.Name = doctor.Name;
            existingDoctor.Specialization = doctor.Specialization;
            existingDoctor.PhoneNumber= doctor.PhoneNumber;
            existingDoctor.Email = doctor.Email;

            await _context.SaveChangesAsync();
            return existingDoctor;
        }

        //public async Task<bool> DeleteDoctorAsync(int id)
        //{
        //    var doctor = await _context.Doctors.FindAsync(id);
        //    if (doctor == null) return false;

        //    _context.Doctors.Remove(doctor);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}

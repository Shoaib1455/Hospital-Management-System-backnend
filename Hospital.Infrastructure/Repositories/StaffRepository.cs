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
    public class StaffRepository:IStaffRepository

    {
        private readonly HospitalContext _context;
        public StaffRepository(HospitalContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffAsync()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task<Staff> GetStaffByIdAsync(int id)
        {
            return await _context.Staffs.FindAsync(id);
        }

        public async Task<Staff> AddStaffAsync(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
            return staff;
        }

        public async Task<Staff> UpdateStaffAsync(Staff staff)
        {
            var existingStaff = await _context.Staffs.FindAsync(staff.Id);
            if (existingStaff == null) return null;

            existingStaff.Name = staff.Name;
            existingStaff.Role = staff.Role;
            existingStaff.PhoneNumber = staff.PhoneNumber;
            existingStaff.Email = staff.Email;

            await _context.SaveChangesAsync();
            return existingStaff;
        }

        //public async Task<bool> DeleteStaffAsync(int id)
        //{
        //    var staff = await _context.Staffs.FindAsync(id);
        //    if (staff == null) return false;

        //    _context.Staffs.Remove(staff);
        //    await _context.SaveChangesAsync();
        //    return true;
        //}
    }
}

using Hospital.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Application.Interfaces
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllStaffAsync();
        Task<Staff> GetStaffByIdAsync(int id);
        Task<Staff> AddStaffAsync(Staff staff);
        Task<Staff> UpdateStaffAsync(Staff staff);
       // Task<bool> DeleteStaffAsync(int id);
    }
}
